using System;
using System.Linq;
using BenchmarkDotNet.Running;

namespace Benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<HashBenchmark>();
            //var summary = BenchmarkRunner.Run<StringBenchmarks>();
            //var summary = BenchmarkRunner.Run<SubBufferBenchmarks>();
            //var summary = BenchmarkRunner.Run<SearchingStringBenchmark>();
            //var summary = BenchmarkRunner.Run<StructVsClass>();
            //var summary = BenchmarkRunner.Run<ToStringBenchmark>();
            //var summary = BenchmarkRunner.Run<MatrixBenchmark>();
            //var summary = BenchmarkRunner.Run<LinqBenchmark>();
            var summary = BenchmarkRunner.Run<InlineningBenchmarks>();
        }
    }
}
