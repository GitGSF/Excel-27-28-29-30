using System;
using System.Collections.Generic;

namespace Excel_27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 2;
            p1.Nome = "PS4";
            p1.Preco = 3000f;

            p1.Inserir(p1);

            List<Produto> lista = p1.Ler();

            foreach (Produto item in lista)
            {
                System.Console.WriteLine($" {p1.Preco} - {p1.Nome}");
            }
        }
    }
}
