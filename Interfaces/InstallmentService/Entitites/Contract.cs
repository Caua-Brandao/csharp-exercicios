using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallmentService.Entitites
{
    internal class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installments { get; set; } = new List<Installment>();

        public Contract()
        {
        }

        public Contract(int number, DateTime date, double totalvalue)
        {
            this.Number = number;
            this.Date = date;
            this.TotalValue = totalvalue;
        }


    }
}
