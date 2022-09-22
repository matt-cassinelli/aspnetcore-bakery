// View Components are like partial views but aren't limited to using data from only the Model.

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

    public IViewComponentResult Invoke() // The Invoke() method gets called when the view component is rendered.
    {
        _basket.Items = _basket.GetItems(); // TODO: Should this be done inside the Basket class?
        var basketViewModel = new BasketViewModel(_basket, _basket.GetTotal());
        return View(basketViewModel);
    }   
}