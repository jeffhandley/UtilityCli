using static UtilityCli.CliArgs;
namespace UtilityCli.Test.OptionValues;

public class GetUInt64s
{
    private const string Name = "ulong";
    private const string Alias = "int64-unsigned";

    private const char ShortNameInferred = 'u';
    private const char ShortNameOverride = 'i';

    private const string ValueString1 = "2";
    private const string ValueString2 = "3";
    private const string ValueString3 = "4";
    private const ulong Value1 = 2;
    private const ulong Value2 = 3;
    private const ulong Value3 = 4;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new ulong[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetUInt64s_Name(string[] args, ulong[]? expected)
    {
        var cli = UtilityCli.CliArgs.Parse(args);
        ulong[]? actual = cli.GetUInt64s(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new ulong[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetUInt64s_Name_ShortName(string[] args, ulong[]? expected)
    {
        var cli = Parse(args);
        ulong[]? actual = cli.GetUInt64s(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new ulong[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetUInt64s_Name_ShortNames(string[] args, ulong[]? expected)
    {
        var cli = Parse(args);
        ulong[]? actual = cli.GetUInt64s(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new ulong[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new ulong[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetUInt64s_Name_Aliases(string[] args, ulong[]? expected)
    {
        var cli = Parse(args);
        ulong[]? actual = cli.GetUInt64s(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new ulong[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new ulong[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, ValueString3, Value1, Value2, Value3, MemberType = typeof(TestData))]
    public void GetUInt64s_Name_Aliases_ShortNames(string[] args, ulong[]? expected)
    {
        var cli = Parse(args);
        ulong[]? actual = cli.GetUInt64s(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetUInt64s_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString1]);
        ulong[]? actual = cli.GetUInt64s(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetUInt64s_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetUInt64s(Name));
    }
}
