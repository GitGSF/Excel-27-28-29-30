using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Excel_27_28_29_30
{
    public class Produto : IProduto
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
        //Inserir um novo produto a lista
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
       public List<Produto> Ler()
        {
            // Guardar retorno
            List<Produto> prod = new List<Produto>();

            string[] linhas = File.ReadAllLines(PATH);

            // Varrer linhas
            foreach(string linha in linhas)
            {
                string[] dado = linha.Split(";");

                Produto p   = new Produto();
                p.Codigo    = Int32.Parse( Separar(dado[0]) );
                p.Nome      = Separar(dado[1]);
                p.Preco     = float.Parse( Separar(dado[2]) );

                prod.Add(p);
            }

            prod = prod.OrderBy(z => z.Nome).ToList();

            return prod;
        }

         /// Altera produto
           public void Alterar(Produto produtoAlterado){

            // Criamos uma lista de linhas para fazer uma espécie de backup 
            // na memória do sistema
            List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha);
                }
            }
            linhas.RemoveAll(z => z.Split(";")[0].Split("=")[1] == produtoAlterado.Codigo.ToString());

            linhas.Add( PrepararLinha( produtoAlterado ) );

            using (StreamWriter output = new StreamWriter(PATH))
            {
                output.Write(String.Join(Environment.NewLine, linhas.ToArray()));
            }

            
        }        

        //filtrar os produtos
        public List<Produto> Filtrar(string _nome)
        {
            return Ler().FindAll(x => x.Nome == _nome);
        }

        public void Remover(string _termo)
        {
            // Criamos uma lista de linhas para fazer "Backup"
            List<string> linhas = new List<string>();


            using (StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while ((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }

                linhas.RemoveAll(z => z.Contains(_termo));
            }

            // Reescrever sem linhas vazias
            using (StreamWriter output = new StreamWriter(PATH))
            {
                foreach (string ln in linhas)
                {
                    output.Write(ln + "\n");
                }
            }
        }

    
        /// <summary>
        /// Ler as linhas para remoção dos produtos
        /// </summary>
        /// <param name="linhas">linha que contém informações do produto</param>
        public void LerLinhas(List<string> linhas)
        {
            using (StreamReader arquivo = new StreamReader(PATH))
            {

                string linha;

                while ((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }

            }
        }
        public string Separar(string dados)
        {
            // codigo=1
            // [0] = codigo
            // [1] = 1
            return dados.Split("=")[1];
        }
        
        /// <summary>
        /// Reescreve uma linha dentro da lista 
        /// </summary>
        /// <param name="linhas">linha que contém informações do produto</param>
        public void ReescreverCSV(List<string> linhas)
        {
            using (StreamWriter output = new StreamWriter(PATH))
            {
                foreach (string ln in linhas)
                {
                    output.Write(ln + "\n");
                }
            }
        }

        private string PrepararLinha(Produto p)
        {
            return $"codigo={p.Codigo};nome={p.Nome};preco={p.Preco}";
        }
    }
}