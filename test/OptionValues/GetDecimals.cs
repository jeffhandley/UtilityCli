using static UtilityCli.CliParser;
namespace UtilityCli.Test.OptionValues;

public class GetDecimals
{
    private const string Name = "decimal";
    private const string Alias = "money";

    private const char ShortNameInferred = 'd';
    private const char ShortNameOverride = 'm';

    private const string ValueString1 = "2.1";
    private const string ValueString2 = "3.2";
    private const string ValueString3 = "4.3";
    private const double Value1 = 2.1;
    private const double Value2 = 3.2;
    private const double Value3 = 4.3;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetDecimals_Name(string[] args, double[]? expected)
    {
        var cli = UtilityCli.CliParser.Parse(args);
        decimal[]? actual = cli.GetDecimals(Name);

        Assert.Equal(expected?.Select(Convert.ToDecimal)!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetDecimals_Name_ShortName(string[] args, double[]? expected)
    {
        var cli = Parse(args);
        decimal[]? actual = cli.GetDecimals(Name, ShortNameInferred);

        Assert.Equal(expected?.Select(Convert.ToDecimal)!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetDecimals_Name_ShortNames(string[] args, double[]? expected)
    {
        var cli = Parse(args);
        decimal[]? actual = cli.GetDecimals(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected?.Select(Convert.ToDecimal)!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetDecimals_Name_Aliases(string[] args, double[]? expected)
    {
        var cli = Parse(args);
        decimal[]? actual = cli.GetDecimals(Name, [Alias]);

        Assert.Equal(expected?.Select(Convert.ToDecimal)!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetDecimals_Name_Aliases_ShortNames(string[] args, double[]? expected)
    {
        var cli = Parse(args);
        decimal[]? actual = cli.GetDecimals(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected?.Select(Convert.ToDecimal)!, actual!);
    }

    [Fact]
    public void GetDecimals_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString1]);
        decimal[]? actual = cli.GetDecimals(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetDecimals_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDecimals(Name));
    }
}
