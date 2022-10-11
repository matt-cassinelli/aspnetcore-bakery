using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bakery.Models;

namespace Bakery.Pages
{
    public class CheckoutPageModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBasket _basket;

        public CheckoutPageModel(IOrderRepository orderRepository, IBasket basket)
        {
            _orderRepository = orderRepository;
            _basket = basket;
        }

        [BindProperty] // Model Binding
        public Order Order { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost() // Don't need to specify params - Model Binding will pass them into the Order property (above)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var items = _basket.GetItems();
            _basket.Items = items;

            if (_basket.Items.Count == 0)
            {
                ModelState.AddModelError("", "Your basket is empty, add some products first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(Order);
                _basket.Clear();
                return RedirectToPage("CheckoutCompletePage");
            }

            return Page();
        }
    }
}
