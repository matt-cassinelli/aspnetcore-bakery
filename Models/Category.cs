namespace Bakery.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty; // Mandatory
    public string? Description { get; set; }
    public List<Product>? Products { get; set; } // Optional
}