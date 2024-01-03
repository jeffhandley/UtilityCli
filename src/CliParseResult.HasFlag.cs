namespace UtilityCli;

public partial struct CliParseResult
{
    public bool HasFlag(string name) => GetBooleanOption(name) ?? false;
    public bool HasFlag(string name, char shortName) => GetBooleanOption(name, shortNames: [shortName]) ?? false;
    public bool HasFlag(string name, IEnumerable<string>? aliases = null, IEnumerable<char>? shortNames = null) => GetBooleanOption(name, aliases, shortNames) ?? false;
}
