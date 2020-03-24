using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmarking
{
    public class IOOperationsBenchmark
    {
        [Benchmark]
        public DriveInfo[] GetDriveInfo() => DriveInfo.GetDrives();

        [Benchmark]
        public long GetDriveInfoAndAvailableFreeSpace() => DriveInfo.GetDrives().First().AvailableFreeSpace;

        [Benchmark]
        public long GetDriveInfoAndTotalFreeSpace() => DriveInfo.GetDrives().First().TotalFreeSpace;
    }
}
