namespace Bakery.Models;

public class BasketItem
{
    public int Id { get; set; }
    public Product Product { get; set; } = default!;
    public int Amount { get; set; }
    public string? BasketId { get; set; } // TODO: Make GUID?
}