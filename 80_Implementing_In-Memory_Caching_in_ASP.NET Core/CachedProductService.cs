using MemoryCacheExample.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCacheExample.Services;

public class CachedProductService : IProductService
{
    private const string ProductListCacheKey = "ProductList";
    private readonly IMemoryCache _memoryCache;
    private readonly IProductService _productService;

    public CachedProductService(IProductService productService, IMemoryCache memoryCache)
    {
        _productService = productService;
        _memoryCache = memoryCache;
    }

    public async Task<List<Product>> GetAll(CancellationToken cancellationToken)
    {
        var options = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(10))
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

        if (_memoryCache.TryGetValue(ProductListCacheKey, out List<Product> result)) return result;

        result = await _productService.GetAll(cancellationToken);

        _memoryCache.Set(ProductListCacheKey, result, options);

        return result;
    }
}