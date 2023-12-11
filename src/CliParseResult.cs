using System.CommandLine;

namespace UtilityCliParser;

public struct CliParseResult
{
    private IReadOnlyList<string> _args;
    private RootCommand _rootCommand;
    private Dictionary<string, Command> _commands = new();
    private Dictionary<string, Option> _options = new();
    private System.CommandLine.Parsing.Parser _parser = new();
    private ushort _argCount = 0;

    public CliParseResult() => throw new ArgumentNullException("args");
    public CliParseResult(IEnumerable<string> args)
    {
        _args = args.ToList();

        _rootCommand = new RootCommand { TreatUnmatchedTokensAsErrors = false };
    }

    public bool GetBoolean() => GetArgumentValues<bool>(1, 1).Single();
    public bool GetBoolean(string name) => GetOptionValue<bool>(name);
    public bool GetBoolean(string name, char shortName) => GetOptionValue<bool>(name, shortNames: [shortName]);
    public bool GetBoolean(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<bool>(name, aliases);

    public byte GetByte() => GetArgumentValues<byte>(1, 1).Single();
    public byte GetByte(string name) => GetOptionValue<byte>(name);
    public byte GetByte(string name, char shortName) => GetOptionValue<byte>(name, shortNames: [shortName]);
    public byte GetByte(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<byte>(name, aliases);

    public short GetInt16() => GetArgumentValues<short>(1, 1).Single();
    public short GetInt16(string name) => GetOptionValue<short>(name);
    public short GetInt16(string name, char shortName) => GetOptionValue<short>(name, shortNames: [shortName]);
    public short GetInt16(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<short>(name, aliases);

    public int GetInt32() => GetArgumentValues<int>(1, 1).Single();
    public int GetInt32(string name) => GetOptionValue<int>(name);
    public int GetInt32(string name, char shortName) => GetOptionValue<int>(name, shortNames: [shortName]);
    public int GetInt32(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<int>(name, aliases);

    public long GetInt64() => GetArgumentValues<long>(1, 1).Single();
    public long GetInt64(string name) => GetOptionValue<long>(name);
    public long GetInt64(string name, char shortName) => GetOptionValue<long>(name, shortNames: [shortName]);
    public long GetInt64(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<long>(name, aliases);

    public float GetSingle() => GetArgumentValues<float>(1, 1).Single();
    public float GetSingle(string name) => GetOptionValue<float>(name);
    public float GetSingle(string name, char shortName) => GetOptionValue<float>(name, shortNames: [shortName]);
    public float GetSingle(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<float>(name, aliases);

    public double GetDouble() => GetArgumentValues<double>(1, 1).Single();
    public double GetDouble(string name) => GetOptionValue<double>(name);
    public double GetDouble(string name, char shortName) => GetOptionValue<double>(name, shortNames: [shortName]);
    public double GetDouble(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<double>(name, aliases);

    public decimal GetDecimal() => GetArgumentValues<decimal>(1, 1).Single();
    public decimal GetDecimal(string name) => GetOptionValue<decimal>(name);
    public decimal GetDecimal(string name, char shortName) => GetOptionValue<decimal>(name, shortNames: [shortName]);
    public decimal GetDecimal(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<decimal>(name, aliases);

    public string GetString() => GetArgumentValues<string>(1, 1).Single();
    public string GetString(string name) => GetOptionValue<string>(name);
    public string GetString(string name, char shortName) => GetOptionValue<string>(name, shortNames: [shortName]);
    public string GetString(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<string>(name, aliases);

    public char GetChar() => GetArgumentValues<char>(1, 1).Single();
    public char GetChar(string name) => GetOptionValue<char>(name);
    public char GetChar(string name, char shortName) => GetOptionValue<char>(name, shortNames: [shortName]);
    public char GetChar(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<char>(name, aliases);

    public DateTime GetDateTime() => GetArgumentValues<DateTime>(1, 1).Single();
    public DateTime GetDateTime(string name) => GetOptionValue<DateTime>(name);
    public DateTime GetDateTime(string name, char shortName) => GetOptionValue<DateTime>(name, shortNames: [shortName]);
    public DateTime GetDateTime(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<DateTime>(name, aliases);

    public DateTimeOffset GetDateTimeOffset() => GetArgumentValues<DateTimeOffset>(1, 1).Single();
    public DateTimeOffset GetDateTimeOffset(string name) => GetOptionValue<DateTimeOffset>(name);
    public DateTimeOffset GetDateTimeOffset(string name, char shortName) => GetOptionValue<DateTimeOffset>(name, shortNames: [shortName]);
    public DateTimeOffset GetDateTimeOffset(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<DateTimeOffset>(name, aliases);

    public Guid GetGuid() => GetArgumentValues<Guid>(1, 1).Single();
    public Guid GetGuid(string name) => GetOptionValue<Guid>(name);
    public Guid GetGuid(string name, char shortName) => GetOptionValue<Guid>(name, shortNames: [shortName]);
    public Guid GetGuid(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<Guid>(name, aliases);

    public sbyte GetSByte() => GetArgumentValues<sbyte>(1, 1).Single();
    public sbyte GetSByte(string name) => GetOptionValue<sbyte>(name);
    public sbyte GetSByte(string name, char shortName) => GetOptionValue<sbyte>(name, shortNames: [shortName]);
    public sbyte GetSByte(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<sbyte>(name, aliases);

    public ushort GetUInt16() => GetArgumentValues<ushort>(1, 1).Single();
    public ushort GetUInt16(string name) => GetOptionValue<ushort>(name);
    public ushort GetUInt16(string name, char shortName) => GetOptionValue<ushort>(name, shortNames: [shortName]);
    public ushort GetUInt16(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<ushort>(name, aliases);

    public uint GetUInt32() => GetArgumentValues<uint>(1, 1).Single();
    public uint GetUInt32(string name) => GetOptionValue<uint>(name);
    public uint GetUInt32(string name, char shortName) => GetOptionValue<uint>(name, shortNames: [shortName]);
    public uint GetUInt32(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<uint>(name, aliases);

    public ulong GetUInt64() => GetArgumentValues<ulong>(1, 1).Single();
    public ulong GetUInt64(string name) => GetOptionValue<ulong>(name);
    public ulong GetUInt64(string name, char shortName) => GetOptionValue<ulong>(name, shortNames: [shortName]);
    public ulong GetUInt64(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetOptionValue<ulong>(name, aliases);


    public bool[] GetBooleans(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<bool>(minValues, maxValues).ToArray();
    public bool[] GetBooleans(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<bool[]>(name);
    public bool[] GetBooleans(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<bool[]>(name, shortNames: [shortName]);
    public bool[] GetBooleans(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<bool[]>(name, aliases);

    public byte[] GetBytes(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<byte>(minValues, maxValues).ToArray();
    public byte[] GetBytes(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<byte[]>(name, maxValues: maxValues);
    public byte[] GetBytes(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<byte[]>(name, shortNames: [shortName], maxValues: maxValues);
    public byte[] GetBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<byte[]>(name, aliases, shortNames, maxValues);

    public short[] GetInt16s(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<short>(minValues, maxValues).ToArray();
    public short[] GetInt16s(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<short[]>(name, maxValues: maxValues);
    public short[] GetInt16s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<short[]>(name, shortNames: [shortName], maxValues: maxValues);
    public short[] GetInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<short[]>(name, aliases, shortNames, maxValues);

    public int[] GetInt32s(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<int>(minValues, maxValues).ToArray();
    public int[] GetInt32s(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<int[]>(name, maxValues: maxValues);
    public int[] GetInt32s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<int[]>(name, shortNames: [shortName], maxValues: maxValues);
    public int[] GetInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<int[]>(name, aliases, shortNames, maxValues);

    public long[] GetInt64s(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<long>(minValues, maxValues).ToArray();
    public long[] GetInt64s(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<long[]>(name, maxValues: maxValues);
    public long[] GetInt64s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<long[]>(name, shortNames: [shortName], maxValues: maxValues);
    public long[] GetInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<long[]>(name, aliases, shortNames, maxValues);

    public float[] GetSingles(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<float>(minValues, maxValues).ToArray();
    public float[] GetSingles(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<float[]>(name, maxValues: maxValues);
    public float[] GetSingles(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<float[]>(name, shortNames: [shortName], maxValues: maxValues);
    public float[] GetSingles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<float[]>(name, aliases, shortNames, maxValues);

    public double[] GetDoubles(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<double>(minValues, maxValues).ToArray();
    public double[] GetDoubles(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<double[]>(name, maxValues: maxValues);
    public double[] GetDoubles(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<double[]>(name, shortNames: [shortName], maxValues: maxValues);
    public double[] GetDoubles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<double[]>(name, aliases, shortNames, maxValues);

    public decimal[] GetDecimals(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<decimal>(minValues, maxValues).ToArray();
    public decimal[] GetDecimals(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<decimal[]>(name, maxValues: maxValues);
    public decimal[] GetDecimals(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<decimal[]>(name, shortNames: [shortName], maxValues: maxValues);
    public decimal[] GetDecimals(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<decimal[]>(name, aliases, shortNames, maxValues);

    public string[] GetStrings(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<string>(minValues, maxValues).ToArray();
    public string[] GetStrings(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<string[]>(name, maxValues: maxValues);
    public string[] GetStrings(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<string[]>(name, shortNames: [shortName], maxValues: maxValues);
    public string[] GetStrings(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<string[]>(name, aliases, shortNames, maxValues);

    public char[] GetChars(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<char>(minValues, maxValues).ToArray();
    public char[] GetChars(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<char[]>(name, maxValues: maxValues);
    public char[] GetChars(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<char[]>(name, shortNames: [shortName], maxValues: maxValues);
    public char[] GetChars(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<char[]>(name, aliases, shortNames, maxValues);

    public DateTime[] GetDateTimes(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<DateTime>(minValues, maxValues).ToArray();
    public DateTime[] GetDateTimes(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<DateTime[]>(name, maxValues: maxValues);
    public DateTime[] GetDateTimes(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<DateTime[]>(name, shortNames: [shortName], maxValues: maxValues);
    public DateTime[] GetDateTimes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<DateTime[]>(name, aliases, shortNames, maxValues);

    public DateTimeOffset[] GetDateTimeOffsets(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<DateTimeOffset>(minValues, maxValues).ToArray();
    public DateTimeOffset[] GetDateTimeOffsets(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<DateTimeOffset[]>(name, maxValues: maxValues);
    public DateTimeOffset[] GetDateTimeOffsets(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<DateTimeOffset[]>(name, shortNames: [shortName], maxValues: maxValues);
    public DateTimeOffset[] GetDateTimeOffsets(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<DateTimeOffset[]>(name, aliases, shortNames, maxValues);

    public Guid[] GetGuids(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<Guid>(minValues, maxValues).ToArray();
    public Guid[] GetGuids(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<Guid[]>(name, maxValues: maxValues);
    public Guid[] GetGuids(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<Guid[]>(name, shortNames: [shortName], maxValues: maxValues);
    public Guid[] GetGuids(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<Guid[]>(name, aliases, shortNames, maxValues);

    public sbyte[] GetSBytes(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<sbyte>(minValues, maxValues).ToArray();
    public sbyte[] GetSBytes(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<sbyte[]>(name, maxValues: maxValues);
    public sbyte[] GetSBytes(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<sbyte[]>(name, shortNames: [shortName], maxValues: maxValues);
    public sbyte[] GetSBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<sbyte[]>(name, aliases, shortNames, maxValues);

    public ushort[] GetUInt16s(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<ushort>(minValues, maxValues).ToArray();
    public ushort[] GetUInt16s(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<ushort[]>(name, maxValues: maxValues);
    public ushort[] GetUInt16s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<ushort[]>(name, shortNames: [shortName], maxValues: maxValues);
    public ushort[] GetUInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<ushort[]>(name, aliases, shortNames, maxValues);

    public uint[] GetUInt32s(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<uint>(minValues, maxValues).ToArray();
    public uint[] GetUInt32s(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<uint[]>(name, maxValues: maxValues);
    public uint[] GetUInt32s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<uint[]>(name, shortNames: [shortName], maxValues: maxValues);
    public uint[] GetUInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<uint[]>(name, aliases, shortNames, maxValues);

    public ulong[] GetUInt64s(ushort minValues = 0, ushort maxValues = ushort.MaxValue) => GetArgumentValues<ulong>(minValues, maxValues).ToArray();
    public ulong[] GetUInt64s(string name, ushort maxValues = ushort.MaxValue) => GetOptionValue<ulong[]>(name, maxValues: maxValues);
    public ulong[] GetUInt64s(string name, char shortName, ushort maxValues = ushort.MaxValue) => GetOptionValue<ulong[]>(name, shortNames: [shortName], maxValues: maxValues);
    public ulong[] GetUInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = ushort.MaxValue) => GetOptionValue<ulong[]>(name, aliases, shortNames, maxValues);

    private T GetOptionValue<T>(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null, ushort maxValues = 1)
    {
        if (_options.TryGetValue(name, out var option))
        {
            if (option is not Option<T> optionT)
            {
                throw new InvalidCastException($"Option '{name}' is not defined as type '{typeof(T).Name}'.");
            }

            var result = _parser.Parse(_args);
            var optionValue = result.GetValueForOption<T>(optionT);

            if (optionValue is not null)
            {
                return optionValue;
            }
        }

        AddOption<T>(name, aliases, shortNames, maxValues);
        return GetOptionValue<T>(name, aliases, shortNames);
    }

    private IEnumerable<T> GetArgumentValues<T>(ushort minValues, ushort maxValues)
    {
        var result = _parser.Parse(_args);
        var argsExcludingSubsequentOptions = result.Tokens.TakeWhile(t => !t.Value.StartsWith("-"));

        var argument = new Argument<IEnumerable<T>>($"arg{_argCount++}")
        {
            Arity = ArgumentArity.ZeroOrMore
        };

        _rootCommand.AddArgument(argument);

        foreach (var command in _rootCommand.Children.OfType<Command>())
        {
            command.AddArgument(argument);
        }

        _parser = new(_rootCommand);

        result = _parser.Parse(_args);

        return result.GetValueForArgument<IEnumerable<T>>(argument) ?? Enumerable.Empty<T>();
    }

    private void AddOption<T>(string name, IEnumerable<string>? aliases, IEnumerable<char>? shortNames, ushort maxValues)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        string[] allAliases = [
            $"--{name}",
            .. aliases?.Select(a => $"--{a}") ?? [],
            .. (shortNames ?? [name[0]]).Select(a => $"-{a}")
            ];

        Option<T> option = new(allAliases);
        option.Arity = maxValues > 1 ? option.Arity = new(1, maxValues) : typeof(T) == typeof(bool) ? ArgumentArity.ZeroOrOne : ArgumentArity.ExactlyOne;

        _options.Add(name, option);

        _rootCommand.AddOption(option);
        _parser = new(_rootCommand);
    }
}
