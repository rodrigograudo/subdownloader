using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubDownloader
{
    public class Episodio : INotifyPropertyChanged
    {
        private string _download;
        private string _status;

        public string Nome { get; set; }
        public string Download { get { return _download; } set { _download = value; NotifyPropertyChanged("Download"); } }
        public string Status { get { return _status; } set { _status = value; NotifyPropertyChanged("Status"); } }
        public string ArquivoEpisodio { get; set; }
        public string ArquivoDownload { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
