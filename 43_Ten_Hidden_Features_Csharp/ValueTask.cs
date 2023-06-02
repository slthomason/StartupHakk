public static async ValueTask<int> GetAsync()
{
    await Task.Delay(100);
    return 42;
}

public static async Task Main()
{
    int result = await GetAsync();
    Console.WriteLine(result);
}