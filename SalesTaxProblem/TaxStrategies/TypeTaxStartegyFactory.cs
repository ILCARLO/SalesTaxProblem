using System.ComponentModel;
using SalesTaxProblem.Domain;

namespace SalesTaxProblem.TaxStrategies
{
    public class TypeTaxStartegyFactory
    {

        public static ITaxable GetTypeStrategy(ProductType productType)
        {
            switch (productType)
            {
                case ProductType.Books:
                case ProductType.Food:
                case ProductType.MedicalProducts:
                    return new ExemptTaxStrategy();
                case ProductType.Other:
                    return new SalesTaxStrategy();
                default:
                    throw new InvalidEnumArgumentException(nameof(productType));
            }
        }
    }

    public class SalesTaxStrategy : BaseTaxStrategy
    {
        public override double GetTax() => 0.1F;
    }

    public class ExemptTaxStrategy : BaseTaxStrategy
    {
        public override double GetTax() => 0;
    }
}
