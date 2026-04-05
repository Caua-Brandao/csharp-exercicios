using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercicio.Funcionario.Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Funcionario Func = new Funcionario();
            Console.Write("Nome: ");
            Func.nome = Console.ReadLine();
            Console.Write("Salário Bruto: ");
            Func.salario_bruto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Imposto: ");
            Func.imposto = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Funcionário: "
                + Func.nome + ", Salário: "
                + Func.SalarioLiquido(Func.salario_bruto, Func.imposto).ToString("F2", CultureInfo.InvariantCulture)
                + "R$");
            Console.Write("Digite a porcentagem pra aumentar o salário: ");
            double porcentagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Func.AumentarSalario(porcentagem);
            Console.WriteLine("Dados atualizados: " +
                Func.nome +
                ", Salário: " +
                Func.SalarioLiquido(Func.salario_bruto, Func.imposto));
        }
    }
    public class Funcionario
    {
        public string nome;
        public double salario_bruto;
        public double imposto;
        public double SalarioLiquido(double salario_bruto, double imposto)
        {
            double salario_liquido = salario_bruto - imposto;
            return salario_liquido;
        }
        public void AumentarSalario(double porcentagem)
        {
            salario_bruto += (porcentagem / 100) * salario_bruto;
        }
    }
}
