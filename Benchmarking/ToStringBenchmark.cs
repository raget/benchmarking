using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class ToStringBenchmark
    {
        private const int a = 5;
        private const int b = 9;

        [Benchmark]
        public string WithoutToString()
        {
            return $"The sum of {a} and {b} is {a+b}.";

        }

        [Benchmark]
        public string WithToString()
        {
            return $"The sum of {a.ToString()} and {b.ToString()} is {(a + b).ToString()}.";
        }
    }
}
