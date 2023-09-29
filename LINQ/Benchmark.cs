using BenchmarkDotNet.Attributes;

namespace LINQ
{
    [MemoryDiagnoser]
    public class Benchmark
    {
        [Benchmark]
        public void WithoutToList()
        {
            var range = new RangeEnumerable(10, 200_000_000);

            var a  = range.Skip(100).Take(100);
        }

        [Benchmark]
        public void WithToList()
        {
            var range = new RangeEnumerable(10, 200_000_000);

            var a = range.ToList().Skip(100).Take(100);
        }
    }
}