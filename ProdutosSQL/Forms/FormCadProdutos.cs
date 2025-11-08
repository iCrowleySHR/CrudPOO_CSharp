using ProdutosSQL.DAL;
using ProdutosSQL.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
                LimparInputs();
                MessageBox.Show("Produto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }

        private void LimparInputs()
        {
            inputNomeProduto.Text = "";
            inputPrecoDesconto.Text = "";
            inputPrecoNormal.Text = "";
        }

    }
}
