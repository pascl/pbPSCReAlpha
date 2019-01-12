using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public ClPbWebClient(ClPbProgessBarLabeled pbl)
        {
            this._pbl = pbl;
            this.DownloadProgressChanged += DownloadProgress;
            this.DownloadFileCompleted += DisableProgressBar;
            _tm = new Timer();
            _tm.Interval = 5000;
            _tm.Enabled = false;
            _tm.Tick += HideLine;
        }

        private void HideLine(object sender, EventArgs e)
        {
            _pbl.PbProgressBar.Visible = false;
            _pbl.PbLabel.Visible = false;
        }

        private void DisableProgressBar(object sender, AsyncCompletedEventArgs e)
        {
            /*_pbl.PbProgressBar.Visible = false;
            _pbl.PbLabel.Visible = false;*/
            _tm.Enabled = true;
        }

        void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            _pbl.PbProgressBar.Value = e.ProgressPercentage;
        }
        
    }
}
