// ———————————————————————–
// 
//  <copyright file="StrategiesTests.cs" >
//      Copyright © 2016 All rights reserved. 
//      Carlo Menapace
//      01 / 12 / 2016
//  </copyright>
// 
// Copyright  © 2016 Carlo Menapace
// 
//  This file is part of SalesTaxProblem.
// 
//     SalesTaxProblem free software: you can redistribute it and/or modify
//     it under the terms of the Affero GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     SalesTaxProblem distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     Affero GNU General Public License for more details.
// 
//     You should have received a copy of the Affero GNU General Public License
//     along with SalesTaxProblem.  If not, see <http://www.gnu.org/licenses/>.
// 
// ———————————————————————–
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
