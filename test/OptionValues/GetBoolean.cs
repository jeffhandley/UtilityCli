using static UtilityCli.CliParser;
namespace UtilityCli.Test.OptionValues;

public class GetBoolean
{
    private const string Name = "boolean";
    private const string Alias = "bool";

    private const char ShortNameInferred = 'b';
    private const char ShortNameOverride = 't';

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_PresentWithoutValue), Name, ShortNameInferred, true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    public void GetBoolean_Name(string[] args, bool? expected)
    {
        var cli = Parse(args);
        bool? actual = cli.GetBoolean(Name);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_PresentWithoutValue), Name, ShortNameInferred, true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    public void GetBoolean_Name_ShortName(string[] args, bool? expected)
    {
        var cli = Parse(args);
        bool? actual = cli.GetBoolean(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_PresentWithoutValue), Name, ShortNameInferred, true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    public void GetBoolean_Name_ShortNames(string[] args, bool? expected)
    {
        var cli = Parse(args);
        bool? actual = cli.GetBoolean(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_PresentWithoutValue), Name, ShortNameInferred, true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    public void GetBoolean_Name_Aliases(string[] args, bool? expected)
    {
        var cli = Parse(args);
        bool? actual = cli.GetBoolean(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_PresentWithoutValue), Name, ShortNameInferred, true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_PresentWithoutValue), Alias, ShortNameInferred, true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, "true", true, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, "false", false, MemberType = typeof(TestData))]
    public void GetBoolean_Name_Aliases_ShortNames(string[] args, bool? expected)
    {
        var cli = Parse(args);
        bool? actual = cli.GetBoolean(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetBoolean_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}"]);
        bool? actual = cli.GetBoolean(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }


    [Fact]
    public void GetBoolean_InvalidValue_ReturnsTrue_BecauseTheValueIsTreatedAsAnUnrelatedArgument()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        bool? actual = cli.GetBoolean(Name);

        Assert.True(actual);
    }
}
