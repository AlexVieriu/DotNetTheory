namespace CodeCop010;

using BenchmarkDotNet.Attributes;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private int[] _array = null!;

    [Params(100, 10_000, 100_000)]
    public int Numbers { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _array = Enumerable.Range(0, Numbers).ToArray();
    }

    [Benchmark]
    public long CountNormalLoop()
    {
        var count = 0L;
        var length = _array.Length;
        for (int i = 0; i < length; i++)
            count += _array[i];

        return count;
    }

    [Benchmark]
    public long CountUnwoundLoop_5()
    {
        var count = 0L;
        var length = _array.Length;

        for (int i = 0; i < length; i += 5)
        {
            count += _array[i];
            count += _array[i + 1];
            count += _array[i + 2];
            count += _array[i + 3];
            count += _array[i + 4];
        }

        return count;
    }
}
