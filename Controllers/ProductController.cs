using Microsoft.AspNetCore.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;   // Constructor injection.
            _categoryRepository = categoryRepository; //
        }

        public IActionResult List()
        {
            ViewBag.CurrentCategory = "Cakes"; // The ViewBag is shared between the Controller and the View.
            return View(_productRepository.AllProducts);
        }
    }
}
