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
