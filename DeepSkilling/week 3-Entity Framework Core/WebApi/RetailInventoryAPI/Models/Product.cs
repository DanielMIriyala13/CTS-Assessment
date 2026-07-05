using System.ComponentModel.DataAnnotations;

namespace RetailInventoryAPI.Models;

public class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int CategoryId { get; set; }

    public Category? Category { get; set; }

    public string Brand { get; set; } = string.Empty;

    [Timestamp]
    public byte[]? RowVersion { get; set; }
}