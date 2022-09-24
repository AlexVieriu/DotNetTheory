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
builder.Services.AddHttpClient();

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
