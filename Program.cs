using System;
using System.Collections.Generic;

namespace Excel_27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto();
            p.Codigo = 1;
            p.Nome = "PS5";
            p.Preco = 1800f;

            p.Inserir(p);


            Produto alterado = new Produto();
            alterado.Codigo = 3;
            alterado.Nome = "Xbox 360";
            alterado.Preco = 600f;

            p.Alterar(alterado);
            
            p.Remover("PS5");

            List<Produto> lista = p.Ler();

            foreach (Produto item in lista)
            {
                System.Console.WriteLine($" {p.Preco} - {p.Nome}");
            }
        }
    }
}
