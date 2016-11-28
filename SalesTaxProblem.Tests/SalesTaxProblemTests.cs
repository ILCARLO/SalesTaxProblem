using System.Collections.Generic;
using System.ComponentModel;
using SalesTaxProblem.Domain;
using Xunit;

namespace SalesTaxProblem.Tests
{
    public class SalesTaxProblemTests
    {
        [Fact]
        [Category("Input1")]
        public void Should_Input1BeEvaluated_When_ProductsAreProvided()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product(1, "book", 12.49, ProductType.Books, Origin.Local),
                new Product(1, "music CD", 14.99, ProductType.Other, Origin.Local),
                new Product(1, "choclate bar", 0.85, ProductType.Food, Origin.Local)
            };

            // Act
            var taxCaluclator = new TaxCalculator();
            var receipt = taxCaluclator.CreateReceipt(products);

            // Assert
            Assert.NotNull(receipt);
            var pieces = receipt.Split('\n');
            Assert.Equal("1 book: 12.49", pieces[0].Trim());
            Assert.Equal("1 music CD: 16.49", pieces[1].Trim());
            Assert.Equal("1 choclate bar: 0.85", pieces[2].Trim());
            Assert.Equal("Sales Taxes: 1.50", pieces[3].Trim());
            Assert.Equal("Total: 29.83", pieces[4].Trim());
        }

        [Fact]
        [Category("Input2")]
        public void Should_Input2BeEvaluated_When_ProductsAreProvided()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product(1, "imported box of chocolate", 10.00, ProductType.Food, Origin.Imported),
                new Product(1,"imported bottle of perfume", 47.50, ProductType.Other, Origin.Imported)
            };

            // Act
            var taxCaluclator = new TaxCalculator();
            var receipt = taxCaluclator.CreateReceipt(products);

            // Assert
            Assert.NotNull(receipt);
            var pieces = receipt.Split('\n');
            Assert.Equal("1 imported box of chocolate: 10.50", pieces[0].Trim());
            Assert.Equal("1 imported bottle of perfume: 54.65", pieces[1].Trim());
            Assert.Equal("Sales Taxes: 7.65", pieces[2].Trim());
            Assert.Equal("Total: 65.15", pieces[3].Trim());
        }

        [Fact]
        [Category("Input3")]
        public void Should_Input3BeEvaluated_When_ProductsAreProvided()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product(1, "imported bottle of parfume", 27.99, ProductType.Other, Origin.Imported),
                new Product(1, "bottle of perfume", 18.99, ProductType.Other, Origin.Local),
                new Product(1, "packet of headache pills", 9.75, ProductType.MedicalProducts, Origin.Local),
                new Product(1, "imported box of chocolates", 11.25, ProductType.Food, Origin.Imported)
            };

            // Act
            var taxCaluclator = new TaxCalculator();
            var receipt = taxCaluclator.CreateReceipt(products);

            // Assert
            Assert.NotNull(receipt);
            var pieces = receipt.Split('\n');
            Assert.Equal("1 imported bottle of parfume: 32.19", pieces[0].Trim());
            Assert.Equal("1 bottle of perfume: 20.89", pieces[1].Trim());
            Assert.Equal("1 packet of headache pills: 9.75", pieces[2].Trim());
            Assert.Equal("1 imported box of chocolates: 11.85", pieces[3].Trim());
            Assert.Equal("Sales Taxes: 6.70", pieces[4].Trim());
            Assert.Equal("Total: 74.68", pieces[5].Trim());
        }

        [Fact]
        [Category("Input4")]
        public void Should_CalculateTaxCorrectly_When_DifferentQuantityIsProvided()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product(2, "book", 12.49, ProductType.Books, Origin.Local),
                new Product(2, "music CD", 14.99, ProductType.Other, Origin.Local),
                new Product(2, "choclate bar", 0.85, ProductType.Food, Origin.Local)
            };

            // Act
            var taxCaluclator = new TaxCalculator();
            var receipt = taxCaluclator.CreateReceipt(products);

            // Assert
            Assert.NotNull(receipt);
            var pieces = receipt.Split('\n');
            Assert.Equal("2 book: 24.98", pieces[0].Trim());
            Assert.Equal("2 music CD: 32.98", pieces[1].Trim());
            Assert.Equal("2 choclate bar: 1.70", pieces[2].Trim());
            Assert.Equal("Sales Taxes: 3.00", pieces[3].Trim());
            Assert.Equal("Total: 59.66", pieces[4].Trim());
        }
    }
}
