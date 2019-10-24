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
    public partial class Form12 : Form
    {
        String[] sScriptFiles;
        String _folderPath;
        String _corePath;
        String _resultContent = String.Empty;
        SimpleLogger slLogger;
        ClGameStructure newGame;
        ClVersionHelper _versionBS;

        public string ResultContent { get => _resultContent; set => _resultContent = value; }

        public Form12(String sFolderPath, SimpleLogger sl, ClGameStructure myGame, ClVersionHelper cvh)
        {
            InitializeComponent();
            Point p = new Point(12, 292);
            gbRetroarch.Location = p;
            gbDrastic.Location = p;
            gbFolder.Location = p;
            this.Height = 404;
            slLogger = sl;
            newGame = myGame;
            _versionBS = cvh;
            _folderPath = sFolderPath + "\\" + newGame.FolderIndex + cvh.GameDataFolder;
            _corePath = sFolderPath;
            if (_corePath.EndsWith("\\"))
            {
                _corePath = _corePath.Substring(0, sFolderPath.Length - 1);
            }
            int iUp = _corePath.LastIndexOf("\\");
            if (iUp > 0)
            {
                _corePath = _corePath.Substring(0, iUp);
            }
            _corePath = _corePath + "\\bleemsync\\opt\\retroarch\\.config\\retroarch\\cores";

            FileInfo[] inDirfileList = new DirectoryInfo(Application.StartupPath).GetFiles("launch*.sh", SearchOption.TopDirectoryOnly);
            cbLaunchScriptChoice.Items.Clear();
            if (inDirfileList.Length > 0)
            {
                sScriptFiles = new String[inDirfileList.Length];
                int i = 0;
                int iIndexRA = 0;
                foreach (FileInfo fi in inDirfileList)
                {
                    using (StreamReader sr = new StreamReader(fi.FullName))
                    {
                        sScriptFiles[i] = sr.ReadToEnd();
                        if (fi.Name == "launch_retroarch.sh")
                        {
                            iIndexRA = cbLaunchScriptChoice.Items.Count;
                        }
                        cbLaunchScriptChoice.Items.Add(fi.Name);
                    }
                    i++;
                }
                cbLaunchScriptChoice.SelectedIndex = iIndexRA;
            }
            else
            {
                Close(); // may be rude...
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbLaunchScriptChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbLaunchScriptChoice.SelectedIndex > -1)
            {
                if(cbLaunchScriptChoice.SelectedIndex < sScriptFiles.Length)
                {
                    tbContent.Clear();
                    String[] sContent = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Split('\n');
                    foreach(String s in sContent)
                    {
                        String sTmp = s.Trim();
                        tbContent.AppendText(sTmp + Environment.NewLine);
                    }

                    switch(cbLaunchScriptChoice.Items[cbLaunchScriptChoice.SelectedIndex].ToString())
                    {
                        case "launch_drastic.sh":
                            cbFiles_DS.Items.Clear();
                            foreach (String s in newGame.Filenames)
                            {
                                cbFiles_DS.Items.Add(s);
                            }
                            gbRetroarch.Visible = false;
                            gbRetroarch.Enabled = false;
                            gbFolder.Visible = false;
                            gbFolder.Enabled = false;
                            gbDrastic.Enabled = true;
                            gbDrastic.Visible = true;
                            break;
                        case "launch_folder.sh":
                            gbDrastic.Visible = false;
                            gbDrastic.Enabled = false;
                            gbRetroarch.Visible = false;
                            gbRetroarch.Enabled = false;
                            gbFolder.Enabled = true;
                            gbFolder.Visible = true;
                            break;
                        case "launch_retroarch.sh":
                            cbCores_RA.Items.Clear();
                            if (Directory.Exists(_corePath))
                            {
                                FileInfo[] inDirfileList = new DirectoryInfo(_corePath).GetFiles("*.*", SearchOption.TopDirectoryOnly);
                                foreach (FileInfo fi in inDirfileList)
                                {
                                    cbCores_RA.Items.Add(fi.Name);
                                }
                            }
                            cbFiles_RA.Items.Clear();
                            foreach(String s in newGame.Filenames)
                            {
                                cbFiles_RA.Items.Add(s);
                            }
                            gbDrastic.Visible = false;
                            gbDrastic.Enabled = false;
                            gbFolder.Visible = false;
                            gbFolder.Enabled = false;
                            gbRetroarch.Enabled = true;
                            gbRetroarch.Visible = true;
                            break;
                        default:
                            gbDrastic.Visible = false;
                            gbDrastic.Enabled = false;
                            gbRetroarch.Visible = false;
                            gbRetroarch.Enabled = false;
                            gbFolder.Visible = false;
                            gbFolder.Enabled = false;
                            break;
                    }
                }
            }
        }

        private void btReplaceCore_Click(object sender, EventArgs e)
        {
            String s = tbContent.Text.Replace("\r\n", "\n");
            String sCore = cbCores_RA.Text.Trim();
            if (s.Contains("XXXXXYYYYY"))
            {
                s = s.Replace("XXXXXYYYYY", sCore);
                tbContent.Text = s.Replace("\n", "\r\n");
            }
            else
            {
                int ipos0 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].IndexOf("XXXXXYYYYY");
                if((ipos0 > 12) && (ipos0+10 < sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Length))
                {
                    String s1 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Substring(ipos0 - 12, 12);
                    String s2 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Substring(ipos0 + 10, 12);
                    int ipos1 = s.IndexOf(s1);
                    int ipos2 = s.IndexOf(s2);
                    if((ipos1 > -1) && (ipos2 > -1))
                    {
                        s = s.Substring(0, ipos1 + 12) + sCore + s.Substring(ipos2);
                        tbContent.Text = s.Replace("\n", "\r\n");
                    }
                }
            }
        }

        private void btReplaceFileName_RA_Click(object sender, EventArgs e)
        {
            String s = tbContent.Text.Replace("\r\n", "\n");
            String sFile = cbFiles_RA.Text.Trim();
            if (s.Contains("YYYYYXXXXX"))
            {
                s = s.Replace("YYYYYXXXXX", sFile);
                tbContent.Text = s.Replace("\n", "\r\n");
            }
            else
            {
                int ipos0 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].IndexOf("YYYYYXXXXX");
                if ((ipos0 > 12) && (ipos0 + 10 < sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Length))
                {
                    String s1 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Substring(ipos0 - 12, 12);
                    String s2 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Substring(ipos0 + 10, 12);
                    int ipos1 = s.IndexOf(s1);
                    int ipos2 = s.IndexOf(s2);
                    if ((ipos1 > -1) && (ipos2 > -1))
                    {
                        s = s.Substring(0, ipos1 + 12) + sFile + s.Substring(ipos2);
                        tbContent.Text = s.Replace("\n", "\r\n");
                    }
                }
            }
        }

        private void btReplaceFileName_DS_Click(object sender, EventArgs e)
        {
            String s = tbContent.Text.Replace("\r\n", "\n");
            String sFile = cbFiles_DS.Text.Trim();
            if (s.Contains("XXXXXYYYYY"))
            {
                s = s.Replace("XXXXXYYYYY", sFile);
                tbContent.Text = s.Replace("\n", "\r\n");
            }
            else
            {
                int ipos0 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].IndexOf("XXXXXYYYYY");
                if ((ipos0 > 12) && (ipos0 + 10 < sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Length))
                {
                    String s1 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Substring(ipos0 - 12, 12);
                    String s2 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Substring(ipos0 + 10, 12);
                    int ipos1 = s.IndexOf(s1);
                    int ipos2 = s.IndexOf(s2);
                    if ((ipos1 > -1) && (ipos2 > -1))
                    {
                        s = s.Substring(0, ipos1 + 12) + sFile + s.Substring(ipos2);
                        tbContent.Text = s.Replace("\n", "\r\n");
                    }
                }
            }
        }

        private void btReplaceFolderIndex_Folder_Click(object sender, EventArgs e)
        {
            String s = tbContent.Text.Replace("\r\n", "\n");
            int iIndex = (int)(nudFolderIndex.Value);
            if (s.Contains("XXXXXYYYYY"))
            {
                s = s.Replace("XXXXXYYYYY", iIndex.ToString());
                tbContent.Text = s.Replace("\n", "\r\n");
            }
            else
            {
                int ipos0 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].IndexOf("XXXXXYYYYY");
                if ((ipos0 > 12) && (ipos0 + 10 < sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Length))
                {
                    String s1 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Substring(ipos0 - 12, 12);
                    String s2 = sScriptFiles[cbLaunchScriptChoice.SelectedIndex].Substring(ipos0 + 10, 12);
                    int ipos1 = s.IndexOf(s1);
                    int ipos2 = s.IndexOf(s2);
                    if ((ipos1 > -1) && (ipos2 > -1))
                    {
                        s = s.Substring(0, ipos1 + 12) + iIndex.ToString() + s.Substring(ipos2);
                        tbContent.Text = s.Replace("\n", "\r\n");
                    }
                }
            }
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            _resultContent = tbContent.Text;
            Close();
        }
    }
}
