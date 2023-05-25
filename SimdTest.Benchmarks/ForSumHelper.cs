namespace SimdTest.Benchmarks;

public class ForSumHelper
{
    public static int ForSum(int[] arr)
    {
        var sum = default(int);

        foreach (var item in arr)
        {
            sum += item;
        }

        return sum;
    }

    public static long ForSum(long[] arr)
    {
        var sum = default(long);

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    public static short ForSum(short[] arr)
    {
        var sum = default(short);

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    public static double ForSum(double[] arr)
    {
        var sum = default(double);

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    public static float ForSum(float[] arr)
    {
        var sum = default(float);

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }
}