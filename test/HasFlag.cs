using static UtilityCli.CliArgs;
namespace UtilityCli.Test.OptionValues;

public class HasFlag
{
    private const string Name = "boolean";
    private const string Alias = "bool";

    private const char ShortNameInferred = 'b';
    private const char ShortNameOverride = 't';

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, false, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_Flag), Name, ShortNameInferred, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    public void HasFlag_Name(string[] args, bool expected)
    {
        var cli = Parse(args);
        bool actual = cli.HasFlag(Name);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, false, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_Flag), Name, ShortNameInferred, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    public void HasFlag_Name_ShortName(string[] args, bool expected)
    {
        var cli = Parse(args);
        bool actual = cli.HasFlag(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, false, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_Flag), Name, ShortNameInferred, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    public void HasFlag_Name_ShortNames(string[] args, bool expected)
    {
        var cli = Parse(args);
        bool actual = cli.HasFlag(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, false, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_Flag), Name, ShortNameInferred, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    public void HasFlag_Name_Aliases(string[] args, bool expected)
    {
        var cli = Parse(args);
        bool actual = cli.HasFlag(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, false, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_Flag), Name, ShortNameInferred, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_Flag), Alias, ShortNameInferred, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    public void HasFlag_Name_Aliases_ShortNames(string[] args, bool expected)
    {
        var cli = Parse(args);
        bool actual = cli.HasFlag(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void HasFlag_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}"]);
        bool actual = cli.HasFlag(Name, shortNames: [ShortNameOverride]);

        Assert.False(actual);
    }


    [Fact]
    public void HasFlag_InvalidValue_ReturnsTrue_BecauseTheValueIsTreatedAsAnUnrelatedArgument()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        bool actual = cli.HasFlag(Name);

        Assert.True(actual);
    }

    [Theory]
    [InlineData(new string[] { "-abc" }, "abcd", new bool[] { true, true, true, false })]
    [InlineData(new string[] { "-abc" }, "bcda", new bool[] { true, true, false, true })]
    [InlineData(new string[] { "-abc" }, "cdab", new bool[] { true, false, true, true })]
    [InlineData(new string[] { "-abc" }, "dabc", new bool[] { false, true, true, true })]
    [InlineData(new string[] { "-abc" }, "cbad", new bool[] { true, true, true, false })]
    [InlineData(new string[] { "-abc" }, "badc", new bool[] { true, true, false, true })]
    [InlineData(new string[] { "-abc" }, "adcb", new bool[] { true, false, true, true })]
    [InlineData(new string[] { "-abc" }, "dcba", new bool[] { false, true, true, true })]

    [InlineData(new string[] { "-aEF", "-GbH", "-IJc" }, "abcd", new bool[] { true, true, true, false })]
    [InlineData(new string[] { "-aEF", "-GbH", "-IJc" }, "bcda", new bool[] { true, true, false, true })]
    [InlineData(new string[] { "-aEF", "-GbH", "-IJc" }, "cdab", new bool[] { true, false, true, true })]
    [InlineData(new string[] { "-aEF", "-GbH", "-IJc" }, "dabc", new bool[] { false, true, true, true })]
    [InlineData(new string[] { "-aEF", "-GbH", "-IJc" }, "cbad", new bool[] { true, true, true, false })]
    [InlineData(new string[] { "-aEF", "-GbH", "-IJc" }, "badc", new bool[] { true, true, false, true })]
    [InlineData(new string[] { "-aEF", "-GbH", "-IJc" }, "adcb", new bool[] { true, false, true, true })]
    [InlineData(new string[] { "-aEF", "-GbH", "-IJc" }, "dcba", new bool[] { false, true, true, true })]

    // When a value is specified after a bundle, only the last flag in the bundle is set
    [InlineData(new string[] { "-abc", "true" }, "abcd", new bool[] { true, true, true, false })]
    [InlineData(new string[] { "-abc", "true" }, "bcda", new bool[] { true, true, false, true })]
    [InlineData(new string[] { "-abc", "true" }, "cdab", new bool[] { true, false, true, true })]
    [InlineData(new string[] { "-abc", "true" }, "dabc", new bool[] { false, true, true, true })]
    [InlineData(new string[] { "-abc", "true" }, "cbad", new bool[] { true, true, true, false })]
    [InlineData(new string[] { "-abc", "true" }, "badc", new bool[] { true, true, false, true })]
    [InlineData(new string[] { "-abc", "true" }, "adcb", new bool[] { true, false, true, true })]
    [InlineData(new string[] { "-abc", "true" }, "dcba", new bool[] { false, true, true, true })]
    [InlineData(new string[] { "-abc", "false" }, "abcd", new bool[] { true, true, false, false })]
    [InlineData(new string[] { "-abc", "false" }, "bcda", new bool[] { true, false, false, true })]
    [InlineData(new string[] { "-abc", "false" }, "cdab", new bool[] { false, false, true, true })]
    [InlineData(new string[] { "-abc", "false" }, "dabc", new bool[] { false, true, true, false })]
    [InlineData(new string[] { "-abc", "false" }, "cbad", new bool[] { false, true, true, false })]
    [InlineData(new string[] { "-abc", "false" }, "badc", new bool[] { true, true, false, false })]
    [InlineData(new string[] { "-abc", "false" }, "adcb", new bool[] { true, false, false, true })]
    [InlineData(new string[] { "-abc", "false" }, "dcba", new bool[] { false, false, true, true })]
    public void HasFlag_SupportsAnyBundleOrdering(string[] args, string flagsToCheck, bool[] expected)
    {
        var cli = Parse(args);
        var actual = new bool[expected.Length];

        for (var i = 0; i < flagsToCheck.Length; i++)
        {
            actual[i] = cli.HasFlag(flagsToCheck[i].ToString());
        }

        Assert.Equal(expected, actual);
    }
}
