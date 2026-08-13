using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Entities
{
    internal class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }

        public Employee(string name, double salary, DateTime hireDate)
        {
            Name = name;
            Salary = salary;
            HireDate = hireDate;
        }


    }
}
