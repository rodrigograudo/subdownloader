using SubDownloader.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubDownloader
{
    public partial class FrmConfiguracao : Form
    {
        public FrmConfiguracao()
        {
            InitializeComponent();
            cbExibirJaBaixadas.Checked = (bool)Settings.Default["ExibirJaBaixadas"];
            txtIgnorar.Text = Settings.Default["IgnorarStrings"].ToString();
        }

        private void FrmConfiguracao_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default["ExibirJaBaixadas"] = cbExibirJaBaixadas.Checked;
            Settings.Default["IgnorarStrings"] = txtIgnorar.Text;
            Settings.Default.Save();
        }
    }
}
