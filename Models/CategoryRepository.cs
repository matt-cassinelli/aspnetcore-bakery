using Microsoft.EntityFrameworkCore;
namespace Bakery.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly MyDbContext _context;

    public CategoryRepository(MyDbContext context)
    {
        _context = context; // Constructor injection.
    }

    public IEnumerable<Category> AllCategories =>
        _context.Categories.OrderBy(c => c.Name);
}