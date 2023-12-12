using static UtilityCliParser.CliParser;
namespace UtilityCliParser.Test.OptionValues;

public class GetDecimal
{
    private const string Name = "decimal";
    private const string Alias = "money";

    private const char ShortNameInferred = 'd';
    private const char ShortNameOverride = 'm';

    private const string ValueString = "2.0";
    private const double Value = 2.0d;

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDecimal_Name(string[] args, object expected)
    {
        var cli = UtilityCliParser.CliParser.Parse(args);
        decimal? actual = cli.GetDecimal(Name);

        Assert.Equal(expected is not null ? Convert.ToDecimal(expected) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDecimal_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        decimal? actual = cli.GetDecimal(Name, ShortNameInferred);

        Assert.Equal(expected is not null ? Convert.ToDecimal(expected) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDecimal_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        decimal? actual = cli.GetDecimal(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected is not null ? Convert.ToDecimal(expected) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDecimal_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        decimal? actual = cli.GetDecimal(Name, [Alias]);

        Assert.Equal(expected is not null ? Convert.ToDecimal(expected) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDecimal_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        decimal? actual = cli.GetDecimal(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected is not null ? Convert.ToDecimal(expected) : null, actual);
    }

    [Fact]
    public void GetDecimal_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        decimal? actual = cli.GetDecimal(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetDecimal_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDecimal(Name));
    }
}
