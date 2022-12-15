var stopwatch = new Stopwatch();
stopwatch.Start();

BenchmarkRunner.Run<TimeBenchmarks>();

// new feature in .net 7
var startTime = Stopwatch.GetTimestamp();
await Task.Delay(1000);
var diff = Stopwatch.GetElapsedTime(startTime); // will calculate automatically the endTime


Console.WriteLine(stopwatch.Elapsed);
