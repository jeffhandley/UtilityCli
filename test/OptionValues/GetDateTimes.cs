using static UtilityCli.CliParser;
namespace UtilityCli.Test.OptionValues;

public class GetDateTimes
{
    private const string Name = "datetime";
    private const string Alias = "calendar";

    private const char ShortNameInferred = 'd';
    private const char ShortNameOverride = 'c';

    private const string ValueString1 = "2023-12-11";
    private const string ValueString2 = "2023-12-12";
    private const string ValueString3 = "2023-12-13T12:34:56";

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, ValueString1, ValueString2, ValueString3, MemberType = typeof(TestData))]
    public void GetDateTimes_Name(string[] args, string[]? expected)
    {
        var cli = UtilityCli.CliParser.Parse(args);
        DateTime[]? actual = cli.GetDateTimes(Name);

        Assert.Equal(expected is not null ? expected.Select(Convert.ToDateTime) : null!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, ValueString1, ValueString2, ValueString3, MemberType = typeof(TestData))]
    public void GetDateTimes_Name_ShortName(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        DateTime[]? actual = cli.GetDateTimes(Name, ShortNameInferred);

        Assert.Equal(expected is not null ? expected.Select(Convert.ToDateTime) : null!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, ValueString1, ValueString2, ValueString3, MemberType = typeof(TestData))]
    public void GetDateTimes_Name_ShortNames(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        DateTime[]? actual = cli.GetDateTimes(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected is not null ? expected.Select(Convert.ToDateTime) : null!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, ValueString1, ValueString2, ValueString3, MemberType = typeof(TestData))]
    public void GetDateTimes_Name_Aliases(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        DateTime[]? actual = cli.GetDateTimes(Name, [Alias]);

        Assert.Equal(expected is not null ? expected.Select(Convert.ToDateTime) : null!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, ValueString1, ValueString2, ValueString3, MemberType = typeof(TestData))]
    public void GetDateTimes_Name_Aliases_ShortNames(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        DateTime[]? actual = cli.GetDateTimes(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected is not null ? expected.Select(Convert.ToDateTime) : null!, actual!);
    }

    [Fact]
    public void GetDateTimes_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString1]);
        DateTime[]? actual = cli.GetDateTimes(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetDateTimes_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDateTimes(Name));
    }
}
