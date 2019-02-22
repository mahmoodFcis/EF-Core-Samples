using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using eCommerce.DAL;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace eCommerce.DAL.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<CommerceDbContext> mockCommerceDbContext;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCommerceDbContext = this.mockRepository.Create<CommerceDbContext>();
        }

        
        
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        private ProductRepository CreateProductRepository()
        {
            return new ProductRepository(
                this.mockCommerceDbContext.Object);
        }
        //fake and not required test
        [Test]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var productRepo = this.CreateProductRepository();
            Product product = new Product() { Name="test produc",Price=20};
            mockCommerceDbContext.Setup(m => m.SaveChanges()).Returns(1);
          //  mockCommerceDbContext.Setup(m => m.Add(It.IsAny<Product>())).Returns(entry);
            // Act
            int actualRowsAffectected=productRepo.Add(
                product);

            // Assert
            Assert.AreEqual(1,actualRowsAffectected);
        }

       
    }
}
