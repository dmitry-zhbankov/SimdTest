# SimdTest
This library implements the array sum using Vector instructions

# Benchmark Results
At commit 39d82a43

// * Summary *

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1702/22H2/2022Update/SunValley2)
AMD Ryzen 9 7950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=7.0.302
[Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


|          Method |       N |             Mean |          Error |         StdDev |           Median | Allocated |
|---------------- |-------- |-----------------:|---------------:|---------------:|-----------------:|----------:|
|      IntLinqSum |     100 |        25.011 ns |      0.0284 ns |      0.0265 ns |        25.019 ns |         - |
|   IntForEachSum |     100 |        23.948 ns |      0.1073 ns |      0.0951 ns |        23.973 ns |         - |
|    IntVectorSum |     100 |        11.415 ns |      0.0032 ns |      0.0030 ns |        11.416 ns |      56 B |
|     LongLinqSum |     100 |        25.119 ns |      0.0287 ns |      0.0254 ns |        25.114 ns |         - |
|      LongForSum |     100 |        24.102 ns |      0.0530 ns |      0.0496 ns |        24.090 ns |         - |
|   LongVectorSum |     100 |        11.079 ns |      0.0036 ns |      0.0032 ns |        11.079 ns |         - |
|     ShortForSum |     100 |        41.893 ns |      0.6975 ns |      0.6524 ns |        42.162 ns |         - |
|  ShortVectorSum |     100 |        11.202 ns |      0.0044 ns |      0.0041 ns |        11.202 ns |      56 B |
|   DoubleLinqSum |     100 |        35.876 ns |      0.5125 ns |      0.4794 ns |        36.056 ns |         - |
|    DoubleForSum |     100 |        34.817 ns |      0.5442 ns |      0.5090 ns |        35.038 ns |         - |
| DoubleVectorSum |     100 |         9.613 ns |      0.0173 ns |      0.0162 ns |         9.614 ns |         - |
|    FloatLinqSum |     100 |       131.636 ns |      0.5523 ns |      0.4896 ns |       131.774 ns |         - |
|     FloatForSum |     100 |        34.978 ns |      0.6821 ns |      0.6381 ns |        35.381 ns |         - |
|  FloatVectorSum |     100 |        12.414 ns |      0.0043 ns |      0.0038 ns |        12.414 ns |      56 B |
|      IntLinqSum |   10000 |     1,854.299 ns |      0.1901 ns |      0.1685 ns |     1,854.331 ns |         - |
|   IntForEachSum |   10000 |     1,846.076 ns |      0.1493 ns |      0.1324 ns |     1,846.084 ns |         - |
|    IntVectorSum |   10000 |       410.410 ns |      0.0394 ns |      0.0329 ns |       410.416 ns |         - |
|     LongLinqSum |   10000 |     1,852.500 ns |      0.1534 ns |      0.1360 ns |     1,852.483 ns |         - |
|      LongForSum |   10000 |     1,843.953 ns |      9.4949 ns |      7.9287 ns |     1,846.112 ns |         - |
|   LongVectorSum |   10000 |       805.172 ns |      0.2513 ns |      0.2098 ns |       805.282 ns |         - |
|     ShortForSum |   10000 |     3,669.932 ns |      0.2876 ns |      0.2549 ns |     3,670.006 ns |         - |
|  ShortVectorSum |   10000 |       208.194 ns |      0.0595 ns |      0.0557 ns |       208.206 ns |         - |
|   DoubleLinqSum |   10000 |     5,463.578 ns |     21.4125 ns |     17.8804 ns |     5,468.348 ns |         - |
|    DoubleForSum |   10000 |     5,464.780 ns |      0.3331 ns |      0.2953 ns |     5,464.673 ns |         - |
| DoubleVectorSum |   10000 |     1,364.487 ns |     28.2192 ns |     25.0156 ns |     1,377.207 ns |         - |
|    FloatLinqSum |   10000 |    11,163.285 ns |     38.4614 ns |     35.9768 ns |    11,172.789 ns |         - |
|     FloatForSum |   10000 |     5,431.682 ns |     80.4713 ns |     75.2729 ns |     5,465.232 ns |         - |
|  FloatVectorSum |   10000 |       686.914 ns |      8.9244 ns |      7.9113 ns |       689.290 ns |         - |
|      IntLinqSum | 1000000 |   182,567.880 ns |  3,065.0153 ns |  2,867.0172 ns |   183,936.707 ns |         - |
|   IntForEachSum | 1000000 |   195,656.365 ns |  1,121.3186 ns |    994.0197 ns |   196,002.942 ns |         - |
|    IntVectorSum | 1000000 |    40,145.021 ns |    302.1615 ns |    282.6421 ns |    40,231.287 ns |         - |
|     LongLinqSum | 1000000 |   184,216.069 ns |     18.9488 ns |     17.7247 ns |   184,221.655 ns |         - |
|      LongForSum | 1000000 |   195,471.070 ns |  2,621.4076 ns |  2,452.0663 ns |   196,466.052 ns |         - |
|   LongVectorSum | 1000000 |    79,165.287 ns |    657.9364 ns |    615.4342 ns |    79,501.843 ns |         - |
|     ShortForSum | 1000000 |   367,393.444 ns |     24.4829 ns |     22.9013 ns |   367,395.801 ns |         - |
|  ShortVectorSum | 1000000 |    19,944.200 ns |    236.3607 ns |    221.0920 ns |    20,070.758 ns |         - |
|   DoubleLinqSum | 1000000 |   547,026.510 ns |  6,358.2592 ns |  5,947.5196 ns |   548,790.625 ns |       1 B |
|    DoubleForSum | 1000000 |   543,403.838 ns | 10,119.4700 ns |  9,465.7586 ns |   548,708.350 ns |       1 B |
| DoubleVectorSum | 1000000 |   136,856.538 ns |  2,449.7942 ns |  2,291.5390 ns |   138,264.136 ns |         - |
|    FloatLinqSum | 1000000 | 1,111,960.326 ns | 11,407.5962 ns | 10,670.6726 ns | 1,116,841.211 ns |       1 B |
|     FloatForSum | 1000000 |   540,082.726 ns | 10,333.5409 ns | 10,611.7857 ns |   548,490.625 ns |       1 B |
|  FloatVectorSum | 1000000 |    68,397.291 ns |  1,264.2209 ns |  1,182.5530 ns |    69,201.538 ns |         - |
