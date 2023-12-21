using Microsoft.Extensions.Configuration;
using Spectre.Console;
using static System.Console;

// order matters
IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .AddCommandLine(args)
    .Build();

// bash
// dotnet run --environment=prod
// environment=qa dotnet run
// environment=qa dotnet run --environment=prod
// greeting=hey dotnet run --environment=prod

var name = "World";

//dotnet run --greeting:color="blue"

//AnsiConsole.MarkupLine($"[{configuration["greeting:color"]}]{configuration["greeting:message"]}, {name}![/]");
WriteLine($"{config["greeting"]}, {name}!");
WriteLine($"Configuration: {config["environment"]}");

