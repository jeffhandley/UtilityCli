using static UtilityCli.CliParser;
namespace UtilityCli.Test.OptionValues;

public class GetInt64
{
    private const string Name = "long";
    private const string Alias = "int64";

    private const char ShortNameInferred = 'l';
    private const char ShortNameOverride = 'i';

    private const string ValueString = "2";
    private const long Value = 2;

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetInt64_Name(string[] args, object expected)
    {
        var cli = UtilityCli.CliParser.Parse(args);
        long? actual = cli.GetInt64(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetInt64_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        long? actual = cli.GetInt64(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetInt64_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        long? actual = cli.GetInt64(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetInt64_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        long? actual = cli.GetInt64(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetInt64_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        long? actual = cli.GetInt64(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetInt64_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        long? actual = cli.GetInt64(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetInt64_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetInt64(Name));
    }
}
