private readonly SemaphoreSlim _cacheLock = new SemaphoreSlim(1);
 //...
 
 public async Task<Entity> GetOrUpdate(int key)
 {
   //...Get value part of method
   try
   {
     await _cacheLock.WaitAsync();
     Entity newValue = GetDataFromDataProvider(key);
     _cache.Set(key, newValue, _entryOptions.SetSize(1));
   }
   finally
   {
     _cacheLock.Release();
   }
   //.....
 }