using static UtilityCli.CliArgs;
namespace UtilityCli.Test.OptionValues;

public class GetUInt32
{
    private const string Name = "uint";
    private const string Alias = "int32-unsigned";

    private const char ShortNameInferred = 'u';
    private const char ShortNameOverride = 'i';

    private const string ValueString = "2";
    private const uint Value = 2;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetUInt32_Name(string[] args, object expected)
    {
        var cli = UtilityCli.CliArgs.Parse(args);
        uint? actual = cli.GetUInt32(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetUInt32_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        uint? actual = cli.GetUInt32(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetUInt32_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        uint? actual = cli.GetUInt32(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetUInt32_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        uint? actual = cli.GetUInt32(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetUInt32_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        uint? actual = cli.GetUInt32(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetUInt32_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        uint? actual = cli.GetUInt32(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetUInt32_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetUInt32(Name));
    }
}
