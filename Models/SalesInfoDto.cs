
namespace CodingBasics.Models;

public partial class SalesInfoDto
{
    /// <summary>
    /// Gets or sets the business entity ID.
    /// </summary>
    public int BusinessEntityID { get; set; }

    /// <summary>
    /// Gets or sets the sales person name.
    /// </summary>
    public string? SalesPersonName { get; set; }

    /// <summary>
    /// Gets or sets the sales order number.
    /// </summary>
    public string? SalesOrderNumber { get; set; }

    /// <summary>
    /// Gets or sets the territory name.
    /// </summary>
    public string? TerritoryName { get; set; }

    /// <summary>
    /// Gets or sets the due date.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Gets or sets the subtotal.
    /// </summary>
    public decimal SubTotal { get; set; }

    /// <summary>
    /// Gets or sets the total due.
    /// </summary>
    public decimal TotalDue { get; set; }
}
