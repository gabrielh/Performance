/*

*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading;

// quick run on windows 10 on the 4 cores machine using .net native!
// single threaded only:                           1 thread   16.207 GB/s    0.46 ns  2175.3 MHz (617...)
// to be compared to  SequentialReads-1:           1 threads  11.025 GB/s    0.68 ns  1479.8 MHz   (907  934.3    960  20.35     10)
// to be compared to  SequentialReadsVectorized-1: 1 threads  14.881 GB/s     0.5 ns  1997.3 MHz   (672  736.4   1052  115.2     10

namespace MemoryReads {
    internal class Program {
        private static void Main(string[] args) {

            //LargeArrayChainedReads(1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            //LargeArrayChainedReads(2, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            //LargeArrayChainedReads(4, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            //LargeArrayRandomReads(1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            //LargeArrayRandomReads(2, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);
            //LargeArrayRandomReads(4, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12);

            LargeArrayChainedReads(1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 16, 18, 20, 24, 28);
            LargeArrayChainedReads(2, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 16, 18, 20, 24, 28);
            LargeArrayChainedReads(4, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 16, 18, 20, 24, 28);
            LargeArrayRandomReads(1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 16, 18, 20, 24, 28);
            LargeArrayRandomReads(2, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 16, 18, 20, 24, 28);
            LargeArrayRandomReads(4, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 16, 18, 20, 24, 28);
            //LargeArraySequentialReads(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 14, 16, 18, 20, 24, 28);
            //LargeArraySequentialReads(1, 2, 5, 10);
            return;

            var maxThreadCount = int.Parse(args[0]);
            RandomReads(maxThreadCount, 1);
            RandomReads(maxThreadCount, 2);
            RandomReads(maxThreadCount, 3);
            RandomReads(maxThreadCount, 4);
            RandomReads(maxThreadCount, 5);
            RandomReads(maxThreadCount, 6);

            return;
            InitializeRandomLongs();


            SequentialReads(maxThreadCount, 1);
            Console.WriteLine("");
            SequentialReadsVectorized(maxThreadCount, 1);
            Console.WriteLine("");
            RandomReads(maxThreadCount,1);
            Console.WriteLine("");

            ChainedReads(maxThreadCount, 1);
            Console.WriteLine("");
            6.ForEach(i => SequentialReads(1, i + 1));
            Console.WriteLine("");
            6.ForEach(i => SequentialReadsVectorized(1, i + 1));
            Console.WriteLine("");
            6.ForEach(i => ChainedReads(1, i + 1));
            Console.WriteLine("");
            Console.WriteLine("");
            ChainedReads(maxThreadCount/2, 1);
            Console.WriteLine("");
            ChainedReads(maxThreadCount/2, 2);
            Console.WriteLine("");
            ChainedReads(maxThreadCount/2, 3);
            Console.WriteLine("");
            ChainedReads(maxThreadCount/2, 4);
            Console.WriteLine("");
            ChainedReads(maxThreadCount/2, 5);
            Console.WriteLine("");
            ChainedReads(maxThreadCount/2, 6);
        }

        // number of longs in a 1GB array of longs
        private static int max = 128*1024*1024;
        private static long iterations = 5;

        // a 1GB array of linked longs, every entry is the index of the next one: index = randomLongs[index]
        // the values are as random as possible so the prefetcher stands no chance of guessing what to prefech
        // only 90% of the array is actually populated
        private static long[] randomLongs;

        // 20 entry points to the randomLongs array, they are all distant of 1'000'000 values
        public static List<long> entryPoints = new List<long>();

        private static void InitializeRandomLongs() {
            randomLongs = new long[max];
            for (int i = 0; i < max; i++) randomLongs[i] = i;//(i+1) & (max-1);
            var rnd = new Random();
            randomLongs.CreateRandomCycle(rnd);

            // some basic checks
            double totalIndex = 0.0;
            double totalIndexSquared = 0.0;
            var index = randomLongs[0];
            double n = 0.0;
            while (index != 0) {
                totalIndex += index;
                totalIndexSquared += index*index;
                index = randomLongs[index];
                n++;
            }
            Console.WriteLine($"count: {n/1024/1024:0.00}  averageIndex: {totalIndex/n/1024/1024:0.00}  standard deviation: {Math.Sqrt(totalIndexSquared/n - totalIndex/n*totalIndex/n)/1024/1024:0.00}");

            long idx = rnd.Next(0, max - 1);
            for (int i = 0; i < 20; i++) {
                entryPoints.Add(idx);
                for (int j = 0; j < 1000*1000; j++) idx = randomLongs[idx];
            }
            Console.WriteLine(entryPoints.Select(i => i.ToString()).JoinWith(","));
        }

        public static void DumpResults(string label, int threadCount, List<double> times, double bandwidth, double access, double rate) {
            Console.WriteLine(label +
                              $"{threadCount} threads  {bandwidth,6:0.###} GB/s  {access,6:0.##} ns  {rate,6:0.#} MHz   ({times.Min():0} {times.Average(),6:0.##} {times.Max(),6:0} {times.StandardDeviation(),6:0.##} {times.Count(),6:0})");
        }

        public static void ChainedReads(int maxThreadCount, int concurrencyLevel) {
            var arrays = maxThreadCount.EnumerateTo().Select(t => new long[max]).ToArray();
            foreach (var array in arrays) randomLongs.CopyTo(array, 0);
            for (int threadCount = 1; threadCount <= maxThreadCount; threadCount += 1) {
                var times = new List<double>();
                long steps = max/8;
                for (int run = 0; run < 10; run++) {
                    var threads = threadCount.EnumerateTo().Select(t => new Thread(() => {
                        switch (concurrencyLevel) {
                            case 1: {
                                    var array = arrays[t];
                                    long index = 0;
                                try {
                                    for (int i = 0; i < steps; i++) index = array[index];
                                }
                                catch {
                                        Console.WriteLine("index:" + index);
                                        Console.WriteLine("max:" + max);
                                    }
                                    //tested as being, in terms of performance equivalent to the following for (int i = 0; i < steps/8; i++) index = array[array[array[array[array[array[array[array[index]]]]]]]];

                                    // the following has no visible effect on performance (well, better not have ;-) )
                                    //total += ((index & 0xFF0000) >> 16) + ((index & 0x00FF00000000) >> 32);

                                    // following code is sufficient to slightly affect execution time 
                                    //var bytes = BitConverter.GetBytes(index);  
                                    //total += bytes[2] + bytes[4];

                                    // following code is sufficient to slightly affect execution time
                                    //total += index;
                                    //totalSquares += index*index;
                                    //totalRoot += Math.Sqrt(index);
                                    //totalLog += Math.Log10(index);

                                    break;
                            }
                            case 2: {
                                var array = arrays[t];
                                long index0 = entryPoints[0];
                                long index1 = entryPoints[1];
                                for (int i = 0; i < steps; i++) {
                                    index0 = array[index0];
                                    index1 = array[index1];
                                }
                                break;
                            }
                            case 3: {
                                var array = arrays[t];
                                long index0 = entryPoints[0];
                                long index1 = entryPoints[1];
                                long index2 = entryPoints[2];
                                for (int i = 0; i < steps; i++) {
                                    index0 = array[index0];
                                    index1 = array[index1];
                                    index2 = array[index2];
                                }
                                break;
                            }
                            case 4: {
                                var array = arrays[t];
                                long index0 = entryPoints[0];
                                long index1 = entryPoints[1];
                                long index2 = entryPoints[2];
                                long index3 = entryPoints[3];
                                for (int i = 0; i < steps; i++) {
                                    index0 = array[index0];
                                    index1 = array[index1];
                                    index2 = array[index2];
                                    index3 = array[index3];
                                }
                                break;
                            }
                            case 5: {
                                var array = arrays[t];
                                long index0 = entryPoints[0];
                                long index1 = entryPoints[1];
                                long index2 = entryPoints[2];
                                long index3 = entryPoints[3];
                                long index4 = entryPoints[4];
                                for (int i = 0; i < steps; i++) {
                                    index0 = array[index0];
                                    index1 = array[index1];
                                    index2 = array[index2];
                                    index3 = array[index3];
                                    index4 = array[index4];
                                }
                                break;
                            }
                            case 6: {
                                var array = arrays[t];
                                long index0 = entryPoints[0];
                                long index1 = entryPoints[1];
                                long index2 = entryPoints[2];
                                long index3 = entryPoints[3];
                                long index4 = entryPoints[4];
                                long index5 = entryPoints[5];
                                for (int i = 0; i < steps; i++) {
                                    index0 = array[index0];
                                    index1 = array[index1];
                                    index2 = array[index2];
                                    index3 = array[index3];
                                    index4 = array[index4];
                                    index5 = array[index5];
                                }
                                break;
                            }
                        }
                    })).ToList();
                    var sw = Stopwatch.StartNew();
                    threads.ForEach(t => t.Start()); 
                    threads.ForEach(t => t.Join());
                    times.Add(sw.ElapsedMilliseconds);
                }
                // steps is the number of iterations in the small loop, so, in the simples case, it is the the number of longs read
                double totalNumberOfLongsRead = steps * (long)threadCount * (long)concurrencyLevel;
                double totalBytesRead = 8*totalNumberOfLongsRead;
                double numberOfLongsReadInOneThread = steps * (long)concurrencyLevel;
                double timeInSeconds = times.Min()/ 1000.0;

                var bandwidth = totalBytesRead/timeInSeconds/ 1024.0 / 1024.0 / 1024.0; // GB/s
                var readsPerSecond = totalNumberOfLongsRead/timeInSeconds/ 1000.0 / 1000.0; // MHz
                var accessTime = timeInSeconds/numberOfLongsReadInOneThread* 1000.0 * 1000.0 * 1000.0; // ns
                DumpResults($"ChainedReads-{concurrencyLevel}: ", threadCount, times, bandwidth, accessTime, readsPerSecond);
            }
        }

        private static void SequentialReads(int maxThreadCount, int arrayCount) {
            var allArrays = maxThreadCount.EnumerateTo().Select(i => arrayCount.EnumerateTo().Select(t => new long[max]).ToArray()).ToArray();
            foreach (var arrays in allArrays) foreach (var array in arrays) for (int i = 0; i < array.Length; i++) array[i] = i;
            for (int threadCount = 1; threadCount <= maxThreadCount; threadCount += 1) {
                long steps = max;
                var times = new List<double>();
                for (int run = 0; run < 10; run++) {
                    var threads = threadCount.EnumerateTo().Select(t => new Thread(() => {
                        for (int iteration = 0; iteration < iterations; iteration++) {
                            long total = 0;
                            var arrays = allArrays[t];
                            switch (arrayCount) {
                                case 1: {
                                    var array0 = arrays[0];
                                    for (int i = 0; i < steps; i++) total += array0[i];
                                    break;
                                }
                                case 2: {
                                    var array0 = arrays[0];
                                    var array1 = arrays[1];
                                    for (int i = 0; i < steps; i++) total += array0[i] + array1[i];
                                    break;
                                }
                                case 3: {
                                    var array0 = arrays[0];
                                    var array1 = arrays[1];
                                    var array2 = arrays[2];
                                    for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i];
                                    break;
                                }
                                case 4: {
                                    var array0 = arrays[0];
                                    var array1 = arrays[1];
                                    var array2 = arrays[2];
                                    var array3 = arrays[3];
                                    for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i] + array3[i];
                                    break;
                                }
                                case 5: {
                                    var array0 = arrays[0];
                                    var array1 = arrays[1];
                                    var array2 = arrays[2];
                                    var array3 = arrays[3];
                                    var array4 = arrays[4];
                                    for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i] + array3[i] + array4[i];
                                    break;
                                }
                                case 6: {
                                    var array0 = arrays[0];
                                    var array1 = arrays[1];
                                    var array2 = arrays[2];
                                    var array3 = arrays[3];
                                    var array4 = arrays[4];
                                    var array5 = arrays[5];
                                    for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i] + array3[i] + array4[i] + array5[i];
                                    break;
                                }
                            }
                        }
                    })).ToList();
                    var sw = Stopwatch.StartNew();
                    threads.ForEach(t => t.Start());
                    threads.ForEach(t => t.Join());
                    times.Add(sw.ElapsedMilliseconds);
                }

                double totalNumberOfLongsRead = iterations * steps * (long)threadCount * (long)arrayCount;
                double totalBytesRead = 8L * totalNumberOfLongsRead;
                double numberOfLongsReadInOneThread = iterations * steps * (long)arrayCount;
                double timeInSeconds = times.Min() / 1000.0;

                var bandwidth = totalBytesRead / timeInSeconds / 1024.0 / 1024.0 / 1024.0; // GB/s
                var readsPerSecond = totalNumberOfLongsRead / timeInSeconds / 1000.0 / 1000.0; // MHz
                var accessTime = timeInSeconds / numberOfLongsReadInOneThread * 1000.0 * 1000.0 * 1000.0; // ns
                DumpResults($"SequentialReads-{arrayCount}: ", threadCount, times, bandwidth, accessTime, readsPerSecond);
            }
        }

        


        private static void RandomReads(int maxThreadCount, int inThreadParallelismLevel) {
            var arrays = maxThreadCount.EnumerateTo().Select(t => new long[max]).ToArray();
            foreach (var array in arrays) for (int i = 0; i < array.Length; i++) array[i] = i;
            for (int threadCount = 1; threadCount <= maxThreadCount; threadCount += 1)
            {
                long steps = max/2;  // reduce the number of reads as this is slower
                long mask = max - 1;
                var times = new List<double>();
                for (int run = 0; run < 10; run++)
                {
                    var threads = threadCount.EnumerateTo().Select(t => new Thread(() => {
                        long total0 = 0;
                        long total1 = 0;
                        long total2 = 0;
                        long total3 = 0;
                        long total4 = 0;
                        long total5 = 0;
                        var array = arrays[t];
                        switch (inThreadParallelismLevel) {
                            case 1: {
                                for (int i = 0; i < steps; i++) {
                                    total0 += array[(11587L*i) & mask]; // is this good enough to outsmart the prefetcher?
                                }
                                break;
                            }
                            case 2: {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(24317L * i) & mask];
                                        total1 += array[(14407L * i) & mask];
                                    }
                                    break;
                            }
                            case 3: {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(24317L * i) & mask];
                                        total1 += array[(14407L * i) & mask];
                                        total2 += array[(11587L * i) & mask];
                                    }
                                    break;
                            }
                            case 4: {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(24317L * i) & mask];
                                        total1 += array[(14407L * i) & mask];
                                        total2 += array[(11587L * i) & mask];
                                        total3 += array[( 9767L * i) & mask];
                                    }
                                    break;
                            }
                            case 5: {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(24317L * i) & mask];
                                        total1 += array[(14407L * i) & mask];
                                        total2 += array[(11587L * i) & mask];
                                        total3 += array[( 9767L * i) & mask];
                                        total4 += array[( 5261L * i) & mask];
                                    }
                                    break;
                            }
                            case 6: {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(24317L*i) & mask];
                                        total1 += array[(14407L*i) & mask];
                                        total2 += array[(11587L*i) & mask];
                                        total3 += array[( 9767L*i) & mask];
                                        total4 += array[( 5261L*i) & mask];
                                        total5 += array[( 1283L*i) & mask];
                                    }
                                    break;
                            }
                        }

                    })).ToList();
                    var sw = Stopwatch.StartNew();
                    threads.ForEach(t => t.Start());
                    threads.ForEach(t => t.Join());
                    times.Add(sw.ElapsedMilliseconds);
                }

                double totalNumberOfLongsRead = steps * (long)threadCount * inThreadParallelismLevel;
                double totalBytesRead = 8 * totalNumberOfLongsRead;
                double numberOfLongsReadInOneThread = steps* inThreadParallelismLevel;
                double timeInSeconds = times.Min() / 1000.0;

                var bandwidth = totalBytesRead / timeInSeconds / 1024.0 / 1024.0 / 1024.0; // GB/s
                var readsPerSecond = totalNumberOfLongsRead / timeInSeconds / 1000.0 / 1000.0; // MHz
                var accessTime = timeInSeconds / numberOfLongsReadInOneThread * 1000.0 * 1000.0 * 1000.0; // ns
                DumpResults($"RandomReads-{inThreadParallelismLevel}:", threadCount, times, bandwidth, accessTime, readsPerSecond);
            }
        }


        private static void SequentialReadsVectorized(int maxThreadCount, int arrayCount)
        {
            var allArrays = maxThreadCount.EnumerateTo().Select(i => arrayCount.EnumerateTo().Select(t => new Vector<long>[max/Vector<long>.Count]).ToArray()).ToArray();
            foreach (var arrays in allArrays) foreach (var array in arrays) for (int i = 0; i < array.Length; i++) array[i] = Vector<long>.One;
            for (int threadCount = 1; threadCount <= maxThreadCount; threadCount += 1)
            {
                long steps = max/Vector<long>.Count;
                var times = new List<double>();
                for (int run = 0; run < 10; run++)
                {
                    var threads = threadCount.EnumerateTo().Select(t => new Thread(() => {
                        for (int iteration = 0; iteration < iterations; iteration++)
                        {

                        var total = Vector<long>.Zero;
                        var arrays = allArrays[t];
                            switch (arrayCount) {
                                case 1: {
                                    var array0 = arrays[0];
                                    for (int i = 0; i < steps; i++) total += array0[i];
                                    break;
                                }
                                case 2: {
                                    var array0 = arrays[0];
                                    var array1 = arrays[1];
                                    for (int i = 0; i < steps; i++) total += array0[i] + array1[i];
                                    break;
                                }
                                case 3: {
                                    var array0 = arrays[0];
                                    var array1 = arrays[1];
                                    var array2 = arrays[2];
                                    for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i];
                                    break;
                                }
                                case 4: {
                                    var array0 = arrays[0];
                                    var array1 = arrays[1];
                                    var array2 = arrays[2];
                                    var array3 = arrays[3];
                                    for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i] + array3[i];
                                    break;
                                }
                                case 5: {
                                    var array0 = arrays[0];
                                    var array1 = arrays[1];
                                    var array2 = arrays[2];
                                    var array3 = arrays[3];
                                    var array4 = arrays[4];
                                    for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i] + array3[i] + array4[i];
                                    break;
                                }
                                case 6: {
                                    var array0 = arrays[0];
                                    var array1 = arrays[1];
                                    var array2 = arrays[2];
                                    var array3 = arrays[3];
                                    var array4 = arrays[4];
                                    var array5 = arrays[5];
                                    for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i] + array3[i] + array4[i] + array5[i];
                                    break;
                                }
                            }
                        }
                    })).ToList();
                    var sw = Stopwatch.StartNew();
                    threads.ForEach(t => t.Start());
                    threads.ForEach(t => t.Join());
                    times.Add(sw.ElapsedMilliseconds);
                }

                double totalNumberOfLongsRead = iterations * steps * (long)Vector<long>.Count * (long)threadCount * (long)arrayCount;
                double totalBytesRead = 8 * totalNumberOfLongsRead;
                double numberOfLongsReadInOneThread = iterations * steps * (long)Vector<long>.Count * (long)arrayCount;
                double timeInSeconds = times.Min() / 1000.0;

                var bandwidth = totalBytesRead / timeInSeconds / 1024.0 / 1024.0 / 1024.0; // GB/s
                var readsPerSecond = totalNumberOfLongsRead / timeInSeconds / 1000.0 / 1000.0; // MHz
                var accessTime = timeInSeconds / numberOfLongsReadInOneThread * 1000.0 * 1000.0 * 1000.0; // ns
                DumpResults($"SequentialReadsVectorized-{arrayCount}: ", threadCount, times, bandwidth, accessTime, readsPerSecond);
            }
        }
        private static void LargeArraySequentialReads(params int[] sizes)
        {
            var arrays = sizes.Max().EnumerateTo().Select(t => new long[max]).ToArray();
            foreach (var array in arrays) for (int i = 0; i < array.Length; i++) array[i] = i;
            foreach (var size in sizes)
            {
                long steps = max;
                var times = new List<double>();
                for (int run = 0; run < 10; run++)
                {
                    var sw = Stopwatch.StartNew();
                    for (int iteration = 0; iteration < iterations; iteration++)
                    {
                        var total = 0L;
                        for (int j = 0; j < size; j++)
                        {
                            var array = arrays[j];
                            for (int i = 0; i < steps; i++)
                            {
                                total += array[i]; // is this good enough to outsmart the prefetcher?
                            }
                        }
                    }
                    times.Add(sw.ElapsedMilliseconds);
                }
                double totalNumberOfLongsRead = steps * size * iterations;
                double totalBytesRead = 8L * totalNumberOfLongsRead;
                double numberOfLongsReadInOneThread = steps * size * iterations;
                double timeInSeconds = times.Min() / 1000.0;

                var bandwidth = totalBytesRead / timeInSeconds / 1024.0 / 1024.0 / 1024.0; // GB/s
                var readsPerSecond = totalNumberOfLongsRead / timeInSeconds / 1000.0 / 1000.0; // MHz
                var accessTime = timeInSeconds / numberOfLongsReadInOneThread * 1000.0 * 1000.0 * 1000.0; // ns
                DumpResults($"SequentialReads on {size} GB: ", 1, times, bandwidth, accessTime, readsPerSecond);
            }
        }


        private static void LargeArrayRandomReads(int inThreadParallelismLevel, params int[] sizes)
        {
            var arrays = sizes.Max().EnumerateTo().Select(t => new long[max]).ToArray();
            foreach (var array in arrays) for (int i = 0; i < array.Length; i++) array[i] = i;
            foreach (var size in sizes)
            {
                long steps = 10 * 25000000 / 4;
                long mask = max - 1;
                var times = new List<double>();
                for (int run = 0; run < 10; run++) {
                    var total0 = 0L;
                    var total1 = 0L;
                    var total2 = 0L;
                    var total3 = 0L;
                    var sw = Stopwatch.StartNew();
                    switch (inThreadParallelismLevel) {
                        case 1: {
                            for (int i = 0; i < steps; i++) {
                                total0 += arrays[i % size][(11587L * i) & mask]; // is this good enough to outsmart the prefetcher?
                            }
                            break;
                        }
                        case 2:
                            {
                                for (int i = 0; i < steps; i++)
                                {
                                    total0 += arrays[i % size][(24317L * i) & mask]; // is this good enough to outsmart the prefetcher?
                                    total1 += arrays[i % size][(14407L * i) & mask]; // is this good enough to outsmart the prefetcher?
                                }
                                break;
                            }
                        case 4:
                            {
                                for (int i = 0; i < steps; i++)
                                {
                                    total0 += arrays[i % size][(24317L * i) & mask]; // is this good enough to outsmart the prefetcher?
                                    total1 += arrays[i % size][(14407L * i) & mask]; // is this good enough to outsmart the prefetcher?
                                    total2 += arrays[i % size][(11587L * i) & mask]; // is this good enough to outsmart the prefetcher?
                                    total3 += arrays[i % size][( 9767L * i) & mask]; // is this good enough to outsmart the prefetcher?
                                }
                                break;
                            }
                    }
                    times.Add(sw.ElapsedMilliseconds);
                }
                double totalNumberOfLongsRead = steps * inThreadParallelismLevel;
                double totalBytesRead = 8L * totalNumberOfLongsRead;
                double numberOfLongsReadInOneThread = steps*inThreadParallelismLevel;
                double timeInSeconds = times.Min() / 1000.0;

                var bandwidth = totalBytesRead / timeInSeconds / 1024.0 / 1024.0 / 1024.0; // GB/s
                var readsPerSecond = totalNumberOfLongsRead / timeInSeconds / 1000.0 / 1000.0; // MHz
                var accessTime = timeInSeconds / numberOfLongsReadInOneThread * 1000.0 * 1000.0 * 1000.0; // ns
                DumpResults($"{inThreadParallelismLevel} - RandomReads on {size} GB: ", 1, times, bandwidth, accessTime, readsPerSecond);
            }
        }

        private static void LargeArrayChainedReads(int inThreadParallelismLevel, params int[] sizes)
        {
            var arrays = sizes.Max().EnumerateTo().Select(t => new long[max]).ToArray();
            foreach (var array in arrays) for (int i = 0; i < array.Length; i++) array[i] = i;
            foreach (var size in sizes)
            {
                long steps = 1 * 25000000;
                long mask = max - 1;
                var times = new List<double>();
                for (int run = 0; run < 10; run++)
                {
                    var next0 = 0L;
                    var next1 = 0L;
                    var next2 = 0L;
                    var next3 = 0L;
                    var sw = Stopwatch.StartNew();
                    switch (inThreadParallelismLevel)
                    {
                        case 1:
                            {
                                for (int i = 0; i < steps; i++)
                                {
                                    next0 = arrays[i % size][(11587L * (i + next0)) & mask]; // is this good enough to outsmart the prefetcher?
                                }
                                break;
                            }
                        case 2:
                            {
                                for (int i = 0; i < steps; i++)
                                {
                                    next0 = arrays[i % size][(11587L * (i + next0)) & mask]; // is this good enough to outsmart the prefetcher?
                                    next1 = arrays[i % size][(14407L * (i + next1)) & mask]; // is this good enough to outsmart the prefetcher?
                                }
                                break;
                            }
                        case 4:
                            {
                                for (int i = 0; i < steps; i++)
                                {
                                    next0 = arrays[i % size][(11587L * (i + next0)) & mask]; // is this good enough to outsmart the prefetcher?
                                    next1 = arrays[i % size][(14407L * (i + next1)) & mask]; // is this good enough to outsmart the prefetcher?
                                    next2 = arrays[i % size][(24317L * (i + next2)) & mask]; // is this good enough to outsmart the prefetcher?
                                    next3 = arrays[i % size][(9767L * (i + next3)) & mask]; // is this good enough to outsmart the prefetcher?
                                }
                                break;
                            }
                    }
                    for (int i = 0; i < steps; i++)
                    {
                        
                    }
                    times.Add(sw.ElapsedMilliseconds);
                }
                double totalNumberOfLongsRead = steps * inThreadParallelismLevel;
                double totalBytesRead = 8L * totalNumberOfLongsRead;
                double numberOfLongsReadInOneThread = steps * inThreadParallelismLevel;
                double timeInSeconds = times.Min() / 1000.0;

                var bandwidth = totalBytesRead / timeInSeconds / 1024.0 / 1024.0 / 1024.0; // GB/s
                var readsPerSecond = totalNumberOfLongsRead / timeInSeconds / 1000.0 / 1000.0; // MHz
                var accessTime = timeInSeconds / numberOfLongsReadInOneThread * 1000.0 * 1000.0 * 1000.0; // ns
                DumpResults($"{inThreadParallelismLevel} - ChainedReads on {size} GB: ", 1, times, bandwidth, accessTime, readsPerSecond);
            }
        }
    }

    public static class Extensions {
        public static void ForEach(this int count, Action<int> action) {
            foreach (var i in count.EnumerateTo()) {
                action(i);
            }
        }

        public static IEnumerable<int> EnumerateTo(this int count) {
            return Enumerable.Range(0, count);
        }

        public static string JoinWith(this IEnumerable<string> strings, string separator) {
            return string.Join(separator, strings);
        }

        // See Sattolo's algorithm at https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        public static void CreateRandomCycle(this long[] array, Random rnd) {
            int n = array.Length;
            while (n > 1) {
                int k = rnd.Next(--n);
                long temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }

        }

        public static double StandardDeviation(this IEnumerable<double> values) {
            var mean = 0.0d;
            var sum = 0.0d;
            var n = 0L;
            foreach (var value in values) {
                n++;
                var difference = value - mean;
                mean += difference/n;
                sum += difference*(value - mean);
            }
            return n > 1 ? Math.Sqrt(sum/(n - 1)) : 0;
        }
    }
}
