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

        public Form10(List<ClGameStructure> lcgs, String sFolderPath, int bleemsyncVersion, ClVersionHelper cvh, SimpleLogger sl)
        {
            InitializeComponent();
            slLogger = sl;
            m_bsversion = bleemsyncVersion;
            m_lcgs = lcgs;
            m_sFolderPath = sFolderPath;
            m_cvh = cvh;
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

            // TODO read DB
            List<ClUIFolder> lFolders = ReadDBFolder("H:\\bleemsync\\etc\\bleemsync\\SYS\\databases\\regional.db", Constant.iBLEEMSYNC_V120);
            foreach(ClUIFolder cuif in lFolders)
            {
                tvFolders.Nodes.Add(cuif.Title);
                List<ClGameStructure> lcgs1 = new List<ClGameStructure>();
                foreach (int iIndex in cuif.ListGameIds)
                {
                    foreach(ClGameStructure cgs in m_lcgs)
                    {
                        int iCurrent = int.Parse(cgs.FolderIndex);
                        if(iCurrent == iIndex)
                        {
                            lcgs1.Add(cgs);
                            break;
                        }
                    }
                }
                m_lcgs_folder.Add(tvFolders.Nodes[tvFolders.Nodes.Count - 1], lcgs1);
            }
        }

        private List<ClUIFolder> ReadDBFolder(String sFilename, int bleemsyncVersion)
        {
            List<ClUIFolder> lFoldersFromDB = new List<ClUIFolder>();
            Dictionary<int, List<int>> dcListGamesInFoldersFromDB = new Dictionary<int, List<int>>();

            String cs = "URI=file:" + sFilename;
            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                try
                {
                    con.Open();
                    string stm = "SELECT * FROM FOLDER_ITEMS ORDER BY FOLDER_ID ASC";
                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int iFolderId = int.Parse(rdr["FOLDER_ID"].ToString().Trim());
                                int iGameId = int.Parse(rdr["GAME_ID"].ToString().Trim());
                                if (!dcListGamesInFoldersFromDB.ContainsKey(iFolderId))
                                {
                                    dcListGamesInFoldersFromDB.Add(iFolderId, new List<int>());
                                }
                                dcListGamesInFoldersFromDB[iFolderId].Add(iGameId);
                            }
                        }
                    }

                    stm = "SELECT * FROM FOLDER_ENTRIES ORDER BY FOLDER_ID ASC";
                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int iId = int.Parse(rdr["FOLDER_ID"].ToString().Trim());
                                if (dcListGamesInFoldersFromDB.ContainsKey(iId))
                                {
                                    lFoldersFromDB.Add(new ClUIFolder(rdr["FOLDER_NAME"].ToString().Trim(), dcListGamesInFoldersFromDB[iId]));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    SQLiteConnection.ClearAllPools();
                }
            }
            return lFoldersFromDB;
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
            //
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
            }
        }

        private void btNewFolder_Click(object sender, EventArgs e)
        {
            //
            tvFolders.Nodes.Add("new folder");
            m_lcgs_folder.Add(tvFolders.Nodes[tvFolders.Nodes.Count - 1], new List<ClGameStructure>());
            tvFolders.SelectedNode = tvFolders.Nodes[tvFolders.Nodes.Count - 1];
            tbCurrentFolder.Focus();
        }

        private void btGenerate_Click(object sender, EventArgs e)
        {
            List<ClUIFolder> lFolders = new List<ClUIFolder>();
            if(tvFolders.Nodes.Count > 0)
            {
                foreach(TreeNode t in tvFolders.Nodes)
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
                        lFolders.Add(new ClUIFolder(t.Text, lGameIds));
                    }
                }
            }
            ClDBManager cdbm = new ClDBManager(m_lcgs, m_sFolderPath, m_bsversion, m_cvh, slLogger, lFolders);
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

        private void tvFolders_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            lbCurrentGames.Items.Clear();
        }

        private void tbCurrentFolder_Leave(object sender, EventArgs e)
        {
            if (tvFolders.SelectedNode != null)
            {
                tvFolders.SelectedNode.Text = tbCurrentFolder.Text;
            }
        }

        private void btRemoveSelectedGame_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btRemoveFolder_Click(object sender, EventArgs e)
        {
            // TODO
        }

        private void btBrowseImage_Click(object sender, EventArgs e)
        {
            // TODO
        }
    }
}
