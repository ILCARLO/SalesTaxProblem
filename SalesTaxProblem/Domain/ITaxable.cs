namespace SalesTaxProblem.Domain
{
    public interface ITaxable
    {
        double GetTaxAmount(double price, int quantity);
    }
}
