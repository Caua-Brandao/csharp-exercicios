

namespace Funcionarios.Entities
{
    internal class SalariedEmployee : Employee
    {
        public double MonthSalary { get; set; }
        public double Bonus { get; set; }

        public SalariedEmployee()
        {
        }

        public SalariedEmployee(string name, Department department, double monthsalary, double bonus): base(name, department)
        {
            this.MonthSalary = monthsalary;
            this.Bonus = bonus;
        }

        public override double CalculatePayment()
        {
            return MonthSalary + (MonthSalary * (Bonus / 100));
        }
        public override string GetInfo()
        {
            return Name + " - " + Department + " - " + "Payment: R$ " + CalculatePayment()
                + "\nSalariedEmployee: : R$" + MonthSalary + " + " + Bonus + "% bônus";
        }
    }
}
