namespace Bakery.Models;

public interface IProductRepository
{
    IEnumerable<Product> AllProducts { get; }
    IEnumerable<Product> ProductsOfTheWeek { get; }
    Product? GetProductById(int id);
}
