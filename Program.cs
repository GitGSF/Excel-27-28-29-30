using System;

namespace Excel_27_28_29_30
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p1 = new Produto();
            p1.Codigo = 1;
            p1.Nome = "PS5";
            p1.Preco = 5000.00f;

            p1.Inserir(p1);
        }
    }
}
