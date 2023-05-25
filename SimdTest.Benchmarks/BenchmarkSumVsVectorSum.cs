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
    public int IntForEachSum() => ForEachSum(intArr);

    [Benchmark]
    public long LongSum() => longArr.Sum();

    [Benchmark]
    public long LongVectorSum() => VectorMath.VectorSum(longArr);

    [Benchmark]
    public long LongForEachSum() => ForEachSum(longArr);

    [Benchmark]
    public double DoubleSum() => doubleArr.Sum();

    [Benchmark]
    public double DoubleVectorSum() => VectorMath.VectorSum(doubleArr);

    [Benchmark]
    public double DoubleForEachSum() => ForEachSum(doubleArr);

    [Benchmark]
    public float FloatSum() => floatArr.Sum();

    [Benchmark]
    public float FloatVectorSum() => VectorMath.VectorSum(floatArr);

    [Benchmark]
    public float FloatForEachSum() => ForEachSum(floatArr);

    private int ForEachSum(int[] arr)
    {
        var sum = default(int);

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private long ForEachSum(long[] arr)
    {
        var sum = default(long);

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private double ForEachSum(double[] arr)
    {
        var sum = default(double);

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private float ForEachSum(float[] arr)
    {
        var sum = default(float);

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }
}