var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<HttpContextMiddleware>();

// Default Http
builder.Services.AddHttpClient();
builder.Services.AddHttpClient("simple", client =>
{
    client.BaseAddress = new Uri("https://localhost:7087");
    client.DefaultRequestHeaders.Add("StartUpHeader", Guid.NewGuid().ToString());
})
.AddHttpMessageHandler<HttpContextMiddleware>(); ;

builder.Services.AddHttpClient<CustomHttpClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7087");
})
.AddHttpMessageHandler<HttpContextMiddleware>()
.SetHandlerLifetime(TimeSpan.FromSeconds(2));


builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
