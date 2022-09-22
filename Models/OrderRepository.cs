namespace Bakery.Models;

public class OrderRepository : IOrderRepository
{
    private readonly MyDbContext _context;
    private readonly IBasket _basket;

    public OrderRepository(MyDbContext context, IBasket basket)
    {
        _context = context;
        _basket = basket;
    }

    public void CreateOrder(Order order)
    {
        order.Placed = DateTime.Now;
        order.Total = _basket.GetTotal();
        order.OrderLines = new List<OrderLine>();

        List<BasketItem>? basketItems = _basket.Items;
        foreach (BasketItem? basketItem in basketItems) // Replace with `in _basket.Items)` ?
        {
            var orderLine = new OrderLine
            {
                Amount = basketItem.Amount,
                ProductId = basketItem.Product.Id,
                Price = basketItem.Product.Price
            };

            order.OrderLines.Add(orderLine);
        }

        _context.Orders.Add(order);

        _context.SaveChanges();
    }
}