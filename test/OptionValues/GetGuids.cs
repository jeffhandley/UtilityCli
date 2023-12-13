using static UtilityCli.CliParser;
namespace UtilityCli.Test.OptionValues;

public class GetGuids
{
    private const string Name = "guid";
    private const string Alias = "uuid";

    private const char ShortNameInferred = 'g';
    private const char ShortNameOverride = 'u';

    private const string ValueString1 = "D4F230DF-E481-4049-B797-AAD0F7F0B736";
    private const string ValueString2 = "E4814049-D4F2-30DF-B797-AAD0F7F0B736";
    private const string ValueString3 = "4049B797-E481-D4F2-30DF-AAD0F7F0B736";
    private const string Value1 = ValueString1;
    private const string Value2 = ValueString2;
    private const string Value3 = ValueString3;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetGuids_Name(string[] args, string[]? expected)
    {
        var cli = UtilityCli.CliParser.Parse(args);
        Guid[]? actual = cli.GetGuids(Name);

        Assert.Equal(expected?.Select(expected => Guid.Parse(expected))!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetGuids_Name_ShortName(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        Guid[]? actual = cli.GetGuids(Name, ShortNameInferred);

        Assert.Equal(expected?.Select(expected => Guid.Parse(expected))!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetGuids_Name_ShortNames(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        Guid[]? actual = cli.GetGuids(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected?.Select(expected => Guid.Parse(expected))!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new string[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetGuids_Name_Aliases(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        Guid[]? actual = cli.GetGuids(Name, [Alias]);

        Assert.Equal(expected?.Select(expected => Guid.Parse(expected))!, actual!);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new string[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new string[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetGuids_Name_Aliases_ShortNames(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        Guid[]? actual = cli.GetGuids(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected?.Select(expected => Guid.Parse(expected))!, actual!);
    }

    [Fact]
    public void GetGuids_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString1]);
        Guid[]? actual = cli.GetGuids(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetGuids_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetGuids(Name));
    }
}
