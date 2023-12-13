using static UtilityCli.CliParser;
namespace UtilityCli.Test.OptionValues;

public class GetDateTime
{
    private const string Name = "datetime";
    private const string Alias = "calendar";

    private const char ShortNameInferred = 'd';
    private const char ShortNameOverride = 'c';

    private const string ValueString = "2023-12-12";
    private const string Value = ValueString;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDateTime_Name(string[] args, object expected)
    {
        var cli = UtilityCli.CliParser.Parse(args);
        DateTime? actual = cli.GetDateTime(Name);

        Assert.Equal(expected is not null ? Convert.ToDateTime(expected) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDateTime_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        DateTime? actual = cli.GetDateTime(Name, ShortNameInferred);

        Assert.Equal(expected is not null ? Convert.ToDateTime(expected) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDateTime_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        DateTime? actual = cli.GetDateTime(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected is not null ? Convert.ToDateTime(expected) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDateTime_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        DateTime? actual = cli.GetDateTime(Name, [Alias]);

        Assert.Equal(expected is not null ? Convert.ToDateTime(expected) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDateTime_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        DateTime? actual = cli.GetDateTime(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected is not null ? Convert.ToDateTime(expected) : null, actual);
    }

    [Fact]
    public void GetDateTime_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        DateTime? actual = cli.GetDateTime(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetDateTime_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDateTime(Name));
    }
}
