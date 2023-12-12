using static UtilityCliParser.CliParser;
namespace UtilityCliParser.Test.OptionValues;

public class GetGuid
{
    private const string Name = "datetime";
    private const string Alias = "calendar";

    private const char ShortNameInferred = 'd';
    private const char ShortNameOverride = 'c';

    private const string ValueString = "D4F230DF-E481-4049-B797-AAD0F7F0B736";
    private const string Value = ValueString;

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetGuid_Name(string[] args, object expected)
    {
        var cli = UtilityCliParser.CliParser.Parse(args);
        Guid? actual = cli.GetGuid(Name);

        Assert.Equal(expected is not null && expected is string guid ? Guid.Parse(guid) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetGuid_Name_ShortName(string[] args, object expected)
    {
        var cli = Parse(args);
        Guid? actual = cli.GetGuid(Name, ShortNameInferred);

        Assert.Equal(expected is not null && expected is string guid ? Guid.Parse(guid) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetGuid_Name_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        Guid? actual = cli.GetGuid(Name, shortNames: [ShortNameInferred]);

        Assert.Equal(expected is not null && expected is string guid ? Guid.Parse(guid) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetGuid_Name_Aliases(string[] args, object expected)
    {
        var cli = Parse(args);
        Guid? actual = cli.GetGuid(Name, [Alias]);

        Assert.Equal(expected is not null && expected is string guid ? Guid.Parse(guid) : null, actual);
    }

    [Theory]
    [MemberData(nameof(TestData.GetTestValues_Unspecified), Name, ShortNameInferred, null, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Name, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    [MemberData(nameof(TestData.GetTestValues_Specified), Alias, ShortNameInferred, ValueString, Value, MemberType = typeof(TestData))]
    public void GetGuid_Name_Aliases_ShortNames(string[] args, object expected)
    {
        var cli = Parse(args);
        Guid? actual = cli.GetGuid(Name, [Alias], [ShortNameInferred]);

        Assert.Equal(expected is not null && expected is string guid ? Guid.Parse(guid) : null, actual);
    }

    [Fact]
    public void GetGuid_WithShortNames_DoesNotInferShortName()
    {
        var cli = Parse([$"-{ShortNameInferred}", ValueString]);
        Guid? actual = cli.GetGuid(Name, shortNames: [ShortNameOverride]);

        Assert.Null(actual);
    }

    [Fact]
    public void GetGuid_InvalidValue_Throws()
    {
        var cli = Parse([$"-{ShortNameInferred}", "invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetGuid(Name));
    }
}
