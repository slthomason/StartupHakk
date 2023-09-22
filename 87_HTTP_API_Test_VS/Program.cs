using Microsoft.AspNetCore.Mvc;
using RudderStackDemo.Entities;
using RudderStackDemo.Repositories;

namespace RudderStackDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Product List
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ProductListAsync()
        {
            var productList = await _productService.ProductListAsync();
            if (productList != null)
            {
                return Ok(productList);
            }
            else
            {
                return NoContent();
            }
        }

        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductDetailsByIdAsync(int productId)
        {
            var productDetails = await _productService.GetProductDetailByIdAsync(productId);
            if (productDetails != null)
            {
                return Ok(productDetails);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductDetails productDetails)
        {
            var isProductInserted = await _productService.AddProductAsync(productDetails);
            if (isProductInserted)
            {
                return Ok(isProductInserted);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update product details
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(ProductDetails productDetails)
        {
            var isProductUpdated = await _productService.UpdateProductAsync(productDetails);
            if (isProductUpdated)
            {
                return Ok(isProductUpdated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(int productId)
        {
            var isProductDeleted = await _productService.DeleteProductAsync(productId);
            if (isProductDeleted)
            {
                return Ok(isProductDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}