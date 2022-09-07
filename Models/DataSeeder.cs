namespace Bakery.Models;

public static class DataSeeder
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        BakeryDbContext context =
            applicationBuilder.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<BakeryDbContext>();

        if (!context.Categories.Any())
        {
            context.Categories.AddRange(Categories.Select(c => c.Value));
        }

        if (!context.Products.Any())
        {
            context.AddRange
            (
                new Product { Name = "Chocolate Cake", Price = 10.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", Category = Categories["Cakes"], ImageUrl = "images/chocolate-cake.jpg", InStock = true, IsProductOfTheWeek = false, ImageThumbnailUrl = "images/chocolate-cake.jpg" },
                new Product { Name = "Blueberry Muffin", Price = 5.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", Category = Categories["Cakes"], ImageUrl = "images/blueberry-muffin.jpg", InStock = true, IsProductOfTheWeek = false, ImageThumbnailUrl = "images/blueberry-muffin.jpg" },
                new Product { Name = "Cupcakes", Price = 7.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", Category = Categories["Cakes"], ImageUrl = "images/cupcakes.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "images/cupcakes.jpg" },
                new Product { Name = "Salted Caramel Cookie", Price = 4.95M, ShortDescription = "Lorem Ipsum", LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", Category = Categories["Cakes"], ImageUrl = "images/salted-caramel-cookie.jpg", InStock = true, IsProductOfTheWeek = true, ImageThumbnailUrl = "images/salted-caramel-cookie.jpg" },
                new Product { Name = "Strawberry Cheese Cake", Price = 18.95M, ShortDescription = "You'll love it!", LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Etiam pharetra finibus mi, a vulputate elit maximus non.Curabitur id nisi sem.Donec et suscipit nunc.Duis non mi mi.Ut nisl magna, consequat non varius non, posuere vel arcu.Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor.Cras eget nunc at mi efficitur volutpat.Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam.Nam eget eros non augue blandit elementum non nec felis.", Category = Categories["Cheese cakes"], ImageUrl = "", InStock = false, IsProductOfTheWeek = false, ImageThumbnailUrl = "", AllergyInformation = "" }
            );
        }

        context.SaveChanges();
    }

    private static Dictionary<string, Category>? categories;

    public static Dictionary<string, Category> Categories
    {
        get
        {
            if (categories == null)
            {
                var genresList = new Category[]
                {
                        new Category { CategoryName="Cakes", Description="All cakes"},
                        new Category { CategoryName="Breads", Description="From loaf to baguette"},
                        new Category { CategoryName="Cookies", Description="Perfectly baked"},
                        new Category { CategoryName="Cheese cakes" }
                };

                categories = new Dictionary<string, Category>();

                foreach (Category genre in genresList)
                {
                    categories.Add(genre.CategoryName, genre);
                }
            }

            return categories;
        }
    }
}