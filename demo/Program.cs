var cli = UtilityCli.CliParser.Parse([
    "--byte", "0",
    "--char", "c",
    "--datetime", "2023-12-12",
    "--datetimeoffset", "2023-12-13",
    "--decimal", "1.2",
    "--double", "2.3",
    "--guid", "D4F230DF-E481-4049-B797-AAD0F7F0B736",
    "--boolean",
    "--int16", "3",
    "--int32", "4",
    "--int64", "5",
    "--sbyte", "6",
    "--single", "7.8",
    "--string", "value",
    "--uint16", "8",
    "--uint32", "9",
    "--uint64", "10",
    "string-value",
    "11",
]);

byte? byte_ = cli.GetByte("byte", shortNames: []);
char? char_ = cli.GetChar("char");
DateTime? datetime_ = cli.GetDateTime("datetime");
DateTimeOffset? datetimeoffset_ = cli.GetDateTimeOffset("datetimeoffset", shortNames: []);
decimal? decimal_ = cli.GetDecimal("decimal", shortNames: []);
double? double_ = cli.GetDouble("double", shortNames: []);
Guid? guid_ = cli.GetGuid("guid");
bool? boolean_ = cli.GetBoolean("boolean");
short? int16_ = cli.GetInt16("int16", shortNames: []);
int? int32_ = cli.GetInt32("int32");
long? int64_ = cli.GetInt64("int64", shortNames: []);
sbyte? sbyte_ = cli.GetSByte("sbyte", shortNames: []);
float? single_ = cli.GetSingle("single", shortNames: []);
string? string_ = cli.GetString("string");
ushort? uint16_ = cli.GetUInt16("uint16", shortNames: []);
uint? uint32_ = cli.GetUInt32("uint32");
ulong? uint64_ = cli.GetUInt64("uint64", shortNames: []);

string? arg0_string = cli.GetString();
byte? arg1_byte = cli.GetByte();

Console.WriteLine($"byte: {byte_}");
Console.WriteLine($"char: {char_}");
Console.WriteLine($"datetime: {datetime_}");
Console.WriteLine($"datetimeoffset: {datetimeoffset_}");
Console.WriteLine($"decimal: {decimal_}");
Console.WriteLine($"double: {double_}");
Console.WriteLine($"guid: {guid_}");
Console.WriteLine($"boolean: {boolean_}");
Console.WriteLine($"int16: {int16_}");
Console.WriteLine($"int32: {int32_}");
Console.WriteLine($"int64: {int64_}");
Console.WriteLine($"sbyte: {sbyte_}");
Console.WriteLine($"single: {single_}");
Console.WriteLine($"string: {string_}");
Console.WriteLine($"uint16: {uint16_}");
Console.WriteLine($"uint32: {uint32_}");
Console.WriteLine($"uint64: {uint64_}");
Console.WriteLine($"arg0_string: {arg0_string}");
Console.WriteLine($"arg1_byte: {arg1_byte}");
