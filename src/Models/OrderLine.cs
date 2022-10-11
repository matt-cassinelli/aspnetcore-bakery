// Link between Order and Product

namespace Bakery.Models;

public class OrderLine
{
    public int Id { get; set; }
    public int OrderId { get; set; }   // Are these needed? Order & Product are referenced below, EF should be able to figure things out.
    public int ProductId { get; set; } //
    public int Amount { get; set; }
    public decimal Price { get; set; }
    public Product Product { get; set; } = default!;
    public Order Order { get; set; } = default!;
}