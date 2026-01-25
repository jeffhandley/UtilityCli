using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace UtilityCli;

public partial struct CliParseResult
{
    public bool GetRequiredBoolean() => GetNullableStructArgumentValue<bool>() ?? ThrowMissingRequiredArgument<bool>();
    public bool GetRequiredBoolean(string name) => GetBooleanOption(name) ?? ThrowMissingRequiredOption<bool>(name);
    public bool GetRequiredBoolean(string name, char shortName) => GetBooleanOption(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<bool>(name);
    public bool GetRequiredBoolean(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetBooleanOption(name, aliases, shortNames) ?? ThrowMissingRequiredOption<bool>(name);

    public byte GetRequiredByte() => GetNullableStructArgumentValue<byte>() ?? ThrowMissingRequiredArgument<byte>();
    public byte GetRequiredByte(string name) => GetNullableStructOptionValue<byte>(name) ?? ThrowMissingRequiredOption<byte>(name);
    public byte GetRequiredByte(string name, char shortName) => GetNullableStructOptionValue<byte>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<byte>(name);
    public byte GetRequiredByte(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<byte>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<byte>(name);

    public short GetRequiredInt16() => GetNullableStructArgumentValue<short>() ?? ThrowMissingRequiredArgument<short>();
    public short GetRequiredInt16(string name) => GetNullableStructOptionValue<short>(name) ?? ThrowMissingRequiredOption<short>(name);
    public short GetRequiredInt16(string name, char shortName) => GetNullableStructOptionValue<short>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<short>(name);
    public short GetRequiredInt16(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<short>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<short>(name);

    public int GetRequiredInt32() => GetNullableStructArgumentValue<int>() ?? ThrowMissingRequiredArgument<int>();
    public int GetRequiredInt32(string name) => GetNullableStructOptionValue<int>(name) ?? ThrowMissingRequiredOption<int>(name);
    public int GetRequiredInt32(string name, char shortName) => GetNullableStructOptionValue<int>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<int>(name);
    public int GetRequiredInt32(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<int>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<int>(name);

    public long GetRequiredInt64() => GetNullableStructArgumentValue<long>() ?? ThrowMissingRequiredArgument<long>();
    public long GetRequiredInt64(string name) => GetNullableStructOptionValue<long>(name) ?? ThrowMissingRequiredOption<long>(name);
    public long GetRequiredInt64(string name, char shortName) => GetNullableStructOptionValue<long>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<long>(name);
    public long GetRequiredInt64(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<long>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<long>(name);

    public float GetRequiredSingle() => GetNullableStructArgumentValue<float>() ?? ThrowMissingRequiredArgument<float>();
    public float GetRequiredSingle(string name) => GetNullableStructOptionValue<float>(name) ?? ThrowMissingRequiredOption<float>(name);
    public float GetRequiredSingle(string name, char shortName) => GetNullableStructOptionValue<float>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<float>(name);
    public float GetRequiredSingle(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<float>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<float>(name);

    public double GetRequiredDouble() => GetNullableStructArgumentValue<double>() ?? ThrowMissingRequiredArgument<double>();
    public double GetRequiredDouble(string name) => GetNullableStructOptionValue<double>(name) ?? ThrowMissingRequiredOption<double>(name);
    public double GetRequiredDouble(string name, char shortName) => GetNullableStructOptionValue<double>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<double>(name);
    public double GetRequiredDouble(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<double>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<double>(name);

    public decimal GetRequiredDecimal() => GetNullableStructArgumentValue<decimal>() ?? ThrowMissingRequiredArgument<decimal>();
    public decimal GetRequiredDecimal(string name) => GetNullableStructOptionValue<decimal>(name) ?? ThrowMissingRequiredOption<decimal>(name);
    public decimal GetRequiredDecimal(string name, char shortName) => GetNullableStructOptionValue<decimal>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<decimal>(name);
    public decimal GetRequiredDecimal(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<decimal>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<decimal>(name);

    public string GetRequiredString() => GetNullableReferenceArgumentValue<string>() ?? ThrowMissingRequiredArgument<string>();
    public string GetRequiredString(string name) => GetNullableReferenceOptionValue<string>(name) ?? ThrowMissingRequiredOption<string>(name);
    public string GetRequiredString(string name, char shortName) => GetNullableReferenceOptionValue<string>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<string>(name);
    public string GetRequiredString(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableReferenceOptionValue<string>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<string>(name);

    public char GetRequiredChar() => ConvertStringToChar(GetNullableReferenceArgumentValue<string>()) ?? ThrowMissingRequiredArgument<char>();
    public char GetRequiredChar(string name) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name)) ?? ThrowMissingRequiredOption<char>(name);
    public char GetRequiredChar(string name, char shortName) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name, shortNames: [shortName])) ?? ThrowMissingRequiredOption<char>(name);
    public char GetRequiredChar(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => ConvertStringToChar(GetNullableReferenceOptionValue<string>(name, aliases, shortNames)) ?? ThrowMissingRequiredOption<char>(name);

    public DateTime GetRequiredDateTime() => GetNullableStructArgumentValue<DateTime>() ?? ThrowMissingRequiredArgument<DateTime>();
    public DateTime GetRequiredDateTime(string name) => GetNullableStructOptionValue<DateTime>(name) ?? ThrowMissingRequiredOption<DateTime>(name);
    public DateTime GetRequiredDateTime(string name, char shortName) => GetNullableStructOptionValue<DateTime>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<DateTime>(name);
    public DateTime GetRequiredDateTime(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<DateTime>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<DateTime>(name);

    public DateTimeOffset GetRequiredDateTimeOffset() => GetNullableStructArgumentValue<DateTimeOffset>() ?? ThrowMissingRequiredArgument<DateTimeOffset>();
    public DateTimeOffset GetRequiredDateTimeOffset(string name) => GetNullableStructOptionValue<DateTimeOffset>(name) ?? ThrowMissingRequiredOption<DateTimeOffset>(name);
    public DateTimeOffset GetRequiredDateTimeOffset(string name, char shortName) => GetNullableStructOptionValue<DateTimeOffset>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<DateTimeOffset>(name);
    public DateTimeOffset GetRequiredDateTimeOffset(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<DateTimeOffset>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<DateTimeOffset>(name);

    public Guid GetRequiredGuid() => GetNullableStructArgumentValue<Guid>() ?? ThrowMissingRequiredArgument<Guid>();
    public Guid GetRequiredGuid(string name) => GetNullableStructOptionValue<Guid>(name) ?? ThrowMissingRequiredOption<Guid>(name);
    public Guid GetRequiredGuid(string name, char shortName) => GetNullableStructOptionValue<Guid>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<Guid>(name);
    public Guid GetRequiredGuid(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<Guid>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<Guid>(name);

    public sbyte GetRequiredSByte() => GetNullableStructArgumentValue<sbyte>() ?? ThrowMissingRequiredArgument<sbyte>();
    public sbyte GetRequiredSByte(string name) => GetNullableStructOptionValue<sbyte>(name) ?? ThrowMissingRequiredOption<sbyte>(name);
    public sbyte GetRequiredSByte(string name, char shortName) => GetNullableStructOptionValue<sbyte>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<sbyte>(name);
    public sbyte GetRequiredSByte(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<sbyte>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<sbyte>(name);

    public ushort GetRequiredUInt16() => GetNullableStructArgumentValue<ushort>() ?? ThrowMissingRequiredArgument<ushort>();
    public ushort GetRequiredUInt16(string name) => GetNullableStructOptionValue<ushort>(name) ?? ThrowMissingRequiredOption<ushort>(name);
    public ushort GetRequiredUInt16(string name, char shortName) => GetNullableStructOptionValue<ushort>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<ushort>(name);
    public ushort GetRequiredUInt16(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<ushort>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<ushort>(name);

    public uint GetRequiredUInt32() => GetNullableStructArgumentValue<uint>() ?? ThrowMissingRequiredArgument<uint>();
    public uint GetRequiredUInt32(string name) => GetNullableStructOptionValue<uint>(name) ?? ThrowMissingRequiredOption<uint>(name);
    public uint GetRequiredUInt32(string name, char shortName) => GetNullableStructOptionValue<uint>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<uint>(name);
    public uint GetRequiredUInt32(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<uint>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<uint>(name);

    public ulong GetRequiredUInt64() => GetNullableStructArgumentValue<ulong>() ?? ThrowMissingRequiredArgument<ulong>();
    public ulong GetRequiredUInt64(string name) => GetNullableStructOptionValue<ulong>(name) ?? ThrowMissingRequiredOption<ulong>(name);
    public ulong GetRequiredUInt64(string name, char shortName) => GetNullableStructOptionValue<ulong>(name, shortNames: [shortName]) ?? ThrowMissingRequiredOption<ulong>(name);
    public ulong GetRequiredUInt64(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetNullableStructOptionValue<ulong>(name, aliases, shortNames) ?? ThrowMissingRequiredOption<ulong>(name);
}
