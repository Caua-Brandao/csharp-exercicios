using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Funcionarios.Entities
{
    internal class ComissionEmployee : Employee
    {
        public double BaseSalary { get; set; }
        public double TotalSales { get; set; }
        public double ComissionRate { get; set; }

        public ComissionEmployee()
        {
        }

        public ComissionEmployee(string name, Department department, double basesalary, double totalsales, double comissionrate): base(name, department)
        {
            this.BaseSalary = basesalary;
            this.TotalSales = totalsales;
            this.ComissionRate = comissionrate;
        }

        public override double CalculatePayment()
        {
            return BaseSalary + (TotalSales * (ComissionRate / 100));
        }

        public override string GetInfo()
        {
            return $"{Name} - {Department} - Payment: R$ {CalculatePayment()}\n(ComissionEmployee: R$ {BaseSalary} + R$ {ComissionRate} comissão";
        }
    }
}
