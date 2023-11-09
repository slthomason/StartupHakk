using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Handlers;
public class GetAllProductsHandler: IRequestHandler<GetAllProductsQuery, Pagination<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<GetAllProductsHandler> _logger;
    public GetAllProductsHandler(IProductRepository productRepository, ILogger<GetAllProductsHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }
    public async Task<Pagination<ProductResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await _productRepository.GetProducts(request.CatalogSpecParams);
        var productResponseList = ProductMapper.Mapper.Map<Pagination<ProductResponse>>(productList);
        _logger.LogDebug("Received Product List.Total Count: {productList}", productResponseList.Count);
        return productResponseList;
    }
    public async Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams)
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Empty;
        if(!string.IsNullOrEmpty(catalogSpecParams.Search))
        {
            var searchFilter = builder.Regex(x => x.Name, new BsonRegularExpression(catalogSpecParams.Search));
            filter &= searchFilter;
        }
        if(!string.IsNullOrEmpty(catalogSpecParams.BrandId))
        {
            var brandFilter = builder.Eq(x => x.Brands.Id,catalogSpecParams.BrandId);
            filter &= brandFilter;
        }
        if(!string.IsNullOrEmpty(catalogSpecParams.TypeId))
        {
            var typeFilter = builder.Eq(x => x.Types.Id, catalogSpecParams.TypeId);
            filter &= typeFilter;
        }
        if (!string.IsNullOrEmpty(catalogSpecParams.Sort))
        {
            return new Pagination<Product>
            {
                PageSize = catalogSpecParams.PageSize,
                PageIndex = catalogSpecParams.PageIndex,
                Data = await DataFilter(catalogSpecParams, filter),
                Count = await _context.Products.CountDocumentsAsync(p =>
                    true) //TODO: Need to check while applying with UI
            };
        }
        return new Pagination<Product>
        {
            PageSize = catalogSpecParams.PageSize,
            PageIndex = catalogSpecParams.PageIndex,
            Data = await _context
                .Products
                .Find(filter)
                .Sort(Builders<Product>.Sort.Ascending("Name"))
                .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
                .Limit(catalogSpecParams.PageSize)
                .ToListAsync(),
            Count = await _context.Products.CountDocumentsAsync(p => true)
        };
    }
    private async Task<IReadOnlyList<Product>> DataFilter(CatalogSpecParams catalogSpecParams, FilterDefinition<Product> filter)
    {
        switch (catalogSpecParams.Sort)
        {
            case "priceAsc":
                return await _context
                    .Products
                    .Find(filter)
                    .Sort(Builders<Product>.Sort.Ascending("Price"))
                    .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
                    .Limit(catalogSpecParams.PageSize)
                    .ToListAsync();
            case "priceDesc":
                return await _context
                    .Products
                    .Find(filter)
                    .Sort(Builders<Product>.Sort.Descending("Price"))
                    .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
                    .Limit(catalogSpecParams.PageSize)
                    .ToListAsync();
            default:
                return await _context
                    .Products
                    .Find(filter)
                    .Sort(Builders<Product>.Sort.Ascending("Name"))
                    .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex - 1))
                    .Limit(catalogSpecParams.PageSize)
                    .ToListAsync();
        }
    }
}