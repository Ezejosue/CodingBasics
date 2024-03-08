using CodingBasics.Data;
using CodingBasics.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingBasics.Services;

/// <summary>
/// Provides services for managing products in the AdventureWorks2019 database.
/// </summary>
public class ProductService
{
    private readonly AdventureWorks2019Context _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductService"/> class.
    /// </summary>
    /// <param name="context">The database context to be used.</param>
    public ProductService(AdventureWorks2019Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a paginated list of products from the database.
    /// </summary>
    /// <param name="pageNumber">The page number of the pagination.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the list of <see cref="Product"/>.</returns>
    public async Task<List<Product>> GetProductsAsync(int pageNumber, int pageSize)
    {
        try
        {
            return await _context.Products
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
        catch (ApplicationException ex)
        {
            throw new ApplicationException("An error occurred while retrieving products: " + ex.Message);
        }
    }

    /// <summary>
    /// Searches for products by their name.
    /// </summary>
    /// <param name="productName">The product name to search for.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Product"/> matching the provided product name.</returns>
    public async Task<List<Product>> GetProductByNameAsync(string productName)
    {
        try
        {
            var product = await _context.Products
                                 .Where(p => p.Name.Contains(productName)).ToListAsync();

            if (product == null)
            {
                throw new ApplicationException("Product not found");
            }
            else
            {
                return product;

            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving product: " + ex.Message);
        }
    }

    /// <summary>
    /// Retrieves products filtered by category type.
    /// </summary>
    /// <param name="categoryType">The category type to filter by.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Product"/> in the specified category type.</returns>
    public async Task<List<Product>> GetProductByCategoryTypeAsync(string CategoryType)
    {

        try
        {
            var product = await _context.Products
                .Where(p => p.ProductSubcategory != null && p.ProductSubcategory.ProductCategory != null && p.ProductSubcategory.ProductCategory.Name == CategoryType)
                .ToListAsync();


            if (product == null)
            {
                throw new ApplicationException("Product not found");
            }
            else
            {
                return product;

            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException("An error occurred while retrieving product: " + ex.Message);
        }
    }

}