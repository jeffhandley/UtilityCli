namespace UtilityCliParser;

public static class CliParser
{
    public static CliParseResult Parse(IEnumerable<string> args) => new CliParseResult(args);
}
