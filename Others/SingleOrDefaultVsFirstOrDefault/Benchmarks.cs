using BenchmarkDotNet.Attributes;

namespace SingleOrDefaultVsFirstOrDefault;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    // will be executed once per execution of the test
    private readonly CustomerService _customerService = new();

    [Params(0,5000,9999)]
    public int Id { get; set; }

    [Benchmark]
    public Customer First_ById()
    {
        return _customerService.GetById_FirstOrDefault(Id)!;
    }

    [Benchmark]
    public Customer Single_ById()
    {
        return _customerService.GetById_SingleOrDefault(Id)!;
    }
}
