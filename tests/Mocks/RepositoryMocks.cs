using Bakery.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryTests.Mocks;

public class RepositoryMocks
{
    public static Mock<IProductRepository> GetProductRepository()
    {
        var products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Chocolate Cake",
                Price = 10.95M,
                ShortDescription = "Our famous chocolate cake!",
                LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.",
                CategoryId = 1, // [alt] Categories["Cakes"]
                ImageUrl = "images/chocolate-cake.jpg",
                InStock = true,
                IsProductOfTheWeek = false,
                ImageThumbnailUrl = "images/chocolate-cake.jpg",
                AllergyInformation = ""
            },
            new Product
            {
                Id = 2,
                Name = "Blueberry Muffin",
                Price = 5.95M,
                ShortDescription = "Lorem Ipsum",
                LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.",
                CategoryId = 1,
                ImageUrl = "images/blueberry-muffin.jpg",
                InStock = true,
                IsProductOfTheWeek = false,
                ImageThumbnailUrl = "images/blueberry-muffin.jpg"
            },
            new Product
            {
                Id = 3,
                Name = "Cupcakes",
                Price = 7.95M,
                ShortDescription = "Lorem Ipsum",
                LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.",
                CategoryId = 1,
                ImageUrl = "images/cupcakes.jpg",
                InStock = true,
                IsProductOfTheWeek = true,
                ImageThumbnailUrl = "images/cupcakes.jpg"
            },
            new Product {
                Id = 4,
                Name = "Salted Caramel Cookie",
                Price = 4.95M,
                ShortDescription = "Lorem Ipsum",
                LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam pharetra finibus mi, a vulputate elit maximus non. Curabitur id nisi sem. Donec et suscipit nunc. Duis non mi mi. Ut nisl magna, consequat non varius non, posuere vel arcu. Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor. Cras eget nunc at mi efficitur volutpat. Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam. Nam eget eros non augue blandit elementum non nec felis.",
                CategoryId = 1,
                ImageUrl = "images/salted-caramel-cookie.jpg",
                InStock = true,
                IsProductOfTheWeek = true,
                ImageThumbnailUrl = "images/salted-caramel-cookie.jpg"
            },
            new Product {
                Id = 5,
                Name = "Strawberry Cheese Cake",
                Price = 18.95M,
                ShortDescription = "You'll love it!",
                LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Etiam pharetra finibus mi, a vulputate elit maximus non.Curabitur id nisi sem.Donec et suscipit nunc.Duis non mi mi.Ut nisl magna, consequat non varius non, posuere vel arcu.Maecenas efficitur turpis sit amet velit cursus, vestibulum hendrerit ligula tempor.Cras eget nunc at mi efficitur volutpat.Morbi ipsum sapien, sodales eleifend metus eget, luctus scelerisque diam.Nam eget eros non augue blandit elementum non nec felis.",
                CategoryId = 4,
                ImageUrl = "images/strawberry-cheesecake.jpg",
                InStock = false,
                IsProductOfTheWeek = false,
                ImageThumbnailUrl = "images/strawberry-cheesecake.jpg",
                AllergyInformation = ""
            }
        };

        var mockPieRepository = new Mock<IProductRepository>();
        mockPieRepository.Setup(repo => repo.AllProducts).Returns(products);
        mockPieRepository.Setup(repo => repo.ProductsOfTheWeek).Returns(products.Where(p => p.IsProductOfTheWeek));
        mockPieRepository.Setup(repo => repo.GetProductById(It.IsAny<int>())).Returns(products[0]);
        return mockPieRepository;
    }

    public static Mock<ICategoryRepository> GetCategoryRepository()
    {
        var categories = new List<Category>
        {
            new Category { Id=1, Name="Cakes",   Description="All cakes" },
            new Category { Id=2, Name="Breads",  Description="From loaf to baguette" },
            new Category { Id=3, Name="Cookies", Description="Perfectly baked" },
            new Category { Id=4, Name="Cheese cakes" }
        };

        var mockCategoryRepository = new Mock<ICategoryRepository>();
        mockCategoryRepository.Setup(repo => repo.AllCategories).Returns(categories);
        return mockCategoryRepository;
    }

    //private static Dictionary<string, Category>? _categories;
    //public static Dictionary<string, Category> Categories
    //{
    //    get
    //    {
    //        if (_categories == null)
    //        {
    //            var genresList = new Category[]
    //            {
    //                new Category { Id=1, Name="Cakes"},
    //                new Category { Id=2, Name="Breads" },
    //                new Category { Id=3, Name="Cookies" },
    //                new Category { Id=4, Name="Cheese cakes" }
    //            };

    //            _categories = new Dictionary<string, Category>();

    //            foreach (var genre in genresList)
    //            {
    //                _categories.Add(genre.Name, genre);
    //            }
    //        }
    //        return _categories;
    //    }
    //}
}
