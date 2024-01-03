// --org dotnet --repo runtime area-System.Security untriaged --dry-run --issue 40074 --pr 40075 --verbose --clear
// -o dotnet -r runtime area-System.Security untriaged --dry-run -i 40074 -p 40075 -vc

var cli = UtilityCli.CliArgs.Parse(args);

string org = cli.GetRequiredString("org", aliases: ["owner"]);
string repo = cli.GetRequiredString("repo");
bool clearExistingLabels = cli.HasFlag("clear");

int[] issues = cli.GetInt32s("issue") ?? [];
int[] prs = cli.GetInt32s("pr") ?? [];

bool verboseOutput = cli.HasFlag("verbose");
bool dryRun = cli.HasFlag("dry-run", shortNames: []); // Do not infer a 'd' short name
string[] labels = cli.GetRequiredStrings();

foreach (int issue in issues)
{
    if (verboseOutput)
    {
        if (clearExistingLabels)
        {
            Console.WriteLine($"Clear labels from {org}/{repo}#{issue} (issue)");
        }

        Console.WriteLine($"Add labels to {org}/{repo}#{issue} (issue): {string.Join(", ", labels)}");
    }
}

foreach (int pr in prs)
{
    if (verboseOutput)
    {
        if (clearExistingLabels)
        {
            Console.WriteLine($"Clear labels from {org}/{repo}#{pr} (PR)");
        }

        Console.WriteLine($"Add labels to {org}/{repo}#{pr} (PR): {string.Join(", ", labels)}");
    }
}

if (!verboseOutput)
{
    if (clearExistingLabels)
    {
        Console.WriteLine($"Cleared labels from {org}/{repo} ({issues.Length} issues; {prs.Length} PRs)");
    }

    Console.WriteLine($"Added labels to {org}/{repo} ({issues.Length} issues; {prs.Length} PRs): {string.Join(", ", labels)}");
}
