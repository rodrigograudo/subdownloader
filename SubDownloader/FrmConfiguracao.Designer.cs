namespace SubDownloader
{
    partial class FrmConfiguracao
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
            this.cbExibirJaBaixadas = new System.Windows.Forms.CheckBox();
            this.txtIgnorar = new System.Windows.Forms.TextBox();
            this.lblIgnorar = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cbExibirJaBaixadas
            // 
            this.cbExibirJaBaixadas.AutoSize = true;
            this.cbExibirJaBaixadas.Location = new System.Drawing.Point(12, 12);
            this.cbExibirJaBaixadas.Name = "cbExibirJaBaixadas";
            this.cbExibirJaBaixadas.Size = new System.Drawing.Size(159, 17);
            this.cbExibirJaBaixadas.TabIndex = 6;
            this.cbExibirJaBaixadas.Text = "Exibir Episódios Já Baixados";
            this.cbExibirJaBaixadas.UseVisualStyleBackColor = true;
            // 
            // txtIgnorar
            // 
            this.txtIgnorar.Location = new System.Drawing.Point(12, 54);
            this.txtIgnorar.Multiline = true;
            this.txtIgnorar.Name = "txtIgnorar";
            this.txtIgnorar.Size = new System.Drawing.Size(260, 195);
            this.txtIgnorar.TabIndex = 7;
            // 
            // lblIgnorar
            // 
            this.lblIgnorar.AutoSize = true;
            this.lblIgnorar.Location = new System.Drawing.Point(13, 35);
            this.lblIgnorar.Name = "lblIgnorar";
            this.lblIgnorar.Size = new System.Drawing.Size(40, 13);
            this.lblIgnorar.TabIndex = 8;
            this.lblIgnorar.Text = "Ignorar";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(12, 261);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(33, 13);
            this.lblLogin.TabIndex = 9;
            this.lblLogin.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(51, 258);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(221, 20);
            this.txtLogin.TabIndex = 10;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(12, 292);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(38, 13);
            this.lblSenha.TabIndex = 11;
            this.lblSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(51, 289);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(221, 20);
            this.txtSenha.TabIndex = 12;
            // 
            // FrmConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 327);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblIgnorar);
            this.Controls.Add(this.txtIgnorar);
            this.Controls.Add(this.cbExibirJaBaixadas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracao";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuração";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmConfiguracao_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbExibirJaBaixadas;
        private System.Windows.Forms.TextBox txtIgnorar;
        private System.Windows.Forms.Label lblIgnorar;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
    }
}