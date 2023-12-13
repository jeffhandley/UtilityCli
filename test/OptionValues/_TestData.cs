using Newtonsoft.Json.Linq;

namespace UtilityCli.Test.OptionValues;

public partial class TestData
{
    public static IEnumerable<object?[]> Option_Unspecified(string name, char shortName, object value)
    {
        // Not specified
        yield return [new string[] { }, value];
        yield return [new string[] { "FOO", "BAR" }, value];
        yield return [new string[] { "--FOO", "BAR" }, value];
        yield return [new string[] { "--FOO", "--BAR" }, value];
    }

    public static IEnumerable<object?[]> Option_Flag(string name, char shortName, object value)
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

    public static IEnumerable<object?[]> Option_SingleValue(string name, char shortName, string valueString, object value)
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

    public static IEnumerable<object?[]> Option_MultipleValues(string name, char shortName, string valueString1, string valueString2, string valueString3, object value1, object value2, object value3)
    {
        string[] args;

        // Before other arguments
        args = [$"--{name}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3, "FOO", "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After other arguments
        args = ["FOO", "BAR", $"--{name}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and after other arguments
        args = [$"--{name}", valueString1, "FOO", "BAR", $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before other options
        args = [$"--{name}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3, "--FOO", "--BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After other options
        args = ["--FOO", "--BAR", $"--{name}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and after other options
        args = [$"--{name}", valueString1, "--FOO", "--BAR", $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];
        
        // In the middle of other arguments
        args = ["FOO", $"--{name}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3, "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and in the middle of other arguments
        args = [$"--{name}", valueString1, "FOO", $"--{name}", valueString2, $"--{name}", valueString3, "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After and in the middle of other arguments
        args = ["FOO", $"--{name}", valueString1, "BAR", $"--{name}", valueString2, $"--{name}", valueString3];
        
        // Before other arguments
        args = [$"-{shortName}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3, "FOO", "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];
        
        // After other arguments
        args = ["FOO", "BAR", $"-{shortName}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and after other arguments
        args = [$"-{shortName}", valueString1, "FOO", "BAR", $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];
        
        // Before other options
        args = [$"-{shortName}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3, "--FOO", "--BAR"];
        yield return [args, new object[] { value1, value2, value3 }];
        
        // After other options
        args = ["--FOO", "--BAR", $"-{shortName}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and after other options
        args = [$"-{shortName}", valueString1, "--FOO", "--BAR", $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];
        
        // In the middle of other arguments
        args = ["FOO", $"-{shortName}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3, "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and in the middle of other arguments
        args = [$"-{shortName}", valueString1, "FOO", $"--{name}", valueString2, $"--{name}", valueString3, "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After and in the middle of other arguments
        args = ["FOO", $"-{shortName}", valueString1, "BAR", $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];
    }
}
