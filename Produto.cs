using System;
using System.IO;

namespace Excel_27_28_29_30
{
    public class Produto
    {
        public int Codigo {get; set;}
        public string Nome {get; set;}
        public float Preco {get; set;}
        
        private const string PATH = "DataBase/Produto.csv";

        public Produto()
        {
            //Cria o arquivo caso não exista
            if(!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }
            //Cria o arquivo caso não exista
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }
        public void Inserir(Produto p){
            var linha = new string [] { p.PrepararLinhaCSV(p)};
            File.AppendAllLines(PATH, linha);
        }
        private string PrepararLinhaCSV(Produto produto){
            return $"codigo={produto.Codigo};nome={produto.Nome};preço={produto.Preco}";
        }
    }
}