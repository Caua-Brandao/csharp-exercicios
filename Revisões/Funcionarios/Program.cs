using Funcionarios.Entities;
using System;
using System.Globalization;

namespace Funcionarios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hourlynumber = 0;
            int salariednumber = 0;
            int comissionnumber = 0;
            Console.Write("How many employees: ");
            int n = int.Parse(Console.ReadLine());
            Employee[] employees = new Employee[n];
            for (int i = 1; i<=n;i++)
            {
                Console.WriteLine("Employee #" + i);
                Console.Write("Type (H-Hourly / S-Salaried / C-Commission): ");
                char type = char.Parse(Console.ReadLine().ToLower());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Department department;
                while (true)
                {
                    Console.Write("Departamento (Sales/IT/HR/Finance): ");
                    string input = Console.ReadLine();
                    if (Enum.TryParse<Department>(input, true, out department))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Tente novamente.");
                    }
                }
                switch (type)
                {
                    case 'h':
                        Console.Write("Worked Hours: ");
                        int workedhours = int.Parse(Console.ReadLine());
                        Console.Write("Value per Hour: ");
                        double valueperhour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        employees[i - 1] = new HourlyEmployee(name, department, workedhours, valueperhour);
                        hourlynumber++;
                        break;
                    case 's':
                        Console.Write("Month Salary: ");
                        double monthsalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Bonus: (%): ");
                        int bonus = int.Parse(Console.ReadLine());
                        employees[i - 1] = new SalariedEmployee(name, department, monthsalary, bonus);
                        salariednumber++;
                        break;
                    case 'c':
                        Console.Write("Base salary: ");
                        double basesalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Total sales: ");
                        double totalsales = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        Console.Write("Comission tax (%): ");
                        int comissiontax = int.Parse(Console.ReadLine());
                        employees[i - 1] = new ComissionEmployee(name, department, basesalary, totalsales, comissiontax);
                        comissionnumber++;
                        break;
                    default:
                        Console.WriteLine("Invalid type. Try again.");
                        i--;
                        continue;
                }
            }
            double sum = 0;
            double higger = 0;
            string higgername = "";
            foreach (Employee emp in employees)
            {
                Console.WriteLine(emp.GetInfo());
                Console.WriteLine();
                sum += emp.CalculatePayment();
                if (emp.CalculatePayment() > higger)
                {
                    higger = emp.CalculatePayment();
                    higgername = emp.Name;
                }
            }
            Console.WriteLine("TOTAL DA FOLHA: R$ " + sum);
            Console.WriteLine();
            Console.WriteLine("MÉDIA GERAL: R$" + (sum / n).ToString("F2"));
            Console.WriteLine();
            Console.WriteLine($"MAIOR PAGAMENTO: {higgername} ({higger})");
            Console.WriteLine();
            Console.WriteLine($"FUNCIONÁRIOS POR TIPO:\nHourly: {hourlynumber}\nSalaried: {salariednumber}\nComission: {comissionnumber}");
            Console.WriteLine();
            Console.WriteLine("MÉDIA POR DEPARTAMENTO:");

            foreach (Department dept in Enum.GetValues(typeof(Department)))
            {
                double deptSum = 0;
                int deptCount = 0;
                foreach (Employee emp in employees)
                {
                    if (emp.Department == dept)
                    {
                        deptSum += emp.CalculatePayment();
                        deptCount++;
                    }
                }
                if (deptCount > 0)
                {
                    double deptAverage = deptSum / deptCount;
                    Console.WriteLine($"  {dept}: R$ {deptAverage:F2}");
                }
            }
        }
    }
}
