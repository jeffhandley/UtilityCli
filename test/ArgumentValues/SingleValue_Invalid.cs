using System.Runtime.InteropServices;
using static UtilityCli.CliParser;
namespace UtilityCli.Test.ArgumentValues;

public class SingleValue_Invalid
{
    [Fact]
    public void GetBoolean_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetBoolean());
    }

    [Fact]
    public void GetByte_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetByte());
    }

    [Fact]
    public void GetChar_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetChar());
    }

    [Fact]
    public void GetDateTime_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDateTime());
    }

    [Fact]
    public void GetDateTimeOffset_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDateTimeOffset());
    }

    [Fact]
    public void GetDecimal_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDecimal());
    }

    [Fact]
    public void GetDouble_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetDouble());
    }

    [Fact]
    public void GetGuid_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetGuid());
    }

    [Fact]
    public void GetInt16_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetInt16());
    }

    [Fact]
    public void GetInt32_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetInt32());
    }

    [Fact]
    public void GetInt64_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetInt64());
    }

    [Fact]
    public void GetSingle_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetSingle());
    }

    [Fact]
    public void GetSByte_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetSByte());
    }

    [Fact]
    public void GetUInt16_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetUInt16());
    }

    [Fact]
    public void GetUInt32_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetUInt32());
    }

    [Fact]
    public void GetUInt64_InvalidValue_Throws()
    {
        var cli = Parse(["invalid"]);
        Assert.Throws<InvalidOperationException>(() => cli.GetUInt64());
    }
}
