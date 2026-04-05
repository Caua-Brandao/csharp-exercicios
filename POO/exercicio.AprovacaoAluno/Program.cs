using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System;

namespace exercicio.AprovacaoAluno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aluno a = new Aluno();
            Console.Write("Nome do aluno: ");
            a.nome = Console.ReadLine();
            Console.WriteLine("Entre com as notas do aluno: ");
            a.nota1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            a.nota2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            a.nota3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            a.NotaFinal(a.nota1, a.nota2, a.nota3);
            Console.WriteLine("Nota final: " + a.nota_final);
            Console.WriteLine("Resultado: " + a.Aprovacao(a.nota_final));
        }
    }
    public class Aluno
    {
        public string nome;
        public double nota1;
        public double nota2;
        public double nota3;
        public double nota_final;
        public void NotaFinal(double nota1, double nota2, double nota3)
        {
            nota_final = nota1 + nota2 + nota3;
        }
        public string Aprovacao(double nota_final)
        {
            string resultado;
            int minimo = 60;
            if (nota_final>=minimo)
            {
                resultado = "aprovado";
            }
            else
            {
                resultado = $"Reprovado, faltaram {(minimo - nota_final).ToString("F2")} pontos";
            }
            return resultado;
        }

    }
}
