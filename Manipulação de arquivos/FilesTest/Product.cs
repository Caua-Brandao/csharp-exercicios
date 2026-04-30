
namespace FilesTest
{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int  Quanty { get; set; } 

        public Product(string name, double price, int quanty)
        {
            Name = name;
            Price = price;
            Quanty = quanty;
        }

        public double Total()
        {
            return Price * Quanty;
        }
    }
}
