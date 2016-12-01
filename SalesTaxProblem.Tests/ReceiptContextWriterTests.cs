// ———————————————————————–
// 
//  <copyright file="ReceiptContextWriterTests.cs" >
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using SalesTaxProblem.Domain;
using Xunit;

namespace SalesTaxProblem.Tests
{
    public class ReceiptContextWriterTests
    {
        [Fact]
        [Category("ReceiptContext")]
        public void Should_ThrowException_When_NullProductIsProvidedToRecepitContextWriter()
        {
            // Arrange
            var receiptContext = new ReceiptContextWriter();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => receiptContext.AddEntryToReceipt(null, 0));
        }

        [Fact]
        [Category("ReceiptContext - add")]
        public void Should_AddEntryToReceipt_When_ValidParametersAreProvided()
        {
            // Arrange
            var receiptContext = new ReceiptContextWriter();
            var newProduct = new Product(1, "Product1", 10.50, ProductType.Books, Origin.Local);

            // Act
            receiptContext.AddEntryToReceipt(newProduct, 0);

            // Assert
            var entries = (List<Product>)typeof(ReceiptContextWriter).GetField("_boughtProducts", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(receiptContext);
            var total = (double)typeof(ReceiptContextWriter).GetField("_total", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(receiptContext);
            var tax = (double)typeof(ReceiptContextWriter).GetField("_taxes", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(receiptContext);
            Assert.NotNull(entries);
            Assert.Equal(1, entries.Count);
            Assert.Equal(10.50, total);
            Assert.Equal(0, tax);
        }

        [Fact]
        [Category("ReceiptContext - Print")]
        public void Should_PrintReceipt_When_ReceiptContainsEntries()
        {
            // Arrange
            var receiptContext = new ReceiptContextWriter();
            var newProduct = new Product(1, "Product1", 10.50, ProductType.Books, Origin.Local);
            receiptContext.AddEntryToReceipt(newProduct, 0);

            // Act
            var printedreceipt = receiptContext.PrintReceipt();

            // Assert
            Assert.NotNull(printedreceipt);
            Assert.Equal("1 Product1: 10.50\r\nSales Taxes: 0.00\r\nTotal: 10.50\r\n", printedreceipt);
        }
    }
}
