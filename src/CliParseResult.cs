using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace UtilityCli;

public struct CliParseResult
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

    public bool? GetBoolean() => GetNullableStructArgumentValue<bool>();
    public bool? GetBoolean(string name) => GetBooleanOption(name);
    public bool? GetBoolean(string name, char shortName) => GetBooleanOption(name, shortNames: [shortName]);
    public bool? GetBoolean(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetBooleanOption(name, aliases, shortNames);

    public byte? GetByte() => GetNullableStructArgumentValue<byte>();
    public byte? GetByte(string name) => GetNullableStructOptionValue<byte>(name);
    public byte? GetByte(string name, char shortName) => GetNullableStructOptionValue<byte>(name, shortNames: [shortName]);
    public byte? GetByte(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<byte>(name, aliases, shortNames);

    public short? GetInt16() => GetNullableStructArgumentValue<short>();
    public short? GetInt16(string name) => GetNullableStructOptionValue<short>(name);
    public short? GetInt16(string name, char shortName) => GetNullableStructOptionValue<short>(name, shortNames: [shortName]);
    public short? GetInt16(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<short>(name, aliases, shortNames);

    public int? GetInt32() => GetNullableStructArgumentValue<int>();
    public int? GetInt32(string name) => GetNullableStructOptionValue<int>(name);
    public int? GetInt32(string name, char shortName) => GetNullableStructOptionValue<int>(name, shortNames: [shortName]);
    public int? GetInt32(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<int>(name, aliases, shortNames);

    public long? GetInt64() => GetNullableStructArgumentValue<long>();
    public long? GetInt64(string name) => GetNullableStructOptionValue<long>(name);
    public long? GetInt64(string name, char shortName) => GetNullableStructOptionValue<long>(name, shortNames: [shortName]);
    public long? GetInt64(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<long>(name, aliases, shortNames);

    public float? GetSingle() => GetNullableStructArgumentValue<float>();
    public float? GetSingle(string name) => GetNullableStructOptionValue<float>(name);
    public float? GetSingle(string name, char shortName) => GetNullableStructOptionValue<float>(name, shortNames: [shortName]);
    public float? GetSingle(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<float>(name, aliases, shortNames);

    public double? GetDouble() => GetNullableStructArgumentValue<double>();
    public double? GetDouble(string name) => GetNullableStructOptionValue<double>(name);
    public double? GetDouble(string name, char shortName) => GetNullableStructOptionValue<double>(name, shortNames: [shortName]);
    public double? GetDouble(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<double>(name, aliases, shortNames);

    public decimal? GetDecimal() => GetNullableStructArgumentValue<decimal>();
    public decimal? GetDecimal(string name) => GetNullableStructOptionValue<decimal>(name);
    public decimal? GetDecimal(string name, char shortName) => GetNullableStructOptionValue<decimal>(name, shortNames: [shortName]);
    public decimal? GetDecimal(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<decimal>(name, aliases, shortNames);

    public string? GetString() => GetNullableReferenceArgumentValue<string>();
    public string? GetString(string name) => GetNullableReferenceOptionValue<string>(name);
    public string? GetString(string name, char shortName) => GetNullableReferenceOptionValue<string>(name, shortNames: [shortName]);
    public string? GetString(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<string>(name, aliases, shortNames);

    // Cannot parse char values from command line arguments -- treat them as single-character strings
    private static char? ConvertStringToChar(string? value) => value switch
    {
        null or [] => null,
        [char c] => c,
        _ => throw new InvalidOperationException($"Cannot parse argument '{value}' as expected type 'System.Char'."),
    };

    public char? GetChar() => ConvertStringToChar(GetNullableReferenceArgumentValue<string>());
    public char? GetChar(string name) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name));
    public char? GetChar(string name, char shortName) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name, shortNames: [shortName]));
    public char? GetChar(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name, aliases, shortNames));

    public DateTime? GetDateTime() => GetNullableStructArgumentValue<DateTime>();
    public DateTime? GetDateTime(string name) => GetNullableStructOptionValue<DateTime>(name);
    public DateTime? GetDateTime(string name, char shortName) => GetNullableStructOptionValue<DateTime>(name, shortNames: [shortName]);
    public DateTime? GetDateTime(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<DateTime>(name, aliases, shortNames);

    public DateTimeOffset? GetDateTimeOffset() => GetNullableStructArgumentValue<DateTimeOffset>();
    public DateTimeOffset? GetDateTimeOffset(string name) => GetNullableStructOptionValue<DateTimeOffset>(name);
    public DateTimeOffset? GetDateTimeOffset(string name, char shortName) => GetNullableStructOptionValue<DateTimeOffset>(name, shortNames: [shortName]);
    public DateTimeOffset? GetDateTimeOffset(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<DateTimeOffset>(name, aliases, shortNames);

    public Guid? GetGuid() => GetNullableStructArgumentValue<Guid>();
    public Guid? GetGuid(string name) => GetNullableStructOptionValue<Guid>(name);
    public Guid? GetGuid(string name, char shortName) => GetNullableStructOptionValue<Guid>(name, shortNames: [shortName]);
    public Guid? GetGuid(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<Guid>(name, aliases, shortNames);

    public sbyte? GetSByte() => GetNullableStructArgumentValue<sbyte>();
    public sbyte? GetSByte(string name) => GetNullableStructOptionValue<sbyte>(name);
    public sbyte? GetSByte(string name, char shortName) => GetNullableStructOptionValue<sbyte>(name, shortNames: [shortName]);
    public sbyte? GetSByte(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<sbyte>(name, aliases, shortNames);

    public ushort? GetUInt16() => GetNullableStructArgumentValue<ushort>();
    public ushort? GetUInt16(string name) => GetNullableStructOptionValue<ushort>(name);
    public ushort? GetUInt16(string name, char shortName) => GetNullableStructOptionValue<ushort>(name, shortNames: [shortName]);
    public ushort? GetUInt16(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<ushort>(name, aliases, shortNames);

    public uint? GetUInt32() => GetNullableStructArgumentValue<uint>();
    public uint? GetUInt32(string name) => GetNullableStructOptionValue<uint>(name);
    public uint? GetUInt32(string name, char shortName) => GetNullableStructOptionValue<uint>(name, shortNames: [shortName]);
    public uint? GetUInt32(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<uint>(name, aliases, shortNames);

    public ulong? GetUInt64() => GetNullableStructArgumentValue<ulong>();
    public ulong? GetUInt64(string name) => GetNullableStructOptionValue<ulong>(name);
    public ulong? GetUInt64(string name, char shortName) => GetNullableStructOptionValue<ulong>(name, shortNames: [shortName]);
    public ulong? GetUInt64(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<ulong>(name, aliases, shortNames);


    //public bool[] GetBooleans(ushort maxValues) => GetArgumentValues<bool>(maxValues).ToArray();
    //public bool[] GetBooleans(string name) => GetNullableStructOptionValue<bool[]>(name);
    //public bool[] GetBooleans(string name, char shortName) => GetNullableStructOptionValue<bool[]>(name, shortNames: [shortName]);
    //public bool[] GetBooleans(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<bool[]>(name, aliases, shortNames);

    //public byte[] GetBytes(ushort maxValues) => GetArgumentValues<byte>(maxValues).ToArray();
    public byte[]? GetBytes(string name) => GetNullableReferenceOptionValue<byte[]>(name);
    public byte[]? GetBytes(string name, char shortName) => GetNullableReferenceOptionValue<byte[]>(name, shortNames: [shortName]);
    public byte[]? GetBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<byte[]>(name, aliases, shortNames);

    //public short[] GetInt16s(ushort maxValues) => GetArgumentValues<short>(maxValues).ToArray();
    //public short[] GetInt16s(string name) => GetNullableStructOptionValue<short[]>(name);
    //public short[] GetInt16s(string name, char shortName) => GetNullableStructOptionValue<short[]>(name, shortNames: [shortName]);
    //public short[] GetInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<short[]>(name, aliases, shortNames);

    //public int[] GetInt32s(ushort maxValues) => GetArgumentValues<int>(maxValues).ToArray();
    //public int[] GetInt32s(string name) => GetNullableStructOptionValue<int[]>(name);
    //public int[] GetInt32s(string name, char shortName) => GetNullableStructOptionValue<int[]>(name, shortNames: [shortName]);
    //public int[] GetInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<int[]>(name, aliases, shortNames);

    //public long[] GetInt64s(ushort maxValues) => GetArgumentValues<long>(maxValues).ToArray();
    //public long[] GetInt64s(string name) => GetNullableStructOptionValue<long[]>(name);
    //public long[] GetInt64s(string name, char shortName) => GetNullableStructOptionValue<long[]>(name, shortNames: [shortName]);
    //public long[] GetInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<long[]>(name, aliases, shortNames);

    //public float[] GetSingles(ushort maxValues) => GetArgumentValues<float>(maxValues).ToArray();
    //public float[] GetSingles(string name) => GetNullableStructOptionValue<float[]>(name);
    //public float[] GetSingles(string name, char shortName) => GetNullableStructOptionValue<float[]>(name, shortNames: [shortName]);
    //public float[] GetSingles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<float[]>(name, aliases, shortNames);

    //public double[] GetDoubles(ushort maxValues) => GetArgumentValues<double>(maxValues).ToArray();
    //public double[] GetDoubles(string name) => GetNullableStructOptionValue<double[]>(name);
    //public double[] GetDoubles(string name, char shortName) => GetNullableStructOptionValue<double[]>(name, shortNames: [shortName]);
    //public double[] GetDoubles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<double[]>(name, aliases, shortNames);

    //public decimal[] GetDecimals(ushort maxValues) => GetArgumentValues<decimal>(maxValues).ToArray();
    //public decimal[] GetDecimals(string name) => GetNullableStructOptionValue<decimal[]>(name);
    //public decimal[] GetDecimals(string name, char shortName) => GetNullableStructOptionValue<decimal[]>(name, shortNames: [shortName]);
    //public decimal[] GetDecimals(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<decimal[]>(name, aliases, shortNames);

    //public string[] GetStrings(ushort maxValues) => GetArgumentValues<string>(maxValues).ToArray();
    //public string[] GetStrings(string name) => GetNullableStructOptionValue<string[]>(name);
    //public string[] GetStrings(string name, char shortName) => GetNullableStructOptionValue<string[]>(name, shortNames: [shortName]);
    //public string[] GetStrings(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<string[]>(name, aliases, shortNames);

    //public char[] GetChars(ushort maxValues) => GetArgumentValues<char>(maxValues).ToArray();
    //public char[] GetChars(string name) => GetNullableStructOptionValue<char[]>(name);
    //public char[] GetChars(string name, char shortName) => GetNullableStructOptionValue<char[]>(name, shortNames: [shortName]);
    //public char[] GetChars(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<char[]>(name, aliases, shortNames);

    //public DateTime[] GetDateTimes(ushort maxValues) => GetArgumentValues<DateTime>(maxValues).ToArray();
    //public DateTime[] GetDateTimes(string name) => GetNullableStructOptionValue<DateTime[]>(name);
    //public DateTime[] GetDateTimes(string name, char shortName) => GetNullableStructOptionValue<DateTime[]>(name, shortNames: [shortName]);
    //public DateTime[] GetDateTimes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<DateTime[]>(name, aliases, shortNames);

    //public DateTimeOffset[] GetDateTimeOffsets(ushort maxValues) => GetArgumentValues<DateTimeOffset>(maxValues).ToArray();
    //public DateTimeOffset[] GetDateTimeOffsets(string name) => GetNullableStructOptionValue<DateTimeOffset[]>(name);
    //public DateTimeOffset[] GetDateTimeOffsets(string name, char shortName) => GetNullableStructOptionValue<DateTimeOffset[]>(name, shortNames: [shortName]);
    //public DateTimeOffset[] GetDateTimeOffsets(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<DateTimeOffset[]>(name, aliases, shortNames);

    //public Guid[] GetGuids(ushort maxValues) => GetArgumentValues<Guid>(maxValues).ToArray();
    //public Guid[] GetGuids(string name) => GetNullableStructOptionValue<Guid[]>(name);
    //public Guid[] GetGuids(string name, char shortName) => GetNullableStructOptionValue<Guid[]>(name, shortNames: [shortName]);
    //public Guid[] GetGuids(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<Guid[]>(name, aliases, shortNames);

    //public sbyte[] GetSBytes(ushort maxValues) => GetArgumentValues<sbyte>(maxValues).ToArray();
    //public sbyte[] GetSBytes(string name) => GetNullableStructOptionValue<sbyte[]>(name);
    //public sbyte[] GetSBytes(string name, char shortName) => GetNullableStructOptionValue<sbyte[]>(name, shortNames: [shortName]);
    //public sbyte[] GetSBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<sbyte[]>(name, aliases, shortNames);

    //public ushort[] GetUInt16s(ushort maxValues) => GetArgumentValues<ushort>(maxValues).ToArray();
    //public ushort[] GetUInt16s(string name) => GetNullableStructOptionValue<ushort[]>(name);
    //public ushort[] GetUInt16s(string name, char shortName) => GetNullableStructOptionValue<ushort[]>(name, shortNames: [shortName]);
    //public ushort[] GetUInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<ushort[]>(name, aliases, shortNames);

    //public uint[] GetUInt32s(ushort maxValues) => GetArgumentValues<uint>(maxValues).ToArray();
    //public uint[] GetUInt32s(string name) => GetNullableStructOptionValue<uint[]>(name);
    //public uint[] GetUInt32s(string name, char shortName) => GetNullableStructOptionValue<uint[]>(name, shortNames: [shortName]);
    //public uint[] GetUInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<uint[]>(name, aliases, shortNames);

    //public ulong[] GetUInt64s(ushort maxValues) => GetArgumentValues<ulong>(maxValues).ToArray();
    //public ulong[] GetUInt64s(string name) => GetNullableStructOptionValue<ulong[]>(name);
    //public ulong[] GetUInt64s(string name, char shortName) => GetNullableStructOptionValue<ulong[]>(name, shortNames: [shortName]);
    //public ulong[] GetUInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<ulong[]>(name, aliases, shortNames);

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

        var argument = new Argument<T>(argName) { Arity = ArgumentArity.ZeroOrOne };
        _rootCommand.AddArgument(argument);

        foreach (var command in _rootCommand.Children.OfType<Command>())
        {
            command.AddArgument(argument);
        }

        _parser = new(_rootCommand);

        return argument;
    }
}
