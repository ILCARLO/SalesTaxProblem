using System;
using SalesTaxProblem.Domain;

namespace SalesTaxProblem.TaxStrategies
{

    public abstract class BaseTaxStrategy : ITaxable
    {
        public abstract double GetTax();

        public double GetTaxAmount(double price, int quantity)
        {
            var appliedTaxes = Math.Round((price * quantity) * GetTax(), 2);
            return (Math.Ceiling(appliedTaxes / 0.05)) * 0.05;
        }
    }
}
