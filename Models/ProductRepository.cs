using Microsoft.EntityFrameworkCore;
namespace Bakery.Models;

public class ProductRepository : IProductRepository
{
    private readonly MyDbContext _context;

    public ProductRepository(MyDbContext context)
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