using Bakery.Models;
using Bakery.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bakery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;     // DI
        public HomeController(IProductRepository productRepository) //
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var piesOfTheWeek = _productRepository.ProductsOfTheWeek;
            var homeViewModel = new HomeViewModel(piesOfTheWeek);
            return View(homeViewModel);
        }
    }
}