using System.CommandLine;
using System.CommandLine.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace UtilityCli;

public partial struct CliParseResult
{
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
}
