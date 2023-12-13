using static UtilityCli.CliParser;
namespace UtilityCli.Test.OptionValues;

public class GetBytes
{
    private const string Name = "byte";
    private const string Alias = "uint8";

    private const char ShortNameInferred = 'b';
    private const char ShortNameOverride = 'u';

    private const string ValueString1 = "2";
    private const string ValueString2 = "3";
    private const byte Value1 = 2;
    private const byte Value2 = 3;

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new byte[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, Value1, Value2, MemberType = typeof(TestData))]
    public void GetBytes_Name(string[] args, byte[]? expected)
    {
        var cli = UtilityCli.CliParser.Parse(args);
        byte[]? actual = cli.GetBytes(Name);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new byte[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, Value1, Value2, MemberType = typeof(TestData))]
    public void GetBytes_Name_ShortName(string[] args, byte[]? expected)
    {
        var cli = Parse(args);
        byte[]? actual = cli.GetBytes(Name, ShortNameInferred);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new byte[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, Value1, Value2, MemberType = typeof(TestData))]
    public void GetBytes_Name_ShortNames(string[] args, byte[]? expected)
    {
        var cli = Parse(args);
        byte[]? actual = cli.GetBytes(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new byte[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new byte[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, Value1, Value2, MemberType = typeof(TestData))]
    public void GetBytes_Name_Aliases(string[] args, byte[]? expected)
    {
        var cli = Parse(args);
        byte[]? actual = cli.GetBytes(Name, [Alias]);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.Option_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Name, ShortNameInferred, ValueString1, new byte[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_SingleValue), Alias, ShortNameInferred, ValueString1, new byte[] { Value1 }, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.Option_MultipleValues), Name, ShortNameInferred, ValueString1, ValueString2, Value1, Value2, MemberType = typeof(TestData))]
    public void GetBytes_Name_Aliases_ShortNames(string[] args, byte[]? expected)
    {
        var cli = Parse(args);
        byte[]? actual = cli.GetBytes(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetBytes_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString1]);
        byte[]? actual = cli.GetBytes(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetBytes_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetBytes(Name));
    }
}
