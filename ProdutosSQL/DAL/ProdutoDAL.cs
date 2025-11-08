using System.Collections.Generic;
using ProdutosSQL.Models;

namespace ProdutosSQL.DAL
{
    internal class ProdutoDAL
    {
        private readonly Conexao conexao;
        private readonly DAL dal;

        public ProdutoDAL(Conexao conexao)
        {
            this.conexao = conexao;
            this.dal = new DAL(conexao);
        }

        public void Inserir(Produto produto)
        {
            dal.Inserir(produto);
        }

        public List<Produto> CarregarProdutos()
        {
            return dal.Ler<Produto>();
        }
    }
}
