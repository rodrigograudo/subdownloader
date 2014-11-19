using SharpCompress.Archive;
using SubDownloader.Properties;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SubDownloader
{
    public partial class FrmPrincipal : Form
    {
        private string pastaDownloads = AppDomain.CurrentDomain.BaseDirectory + "Legendas\\";
        private BindingList<Episodio> episodios;
        private Cookie cookieAuth = null;

        public FrmPrincipal()
        {
            InitializeComponent();
            txtDiretorioSeries.Text = Settings.Default["DiretorioSeries"].ToString();

            episodios = new BindingList<Episodio>();
            dgvEpisodios.DataSource = episodios;
        }

        private void btnBaixar_Click(object sender, EventArgs e)
        {
            episodios.Clear();

            if (!Directory.Exists(pastaDownloads))
            {
                Directory.CreateDirectory(pastaDownloads);
            }

            if (Directory.Exists(txtDiretorioSeries.Text))
            {
                BuscaSeriados(txtDiretorioSeries.Text);

                if (episodios.Count > 0)
                {
                    if (Login())
                    {
                        foreach (var episodio in episodios)
                        {
                            BuscaLegenda(episodio);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(String.Format("Diretório '{0}' inexistente.", txtDiretorioSeries.Text));
            }
        }

        private bool Login()
        {
            using (WebClientPlus webClient = new WebClientPlus())
            {
                try 
                {
                    var dadosLogin = new NameValueCollection();
                    dadosLogin.Add("_method", "POST");
                    dadosLogin.Add("data[User][username]", Settings.Default["Login"].ToString());
                    dadosLogin.Add("data[User][password]", Settings.Default["Senha"].ToString());
                    dadosLogin.Add("data[lembrar]", "on");

                    webClient.IgnoreRedirects = true;
                    webClient.UploadValues("http://legendas.tv/login", "POST", dadosLogin);
                    var cookie = webClient.ResponseHeaders["Set-Cookie"];
                    cookieAuth = new Cookie("au", cookie.Substring(cookie.LastIndexOf("au=") + 3, cookie.IndexOf(";", cookie.LastIndexOf("au=")) - (cookie.LastIndexOf("au=") + 3)), "/", "legendas.tv");
                    return true;
                }
                catch
                {
                    MessageBox.Show("Ocorreu um erro ao logar no site do Legendas.tv");
                    return false;
                }
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

        public void ExtrairLegenda(Episodio episodio)
        {
            var extraido = false;

            try
            {
                using (var arquivo = ArchiveFactory.Open(episodio.ArquivoDownload))
                {
                    foreach (var entry in arquivo.Entries)
                    {
                        if (TrataNomeArquivo(entry.FilePath) == TrataNomeArquivo(episodio.ArquivoEpisodio))
                        {
                            entry.WriteToFile(txtDiretorioSeries.Text + "\\" + Path.GetFileNameWithoutExtension(episodio.ArquivoEpisodio) + Path.GetExtension(entry.FilePath));
                            episodio.Status = "Legenda extraida.";
                            extraido = true;
                            break;
                        }
                    }
                }
            }
            catch
            {
                episodio.Status = "Ocorreu um erro ao extrair a legenda.";
            }

            if (!extraido)
            {
                episodio.Status = "Não foi possivel extrair legenda.";
            }
        }

        public async void BuscaLegenda(Episodio episodio)
        {
            string urlLegenda = "http://legendas.tv/util/carrega_legendas_busca/{0}/1/d";
            string urlDownload = "http://legendas.tv/downloadarquivo/{0}";

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();

            using (WebClientPlus webClient = new WebClientPlus())
            {
                try
                {
                    webClient.OutboundCookies.Add(cookieAuth);
                    var htmlString = await webClient.DownloadStringTaskAsync(String.Format(urlLegenda, episodio.Nome));
                    html.LoadHtml(htmlString);

                    string idLegenda = String.Empty;

                    var links = html.DocumentNode.SelectNodes("//p//a[ contains (@href, 'download') ]");

                    if (links == null)
                    {
                        episodio.Download = "Erro";
                        episodio.Status = "Legenda não encontrada.";
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

                        episodio.ArquivoDownload = nomeArquivoDownload;

                        if (!File.Exists(nomeArquivoDownload))
                        {
                            webClient.DownloadFileAsync(uriDownload, nomeArquivoDownload, episodio);
                            webClient.DownloadFileCompleted += webClient_DownloadFileCompleted;
                            webClient.DownloadProgressChanged += webClient_DownloadProgressChanged;
                        }
                        else
                        {
                            episodio.Download = "100";
                            ExtrairLegenda(episodio);
                        }

                        dgvEpisodios.FirstDisplayedScrollingRowIndex = dgvEpisodios.Rows.Count - 1;
                        dgvEpisodios.Update();
                    }
                }
                catch
                {
                    episodio.Download = "Erro";
                    episodio.Status = "Ocorreu um erro na busca da legenda.";
                }
            }
        }

        void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var episodio = e.UserState as Episodio;
            episodio.Download = e.ProgressPercentage.ToString();
        }

        void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var episodio = e.UserState as Episodio;
            episodio.Status = "Download Completo!";

            ExtrairLegenda(episodio);
        }

        public void ValidaEpisodioSeriado(string diretorio, string arquivo)
        {
            var nomeEpisodio = new Regex("(.*)s\\d\\de\\d\\d", RegexOptions.IgnoreCase).Match(arquivo).Value;

            if (String.IsNullOrEmpty(nomeEpisodio)) return;

            var episodio = new Episodio();
            episodio.Nome = nomeEpisodio.Replace('.', ' ');
            episodio.ArquivoEpisodio = arquivo;

            if (Directory.GetFiles(diretorio, nomeEpisodio + "*").Count() > 1)
            {
                episodio.Download = "Ok";
                episodio.Status = "Legenda já baixada.";

                if ((bool)Settings.Default["ExibirJaBaixadas"]) episodios.Add(episodio);
            }
            else
            {
                episodios.Add(episodio);
            }
        }

        public void BuscaSeriados(string diretorio)
        {
            var arquivos = Directory.GetFiles(diretorio, "*s*e*")
                                    .Where(a => a.EndsWith(".mkv") || a.EndsWith(".mp4"))
                                    .Select(a => a);

            foreach (var arquivo in arquivos)
            {
                ValidaEpisodioSeriado(Path.GetDirectoryName(arquivo), Path.GetFileName(arquivo));
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
                var pastaDownlaodsInfo = new DirectoryInfo(pastaDownloads);

                foreach (var file in pastaDownlaodsInfo.GetFiles())
                {
                    file.Delete();
                }
            }

            Directory.CreateDirectory(pastaDownloads);
        }

        private void configuraçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConfiguracao().ShowDialog();
        }

        private void dgSeries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var episodio = episodios[e.RowIndex];
            if (!String.IsNullOrEmpty(episodio.ArquivoDownload))
            {
                var processInfo = new ProcessStartInfo(episodio.ArquivoDownload);
                Process process = new Process();
                process.StartInfo = processInfo;
                process.Start();
            }
            else
            {
                MessageBox.Show("Legenda não encontrada.");
            }
        }
    }
}
