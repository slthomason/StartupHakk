Task<byte[]> GetInfoAsync(int id)
{
    var key = id.ToString();
    if (cache.Contains(key))
    {
        var res = cache.Get(key) as Task<byte[]>;
        return res;
    }
    var client = new HttpClient();
    var result = client.GetByteArrayAsync($"https://randomfox.ca/images/{key}.jpg")
        .ContinueWith(t =>
        {
            if(t.Exception != null) 
                throw t.Exception;
            cache.Add(key, t, DateTimeOffset.UtcNow.AddMinutes(2));
            return t.Result;
        });
    return result;
}


async Task<byte[]> GetInfoAsync(int id)
{
    var key = id.ToString();
    if (cache.Contains(key))
    {
        var res = cache.Get(key) as byte[];
        return res;
    }
    var client = new HttpClient();
    byte[] result = await client.GetByteArrayAsync($"https://randomfox.ca/images/{key}.jpg");
    cache.Add(key, result, DateTimeOffset.UtcNow.AddMinutes(2));
    return result;
}


async Task CanBeTrickyAsync()
{
    // which thread execute the first part of the code?
    Thread.Sleep(2000);
    // which thread execute the rest?
}


Task CanBeTrickyDemystifyAsync()
{
    // which thread execute the first part of the code?
    Thread.Sleep(2000);
    // which thread execute the rest?
    return Task.CompletedTask;
}


async Task CanBeTrickyAsync()
{
    // which thread execute the first part of the code?
    await Task.CompletedTask;
    // which thread execute the rest?
}


async Task CanBeTrickyAsync()
{
    // which thread execute the first part of the code?
    await Task.Delay(2000);
    // which thread execute the rest?
}