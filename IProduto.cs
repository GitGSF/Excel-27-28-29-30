using System.Collections.Generic;
namespace Excel_27_28_29_30
{
    public interface IProduto
    {
        List<Produto> Ler();
        void Inserir(Produto prod);
        void Remover(string _termo);
        void Alterar(Produto _produtoAlterado);
    }
}