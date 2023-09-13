using MemoryCacheExample.Entities;

namespace MemoryCacheExample.Services;

public interface IProductService
{
    Task<List<Product>> GetAll(CancellationToken cancellationToken);
}