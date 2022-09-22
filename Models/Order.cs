namespace Bakery.Models;

public class Order
{
    public int Id { get; set; }
    public List<OrderLine>? OrderLines { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string? AddressLine2 { get; set; }
    public string Postcode { get; set; } = string.Empty;
    public string Town { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public DateTime Placed { get; set; }
}