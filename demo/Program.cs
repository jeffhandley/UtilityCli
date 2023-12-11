var cli = UtilityCliParser.CliParser.Parse(args);
bool test = cli.GetBoolean("test");
string[] arguments = cli.GetStrings();

Console.WriteLine($"test: {test}");
Console.WriteLine($"arguments: {string.Join(", ", arguments)}");
