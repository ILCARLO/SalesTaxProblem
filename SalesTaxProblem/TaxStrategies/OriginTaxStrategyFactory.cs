using System.ComponentModel;
using SalesTaxProblem.Domain;

namespace SalesTaxProblem.TaxStrategies
{
    public class OriginTaxStrategyFactory
    {

        public static ITaxable GetKindStrategy(Origin productOrigin)
        {
            switch (productOrigin)
            {
                case Origin.Local:
                    return new LocalTaxStartegy();
                case Origin.Imported:
                    return new ImportedtaxStrategy();
                default:
                    throw new InvalidEnumArgumentException(nameof(productOrigin));
            }
        }
    }

    public class LocalTaxStartegy : BaseTaxStrategy
    {
        public override double GetTax() => 0;
    }

    public class ImportedtaxStrategy : BaseTaxStrategy
    {
        public override double GetTax() => 0.05F;
    }
}
