 private readonly MemoryCacheEntryOptions _entryOptions = new MemoryCacheEntryOptions()
        .SetSlidingExpiration(TimeSpan.FromSeconds(3)) 
        .SetAbsoluteExpiration(TimeSpan.FromSeconds(5))
        .RegisterPostEvictionCallback(EvictionCallback); // register callback for eviction
        
public Entity? Get(int key)
{   
    if (_cache.TryGetValue(key, out Entity result))
    {
        return result;
    }

    return null;
}

public Entity Set(int key, Entity value) => _cache.Set(key, value, _entryOptions.SetSize(1));
    
private void EvictionCallback(object key, object value, EvictionReason evictionReason, object state)
{
    // Run when value is removed from a cache
    if (evictionReason == EvictionReason.Replaced)
        return;
    
    try
    {
        _cacheLock.Wait();
        Entity newValue = GetDataFromDataProvider((int)key);
        _cache.Set(key, newValue, _entryOptions.SetSize(1));
    }
    finally
    {
        _cacheLock.Release();
    }
}