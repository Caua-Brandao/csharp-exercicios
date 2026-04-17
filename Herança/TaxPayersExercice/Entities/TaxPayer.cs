
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxPayersExercice.Entities
{
    abstract class TaxPayer
    {
        public string Name { get; set; }
        public double AnualIncome { get; set; }

        public TaxPayer()
        {
        }
        public TaxPayer(string name, double anualincome)
        {
            this.Name = name;
            this.AnualIncome = anualincome;  
        }
        public abstract double Tax();
    }
}
