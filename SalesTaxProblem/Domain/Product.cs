namespace SalesTaxProblem.Domain
{
    public class Product
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Origin Origin { get; }
        public ProductType Kind { get; }

        public Product(int quantity, string name, double price, ProductType kind, Origin origin)
        {
            Quantity = quantity;
            Name = name;
            Price = price;
            Kind = kind;
            Origin = origin;
        }
    }
}
