// --org dotnet --repo runtime --issue 40074 area-System.Security untriaged --dry-run
if (args.Length == 0) args = ["--org", "dotnet", "--repo", "runtime", "--issue", "40074", "area-System.Security", "untriaged", "--dry-run"];

var cli = UtilityCli.CliArgs.Parse(args);
var org = cli.GetString("org") ?? throw new ArgumentNullException("org");
var repo = cli.GetString("repo") ?? throw new ArgumentNullException("repo"); ;
var issue = cli.GetInt32("issue");
var pr = cli.GetInt32("pr");
var dryrun = cli.GetBoolean("dry-run") ?? false;
var labels = cli.GetStrings() ?? [];

if (labels.Length == 0)
{
    throw new ArgumentNullException("labels");
}

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
