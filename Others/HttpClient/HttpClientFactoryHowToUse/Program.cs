var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Basic Usage
builder.Services.AddHttpClient();
// Named Client
builder.Services.AddHttpClient("Github", client =>
{
    client.BaseAddress = new Uri("https://api.github.com/");
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");
    client.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "HttpRequestSample");
});
// Typed 
builder.Services.AddHttpClient<GitHubService>();
// General 
builder.Services.AddRefitClient<IGitHubClient>()
    .ConfigureHttpClient(httpClient =>
    {
        httpClient.BaseAddress = new Uri("https://api.github.com/");
        httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/vnd.github.v3+json");
        httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "HttpRequestsSample");
    });

// Outgoing request middleware
builder.Services.AddTransient<ValidateHeaderHandler>();

builder.Services.AddHttpClient("HttpMessageHandler")
    .AddHttpMessageHandler<ValidateHeaderHandler>();

// Multiple Handlers
builder.Services.AddHttpClient<SampleHandler1>();
builder.Services.AddHttpClient<SampleHandler2>();

builder.Services.AddHttpClient("MultipleHttpMessageHandlers")
                .AddHttpMessageHandler<SampleHandler1>()
                .AddHttpMessageHandler<SampleHandler2>();

// Use DI in outgoing request middleware
builder.Services.AddScoped<IOperationScoped, OperationScoped>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
