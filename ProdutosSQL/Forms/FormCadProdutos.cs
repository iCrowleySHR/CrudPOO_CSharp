using System;
using System.Windows.Forms;
using ProdutosSQL.DAL;
using ProdutosSQL.Models;

namespace ProdutosSQL
{
    public partial class FormCadProdutos : Form
    {
        Conexao conexao = new Conexao();
        ProdutoDAL produtoDAL;

        public FormCadProdutos()
        {
            InitializeComponent();
            produtoDAL = new ProdutoDAL(conexao);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Produto produto = new Produto
                {
                    Nome_Produto = inputNomeProduto.Text,
                    Preco_Desconto = decimal.Parse(inputPrecoDesconto.Text),
                    Preco_Normal = decimal.Parse(inputPrecoNormal.Text)
                };

                produtoDAL.Inserir(produto);
                MessageBox.Show("Produto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }
    }
}
