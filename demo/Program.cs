using UtilityCli;

// --org dotnet --repo runtime --issue 40074 area-System.Security untriaged --dry-run
if (args.Length == 0) args = ["--org", "dotnet", "--repo", "runtime", "--issue", "40074", "area-System.Security", "untriaged", "--dry-run"];

CliParseResult cli = CliArgs.Parse(args);
string org = cli.GetString("org") ?? throw new ArgumentNullException("org");
string repo = cli.GetString("repo") ?? throw new ArgumentNullException("repo"); ;
int? issue = cli.GetInt32("issue");
int? pr = cli.GetInt32("pr");
bool dryRun = cli.HasFlag("dry-run");
string[] labels = cli.GetStrings() ?? [];

if (labels.Length == 0) throw new ArgumentNullException("labels");

if (issue is not null)
{
    Console.WriteLine($"Add labels to {org}/{repo}#{issue} (issue): {string.Join(", ", labels)}");
}
else if (pr is not null)
{
    Console.WriteLine($"Add labels to {org}/{repo}#{issue} (PR): {string.Join(", ", labels)}");
}
else
{
    throw new ArgumentNullException("issue or pr");
}
