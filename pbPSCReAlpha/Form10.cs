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
            //
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
    }
}
