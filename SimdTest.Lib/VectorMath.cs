using System.Numerics;

namespace SimdTest.Lib;

public class VectorMath
{
    public static T VectorSum<T>(Span<T> arr) where T : struct
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

        if (remainingLength > 0)
        {
            var remainingSpan = arr.Slice(arrLength - remainingLength);

            var remainingArr = new T[vectorLength];

            remainingSpan.CopyTo(remainingArr);

            var remainingVector = new Vector<T>(remainingArr);

            sumVector += remainingVector;
        }

        var sum = Vector.Dot(sumVector, Vector<T>.One);

        return sum;
    }
}