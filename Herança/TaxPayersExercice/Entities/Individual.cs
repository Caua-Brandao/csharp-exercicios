namespace TaxPayersExercice.Entities
{
    internal class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public Individual()
        {
        }

        public Individual(string name, double anualincome, double healthexpenditures) :base(name, anualincome)
        {
            this.HealthExpenditures = healthexpenditures;
        }

        public override double Tax()
        {
            double tax = 0;
            if (AnualIncome < 20000)
            {
                tax = AnualIncome * 0.15;
            }
            else if (AnualIncome >20000)
            {
                tax = AnualIncome * 0.25;
            }
            if (HealthExpenditures>0)
            {
                tax = tax - (HealthExpenditures * 0.5);
            }
            return tax;
        }
    }
}
