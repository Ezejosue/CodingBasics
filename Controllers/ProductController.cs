using CodingBasics.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingBasics.Services;

/// <summary>
/// Controller for handling product-related requests.
/// </summary>
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductController"/> class.
    /// </summary>
    /// <param name="productService">The service for managing product data.</param>
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Gets a paginated list of products.
    /// </summary>
    /// <param name="pageNumber">The current page number for pagination.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <returns>A list of products in the specified page range.</returns>
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductsAsync(int pageNumber, int pageSize)
    {
        try
        {
            var product = await _productService.GetProductsAsync(pageNumber, pageSize);
            return Ok(product);
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving products");
        }
    }

    /// <summary>
    /// Gets a list of products by their name.
    /// </summary>
    /// <param name="productName">The product name to filter products by.</param>
    /// <returns>A list of products matching the provided product name.</returns>
    [HttpGet("{productName}")]
    public async Task<ActionResult<List<Product>>> GetProductByNameAsync(string productName)
    {
        try
        {
            var product = await _productService.GetProductByNameAsync(productName);
            return Ok(product);
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving product");
        }
    }

    /// <summary>
    /// Gets a list of products by their category type.
    /// </summary>
    /// <param name="categoryType">The category type to filter products by.</param>
    /// <returns>A list of products in the specified category.</returns>
    [HttpGet("category/{CategoryType}")]
    public async Task<ActionResult<List<Product>>> GetProductByCategoryTypeAsync(string CategoryType)
    {
        try
        {
            var product = await _productService.GetProductByCategoryTypeAsync(CategoryType);
            return Ok(product);
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving product");
        }
    }
}