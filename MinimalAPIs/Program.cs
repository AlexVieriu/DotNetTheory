var builder = WebApplication.CreateBuilder(args);

// Configure Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISql, Sql>();
builder.Services.AddSingleton<IUserData, UserData>();

var app = builder.Build();

// Configure 
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Minimal Apis
app.ConfigureApi();

app.Run();


