using Bakery.Models;
using Bakery.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace Bakery.Controllers;

public class BasketController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly IBasket _basket;

    public BasketController(IProductRepository productRepository, IBasket basket)
    {
        _productRepository = productRepository;
        _basket = basket;

    }
    public ViewResult Index()
    {
        _basket.Items = _basket.GetItems(); // Should this just be a property instead?

        var basketViewModel = new BasketViewModel(_basket, _basket.GetTotal());

        return View(basketViewModel);
    }

    public RedirectToActionResult AddToBasket(int id)
    {
        var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.Id == id);

        if (selectedProduct != null)
        {
            _basket.AddItem(selectedProduct);
        }
        return RedirectToAction("Index"); // Redirect to Index of Basket
    }

    public RedirectToActionResult RemoveFromBasket(int id)
    {
        var selectedProduct = _productRepository.AllProducts.FirstOrDefault(p => p.Id == id);

        if (selectedProduct != null)
        {
            _basket.RemoveItem(selectedProduct);
        }
        return RedirectToAction("Index");
    }
}