using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace exercicio_conta_bancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria A;
            Console.Write("Número da conta: ");
            int numero_conta = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome do titular: ");
            string titular = Console.ReadLine();
            Console.Write("Haverá depósito inicial? (S/N): ");
            string resposta = Console.ReadLine();
            if (resposta == "S" || resposta == "s")
            {
                Console.Write("Qual o valor do depósito incial: ");
                double saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                A = new ContaBancaria(numero_conta, titular, saldo);
            }
            else
            {
                A = new ContaBancaria(numero_conta, titular);
            }
            Console.WriteLine("Dados da conta: " + A);
            Console.Write("Qual o valor do depósito: ");
            double deposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            A.Depositar(deposito);
            Console.WriteLine("Dados atualizados:\n" + A);
            Console.Write("Valor do saque: ");
            double saque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            A.Sacar(saque);
            Console.WriteLine("Dados atualizados: \n" + A);
        }
    }
    public class ContaBancaria
    {
        string Titular;
        int Numero_conta;
        double Saldo;
        public ContaBancaria(int numero_conta, string titular)
        {
            Numero_conta = numero_conta;
            Titular = titular;
        }
        public ContaBancaria(int numero_conta, string titular, double saldo_inicial)
        {
            Numero_conta = numero_conta;
            Titular = titular;
            Saldo = saldo_inicial;
        }
        public double Depositar(double deposito)
        {
            return Saldo += deposito;
        }
        public double Sacar(double saque)
        {
            return Saldo -= (saque + 5.0);
        }
        public override string ToString()
        {
            return "Conta: " +
                Numero_conta +
                "\nTitular: " +
                Titular +
                "\nSaldo: " +
                Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
