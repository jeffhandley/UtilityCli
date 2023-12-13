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
    "--byte-array", "12", "--byte-array", "13", "--byte-array", "14",
]);

var byte_ = cli.GetByte("byte");
var char_ = cli.GetChar("char");
var datetime_ = cli.GetDateTime("datetime");
var datetimeoffset_ = cli.GetDateTimeOffset("datetimeoffset");
var decimal_ = cli.GetDecimal("decimal");
var double_ = cli.GetDouble("double");
var guid_ = cli.GetGuid("guid");
var boolean_ = cli.GetBoolean("boolean");
var int16_ = cli.GetInt16("int16");
var int32_ = cli.GetInt32("int32");
var int64_ = cli.GetInt64("int64");
var sbyte_ = cli.GetSByte("sbyte");
var single_ = cli.GetSingle("single");
var string_ = cli.GetString("string");
var uint16_ = cli.GetUInt16("uint16");
var uint32_ = cli.GetUInt32("uint32");
var uint64_ = cli.GetUInt64("uint64");
var byteArray_ = cli.GetBytes("byteArray");

var arg0_string = cli.GetString();
var arg1_byte = cli.GetByte();

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
Console.WriteLine($"byte-array: {string.Join(", ", byteArray_ ?? [])}");