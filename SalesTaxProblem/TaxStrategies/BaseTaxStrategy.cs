using System;
using SalesTaxProblem.Domain;

namespace SalesTaxProblem.TaxStrategies
{

    public abstract class BaseTaxStrategy : ITaxable
    {
        public abstract double GetTax();

        public double GetTaxAmount(double price)
        {
            var appliedTaxes = Math.Round(price * GetTax(), 2);
            return (Math.Ceiling(appliedTaxes / 0.05)) * 0.05;
        }
    }
}
