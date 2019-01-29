using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbPSCReAlpha
{
    public partial class Form6 : Form
    {

        String _leftFilename;
        Dictionary<String, String> _dcLeft;
        Dictionary<String, String> _dcRight;
        SimpleLogger slLogger;

        public Form6(String sLeftFilename, Dictionary<String, String> dcLeftContent, Dictionary<String, String> dcRightContent, SimpleLogger sl)
        {
            InitializeComponent();
            _leftFilename = sLeftFilename;
            _dcLeft = dcLeftContent;
            _dcRight = dcRightContent;
            slLogger = sl;

            lbLeftTitle.Text = _dcLeft["title"];
            lbLeftDiscs.Text = _dcLeft["discs"];
            lbLeftPublisher.Text = _dcLeft["publisher"];
            lbLeftPlayers.Text = _dcLeft["players"];
            lbLeftYear.Text = _dcLeft["year"];
            lbLeftAlphaTitle.Text = _dcLeft["alphatitle"];

            lbRightTitle.Text = _dcRight["title"];
            lbRightDiscs.Text = _dcRight["discs"];
            lbRightPublisher.Text = _dcRight["publisher"];
            lbRightPlayers.Text = _dcRight["players"];
            lbRightYear.Text = _dcRight["year"];
            lbRightAlphaTitle.Text = _dcRight["alphatitle"];

            lbMergedTitle.Text = _dcLeft["title"];
            lbMergedDiscs.Text = _dcLeft["discs"];
            lbMergedPublisher.Text = _dcLeft["publisher"];
            lbMergedPlayers.Text = _dcLeft["players"];
            lbMergedYear.Text = _dcLeft["year"];
            lbMergedAlphaTitle.Text = _dcLeft["alphatitle"];

            bool bVisible = false;
            if (_dcLeft["title"] == _dcRight["title"])
            {
                bVisible = false;
            }
            else
            {
                bVisible = true;
            }
            btGoLeftTitle.Visible = bVisible;
            btGoRightTitle.Visible = bVisible;

            if (_dcLeft["discs"] == _dcRight["discs"])
            {
                bVisible = false;
            }
            else
            {
                bVisible = true;
            }
            btGoLeftDiscs.Visible = bVisible;
            btGoRightDiscs.Visible = bVisible;

            if (_dcLeft["publisher"] == _dcRight["publisher"])
            {
                bVisible = false;
            }
            else
            {
                bVisible = true;
            }
            btGoLeftPublisher.Visible = bVisible;
            btGoRightPublisher.Visible = bVisible;

            if (_dcLeft["players"] == _dcRight["players"])
            {
                bVisible = false;
            }
            else
            {
                bVisible = true;
            }
            btGoLeftPlayers.Visible = bVisible;
            btGoRightPlayers.Visible = bVisible;

            if (_dcLeft["year"] == _dcRight["year"])
            {
                bVisible = false;
            }
            else
            {
                bVisible = true;
            }
            btGoLeftYear.Visible = bVisible;
            btGoRightYear.Visible = bVisible;

            if (_dcLeft["alphatitle"] == _dcRight["alphatitle"])
            {
                bVisible = false;
            }
            else
            {
                bVisible = true;
            }
            btGoLeftAlphaTitle.Visible = bVisible;
            btGoRightAlphaTitle.Visible = bVisible;
            
        }

        private void btChooseLeft_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Keep Left file Click");
            // do nothing
            slLogger.Trace("<< Keep Left file Click");
        }

        private void btChooseRight_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Save Right file Click");
            ClPbHelper.SaveGameIni(_leftFilename, _dcRight, slLogger);
            slLogger.Trace("<< Save Right file Click");
        }

        private void btChooseKeepFiles_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Keep 2 files Click");
            String sFilename = _leftFilename + ".bak";
            if (File.Exists(sFilename))
            {
                int i = 0;
                String sFilenameN = sFilename + i.ToString();
                while(File.Exists(sFilenameN))
                {
                    i++;
                    sFilenameN = sFilename + i.ToString();
                }
                sFilename = sFilenameN;
            }
            ClPbHelper.SaveGameIni(sFilename, _dcRight, slLogger);
            slLogger.Trace("<< Keep 2 files Click");
        }

        private void btGoLeftTitle_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy left title Click");
            lbMergedTitle.Text = _dcLeft["title"];
            slLogger.Trace("<< Copy left title Click");
        }

        private void btGoLeftDiscs_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy left discs Click");
            lbMergedDiscs.Text = _dcLeft["discs"];
            slLogger.Trace("<< Copy left discs Click");
        }

        private void btGoLeftPublisher_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy left publisher Click");
            lbMergedPublisher.Text = _dcLeft["publisher"];
            slLogger.Trace("<< Copy left publisher Click");
        }

        private void btGoLeftPlayers_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy left players Click");
            lbMergedPlayers.Text = _dcLeft["players"];
            slLogger.Trace("<< Copy left players Click");
        }

        private void btGoLeftYear_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy left year Click");
            lbMergedYear.Text = _dcLeft["year"];
            slLogger.Trace("<< Copy left year Click");
        }

        private void btGoLeftAlphaTitle_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy left alphatitle Click");
            lbMergedAlphaTitle.Text = _dcLeft["alphatitle"];
            slLogger.Trace("<< Copy left alphatitle Click");
        }

        private void btGoRightTitle_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy right title Click");
            lbMergedTitle.Text = _dcRight["title"];
            slLogger.Trace("<< Copy right title Click");
        }

        private void btGoRightDiscs_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy right discs Click");
            lbMergedDiscs.Text = _dcRight["discs"];
            slLogger.Trace("<< Copy right discs Click");
        }

        private void btGoRightPublisher_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy right publisher Click");
            lbMergedPublisher.Text = _dcRight["publisher"];
            slLogger.Trace("<< Copy right publisher Click");
        }

        private void btGoRightPlayers_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy right players Click");
            lbMergedPlayers.Text = _dcRight["players"];
            slLogger.Trace("<< Copy right players Click");
        }

        private void btGoRightYear_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy right year Click");
            lbMergedYear.Text = _dcRight["year"];
            slLogger.Trace("<< Copy right year Click");
        }

        private void btGoRightAlphaTitle_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Copy right alphatitle Click");
            lbMergedAlphaTitle.Text = _dcRight["alphatitle"];
            slLogger.Trace("<< Copy right alphatitle Click");
        }

        private void btChooseMerged_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Save Merged file Click");
            String s1 = lbMergedTitle.Text.Trim();
            String s2 = lbMergedDiscs.Text.Trim();
            String s3 = lbMergedPublisher.Text.Trim();
            String s4 = lbMergedAlphaTitle.Text.Trim();
            int i1 = 1;
            int i2 = 1995;
            try
            {
                i1 = int.Parse(lbMergedPlayers.Text);
            }
            catch (Exception ex)
            {
                //
            }
            try
            {
                i2 = int.Parse(lbMergedYear.Text);
            }
            catch (Exception ex)
            {
                //
            }
            Dictionary<String, String> dcTosave = new Dictionary<string, string>();
            dcTosave.Add("title", s1);
            dcTosave.Add("discs", s2);
            dcTosave.Add("publisher", s3);
            dcTosave.Add("alphatitle", s4);
            dcTosave.Add("players", i1.ToString());
            dcTosave.Add("year", i2.ToString());
            ClPbHelper.SaveGameIni(_leftFilename, dcTosave, slLogger);
            slLogger.Trace("<< Save Merged file Click");
        }
    }
}
