using Microsoft.AspNetCore.Mvc;
using Bakery.Models;

namespace Bakery.Controllers;

public class OrderController : Controller
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBasket _basket;

    public OrderController(IOrderRepository orderRepository, IBasket basket)
    {
        _orderRepository = orderRepository; //
        _basket = basket;                   // Inject the dependencies we need.
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        var items = _basket.GetItems();
        _basket.Items = items; // Put this in GetItems?

        if (_basket.Items.Count == 0)
        {
            ModelState.AddModelError("", "Your cart is empty, add some products first");
        }

        if (ModelState.IsValid)
        {
            _orderRepository.CreateOrder(order);
            _basket.Clear();
            return RedirectToAction("CheckoutComplete");
        }

        return View(order); // If not valid, return the same view, passing in their order object
    }

    public IActionResult CheckoutComplete()
    {
        ViewBag.CheckoutCompleteMessage = "Thanks for your order. Enjoy!";
        return View();
    }
}