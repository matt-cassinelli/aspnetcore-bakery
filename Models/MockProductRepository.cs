namespace Bakery.Models;

public class MockProductRepository : IProductRepository
{
    public IEnumerable<Product> AllProducts =>
        new List<Product>
        {
            new Product {ProductId=1, Name="Chocolate Cake",        Price=10.95M, ShortDescription="Lorem Ipsum", LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", Category = _categoryRepository.AllCategories.ToList()[0],ImageUrl="http://placekitten.com/400/400", InStock=true, IsProductOfTheWeek=false, ImageThumbnailUrl="http://placekitten.com/100/100"},
            new Product {ProductId=2, Name="Blueberry Muffin",      Price=5.95M,  ShortDescription="Lorem Ipsum", LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", Category = _categoryRepository.AllCategories.ToList()[1],ImageUrl="http://placekitten.com/400/400", InStock=true, IsProductOfTheWeek=false, ImageThumbnailUrl="http://placekitten.com/100/100"},
            new Product {ProductId=3, Name="Cupcakes",              Price=7.95M,  ShortDescription="Lorem Ipsum", LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", Category = _categoryRepository.AllCategories.ToList()[0],ImageUrl="http://placekitten.com/400/400", InStock=true, IsProductOfTheWeek=true,  ImageThumbnailUrl="http://placekitten.com/100/100"},
            new Product {ProductId=4, Name="Salted Caramel Cookie", Price=4.95M,  ShortDescription="Lorem Ipsum", LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", Category = _categoryRepository.AllCategories.ToList()[2],ImageUrl="http://placekitten.com/400/400", InStock=true, IsProductOfTheWeek=true,  ImageThumbnailUrl="http://placekitten.com/100/100"}
        };

    public IEnumerable<Product> ProductsOfTheWeek
    {
        get
        {
            return AllProducts.Where(p => p.IsProductOfTheWeek);
        }
    }

    public Product? GetProductById(int productId) => AllProducts.FirstOrDefault(p => p.ProductId == productId);

    public IEnumerable<Product> SearchProducts(string searchQuery)
    {
        throw new NotImplementedException();
    }
}
