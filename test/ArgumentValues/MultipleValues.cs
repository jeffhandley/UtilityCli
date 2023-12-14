using System.Runtime.InteropServices;
using static UtilityCli.CliArgs;
namespace UtilityCli.Test.ArgumentValues;

public class MultipleValues
{
    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "true" }, new bool[] { true })]
    [InlineData(new string[] { "true", "false" }, new bool[] { true, false })]
    [InlineData(new string[] { "false", "true" }, new bool[] { false, true })]
    public void GetBooleans(string[] args, bool[]? expected)
    {
        var cli = Parse(args);
        bool[]? actual = cli.GetBooleans();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, new byte[] { 2 })]
    [InlineData(new string[] { "2", "3" }, new byte[] { 2, 3 })]
    [InlineData(new string[] { "2", "3", "4" }, new byte[] { 2, 3, 4 })]
    public void GetBytes(string[] args, byte[]? expected)
    {
        var cli = Parse(args);
        byte[]? actual = cli.GetBytes();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "c" }, new [] { 'c' })]
    [InlineData(new string[] { "c", "d" }, new [] { 'c', 'd' })]
    [InlineData(new string[] { "c", "d", "e" }, new[] { 'c', 'd', 'e' })]
    public void GetChars(string[] args, char[]? expected)
    {
        var cli = Parse(args);
        char[]? actual = cli.GetChars();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2023-12-11" }, new[] { "2023-12-11" })]
    [InlineData(new string[] { "2023-12-11", "2023-12-12" }, new[] { "2023-12-11", "2023-12-12" })]
    [InlineData(new string[] {"2023-12-11", "2023-12-12", "2023-12-13T12:34:56" }, new[] {"2023-12-11", "2023-12-12", "2023-12-13T12:34:56" })]
    public void GetDateTimes(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        DateTime[]? actual = cli.GetDateTimes();

        Assert.Equal(expected?.Select(Convert.ToDateTime)!, actual!);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2023-12-11" }, new[] { "2023-12-11" })]
    [InlineData(new string[] { "2023-12-11", "2023-12-12" }, new[] { "2023-12-11", "2023-12-12" })]
    [InlineData(new string[] { "2023-12-11", "2023-12-12", "2023-12-13T12:34:56" }, new[] { "2023-12-11", "2023-12-12", "2023-12-13T12:34:56" })]
    public void GetDateTimeOffsets(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        DateTimeOffset[]? actual = cli.GetDateTimeOffsets();

        Assert.Equal(expected?.Select(s => new DateTimeOffset(Convert.ToDateTime(s)))!, actual!);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2.1" }, new[] { 2.1d })]
    [InlineData(new string[] { "2.1", "3.2" }, new[] { 2.1d, 3.2d })]
    [InlineData(new string[] { "2.1", "3.2", "4.3" }, new[] { 2.1d, 3.2d, 4.3d })]
    public void GetDecimals(string[] args, double[]? expected)
    {
        var cli = Parse(args);
        decimal[]? actual = cli.GetDecimals();

        Assert.Equal(expected?.Select(Convert.ToDecimal)!, actual!);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2.1" }, new[] { 2.1d })]
    [InlineData(new string[] { "2.1", "3.2" }, new[] { 2.1d, 3.2d })]
    [InlineData(new string[] { "2.1", "3.2", "4.3" }, new[] { 2.1d, 3.2d, 4.3d })]
    public void GetDoubles(string[] args, double[]? expected)
    {
        var cli = Parse(args);
        double[]? actual = cli.GetDoubles();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "D4F230DF-E481-4049-B797-AAD0F7F0B736" }, new[] { "D4F230DF-E481-4049-B797-AAD0F7F0B736" })]
    [InlineData(new string[] { "D4F230DF-E481-4049-B797-AAD0F7F0B736", "E4814049-D4F2-30DF-B797-AAD0F7F0B736" }, new[] { "D4F230DF-E481-4049-B797-AAD0F7F0B736", "E4814049-D4F2-30DF-B797-AAD0F7F0B736" })]
    [InlineData(new string[] { "D4F230DF-E481-4049-B797-AAD0F7F0B736", "E4814049-D4F2-30DF-B797-AAD0F7F0B736", "4049B797-E481-D4F2-30DF-AAD0F7F0B736" }, new[] { "D4F230DF-E481-4049-B797-AAD0F7F0B736", "E4814049-D4F2-30DF-B797-AAD0F7F0B736", "4049B797-E481-D4F2-30DF-AAD0F7F0B736" })]
    public void GetGuids(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        Guid[]? actual = cli.GetGuids();

        Assert.Equal(expected?.Select(Guid.Parse)!, actual!);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, new short[] { 2 })]
    [InlineData(new string[] { "2", "3" }, new short[] { 2, 3 })]
    [InlineData(new string[] { "2", "3", "4" }, new short[] { 2, 3, 4 })]
    public void GetInt16s(string[] args, short[]? expected)
    {
        var cli = Parse(args);
        short[]? actual = cli.GetInt16s();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, new [] { 2 })]
    [InlineData(new string[] { "2", "3" }, new [] { 2, 3 })]
    [InlineData(new string[] { "2", "3", "4" }, new [] { 2, 3, 4 })]
    public void GetInt32s(string[] args, int[]? expected)
    {
        var cli = Parse(args);
        int[]? actual = cli.GetInt32s();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { "2" }, new long[] { 2 })]
    [InlineData(new string[] { "2", "3" }, new long[] { 2, 3 })]
    [InlineData(new string[] { "2", "3", "4" }, new long[] { 2, 3, 4 })]
    public void GetInt64s(string[] args, long[]? expected)
    {
        var cli = Parse(args);
        long[]? actual = cli.GetInt64s();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2.1" }, new[] { 2.1f })]
    [InlineData(new string[] { "2.1", "3.2" }, new[] { 2.1f, 3.2f })]
    [InlineData(new string[] { "2.1", "3.2", "4.3" }, new[] { 2.1f, 3.2f, 4.3f })]
    public void GetSingles(string[] args, float[]? expected)
    {
        var cli = Parse(args);
        float[]? actual = cli.GetSingles();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, new sbyte[] { 2 })]
    [InlineData(new string[] { "2", "3" }, new sbyte[] { 2, 3 })]
    [InlineData(new string[] { "2", "3", "4" }, new sbyte[] { 2, 3, 4 })]
    public void GetSBytes(string[] args, sbyte[]? expected)
    {
        var cli = Parse(args);
        sbyte[]? actual = cli.GetSBytes();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "value1" }, new[] { "value1" })]
    [InlineData(new string[] { "value1", "value2" }, new[] { "value1", "value2" })]
    [InlineData(new string[] { "value1", "value2", "value3" }, new[] { "value1", "value2", "value3" })]
    public void GetString(string[] args, string[]? expected)
    {
        var cli = Parse(args);
        string[]? actual = cli.GetStrings();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, new ushort[] { 2 })]
    [InlineData(new string[] { "2", "3" }, new ushort[] { 2, 3 })]
    [InlineData(new string[] { "2", "3", "4" }, new ushort[] { 2, 3, 4 })]
    public void GetUInt16s(string[] args, ushort[]? expected)
    {
        var cli = Parse(args);
        ushort[]? actual = cli.GetUInt16s();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, new uint[] { 2 })]
    [InlineData(new string[] { "2", "3" }, new uint[] { 2, 3 })]
    [InlineData(new string[] { "2", "3", "4" }, new uint[] { 2, 3, 4 })]
    public void GetUInt32s(string[] args, uint[]? expected)
    {
        var cli = Parse(args);
        uint[]? actual = cli.GetUInt32s();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new string[] { }, null)]
    [InlineData(new string[] { "2" }, new ulong[] { 2 })]
    [InlineData(new string[] { "2", "3" }, new ulong[] { 2, 3 })]
    [InlineData(new string[] { "2", "3", "4" }, new ulong[] { 2, 3, 4 })]
    public void GetUInt64s(string[] args, ulong[]? expected)
    {
        var cli = Parse(args);
        ulong[]? actual = cli.GetUInt64s();

        Assert.Equal(expected, actual);
    }
}
