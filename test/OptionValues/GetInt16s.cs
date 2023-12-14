using static UtilityCli.CliArgs;
namespace UtilityCli.Test.OptionValues;

public class GetInt16s
{
    private const string Name = "short";
    private const string Alias = "int16";

    private const char ShortNameInferred = 's';
    private const char ShortNameOverride = 'i';

    private const string ValueString1 = "2";
    private const string ValueString2 = "3";
    private const string ValueString3 = "4";
    private const short Value1 = 2;
    private const short Value2 = 3;
    private const short Value3 = 4;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new short[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetInt16s_Name(string[] args, short[]? expected)
    {
        var cli = UtilityCli.CliArgs.Parse(args);
        short[]? actual = cli.GetInt16s(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new short[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetInt16s_Name_ShortName(string[] args, short[]? expected)
    {
        var cli = Parse(args);
        short[]? actual = cli.GetInt16s(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new short[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetInt16s_Name_ShortNames(string[] args, short[]? expected)
    {
        var cli = Parse(args);
        short[]? actual = cli.GetInt16s(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new short[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new short[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetInt16s_Name_Aliases(string[] args, short[]? expected)
    {
        var cli = Parse(args);
        short[]? actual = cli.GetInt16s(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new short[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new short[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetInt16s_Name_Aliases_ShortNames(string[] args, short[]? expected)
    {
        var cli = Parse(args);
        short[]? actual = cli.GetInt16s(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetInt16s_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString1]);
        short[]? actual = cli.GetInt16s(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetInt16s_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetInt16s(Name));
    }
}
