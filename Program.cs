using System;
using System.Collections.Generic;

namespace Excel_27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto();
            p.Codigo = 2;
            p.Nome = "PS5";
            p.Preco = 2000f;
            p.Inserir(p);

            p.Remover("PS4");


            List<Produto> lista = new List<Produto>();
            lista = p.Ler();

            foreach (Produto item in lista)
            {
                System.Console.WriteLine($" {p.Preco} - {p.Nome}");
            }
        }
    }
}
