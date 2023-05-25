# SimdTest
This library implements the array sum using Vector instructions

# Benchmark Results
At commit a6246359

// * Summary *

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1702/22H2/2022Update/SunValley2)
AMD Ryzen 9 7950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=7.0.302
[Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


|           Method |       N |          Mean |        Error |       StdDev |   Gen0 | Allocated |
|----------------- |-------- |--------------:|-------------:|-------------:|-------:|----------:|
|           IntSum |     100 |      24.82 ns |     0.048 ns |     0.043 ns |      - |         - |
|     IntVectorSum |     100 |      16.75 ns |     0.154 ns |     0.144 ns | 0.0067 |     112 B |
|    IntForEachSum |     100 |      24.17 ns |     0.051 ns |     0.048 ns |      - |         - |
|          LongSum |     100 |      24.90 ns |     0.038 ns |     0.034 ns |      - |         - |
|    LongVectorSum |     100 |      15.00 ns |     0.149 ns |     0.132 ns | 0.0033 |      56 B |
|   LongForEachSum |     100 |      24.03 ns |     0.017 ns |     0.015 ns |      - |         - |
|        DoubleSum |     100 |      35.78 ns |     0.058 ns |     0.055 ns |      - |         - |
|  DoubleVectorSum |     100 |      15.33 ns |     0.124 ns |     0.116 ns | 0.0033 |      56 B |
| DoubleForEachSum |     100 |      34.72 ns |     0.040 ns |     0.036 ns |      - |         - |
|         FloatSum |     100 |     129.73 ns |     0.178 ns |     0.166 ns |      - |         - |
|   FloatVectorSum |     100 |      15.77 ns |     0.147 ns |     0.138 ns | 0.0067 |     112 B |
|  FloatForEachSum |     100 |      33.75 ns |     0.093 ns |     0.072 ns |      - |         - |
|           IntSum |   10000 |   1,789.46 ns |     4.411 ns |     3.910 ns |      - |         - |
|     IntVectorSum |   10000 |     402.27 ns |     5.489 ns |     5.134 ns | 0.0033 |      56 B |
|    IntForEachSum |   10000 |   1,783.90 ns |     4.578 ns |     4.059 ns |      - |         - |
|          LongSum |   10000 |   1,789.11 ns |     2.405 ns |     2.009 ns |      - |         - |
|    LongVectorSum |   10000 |     798.03 ns |     4.590 ns |     4.293 ns | 0.0029 |      56 B |
|   LongForEachSum |   10000 |   1,784.69 ns |     6.935 ns |     6.148 ns |      - |         - |
|        DoubleSum |   10000 |   5,295.71 ns |    13.137 ns |    12.289 ns |      - |         - |
|  DoubleVectorSum |   10000 |   1,339.72 ns |     5.422 ns |     5.072 ns | 0.0019 |      56 B |
| DoubleForEachSum |   10000 |   5,291.34 ns |    14.052 ns |    12.457 ns |      - |         - |
|         FloatSum |   10000 |   9,176.17 ns |    17.645 ns |    16.506 ns |      - |         - |
|   FloatVectorSum |   10000 |     671.81 ns |     1.674 ns |     1.484 ns | 0.0029 |      56 B |
|  FloatForEachSum |   10000 |   5,303.34 ns |    35.350 ns |    33.067 ns |      - |         - |
|           IntSum | 1000000 | 177,794.16 ns |   267.445 ns |   223.329 ns |      - |         - |
|     IntVectorSum | 1000000 |  39,320.11 ns |   117.062 ns |   109.500 ns |      - |      56 B |
|    IntForEachSum | 1000000 | 189,352.79 ns |   529.663 ns |   469.532 ns |      - |         - |
|          LongSum | 1000000 | 179,958.05 ns | 1,091.638 ns | 1,021.119 ns |      - |         - |
|    LongVectorSum | 1000000 |  79,094.95 ns |   246.523 ns |   230.597 ns |      - |      56 B |
|   LongForEachSum | 1000000 | 190,350.92 ns |   682.608 ns |   638.512 ns |      - |         - |
|        DoubleSum | 1000000 | 531,049.93 ns | 1,742.722 ns | 1,630.143 ns |      - |       1 B |
|  DoubleVectorSum | 1000000 | 135,128.30 ns |   829.767 ns |   776.165 ns |      - |      56 B |
| DoubleForEachSum | 1000000 | 531,646.48 ns | 2,076.189 ns | 1,942.068 ns |      - |       1 B |
|         FloatSum | 1000000 | 916,899.86 ns | 1,704.806 ns | 1,511.266 ns |      - |       1 B |
|   FloatVectorSum | 1000000 |  67,212.79 ns |   411.681 ns |   343.772 ns |      - |      56 B |
|  FloatForEachSum | 1000000 | 537,318.76 ns | 4,215.700 ns | 3,943.368 ns |      - |       1 B |
