using MemoryCacheExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemoryCacheExample.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _productService.GetAll(cancellationToken);
        return Ok(response);
    }
}