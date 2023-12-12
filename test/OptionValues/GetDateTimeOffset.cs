using static UtilityCliParser.CliParser;
namespace UtilityCliParser.Test.OptionValues;

public class GetDateTimeOffset
{
    private const string Name = "datetimeoffset";
    private const string Alias = "offset";

    private const char ShortNameInferred = 'd';
    private const char ShortNameOverride = 'o';

    private const string ValueString = "2023-12-12";
    private const string Value = ValueString;

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDateTimeOffset_Name(string[] args, object expected)
    {
        var cli = UtilityCliParser.CliParser.Parse(args);
        DateTimeOffset? actual = cli.GetDateTimeOffset(Name);

        Assert.Equal(expected is not null ? new DateTimeOffset(Convert.ToDateTime(expected)) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDateTimeOffset_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        DateTimeOffset? actual = cli.GetDateTimeOffset(Name, ShortNameInferred);

        Assert.Equal(expected is not null ? new DateTimeOffset(Convert.ToDateTime(expected)) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDateTimeOffset_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        DateTimeOffset? actual = cli.GetDateTimeOffset(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected is not null ? new DateTimeOffset(Convert.ToDateTime(expected)) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDateTimeOffset_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        DateTimeOffset? actual = cli.GetDateTimeOffset(Name, [Alias]);

        Assert.Equal(expected is not null ? new DateTimeOffset(Convert.ToDateTime(expected)) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDateTimeOffset_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        DateTimeOffset? actual = cli.GetDateTimeOffset(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected is not null ? new DateTimeOffset(Convert.ToDateTime(expected)) : null, actual);
    }

    [Fact]
    public void GetDateTimeOffset_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        DateTimeOffset? actual = cli.GetDateTimeOffset(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetDateTimeOffset_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDateTimeOffset(Name));
    }
}
