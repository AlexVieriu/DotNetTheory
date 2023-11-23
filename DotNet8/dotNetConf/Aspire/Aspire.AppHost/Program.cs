var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache2");

var api = builder.AddProject<Projects.WepAPI>("weather");

builder.AddProject<Projects.BlazorServer>("frontend")
    .WithReference(api)
    .WithReference(cache);

builder.Build().Run();
