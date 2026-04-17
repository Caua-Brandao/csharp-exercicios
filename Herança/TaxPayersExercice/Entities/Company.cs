namespace TaxPayersExercice.Entities
{
    internal class Company : TaxPayer
    {
        public int NumberofEmployees { get; set; }

        public Company()
        {
        }
        public Company(string name, double anualincome, int numberofemployees):base(name, anualincome)
        {
            this.NumberofEmployees = numberofemployees;
        }

        public override double Tax()
        {
            double tax = AnualIncome * 0.16;
            if (NumberofEmployees >10)
            {
                tax = AnualIncome * 0.14;
            }
            return tax;
        }
    }
}
