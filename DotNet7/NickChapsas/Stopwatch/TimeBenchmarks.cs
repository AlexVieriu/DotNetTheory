namespace StopwatchExample;

[MemoryDiagnoser(false)]
public class TimeBenchmarks
{
    private static readonly int[] Array = { 10, 5, 20 };

    //[Benchmark]
    public TimeSpan Old()
    {
        return Stopwatch.StartNew().Elapsed;
    }

    //[Benchmark]
    public TimeSpan New()
    {
        return Stopwatch.GetElapsedTime(Stopwatch.GetTimestamp());
    }

    [Benchmark]
    public TimeSpan Old_Loop()
    {
        var sw = Stopwatch.StartNew();
        var length = Array.Length;
        for (int i = 0; i < length; i++)
        {
            DoSomething(i);
        }
        return sw.Elapsed;
    }

    [Benchmark]
    public TimeSpan New_Loop()
    {
        var startTime = Stopwatch.GetTimestamp();
        var length = Array.Length;
        for (int i = 0; i < length; i++)
        {
            DoSomething(i);
        }
        return Stopwatch.GetElapsedTime(startTime);
    } 
    
    private void DoSomething(int val)
    {

    }
}
