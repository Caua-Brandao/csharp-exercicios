namespace Products.Entities
{
    internal class ImportedProduct : Product
    {
        public double CustomFee { get; set; }

        public ImportedProduct()
        {
        }
        public ImportedProduct(string name, double price, double customfree) : base(name, price)
        {
            this.CustomFee = customfree;
        }

        public override string PriceTag()
        {
            return base.PriceTag() +
                " (Custom free: $ " +
                CustomFee.ToString("F2") +
                ")";
        }

        public void TotalPrice(double customfree)
        {
            Price += customfree;
        }
    }
}
