namespace UtilityCliParser.Test;

public class OptionValueTests
{
    [Theory]
    [InlineData(new string[] { }, false)]
    [InlineData(new string[] { "--test" }, true)]
    [InlineData(new string[] { "foo", "bar", "baz" }, false)]
    [InlineData(new string[] { "--foo", "bar", "baz" }, false)]
    [InlineData(new string[] { "--foo", "--bar", "--baz" }, false)]
    [InlineData(new string[] { "foo", "bar", "baz", "--test" }, true)]
    [InlineData(new string[] { "foo", "bar", "baz", "--test", "true" }, true)]
    [InlineData(new string[] { "foo", "bar", "baz", "--test", "false" }, false)]
    [InlineData(new string[] { "--test", "foo", "bar", "baz" }, true)]
    [InlineData(new string[] { "--test", "true", "foo", "bar", "baz" }, true)]
    [InlineData(new string[] { "--test", "false", "foo", "bar", "baz" }, false)]
    [InlineData(new string[] { "foo", "bar", "--test", "baz" }, true)]
    [InlineData(new string[] { "foo", "bar", "--test", "true", "baz" }, true)]
    [InlineData(new string[] { "foo", "bar", "--test", "false", "baz" }, false)]
    public void GetBooleanByName(string[] args, bool expected)
    {
        var cli = UtilityCliParser.CliParser.Parse(args);
        bool actual = cli.GetBoolean("test");

        Assert.Equal(expected, actual);
    }
}