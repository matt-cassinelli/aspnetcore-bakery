using Bakery.Models;
namespace Bakery.ViewModels;

public class BasketViewModel
{
    public BasketViewModel(IBasket basket, decimal basketTotal)
    {
        Basket = basket;
        BasketTotal = basketTotal;
    }

    public IBasket Basket { get; }
    public decimal BasketTotal { get; }
}