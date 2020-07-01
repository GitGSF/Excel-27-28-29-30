using System;
using System.IO;
using System.Collections.Generic;

namespace Excel_27_28_29_30
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        private const string PATH = "Database/produto.csv";

        public Produto()
        {
            string pasta = PATH.Split('/')[0];
            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }


            //Cria o arquivo caso não exista
            if (!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        public void Inserir(Produto p)
        {
            var linha = new string[] { p.PrepararLinhaCSV(p) };
            File.AppendAllLines(PATH, linha);
        }
        private string PrepararLinhaCSV(Produto produto)
        {
            return $"codigo={produto.Codigo};nome={produto.Nome};preço={produto.Preco}";
        }

        // Criamos lista 
        List<Produto> prod = new List<Produto>();

        public List<Produto> Ler()
        {
            string[] linhas = File.ReadAllLines(PATH);

            // Dados novos produtos
            foreach (string linha in linhas)
            {
                string[] dados = linha.Split(";");

                Produto p = new Produto();
                p.Codigo = Int32.Parse(dados[0].Split("=")[1]);
                p.Nome = dados[1].Split("=")[1];
                p.Preco = float.Parse(dados[2].Split("=")[1]);

                prod.Add(p);
            }
            return prod;
        }
        public string Separar(string dados)
        {
            // codigo=1
            // [0] = codigo
            // [1] = 1
            return dados.Split("=")[1];
        }
        private string PrepararLinha(Produto p)
        {
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }
    }
}