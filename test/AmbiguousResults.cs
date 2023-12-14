using static UtilityCli.CliArgs;
namespace UtilityCli.Test;

public class AmbiguousResults
{
    [Fact]
    public void GetOptionAfterArgument_Throws()
    {
        var cli = Parse(["--option", "value", "argument"]);
        var stringArgument = cli.GetString();

        Assert.Throws<InvalidOperationException>(() => cli.GetString("option"));
    }
}
