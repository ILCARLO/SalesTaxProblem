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
                var taxKindStrategy = TypeTaxStartegyFactory.GetKindStrategy(product.Kind);
                var kindTax = taxKindStrategy.GetTaxAmount(product.Price);

                var taxOriginStrategy = OriginTaxStrategyFactory.GetKindStrategy(product.Origin);
                var originTax = taxOriginStrategy.GetTaxAmount(product.Price);

                var currentTax = (kindTax + originTax);
                
                receiptContext.AddEntry(product, product.Price + currentTax, currentTax);
            }

            return receiptContext.PrintReceipt();
        }
    }
}
