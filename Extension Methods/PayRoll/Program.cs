using PayRoll.Entities;
using PayRoll.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Maria Silva Souza", 5200, new DateTime(2019, 4, 10));
            Employee emp2 = new Employee("Ana Beatriz Lima Costa", 8750, new DateTime(2015, 1, 23));
            Employee emp3 = new Employee("Carlos Andrade", 3100.50, new DateTime(2021, 9, 01));
            List<Employee> employees = new List<Employee> { emp1, emp2, emp3 };

            Console.WriteLine("=== FOLHA DE PAGAMENTO ===");
            Console.WriteLine();

            Console.WriteLine(emp1.Name + " (" + emp1.Name.Initials() + ") - " + emp1.Salary.ToBRL() + " - " + emp1.HireDate.YearsOfService(DateTime.Now) + " anos de casa");
            Console.WriteLine(emp2.Name + " (" + emp2.Name.Initials() + ") - " + emp2.Salary.ToBRL() + " - " + emp2.HireDate.YearsOfService(DateTime.Now) + " anos de casa");
            Console.WriteLine(emp3.Name + " (" + emp3.Name.Initials() + ") - " + emp3.Salary.ToBRL() + " - " + emp3.HireDate.YearsOfService(DateTime.Now) + " anos de casa");
            Console.WriteLine("\n\nTotal da folha: " + (employees.TotalPayroll()).ToBRL());


            Console.WriteLine("Aplicando 10% de aumento pra quem tem 5 ou mais anos de casa");

            foreach(Employee emp in employees)
            {
                if (emp.HireDate.YearsOfService(DateTime.Now) >=5)
                {
                    emp.IncreaseSalary(10);
                }
            }
            Console.WriteLine();

            foreach(Employee emp in employees)
            {
                Console.WriteLine(emp.Name + " - " + emp.Salary.ToBRL());
            }

            Console.WriteLine("Novo total da folha: " + employees.TotalPayroll().ToBRL());
        }
    }
}
