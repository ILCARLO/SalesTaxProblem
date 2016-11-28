using System.Collections.Generic;
using SalesTaxProblem.Domain;
using SalesTaxProblem.TaxStrategies;

namespace SalesTaxProblem
{
    public class TaxCalculator
    {
        public string CreateReceipt(List<Product> products)
        {
            var receiptContext = new ReceiptContextWriter();

            foreach (var product in products)
            {
                var taxKindStrategy = TypeTaxStartegyFactory.GetTypeStrategy(product.Kind);
                var kindTax = taxKindStrategy.GetTaxAmount(product.Price, product.Quantity);

                var taxOriginStrategy = OriginTaxStrategyFactory.GetOriginStrategy(product.Origin);
                var originTax = taxOriginStrategy.GetTaxAmount(product.Price, product.Quantity);

                var currentTax = (kindTax + originTax);
                
                receiptContext.AddEntryToReceipt(product, currentTax);
            }

            return receiptContext.PrintReceipt();
        }
    }
}
