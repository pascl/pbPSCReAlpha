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
    public partial class Form4 : Form
    {
        String _folderPath;
        SimpleLogger slLogger;
        ClGameStructure newGame;
        ClVersionHelper _versionBS;

        public Form4()
        {
            InitializeComponent();
        }
        
        public Form4(String sFolderPath, SimpleLogger sl, ClGameStructure myGame, ClVersionHelper cvh)
        {
            InitializeComponent();
            slLogger = sl;
            newGame = myGame;
            _versionBS = cvh;

            _folderPath = sFolderPath + "\\" + newGame.FolderIndex + cvh.GameDataFolder;

            if (!newGame.CueMissing)
            {
                int cueCount = 0;

                foreach(String s in newGame.Filenames)
                {
                    if(s.EndsWith(".cue"))
                    {
                        cueCount++;
                        GroupBox gb = new GroupBox();
                        gb.Text = s;
                        gb.Width = 400;
                        gb.Height = 250;
                        gb.Parent = flpCueFiles;


                        TextBox tb = new TextBox();
                        tb.Multiline = true;
                        tb.Parent = gb;
                        tb.Dock = DockStyle.Top;
                        tb.Height = 200;
                        tb.ScrollBars = ScrollBars.Both;
                        //tb.ReadOnly = true;

                        if(File.Exists(_folderPath + "\\" + s))
                        {
                            using (StreamReader sr = new StreamReader(_folderPath + "\\" + s))
                            {
                                String sline = String.Empty;
                                while ((sline = sr.ReadLine()) != null)
                                {
                                    tb.AppendText(sline + Environment.NewLine);
                                }
                            }
                        }

                        Button btSave = new Button();
                        btSave.Text = "Save";
                        btSave.Parent = gb;
                        btSave.Top = 220;
                        btSave.Left = 4;
                        //btSave.Enabled = false;
                        btSave.Tag = (object)(gb);
                        btSave.Click += cueSave;

                        Button btAutoedit = new Button();
                        btAutoedit.Text = "Auto";
                        btAutoedit.Parent = gb;
                        btAutoedit.Top = 220;
                        btAutoedit.Left = 90;
                        //btAutoedit.Enabled = false;
                        btAutoedit.Tag = (object)(gb);
                        btAutoedit.Click += cueAuto;
                    }
                }
                if(cueCount > 2)
                {
                    this.Width = 994;
                }
            }
            lbBinFiles.Items.Clear();
            if (!newGame.BinMissing)
            {
                if(newGame.Filenames.Count > 0)
                {
                    foreach(String s in newGame.Filenames)
                    {
                        if (s.EndsWith(".bin"))
                        {
                            lbBinFiles.Items.Add(s);
                        }
                    }
                }
            }
        }

        private void cueAuto(object sender, EventArgs e)
        {
            slLogger.Trace(">> Autoedit cue Click");
            Button bt = (Button)(sender);
            GroupBox gb = (GroupBox)(bt.Tag);
            TextBox tb = null;
            try
            {
                if (gb.HasChildren)
                {
                    foreach (Control ct in gb.Controls)
                    {
                        if (ct is TextBox)
                        {
                            tb = (TextBox)ct;
                        }
                    }
                    if (tb != null)
                    {
                        String sCue = gb.Text;
                        sCue = sCue.Substring(0, sCue.IndexOf(".cue"));
                        List<String> lsBinFilesForCue = new List<string>();
                        foreach(String item in lbBinFiles.Items)
                        {
                            if(item.ToLower().IndexOf(sCue.ToLower()) > -1)
                            {
                                lsBinFilesForCue.Add(item);
                            }
                        }
                        String sAll = tb.Text;
                        using (StringReader sr = new StringReader(sAll))
                        {
                            int iIndex = 0;
                            String s = String.Empty;
                            String sBack = String.Empty;
                            while ((s = sr.ReadLine()) != null)
                            {
                                //s = s.Trim();
                                if (s.Trim().ToUpper().StartsWith("FILE"))
                                {
                                    int ipos1 = s.IndexOf("\"");
                                    int ipos2 = s.LastIndexOf("\"");
                                    if ((ipos1 > -1) && (ipos2 > -1) && (ipos1 != ipos2))
                                    {
                                        String sBin = s.Substring(ipos1 + 1, ipos2 - ipos1 - 1);
                                        if (iIndex < lsBinFilesForCue.Count)
                                        {
                                            s = s.Remove(ipos1 + 1, ipos2 - ipos1 - 1);
                                            s = s.Insert(ipos1 + 1, lsBinFilesForCue[iIndex]);
                                        }
                                    }
                                    iIndex++;
                                }
                                sBack += s + Environment.NewLine;
                            }
                            tb.Text = sBack;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                slLogger.Fatal(ex.Message);
            }
            slLogger.Trace("<< Autoedit cue Click");
        }

        private void cueSave(object sender, EventArgs e)
        {
            slLogger.Trace(">> Save cue Click");
            Button bt = (Button)(sender);
            GroupBox gb = (GroupBox)(bt.Tag);
            TextBox tb = null;

            try
            {
                if (gb.HasChildren)
                {
                    foreach (Control ct in gb.Controls)
                    {
                        if (ct is TextBox)
                        {
                            tb = (TextBox)ct;
                        }
                    }
                    if (tb != null)
                    {
                        slLogger.Debug("Saving " + _folderPath + "\\" + gb.Text);
                        using (StreamWriter sw = new StreamWriter(_folderPath + "\\" + gb.Text))
                        {
                            sw.Write(tb.Text);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
            }
            slLogger.Trace("<< Save cue Click");
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CopyBinNameToClipboard()
        {
            if (lbBinFiles.SelectedIndex > -1)
            {
                Clipboard.SetText(lbBinFiles.Items[lbBinFiles.SelectedIndex].ToString());
            }
        }

        private void btClipboardCopy_Click(object sender, EventArgs e)
        {
            CopyBinNameToClipboard();
        }

        private void lbBinFiles_DoubleClick(object sender, EventArgs e)
        {
            CopyBinNameToClipboard();
        }
    }
}
