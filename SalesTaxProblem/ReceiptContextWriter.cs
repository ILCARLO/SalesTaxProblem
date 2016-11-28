using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using SalesTaxProblem.Domain;

namespace SalesTaxProblem
{
    public class ReceiptContextWriter
    {
        private double _total;
        private double _taxes;
        private readonly List<Product> _boughtProducts;

        public ReceiptContextWriter()
        {
            _total = 0F;
            _taxes = 0F;
            _boughtProducts = new List<Product>(0);

        }

        public void AddEntry(Product product, double finalPrice, double tax)
        {
            product.Price = finalPrice;
            _boughtProducts.Add(product);
            _total += finalPrice;
            _taxes += tax;
        }

        public string PrintReceipt()
        {
            // Just in case your machine has other cultures
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var builder = new StringBuilder();
            foreach (var product in _boughtProducts)
            {
                builder.AppendLine($"{product.Quantity} {product.Name}: {GetDoubleValue(product.Price)}");
            }

            builder.AppendLine($"Sales Taxes: {GetDoubleValue(_taxes)}");
            builder.AppendLine($"Total: {GetDoubleValue(_total)}");
            return builder.ToString();
        }

        private string GetDoubleValue(double value)
        {
            return $"{value:0.00}";
        }
    }
}
