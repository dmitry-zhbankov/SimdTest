using BenchmarkDotNet.Attributes;
using SimdTest.Lib;

namespace SimdTest.Benchmarks;

[RPlotExporter]
[MemoryDiagnoser]
public class BenchmarkSumVsVectorSum
{
    [Params(100, 10000, 1000000)] public int N;

    private int[] _intArr;
    private long[] _longArr;
    private short[] _shortArr;
    private float[] _floatArr;
    private double[] _doubleArr;

    [GlobalSetup]
    public void Setup()
    {
        var random = new Random();

        _intArr = new int[N];
        _longArr = new long[N];
        _shortArr = new short[N];
        _floatArr = new float[N];
        _doubleArr = new double[N];

        for (int i = 0; i < _intArr.Length; i++)
        {
            var randNum = random.Next(1, 10);

            _intArr[i] = randNum;
            _longArr[i] = randNum;
            _shortArr[i] = (short)randNum;
            _doubleArr[i] = randNum;
            _floatArr[i] = randNum;
        }
    }

    [Benchmark]
    public int IntLinqSum() => _intArr.Sum();

    [Benchmark]
    public int IntForEachSum() => ForSumHelper.ForSum(_intArr);

    [Benchmark]
    public int IntVectorSum() => VectorMath.VectorSum<int>(_intArr);

    [Benchmark]
    public long LongLinqSum() => _longArr.Sum();

    [Benchmark]
    public long LongForSum() => ForSumHelper.ForSum(_longArr);

    [Benchmark]
    public long LongVectorSum() => VectorMath.VectorSum<long>(_longArr);

    [Benchmark]
    public short ShortForSum() => ForSumHelper.ForSum(_shortArr);

    [Benchmark]
    public short ShortVectorSum() => VectorMath.VectorSum<short>(_shortArr);

    [Benchmark]
    public double DoubleLinqSum() => _doubleArr.Sum();

    [Benchmark]
    public double DoubleForSum() => ForSumHelper.ForSum(_doubleArr);

    [Benchmark]
    public double DoubleVectorSum() => VectorMath.VectorSum<double>(_doubleArr);

    [Benchmark]
    public float FloatLinqSum() => _floatArr.Sum();

    [Benchmark]
    public float FloatForSum() => ForSumHelper.ForSum(_floatArr);

    [Benchmark]
    public float FloatVectorSum() => VectorMath.VectorSum<float>(_floatArr);
}