// Create our cache service using the defaults (Dependency injection ready).
// By default it uses a single shared cache under the hood so cache is shared out of the box (but you can configure this)
IAppCache cache = new CachingService();

// Declare (but don't execute) a func/delegate whose result we want to cache
Func<ComplexObjects> complexObjectFactory = () => methodThatTakesTimeOrResources();

// Get our ComplexObjects from the cache, or build them in the factory func 
// and cache the results for next time under the given key
ComplexObjects cachedResults = cache.GetOrAdd("uniqueKey", complexObjectFactory);