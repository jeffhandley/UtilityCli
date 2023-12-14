using static UtilityCli.CliArgs;
namespace UtilityCli.Test.OptionValues;

public class GetInt16
{
    private const string Name = "short";
    private const string Alias = "int16";

    private const char ShortNameInferred = 's';
    private const char ShortNameOverride = 'i';

    private const string ValueString = "2";
    private const short Value = 2;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetInt16_Name(string[] args, object expected)
    {
        var cli = UtilityCli.CliArgs.Parse(args);
        short? actual = cli.GetInt16(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetInt16_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        short? actual = cli.GetInt16(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetInt16_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        short? actual = cli.GetInt16(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetInt16_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        short? actual = cli.GetInt16(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetInt16_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        short? actual = cli.GetInt16(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetInt16_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        short? actual = cli.GetInt16(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetInt16_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetInt16(Name));
    }
}
