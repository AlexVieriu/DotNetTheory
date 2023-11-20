var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.WepAPI>("backend");
builder.AddProject<Projects.BlazorServer>("frontend")
    .WithReference(api);

builder.Build().Run();
