using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace encapsulamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaBancaria A;
            Console.Write("Entre o Número da conta: ");
            int numeroconta = int.Parse(Console.ReadLine());
            Console.Write("Entre o titular da conta: ");
            string titular = Console.ReadLine();
            Console.Write("Haverá depósito incial? (S/N): ");
            string resposta = Console.ReadLine();
            if (resposta == "S" || resposta == "s")
            {
                Console.Write("Qual o valor do deposito inicial: ");
                double depositoinicial = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                A = new ContaBancaria(titular, depositoinicial, numeroconta);
            }
            else
            {
                A = new ContaBancaria(titular, numeroconta);
            }
            Console.WriteLine("Dados da conta: " + A);
            Console.Write("Entre com um valor para deposito: ");
            double deposito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            A.Deposito(deposito);
            Console.WriteLine($"Dados da conta atualizados: " + A);
            Console.Write("Entre com um valor para o saque: ");
            double saque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            A.Saque(saque);
            Console.WriteLine("Dados da conta atualizados: " + A);
        }
    }
    internal class ContaBancaria
    {
        private string _nome;
        private double _saldo;
        public int NumeroConta { get; private set; }

        public ContaBancaria(string nome, int numeroconta)
        {
            this._nome = nome;
            this.NumeroConta = numeroconta;
        }
        public ContaBancaria(string nome, double saldo, int NumeroConta) : this(nome, NumeroConta)
        {
            this._saldo = saldo;
        }
        
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (value != null && value.Length > 1)
                {
                    _nome = value;
                }
            }
        }
        public double Saldo
        {
            get { return _saldo; }
        }
        public void Deposito(double deposito)
        {
            _saldo += deposito;
        }
        public void Saque(double saque)
        {
            _saldo -= (saque + 5);
        }
        public override string ToString()
        {
            return "Nome: " +
                _nome +
                ".  Número da conta: " +
                NumeroConta +
                ".  Saldo: " +
                _saldo;
        }
    }
}
