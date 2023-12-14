namespace UtilityCli;

public static class CliArgs
{
    public static CliParseResult Parse(IEnumerable<string> args) => new(args);
}
