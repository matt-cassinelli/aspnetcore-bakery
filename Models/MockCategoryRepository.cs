namespace Bakery.Models;

public class MockCategoryRepository : ICategoryRepository
{
    public IEnumerable<Category> AllCategories =>
        new List<Category>
        {
            new Category{CategoryId=1, CategoryName="Cakes", Description="All cakes"},
            new Category{CategoryId=2, CategoryName="Breads", Description="From loaf to baguette"},
            new Category{CategoryId=3, CategoryName="Cookies", Description="Perfectly baked"}
        };
}