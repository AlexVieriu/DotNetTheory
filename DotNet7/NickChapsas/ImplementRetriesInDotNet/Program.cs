using ImplementRetriesInDotNet.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IWeatherClient, OpenWeatherClient>();

builder.Services.AddHttpClient(OpenWeatherClient.ClientName,
    client =>
    {
        client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
    });

    //.AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5)));    
    //.AddPolicyHandler(
    //Policy<HttpResponseMessage>
    //        .Handle<HttpRequestException>()
    //        .OrResult(x => x.StatusCode >= HttpStatusCode.InternalServerError ||
    //                       x.StatusCode == HttpStatusCode.RequestTimeout)
    //        .WaitAndRetryAsync(
    //            Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5)
    //    )
    //);

// we can extrac the policy into a variable and use is on each HttpClient if we want to


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
