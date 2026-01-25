using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace UtilityCli;

public partial struct CliParseResult
{
    private readonly IReadOnlyList<string> _args;
    private readonly Dictionary<string, Option> _options = [];
    private readonly List<Argument> _arguments = [];
    private readonly List<char> _shortNamesUsed = [];
    private readonly Dictionary<string, ushort> _argCounter = [];

    public CliParseResult(IEnumerable<string> args)
    {
        _args = args.ToList();
    }

    // Cannot parse char values from command line arguments -- treat them as single-character strings
    private static char? ConvertStringToChar(string? value) => value switch
    {
        null or [] => null,
        [char c] => c,
        _ => throw new InvalidOperationException($"Cannot parse argument '{value}' as expected type 'System.Char'."),
    };

    private static char ConvertStringsToChars(string value) => value switch
    {
        [char c] => c,
        _ => throw new InvalidOperationException($"Cannot parse argument '{value}' as expected type 'System.Char'."),
    };

    private static T ThrowMissingRequiredArgument<T>() =>
        throw new ArgumentException($"Required argument of type '{typeof(T).Name}' was not provided.");

    private static T ThrowMissingRequiredOption<T>(string name) =>
        throw new ArgumentException($"Required option '--{name}' of type '{typeof(T).Name}' was not provided.", name);

    private bool? GetBooleanOption(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) =>
        TryGetOptionValue<bool>(out var value, name, aliases, shortNames) ? value : null;

    private T? GetNullableStructOptionValue<T>(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) where T : struct =>
        TryGetOptionValue<Nullable<T>>(out var value, name, aliases, shortNames) ? value : null;

    private T? GetNullableReferenceOptionValue<T>(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) where T : class =>
        TryGetOptionValue<T>(out var value, name, aliases, shortNames) ? value : null;

    private bool TryGetOptionValue<T>(out T? value, string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null)
    {
        if (_argCounter.Count > 0)
        {
            throw new InvalidOperationException("Named option values must be used before unnamed argument values. Otherwise, the named options and their values could be returned as argument values.");
        }

        // Infer the first character as a short name if it is not already used
        shortNames ??= (_shortNamesUsed.Contains(name[0]) ? [] : [name[0]]);

        if (_options.TryGetValue(name, out var option))
        {
            if (option is not Option<T> optionT)
            {
                throw new InvalidCastException($"Option '{name}' is not defined as type '{typeof(T).Name}'.");
            }

            var (rootCommand, config) = BuildParser();
            var success = TryGetResultValue<T>(rootCommand, config, optionT, out value, out var unmatchedTokens);

            // If the option was not found but it has a shortname and there are unmatched tokens,
            // it's possible that the option is bundled with other short names that haven't yet been defined as options.
            if (!success && shortNames.Any() && unmatchedTokens.Any())
            {
                success = TryGetOptionValueFromUnmatchedBundles(ref value, shortNames, optionT, unmatchedTokens);
            }

            return success;
        }

        option = BuildOption<T>(name, aliases ?? [], shortNames);
        _options.Add(name, option);
        _shortNamesUsed.AddRange(shortNames);

        var (newRootCommand, newConfig) = BuildParser();
        var newSuccess = TryGetResultValue(newRootCommand, newConfig, option, out value, out var newUnmatchedTokens);

        // If the option was not found but it has a shortname and there are unmatched tokens,
        // it's possible that the option is bundled with other short names that haven't yet been defined as options.
        if (!newSuccess && shortNames.Any() && newUnmatchedTokens.Any())
        {
            newSuccess = TryGetOptionValueFromUnmatchedBundles(ref value, shortNames, (Option<T>)option, newUnmatchedTokens);
        }

        return newSuccess;
    }

    private bool TryGetOptionValueFromUnmatchedBundles<T>(ref T? value, IEnumerable<char> shortNames, Option<T> optionT, IEnumerable<string> unmatchedTokens)
    {
        // If the option was not found, but one of its short names is part of a bundle of short names,
        // try adding the other short names as options and see if the option value can be parsed.
        // Capture the original args (for use in lambda)
        var originalArgs = _args;

        // Unmatched bundles are unmatched tokens that start with a hyphen and contain more than one character
        var unmatchedBundles = unmatchedTokens.Where(t => BundlePattern().IsMatch(t)).Select(t => t[1..]);

        // Partially matched bundles are unmatched tokens that do not start with a hyphen and do not match any of the original arguments
        // These have already been unbundled with some short names matched and removed already (along with the hyphen)
        var partiallyMatchedBundles = unmatchedTokens.Where(t => !BundlePattern().IsMatch(t) && !originalArgs.Contains(t));

        foreach (var bundle in unmatchedBundles.Concat(partiallyMatchedBundles))
        {
            var index = bundle.IndexOfAny(shortNames.ToArray());

            if (index >= 0)
            {
                var otherFlags = bundle[..index] + bundle[(index + 1)..];
                List<Option> stubOptions = [];

                // Add stub options for each short name not already defined as an option
                foreach (var flag in otherFlags.Except(_shortNamesUsed))
                {
                    stubOptions.Add(BuildOption<T>(flag.ToString(), [], [flag]));
                }

                var (stubRootCommand, stubConfig) = BuildParser(stubOptions);
                return TryGetResultValue<T>(stubRootCommand, stubConfig, optionT, out value, out _);
            }
        }

        return false;
    }

    private T? GetNullableReferenceArgumentValue<T>() where T : class => TryGetArgumentValue<T>(out var value) ? value : null;
    private T? GetNullableStructArgumentValue<T>() where T : struct => TryGetArgumentValue<T>(out var value) ? value : null;

    private bool TryGetArgumentValue<T>(out T? value)
    {
        var argument = BuildArgument<T>();
        _arguments.Add(argument);

        var (rootCommand, config) = BuildParser();
        return TryGetResultValue(rootCommand, config, argument, out value, out _);
    }

    [SuppressMessage("Style", "IDE0251:Make member 'readonly'", Justification = "Reserving the opportunity to have a stateful root command or parser")]
    private bool TryGetResultValue<T>(RootCommand rootCommand, ParserConfiguration config, Symbol symbol, out T? value, out IEnumerable<string> unmatchedTokens)
    {
        var result = CommandLineParser.Parse(rootCommand, _args, config);
        var symbolResult = result.GetResult(symbol);

        (value, bool success) = (symbol, symbolResult) switch
        {
            // If symbolResult is null (not in args at all), return default with success=false
            (_, null) => (default, false),
            // For arguments, check if it was implicit (default/not provided) - return default with success=false
            (Argument<T>, ArgumentResult argumentResult) when argumentResult.Implicit => (default, false),
            // For options, check if it was implicit (default/not provided) - return default with success=false
            (Option<T>, OptionResult optionResult) when optionResult.Implicit => (default, false),
            // If the result has errors:
            // - For "Required argument missing" errors, return default (don't throw)
            // - For other errors (e.g., invalid value), call GetValueOrDefault to throw
            (Argument<T>, ArgumentResult argumentResult) when argumentResult.Errors.Any(e => e.Message.Contains("Required argument missing")) => (default, false),
            (Argument<T>, ArgumentResult argumentResult) when argumentResult.Errors.Any() => (argumentResult.GetValueOrDefault<T>(), true),
            (Option<T>, OptionResult optionResult) when optionResult.Errors.Any() => (optionResult.GetValueOrDefault<T>(), true),
            // Otherwise, get the value
            (Argument<T>, ArgumentResult argumentResult) => (argumentResult.GetValueOrDefault<T>(), true),
            (Option<T>, OptionResult optionResult) => (optionResult.GetValueOrDefault<T>(), true),
            _ => (default, false),
        };

        unmatchedTokens = result.UnmatchedTokens;
        return success;
    }

    private readonly Option<T> BuildOption<T>(string name, IEnumerable<string> aliases, IEnumerable<char> shortNames)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentNullException.ThrowIfNull(aliases);
        ArgumentNullException.ThrowIfNull(shortNames);

        string optionName = $"--{name}";
        string[] optionAliases = [
            .. aliases.Select(a => $"--{a}"),
            .. shortNames.Select(a => $"-{a}")
            ];

        return new(optionName, optionAliases);
    }

    private readonly Argument<T> BuildArgument<T>()
    {
        string argName = typeof(T).Name.ToLower();
        ushort argCount = _argCounter.TryGetValue(argName, out var count) ? (ushort)(count + 1) : (ushort)1;
        _argCounter[typeof(T).Name] = argCount;

        if (argCount > 1)
        {
            argName = $"{argName}_{argCount}";
        }

        return new(argName);
    }

    [SuppressMessage("Style", "IDE0251:Make member 'readonly'", Justification = "Reserving the opportunity to have a stateful root command or parser")]
    private (RootCommand, ParserConfiguration) BuildParser(IEnumerable<Option>? stubOptions = null)
    {
        RootCommand rootCommand = new();

        foreach (var option in _options.Values.Concat(stubOptions ?? []))
        {
            rootCommand.Options.Add(option);
        }

        foreach (var argument in _arguments)
        {
            rootCommand.Arguments.Add(argument);
        }

        var config = new ParserConfiguration
        {
            EnablePosixBundling = true
        };

        return (rootCommand, config);
    }

    [GeneratedRegex(@"^-\w+$")]
    private static partial Regex BundlePattern();
}
