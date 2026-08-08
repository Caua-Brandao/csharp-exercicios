using System;
using System.Globalization;
using InstallmentService.Entitites;
using InstallmentService.Services;


namespace InstallmentService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ENTER CONTRACT DATA");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Contract value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter the number of installments: ");
            int n = int.Parse(Console.ReadLine());

            Contract cont = new Contract(number, date, value);
            ContractService contService = new ContractService(new PagSeguroService());
            contService.ProcessContract(cont, n);
            Console.WriteLine("INSTALLMENTS");

            foreach(var installment in cont.Installments)
            {
                Console.WriteLine(installment.DueDate.ToString("dd/MM/yyyy") + " - " + installment.Amount);
            }
        }
    }
}
