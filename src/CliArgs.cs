namespace UtilityCli;

public static class CliArgs
{
    public static CliParseResult Parse(IEnumerable<string> args, Action<CliError>? onError = null) => new(args, onError);
}
