using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentService.Entitites
{
    internal class Installment
    {
        public DateTime DueDate { get; set; }
        public double Amount { get; set; }

        public Installment(DateTime duedate, double amount)
        {
            this.DueDate = duedate;
            this.Amount = amount;
        }

    }
}
