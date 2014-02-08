using NUnrar.Archive;
using SubDownloader.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubDownloader
{
    public partial class FrmPrincipal : Form
    {
        private string pastaDownloads = AppDomain.CurrentDomain.BaseDirectory + "Legendas\\";
        private DataTable _series;

        public DataTable Series
        {
            get
            {
                if (_series == null)
                {
                    _series = new DataTable();
                    _series.Columns.Add(new DataColumn("Serie"));
                    _series.Columns.Add(new DataColumn("Download"));
                    _series.Columns.Add(new DataColumn("Status"));
                    _series.Columns.Add(new DataColumn("ArquivoEpisodio"));
                    _series.Columns.Add(new DataColumn("ArquivoDownload"));
                }

                return _series;
            }
        }

        public FrmPrincipal()
        {
            InitializeComponent();
            txtDiretorioSeries.Text = Settings.Default["DiretorioSeries"].ToString();
        }

        private void btnBaixar_Click(object sender, EventArgs e)
        {
            dgSeries.DataSource = Series;
            Series.Clear();

            if (!Directory.Exists(pastaDownloads))
            {
                Directory.CreateDirectory(pastaDownloads);
            }

            if (Directory.Exists(txtDiretorioSeries.Text))
            {
                BuscaSeriados(txtDiretorioSeries.Text);
            }
            else
            {
                MessageBox.Show(String.Format("Diretório '{0}' inexistente.", txtDiretorioSeries.Text));
            }
        }

        public string TrataNomeArquivo(string nomeArquivo)
        {
            var nomeArquivoTratado = Path.GetFileNameWithoutExtension(nomeArquivo).ToLower();

            foreach (var ignorar in Settings.Default["IgnorarStrings"].ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
            {
                nomeArquivoTratado = nomeArquivoTratado.Replace(ignorar.ToLower(), "");
            }

            return nomeArquivoTratado;
        }

        public void ExtrairLegenda(DataRow dr)
        {
            var extraido = false;
            var arquivoDownload = dr["ArquivoDownload"].ToString();
            var arquivoEpisodio = dr["ArquivoEpisodio"].ToString();

            RarArchive arquivo = RarArchive.Open(arquivoDownload);

            foreach (RarArchiveEntry entry in arquivo.Entries)
            {
                if (TrataNomeArquivo(entry.FilePath) == TrataNomeArquivo(arquivoEpisodio))
                {
                    entry.WriteToFile(txtDiretorioSeries.Text + "\\" + Path.GetFileNameWithoutExtension(arquivoEpisodio) + Path.GetExtension(entry.FilePath));
                    extraido = true;
                    break;
                }
            }

            if (extraido)
            {
                dr["Status"] = "Legenda extraida.";
            }
            else
            {
                dr["Status"] = "Não foi possivel extrair legenda.";
            }
        }

        public void BuscaLegenda(string nomeEpisodio, DataRow dr)
        {
            string urlLegenda = "http://legendas.tv/util/carrega_legendas_busca/termo:{0}/id_idioma:1/sel_tipo:d";
            string urlDownload = "http://legendas.tv/downloadarquivo/{0}";

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();

            using (WebClient webClient = new WebClient())
            {
                try
                {
                    html.LoadHtml(webClient.DownloadString(String.Format(urlLegenda, nomeEpisodio)));

                    string idLegenda = String.Empty;

                    var links = html.DocumentNode.SelectNodes("//p//a[ contains (@href, 'download') ]");

                    if (links == null)
                    {
                        dr["Download"] = "Erro";
                        dr["Status"] = "Legenda não encontrada.";
                    }
                    else
                    {
                        foreach (var link in links)
                        {
                            idLegenda = link.Attributes["href"].Value.Replace("/download/", "");
                            idLegenda = idLegenda.Substring(0, idLegenda.IndexOf('/'));
                        }

                        var uriDownload = new Uri(String.Format(urlDownload, idLegenda));
                        var nomeArquivoDownload = String.Format("{0}{1}.rar", pastaDownloads, idLegenda);

                        dr["ArquivoDownload"] = nomeArquivoDownload;

                        if (!File.Exists(nomeArquivoDownload))
                        {
                            webClient.DownloadFileAsync(uriDownload, nomeArquivoDownload, dr);
                            webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;
                            webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
                        }
                        else
                        {
                            dr["Download"] = "100";
                            ExtrairLegenda(dr);
                        }

                        dgSeries.FirstDisplayedScrollingRowIndex = dgSeries.Rows.Count - 1;
                        dgSeries.Update();
                    }
                }
                catch
                {
                    dr["Download"] = "Erro";
                    dr["Status"] = "Ocorreu um erro na busca da legenda.";
                }
            }
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var dr = e.UserState as DataRow;
            dr["Download"] = e.ProgressPercentage;
        }

        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var dr = e.UserState as DataRow;
            dr["Status"] = "Download Completo!";
        }

        public void ValidaEpisodioSeriado(string diretorio, string arquivo)
        {
            var nomeEpisodio = new Regex("(.*)s\\d\\de\\d\\d", RegexOptions.IgnoreCase).Match(arquivo).Value;

            if (String.IsNullOrEmpty(nomeEpisodio)) return;

            DataRow dr = Series.NewRow();
            dr["Serie"] = nomeEpisodio;
            dr["ArquivoEpisodio"] = arquivo;

            if (Directory.GetFiles(diretorio, nomeEpisodio + "*").Count() > 1)
            {
                dr["Download"] = "Ok";
                dr["Status"] = "Legenda já baixada.";

                if ((bool)Settings.Default["ExibirJaBaixadas"]) Series.Rows.Add(dr);
            }
            else
            {
                Series.Rows.Add(dr);
                BuscaLegenda(nomeEpisodio, dr);
            }
        }

        public void BuscaSeriados(string diretorio)
        {
            var arquivos = Directory.GetFiles(diretorio, "*s*e*")
                                    .Where(a => a.EndsWith(".mkv") || a.EndsWith(".mp4"))
                                    .Select(a => Path.GetFileName(a));

            foreach (var arquivo in arquivos)
            {
                ValidaEpisodioSeriado(diretorio, arquivo);
            }
        }

        private void txtDiretorioSeries_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDiretorioSeries.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDiretorioSeries.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default["DiretorioSeries"] = txtDiretorioSeries.Text;
            Settings.Default.Save();
        }

        private void btnLimparLegendas_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(pastaDownloads))
            {
                Directory.Delete(pastaDownloads, true);
            }

            Directory.CreateDirectory(pastaDownloads);
        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConfiguracao().ShowDialog();
        }
    }
}
