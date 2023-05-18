public class EntitiesProvider
{
    private readonly IMemoryCache _cache = new MemoryCache(new MemoryCacheOptions
    {
        SizeLimit = 1000, // Cache size in custom units. It can be: amount, bytes, rows, batches etc.
        ExpirationScanFrequency = TimeSpan.FromMinutes(5) // Period for a expiration checking
    });

    private readonly MemoryCacheEntryOptions _entryOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(TimeSpan.FromSeconds(5)) // Entity will be expired, if it didn't request in period more than 5 seconds
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(10)); // In this period entity will be expired

    public Entity GetOrUpdate(int key)
    {
        if (_cache.TryGetValue(key, out Entity result))
            return result;

        Entity newValue = GetDataFromDataProvider(key);
        _cache.Set(key, newValue, _entryOptions.SetSize(1));
        return newValue;
    }

    private Entity GetDataFromDataProvider(int key)
    {
        //...here receive data from data provider
        return new Entity();
    }
}