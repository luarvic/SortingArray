using BenchmarkDotNet.Attributes;

namespace SortingArray;

[MemoryDiagnoser]
public class SortedArrayBenchmark
{
    [Params(1000, 10000, 100000)]
    public static int Count { get; set; }
    public readonly int[] Numbers =
        Enumerable.Range(1, Count)
            .Select(_ => Random.Shared.Next(1000000)).ToArray();

    [Benchmark]
    public int[] GetSortedArrayWithSpan()
    {
        var span = new Span<int>(Numbers);
        span.Sort();
        return span.ToArray();
    }

    [Benchmark]
    public int[] GetSortedArray()
    {
        Array.Sort(Numbers);
        return Numbers;
    }
}
