using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class HashBenchmark
    {
        private SHA256 sha256 = SHA256.Create();
        private MD5 md5 = MD5.Create();
        private byte[] data;
        private int dataSize = 5*1024;

        [GlobalSetup]
        public void Setup()
        {
            data = new byte[dataSize];
            new Random(42).NextBytes(data);
        }

        [Benchmark]
        public byte[] ComputeSha256HashFrom5kBData() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] ComputeMd5Hash() => md5.ComputeHash(data);
    }
}
