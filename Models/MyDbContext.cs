using Microsoft.EntityFrameworkCore;
namespace Bakery.Models;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id=1, Name="Cakes",   Description="All cakes" },
            new Category { Id=2, Name="Breads",  Description="From loaf to baguette" },
            new Category { Id=3, Name="Cookies", Description="Perfectly baked" },
            new Category { Id=4, Name="Cheese cakes" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id=1, Name="Chocolate Cake",         Price=10.95M, ShortDescription="Lorem Ipsum",     LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", CategoryId=1, ImageUrl="images/chocolate-cake.jpg",        InStock=true,  IsProductOfTheWeek=false, ImageThumbnailUrl="images/chocolate-cake.jpg" },
            new Product { Id=2, Name="Blueberry Muffin",       Price=5.95M,  ShortDescription="Lorem Ipsum",     LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", CategoryId=1, ImageUrl="images/blueberry-muffin.jpg",      InStock=true,  IsProductOfTheWeek=false, ImageThumbnailUrl="images/blueberry-muffin.jpg" },
            new Product { Id=3, Name="Cupcakes",               Price=7.95M,  ShortDescription="Lorem Ipsum",     LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", CategoryId=1, ImageUrl="images/cupcakes.jpg",              InStock=true,  IsProductOfTheWeek=true,  ImageThumbnailUrl="images/cupcakes.jpg" },
            new Product { Id=4, Name="Salted Caramel Cookie",  Price=4.95M,  ShortDescription="Lorem Ipsum",     LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.", CategoryId=1, ImageUrl="images/salted-caramel-cookie.jpg", InStock=true,  IsProductOfTheWeek=true,  ImageThumbnailUrl="images/salted-caramel-cookie.jpg" },
            new Product { Id=5, Name="Strawberry Cheese Cake", Price=18.95M, ShortDescription="You'll love it!", LongDescription="Lorem ipsum dolor sit amet, consectetur adipiscing elit.Etiam pharetra finibus mi, a vulputate elit maximus non.Curabitur id nisi sem.Donec et suscipit nunc.Duis non mi mi.Ut nisl magna, consequat non varius non, posuere vel arcu.Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor.Cras eget nunc at mi efficitur volutpat.Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam.Nam eget eros non augue blandit elementum non nec felis.",          CategoryId=4, ImageUrl="",                                 InStock=false, IsProductOfTheWeek=false, ImageThumbnailUrl="", AllergyInformation = "" }
        );
    }
}