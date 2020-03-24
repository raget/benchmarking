using System;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    [InProcess]
    public class SubBufferBenchmarks
    {
        private byte[] data;

        [Params(256, 65536)]
        public int dataSize;

        public int length = 64;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[dataSize];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] Array() => data.SubArrayCopy(dataSize / 2, length);

        [Benchmark]
        public byte[] BufferBlock() => data.SubArrayBufferBlock(dataSize / 2, length);

        [Benchmark]
        public byte[] Pointers() => data.SubArrayPointers(dataSize / 2, length);

        [Benchmark]
        public byte[] PointersBetter() => data.SubArrayPointersOtimized(dataSize / 2, length);
    }

    public static class ArrayExtensions
    {
        public static byte[] SubArrayCopy(this byte[] buffer, int fromPosition, int length)
        {
            if (length - fromPosition == buffer.Length)
                return buffer;
            var outputBuffer = new byte[length];
            Array.Copy(buffer, fromPosition, outputBuffer, 0, length);
            return outputBuffer;
        }

        public static byte[] SubArrayBufferBlock(this byte[] buffer, int fromPosition, int length)
        {
            if (length - fromPosition == buffer.Length)
                return buffer;
            var outputBuffer = new byte[length];
            Buffer.BlockCopy(buffer, fromPosition, outputBuffer, 0, length);
            return outputBuffer;
        }

        public static unsafe byte[] SubArrayPointers(this byte[] buffer, int fromPosition, int length)
        {
            if (length - fromPosition == buffer.Length)
                return buffer;
            var outputBuffer = new byte[length];

            fixed (byte* destination = &outputBuffer[0])
            {
                fixed (byte* source = &buffer[0])
                {
                    for (int i = 0; i < length; ++i)
                    {
                        destination[i] = source[i + fromPosition];
                    }
                }
            }
            return outputBuffer;
        }

        public static unsafe byte[] SubArrayPointersOtimized(this byte[] source, int fromPosition, int length)
        {
            if (length - fromPosition == source.Length)
                return source;
            var destination = new byte[length];

            fixed (byte* p1 = &destination[0])
            {
                fixed (byte* p2 = &source[fromPosition])
                {
                    long* pDst = (long*) p1;
                    long* pSrc = (long*) p2;
                    int remainder;
                    int iterations = Math.DivRem(length, sizeof(long), out remainder);
                    for (int i = 0; i < iterations; ++i)
                    {
                        *pDst = *pSrc;
                        ++pDst;
                        ++pSrc;
                    }

                    if (remainder > 0)
                    {
                        int endPos = length - remainder;
                        for (int i = 0; i < remainder; ++i)
                        {
                            p1[endPos + i] = p2[endPos + i];
                        }
                    }
                }
            }

            return destination;
        }
    }
}
