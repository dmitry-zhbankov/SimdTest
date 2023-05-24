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

        Console.WriteLine("Test: VectorSum vs Sum");
        Console.WriteLine($"Array length = {arr.Length}");
        Console.WriteLine();

        var stopwatch = new Stopwatch();
        stopwatch.Start();

        var sum1 = arr.Sum();
        var elapsed1 = stopwatch.ElapsedTicks;

        Console.WriteLine("Sum");
        Console.WriteLine($"Elapsed {elapsed1} ticks");
        Console.WriteLine($"Result = {sum1}");

        Console.WriteLine();
        stopwatch.Restart();

        var sum2 = VectorMath.VectorSum(arr);
        var elapsed2 = stopwatch.ElapsedTicks;

        Console.WriteLine("VectorSum");
        Console.WriteLine($"Elapsed {elapsed2} ticks");
        Console.WriteLine($"Result = {sum2}");

        stopwatch.Stop();
        Console.WriteLine();

        Console.WriteLine($"VectorSum is {((double)elapsed1 - elapsed2) / elapsed2:P} faster than Sum");
#endif
    }
}