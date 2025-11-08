using ProdutosSQL.DAL;
using ProdutosSQL.Models;
using System;
using System.Windows.Forms;

namespace ProdutosSQL
{
    public partial class FormEditarExcluirProduto : Form
    {
        private readonly ProdutoDAL produtoDAL;
        private Produto produtoSelecionado;

        public FormEditarExcluirProduto(Produto produto)
        {
            InitializeComponent();
            produtoDAL = new ProdutoDAL(new Conexao());
            produtoSelecionado = produto;

            PreencherCampos();
        }

        private void PreencherCampos()
        {
            inputId.Text = produtoSelecionado.IdProduto.ToString();
            inputNome.Text = produtoSelecionado.Nome_Produto;
            inputPrecoNormal.Text = produtoSelecionado.Preco_Normal.ToString("F2");
            inputPrecoDesconto.Text = produtoSelecionado.Preco_Desconto.ToString("F2");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                produtoSelecionado.Nome_Produto = inputNome.Text;
                produtoSelecionado.Preco_Normal = decimal.Parse(inputPrecoNormal.Text);
                produtoSelecionado.Preco_Desconto = decimal.Parse(inputPrecoDesconto.Text);

                produtoDAL.Editar(produtoSelecionado);
                MessageBox.Show("Produto atualizado com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar produto: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Tem certeza que deseja excluir este produto?",
                    "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    produtoDAL.Excluir(produtoSelecionado.IdProduto);
                    MessageBox.Show("Produto excluído com sucesso!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto: " + ex.Message);
            }
        }
    }
}
