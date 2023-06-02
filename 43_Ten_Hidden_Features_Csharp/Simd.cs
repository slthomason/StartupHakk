using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

public static float Sum(float[] values)
{
    Vector<float> sum = Vector<float>.Zero;
    int i = 0;
    for (; i <= values.Length - Vector<float>.Count; i += Vector<float>.Count)
    {
        sum += new Vector<float>(values, i);
    }
    float total = Vector.Dot(sum, Vector<float>.One);
    for (; i < values.Length; i++)
    {
        total += values[i];
    }
    return total;
}