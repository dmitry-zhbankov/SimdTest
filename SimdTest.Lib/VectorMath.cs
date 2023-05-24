using System.Numerics;

namespace SimdTest.Lib;

public class VectorMath
{
    public static int VectorSum(int[] arr)
    {
        var result = VectorSumGeneric(arr);

        var sum = default(int);

        for (var i = 0; i < result.Length; i++)
        {
            sum += result[i];
        }

        return sum;
    }

    public static long VectorSum(long[] arr)
    {
        var result = VectorSumGeneric(arr);

        var sum = default(long);

        for (var i = 0; i < result.Length; i++)
        {
            sum += result[i];
        }

        return sum;
    }

    public static double VectorSum(double[] arr)
    {
        var result = VectorSumGeneric(arr);

        var sum = default(double);

        for (var i = 0; i < result.Length; i++)
        {
            sum += result[i];
        }

        return sum;
    }

    public static float VectorSum(float[] arr)
    {
        var result = VectorSumGeneric(arr);

        var sum = default(float);

        for (var i = 0; i < result.Length; i++)
        {
            sum += result[i];
        }

        return sum;
    }

    private static T[] VectorSumGeneric<T>(T[] arr) where T : struct
    {
        var vectorLength = Vector<T>.Count;

        var arrLength = arr.Length;

        var span = new Span<T>(arr);

        var batchCouplesCount = arrLength / (2 * vectorLength);

        var remainingLength = arrLength % (2 * vectorLength);

        var batchLength = batchCouplesCount * vectorLength;

        var batchResultArr = new T[batchLength];

        for (int i = 0; i < batchCouplesCount; i++)
        {
            var batch1 = span.Slice(2 * i * vectorLength, vectorLength);
            var batch2 = span.Slice((2 * i + 1) * vectorLength, vectorLength);

            var vector1 = new Vector<T>(batch1);
            var vector2 = new Vector<T>(batch2);

            var sumVector = vector1 + vector2;

            sumVector.CopyTo(batchResultArr, i * vectorLength);
        }

        var remainingArr = span.Slice(arrLength - remainingLength, remainingLength).ToArray();

        var result = new T[batchLength + remainingLength];

        batchResultArr.CopyTo(result, 0);
        remainingArr.CopyTo(result, batchLength);

        if (result.Length >= vectorLength * 2)
        {
            VectorSumGeneric(result);
        }

        return result;
    }
}