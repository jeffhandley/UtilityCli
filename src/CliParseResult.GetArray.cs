using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace UtilityCli;

public partial struct CliParseResult
{
    public bool[]? GetBooleans() => GetNullableReferenceArgumentValue<bool[]>();
    public bool[]? GetBooleans(string name) => GetNullableReferenceOptionValue<bool[]>(name);
    public bool[]? GetBooleans(string name, char shortName) => GetNullableReferenceOptionValue<bool[]>(name, shortNames: [shortName]);
    public bool[]? GetBooleans(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<bool[]>(name, aliases, shortNames);

    public byte[]? GetBytes() => GetNullableReferenceArgumentValue<byte[]>();
    public byte[]? GetBytes(string name) => GetNullableReferenceOptionValue<byte[]>(name);
    public byte[]? GetBytes(string name, char shortName) => GetNullableReferenceOptionValue<byte[]>(name, shortNames: [shortName]);
    public byte[]? GetBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<byte[]>(name, aliases, shortNames);

    public short[]? GetInt16s() => GetNullableReferenceArgumentValue<short[]>();
    public short[]? GetInt16s(string name) => GetNullableReferenceOptionValue<short[]>(name);
    public short[]? GetInt16s(string name, char shortName) => GetNullableReferenceOptionValue<short[]>(name, shortNames: [shortName]);
    public short[]? GetInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<short[]>(name, aliases, shortNames);

    public int[]? GetInt32s() => GetNullableReferenceArgumentValue<int[]>();
    public int[]? GetInt32s(string name) => GetNullableReferenceOptionValue<int[]>(name);
    public int[]? GetInt32s(string name, char shortName) => GetNullableReferenceOptionValue<int[]>(name, shortNames: [shortName]);
    public int[]? GetInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<int[]>(name, aliases, shortNames);

    public long[]? GetInt64s() => GetNullableReferenceArgumentValue<long[]>();
    public long[]? GetInt64s(string name) => GetNullableReferenceOptionValue<long[]>(name);
    public long[]? GetInt64s(string name, char shortName) => GetNullableReferenceOptionValue<long[]>(name, shortNames: [shortName]);
    public long[]? GetInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<long[]>(name, aliases, shortNames);

    public float[]? GetSingles() => GetNullableReferenceArgumentValue<float[]>();
    public float[]? GetSingles(string name) => GetNullableReferenceOptionValue<float[]>(name);
    public float[]? GetSingles(string name, char shortName) => GetNullableReferenceOptionValue<float[]>(name, shortNames: [shortName]);
    public float[]? GetSingles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<float[]>(name, aliases, shortNames);

    public double[]? GetDoubles() => GetNullableReferenceArgumentValue<double[]>();
    public double[]? GetDoubles(string name) => GetNullableReferenceOptionValue<double[]>(name);
    public double[]? GetDoubles(string name, char shortName) => GetNullableReferenceOptionValue<double[]>(name, shortNames: [shortName]);
    public double[]? GetDoubles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<double[]>(name, aliases, shortNames);

    public decimal[]? GetDecimals() => GetNullableReferenceArgumentValue<decimal[]>();
    public decimal[]? GetDecimals(string name) => GetNullableReferenceOptionValue<decimal[]>(name);
    public decimal[]? GetDecimals(string name, char shortName) => GetNullableReferenceOptionValue<decimal[]>(name, shortNames: [shortName]);
    public decimal[]? GetDecimals(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<decimal[]>(name, aliases, shortNames);

    public string[]? GetStrings() => GetNullableReferenceArgumentValue<string[]>();
    public string[]? GetStrings(string name) => GetNullableReferenceOptionValue<string[]>(name);
    public string[]? GetStrings(string name, char shortName) => GetNullableReferenceOptionValue<string[]>(name, shortNames: [shortName]);
    public string[]? GetStrings(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<string[]>(name, aliases, shortNames);

    public char[]? GetChars() => GetNullableReferenceArgumentValue<string[]>()?.Select(ConvertStringsToChars).ToArray();
    public char[]? GetChars(string name) => GetNullableReferenceOptionValue<string[]>(name)?.Select(ConvertStringsToChars).ToArray();
    public char[]? GetChars(string name, char shortName) => GetNullableReferenceOptionValue<string[]>(name, shortNames: [shortName])?.Select(ConvertStringsToChars).ToArray();
    public char[]? GetChars(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<string[]>(name, aliases, shortNames)?.Select(ConvertStringsToChars).ToArray();

    public DateTime[]? GetDateTimes() => GetNullableReferenceArgumentValue<DateTime[]>();
    public DateTime[]? GetDateTimes(string name) => GetNullableReferenceOptionValue<DateTime[]>(name);
    public DateTime[]? GetDateTimes(string name, char shortName) => GetNullableReferenceOptionValue<DateTime[]>(name, shortNames: [shortName]);
    public DateTime[]? GetDateTimes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<DateTime[]>(name, aliases, shortNames);

    public DateTimeOffset[]? GetDateTimeOffsets() => GetNullableReferenceArgumentValue<DateTimeOffset[]>();
    public DateTimeOffset[]? GetDateTimeOffsets(string name) => GetNullableReferenceOptionValue<DateTimeOffset[]>(name);
    public DateTimeOffset[]? GetDateTimeOffsets(string name, char shortName) => GetNullableReferenceOptionValue<DateTimeOffset[]>(name, shortNames: [shortName]);
    public DateTimeOffset[]? GetDateTimeOffsets(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<DateTimeOffset[]>(name, aliases, shortNames);

    public Guid[]? GetGuids() => GetNullableReferenceArgumentValue<Guid[]>();
    public Guid[]? GetGuids(string name) => GetNullableReferenceOptionValue<Guid[]>(name);
    public Guid[]? GetGuids(string name, char shortName) => GetNullableReferenceOptionValue<Guid[]>(name, shortNames: [shortName]);
    public Guid[]? GetGuids(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<Guid[]>(name, aliases, shortNames);

    public sbyte[]? GetSBytes() => GetNullableReferenceArgumentValue<sbyte[]>();
    public sbyte[]? GetSBytes(string name) => GetNullableReferenceOptionValue<sbyte[]>(name);
    public sbyte[]? GetSBytes(string name, char shortName) => GetNullableReferenceOptionValue<sbyte[]>(name, shortNames: [shortName]);
    public sbyte[]? GetSBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<sbyte[]>(name, aliases, shortNames);

    public ushort[]? GetUInt16s() => GetNullableReferenceArgumentValue<ushort[]>();
    public ushort[]? GetUInt16s(string name) => GetNullableReferenceOptionValue<ushort[]>(name);
    public ushort[]? GetUInt16s(string name, char shortName) => GetNullableReferenceOptionValue<ushort[]>(name, shortNames: [shortName]);
    public ushort[]? GetUInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<ushort[]>(name, aliases, shortNames);

    public uint[]? GetUInt32s() => GetNullableReferenceArgumentValue<uint[]>();
    public uint[]? GetUInt32s(string name) => GetNullableReferenceOptionValue<uint[]>(name);
    public uint[]? GetUInt32s(string name, char shortName) => GetNullableReferenceOptionValue<uint[]>(name, shortNames: [shortName]);
    public uint[]? GetUInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<uint[]>(name, aliases, shortNames);

    public ulong[]? GetUInt64s() => GetNullableReferenceArgumentValue<ulong[]>();
    public ulong[]? GetUInt64s(string name) => GetNullableReferenceOptionValue<ulong[]>(name);
    public ulong[]? GetUInt64s(string name, char shortName) => GetNullableReferenceOptionValue<ulong[]>(name, shortNames: [shortName]);
    public ulong[]? GetUInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<ulong[]>(name, aliases, shortNames);
}
