using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbPSCReAlpha
{
    class ClPbWebClient : WebClient
    {
        ClPbProgessBarLabeled _pbl;
        Timer _tm;
        SimpleLogger slLogger;
        Uri _srcFileUri;
        String _dstFile;
        bool _started;
        bool _ended;
        long _fileSize;

        public bool Started { get => _started; set => _started = value; }
        public long FileSize { get => _fileSize; set => _fileSize = value; }
        public bool Ended { get => _ended; set => _ended = value; }

        public ClPbWebClient(ClPbProgessBarLabeled pbl, SimpleLogger sl, String sSrcFile, String sDstFile)
        {
            _started = false;
            _ended = false;
            _pbl = pbl;
            slLogger = sl;
            _srcFileUri = new Uri(sSrcFile);
            try
            {
                if (File.Exists(sSrcFile))
                {
                    FileInfo myfile = new FileInfo(sSrcFile);
                    _fileSize = myfile.Length;
                }
            }
            catch(Exception ex)
            {
                _fileSize = 0;
                slLogger.Fatal(ex.Message);
            }
            _dstFile = sDstFile;
            this.DownloadProgressChanged += DownloadProgress;
            this.DownloadFileCompleted += DisableProgressBar;
            _tm = new Timer();
            _tm.Interval = 5000;
            _tm.Enabled = false;
            _tm.Tick += HideLine;
        }

        private void HideLine(object sender, EventArgs e)
        {
            _pbl.PbPanel.Visible = false;
            _pbl.PbProgressBar.Visible = false;
            _pbl.PbLabel.Visible = false;
            _tm.Enabled = false;
        }

        private void DisableProgressBar(object sender, AsyncCompletedEventArgs e)
        {
            slLogger.Debug("Copy OK: " + _pbl.PbLabel.Text);
            _ended = true;
            _started = false;
            _tm.Enabled = true;
        }

        void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            _pbl.PbProgressBar.Value = e.ProgressPercentage;
        }

        public void StartDownload()
        {
            _ended = false;
            _started = true;
            this.DownloadFileAsync(_srcFileUri, _dstFile);
        }
    }
}
