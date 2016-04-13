/*
6 cores machine

Single array:

RandomReads-1:1 threads   0.425 GB/s   17.52 ns    57.1 MHz   (4702 4708.3   4713   3.62     10)
RandomReads-1:2 threads   0.835 GB/s   17.85 ns     112 MHz   (4792 4804.6   4809   5.42     10)
RandomReads-1:3 threads   1.244 GB/s   17.97 ns   166.9 MHz   (4825 4830.4   4841   4.55     10)
RandomReads-1:4 threads   1.653 GB/s   18.03 ns   221.9 MHz   (4839 4904.4   5177   98.9     10)
RandomReads-1:5 threads   2.026 GB/s   18.38 ns     272 MHz   (4935 5050.1   5165  69.38     10)
RandomReads-1:6 threads   2.268 GB/s   19.71 ns   304.4 MHz   (5291 5464.4   5694 142.53     10)
RandomReads-1:7 threads   2.217 GB/s   23.53 ns   297.5 MHz   (6316 6705.5   7011 201.84     10)
RandomReads-1:8 threads   2.281 GB/s   26.13 ns   306.2 MHz   (7014 7377.4   7719  205.8     10)
RandomReads-1:9 threads   2.217 GB/s   30.24 ns   297.6 MHz   (8118   8248   8404  90.42     10)
RandomReads-1:10 threads   2.261 GB/s   32.95 ns   303.5 MHz   (8845   9005   9153 109.61     10)
RandomReads-1:11 threads   2.305 GB/s   35.55 ns   309.4 MHz   (9544 9724.3   9864 106.17     10)
RandomReads-1:12 threads   2.327 GB/s   38.42 ns   312.4 MHz   (10312 10534.5  10663 124.82     10)
RandomWrites-1:1 threads   0.415 GB/s   17.94 ns    55.7 MHz   (4815   4832   4854  11.62     10)
RandomWrites-1:2 threads    0.82 GB/s   18.17 ns   110.1 MHz   (4878 4929.5   4961  23.66     10)
RandomWrites-1:3 threads   1.214 GB/s   18.41 ns     163 MHz   (4941 5066.9   5336 131.83     10)
RandomWrites-1:4 threads   1.568 GB/s   19.01 ns   210.5 MHz   (5102 5197.3   5451  103.1     10)
RandomWrites-1:5 threads   1.984 GB/s   18.78 ns   266.3 MHz   (5040 5328.1   5612    155     10)
RandomWrites-1:6 threads   2.167 GB/s   20.63 ns   290.9 MHz   (5537 5909.4   6309 212.84     10)
RandomWrites-1:7 threads    2.06 GB/s   25.32 ns   276.5 MHz   (6796 7113.5   7465 213.21     10)
RandomWrites-1:8 threads    2.05 GB/s   29.08 ns   275.1 MHz   (7805 8048.9   8263  166.2     10)
RandomWrites-1:9 threads   2.071 GB/s   32.37 ns     278 MHz   (8690 8812.6   9054  117.1     10)
RandomWrites-1:10 threads   2.096 GB/s   35.54 ns   281.4 MHz   (9540 9685.5   9788   70.9     10)
RandomWrites-1:11 threads   2.156 GB/s   38.01 ns   289.4 MHz   (10203  10313  10458   86.5     10)
RandomWrites-1:12 threads   2.284 GB/s   39.15 ns   306.5 MHz   (10509 10723.5  10893 118.48     10)



RandomReads-1 1 threads   0.403 GB/s   18.49 ns    54.1 MHz   (1241 1299.4   1417  54.19     10)
RandomReads-1 2 threads    0.83 GB/s   17.96 ns   111.4 MHz   (1205 1313.2   1421   59.1     10)
RandomReads-1 3 threads    1.19 GB/s   18.79 ns   159.7 MHz   (1261 1305.4   1412  52.16     10)
RandomReads-1 4 threads   1.336 GB/s   22.31 ns   179.3 MHz   (1497 1513.2   1562  18.92     10)
RandomReads-1 5 threads   1.272 GB/s    29.3 ns   170.7 MHz   (1966 2026.6   2096  57.36     10)
RandomReads-1 6 threads     1.3 GB/s   34.38 ns   174.5 MHz   (2307 2388.8   2473  58.95     10)
RandomReads-1 7 threads    1.27 GB/s   41.07 ns   170.5 MHz   (2756 2887.3   3159 118.68     10)
RandomReads-1 8 threads   1.301 GB/s   45.82 ns   174.6 MHz   (3075 3239.2   3485 125.71     10)
RandomReads-1 9 threads   1.284 GB/s   52.21 ns   172.4 MHz   (3504 3630.6   3764  86.46     10)
RandomReads-1 10 threads   1.212 GB/s   61.45 ns   162.7 MHz   (4124   4692   5184 398.15     10)
RandomReads-1 11 threads   1.108 GB/s      74 ns   148.7 MHz   (4966 5069.5   5156  62.54     10)
RandomReads-1 12 threads   0.909 GB/s   98.35 ns     122 MHz   (6600 6961.6   7245 198.69     10)
RandomWrites-1 1 threads     0.4 GB/s   18.64 ns    53.6 MHz   (1251 1307.5   1524  84.91     10)
RandomWrites-1 2 threads    0.77 GB/s   19.34 ns   103.4 MHz   (1298 1374.3   1485  56.92     10)
RandomWrites-1 3 threads    0.98 GB/s   22.81 ns   131.5 MHz   (1531 1607.9   1748  88.18     10)
RandomWrites-1 4 threads   0.989 GB/s   30.15 ns   132.7 MHz   (2023 2139.9   2245  73.66     10)
RandomWrites-1 5 threads   1.024 GB/s   36.39 ns   137.4 MHz   (2442 2514.5   2643  58.53     10)
RandomWrites-1 6 threads   1.018 GB/s    43.9 ns   136.7 MHz   (2946   3032   3153  61.73     10)
RandomWrites-1 7 threads   1.043 GB/s   49.99 ns     140 MHz   (3355 3515.6   3657  93.79     10)
RandomWrites-1 8 threads   1.028 GB/s      58 ns   137.9 MHz   (3892 3983.7   4039  46.04     10)
RandomWrites-1 9 threads   1.037 GB/s   64.66 ns   139.2 MHz   (4339 4446.9   4555  72.48     10)
RandomWrites-1 10 threads   1.019 GB/s   73.11 ns   136.8 MHz   (4906 5003.1   5147  76.96     10)
RandomWrites-1 11 threads   1.007 GB/s   81.41 ns   135.1 MHz   (5463 5581.1   5900 130.41     10)
RandomWrites-1 12 threads   0.888 GB/s  100.64 ns   119.2 MHz   (6754 6775.5   6789   8.71     10)


RandomWrites-1:1 threads   0.419 GB/s   17.78 ns    56.3 MHz   (1193 1222.9   1336  46.62     10)
RandomWrites-1:2 threads   0.789 GB/s   18.89 ns   105.8 MHz   (1268 1285.7   1329   19.7     10)
RandomWrites-1:3 threads    0.96 GB/s   23.29 ns   128.8 MHz   (1563 1653.1   1704   46.7     10)
RandomWrites-1:4 threads   1.002 GB/s   29.76 ns   134.4 MHz   (1997 2084.1   2177  57.78     10)
RandomWrites-1:5 threads   1.014 GB/s   36.75 ns   136.1 MHz   (2466 2513.1   2656  58.81     10)
RandomWrites-1:6 threads    1.01 GB/s   44.26 ns   135.6 MHz   (2970 3026.2   3080  37.03     10)
RandomWrites-2:1 threads   0.407 GB/s   18.31 ns    54.6 MHz   (2458   2543   2613  50.48     10)
RandomWrites-2:2 threads   0.682 GB/s   21.85 ns    91.5 MHz   (2933 2984.7   3025   29.3     10)
RandomWrites-2:3 threads   0.842 GB/s   26.54 ns     113 MHz   (3562 3599.6   3714  42.32     10)
RandomWrites-2:4 threads   0.987 GB/s   30.19 ns   132.5 MHz   (4052 4266.3   4464 165.13     10)
RandomWrites-2:5 threads   1.032 GB/s   36.11 ns   138.5 MHz   (4846 4962.7   5110  85.52     10)
RandomWrites-2:6 threads   1.047 GB/s   42.68 ns   140.6 MHz   (5729 5811.2   5922  61.82     10)
RandomWrites-3:1 threads   0.403 GB/s   18.49 ns    54.1 MHz   (3723 3895.1   5330  504.3     10)
RandomWrites-3:2 threads   0.707 GB/s   21.09 ns    94.8 MHz   (4246 4409.7   4562 124.92     10)
RandomWrites-3:3 threads    0.81 GB/s    27.6 ns   108.7 MHz   (5557   5599   5689  38.49     10)
RandomWrites-3:4 threads   0.864 GB/s   34.49 ns     116 MHz   (6944 6984.3   7036  29.11     10)
RandomWrites-3:5 threads   0.896 GB/s   41.56 ns   120.3 MHz   (8367 8456.5   8631  80.24     10)
RandomWrites-3:6 threads   0.934 GB/s   47.84 ns   125.4 MHz   (9631 10012.6  10720 444.07     10)
RandomWrites-4:1 threads   0.409 GB/s   18.24 ns    54.8 MHz   (4895   5093   6566 520.01     10)
RandomWrites-4:2 threads   0.704 GB/s   21.17 ns    94.5 MHz   (5682 5829.7   6306 187.99     10)
RandomWrites-4:3 threads   0.809 GB/s   27.62 ns   108.6 MHz   (7413 7594.8   7892 131.28     10)
RandomWrites-4:4 threads   0.836 GB/s   35.64 ns   112.2 MHz   (9568 9685.5   9991 136.21     10)
RandomWrites-4:5 threads    0.88 GB/s   42.33 ns   118.1 MHz   (11362 11499.4  11923 164.19     10)
RandomWrites-4:6 threads   0.927 GB/s   48.22 ns   124.4 MHz   (12944 13170.2  13533 197.28     10)
RandomWrites-5:1 threads   0.411 GB/s   18.11 ns    55.2 MHz   (6077 6141.2   6458 113.14     10)
RandomWrites-5:2 threads   0.714 GB/s   20.87 ns    95.8 MHz   (7003 7065.8   7192  62.85     10)
RandomWrites-5:3 threads   0.787 GB/s   28.41 ns   105.6 MHz   (9533   9623   9783  74.51     10)
RandomWrites-5:4 threads   0.817 GB/s   36.49 ns   109.6 MHz   (12243 12315.3  12509   81.8     10)
RandomWrites-5:5 threads   0.878 GB/s   42.41 ns   117.9 MHz   (14231  14606  17353 966.94     10)
RandomWrites-5:6 threads   0.938 GB/s   47.64 ns     126 MHz   (15984 16281.9  16767 229.98     10)
RandomWrites-6:1 threads   0.442 GB/s   16.86 ns    59.3 MHz   (6788 6815.5   6842  16.79     10)
RandomWrites-6:2 threads   0.748 GB/s   19.92 ns   100.4 MHz   (8019 8045.8   8121  32.48     10)
RandomWrites-6:3 threads   0.817 GB/s   27.36 ns   109.6 MHz   (11017 11058.3  11101  26.65     10)
RandomWrites-6:4 threads   0.869 GB/s   34.31 ns   116.6 MHz   (13816 13859.3  13908  30.52     10)
RandomWrites-6:5 threads   0.942 GB/s   39.55 ns   126.4 MHz   (15926 16069.4  16241 109.61     10)
RandomWrites-6:6 threads   1.009 GB/s   44.28 ns   135.5 MHz   (17831 18427.1  22336   1376     10)



C:\temp>MemoryWrites.exe
RandomWrites 1 1 threads   0.419 GB/s   17.78 ns    56.3 MHz   (1193 1222.9   1336  46.62     10)
RandomWrites 1 2 threads   0.789 GB/s   18.89 ns   105.8 MHz   (1268 1285.7   1329   19.7     10)
RandomWrites 1 3 threads    0.96 GB/s   23.29 ns   128.8 MHz   (1563 1653.1   1704   46.7     10)
RandomWrites 1 4 threads   1.002 GB/s   29.76 ns   134.4 MHz   (1997 2084.1   2177  57.78     10)
RandomWrites 1 5 threads   1.014 GB/s   36.75 ns   136.1 MHz   (2466 2513.1   2656  58.81     10)
RandomWrites 1 6 threads    1.01 GB/s   44.26 ns   135.6 MHz   (2970 3026.2   3080  37.03     10)
RandomWrites 2 1 threads   0.407 GB/s   18.31 ns    54.6 MHz   (2458   2543   2613  50.48     10)
RandomWrites 2 2 threads   0.682 GB/s   21.85 ns    91.5 MHz   (2933 2984.7   3025   29.3     10)
RandomWrites 2 3 threads   0.842 GB/s   26.54 ns     113 MHz   (3562 3599.6   3714  42.32     10)
RandomWrites 2 4 threads   0.987 GB/s   30.19 ns   132.5 MHz   (4052 4266.3   4464 165.13     10)
RandomWrites 2 5 threads   1.032 GB/s   36.11 ns   138.5 MHz   (4846 4962.7   5110  85.52     10)
RandomWrites 2 6 threads   1.047 GB/s   42.68 ns   140.6 MHz   (5729 5811.2   5922  61.82     10)
RandomWrites 3 1 threads   0.403 GB/s   18.49 ns    54.1 MHz   (3723 3895.1   5330  504.3     10)
RandomWrites 3 2 threads   0.707 GB/s   21.09 ns    94.8 MHz   (4246 4409.7   4562 124.92     10)
RandomWrites 3 3 threads    0.81 GB/s    27.6 ns   108.7 MHz   (5557   5599   5689  38.49     10)
RandomWrites 3 4 threads   0.864 GB/s   34.49 ns     116 MHz   (6944 6984.3   7036  29.11     10)
RandomWrites 3 5 threads   0.896 GB/s   41.56 ns   120.3 MHz   (8367 8456.5   8631  80.24     10)
RandomWrites 3 6 threads   0.934 GB/s   47.84 ns   125.4 MHz   (9631 10012.6  10720 444.07     10)
RandomWrites 4 1 threads   0.409 GB/s   18.24 ns    54.8 MHz   (4895   5093   6566 520.01     10)
RandomWrites 4 2 threads   0.704 GB/s   21.17 ns    94.5 MHz   (5682 5829.7   6306 187.99     10)
RandomWrites 4 3 threads   0.809 GB/s   27.62 ns   108.6 MHz   (7413 7594.8   7892 131.28     10)
RandomWrites 4 4 threads   0.836 GB/s   35.64 ns   112.2 MHz   (9568 9685.5   9991 136.21     10)
RandomWrites 4 5 threads    0.88 GB/s   42.33 ns   118.1 MHz   (11362 11499.4  11923 164.19     10)
RandomWrites 4 6 threads   0.927 GB/s   48.22 ns   124.4 MHz   (12944 13170.2  13533 197.28     10)
RandomWrites 5 1 threads   0.411 GB/s   18.11 ns    55.2 MHz   (6077 6141.2   6458 113.14     10)
RandomWrites 5 2 threads   0.714 GB/s   20.87 ns    95.8 MHz   (7003 7065.8   7192  62.85     10)
RandomWrites 5 3 threads   0.787 GB/s   28.41 ns   105.6 MHz   (9533   9623   9783  74.51     10)
RandomWrites 5 4 threads   0.817 GB/s   36.49 ns   109.6 MHz   (12243 12315.3  12509   81.8     10)
RandomWrites 5 5 threads   0.878 GB/s   42.41 ns   117.9 MHz   (14231  14606  17353 966.94     10)
RandomWrites 5 6 threads   0.938 GB/s   47.64 ns     126 MHz   (15984 16281.9  16767 229.98     10)
RandomWrites 6 1 threads   0.442 GB/s   16.86 ns    59.3 MHz   (6788 6815.5   6842  16.79     10)
RandomWrites 6 2 threads   0.748 GB/s   19.92 ns   100.4 MHz   (8019 8045.8   8121  32.48     10)
RandomWrites 6 3 threads   0.817 GB/s   27.36 ns   109.6 MHz   (11017 11058.3  11101  26.65     10)
RandomWrites 6 4 threads   0.869 GB/s   34.31 ns   116.6 MHz   (13816 13859.3  13908  30.52     10)
RandomWrites 6 5 threads   0.942 GB/s   39.55 ns   126.4 MHz   (15926 16069.4  16241 109.61     10)
RandomWrites 6 6 threads   1.009 GB/s   44.28 ns   135.5 MHz   (17831 18427.1  22336   1376     10)

SequentialWrites 1 1 threads  10.225 GB/s    0.73 ns  1372.4 MHz   (489  492.9    519   9.21     10)
SequentialWrites 1 2 threads  16.474 GB/s     0.9 ns  2211.2 MHz   (607  608.6    619   3.69     10)
SequentialWrites 1 3 threads  19.305 GB/s    1.16 ns  2591.1 MHz   (777  777.8    779   0.63     10)
SequentialWrites 1 4 threads  20.855 GB/s    1.43 ns  2799.1 MHz   (959  962.3    969    3.4     10)
SequentialWrites 1 5 threads  20.886 GB/s    1.78 ns  2803.2 MHz   (1197 1200.9   1209   3.75     10)
SequentialWrites 1 6 threads  20.704 GB/s    2.16 ns  2778.8 MHz   (1449 1478.7   1599  44.65     10)
SequentialWrites 2 1 threads   7.407 GB/s    1.01 ns   994.2 MHz   (1350 2716.6  14900 4280.82     10)
SequentialWrites 2 2 threads  13.889 GB/s    1.07 ns  1864.1 MHz   (1440   2018   6942 1730.55     10)
SequentialWrites 2 3 threads  17.637 GB/s    1.27 ns  2367.2 MHz   (1701 3173.8  16236 4589.67     10)
SequentialWrites 2 4 threads   19.55 GB/s    1.52 ns    2624 MHz   (2046 2615.7   7478 1708.7     10)
SequentialWrites 2 5 threads  19.547 GB/s    1.91 ns  2623.5 MHz   (2558 2831.6   5157 817.23     10)
SequentialWrites 2 6 threads  19.405 GB/s     2.3 ns  2604.5 MHz   (3092 3144.9   3445 107.37     10)
SequentialWrites 3 1 threads   7.415 GB/s       1 ns   995.2 MHz   (2023 2124.7   2858 257.97     10)
SequentialWrites 3 2 threads   13.55 GB/s     1.1 ns  1818.7 MHz   (2214   2292   2707 146.64     10)
SequentialWrites 3 3 threads   17.64 GB/s    1.27 ns  2367.6 MHz   (2551   3727  13986 3604.84     10)
SequentialWrites 3 4 threads  19.157 GB/s    1.56 ns  2571.2 MHz   (3132 4406.9  15335 3840.16     10)
SequentialWrites 4 1 threads   7.479 GB/s       1 ns  1003.9 MHz   (2674 6456.1  40207 11858.89     10)
SequentialWrites 4 2 threads  13.812 GB/s    1.08 ns  1853.8 MHz   (2896 6403.5  37538 10939.74     10)
SequentialWrites 4 3 threads  17.621 GB/s    1.27 ns  2365.1 MHz   (3405 7119.8  35678 10097.76     10)
SequentialWrites 5 1 threads   7.157 GB/s    1.04 ns   960.6 MHz   (3493 3517.9   3568  27.14     10)
SequentialWrites 5 2 threads  13.193 GB/s    1.13 ns  1770.7 MHz   (3790 3826.4   4024  69.82     10)
SequentialWrites 6 1 threads    6.28 GB/s    1.19 ns   842.9 MHz   (4777 4978.4   6224 441.09     10)
SequentialWrites 6 2 threads  11.886 GB/s    1.25 ns  1595.3 MHz   (5048 5105.3   5413 109.02     10)
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;


namespace MemoryWrites {
    internal class Program {
        private static void Main(string[] args) {
            SequentialReads(12, 1);
            SequentialWrites(12, 1);
            //RandomReads(1, 12, 1);
            //RandomWrites(1, 12, 1);

            //RandomWrites(1, 6, 1);
            //RandomWrites(1, 6, 2);
            //RandomWrites(1, 6, 3);
            //RandomWrites(1, 6, 4);
            //RandomWrites(1, 6, 5);
            //RandomWrites(1, 6, 6);
            //RandomReads(1, 6, 1);
            //RandomReads(1, 6, 2);
            //RandomReads(1, 6, 3);
            //RandomReads(1, 6, 4);
            //RandomReads(1, 6, 5);
            //RandomReads(1, 6, 6);

            //Console.WriteLine();
            //SequentialWrites(6, 1);
            //SequentialWrites(6, 2);
            //SequentialWrites(4, 3);
            //SequentialWrites(3, 4);
            //SequentialWrites(2, 5);
            //SequentialWrites(2, 6);
        }

        // number of longs in a 1GB array of longs
        private static int max = 128 * 1024 * 1024;
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
                totalIndexSquared += index * index;
                index = randomLongs[index];
                n++;
            }
            Console.WriteLine($"count: {n / 1024 / 1024:0.00}  averageIndex: {totalIndex / n / 1024 / 1024:0.00}  standard deviation: {Math.Sqrt(totalIndexSquared / n - totalIndex / n * totalIndex / n) / 1024 / 1024:0.00}");

            long idx = rnd.Next(0, max - 1);
            for (int i = 0; i < 20; i++) {
                entryPoints.Add(idx);
                for (int j = 0; j < 1000 * 1000; j++) idx = randomLongs[idx];
            }
            Console.WriteLine(entryPoints.Select(i => i.ToString()).JoinWith(","));
        }

        public static void DumpResults(string label, int threadCount, List<double> times, double bandwidth, double access, double rate) {
            Console.WriteLine(label +
                              $"{threadCount} threads  {bandwidth,6:0.###} GB/s  {access,6:0.##} ns  {rate,6:0.#} MHz   ({times.Min():0} {times.Average(),6:0.##} {times.Max(),6:0} {times.StandardDeviation(),6:0.##} {times.Count(),6:0})");
        }



        private static void SequentialWrites(int maxThreadCount, int inThreadParallelismLevel) {
            var allArrays = maxThreadCount.EnumerateTo().Select(i => inThreadParallelismLevel.EnumerateTo().Select(t => new long[max]).ToArray()).ToArray();
            foreach (var arrays in allArrays) foreach (var array in arrays) for (int i = 0; i < array.Length; i++) array[i] = i;
            for (int threadCount = 1; threadCount <= maxThreadCount; threadCount += 1) {
                long steps = max;
                var times = new List<double>();
                for (int run = 0; run < 10; run++) {
                    var threads = threadCount.EnumerateTo().Select(t => new Thread(() => {
                        for (int iteration = 0; iteration < iterations; iteration++) {
                            long total = 0;
                            var arrays = allArrays[t];
                            switch (inThreadParallelismLevel) {
                                case 1:
                                    {
                                        var array0 = arrays[0];
                                        for (int i = 0; i < steps; i++) array0[i] = i;
                                        break;
                                    }
                                case 2:
                                    {
                                        var array0 = arrays[0];
                                        var array1 = arrays[1];
                                        for (int i = 0; i < steps; i++) { array0[i] = i; array1[i] = i; }
                                        break;
                                    }
                                case 3:
                                    {
                                        var array0 = arrays[0];
                                        var array1 = arrays[1];
                                        var array2 = arrays[2];
                                        for (int i = 0; i < steps; i++) { array0[i] = i; array1[i] = i; array2[i] = i; }
                                        break;
                                    }
                                case 4:
                                    {
                                        var array0 = arrays[0];
                                        var array1 = arrays[1];
                                        var array2 = arrays[2];
                                        var array3 = arrays[3];
                                        for (int i = 0; i < steps; i++) { array0[i] = i; array1[i] = i; array2[i] = i; array3[i] = i; }
                                        break;
                                    }
                                case 5:
                                    {
                                        var array0 = arrays[0];
                                        var array1 = arrays[1];
                                        var array2 = arrays[2];
                                        var array3 = arrays[3];
                                        var array4 = arrays[4];
                                        for (int i = 0; i < steps; i++) { array0[i] = i; array1[i] = i; array2[i] = i; array3[i] = i; array4[i] = i; }
                                        break;
                                    }
                                case 6:
                                    {
                                        var array0 = arrays[0];
                                        var array1 = arrays[1];
                                        var array2 = arrays[2];
                                        var array3 = arrays[3];
                                        var array4 = arrays[4];
                                        var array5 = arrays[5];
                                        for (int i = 0; i < steps; i++) { array0[i] = i; array1[i] = i; array2[i] = i; array3[i] = i; array4[i] = i; array5[i] = i; }
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

                double totalNumberOfLongsRead = iterations * steps * (long)threadCount * (long)inThreadParallelismLevel;
                double totalBytesRead = 8L * totalNumberOfLongsRead;
                double numberOfLongsReadInOneThread = iterations * steps * (long)inThreadParallelismLevel;
                double timeInSeconds = times.Min() / 1000.0;

                var bandwidth = totalBytesRead / timeInSeconds / 1024.0 / 1024.0 / 1024.0; // GB/s
                var readsPerSecond = totalNumberOfLongsRead / timeInSeconds / 1000.0 / 1000.0; // MHz
                var accessTime = timeInSeconds / numberOfLongsReadInOneThread * 1000.0 * 1000.0 * 1000.0; // ns
                DumpResults($"SequentialWrites-{inThreadParallelismLevel}: ", threadCount, times, bandwidth, accessTime, readsPerSecond);
            }
        }




        private static void RandomWrites(int minThreadCount, int maxThreadCount, int inThreadParallelismLevel) {
            var array = new long[max];
            for (int i = 0; i < array.Length; i++) array[i] = i;
            for (int threadCount = minThreadCount; threadCount <= maxThreadCount; threadCount += 1) {
                long steps = 2 * max / inThreadParallelismLevel;  // reduce the number of reads as this is slower
                long mask = max - 1;
                var times = new List<double>();
                for (int run = 0; run < 10; run++) {
                    var threads = threadCount.EnumerateTo().Select(t => new Thread(() => {
                        long total0 = 0;
                        long total1 = 0;
                        long total2 = 0;
                        long total3 = 0;
                        long total4 = 0;
                        long total5 = 0;
                        switch (inThreadParallelismLevel) {
                            case 1:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        array[(11587L * i) & mask] = i;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        array[(24317L * i) & mask] = i;
                                        array[(14407L * i) & mask] = i;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        array[(24317L * i) & mask] = i;
                                        array[(14407L * i) & mask] = i;
                                        array[(11587L * i) & mask] = i;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        array[(24317L * i) & mask] = i;
                                        array[(14407L * i) & mask] = i;
                                        array[(11587L * i) & mask] = i;
                                        array[(9767L * i) & mask] = i;
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        array[(24317L * i) & mask] = i;
                                        array[(14407L * i) & mask] = i;
                                        array[(11587L * i) & mask] = i;
                                        array[(9767L * i) & mask] = i;
                                        array[(5261L * i) & mask] = i;
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        array[(24317L * i) & mask] = i;
                                        array[(14407L * i) & mask] = i;
                                        array[(11587L * i) & mask] = i;
                                        array[(9767L * i) & mask] = i;
                                        array[(5261L * i) & mask] = i;
                                        array[(1283L * i) & mask] = i;
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
                double numberOfLongsReadInOneThread = steps * inThreadParallelismLevel;
                double timeInSeconds = times.Min() / 1000.0;

                var bandwidth = totalBytesRead / timeInSeconds / 1024.0 / 1024.0 / 1024.0; // GB/s
                var readsPerSecond = totalNumberOfLongsRead / timeInSeconds / 1000.0 / 1000.0; // MHz
                var accessTime = timeInSeconds / numberOfLongsReadInOneThread * 1000.0 * 1000.0 * 1000.0; // ns
                DumpResults($"RandomWrites-{inThreadParallelismLevel}:", threadCount, times, bandwidth, accessTime, readsPerSecond);
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
                                case 1:
                                    {
                                        var array0 = arrays[0];
                                        for (int i = 0; i < steps; i++) total += array0[i];
                                        break;
                                    }
                                case 2:
                                    {
                                        var array0 = arrays[0];
                                        var array1 = arrays[1];
                                        for (int i = 0; i < steps; i++) total += array0[i] + array1[i];
                                        break;
                                    }
                                case 3:
                                    {
                                        var array0 = arrays[0];
                                        var array1 = arrays[1];
                                        var array2 = arrays[2];
                                        for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i];
                                        break;
                                    }
                                case 4:
                                    {
                                        var array0 = arrays[0];
                                        var array1 = arrays[1];
                                        var array2 = arrays[2];
                                        var array3 = arrays[3];
                                        for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i] + array3[i];
                                        break;
                                    }
                                case 5:
                                    {
                                        var array0 = arrays[0];
                                        var array1 = arrays[1];
                                        var array2 = arrays[2];
                                        var array3 = arrays[3];
                                        var array4 = arrays[4];
                                        for (int i = 0; i < steps; i++) total += array0[i] + array1[i] + array2[i] + array3[i] + array4[i];
                                        break;
                                    }
                                case 6:
                                    {
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




        private static void RandomReads(int minThreadCount, int maxThreadCount, int inThreadParallelismLevel) {
            var array = new long[max];
            for (int i = 0; i < array.Length; i++) array[i] = i;
            for (int threadCount = minThreadCount; threadCount <= maxThreadCount; threadCount += 1) {
                long steps = 2 * max / inThreadParallelismLevel;  // reduce the number of reads as this is slower
                long mask = max - 1;
                var times = new List<double>();
                for (int run = 0; run < 10; run++) {
                    var threads = threadCount.EnumerateTo().Select(t => new Thread(() => {
                        long total0 = 0;
                        long total1 = 0;
                        long total2 = 0;
                        long total3 = 0;
                        long total4 = 0;
                        long total5 = 0;
                        switch (inThreadParallelismLevel) {
                            case 1:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(11587L * i) & mask]; // is this good enough to outsmart the prefetcher?
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(24317L * i) & mask];
                                        total1 += array[(14407L * i) & mask];
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(24317L * i) & mask];
                                        total1 += array[(14407L * i) & mask];
                                        total2 += array[(11587L * i) & mask];
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(24317L * i) & mask];
                                        total1 += array[(14407L * i) & mask];
                                        total2 += array[(11587L * i) & mask];
                                        total3 += array[(9767L * i) & mask];
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(24317L * i) & mask];
                                        total1 += array[(14407L * i) & mask];
                                        total2 += array[(11587L * i) & mask];
                                        total3 += array[(9767L * i) & mask];
                                        total4 += array[(5261L * i) & mask];
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    for (int i = 0; i < steps; i++) {
                                        total0 += array[(24317L * i) & mask];
                                        total1 += array[(14407L * i) & mask];
                                        total2 += array[(11587L * i) & mask];
                                        total3 += array[(9767L * i) & mask];
                                        total4 += array[(5261L * i) & mask];
                                        total5 += array[(1283L * i) & mask];
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
                double numberOfLongsReadInOneThread = steps * inThreadParallelismLevel;
                double timeInSeconds = times.Min() / 1000.0;

                var bandwidth = totalBytesRead / timeInSeconds / 1024.0 / 1024.0 / 1024.0; // GB/s
                var readsPerSecond = totalNumberOfLongsRead / timeInSeconds / 1000.0 / 1000.0; // MHz
                var accessTime = timeInSeconds / numberOfLongsReadInOneThread * 1000.0 * 1000.0 * 1000.0; // ns
                DumpResults($"RandomReads-{inThreadParallelismLevel}:", threadCount, times, bandwidth, accessTime, readsPerSecond);
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
                mean += difference / n;
                sum += difference * (value - mean);
            }
            return n > 1 ? Math.Sqrt(sum / (n - 1)) : 0;
        }
    }
}
