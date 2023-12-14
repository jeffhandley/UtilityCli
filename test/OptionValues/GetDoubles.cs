using static UtilityCli.CliArgs;
namespace UtilityCli.Test.OptionValues;

public class GetDoubles
{
    private const string Name = "double";
    private const string Alias = "float2";

    private const char ShortNameInferred = 'd';
    private const char ShortNameOverride = 'm';

    private const string ValueString1 = "2.1";
    private const string ValueString2 = "3.2";
    private const string ValueString3 = "4.3";
    private const double Value1 = 2.1d;
    private const double Value2 = 3.2d;
    private const double Value3 = 4.3d;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetDoubles_Name(string[] args, double[]? expected)
    {
        var cli = UtilityCli.CliArgs.Parse(args);
        double[]? actual = cli.GetDoubles(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetDoubles_Name_ShortName(string[] args, double[]? expected)
    {
        var cli = Parse(args);
        double[]? actual = cli.GetDoubles(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetDoubles_Name_ShortNames(string[] args, double[]? expected)
    {
        var cli = Parse(args);
        double[]? actual = cli.GetDoubles(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetDoubles_Name_Aliases(string[] args, double[]? expected)
    {
        var cli = Parse(args);
        double[]? actual = cli.GetDoubles(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new double[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetDoubles_Name_Aliases_ShortNames(string[] args, double[]? expected)
    {
        var cli = Parse(args);
        double[]? actual = cli.GetDoubles(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetDoubles_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString1]);
        double[]? actual = cli.GetDoubles(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetDoubles_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDoubles(Name));
    }
}
