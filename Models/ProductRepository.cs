using Microsoft.EntityFrameworkCore;
namespace Bakery.Models;

public class ProductRepository : IProductRepository
{
    private readonly BakeryDbContext _context;

    public ProductRepository(BakeryDbContext context)
    {
        _context = context; // Construction injection.
    }

    public IEnumerable<Product> AllProducts
    {
        get
        {
            return _context.Products.Include(p => p.Category);
        }
    }

    public IEnumerable<Product> ProductsOfTheWeek
    {
        get
        {
            return _context.Products.Include(p => p.Category).Where(p => p.IsProductOfTheWeek);
        }
    }

    public Product? GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }
}