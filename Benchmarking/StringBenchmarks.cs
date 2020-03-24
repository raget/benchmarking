using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class StringBenchmarks
    {
        private const string a = "aaaaaaaaaaaaaaaaaaaaaaaa";

        [Params(5, 10, 100, 1000)]
        public int Repetitions;

        [Benchmark]
        public string StringConcatenation()
        {
            var b = "";
            for (var i = 0; i < Repetitions; i++)
            {
                b += a;
            }
            return b;
        }

        [Benchmark]
        public string StringBuilder()
        {
            var result = new StringBuilder("");
            for (var i = 0; i < Repetitions; i++)
            {
                result.Append(a);
            }
            return result.ToString();
        }
    }
}
