using CodingBasics.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingBasics.Services;

/// <summary>
/// Controller for handling sale-related requests.
/// </summary>

[ApiController]
[Route("[controller]")]
public class SaleController : ControllerBase
{
    private readonly SaleService _saleService;

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleController" /> class.
    /// </summary>
    /// <param name="saleService">The service for managing sale data.</param>
    public SaleController(SaleService saleService)
    {
        _saleService = saleService;
    }

    /// <summary>
    /// Gets a paginated list of sales.
    /// </summary>
    /// <param name="pageNumber">The current page number for pagination.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <returns>A list of sales in the specified page range.</returns>

    [HttpGet]
    public async Task<ActionResult<List<VSalesPerson>>> GetSalesOverview(int pageNumber, int pageSize)
    {
        try
        {
            var sales = await _saleService.GetSalesOverview(pageNumber, pageSize);
            return Ok(sales);
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving sales");
        }
    }

    /// <summary>
    /// Gets sales information for a specific salesperson in a given year.
    /// </summary>
    /// <param name="salesPersonName">The name of the salesperson to retrieve sales information for.</param>
    /// <param name="year">The year to retrieve sales information for.</param>
    /// <returns>A list of sales information for the specified salesperson in the specified year.</returns>

    [HttpGet("salesByPerson")]
    public async Task<ActionResult<List<SalesInfoDto>>> GetSalesInfo(string salesPersonName, int year)
    {
        try
        {
            var salesInfo = await _saleService.GetSalesInfo(salesPersonName, year);
            return Ok(salesInfo);
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
            return BadRequest("An error occurred while retrieving sales info");
        }
    }
}