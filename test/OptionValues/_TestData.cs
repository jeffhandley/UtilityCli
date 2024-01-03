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

    public static IEnumerable<object?[]> Option_Flag(string name, char shortName)
    {
        // Not specified
        yield return [new string[] { }, null];

        // Name
        yield return [new string[] { $"--{name}" }, true];
        yield return [new string[] { $"--{name}", "--FOO" }, true];
        yield return [new string[] { $"--{name}", "-F" }, true];

        // Short Name
        yield return [new string[] { $"-{shortName}" }, true];
        yield return [new string[] { $"-{shortName}", "--FOO" }, true];
        yield return [new string[] { $"-{shortName}", "-F" }, true];

        // Bundled Short Names
        yield return [new string[] { $"-FB" }, null];
        yield return [new string[] { $"-{shortName}FB" }, true];
        yield return [new string[] { $"-F{shortName}B" }, true];
        yield return [new string[] { $"-FB{shortName}" }, true];
        yield return [new string[] { $"-{shortName}FB", "-QUX" }, true];
        yield return [new string[] { $"-F{shortName}B", "-QUX" }, true];
        yield return [new string[] { $"-FB{shortName}", "-QUX" }, true];

        // Bundled Short Names with value (true)
        yield return [new string[] { $"-FB", "true" }, null];
        yield return [new string[] { $"-{shortName}FB", "true" }, true];
        yield return [new string[] { $"-F{shortName}B", "true" }, true];
        yield return [new string[] { $"-FB{shortName}", "true" }, true];
        yield return [new string[] { $"-{shortName}FB", "-QUX", "true" }, true];
        yield return [new string[] { $"-F{shortName}B", "-QUX", "true" }, true];
        yield return [new string[] { $"-FB{shortName}", "-QUX", "true" }, true];

        // Bundled Short Names with value (false)
        // Only the last bundled short name gets the value applied to it
        yield return [new string[] { $"-FB", "false" }, null];
        yield return [new string[] { $"-{shortName}FB", "false" }, true];
        yield return [new string[] { $"-F{shortName}B", "false" }, true];
        yield return [new string[] { $"-FB{shortName}", "false" }, false];
        yield return [new string[] { $"-{shortName}FB", "-QUX", "false" }, true];
        yield return [new string[] { $"-F{shortName}B", "-QUX", "false" }, true];
        yield return [new string[] { $"-FB{shortName}", "-QUX", "false" }, true];
    }

    public static IEnumerable<object?[]> Option_SingleValue(string name, char shortName, string valueString, object value)
    {
        // Without other arguments
        yield return [new string[] { $"--{name}", valueString }, value];
        yield return [new string[] { $"-{shortName}", valueString }, value];

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

        // Before other arguments (all using name)
        args = [$"--{name}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3, "FOO", "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After other arguments (all using name)
        args = ["FOO", "BAR", $"--{name}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and after other arguments (all using name)
        args = [$"--{name}", valueString1, "FOO", "BAR", $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before other options (all using name)
        args = [$"--{name}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3, "--FOO", "--BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After other options (all using name)
        args = ["--FOO", "--BAR", $"--{name}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and after other options (all using name)
        args = [$"--{name}", valueString1, "--FOO", "--BAR", $"--{name}", valueString2, $"--{name}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // In the middle of other arguments (all using name)
        args = ["FOO", $"--{name}", valueString1, $"--{name}", valueString2, $"--{name}", valueString3, "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and in the middle of other arguments (all using name)
        args = [$"--{name}", valueString1, "FOO", $"--{name}", valueString2, $"--{name}", valueString3, "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After and in the middle of other arguments (all using name)
        args = ["FOO", $"--{name}", valueString1, "BAR", $"--{name}", valueString2, $"--{name}", valueString3];
        

        // Before other arguments (all using short name)
        args = [$"-{shortName}", valueString1, $"-{shortName}", valueString2, $"-{shortName}", valueString3, "FOO", "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After other arguments (all using short name)
        args = ["FOO", "BAR", $"-{shortName}", valueString1, $"-{shortName}", valueString2, $"-{shortName}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and after other arguments (all using short name)
        args = [$"-{shortName}", valueString1, "FOO", "BAR", $"-{shortName}", valueString2, $"-{shortName}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];
        
        // Before other options (all using short name)
        args = [$"-{shortName}", valueString1, $"-{shortName}", valueString2, $"-{shortName}", valueString3, "--FOO", "--BAR"];
        yield return [args, new object[] { value1, value2, value3 }];
        
        // After other options (all using short name)
        args = ["--FOO", "--BAR", $"-{shortName}", valueString1, $"-{shortName}", valueString2, $"-{shortName}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and after other options (all using short name)
        args = [$"-{shortName}", valueString1, "--FOO", "--BAR", $"-{shortName}", valueString2, $"-{shortName}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // In the middle of other arguments (all using short name)
        args = ["FOO", $"-{shortName}", valueString1, $"-{shortName}", valueString2, $"-{shortName}", valueString3, "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and in the middle of other arguments (all using short name)
        args = [$"-{shortName}", valueString1, "FOO", $"-{shortName}", valueString2, $"-{shortName}", valueString3, "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After and in the middle of other arguments (all using short name)
        args = ["FOO", $"-{shortName}", valueString1, "BAR", $"-{shortName}", valueString2, $"-{shortName}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];


        // Before other arguments (with a mixture of name/short name)
        args = [$"-{shortName}", valueString1, $"--{name}", valueString2, $"-{shortName}", valueString3, "FOO", "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After other arguments (with a mixture of name/short name)
        args = ["FOO", "BAR", $"-{shortName}", valueString1, $"--{name}", valueString2, $"-{shortName}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and after other arguments (with a mixture of name/short name)
        args = [$"-{shortName}", valueString1, "FOO", "BAR", $"--{name}", valueString2, $"-{shortName}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before other options (with a mixture of name/short name)
        args = [$"-{shortName}", valueString1, $"--{name}", valueString2, $"-{shortName}", valueString3, "--FOO", "--BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After other options (with a mixture of name/short name)
        args = ["--FOO", "--BAR", $"-{shortName}", valueString1, $"--{name}", valueString2, $"-{shortName}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and after other options (with a mixture of name/short name)
        args = [$"-{shortName}", valueString1, "--FOO", "--BAR", $"--{name}", valueString2, $"-{shortName}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];

        // In the middle of other arguments (with a mixture of name/short name)
        args = ["FOO", $"-{shortName}", valueString1, $"--{name}", valueString2, $"-{shortName}", valueString3, "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // Before and in the middle of other arguments (with a mixture of name/short name)
        args = [$"-{shortName}", valueString1, "FOO", $"--{name}", valueString2, $"-{shortName}", valueString3, "BAR"];
        yield return [args, new object[] { value1, value2, value3 }];

        // After and in the middle of other arguments (with a mixture of name/short name)
        args = ["FOO", $"-{shortName}", valueString1, "BAR", $"--{name}", valueString2, $"-{shortName}", valueString3];
        yield return [args, new object[] { value1, value2, value3 }];
    }
}
