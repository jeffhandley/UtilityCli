using static UtilityCli.CliArgs;
namespace UtilityCli.Test.OptionValues;

public class GetDouble
{
    private const string Name = "double";
    private const string Alias = "float2";

    private const char ShortNameInferred = 'd';
    private const char ShortNameOverride = 'f';

    private const string ValueString = "2.0";
    private const double Value = 2.0d;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDouble_Name(string[] args, object expected)
    {
        var cli = UtilityCli.CliArgs.Parse(args);
        double? actual = cli.GetDouble(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDouble_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        double? actual = cli.GetDouble(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDouble_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        double? actual = cli.GetDouble(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDouble_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        double? actual = cli.GetDouble(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetDouble_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        double? actual = cli.GetDouble(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetDouble_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        double? actual = cli.GetDouble(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetDouble_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDouble(Name));
    }
}
