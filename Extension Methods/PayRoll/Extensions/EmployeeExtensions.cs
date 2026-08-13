using PayRoll.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Extensions
{
    static class EmployeeExtensions
    {
        public static string ToBRL(this double thisobj)
        {
            return "R$ " + thisobj.ToString("F2", new CultureInfo("pt-BR"));
        }

        public static string Initials(this string FullName)
        {
            string init = "";
            string[] s = FullName.Split(' ');
            foreach(string st in s)
            {
                init += st[0]+".";
            }
            return init;
        }

        public static int YearsOfService(this DateTime hireDate, DateTime reference)
        {
            int years = reference.Year - hireDate.Year;
            if (reference < hireDate.AddYears(years))
            {
                years--;
            }
            return years;
        }

        public static void IncreaseSalary(this Employee obj, double porcentage)
        {
            obj.Salary += (obj.Salary * (porcentage / 100));
        }

        public static double TotalPayroll(this List<Employee> list)
        {
            double total = 0;
            foreach(Employee emp in list)
            {
                total += emp.Salary;
            }
            return total;
        }
    }
}
