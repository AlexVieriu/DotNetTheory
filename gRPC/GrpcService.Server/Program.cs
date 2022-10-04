using GrpcService.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddHttpClient();   

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GrpcService.Server.Services.WeatherService>();
app.MapGrpcService<ChatService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();
