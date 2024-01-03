using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace UtilityCli;

public partial struct CliParseResult
{
    private readonly IReadOnlyList<string> _args;
    private readonly RootCommand _rootCommand = new() { TreatUnmatchedTokensAsErrors = false };
    private readonly Dictionary<string, Command> _commands = [];
    private readonly Dictionary<string, Option> _options = [];
    private readonly List<char> _shortNamesUsed = [];
    private readonly Dictionary<string, ushort> _argCounter = [];

    private System.CommandLine.Parsing.Parser _parser = new();

    public CliParseResult() => throw new ArgumentNullException("args");

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

        if (_options.TryGetValue(name, out var option))
        {
            if (option is not Option<T> optionT)
            {
                throw new InvalidCastException($"Option '{name}' is not defined as type '{typeof(T).Name}'.");
            }

            return TryGetResultValue<T>(out value, optionT);
        }

        AddOption<T>(name, aliases, shortNames);
        return TryGetOptionValue<T>(out value, name, aliases, shortNames);
    }

    private T? GetNullableReferenceArgumentValue<T>() where T : class => TryGetArgumentValue<T>(out var value) ? value : null;
    private T? GetNullableStructArgumentValue<T>() where T : struct => TryGetArgumentValue<T>(out var value) ? value : null;

    private bool TryGetArgumentValue<T>(out T? value) => TryGetResultValue(out value, AddArgument<T>());

    private readonly bool TryGetResultValue<T>(out T? value, Symbol symbol)
    {
        var result = _parser.Parse(_args);
        var symbolResult = result.FindResultFor(symbol);

        (value, bool success) = (symbol, symbolResult) switch
        {
            (Argument<T>, ArgumentResult argumentResult) => (argumentResult.GetValueOrDefault<T>(), true),
            (Option<T>, OptionResult optionResult) => (optionResult.GetValueOrDefault<T>(), true),
            _ => (default, false),
        };

        return success;
    }

    private void AddOption<T>(string name, IEnumerable<string>? aliases, IEnumerable<char>? shortNames)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        shortNames ??= _shortNamesUsed.Contains(name[0]) ?[] : [name[0]];
        _shortNamesUsed.AddRange(shortNames);

        string[] allAliases = [
            $"--{name}",
            .. aliases?.Select(a => $"--{a}") ?? [],
            .. shortNames.Select(a => $"-{a}")
            ];

        Option<T> option = new(allAliases);

        _options.Add(name, option);
        _rootCommand.AddOption(option);
        _parser = new(new CommandLineConfiguration(_rootCommand, enablePosixBundling: false));
    }

    private Argument<T> AddArgument<T>()
    {
        string argName = typeof(T).Name.ToLower();
        ushort argCount = _argCounter.TryGetValue(argName, out var count) ? (ushort)(count + 1) : (ushort)1;
        _argCounter[typeof(T).Name] = argCount;

        if (argCount > 1)
        {
            argName = $"{argName}_{argCount}";
        }

        var argument = new Argument<T>(argName);
        _rootCommand.AddArgument(argument);

        foreach (var command in _rootCommand.Children.OfType<Command>())
        {
            command.AddArgument(argument);
        }

        _parser = new(_rootCommand);

        return argument;
    }
}
