using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class StructVsClass
    {
        [Params(128, 256)] 
        public static int Length;

        private PointStruct[] pointStructs;
        private PointClass[] pointClasses;

        [GlobalSetup]
        public void Setup()
        {
            pointStructs = new PointStruct[Length];
            pointClasses = new PointClass[Length];

            for (int i = 0; i < Length; i++)
            {
                pointClasses[i] = new PointClass();
            }
        }

        [Benchmark]
        public void FillStructs()
        {
            for (int i = 0; i < Length; i++)
            {
                pointStructs[i].X = 1;
                pointStructs[i].Y = 1;
            }
        }

        [Benchmark]
        public void FillClasses()
        {
            for (int i = 0; i < Length; i++)
            {
                pointClasses[i].X = 1;
                pointClasses[i].Y = 1;
            }
        }

    }

    struct PointStruct
    {
        public int X;
        public int Y;
    }

    class PointClass
    {
        public int X;
        public int Y;
    }
}
