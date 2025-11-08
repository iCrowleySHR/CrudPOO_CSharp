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

        public event EventHandler ProdutoCadastrado;

        public FormCadProdutos()
        {
            InitializeComponent();
            produtoDAL = new ProdutoDAL(conexao);
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal precoNormal = decimal.Parse(inputPrecoNormal.Text);
                decimal porcentagem = decimal.Parse(inputPorcentagemDesconto.Text);
                decimal precoComDesconto = precoNormal - (precoNormal * (porcentagem / 100));

                Produto produto = new Produto
                {
                    Nome_Produto = inputNomeProduto.Text,
                    Preco_Normal = precoNormal,
                    Preco_Desconto = precoComDesconto
                };

                produtoDAL.Inserir(produto);
                LimparInputs();
                lblPrecoComDesconto.Text = "Preço com desconto: R$ 0,00";
                ProdutoCadastrado?.Invoke(this, EventArgs.Empty);
                MessageBox.Show("Produto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
        }

        private void inputPorcentagemDesconto_TextChanged(object sender, EventArgs e)
        {
            AtualizarPrecoComDesconto();
        }

        private void inputPrecoNormal_TextChanged(object sender, EventArgs e)
        {
            AtualizarPrecoComDesconto();
        }

        private void AtualizarPrecoComDesconto()
        {
            if (decimal.TryParse(inputPrecoNormal.Text, out decimal precoNormal) &&
                decimal.TryParse(inputPorcentagemDesconto.Text, out decimal porcentagem))
            {
                decimal valorDesconto = precoNormal * (porcentagem / 100);
                decimal precoComDesconto = precoNormal - valorDesconto;

                lblPrecoComDesconto.Text = $"Preço com desconto: {precoComDesconto:C2}";
            }
            else
            {
                lblPrecoComDesconto.Text = "Preço com desconto: R$ 0,00";
            }
        }

        private void LimparInputs()
        {
            inputNomeProduto.Text = "";
            inputPorcentagemDesconto.Text = "";
            inputPrecoNormal.Text = "";
        }
    }
}
