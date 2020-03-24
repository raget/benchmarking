using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class InlineningBenchmarks
    {
        [Params(100)]
        public int Boundary;

        [Benchmark]
        public void WithInlinening()
        {
            int s = 0;
            for (int i = 0; i < Boundary; i++)
            {
                s += "one".Length + "two".Length + "three".Length +
                     "four".Length + "five".Length + "six".Length +
                     "seven".Length + "eight".Length + "nine".Length +
                     "ten".Length;
            }
        }

        [Benchmark]
        public void WithoutInlinening()
        {
            int s = 0;
            for (int i = 0; i < Boundary; i++)
            {
                s += DoSomething();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int DoSomething()
        {
           return "one".Length + "two".Length + "three".Length +
                  "four".Length + "five".Length + "six".Length +
                  "seven".Length + "eight".Length + "nine".Length +
                  "ten".Length;
        }
    }
}
