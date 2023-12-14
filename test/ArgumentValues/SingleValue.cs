using System.Runtime.InteropServices;
using static UtilityCli.CliArgs;
namespace UtilityCli.Test.ArgumentValues;

public class SingleValue
{
    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "true" }, true)]
    [InlineData(new string[] { "false" }, false)]
    public void GetBoolean(string[] args, bool? expected)
    {
        var cli = Parse(args);
        bool? actual = cli.GetBoolean();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, (byte)2)]
    public void GetByte(string[] args, byte? expected)
    {
        var cli = Parse(args);
        byte? actual = cli.GetByte();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "c" }, 'c')]
    public void GetChar(string[] args, char? expected)
    {
        var cli = Parse(args);
        char? actual = cli.GetChar();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2023-12-12T12:34:56" }, "2023-12-12T12:34:56")]
    public void GetDateTime(string[] args, string? expected)
    {
        var cli = Parse(args);
        DateTime? actual = cli.GetDateTime();

        Assert.Equal(expected is not null && expected is string date ? DateTime.Parse(date) : null, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2023-12-12T12:34:56" }, "2023-12-12T12:34:56")]
    public void GetDateTimeOffset(string[] args, string? expected)
    {
        var cli = Parse(args);
        DateTimeOffset? actual = cli.GetDateTimeOffset();

        Assert.Equal(expected is not null && expected is string date ? DateTimeOffset.Parse(date) : null, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2.0" }, 2.0d)]
    public void GetDecimal(string[] args, double? expected)
    {
        var cli = Parse(args);
        decimal? actual = cli.GetDecimal();

        Assert.Equal(expected is not null ? Convert.ToDecimal(expected) : null, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2.0" }, 2.0d)]
    public void GetDouble(string[] args, double? expected)
    {
        var cli = Parse(args);
        double? actual = cli.GetDouble();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "96500B76-7095-41FB-AA78-06E29E5BC39B" }, "96500B76-7095-41FB-AA78-06E29E5BC39B")]
    public void GetGuid(string[] args, string? expected)
    {
        var cli = Parse(args);
        Guid? actual = cli.GetGuid();

        Assert.Equal(expected is not null && expected is string guid ? Guid.Parse(guid) : null, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, (short)2)]
    public void GetInt16(string[] args, short? expected)
    {
        var cli = Parse(args);
        short? actual = cli.GetInt16();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, 2)]
    public void GetInt32(string[] args, int? expected)
    {
        var cli = Parse(args);
        int? actual = cli.GetInt32();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, (long)2)]
    public void GetInt64(string[] args, long? expected)
    {
        var cli = Parse(args);
        long? actual = cli.GetInt64();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2.0" }, 2.0f)]
    public void GetSingle(string[] args, float? expected)
    {
        var cli = Parse(args);
        float? actual = cli.GetSingle();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, (sbyte)2)]
    public void GetSByte(string[] args, sbyte? expected)
    {
        var cli = Parse(args);
        sbyte? actual = cli.GetSByte();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "value" }, "value")]
    public void GetString(string[] args, string? expected)
    {
        var cli = Parse(args);
        string? actual = cli.GetString();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, (ushort)2)]
    public void GetUInt16(string[] args, ushort? expected)
    {
        var cli = Parse(args);
        ushort? actual = cli.GetUInt16();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, (uint)2)]
    public void GetUInt32(string[] args, uint? expected)
    {
        var cli = Parse(args);
        uint? actual = cli.GetUInt32();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, (ulong)2)]
    public void GetUInt64(string[] args, ulong? expected)
    {
        var cli = Parse(args);
        ulong? actual = cli.GetUInt64();

        Assert.Equal(expected, actual);
    }
}
