namespace FastListIteration;

[MemoryDiagnoser(false)] //  Display Garbage Collections per Generation columns (Gen 0, Gen 1, Gen 2). True by default.
public class Benchmarks
{
    private static readonly Random Rng = new Random(80085);

    [Params(100, 10_000, 1_000_000)]
    public int Size { get; set; }

    private List<int> _items;

    [GlobalSetup]
    public void Setup()
    {
        _items = Enumerable.Range(1, Size).Select(x => Rng.Next()).ToList();
    }

    [Benchmark]
    public void For()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            var item = _items[i];
        }
    }

    [Benchmark]
    public void ForEach()
    {
        foreach (var item in _items)
        {

        }
    }

    [Benchmark]
    public void ForEach_Linq()
    {
        _items.ForEach(item => { });
    }

    [Benchmark]
    public void Parallel_ForEach()
    {
        Parallel.ForEach(_items, i => { });
    }

    [Benchmark]
    public void Parallel_Linq()
    {
        _items.AsParallel().ForAll(i => { });
    }
}
