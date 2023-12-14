using static UtilityCli.CliArgs;
namespace UtilityCli.Test.OptionValues;

public class GetUInt64
{
    private const string Name = "ulong";
    private const string Alias = "int64-unsigned";

    private const char ShortNameInferred = 'u';
    private const char ShortNameOverride = 'i';

    private const string ValueString = "2";
    private const ulong Value = 2;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetUInt64_Name(string[] args, object expected)
    {
        var cli = UtilityCli.CliArgs.Parse(args);
        ulong? actual = cli.GetUInt64(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetUInt64_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        ulong? actual = cli.GetUInt64(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetUInt64_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        ulong? actual = cli.GetUInt64(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetUInt64_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        ulong? actual = cli.GetUInt64(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetUInt64_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        ulong? actual = cli.GetUInt64(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetUInt64_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        ulong? actual = cli.GetUInt64(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetUInt64_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetUInt64(Name));
    }
}
