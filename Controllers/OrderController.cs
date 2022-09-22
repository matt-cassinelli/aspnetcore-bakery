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

    public IActionResult Checkout()
    {
        return View();
    }
}