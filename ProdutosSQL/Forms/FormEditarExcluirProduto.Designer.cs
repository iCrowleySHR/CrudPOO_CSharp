namespace ProdutosSQL
{
    partial class FormEditarExcluirProduto
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
            this.inputId = new System.Windows.Forms.TextBox();
            this.inputNome = new System.Windows.Forms.TextBox();
            this.inputPrecoNormal = new System.Windows.Forms.TextBox();
            this.inputPrecoDesconto = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputId
            // 
            this.inputId.Location = new System.Drawing.Point(52, 59);
            this.inputId.Name = "inputId";
            this.inputId.ReadOnly = true;
            this.inputId.Size = new System.Drawing.Size(100, 20);
            this.inputId.TabIndex = 0;
            // 
            // inputNome
            // 
            this.inputNome.Location = new System.Drawing.Point(52, 104);
            this.inputNome.Name = "inputNome";
            this.inputNome.Size = new System.Drawing.Size(199, 20);
            this.inputNome.TabIndex = 1;
            // 
            // inputPrecoNormal
            // 
            this.inputPrecoNormal.Location = new System.Drawing.Point(52, 153);
            this.inputPrecoNormal.Name = "inputPrecoNormal";
            this.inputPrecoNormal.Size = new System.Drawing.Size(199, 20);
            this.inputPrecoNormal.TabIndex = 2;
            // 
            // inputPrecoDesconto
            // 
            this.inputPrecoDesconto.Location = new System.Drawing.Point(52, 196);
            this.inputPrecoDesconto.Name = "inputPrecoDesconto";
            this.inputPrecoDesconto.Size = new System.Drawing.Size(199, 20);
            this.inputPrecoDesconto.TabIndex = 3;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(51, 237);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(147, 237);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 5;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 88);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nome do Produto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Preço Normal:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Preço com Desconto:";
            // 
            // FormEditarExcluirProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.inputPrecoDesconto);
            this.Controls.Add(this.inputPrecoNormal);
            this.Controls.Add(this.inputNome);
            this.Controls.Add(this.inputId);
            this.Name = "FormEditarExcluirProduto";
            this.Text = "FormEditarExcluirProduto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputId;
        private System.Windows.Forms.TextBox inputNome;
        private System.Windows.Forms.TextBox inputPrecoNormal;
        private System.Windows.Forms.TextBox inputPrecoDesconto;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}