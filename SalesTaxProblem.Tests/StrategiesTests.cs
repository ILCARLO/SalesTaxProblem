using System;
using System.ComponentModel;
using SalesTaxProblem.Domain;
using SalesTaxProblem.TaxStrategies;
using Xunit;

namespace SalesTaxProblem.Tests
{
    public class StrategiesTests
    {
        [Theory]
        [InlineData(ProductType.Books, typeof(ExemptTaxStrategy))]
        [InlineData(ProductType.Food, typeof(ExemptTaxStrategy))]
        [InlineData(ProductType.MedicalProducts, typeof(ExemptTaxStrategy))]
        [InlineData(ProductType.Other, typeof(SalesTaxStrategy))]
        [Category("Strategies - ProductType ")]
        public void Should_ReturnValidTypeStrategy_When_PassingProductType(ProductType productType, Type expectedType)
        {
            // Act
            var strategy = TypeTaxStartegyFactory.GetTypeStrategy(productType);

            // Assert
            Assert.NotNull(strategy);
            Assert.IsType(expectedType, strategy);
        }

        [Theory]
        [InlineData(Origin.Local, typeof(LocalTaxStartegy))]
        [InlineData(Origin.Imported, typeof(ImportedtaxStrategy))]
        [Category("Strategies - Origin ")]
        public void Should_ReturnValidOriginStrategy_When_PassingOrigin(Origin origin, Type expectedType)
        {
            // Act
            var strategy = OriginTaxStrategyFactory.GetOriginStrategy(origin);

            // Assert
            Assert.NotNull(strategy);
            Assert.IsType(expectedType, strategy);
        }
    }
}
