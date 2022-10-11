namespace Bakery.Models;

public interface IBasket
{
    void AddItem(Product product);
    void RemoveItem(Product product);
    List<BasketItem> GetItems();
    void Clear();
    decimal GetTotal();
    List<BasketItem> Items { get; set; }
    //List<BasketItem> Items { get; }
}