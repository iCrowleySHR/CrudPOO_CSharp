namespace ProdutosSQL
{
    partial class FormCadProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.inputPrecoDesconto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inputPrecoNormal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.inputNomeProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(63, 216);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(75, 23);
            this.btnCadastrar.TabIndex = 13;
            this.btnCadastrar.Text = "Cadastrar";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // inputPrecoDesconto
            // 
            this.inputPrecoDesconto.Location = new System.Drawing.Point(63, 178);
            this.inputPrecoDesconto.Name = "inputPrecoDesconto";
            this.inputPrecoDesconto.Size = new System.Drawing.Size(254, 20);
            this.inputPrecoDesconto.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Preço com Desconto:";
            // 
            // inputPrecoNormal
            // 
            this.inputPrecoNormal.Location = new System.Drawing.Point(63, 120);
            this.inputPrecoNormal.Name = "inputPrecoNormal";
            this.inputPrecoNormal.Size = new System.Drawing.Size(254, 20);
            this.inputPrecoNormal.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Preço Normal:";
            // 
            // inputNomeProduto
            // 
            this.inputNomeProduto.Location = new System.Drawing.Point(63, 68);
            this.inputNomeProduto.Name = "inputNomeProduto";
            this.inputNomeProduto.Size = new System.Drawing.Size(254, 20);
            this.inputNomeProduto.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome do Produto:";
            // 
            // FormProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.inputPrecoDesconto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.inputPrecoNormal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputNomeProduto);
            this.Controls.Add(this.label1);
            this.Name = "FormProdutos";
            this.Text = "FormProdutos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.TextBox inputPrecoDesconto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputPrecoNormal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputNomeProduto;
        private System.Windows.Forms.Label label1;
    }
}