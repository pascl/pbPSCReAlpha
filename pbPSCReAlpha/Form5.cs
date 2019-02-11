using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbPSCReAlpha
{
    public partial class Form5 : Form
    {
        int _simultaneousCopiedFiles = 2;

        public Form5(int simultaneousCopiedFiles)
        {
            InitializeComponent();

            _simultaneousCopiedFiles = simultaneousCopiedFiles;
        }

        public int SimultaneousCopiedFiles { get => _simultaneousCopiedFiles; set => _simultaneousCopiedFiles = value; }

        public ClPbProgessBarLabeled addNewLine(String sCaption)
        {
            ClPbProgessBarLabeled c1 = new ClPbProgessBarLabeled(tlpFilesCopying);
            c1.setCaption(sCaption);

            if(!tmStartFiles.Enabled)
            {
                tmStartFiles.Enabled = true;
            }

            return c1;
        }

        private void tmAutoHide_Tick(object sender, EventArgs e)
        {
            bool bVisible = false;
            if(tlpFilesCopying.HasChildren)
            {
                foreach(Control c in tlpFilesCopying.Controls)
                {
                    if(c.Visible == true)
                    {
                        bVisible = true;
                    }
                }
                this.Visible = bVisible;
            }
        }

        private void tmStartFiles_Tick(object sender, EventArgs e)
        {
            int iMaxCurrentCount = _simultaneousCopiedFiles;
            long lMaxSizeOverrideCount = 500000; // about 500ko
            bool atLeastOneNotStarted = false;
            int iCurrentCount = 0;
            if (tlpFilesCopying.HasChildren)
            {
                foreach (Control c in tlpFilesCopying.Controls)
                {
                    if ((c.Tag != null) && (c.Tag.GetType() == typeof(ClPbWebClient)))
                    {
                        ClPbWebClient cwc = (ClPbWebClient)(c.Tag);
                        if(cwc.Started && (!cwc.Ended))
                        {
                            iCurrentCount++;
                        }
                        else
                        if ((!cwc.Started) && (!cwc.Ended))
                        {
                            if (cwc.FileSize < lMaxSizeOverrideCount)
                            {
                                cwc.StartDownload();
                                iCurrentCount++;
                            }
                            else
                            {
                                atLeastOneNotStarted = true;
                            }
                        }
                    }
                }
                if((atLeastOneNotStarted) && (iCurrentCount < iMaxCurrentCount))
                {
                    foreach (Control c in tlpFilesCopying.Controls)
                    {
                        if ((c.Tag != null) && (c.Tag.GetType() == typeof(ClPbWebClient)))
                        {
                            ClPbWebClient cwc = (ClPbWebClient)(c.Tag);
                            if ((!cwc.Started) && (!cwc.Ended))
                            {
                                if (iCurrentCount < iMaxCurrentCount)
                                {
                                    cwc.StartDownload();
                                    iCurrentCount++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
