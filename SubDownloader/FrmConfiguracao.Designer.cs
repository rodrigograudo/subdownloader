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
            // FrmConfiguracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
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
    }
}