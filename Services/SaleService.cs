using CodingBasics.Data;
using CodingBasics.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingBasics.Services;

/// <summary>
/// Provides services for managing sales in the AdventureWorks2019 database.
/// </summary>
public class SaleService
{
    private readonly AdventureWorks2019Context _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="SaleService"/> class.
    /// </summary>
    /// <param name="context">The database context to be used.</param>
    public SaleService(AdventureWorks2019Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Gets a paginated list of sales.
    /// </summary>
    /// <param name="pageNumber">The current page number for pagination.</param>
    /// <param name="pageSize">The size of each page.</param>
    /// <returns>A list of sales in the specified page range.</returns>
    public async Task<List<VSalesPerson>> GetSalesOverview(int pageNumber, int pageSize)
    {
        try
        {
            return await _context.VSalesPeople.OrderBy(s => s.BusinessEntityId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            // Handle the exception here
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<VSalesPerson>(); // Return an empty list or handle the error accordingly
        }
    }

    /// <summary>
    /// Gets sales information for a specific salesperson in a given year.
    /// </summary>
    /// <param name="salesPersonName">The name of the salesperson to retrieve sales information for.</param>
    /// <param name="year">The year to retrieve sales information for.</param>
    /// <returns>A list of sales information for the specified salesperson in the specified year.</returns>
    public async Task<List<SalesInfoDto>> GetSalesInfo(string salesPersonName, int year)
    {
        try
        {
            salesPersonName = salesPersonName.ToLower();
            var query = from sp in _context.SalesPeople
                        join p in _context.People on sp.BusinessEntityId equals p.BusinessEntityId
                        join soh in _context.SalesOrderHeaders on sp.BusinessEntityId equals soh.SalesPersonId
                        join st in _context.SalesTerritories on sp.TerritoryId equals st.TerritoryId
                        where (p.FirstName.ToLower() + " " + p.LastName.ToLower()).Contains(salesPersonName) &&
                              soh.OrderDate.AddMonths(6).Year == year
                        select new SalesInfoDto
                        {
                            BusinessEntityID = sp.BusinessEntityId,
                            SalesPersonName = p.FirstName + " " + p.LastName,
                            SalesOrderNumber = soh.SalesOrderNumber,
                            TerritoryName = st.Name,
                            DueDate = soh.DueDate,
                            SubTotal = soh.SubTotal,
                            TotalDue = soh.TotalDue
                        };

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            // Handle the exception here
            Console.WriteLine($"An error occurred: {ex.Message}");
            return new List<SalesInfoDto>(); // Return an empty list or handle the error accordingly
        }
    }


}