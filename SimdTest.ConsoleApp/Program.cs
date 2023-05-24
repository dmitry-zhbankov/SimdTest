using BenchmarkDotNet.Running;
using SimdTest.ConsoleApp;

internal class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<BenchmarkSumVsVectorSum>();
    }
}