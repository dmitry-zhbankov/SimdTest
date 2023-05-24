using System.Numerics;

namespace SimdTest.Lib;

public class VectorMath
{
    public static int VectorSum(int[] arr)
    {
        var result = VectorSumGeneric<int>(arr);

        var sum = default(int);

        for (var i = 0; i < result.Length; i++)
        {
            sum += result[i];
        }

        return sum;
    }

    public static long VectorSum(long[] arr)
    {
        var result = VectorSumGeneric<long>(arr);

        var sum = default(long);

        for (var i = 0; i < result.Length; i++)
        {
            sum += result[i];
        }

        return sum;
    }

    public static double VectorSum(double[] arr)
    {
        var result = VectorSumGeneric<double>(arr);

        var sum = default(double);

        for (var i = 0; i < result.Length; i++)
        {
            sum += result[i];
        }

        return sum;
    }

    public static float VectorSum(float[] arr)
    {
        var result = VectorSumGeneric<float>(arr);

        var sum = default(float);

        for (var i = 0; i < result.Length; i++)
        {
            sum += result[i];
        }

        return sum;
    }

    private static T[] VectorSumGeneric<T>(Span<T> arr) where T : struct
    {
        var arrLength = arr.Length;

        var vectorLength = Vector<T>.Count;

        var vectorsCount = arrLength / vectorLength;

        var remainingLength = arrLength % vectorLength;

        var sumVector = new Vector<T>();

        for (int i = 0; i < vectorsCount; i++)
        {
            var spanToAdd = arr.Slice(i * vectorLength, vectorLength);

            var vectorToAdd = new Vector<T>(spanToAdd);

            sumVector += vectorToAdd;
        }

        var resultArr = new T[vectorLength + remainingLength];

        sumVector.CopyTo(resultArr);

        var remainingArr = arr.Slice(arrLength - remainingLength).ToArray();

        remainingArr.CopyTo(resultArr, vectorLength);

        return resultArr;
    }
}