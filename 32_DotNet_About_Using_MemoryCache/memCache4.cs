/// <summary>
/// The given callback will be fired after the cache entry is evicted from the cache.
/// </summary>
/// <param name="options">Options of entity</param>
/// <param name="callback">The callback to register for calling after an entry is evicted.</param>
/// <param name="state">The state to pass to the callback.</param>
/// <returns>The <see cref="MemoryCacheEntryOptions"/> so that additional calls can be chained.</returns>
public static MemoryCacheEntryOptions RegisterPostEvictionCallback(
    this MemoryCacheEntryOptions options,
    PostEvictionDelegate callback,
    object state);
    
/// <summary>
/// Signature of the callback which gets called when a cache entry expires.
/// </summary>
/// <param name="key">The key of the entry being evicted.</param>
/// <param name="value">The value of the entry being evicted.</param>
/// <param name="reason">The instance of EvictionReason enum.</param>
/// <param name="state">The information that was passed when registering the callback.</param>
public delegate void PostEvictionDelegate(object key, object value, EvictionReason reason, object state);    