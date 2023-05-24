# SimdTest
This library implements the array sum using Vector instructions

# Benchmark Results
At commit e0d1cef1

// * Summary *

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1702/22H2/2022Update/SunValley2)
AMD Ryzen 9 7950X, 1 CPU, 32 logical and 16 physical cores
.NET SDK=7.0.302
[Host]     : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
DefaultJob : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2


|          Method |       N |          Mean |        Error |       StdDev |   Gen0 | Allocated |
|---------------- |-------- |--------------:|-------------:|-------------:|-------:|----------:|
|          IntSum |     100 |      24.81 ns |     0.066 ns |     0.055 ns |      - |         - |
|    IntVectorSum |     100 |      16.96 ns |     0.204 ns |     0.191 ns | 0.0067 |     112 B |
|         LongSum |     100 |      24.86 ns |     0.052 ns |     0.046 ns |      - |         - |
|   LongVectorSum |     100 |      15.01 ns |     0.124 ns |     0.116 ns | 0.0033 |      56 B |
|       DoubleSum |     100 |      35.81 ns |     0.104 ns |     0.097 ns |      - |         - |
| DoubleVectorSum |     100 |      15.32 ns |     0.107 ns |     0.101 ns | 0.0033 |      56 B |
|        FloatSum |     100 |     129.77 ns |     0.385 ns |     0.360 ns |      - |         - |
|  FloatVectorSum |     100 |      16.01 ns |     0.107 ns |     0.100 ns | 0.0067 |     112 B |
|          IntSum |   10000 |   1,841.85 ns |     4.032 ns |     3.574 ns |      - |         - |
|    IntVectorSum |   10000 |     476.66 ns |     1.101 ns |     1.029 ns | 0.0033 |      56 B |
|         LongSum |   10000 |   1,843.21 ns |     5.234 ns |     4.640 ns |      - |         - |
|   LongVectorSum |   10000 |     785.78 ns |     9.846 ns |     9.210 ns | 0.0029 |      56 B |
|       DoubleSum |   10000 |   5,442.18 ns |     6.255 ns |     4.884 ns |      - |         - |
| DoubleVectorSum |   10000 |   1,374.69 ns |     3.324 ns |     3.109 ns | 0.0019 |      56 B |
|        FloatSum |   10000 |   9,331.58 ns |    58.706 ns |    54.913 ns |      - |         - |
|  FloatVectorSum |   10000 |     690.30 ns |     1.093 ns |     0.969 ns | 0.0029 |      56 B |
|          IntSum | 1000000 | 182,924.52 ns |   279.276 ns |   261.235 ns |      - |         - |
|    IntVectorSum | 1000000 |  39,416.05 ns |   157.457 ns |   147.286 ns |      - |      56 B |
|         LongSum | 1000000 | 183,283.12 ns |   213.688 ns |   189.429 ns |      - |         - |
|   LongVectorSum | 1000000 |  79,670.77 ns |   454.021 ns |   424.691 ns |      - |      56 B |
|       DoubleSum | 1000000 | 547,470.66 ns | 1,522.464 ns | 1,424.113 ns |      - |       1 B |
| DoubleVectorSum | 1000000 | 137,652.81 ns |   332.680 ns |   294.912 ns |      - |      56 B |
|        FloatSum | 1000000 | 923,752.72 ns | 4,305.093 ns | 3,816.352 ns |      - |       1 B |
|  FloatVectorSum | 1000000 |  68,767.28 ns |   129.528 ns |   114.823 ns |      - |      56 B |
