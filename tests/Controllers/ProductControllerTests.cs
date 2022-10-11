using Bakery.Controllers;
using Bakery.ViewModels;
using BakeryTests.Mocks;
using Microsoft.AspNetCore.Mvc;

namespace BakeryTests.Controllers;

public class ProductControllerTests
{
    [Fact]
    public void List_EmptyCategory_ReturnsAllProducts()
    {
        // Arrange
        var mockCategoryRepository = RepositoryMocks.GetCategoryRepository(); // Under normal circumstances (not test), these are passed in
        var mockProductRepository = RepositoryMocks.GetProductRepository();   // from the dependency injection container
        var productController = new ProductController(mockProductRepository.Object, mockCategoryRepository.Object);

        // Act
        var result = productController.List("");

        // Assert
        var viewResult = Assert.IsType<ViewResult>(result); // Check result is type 'ViewResult'
        var productListViewModel = Assert.IsAssignableFrom<ProductListViewModel>(viewResult.ViewData.Model);
        Assert.Equal(5, productListViewModel.Products.Count()); // Check there are 5 products
    }
}

