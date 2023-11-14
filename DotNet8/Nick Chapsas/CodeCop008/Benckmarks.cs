// https://www.youtube.com/watch?v=eqqBzwIIM-4&ab_channel=NickChapsas

using BenchmarkDotNet.Attributes;
using Bogus;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    private readonly List<Person> _people;

    public Benchmarks()
    {
        var faker = new Faker<Person>()
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .UseSeed(1);

        _people = faker.Generate(100);
    }

    [Benchmark]
    public bool Exists_Using_True_1()
    {
        return _people.Count(x => x.Name == "Justin") > 0;
    }

    [Benchmark]
    public bool Exists_Using_Count_True_50()
    {
        return _people.Count(x => x.Name == "Miriam") > 0;
    }

    [Benchmark]
    public bool Exists_Using_Count_True_100()
    {
        return _people.Count(x => x.Name == "Chris") > 0;
    }

    [Benchmark]
    public bool Exists_Using_Any_True_1()
    {
        return _people.Any(x => x.Name == "Miriam");
    }

    [Benchmark]
    public bool Exists_Using_Any_True_50()
    {
        return _people.Any(x => x.Name == "Chris");
    }

    [Benchmark]
    public bool Exists_Using_Any_True_100()
    {
        return _people.Any(x => x.Name == "Justin");
    }

    [Benchmark]
    public bool Exists_Using_Any_False()
    {
        return _people.Any(x => x.Name == "Nick");
    }
}

