using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace UtilityCli;

public partial struct CliParseResult
{
    public bool[] GetRequiredBooleans() => GetNullableReferenceArgumentValue<bool[]>() ?? throw new ArgumentNullException();
    public bool[] GetRequiredBooleans(string name) => GetNullableReferenceOptionValue<bool[]>(name) ?? throw new ArgumentNullException(name);
    public bool[] GetRequiredBooleans(string name, char shortName) => GetNullableReferenceOptionValue<bool[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public bool[] GetRequiredBooleans(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<bool[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public byte[] GetRequiredBytes() => GetNullableReferenceArgumentValue<byte[]>() ?? throw new ArgumentNullException();
    public byte[] GetRequiredBytes(string name) => GetNullableReferenceOptionValue<byte[]>(name) ?? throw new ArgumentNullException(name);
    public byte[] GetRequiredBytes(string name, char shortName) => GetNullableReferenceOptionValue<byte[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public byte[] GetRequiredBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<byte[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public short[] GetRequiredInt16s() => GetNullableReferenceArgumentValue<short[]>() ?? throw new ArgumentNullException();
    public short[] GetRequiredInt16s(string name) => GetNullableReferenceOptionValue<short[]>(name) ?? throw new ArgumentNullException(name);
    public short[] GetRequiredInt16s(string name, char shortName) => GetNullableReferenceOptionValue<short[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public short[] GetRequiredInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<short[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public int[] GetRequiredInt32s() => GetNullableReferenceArgumentValue<int[]>() ?? throw new ArgumentNullException();
    public int[] GetRequiredInt32s(string name) => GetNullableReferenceOptionValue<int[]>(name) ?? throw new ArgumentNullException(name);
    public int[] GetRequiredInt32s(string name, char shortName) => GetNullableReferenceOptionValue<int[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public int[] GetRequiredInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<int[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public long[] GetRequiredInt64s() => GetNullableReferenceArgumentValue<long[]>() ?? throw new ArgumentNullException();
    public long[] GetRequiredInt64s(string name) => GetNullableReferenceOptionValue<long[]>(name) ?? throw new ArgumentNullException(name);
    public long[] GetRequiredInt64s(string name, char shortName) => GetNullableReferenceOptionValue<long[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public long[] GetRequiredInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<long[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public float[] GetRequiredSingles() => GetNullableReferenceArgumentValue<float[]>() ?? throw new ArgumentNullException();
    public float[] GetRequiredSingles(string name) => GetNullableReferenceOptionValue<float[]>(name) ?? throw new ArgumentNullException(name);
    public float[] GetRequiredSingles(string name, char shortName) => GetNullableReferenceOptionValue<float[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public float[] GetRequiredSingles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<float[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public double[] GetRequiredDoubles() => GetNullableReferenceArgumentValue<double[]>() ?? throw new ArgumentNullException();
    public double[] GetRequiredDoubles(string name) => GetNullableReferenceOptionValue<double[]>(name) ?? throw new ArgumentNullException(name);
    public double[] GetRequiredDoubles(string name, char shortName) => GetNullableReferenceOptionValue<double[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public double[] GetRequiredDoubles(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<double[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public decimal[] GetRequiredDecimals() => GetNullableReferenceArgumentValue<decimal[]>() ?? throw new ArgumentNullException();
    public decimal[] GetRequiredDecimals(string name) => GetNullableReferenceOptionValue<decimal[]>(name) ?? throw new ArgumentNullException(name);
    public decimal[] GetRequiredDecimals(string name, char shortName) => GetNullableReferenceOptionValue<decimal[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public decimal[] GetRequiredDecimals(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<decimal[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public string[] GetRequiredStrings() => GetNullableReferenceArgumentValue<string[]>() ?? throw new ArgumentNullException();
    public string[] GetRequiredStrings(string name) => GetNullableReferenceOptionValue<string[]>(name) ?? throw new ArgumentNullException(name);
    public string[] GetRequiredStrings(string name, char shortName) => GetNullableReferenceOptionValue<string[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public string[] GetRequiredStrings(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<string[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public char[] GetRequiredChars() => GetNullableReferenceArgumentValue<string[]>()?.Select(ConvertStringsToChars).ToArray() ?? throw new ArgumentNullException();
    public char[] GetRequiredChars(string name) => GetNullableReferenceOptionValue<string[]>(name)?.Select(ConvertStringsToChars).ToArray() ?? throw new ArgumentNullException(name);
    public char[] GetRequiredChars(string name, char shortName) => GetNullableReferenceOptionValue<string[]>(name, shortNames: [shortName])?.Select(ConvertStringsToChars).ToArray() ?? throw new ArgumentNullException(name);
    public char[] GetRequiredChars(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<string[]>(name, aliases, shortNames)?.Select(ConvertStringsToChars).ToArray() ?? throw new ArgumentNullException(name);

    public DateTime[] GetRequiredDateTimes() => GetNullableReferenceArgumentValue<DateTime[]>() ?? throw new ArgumentNullException();
    public DateTime[] GetRequiredDateTimes(string name) => GetNullableReferenceOptionValue<DateTime[]>(name) ?? throw new ArgumentNullException(name);
    public DateTime[] GetRequiredDateTimes(string name, char shortName) => GetNullableReferenceOptionValue<DateTime[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public DateTime[] GetRequiredDateTimes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<DateTime[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public DateTimeOffset[] GetRequiredDateTimeOffsets() => GetNullableReferenceArgumentValue<DateTimeOffset[]>() ?? throw new ArgumentNullException();
    public DateTimeOffset[] GetRequiredDateTimeOffsets(string name) => GetNullableReferenceOptionValue<DateTimeOffset[]>(name) ?? throw new ArgumentNullException(name);
    public DateTimeOffset[] GetRequiredDateTimeOffsets(string name, char shortName) => GetNullableReferenceOptionValue<DateTimeOffset[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public DateTimeOffset[] GetRequiredDateTimeOffsets(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<DateTimeOffset[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public Guid[] GetRequiredGuids() => GetNullableReferenceArgumentValue<Guid[]>() ?? throw new ArgumentNullException();
    public Guid[] GetRequiredGuids(string name) => GetNullableReferenceOptionValue<Guid[]>(name) ?? throw new ArgumentNullException(name);
    public Guid[] GetRequiredGuids(string name, char shortName) => GetNullableReferenceOptionValue<Guid[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public Guid[] GetRequiredGuids(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<Guid[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public sbyte[] GetRequiredSBytes() => GetNullableReferenceArgumentValue<sbyte[]>() ?? throw new ArgumentNullException();
    public sbyte[] GetRequiredSBytes(string name) => GetNullableReferenceOptionValue<sbyte[]>(name) ?? throw new ArgumentNullException(name);
    public sbyte[] GetRequiredSBytes(string name, char shortName) => GetNullableReferenceOptionValue<sbyte[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public sbyte[] GetRequiredSBytes(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<sbyte[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public ushort[] GetRequiredUInt16s() => GetNullableReferenceArgumentValue<ushort[]>() ?? throw new ArgumentNullException();
    public ushort[] GetRequiredUInt16s(string name) => GetNullableReferenceOptionValue<ushort[]>(name) ?? throw new ArgumentNullException(name);
    public ushort[] GetRequiredUInt16s(string name, char shortName) => GetNullableReferenceOptionValue<ushort[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public ushort[] GetRequiredUInt16s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<ushort[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public uint[] GetRequiredUInt32s() => GetNullableReferenceArgumentValue<uint[]>() ?? throw new ArgumentNullException();
    public uint[] GetRequiredUInt32s(string name) => GetNullableReferenceOptionValue<uint[]>(name) ?? throw new ArgumentNullException(name);
    public uint[] GetRequiredUInt32s(string name, char shortName) => GetNullableReferenceOptionValue<uint[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public uint[] GetRequiredUInt32s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<uint[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public ulong[] GetRequiredUInt64s() => GetNullableReferenceArgumentValue<ulong[]>() ?? throw new ArgumentNullException();
    public ulong[] GetRequiredUInt64s(string name) => GetNullableReferenceOptionValue<ulong[]>(name) ?? throw new ArgumentNullException(name);
    public ulong[] GetRequiredUInt64s(string name, char shortName) => GetNullableReferenceOptionValue<ulong[]>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public ulong[] GetRequiredUInt64s(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<ulong[]>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);
}
