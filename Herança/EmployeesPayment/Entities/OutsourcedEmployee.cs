using System.Security;
using System.Security.Cryptography;

namespace EmployeesPayment.Entities
{
    internal class OutsourcedEmployee : Employee
    {
        public double AddicionalCharge { get; set; }

        public OutsourcedEmployee()
        {
        }

        public OutsourcedEmployee(string name, int hours, double valueperhour, double adicionalcharge) : base(name, hours, valueperhour)
        {
            AddicionalCharge = adicionalcharge;
        }

        public override double Payment()
        {
            return (base.Payment() + (AddicionalCharge * 1.1));
        }
    }
}
