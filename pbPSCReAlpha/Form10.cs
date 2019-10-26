using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbPSCReAlpha
{
    public partial class Form10 : Form
    {
        SimpleLogger slLogger;
        int m_bsversion;
        List<ClGameStructure> m_lcgs;
        String m_sFolderPath;
        ClVersionHelper m_cvh;
        Dictionary<TreeNode,List<ClGameStructure>> m_lcgs_folder;
        List<ClUIFolder> m_luiFolders;

        public Form10(List<ClGameStructure> lcgs, String sFolderPath, int bleemsyncVersion, ClVersionHelper cvh, SimpleLogger sl, List<ClUIFolder> luiFoldersList)
        {
            InitializeComponent();
            slLogger = sl;
            m_bsversion = bleemsyncVersion;
            m_lcgs = lcgs;
            m_sFolderPath = sFolderPath;
            m_cvh = cvh;
            m_luiFolders = luiFoldersList;
            lbGameList.Items.Clear();
            lbGameList.DisplayMember = "IndexAndTitle";
            if (m_lcgs.Count > 0)
            {
                foreach(ClGameStructure cgs in m_lcgs)
                {
                    lbGameList.Items.Add(cgs);
                }
            }
            lbCurrentGames.DisplayMember = "IndexAndTitle";
            m_lcgs_folder = new Dictionary<TreeNode, List<ClGameStructure>>();
            
            // folders from DB
            if (m_luiFolders != null)
            {
                foreach (ClUIFolder cuif in m_luiFolders)
                {
                    tvFolders.Nodes.Add(cuif.Title);
                    List<ClGameStructure> lcgs1 = new List<ClGameStructure>();
                    foreach (int iIndex in cuif.ListGameIds)
                    {
                        foreach (ClGameStructure cgs in m_lcgs)
                        {
                            int iCurrent = int.Parse(cgs.FolderIndex);
                            if (iCurrent == iIndex)
                            {
                                lcgs1.Add(cgs);
                                break;
                            }
                        }
                    }
                    m_lcgs_folder.Add(tvFolders.Nodes[tvFolders.Nodes.Count - 1], lcgs1);
                }
            }
            refreshComboBoxFolders();
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAddTo_Click(object sender, EventArgs e)
        {
            if(lbGameList.SelectedItems.Count > 0)
            {
                //
                if(tvFolders.SelectedNode != null)
                {
                    foreach (ClGameStructure cgsGlobal in lbGameList.SelectedItems)
                    {
                        if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                        {
                            if (m_lcgs_folder[tvFolders.SelectedNode].Count > 0)
                            {
                                bool bFound = false;
                                foreach (ClGameStructure cgs in m_lcgs_folder[tvFolders.SelectedNode])
                                {
                                    if (bFound == false)
                                    {
                                        if (cgs.IsSame(cgsGlobal))
                                        {
                                            bFound = true;
                                        }
                                    }
                                }
                                if (bFound == false)
                                {
                                    lbCurrentGames.Items.Add(cgsGlobal);
                                    m_lcgs_folder[tvFolders.SelectedNode].Add(cgsGlobal);
                                }
                            }
                            else
                            {
                                lbCurrentGames.Items.Add(cgsGlobal);
                                m_lcgs_folder[tvFolders.SelectedNode].Add(cgsGlobal);
                            }
                        }
                    }
                }
            }
        }

        private void tvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvFolders.SelectedNode != null)
            {
                if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                {
                    foreach (ClGameStructure cgs in m_lcgs_folder[tvFolders.SelectedNode])
                    {
                        lbCurrentGames.Items.Add(cgs);
                    }
                }
                tbCurrentFolder.Text = tvFolders.SelectedNode.Text;
                refreshComboBoxFolders();
            }
        }

        private void btNewFolder_Click(object sender, EventArgs e)
        {
            //
            int iNew = tvFolders.Nodes.Count + 1;
            tvFolders.Nodes.Add("Folder " + iNew.ToString());
            m_lcgs_folder.Add(tvFolders.Nodes[tvFolders.Nodes.Count - 1], new List<ClGameStructure>());
            tvFolders.SelectedNode = tvFolders.Nodes[tvFolders.Nodes.Count - 1];
            tbCurrentFolder.Focus();
            refreshComboBoxFolders();
        }

        private void btGenerate_Click(object sender, EventArgs e)
        {
            List<ClUIFolder> lFolders = new List<ClUIFolder>();
            int iIndexFirstBoot = 0;
            TreeNode tSelected = null;
            if(cbFolderAtFirstBoot.SelectedIndex > 0)
            {
                tSelected = (TreeNode)(cbFolderAtFirstBoot.Items[cbFolderAtFirstBoot.SelectedIndex]);
            }
            if(tvFolders.Nodes.Count > 0)
            {
                tvFolders.SelectedNode = null;
                tvFolders.Sort();
                int iIndex = 1;
                foreach (TreeNode t in tvFolders.Nodes)
                {
                    if (m_lcgs_folder.ContainsKey(t))
                    {
                        List<int> lGameIds = new List<int>();
                        if (m_lcgs_folder[t].Count > 0)
                        {
                            foreach (ClGameStructure cgs in m_lcgs_folder[t])
                            {
                                try
                                {
                                    int iGame = int.Parse(cgs.FolderIndex);
                                    lGameIds.Add(iGame);
                                }
                                catch(Exception ex)
                                {
                                    //
                                }
                            }
                        }
                        if(tSelected == t)
                        {
                            iIndexFirstBoot = iIndex;
                        }
                        lFolders.Add(new ClUIFolder(t.Text, lGameIds, "images/folder.png")); // TODO add img
                    }
                    iIndex++;
                }
            }
            ClDBManager cdbm = new ClDBManager(m_lcgs, m_sFolderPath, m_bsversion, m_cvh, slLogger, lFolders);
            String sFolderUpp = m_sFolderPath;
            if (sFolderUpp.EndsWith("\\"))
            {
                sFolderUpp = sFolderUpp.Substring(0, sFolderUpp.Length - 1);
            }
            int ipos = sFolderUpp.LastIndexOf("\\");
            if (ipos > -1)
            {
                sFolderUpp = sFolderUpp.Substring(0, ipos);
            }
            String sFolderImg = sFolderUpp + "\\bleemsync\\etc\\bleemsync\\SUP\\launchers\\folder_launch";
            String sFolderLaunch = sFolderUpp + "\\bleemsync\\etc\\bleemsync\\SUP\\launchers";
            String sFolderSelectedCfg = sFolderUpp + "\\bleemsync\\etc\\bleemsync\\CFG";
            if (iIndexFirstBoot == 0)
            {
                if(File.Exists(sFolderSelectedCfg + "\\selected_folder"))
                {
                    File.Delete(sFolderSelectedCfg + "\\selected_folder");
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(sFolderSelectedCfg + "\\selected_folder"))
                {
                    sw.Write(iIndexFirstBoot.ToString());
                }
            }
            if (cbLauncherGenerate.Checked)
            {
                if (lFolders.Count > 0)
                {
                    if (Directory.Exists(sFolderLaunch))
                    {
                        DirectoryInfo[] dirList = new DirectoryInfo(sFolderLaunch).GetDirectories("bsfolder*", SearchOption.TopDirectoryOnly);
                        foreach (DirectoryInfo di in dirList)
                        {
                            Directory.Delete(di.FullName, true);
                        }
                        int iIndex = 1;
                        foreach (ClUIFolder cuif in lFolders)
                        {
                            Directory.CreateDirectory(sFolderLaunch + "\\bsfolder" + iIndex.ToString());
                            using (StreamWriter sw = new StreamWriter(sFolderLaunch + "\\bsfolder" + iIndex.ToString() + "\\launch.sh"))
                            {
                                sw.Write("#!/bin/sh" + "\n\n");
                                sw.Write("echo 2 > /data/power/disable" + "\n");
                                sw.Write("echo " + iIndex.ToString() + " > \"/media/bleemsync/etc/bleemsync/CFG/selected_folder\"" + "\n");
                                sw.Write("cd \"/var/volatile/launchtmp\"" + "\n"); // maybe useless, to be tested without this line
                                sw.Write("echo \"launch_StockUI\" > \"/tmp/launchfilecommand\"" + "\n");
                                sw.Write("echo 0 > /data/power/disable" + "\n");
                            }
                            using (StreamWriter sw = new StreamWriter(sFolderLaunch + "\\bsfolder" + iIndex.ToString() + "\\launcher.cfg"))
                            {
                                sw.Write("launcher_filename=\"folder\"" + "\n");
                                sw.Write("launcher_title=\"" + cuif.Title + "\"" + "\n");
                                sw.Write("launcher_publisher=\"Folder\"" + "\n");
                                sw.Write("launcher_year=\"2019\"" + "\n");
                                sw.Write("launcher_sort=\"no\"" + "\n");
                            }
                            if (File.Exists(sFolderImg + "\\" + cuif.Imgpath))
                            {
                                File.Copy(sFolderImg + "\\" + cuif.Imgpath, sFolderLaunch + "\\bsfolder" + iIndex.ToString() + "\\folder.png");
                            }
                            iIndex++;
                        }
                    }
                }
            }
            if (!cdbm.BDone)
            {
                FlexibleMessageBox.Show("There is a problem during database creation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void refreshComboBoxFolders()
        {
            int iSelected = cbFolderAtFirstBoot.SelectedIndex;
            int iNewSelected = 0;
            TreeNode tSelected = new TreeNode("");
            if (iSelected > -1)
            {
                tSelected = (TreeNode)(cbFolderAtFirstBoot.Items[cbFolderAtFirstBoot.SelectedIndex]);
            }
            cbFolderAtFirstBoot.DisplayMember = "Text";
            cbFolderAtFirstBoot.Items.Clear();
            cbFolderAtFirstBoot.Items.Add(new TreeNode("No folder"));
            if (tvFolders.Nodes.Count > 0)
            {
                foreach(TreeNode t in tvFolders.Nodes)
                {
                    cbFolderAtFirstBoot.Items.Add(t);
                    if(iSelected > 0)
                    {
                        if(tSelected == t)
                        {
                            iNewSelected = cbFolderAtFirstBoot.Items.Count - 1;
                        }
                    }

                }
            }
            cbFolderAtFirstBoot.SelectedIndex = iNewSelected;
        }

        private void tvFolders_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            lbCurrentGames.Items.Clear();
        }

        private void tbCurrentFolder_Leave(object sender, EventArgs e)
        {
            if (tvFolders.SelectedNode != null)
            {
                tvFolders.SelectedNode.Text = tbCurrentFolder.Text;
                refreshComboBoxFolders();
            }
        }

        private void btRemoveSelectedGame_Click(object sender, EventArgs e)
        {
            if(lbCurrentGames.SelectedItems.Count > 0)
            {
                List<ClGameStructure> lcgs = new List<ClGameStructure>();
                foreach (ClGameStructure cgs in lbCurrentGames.SelectedItems)
                {
                    lcgs.Add(cgs);
                }
                foreach (ClGameStructure cgs in lcgs)
                {
                    lbCurrentGames.Items.Remove(cgs);
                    m_lcgs_folder[tvFolders.SelectedNode].Remove(cgs);
                }
                refreshComboBoxFolders();
            }
        }

        private void btRemoveFolder_Click(object sender, EventArgs e)
        {
            if (tvFolders.SelectedNode != null)
            {
                if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                {
                    m_lcgs_folder.Remove(tvFolders.SelectedNode);
                }
                tvFolders.SelectedNode.Remove();
                refreshComboBoxFolders();
            }
        }

        private void btBrowseImage_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btClearFolders_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == FlexibleMessageBox.Show("Are you sure you want to remove all folders ?", "Removing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                tvFolders.Nodes.Clear();
                m_lcgs_folder.Clear();
                lbCurrentGames.Items.Clear();
                tbCurrentFolder.Text = "";
                pbCurrentFolder.Image = null;
                refreshComboBoxFolders();
            }
        }

        private void tvFolders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (tvFolders.SelectedNode != null)
                {
                    if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                    {
                        m_lcgs_folder.Remove(tvFolders.SelectedNode);
                    }
                    tvFolders.SelectedNode.Remove();
                    refreshComboBoxFolders();
                }
            }
        }

        private void lbCurrentGames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lbCurrentGames.SelectedItems.Count > 0)
                {
                    List<ClGameStructure> lcgs = new List<ClGameStructure>();
                    foreach (ClGameStructure cgs in lbCurrentGames.SelectedItems)
                    {
                        lcgs.Add(cgs);
                    }
                    foreach (ClGameStructure cgs in lcgs)
                    {
                        lbCurrentGames.Items.Remove(cgs);
                        m_lcgs_folder[tvFolders.SelectedNode].Remove(cgs);
                    }
                }
            }
        }
    }
}
