using static UtilityCli.CliArgs;
namespace UtilityCli.Test.OptionValues;

public class GetDateTimeOffsets
{
    private const string Name = "datetimeoffset";
    private const string Alias = "offset";

    private const char ShortNameInferred = 'd';
    private const char ShortNameOverride = '0';

    private const string ValueString1 = "2023-12-11";
    private const string ValueString2 = "2023-12-12";
    private const string ValueString3 = "2023-12-13T12:34:56";

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, ValueString1, ValueString2, ValueString3, MemberType = typeof(TestData))]
    public void GetDateTimeOffsets_Name(string[] args, string[]? expected)
    {
        var cli = UtilityCli.CliArgs.Parse(args);
        DateTimeOffset[]? actual = cli.GetDateTimeOffsets(Name);

        Assert.Equal(expected is not null ? expected.Select(s => new DateTimeOffset(Convert.ToDateTime(s))) : null!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, ValueString1, ValueString2, ValueString3, MemberType = typeof(TestData))]
    public void GetDateTimeOffsets_Name_ShortName(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        DateTimeOffset[]? actual = cli.GetDateTimeOffsets(Name, ShortNameInferred);

        Assert.Equal(expected is not null ? expected.Select(s => new DateTimeOffset(Convert.ToDateTime(s))) : null!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, ValueString1, ValueString2, ValueString3, MemberType = typeof(TestData))]
    public void GetDateTimeOffsets_Name_ShortNames(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        DateTimeOffset[]? actual = cli.GetDateTimeOffsets(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected is not null ? expected.Select(s => new DateTimeOffset(Convert.ToDateTime(s))) : null!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, ValueString1, ValueString2, ValueString3, MemberType = typeof(TestData))]
    public void GetDateTimeOffsets_Name_Aliases(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        DateTimeOffset[]? actual = cli.GetDateTimeOffsets(Name, [Alias]);

        Assert.Equal(expected is not null ? expected.Select(s => new DateTimeOffset(Convert.ToDateTime(s))) : null!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new string[] { ValueString1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, ValueString1, ValueString2, ValueString3, MemberType = typeof(TestData))]
    public void GetDateTimeOffsets_Name_Aliases_ShortNames(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        DateTimeOffset[]? actual = cli.GetDateTimeOffsets(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected is not null ? expected.Select(s => new DateTimeOffset(Convert.ToDateTime(s))) : null!, actual!);
    }

    [Fact]
    public void GetDateTimeOffsets_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString1]);
        DateTimeOffset[]? actual = cli.GetDateTimeOffsets(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetDateTimeOffsets_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDateTimeOffsets(Name));
    }
}
