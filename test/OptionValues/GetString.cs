using static UtilityCli.CliParser;
namespace UtilityCli.Test.OptionValues;

public class GetString
{
    private const string Name = "string";
    private const string Alias = "characters";

    private const char ShortNameInferred = 's';
    private const char ShortNameOverride = 'c';

    private const string ValueString = "value";
    private const string Value = "value";

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetString_Name(string[] args, object expected)
    {
        var cli = UtilityCli.CliParser.Parse(args);
        string? actual = cli.GetString(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetString_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        string? actual = cli.GetString(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetString_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        string? actual = cli.GetString(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetString_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        string? actual = cli.GetString(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetString_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        string? actual = cli.GetString(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetString_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        string? actual = cli.GetString(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }
}
