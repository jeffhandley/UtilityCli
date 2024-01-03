using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace UtilityCli;

public partial struct CliParseResult
{
    public bool GetRequiredBoolean() => GetNullableStructArgumentValue<bool>() ?? throw new ArgumentNullException();
    public bool GetRequiredBoolean(string name) => GetBooleanOption(name) ?? throw new ArgumentNullException(name);
    public bool GetRequiredBoolean(string name, char shortName) => GetBooleanOption(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public bool GetRequiredBoolean(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetBooleanOption(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public byte GetRequiredByte() => GetNullableStructArgumentValue<byte>() ?? throw new ArgumentNullException();
    public byte GetRequiredByte(string name) => GetNullableStructOptionValue<byte>(name) ?? throw new ArgumentNullException(name);
    public byte GetRequiredByte(string name, char shortName) => GetNullableStructOptionValue<byte>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public byte GetRequiredByte(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<byte>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public short GetRequiredInt16() => GetNullableStructArgumentValue<short>() ?? throw new ArgumentNullException();
    public short GetRequiredInt16(string name) => GetNullableStructOptionValue<short>(name) ?? throw new ArgumentNullException(name);
    public short GetRequiredInt16(string name, char shortName) => GetNullableStructOptionValue<short>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public short GetRequiredInt16(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<short>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public int GetRequiredInt32() => GetNullableStructArgumentValue<int>() ?? throw new ArgumentNullException();
    public int GetRequiredInt32(string name) => GetNullableStructOptionValue<int>(name) ?? throw new ArgumentNullException(name);
    public int GetRequiredInt32(string name, char shortName) => GetNullableStructOptionValue<int>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public int GetRequiredInt32(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<int>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public long GetRequiredInt64() => GetNullableStructArgumentValue<long>() ?? throw new ArgumentNullException();
    public long GetRequiredInt64(string name) => GetNullableStructOptionValue<long>(name) ?? throw new ArgumentNullException(name);
    public long GetRequiredInt64(string name, char shortName) => GetNullableStructOptionValue<long>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public long GetRequiredInt64(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<long>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public float GetRequiredSingle() => GetNullableStructArgumentValue<float>() ?? throw new ArgumentNullException();
    public float GetRequiredSingle(string name) => GetNullableStructOptionValue<float>(name) ?? throw new ArgumentNullException(name);
    public float GetRequiredSingle(string name, char shortName) => GetNullableStructOptionValue<float>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public float GetRequiredSingle(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<float>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public double GetRequiredDouble() => GetNullableStructArgumentValue<double>() ?? throw new ArgumentNullException();
    public double GetRequiredDouble(string name) => GetNullableStructOptionValue<double>(name) ?? throw new ArgumentNullException(name);
    public double GetRequiredDouble(string name, char shortName) => GetNullableStructOptionValue<double>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public double GetRequiredDouble(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<double>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public decimal GetRequiredDecimal() => GetNullableStructArgumentValue<decimal>() ?? throw new ArgumentNullException();
    public decimal GetRequiredDecimal(string name) => GetNullableStructOptionValue<decimal>(name) ?? throw new ArgumentNullException(name);
    public decimal GetRequiredDecimal(string name, char shortName) => GetNullableStructOptionValue<decimal>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public decimal GetRequiredDecimal(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<decimal>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public string GetRequiredString() => GetNullableReferenceArgumentValue<string>() ?? throw new ArgumentNullException();
    public string GetRequiredString(string name) => GetNullableReferenceOptionValue<string>(name) ?? throw new ArgumentNullException(name);
    public string GetRequiredString(string name, char shortName) => GetNullableReferenceOptionValue<string>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public string GetRequiredString(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<string>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public char GetRequiredChar() => ConvertStringToChar(GetNullableReferenceArgumentValue<string>()) ?? throw new ArgumentNullException();
    public char GetRequiredChar(string name) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name)) ?? throw new ArgumentNullException(name);
    public char GetRequiredChar(string name, char shortName) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name, shortNames: [shortName])) ?? throw new ArgumentNullException(name);
    public char GetRequiredChar(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name, aliases, shortNames)) ?? throw new ArgumentNullException(name);

    public DateTime GetRequiredDateTime() => GetNullableStructArgumentValue<DateTime>() ?? throw new ArgumentNullException();
    public DateTime GetRequiredDateTime(string name) => GetNullableStructOptionValue<DateTime>(name) ?? throw new ArgumentNullException(name);
    public DateTime GetRequiredDateTime(string name, char shortName) => GetNullableStructOptionValue<DateTime>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public DateTime GetRequiredDateTime(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<DateTime>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public DateTimeOffset GetRequiredDateTimeOffset() => GetNullableStructArgumentValue<DateTimeOffset>() ?? throw new ArgumentNullException();
    public DateTimeOffset GetRequiredDateTimeOffset(string name) => GetNullableStructOptionValue<DateTimeOffset>(name) ?? throw new ArgumentNullException(name);
    public DateTimeOffset GetRequiredDateTimeOffset(string name, char shortName) => GetNullableStructOptionValue<DateTimeOffset>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public DateTimeOffset GetRequiredDateTimeOffset(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<DateTimeOffset>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public Guid GetRequiredGuid() => GetNullableStructArgumentValue<Guid>() ?? throw new ArgumentNullException();
    public Guid GetRequiredGuid(string name) => GetNullableStructOptionValue<Guid>(name) ?? throw new ArgumentNullException(name);
    public Guid GetRequiredGuid(string name, char shortName) => GetNullableStructOptionValue<Guid>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public Guid GetRequiredGuid(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<Guid>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public sbyte GetRequiredSByte() => GetNullableStructArgumentValue<sbyte>() ?? throw new ArgumentNullException();
    public sbyte GetRequiredSByte(string name) => GetNullableStructOptionValue<sbyte>(name) ?? throw new ArgumentNullException(name);
    public sbyte GetRequiredSByte(string name, char shortName) => GetNullableStructOptionValue<sbyte>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public sbyte GetRequiredSByte(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<sbyte>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public ushort GetRequiredUInt16() => GetNullableStructArgumentValue<ushort>() ?? throw new ArgumentNullException();
    public ushort GetRequiredUInt16(string name) => GetNullableStructOptionValue<ushort>(name) ?? throw new ArgumentNullException(name);
    public ushort GetRequiredUInt16(string name, char shortName) => GetNullableStructOptionValue<ushort>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public ushort GetRequiredUInt16(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<ushort>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public uint GetRequiredUInt32() => GetNullableStructArgumentValue<uint>() ?? throw new ArgumentNullException();
    public uint GetRequiredUInt32(string name) => GetNullableStructOptionValue<uint>(name) ?? throw new ArgumentNullException(name);
    public uint GetRequiredUInt32(string name, char shortName) => GetNullableStructOptionValue<uint>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public uint GetRequiredUInt32(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<uint>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);

    public ulong GetRequiredUInt64() => GetNullableStructArgumentValue<ulong>() ?? throw new ArgumentNullException();
    public ulong GetRequiredUInt64(string name) => GetNullableStructOptionValue<ulong>(name) ?? throw new ArgumentNullException(name);
    public ulong GetRequiredUInt64(string name, char shortName) => GetNullableStructOptionValue<ulong>(name, shortNames: [shortName]) ?? throw new ArgumentNullException(name);
    public ulong GetRequiredUInt64(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<ulong>(name, aliases, shortNames) ?? throw new ArgumentNullException(name);
}
