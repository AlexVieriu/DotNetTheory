// https://www.youtube.com/watch?v=eqqBzwIIM-4&ab_channel=NickChapsas

using BenchmarkDotNet.Running;
using Bogus;

BenchmarkRunner.Run<Benchmarks>();

class Person
{
    public string Name { get; set; }
}