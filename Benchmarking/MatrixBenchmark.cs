using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class MatrixBenchmark
    {
        [Params(20, 10000)]
        public int size;

        [Benchmark]
        public void Fill_i_j()
        {
            var matrix = new int[size,size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = 1;
                }
            }
        }

        [Benchmark]
        public void Fill_j_i()
        {
            var matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[j, i] = 1;
                }
            }
        }
    }
}
