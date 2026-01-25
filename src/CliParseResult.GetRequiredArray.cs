using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace UtilityCli;

public partial struct CliParseResult
{
    public bool[] GetRequiredBooleans() => GetNullableReferenceArgumentValue<bool[]>() ?? ThrowMissingRequiredArgument<bool[]>();
    public bool[] GetRequiredBooleans(string name) => GetNullableReferenceOptionValue<bool[]>(name) ?? ThrowMissingRequiredOption<bool[]>(name);
    public bool[] GetRequiredBooleans(string name, char shortName) => GetNullableReferenceOptionValue<bool[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<bool[]>(name);
    public bool[] GetRequiredBooleans(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<bool[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<bool[]>(name);

    public byte[] GetRequiredBytes() => GetNullableReferenceArgumentValue<byte[]>() ?? ThrowMissingRequiredArgument<byte[]>();
    public byte[] GetRequiredBytes(string name) => GetNullableReferenceOptionValue<byte[]>(name) ?? ThrowMissingRequiredOption<byte[]>(name);
    public byte[] GetRequiredBytes(string name, char shortName) => GetNullableReferenceOptionValue<byte[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<byte[]>(name);
    public byte[] GetRequiredBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<byte[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<byte[]>(name);

    public short[] GetRequiredInt16s() => GetNullableReferenceArgumentValue<short[]>() ?? ThrowMissingRequiredArgument<short[]>();
    public short[] GetRequiredInt16s(string name) => GetNullableReferenceOptionValue<short[]>(name) ?? ThrowMissingRequiredOption<short[]>(name);
    public short[] GetRequiredInt16s(string name, char shortName) => GetNullableReferenceOptionValue<short[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<short[]>(name);
    public short[] GetRequiredInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<short[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<short[]>(name);

    public int[] GetRequiredInt32s() => GetNullableReferenceArgumentValue<int[]>() ?? ThrowMissingRequiredArgument<int[]>();
    public int[] GetRequiredInt32s(string name) => GetNullableReferenceOptionValue<int[]>(name) ?? ThrowMissingRequiredOption<int[]>(name);
    public int[] GetRequiredInt32s(string name, char shortName) => GetNullableReferenceOptionValue<int[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<int[]>(name);
    public int[] GetRequiredInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<int[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<int[]>(name);

    public long[] GetRequiredInt64s() => GetNullableReferenceArgumentValue<long[]>() ?? ThrowMissingRequiredArgument<long[]>();
    public long[] GetRequiredInt64s(string name) => GetNullableReferenceOptionValue<long[]>(name) ?? ThrowMissingRequiredOption<long[]>(name);
    public long[] GetRequiredInt64s(string name, char shortName) => GetNullableReferenceOptionValue<long[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<long[]>(name);
    public long[] GetRequiredInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<long[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<long[]>(name);

    public float[] GetRequiredSingles() => GetNullableReferenceArgumentValue<float[]>() ?? ThrowMissingRequiredArgument<float[]>();
    public float[] GetRequiredSingles(string name) => GetNullableReferenceOptionValue<float[]>(name) ?? ThrowMissingRequiredOption<float[]>(name);
    public float[] GetRequiredSingles(string name, char shortName) => GetNullableReferenceOptionValue<float[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<float[]>(name);
    public float[] GetRequiredSingles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<float[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<float[]>(name);

    public double[] GetRequiredDoubles() => GetNullableReferenceArgumentValue<double[]>() ?? ThrowMissingRequiredArgument<double[]>();
    public double[] GetRequiredDoubles(string name) => GetNullableReferenceOptionValue<double[]>(name) ?? ThrowMissingRequiredOption<double[]>(name);
    public double[] GetRequiredDoubles(string name, char shortName) => GetNullableReferenceOptionValue<double[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<double[]>(name);
    public double[] GetRequiredDoubles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<double[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<double[]>(name);

    public decimal[] GetRequiredDecimals() => GetNullableReferenceArgumentValue<decimal[]>() ?? ThrowMissingRequiredArgument<decimal[]>();
    public decimal[] GetRequiredDecimals(string name) => GetNullableReferenceOptionValue<decimal[]>(name) ?? ThrowMissingRequiredOption<decimal[]>(name);
    public decimal[] GetRequiredDecimals(string name, char shortName) => GetNullableReferenceOptionValue<decimal[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<decimal[]>(name);
    public decimal[] GetRequiredDecimals(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<decimal[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<decimal[]>(name);

    public string[] GetRequiredStrings() => GetNullableReferenceArgumentValue<string[]>() ?? ThrowMissingRequiredArgument<string[]>();
    public string[] GetRequiredStrings(string name) => GetNullableReferenceOptionValue<string[]>(name) ?? ThrowMissingRequiredOption<string[]>(name);
    public string[] GetRequiredStrings(string name, char shortName) => GetNullableReferenceOptionValue<string[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<string[]>(name);
    public string[] GetRequiredStrings(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<string[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<string[]>(name);

    public char[] GetRequiredChars() => GetNullableReferenceArgumentValue<string[]>()?.Select(ConvertStringsToChars).ToArray() ?? ThrowMissingRequiredArgument<char[]>();
    public char[] GetRequiredChars(string name) => GetNullableReferenceOptionValue<string[]>(name)?.Select(ConvertStringsToChars).ToArray() ?? ThrowMissingRequiredOption<char[]>(name);
    public char[] GetRequiredChars(string name, char shortName) => GetNullableReferenceOptionValue<string[]>(name, shortNames: [shortName])?.Select(ConvertStringsToChars).ToArray() ?? ThrowMissingRequiredOption<char[]>(name);
    public char[] GetRequiredChars(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<string[]>(name, aliases, shortNames)?.Select(ConvertStringsToChars).ToArray() ?? ThrowMissingRequiredOption<char[]>(name);

    public DateTime[] GetRequiredDateTimes() => GetNullableReferenceArgumentValue<DateTime[]>() ?? ThrowMissingRequiredArgument<DateTime[]>();
    public DateTime[] GetRequiredDateTimes(string name) => GetNullableReferenceOptionValue<DateTime[]>(name) ?? ThrowMissingRequiredOption<DateTime[]>(name);
    public DateTime[] GetRequiredDateTimes(string name, char shortName) => GetNullableReferenceOptionValue<DateTime[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<DateTime[]>(name);
    public DateTime[] GetRequiredDateTimes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<DateTime[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<DateTime[]>(name);

    public DateTimeOffset[] GetRequiredDateTimeOffsets() => GetNullableReferenceArgumentValue<DateTimeOffset[]>() ?? ThrowMissingRequiredArgument<DateTimeOffset[]>();
    public DateTimeOffset[] GetRequiredDateTimeOffsets(string name) => GetNullableReferenceOptionValue<DateTimeOffset[]>(name) ?? ThrowMissingRequiredOption<DateTimeOffset[]>(name);
    public DateTimeOffset[] GetRequiredDateTimeOffsets(string name, char shortName) => GetNullableReferenceOptionValue<DateTimeOffset[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<DateTimeOffset[]>(name);
    public DateTimeOffset[] GetRequiredDateTimeOffsets(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<DateTimeOffset[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<DateTimeOffset[]>(name);

    public Guid[] GetRequiredGuids() => GetNullableReferenceArgumentValue<Guid[]>() ?? ThrowMissingRequiredArgument<Guid[]>();
    public Guid[] GetRequiredGuids(string name) => GetNullableReferenceOptionValue<Guid[]>(name) ?? ThrowMissingRequiredOption<Guid[]>(name);
    public Guid[] GetRequiredGuids(string name, char shortName) => GetNullableReferenceOptionValue<Guid[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<Guid[]>(name);
    public Guid[] GetRequiredGuids(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<Guid[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<Guid[]>(name);

    public sbyte[] GetRequiredSBytes() => GetNullableReferenceArgumentValue<sbyte[]>() ?? ThrowMissingRequiredArgument<sbyte[]>();
    public sbyte[] GetRequiredSBytes(string name) => GetNullableReferenceOptionValue<sbyte[]>(name) ?? ThrowMissingRequiredOption<sbyte[]>(name);
    public sbyte[] GetRequiredSBytes(string name, char shortName) => GetNullableReferenceOptionValue<sbyte[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<sbyte[]>(name);
    public sbyte[] GetRequiredSBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<sbyte[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<sbyte[]>(name);

    public ushort[] GetRequiredUInt16s() => GetNullableReferenceArgumentValue<ushort[]>() ?? ThrowMissingRequiredArgument<ushort[]>();
    public ushort[] GetRequiredUInt16s(string name) => GetNullableReferenceOptionValue<ushort[]>(name) ?? ThrowMissingRequiredOption<ushort[]>(name);
    public ushort[] GetRequiredUInt16s(string name, char shortName) => GetNullableReferenceOptionValue<ushort[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<ushort[]>(name);
    public ushort[] GetRequiredUInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<ushort[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<ushort[]>(name);

    public uint[] GetRequiredUInt32s() => GetNullableReferenceArgumentValue<uint[]>() ?? ThrowMissingRequiredArgument<uint[]>();
    public uint[] GetRequiredUInt32s(string name) => GetNullableReferenceOptionValue<uint[]>(name) ?? ThrowMissingRequiredOption<uint[]>(name);
    public uint[] GetRequiredUInt32s(string name, char shortName) => GetNullableReferenceOptionValue<uint[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<uint[]>(name);
    public uint[] GetRequiredUInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<uint[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<uint[]>(name);

    public ulong[] GetRequiredUInt64s() => GetNullableReferenceArgumentValue<ulong[]>() ?? ThrowMissingRequiredArgument<ulong[]>();
    public ulong[] GetRequiredUInt64s(string name) => GetNullableReferenceOptionValue<ulong[]>(name) ?? ThrowMissingRequiredOption<ulong[]>(name);
    public ulong[] GetRequiredUInt64s(string name, char shortName) => GetNullableReferenceOptionValue<ulong[]>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<ulong[]>(name);
    public ulong[] GetRequiredUInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<ulong[]>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<ulong[]>(name);
}
