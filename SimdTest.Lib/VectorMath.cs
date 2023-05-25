using System.Numerics;

namespace SimdTest.Lib;

public class VectorMath
{
    public static int VectorSum(Span<int> arr)
    {
        var result = VectorSumGeneric(arr);

        var sum = ForSumHelper.ForSum(result);

        return sum;
    }

    public static long VectorSum(Span<long> arr)
    {
        var result = VectorSumGeneric(arr);

        var sum = ForSumHelper.ForSum(result);

        return sum;
    }

    public static short VectorSum(Span<short> arr)
    {
        var result = VectorSumGeneric(arr);

        var sum = ForSumHelper.ForSum(result);

        return sum;
    }

    public static double VectorSum(Span<double> arr)
    {
        var result = VectorSumGeneric(arr);

        var sum = ForSumHelper.ForSum(result);

        return sum;
    }

    public static float VectorSum(Span<float> arr)
    {
        var result = VectorSumGeneric(arr);

        var sum = ForSumHelper.ForSum(result);

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