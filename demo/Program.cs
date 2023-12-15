if (args.Length == 0) args = ["--org", "dotnet", "--repo", "runtime", "area-System.Security", "untriaged", "--dry-run", "--issue", "40074", "--pr", "40075"];

// --org dotnet --repo runtime area-System.Security untriaged --dry-run --issue 40075 --pr 40075
// -o dotnet -r runtime area-System.Security untriaged --dry-run -i 40075 -p 40075
var cli = UtilityCli.CliArgs.Parse(args);

string org = cli.GetRequiredString("org", aliases: ["owner"]);
string repo = cli.GetRequiredString("repo");
int[] issues = cli.GetInt32s("issue") ?? [];
int[] prs = cli.GetInt32s("pr") ?? [];
bool dryRun = cli.HasFlag("dry-run", shortNames: null);
string[] labels = cli.GetRequiredStrings();

foreach (int issue in issues)
{
    Console.WriteLine($"Add labels to {org}/{repo}#{issue} (issue): {string.Join(", ", labels)}");
}

foreach (int pr in prs)
{
    Console.WriteLine($"Add labels to {org}/{repo}#{pr} (PR): {string.Join(", ", labels)}");
}
