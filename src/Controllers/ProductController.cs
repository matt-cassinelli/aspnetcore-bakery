using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using Bakery.ViewModels;

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

        public ViewResult List(string category) // This should be moved to an application service.
        {
            IEnumerable<Product> products;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                products = _productRepository.AllProducts.OrderBy(p => p.Id);
                currentCategory = "All products";
            }
            else
            {
                products = _productRepository.AllProducts
                    .Where(p => p.Category.Name == category)
                    .OrderBy(p => p.Id);
                currentCategory = _categoryRepository.AllCategories
                    .FirstOrDefault(c => c.Name == category)?.Name;
            }

            //ViewBag.CurrentCategory = "Cakes"; // The ViewBag is shared between the Controller and the View.
            //return View(_productRepository.AllProducts);
            //return View(new ProductListViewModel(_productRepository.AllProducts, "All Products"));
            return View(new ProductListViewModel(products, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product == null) { return NotFound(); }
            return View(product);
        }
    }
}
