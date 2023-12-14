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
    [MemberData(nameof(TestData.Option_Flag), Name, ShortNameInferred, true, MemberType = typeof(TestData))]
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
    [MemberData(nameof(TestData.Option_Flag), Name, ShortNameInferred, true, MemberType = typeof(TestData))]
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
    [MemberData(nameof(TestData.Option_Flag), Name, ShortNameInferred, true, MemberType = typeof(TestData))]
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
    [MemberData(nameof(TestData.Option_Flag), Name, ShortNameInferred, true, MemberType = typeof(TestData))]
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
    [MemberData(nameof(TestData.Option_Flag), Name, ShortNameInferred, true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_Flag), Alias, ShortNameInferred, true, MemberType = typeof(TestData))]
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
}
