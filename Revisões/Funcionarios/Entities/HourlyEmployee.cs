using System.Runtime.Serialization;

namespace Funcionarios.Entities
{
    internal class HourlyEmployee : Employee
    {
        public int HoursWorked { get; set; }
        public double ValuePerHour { get; set; }

        public HourlyEmployee()
        {
        }

        public HourlyEmployee(string name, Department department, int hoursworked, double valueperhour): base(name, department)
        {
            this.HoursWorked = hoursworked;
            this.ValuePerHour = valueperhour;
        }

        public override double CalculatePayment()
        {
            if (HoursWorked > 160)
            {
                int overtime = HoursWorked - 160;
                double extra = overtime * ValuePerHour * 0.5;
                return HoursWorked * ValuePerHour + extra;
            }
            else
            {
                return HoursWorked * ValuePerHour;
            }
        }

        public override string GetInfo()
        {
            string overtimeInfo = HoursWorked > 160 ? $" + {(HoursWorked - 160)}h extras" : "";
            return $"{Name} - {Department} - Payment: R$ {CalculatePayment()}\n(HourlyEmployee: {HoursWorked}h x R$ {ValuePerHour}{overtimeInfo})";
        }
    }
}
