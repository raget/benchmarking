using BenchmarkDotNet.Running;

namespace Benchmarking
{
    class Program
    {
        // Build the program in the Release mode.
        static void Main()
        {
            BenchmarkRunner.Run<HashBenchmark>();
            // BenchmarkRunner.Run<StringBenchmarks>();
            // BenchmarkRunner.Run<SubBufferBenchmarks>();
            // BenchmarkRunner.Run<SearchingStringBenchmark>();
            // BenchmarkRunner.Run<StructVsClass>();
            // BenchmarkRunner.Run<ToStringBenchmark>();
            // BenchmarkRunner.Run<MatrixBenchmark>();
            // BenchmarkRunner.Run<LinqBenchmark>();
            // BenchmarkRunner.Run<InlineningBenchmarks>();
        }
    }
}
