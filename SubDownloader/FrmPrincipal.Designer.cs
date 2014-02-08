namespace SubDownloader
{
    partial class FrmPrincipal
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
            this.btnBaixar = new System.Windows.Forms.Button();
            this.dgSeries = new System.Windows.Forms.DataGridView();
            this.txtDiretorioSeries = new System.Windows.Forms.TextBox();
            this.lblDiretorioSeries = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Download = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLimparLegendas = new System.Windows.Forms.Button();
            this.cbExibirJaBaixadas = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgSeries)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBaixar
            // 
            this.btnBaixar.Location = new System.Drawing.Point(15, 60);
            this.btnBaixar.Name = "btnBaixar";
            this.btnBaixar.Size = new System.Drawing.Size(75, 23);
            this.btnBaixar.TabIndex = 0;
            this.btnBaixar.Text = "Baixar";
            this.btnBaixar.UseVisualStyleBackColor = true;
            this.btnBaixar.Click += new System.EventHandler(this.btnBaixar_Click);
            // 
            // dgSeries
            // 
            this.dgSeries.AllowUserToAddRows = false;
            this.dgSeries.AllowUserToDeleteRows = false;
            this.dgSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Serie,
            this.Download,
            this.Status});
            this.dgSeries.Location = new System.Drawing.Point(12, 93);
            this.dgSeries.Name = "dgSeries";
            this.dgSeries.ReadOnly = true;
            this.dgSeries.RowHeadersVisible = false;
            this.dgSeries.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgSeries.Size = new System.Drawing.Size(863, 358);
            this.dgSeries.TabIndex = 1;
            // 
            // txtDiretorioSeries
            // 
            this.txtDiretorioSeries.Location = new System.Drawing.Point(96, 34);
            this.txtDiretorioSeries.Name = "txtDiretorioSeries";
            this.txtDiretorioSeries.Size = new System.Drawing.Size(777, 20);
            this.txtDiretorioSeries.TabIndex = 2;
            this.txtDiretorioSeries.Click += new System.EventHandler(this.txtDiretorioSeries_Click);
            // 
            // lblDiretorioSeries
            // 
            this.lblDiretorioSeries.AutoSize = true;
            this.lblDiretorioSeries.Location = new System.Drawing.Point(12, 37);
            this.lblDiretorioSeries.Name = "lblDiretorioSeries";
            this.lblDiretorioSeries.Size = new System.Drawing.Size(78, 13);
            this.lblDiretorioSeries.TabIndex = 3;
            this.lblDiretorioSeries.Text = "Diretório Séries";
            // 
            // Serie
            // 
            this.Serie.DataPropertyName = "Serie";
            this.Serie.Frozen = true;
            this.Serie.HeaderText = "Série";
            this.Serie.Name = "Serie";
            this.Serie.ReadOnly = true;
            this.Serie.Width = 300;
            // 
            // Download
            // 
            this.Download.DataPropertyName = "Download";
            this.Download.Frozen = true;
            this.Download.HeaderText = "Download";
            this.Download.Name = "Download";
            this.Download.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.Frozen = true;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 460;
            // 
            // btnLimparLegendas
            // 
            this.btnLimparLegendas.Location = new System.Drawing.Point(96, 60);
            this.btnLimparLegendas.Name = "btnLimparLegendas";
            this.btnLimparLegendas.Size = new System.Drawing.Size(166, 23);
            this.btnLimparLegendas.TabIndex = 4;
            this.btnLimparLegendas.Text = "Limpar Legendas Baixadas";
            this.btnLimparLegendas.UseVisualStyleBackColor = true;
            this.btnLimparLegendas.Click += new System.EventHandler(this.btnLimparLegendas_Click);
            // 
            // cbExibirJaBaixadas
            // 
            this.cbExibirJaBaixadas.AutoSize = true;
            this.cbExibirJaBaixadas.Location = new System.Drawing.Point(268, 64);
            this.cbExibirJaBaixadas.Name = "cbExibirJaBaixadas";
            this.cbExibirJaBaixadas.Size = new System.Drawing.Size(159, 17);
            this.cbExibirJaBaixadas.TabIndex = 5;
            this.cbExibirJaBaixadas.Text = "Exibir Episódios Já Baixados";
            this.cbExibirJaBaixadas.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(885, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraçãoToolStripMenuItem
            // 
            this.configuraçãoToolStripMenuItem.Name = "configuraçãoToolStripMenuItem";
            this.configuraçãoToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.configuraçãoToolStripMenuItem.Text = "Configuração";
            this.configuraçãoToolStripMenuItem.Click += new System.EventHandler(this.configuraçãoToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 463);
            this.Controls.Add(this.cbExibirJaBaixadas);
            this.Controls.Add(this.btnLimparLegendas);
            this.Controls.Add(this.lblDiretorioSeries);
            this.Controls.Add(this.txtDiretorioSeries);
            this.Controls.Add(this.dgSeries);
            this.Controls.Add(this.btnBaixar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubDownloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgSeries)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBaixar;
        private System.Windows.Forms.DataGridView dgSeries;
        private System.Windows.Forms.TextBox txtDiretorioSeries;
        private System.Windows.Forms.Label lblDiretorioSeries;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Download;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button btnLimparLegendas;
        private System.Windows.Forms.CheckBox cbExibirJaBaixadas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraçãoToolStripMenuItem;
    }
}

