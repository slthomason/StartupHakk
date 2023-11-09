//Implementation of Specification Pattern from Microservices example:
using Catalog.Application.Responses;
using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Queries;
public class GetAllProductsQuery : IRequest<Pagination<ProductResponse>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; }
    public GetAllProductsQuery(CatalogSpecParams catalogSpecParams)
    {
        CatalogSpecParams = catalogSpecParams;
    }

    [HttpGet]
    [Route("GetAllProducts")]
    [ProducesResponseType(typeof(IList<ProductResponse>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts([FromQuery]CatalogSpecParams catalogSpecParams)
    {
        try
        {
            var query = new GetAllProductsQuery(catalogSpecParams);
            var result = await _mediator.Send(query);
            _logger.LogInformation("All products retrieved");
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An Exception has occured: {Exception}");
            throw;
        }
    }
}

