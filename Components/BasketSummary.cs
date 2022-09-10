using Bakery.Models;
using Bakery.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Bakery.Components;

public class BasketSummary : ViewComponent
{
    private readonly IBasket _basket;
    public BasketSummary(IBasket basket)
    {
        _basket = basket; // Provide access to Basket through DI
    }

    public IViewComponentResult Invoke() // When a view component is rendered, the Invoke() method gets called.
    {
        _basket.Items = _basket.GetItems(); // TODO: Should this be done inside the Basket class?
        var basketViewModel = new BasketViewModel(_basket, _basket.GetTotal());
        return View(basketViewModel);
    }   
}