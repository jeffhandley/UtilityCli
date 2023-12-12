namespace UtilityCliParser.Test.OptionValues;

public partial class TestData
{
    public static IEnumerable<object?[]> GetTestValues_Unspecified(string name, char shortName, object value)
    {
        // Not specified
        yield return [new string[] { }, value];
        yield return [new string[] { "FOO", "BAR" }, value];
        yield return [new string[] { "--FOO", "BAR" }, value];
        yield return [new string[] { "--FOO", "--BAR" }, value];
    }

    public static IEnumerable<object?[]> GetTestValues_PresentWithoutValue(string name, char shortName, object value)
    {
        // Name
        yield return [new string[] { $"--{name}" }, value];
        yield return [new string[] { $"--{name}", "--FOO" }, value];
        yield return [new string[] { $"--{name}", "-F" }, value];

        // Short Name
        yield return [new string[] { $"-{shortName}" }, value];
        yield return [new string[] { $"-{shortName}", "--FOO" }, value];
        yield return [new string[] { $"-{shortName}", "-F" }, value];
    }

    public static IEnumerable<object?[]> GetTestValues_Specified(string name, char shortName, string valueString, object value)
    {
        // Before other arguments
        yield return [new string[] { $"--{name}", valueString, "FOO", "BAR" }, value];

        // After other arguments
        yield return [new string[] { "FOO", "BAR", $"--{name}", valueString }, value];

        // Before other options
        yield return [new string[] { $"--{name}", valueString, "--FOO", "--BAR" }, value];

        // After other options
        yield return [new string[] { "--FOO", "--BAR", $"--{name}", valueString }, value];

        // In the middle of other arguments
        yield return [new string[] { "FOO", $"--{name}", valueString, "BAR" }, value];

        // Before other arguments
        yield return [new string[] { $"-{shortName}", valueString, "FOO", "BAR" }, value];

        // After other arguments
        yield return [new string[] { "FOO", "BAR", $"-{shortName}", valueString }, value];

        // Before other options
        yield return [new string[] { $"-{shortName}", valueString, "--FOO", "--BAR" }, value];

        // After other options
        yield return [new string[] { "--FOO", "--BAR", $"-{shortName}", valueString }, value];

        // In the middle of other arguments
        yield return [new string[] { "FOO", $"-{shortName}", valueString, "BAR" }, value];

    }
}
