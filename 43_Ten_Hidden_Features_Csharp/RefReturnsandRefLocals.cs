public static ref int Find(int[] values, int target)
{
    for (int i = 0; i < values.Length; i++)
    {
        if (values[i] == target)
        {
            return ref values[i];
        }
    }
    throw new ArgumentException("Value not found.", nameof(target));
}

public static void Main()
{
    int[] values = { 1, 2, 3, 4, 5 };
    ref int value = ref Find(values, 3);
    value = 42;
    Console.WriteLine(values[2]); // output: 42
}