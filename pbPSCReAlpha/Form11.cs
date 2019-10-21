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
    public partial class Form11 : Form
    {
        String _folderPath;
        SimpleLogger slLogger;
        ClGameStructure newGame;
        ClVersionHelper _versionBS;

        public Form11()
        {
            InitializeComponent();
        }

        public Form11(String sFolderPath, SimpleLogger sl, ClGameStructure myGame, ClVersionHelper cvh)
        {
            InitializeComponent();
            slLogger = sl;
            newGame = myGame;
            _versionBS = cvh;

            _folderPath = sFolderPath + "\\" + newGame.FolderIndex + cvh.GameDataFolder;

            if (newGame.BypassLaunchScript)
            {
                tbLaunchContent.Clear();
                try
                {
                    using (StreamReader sr = new StreamReader(_folderPath + "\\" + "launch.sh"))
                    {
                        String sline = String.Empty;
                        while ((sline = sr.ReadLine()) != null)
                        {
                            tbLaunchContent.AppendText(sline + Environment.NewLine);
                        }
                    }
                }
                catch(Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
            }
            lbFiles.Items.Clear();
            if (newGame.Filenames.Count > 0)
            {
                foreach (String s in newGame.Filenames)
                {
                    lbFiles.Items.Add(s);
                }
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Save launch.sh Click");
            try
            {
                slLogger.Debug("Saving " + _folderPath + "\\" + "launch.sh");
                using (StreamWriter sw = new StreamWriter(_folderPath + "\\" + "launch.sh"))
                {
                    String s = tbLaunchContent.Text.Trim();
                    if(!String.IsNullOrEmpty(s))
                    {
                        String[] sTok = s.Split('\n');
                        foreach(String sLine in sTok)
                        {
                            sw.Write(sLine + "\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                slLogger.Fatal(ex.Message);
            }
            slLogger.Trace("<< Save launch.sh Click");
        }

        private void CopyFilenameToClipboard()
        {
            if (lbFiles.SelectedIndex > -1)
            {
                Clipboard.SetText(lbFiles.Items[lbFiles.SelectedIndex].ToString());
            }
        }

        private void btClipboardCopy_Click(object sender, EventArgs e)
        {
            CopyFilenameToClipboard();
        }

        private void lbFiles_DoubleClick(object sender, EventArgs e)
        {
            CopyFilenameToClipboard();
        }
    }
}
