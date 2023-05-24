using System.Diagnostics;
using BenchmarkDotNet.Running;
using SimdTest.Benchmarks;
using SimdTest.Lib;

internal class Program
{
    public static void Main(string[] args)
    {
#if RELEASE
        var summary = BenchmarkRunner.Run<BenchmarkSumVsVectorSum>();
#else
        var random = new Random();

        var arr = new int[random.Next(0, 1000000)];

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = random.Next(1, 10);
        }

        var stopwatch = new Stopwatch();

        var previousElapsed = 0L;

        stopwatch.Start();

        var sum1 = arr.Sum();
        Console.WriteLine(previousElapsed = stopwatch.ElapsedTicks - previousElapsed);
        Console.WriteLine(sum1);

        var sum2 = VectorMath.VectorSum(arr);
        Console.WriteLine(previousElapsed = stopwatch.ElapsedTicks - previousElapsed);
        Console.WriteLine(sum2);

        stopwatch.Stop();
#endif
    }
}