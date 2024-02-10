// ** The Easiest Scheduling for Your .NET Applications ** // 
// https://www.youtube.com/watch?v=73Q5EabiEHM&list=TLPQMTAwMjIwMjT9By1a00n_kw&index=4&ab_channel=NickChapsas

var builder = Host.CreateApplicationBuilder();

builder.Services.AddScheduler();
// builder.Services.AddTransient<MyRepeatableTask>();

var app = builder.Build();

app.Services.UseScheduler(scheduler =>
{
    // scheduler.Schedule(() => WriteLine("This was scheduled"))
    // .EverySeconds(2);

    // scheduler.ScheduleAsync(async () =>
    // {
    //     await Task.Delay(20);
    //     WriteLine("This was scheduled");
    // }).EverySeconds(2);

    // scheduler.Schedule<MyRepeatableTask>()
    // .EveryFiveSeconds();

    scheduler.ScheduleWithParams<MyRepeatableTask>("localhost:5001")
    .EverySeconds(2);
});

app.Run();