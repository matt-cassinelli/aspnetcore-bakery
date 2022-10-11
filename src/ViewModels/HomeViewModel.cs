using Bakery.Models;

namespace Bakery.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Product> ProductsOfTheWeek { get; }
    public HomeViewModel(IEnumerable<Product> productsOfTheWeek)
    {
        ProductsOfTheWeek = productsOfTheWeek;
    }
}

// TODO: Add extra bits of info to the home page.