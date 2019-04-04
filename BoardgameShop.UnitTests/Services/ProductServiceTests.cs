using System;
using System.Collections.Generic;
using System.Text;
using BoardgameShop.Repository;
using BoardgameShop.Services;
using BoardgameShop.Models;
using NUnit.Framework;
using FakeItEasy;
using System.Linq;

namespace BoardgameShop.UnitTests.Services
{
    class ProductServiceTests
    {
        private IProductRepository productRepository;
        private ProductService productService;

        [SetUp]
        public void SetUp()
        {
            this.productRepository = A.Fake<IProductRepository>();
            this.productService = new ProductService(this.productRepository);
        }

        [Test]
        public void Get_ReturnsResultFromRepository()
        {
            // Arrange
            var productItem = new Product
            {
                ProductId = 2,
                Name = "Catan",
                Price = 295,
                Description = "In Catan players try to be the dominant force on the island of Catan by building settlements, cities, and roads.",
                Image = "",
                Category = "strategy"
            };

            var productItems = new List<Product>
            {
                productItem
            };

            A.CallTo(() => this.productRepository.Get()).Returns(productItems);
            // Act
            var result = this.productService.Get().Single();

            // Assert
            Assert.That(result, Is.EqualTo(productItem));
        }
    }
}
