// "Don't Use Loops, They Are Slow! Do This Instead" | Code Cop 10
// https://www.youtube.com/watch?v=tllygkj0czw&list=TLPQMTAwMjIwMjT9By1a00n_kw&index=1&ab_channel=NickChapsas

using BenchmarkDotNet.Running;
using CodeCop010;

BenchmarkRunner.Run<Benchmarks>();