using static UtilityCli.CliArgs;
namespace UtilityCli.Test;

/// <summary>
/// Tests that exercise the sample code shown in the README.
/// </summary>
public class ReadmeSample
{
    [Fact]
    public void ReadmeSample_LongForm()
    {
        // --org dotnet --repo runtime area-System.Security untriaged --dry-run --issue 40074 --pr 40075 --verbose --clear
        var args = new[] { "--org", "dotnet", "--repo", "runtime", "area-System.Security", "untriaged", "--dry-run", "--issue", "40074", "--pr", "40075", "--verbose", "--clear" };
        var cli = Parse(args);

        string org = cli.GetRequiredString("org", aliases: ["owner"]);
        string repo = cli.GetRequiredString("repo");
        bool clearExistingLabels = cli.HasFlag("clear");

        int[] issues = cli.GetInt32s("issue") ?? [];
        int[] prs = cli.GetInt32s("pr") ?? [];

        bool verboseOutput = cli.HasFlag("verbose");
        bool dryRun = cli.HasFlag("dry-run", shortNames: []); // Do not infer a 'd' short name
        string[] labels = cli.GetRequiredStrings();

        Assert.Equal("dotnet", org);
        Assert.Equal("runtime", repo);
        Assert.True(clearExistingLabels);
        Assert.Equal([40074], issues);
        Assert.Equal([40075], prs);
        Assert.True(verboseOutput);
        Assert.True(dryRun);
        Assert.Equal(["area-System.Security", "untriaged"], labels);
    }

    [Fact]
    public void ReadmeSample_ShortForm()
    {
        // -o dotnet -r runtime area-System.Security untriaged --dry-run -i 40074 -p 40075 -vc
        var args = new[] { "-o", "dotnet", "-r", "runtime", "area-System.Security", "untriaged", "--dry-run", "-i", "40074", "-p", "40075", "-vc" };
        var cli = Parse(args);

        string org = cli.GetRequiredString("org", aliases: ["owner"]);
        string repo = cli.GetRequiredString("repo");
        bool clearExistingLabels = cli.HasFlag("clear");

        int[] issues = cli.GetInt32s("issue") ?? [];
        int[] prs = cli.GetInt32s("pr") ?? [];

        bool verboseOutput = cli.HasFlag("verbose");
        bool dryRun = cli.HasFlag("dry-run", shortNames: []); // Do not infer a 'd' short name
        string[] labels = cli.GetRequiredStrings();

        Assert.Equal("dotnet", org);
        Assert.Equal("runtime", repo);
        Assert.True(clearExistingLabels);
        Assert.Equal([40074], issues);
        Assert.Equal([40075], prs);
        Assert.True(verboseOutput);
        Assert.True(dryRun);
        Assert.Equal(["area-System.Security", "untriaged"], labels);
    }

    [Fact]
    public void ReadmeSample_UsingOwnerAlias()
    {
        // Using --owner alias instead of --org
        var args = new[] { "--owner", "dotnet", "--repo", "runtime", "area-System.Security", "--verbose" };
        var cli = Parse(args);

        string org = cli.GetRequiredString("org", aliases: ["owner"]);
        string repo = cli.GetRequiredString("repo");
        bool verboseOutput = cli.HasFlag("verbose");
        string[] labels = cli.GetRequiredStrings();

        Assert.Equal("dotnet", org);
        Assert.Equal("runtime", repo);
        Assert.True(verboseOutput);
        Assert.Equal(["area-System.Security"], labels);
    }

    [Fact]
    public void ReadmeSample_MinimalArgs()
    {
        // Minimal required args only
        var args = new[] { "--org", "dotnet", "--repo", "runtime", "needs-triage" };
        var cli = Parse(args);

        string org = cli.GetRequiredString("org", aliases: ["owner"]);
        string repo = cli.GetRequiredString("repo");
        bool clearExistingLabels = cli.HasFlag("clear");

        int[] issues = cli.GetInt32s("issue") ?? [];
        int[] prs = cli.GetInt32s("pr") ?? [];

        bool verboseOutput = cli.HasFlag("verbose");
        bool dryRun = cli.HasFlag("dry-run", shortNames: []);
        string[] labels = cli.GetRequiredStrings();

        Assert.Equal("dotnet", org);
        Assert.Equal("runtime", repo);
        Assert.False(clearExistingLabels);
        Assert.Empty(issues);
        Assert.Empty(prs);
        Assert.False(verboseOutput);
        Assert.False(dryRun);
        Assert.Equal(["needs-triage"], labels);
    }

    [Fact]
    public void ReadmeSample_MissingRequiredOrg_Throws()
    {
        var args = new[] { "--repo", "runtime", "needs-triage" };
        var cli = Parse(args);

        var ex = Assert.Throws<ArgumentException>(() => cli.GetRequiredString("org", aliases: ["owner"]));
        Assert.Contains("--org", ex.Message);
        Assert.Contains("String", ex.Message);
    }

    [Fact]
    public void ReadmeSample_MissingRequiredLabels_Throws()
    {
        var args = new[] { "--org", "dotnet", "--repo", "runtime" };
        var cli = Parse(args);

        // Extract options first
        cli.GetRequiredString("org", aliases: ["owner"]);
        cli.GetRequiredString("repo");
        cli.HasFlag("clear");
        cli.GetInt32s("issue");
        cli.GetInt32s("pr");
        cli.HasFlag("verbose");
        cli.HasFlag("dry-run", shortNames: []);

        var ex = Assert.Throws<ArgumentException>(() => cli.GetRequiredStrings());
        Assert.Contains("String[]", ex.Message);
    }
}
