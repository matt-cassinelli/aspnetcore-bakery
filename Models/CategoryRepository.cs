using Microsoft.EntityFrameworkCore;
namespace Bakery.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly BakeryDbContext _context;

    public CategoryRepository(BakeryDbContext context)
    {
        _context = context; // Constructor injection.
    }

    public IEnumerable<Category> AllCategories =>
        _context.Categories.OrderBy(c => c.CategoryName);
}