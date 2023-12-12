using System.CommandLine;

namespace UtilityCliParser;

public struct CliParseResult
{
    private readonly IReadOnlyList<string> _args;
    private readonly RootCommand _rootCommand = new() { TreatUnmatchedTokensAsErrors = false };
    private readonly Dictionary<string, Command> _commands = [];
    private readonly Dictionary<string, Option> _options = [];

    private System.CommandLine.Parsing.Parser _parser = new();
    private ushort _argCount = 0;

    public CliParseResult() => throw new ArgumentNullException("args");

    public CliParseResult(IEnumerable<string> args)
    {
        _args = args.ToList();
    }

    //public bool GetBoolean() => GetArgumentValues<bool>(1).SingleOrDefault();
    public bool GetBoolean(string name) => GetStructOptionValue<bool>(name);
    public bool GetBoolean(string name, char shortName) => GetStructOptionValue<bool>(name, shortNames: [shortName]);
    public bool GetBoolean(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetStructOptionValue<bool>(name, aliases, shortNames);

    //public byte? GetByte() => GetArgumentValues<byte>(1).SingleOrDefault();
    public byte? GetByte(string name) => GetNullableStructOptionValue<byte>(name);
    public byte? GetByte(string name, char shortName) => GetNullableStructOptionValue<byte>(name, shortNames: [shortName]);
    public byte? GetByte(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<byte>(name, aliases, shortNames);

    //public short? GetInt16() => GetArgumentValues<short>(1).SingleOrDefault();
    public short? GetInt16(string name) => GetNullableStructOptionValue<short>(name);
    public short? GetInt16(string name, char shortName) => GetNullableStructOptionValue<short>(name, shortNames: [shortName]);
    public short? GetInt16(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<short>(name, aliases, shortNames);

    //public int? GetInt32() => GetArgumentValues<int>(1).SingleOrDefault();
    public int? GetInt32(string name) => GetNullableStructOptionValue<int>(name);
    public int? GetInt32(string name, char shortName) => GetNullableStructOptionValue<int>(name, shortNames: [shortName]);
    public int? GetInt32(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<int>(name, aliases, shortNames);

    //public long? GetInt64() => GetArgumentValues<long>(1).SingleOrDefault();
    public long? GetInt64(string name) => GetNullableStructOptionValue<long>(name);
    public long? GetInt64(string name, char shortName) => GetNullableStructOptionValue<long>(name, shortNames: [shortName]);
    public long? GetInt64(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<long>(name, aliases, shortNames);

    //public float? GetSingle() => GetArgumentValues<float>(1).SingleOrDefault();
    public float? GetSingle(string name) => GetNullableStructOptionValue<float>(name);
    public float? GetSingle(string name, char shortName) => GetNullableStructOptionValue<float>(name, shortNames: [shortName]);
    public float? GetSingle(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<float>(name, aliases, shortNames);

    //public double? GetDouble() => GetArgumentValues<double>(1).SingleOrDefault();
    public double? GetDouble(string name) => GetNullableStructOptionValue<double>(name);
    public double? GetDouble(string name, char shortName) => GetNullableStructOptionValue<double>(name, shortNames: [shortName]);
    public double? GetDouble(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<double>(name, aliases, shortNames);

    //public decimal? GetDecimal() => GetArgumentValues<decimal>(1).SingleOrDefault();
    public decimal? GetDecimal(string name) => GetNullableStructOptionValue<decimal>(name);
    public decimal? GetDecimal(string name, char shortName) => GetNullableStructOptionValue<decimal>(name, shortNames: [shortName]);
    public decimal? GetDecimal(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<decimal>(name, aliases, shortNames);

    //public string? GetString() => GetArgumentValues<string>(1).SingleOrDefault();
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

    //public char? GetChar() => ConvertStringToChar(GetArgumentValues<string>(1).SingleOrDefault());
    public char? GetChar(string name) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name));
    public char? GetChar(string name, char shortName) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name, shortNames: [shortName]));
    public char? GetChar(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name, aliases, shortNames));

    //public DateTime? GetDateTime() => GetArgumentValues<DateTime>(1).SingleOrDefault();
    public DateTime? GetDateTime(string name) => GetNullableStructOptionValue<DateTime>(name);
    public DateTime? GetDateTime(string name, char shortName) => GetNullableStructOptionValue<DateTime>(name, shortNames: [shortName]);
    public DateTime? GetDateTime(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<DateTime>(name, aliases, shortNames);

    //public DateTimeOffset? GetDateTimeOffset() => GetArgumentValues<DateTimeOffset>(1).SingleOrDefault();
    public DateTimeOffset? GetDateTimeOffset(string name) => GetNullableStructOptionValue<DateTimeOffset>(name);
    public DateTimeOffset? GetDateTimeOffset(string name, char shortName) => GetNullableStructOptionValue<DateTimeOffset>(name, shortNames: [shortName]);
    public DateTimeOffset? GetDateTimeOffset(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<DateTimeOffset>(name, aliases, shortNames);

    //public Guid? GetGuid() => GetArgumentValues<Guid>(1).SingleOrDefault();
    public Guid? GetGuid(string name) => GetNullableStructOptionValue<Guid>(name);
    public Guid? GetGuid(string name, char shortName) => GetNullableStructOptionValue<Guid>(name, shortNames: [shortName]);
    public Guid? GetGuid(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<Guid>(name, aliases, shortNames);

    //public sbyte? GetSByte() => GetArgumentValues<sbyte>(1).SingleOrDefault();
    public sbyte? GetSByte(string name) => GetNullableStructOptionValue<sbyte>(name);
    public sbyte? GetSByte(string name, char shortName) => GetNullableStructOptionValue<sbyte>(name, shortNames: [shortName]);
    public sbyte? GetSByte(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<sbyte>(name, aliases, shortNames);

    //public ushort? GetUInt16() => GetArgumentValues<ushort>(1).SingleOrDefault();
    public ushort? GetUInt16(string name) => GetNullableStructOptionValue<ushort>(name);
    public ushort? GetUInt16(string name, char shortName) => GetNullableStructOptionValue<ushort>(name, shortNames: [shortName]);
    public ushort? GetUInt16(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<ushort>(name, aliases, shortNames);

    //public uint? GetUInt32() => GetArgumentValues<uint>(1).SingleOrDefault();
    public uint? GetUInt32(string name) => GetNullableStructOptionValue<uint>(name);
    public uint? GetUInt32(string name, char shortName) => GetNullableStructOptionValue<uint>(name, shortNames: [shortName]);
    public uint? GetUInt32(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<uint>(name, aliases, shortNames);

    //public ulong? GetUInt64() => GetArgumentValues<ulong>(1).SingleOrDefault();
    public ulong? GetUInt64(string name) => GetNullableStructOptionValue<ulong>(name);
    public ulong? GetUInt64(string name, char shortName) => GetNullableStructOptionValue<ulong>(name, shortNames: [shortName]);
    public ulong? GetUInt64(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<ulong>(name, aliases, shortNames);


    //public bool[] GetBooleans(ushort maxValues = ushort.MaxValue) => GetArgumentValues<bool>(maxValues).ToArray();
    //public bool[] GetBooleans(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<bool[]>(name, maxValues: maxValues);
    //public bool[] GetBooleans(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<bool[]>(name, shortNames: [shortName]);
    //public bool[] GetBooleans(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<bool[]>(name, aliases, shortNames, maxValues);

    //public byte[] GetBytes(ushort maxValues = ushort.MaxValue) => GetArgumentValues<byte>(maxValues).ToArray();
    //public byte[] GetBytes(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<byte[]>(name, maxValues: maxValues);
    //public byte[] GetBytes(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<byte[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public byte[] GetBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<byte[]>(name, aliases, shortNames, maxValues);

    //public short[] GetInt16s(ushort maxValues = ushort.MaxValue) => GetArgumentValues<short>(maxValues).ToArray();
    //public short[] GetInt16s(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<short[]>(name, maxValues: maxValues);
    //public short[] GetInt16s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<short[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public short[] GetInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<short[]>(name, aliases, shortNames, maxValues);

    //public int[] GetInt32s(ushort maxValues = ushort.MaxValue) => GetArgumentValues<int>(maxValues).ToArray();
    //public int[] GetInt32s(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<int[]>(name, maxValues: maxValues);
    //public int[] GetInt32s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<int[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public int[] GetInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<int[]>(name, aliases, shortNames, maxValues);

    //public long[] GetInt64s(ushort maxValues = ushort.MaxValue) => GetArgumentValues<long>(maxValues).ToArray();
    //public long[] GetInt64s(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<long[]>(name, maxValues: maxValues);
    //public long[] GetInt64s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<long[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public long[] GetInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<long[]>(name, aliases, shortNames, maxValues);

    //public float[] GetSingles(ushort maxValues = ushort.MaxValue) => GetArgumentValues<float>(maxValues).ToArray();
    //public float[] GetSingles(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<float[]>(name, maxValues: maxValues);
    //public float[] GetSingles(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<float[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public float[] GetSingles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<float[]>(name, aliases, shortNames, maxValues);

    //public double[] GetDoubles(ushort maxValues = ushort.MaxValue) => GetArgumentValues<double>(maxValues).ToArray();
    //public double[] GetDoubles(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<double[]>(name, maxValues: maxValues);
    //public double[] GetDoubles(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<double[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public double[] GetDoubles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<double[]>(name, aliases, shortNames, maxValues);

    //public decimal[] GetDecimals(ushort maxValues = ushort.MaxValue) => GetArgumentValues<decimal>(maxValues).ToArray();
    //public decimal[] GetDecimals(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<decimal[]>(name, maxValues: maxValues);
    //public decimal[] GetDecimals(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<decimal[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public decimal[] GetDecimals(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<decimal[]>(name, aliases, shortNames, maxValues);

    //public string[] GetStrings(ushort maxValues = ushort.MaxValue) => GetArgumentValues<string>(maxValues).ToArray();
    //public string[] GetStrings(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<string[]>(name, maxValues: maxValues);
    //public string[] GetStrings(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<string[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public string[] GetStrings(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<string[]>(name, aliases, shortNames, maxValues);

    //public char[] GetChars(ushort maxValues = ushort.MaxValue) => GetArgumentValues<char>(maxValues).ToArray();
    //public char[] GetChars(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<char[]>(name, maxValues: maxValues);
    //public char[] GetChars(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<char[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public char[] GetChars(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<char[]>(name, aliases, shortNames, maxValues);

    //public DateTime[] GetDateTimes(ushort maxValues = ushort.MaxValue) => GetArgumentValues<DateTime>(maxValues).ToArray();
    //public DateTime[] GetDateTimes(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<DateTime[]>(name, maxValues: maxValues);
    //public DateTime[] GetDateTimes(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<DateTime[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public DateTime[] GetDateTimes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<DateTime[]>(name, aliases, shortNames, maxValues);

    //public DateTimeOffset[] GetDateTimeOffsets(ushort maxValues = ushort.MaxValue) => GetArgumentValues<DateTimeOffset>(maxValues).ToArray();
    //public DateTimeOffset[] GetDateTimeOffsets(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<DateTimeOffset[]>(name, maxValues: maxValues);
    //public DateTimeOffset[] GetDateTimeOffsets(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<DateTimeOffset[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public DateTimeOffset[] GetDateTimeOffsets(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<DateTimeOffset[]>(name, aliases, shortNames, maxValues);

    //public Guid[] GetGuids(ushort maxValues = ushort.MaxValue) => GetArgumentValues<Guid>(maxValues).ToArray();
    //public Guid[] GetGuids(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<Guid[]>(name, maxValues: maxValues);
    //public Guid[] GetGuids(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<Guid[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public Guid[] GetGuids(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<Guid[]>(name, aliases, shortNames, maxValues);

    //public sbyte[] GetSBytes(ushort maxValues = ushort.MaxValue) => GetArgumentValues<sbyte>(maxValues).ToArray();
    //public sbyte[] GetSBytes(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<sbyte[]>(name, maxValues: maxValues);
    //public sbyte[] GetSBytes(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<sbyte[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public sbyte[] GetSBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<sbyte[]>(name, aliases, shortNames, maxValues);

    //public ushort[] GetUInt16s(ushort maxValues = ushort.MaxValue) => GetArgumentValues<ushort>(maxValues).ToArray();
    //public ushort[] GetUInt16s(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<ushort[]>(name, maxValues: maxValues);
    //public ushort[] GetUInt16s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<ushort[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public ushort[] GetUInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<ushort[]>(name, aliases, shortNames, maxValues);

    //public uint[] GetUInt32s(ushort maxValues = ushort.MaxValue) => GetArgumentValues<uint>(maxValues).ToArray();
    //public uint[] GetUInt32s(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<uint[]>(name, maxValues: maxValues);
    //public uint[] GetUInt32s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<uint[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public uint[] GetUInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<uint[]>(name, aliases, shortNames, maxValues);

    //public ulong[] GetUInt64s(ushort maxValues = ushort.MaxValue) => GetArgumentValues<ulong>(maxValues).ToArray();
    //public ulong[] GetUInt64s(string name, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<ulong[]>(name, maxValues: maxValues);
    //public ulong[] GetUInt64s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<ulong[]>(name, shortNames: [shortName], maxValues: maxValues);
    //public ulong[] GetUInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetNullableStructOptionValue<ulong[]>(name, aliases, shortNames, maxValues);

    private T GetStructOptionValue<T>(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = 1) where T : struct
    {
        if (_options.TryGetValue(name, out var option))
        {
            if (option is not Option<T> optionT)
            {
                throw new InvalidCastException($"Option '{name}' is not defined as type '{typeof(T).Name}'.");
            }

            var result = _parser.Parse(_args);
            var optionValue = result.GetValueForOption<T>(optionT);

            return optionValue;
        }

        AddOption<T>(name, aliases, shortNames, maxValues);
        return GetStructOptionValue<T>(name, aliases, shortNames);
    }

    private T? GetNullableStructOptionValue<T>(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = 1) where T : struct
    {
        if (_options.TryGetValue(name, out var option))
        {
            if (option is not Option<T?> optionT)
            {
                throw new InvalidCastException($"Option '{name}' is not defined as type '{typeof(T).Name}'.");
            }

            var result = _parser.Parse(_args);
            var optionValue = result.GetValueForOption<T?>(optionT);

            return optionValue;
        }

        AddOption<T?>(name, aliases, shortNames, maxValues);
        return GetNullableStructOptionValue<T>(name, aliases, shortNames);
    }

    private T? GetNullableReferenceOptionValue<T>(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = 1) where T : class
    {
        if (_options.TryGetValue(name, out var option))
        {
            if (option is not Option<T?> optionT)
            {
                throw new InvalidCastException($"Option '{name}' is not defined as type '{typeof(T).Name}'.");
            }

            var result = _parser.Parse(_args);
            var optionValue = result.GetValueForOption<T?>(optionT);

            return optionValue;
        }

        AddOption<T?>(name, aliases, shortNames, maxValues);
        return GetNullableReferenceOptionValue<T>(name, aliases, shortNames);
    }

    //private IEnumerable<T> GetArgumentValues<T>(ushort maxValues)
    //{
    //    var result = _parser.Parse(_args);
    //    var argsExcludingSubsequentOptions = result.Tokens.TakeWhile(t => !t.Value.StartsWith('-'));

    //    var argument = new Argument<IEnumerable<T>>($"arg{_argCount++}")
    //    {
    //        Arity = new ArgumentArity(0, maxValues)
    //    };

    //    _rootCommand.AddArgument(argument);

    //    foreach (var command in _rootCommand.Children.OfType<Command>())
    //    {
    //        command.AddArgument(argument);
    //    }

    //    _parser = new(_rootCommand);

    //    result = _parser.Parse(_args);

    //    return result.GetValueForArgument<IEnumerable<T>>(argument) ?? Enumerable.Empty<T>();
    //}

    private void AddOption<T>(string name, IEnumerable<string>? aliases, IEnumerable<char>? shortNames, ushort maxValues)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        string[] allAliases = [
            $"--{name}",
            .. aliases?.Select(a => $"--{a}") ?? [],
            .. (shortNames ?? [name[0]]).Select(a => $"-{a}")
            ];

        Option<T> option = new(allAliases);
        option.Arity = maxValues > 1 ? option.Arity = new(1, maxValues) : ArgumentArity.ZeroOrOne;

        _options.Add(name, option);
        _rootCommand.AddOption(option);
        _parser = new(new CommandLineConfiguration(_rootCommand, enablePosixBundling: false));
    }
}
