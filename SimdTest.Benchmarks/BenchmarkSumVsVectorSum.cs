using BenchmarkDotNet.Attributes;
using SimdTest.Lib;

namespace SimdTest.Benchmarks;

[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkSumVsVectorSum
{
    [Params(100, 10000, 1000000)] 
    public int N;

    private int[] intArr;
    private long[] longArr;
    private float[] floatArr;
    private double[] doubleArr;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();

        intArr = new int[N];
        longArr = new long[N];
        doubleArr = new double[N];
        floatArr = new float[N];

        for (int i = 0; i < intArr.Length; i++)
        {
            var randNum = random.Next(1, 10);

            intArr[i] = randNum;
            longArr[i] = randNum;
            doubleArr[i] = randNum;
            floatArr[i] = randNum;
        }
    }

    [Benchmark]
    public int IntSum() => intArr.Sum();

    [Benchmark]
    public int IntVectorSum() => VectorMath.VectorSum(intArr);

    [Benchmark]
    public long LongSum() => longArr.Sum();

    [Benchmark]
    public long LongVectorSum() => VectorMath.VectorSum(longArr);

    [Benchmark]
    public double DoubleSum() => doubleArr.Sum();

    [Benchmark]
    public double DoubleVectorSum() => VectorMath.VectorSum(doubleArr);

    [Benchmark]
    public float FloatSum() => floatArr.Sum();

    [Benchmark]
    public float FloatVectorSum() => VectorMath.VectorSum(floatArr);
}