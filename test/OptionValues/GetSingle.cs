using static UtilityCliParser.CliParser;
namespace UtilityCliParser.Test.OptionValues;

public class GetSingle
{
    private const string Name = "single";
    private const string Alias = "float";

    private const char ShortNameInferred = 's';
    private const char ShortNameOverride = 'f';

    private const string ValueString = "2";
    private const float Value = 2;

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetSingle_Name(string[] args, object expected)
    {
        var cli = UtilityCliParser.CliParser.Parse(args);
        float? actual = cli.GetSingle(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetSingle_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        float? actual = cli.GetSingle(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetSingle_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        float? actual = cli.GetSingle(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetSingle_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        float? actual = cli.GetSingle(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetSingle_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        float? actual = cli.GetSingle(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetSingle_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        float? actual = cli.GetSingle(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetSingle_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetSingle(Name));
    }
}
