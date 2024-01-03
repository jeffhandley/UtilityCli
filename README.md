# UtilityCli

## Quickly build utility applications that parse the command-line

UtilityCli is built for simple utility console application scenarios. As a wrapper around System.CommandLine, UtilityCli provides simple APIs for extracting strongly-typed options and arguments from the command line args. UtilityCli does not require the CLI to be defined/modeled up-front. Instead, the model is progressively defined while extracting the option and argument values.

```csharp
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
```

## Approachable, easy, opinionated

Working in happy-path scenarios, UtilityCli allows you to simply call `Parse(args)` in your console application and then extract elements into strongly-typed values. UtilityCli applies some opinionated formatting to your command-line to achieve an easy-to-use API.

* Option names are always prefixed with a double dash; e.g. `--name`
* Option short names must always be single characters, and are recognized with a single dash; e.g. `-n`
* POSIX bundling is always enabled; e.g. `-name` would match options with short names `n`, `a`, `m`, `e` (regardless of order)
* Option names (and short names) are case-sensitive; aliases can be specified with different casing if desired

UtilityCli is not intended for CLI applications that are distributed to other users; it's intended for utility applications you create for yourself or your team. Because UtilityCli does not require the CLI to be modeled up-front, there are functional limitations. Most notably:

* Unmatched options and arguments do not cause parsing to fail
* Options must always be extracted before arguments (to avoid ambiguity)

With a fully-modeled System.CommandLine CLI, there is no ambiguity in terms of how options and arguments are extracted. Using UtilityCli and skipping the step of modeling your CLI can introduce such ambiguities. For utility apps you author for yourself or your team, and even for single-use applications though, this trade-off can save time and frustration.
