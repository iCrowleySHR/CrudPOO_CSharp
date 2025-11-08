using ProdutosSQL.DAL;
using ProdutosSQL.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProdutosSQL
{
    public partial class Form1 : Form
    {
        private readonly ProdutoDAL produtoDAL;
        private readonly Conexao conexao = new Conexao();

        public Form1()
        {
            InitializeComponent();
            produtoDAL = new ProdutoDAL(conexao);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarProdutosNoGrid();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCadProdutos form = new FormCadProdutos();
            form.ProdutoCadastrado += (s, args) => CarregarProdutosNoGrid();
            form.Show();
        }

        public void CarregarProdutosNoGrid()
        {
            List<Produto> produtos = produtoDAL.CarregarProdutos();
            dgvProdutos.DataSource = produtos;

            dgvProdutos.Columns["IdProduto"].HeaderText = "Código";
            dgvProdutos.Columns["Nome_Produto"].HeaderText = "Produto";

            dgvProdutos.Columns["Preco_Normal"].HeaderText = "Preço Normal (R$)";
            dgvProdutos.Columns["Preco_Normal"].DefaultCellStyle.Format = "C2";

            dgvProdutos.Columns["Preco_Desconto"].HeaderText = "Preço com Desconto (R$)";
            dgvProdutos.Columns["Preco_Desconto"].DefaultCellStyle.Format = "C2";

            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
