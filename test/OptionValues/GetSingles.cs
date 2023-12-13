using static UtilityCli.CliParser;
namespace UtilityCli.Test.OptionValues;

public class GetSingles
{
    private const string Name = "float";
    private const string Alias = "single";

    private const char ShortNameInferred = 'f';
    private const char ShortNameOverride = 's';

    private const string ValueString1 = "2.1";
    private const string ValueString2 = "3.2";
    private const string ValueString3 = "4.3";
    private const float Value1 = 2.1f;
    private const float Value2 = 3.2f;
    private const float Value3 = 4.3f;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new float[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetSingles_Name(string[] args, float[]? expected)
    {
        var cli = UtilityCli.CliParser.Parse(args);
        float[]? actual = cli.GetSingles(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new float[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetSingles_Name_ShortName(string[] args, float[]? expected)
    {
        var cli = Parse(args);
        float[]? actual = cli.GetSingles(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new float[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetSingles_Name_ShortNames(string[] args, float[]? expected)
    {
        var cli = Parse(args);
        float[]? actual = cli.GetSingles(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new float[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new float[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetSingles_Name_Aliases(string[] args, float[]? expected)
    {
        var cli = Parse(args);
        float[]? actual = cli.GetSingles(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new float[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new float[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetSingles_Name_Aliases_ShortNames(string[] args, float[]? expected)
    {
        var cli = Parse(args);
        float[]? actual = cli.GetSingles(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetSingles_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString1]);
        float[]? actual = cli.GetSingles(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetSingles_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetSingles(Name));
    }
}
