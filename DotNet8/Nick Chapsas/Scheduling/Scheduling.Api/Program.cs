using Coravel;
using Coravel.Mailer.Mail.Interfaces;
using Coravel.Scheduling.Schedule.Interfaces;
using Scheduling.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScheduler();
builder.Services.AddTransient<MyRepeatableTask>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// What is for? ex: to run a migration, to send and email, etc.
// Con: u can't save this times in the DB
app.MapGet("/example", (IScheduler scheduler, IMailer queue) =>
{
    scheduler.Schedule<MyRepeatableTask>()
        .EverySeconds(2);

    // scheduler.Schedule<MyRepeatableTask>()
    //     .Hourly()
    //     .Once()
    //     .Zoned(TimeZoneInfo.Utc);

    return Results.Ok();
})
.WithName("Example")
.WithOpenApi();

app.Run();
