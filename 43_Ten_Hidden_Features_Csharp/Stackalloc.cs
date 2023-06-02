int* buffer = stackalloc int[values.Length];
    for (int i = 0; i < values.Length; i++)
    {
        buffer[i] = values[i];
    }
    // ...
}