using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
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
        Dictionary<TreeNode,ClGameStructureWithPicture> m_lcgs_folder;
        List<ClUIFolder> m_luiFolders;

        class ClGameStructureWithPicture
        {
            String _picturePath;
            Bitmap _pictureBitmap;
            List<ClGameStructure> _gameStruct;

            public ClGameStructureWithPicture(string picturePath, Bitmap pictureBitmap, List<ClGameStructure> gameStruct)
            {
                _picturePath = picturePath;
                _pictureBitmap = pictureBitmap;
                _gameStruct = gameStruct;
            }

            public string PicturePath { get => _picturePath; set => _picturePath = value; }
            public Bitmap PictureBitmap { get => _pictureBitmap; set => _pictureBitmap = value; }
            public List<ClGameStructure> GameStruct { get => _gameStruct; set => _gameStruct = value; }
        }

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

            pbCurrentFolder.AllowDrop = true;

            m_lcgs_folder = new Dictionary<TreeNode, ClGameStructureWithPicture>();
            
            // folders from DB
            if (m_luiFolders != null)
            {
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
                    String sImgFullPath = sFolderImg + "\\" + cuif.Imgpath.Replace("/", "\\");
                    if(!File.Exists(sImgFullPath))
                    {
                        sImgFullPath = sFolderImg + "\\images\\folder.png";
                    }
                    if (!File.Exists(sImgFullPath))
                    {
                        m_lcgs_folder.Add(tvFolders.Nodes[tvFolders.Nodes.Count - 1], new ClGameStructureWithPicture(String.Empty, null, lcgs1));
                    }
                    else
                    {
                        m_lcgs_folder.Add(tvFolders.Nodes[tvFolders.Nodes.Count - 1], new ClGameStructureWithPicture(sImgFullPath, new Bitmap(sImgFullPath), lcgs1));
                    }
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
            slLogger.Trace(">> Add games in folder Click");
            try
            {
                if (lbGameList.SelectedItems.Count > 0)
                {
                    if (tvFolders.SelectedNode != null)
                    {
                        foreach (ClGameStructure cgsGlobal in lbGameList.SelectedItems)
                        {
                            if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                            {
                                if (m_lcgs_folder[tvFolders.SelectedNode].GameStruct.Count > 0)
                                {
                                    bool bFound = false;
                                    foreach (ClGameStructure cgs in m_lcgs_folder[tvFolders.SelectedNode].GameStruct)
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
                                        m_lcgs_folder[tvFolders.SelectedNode].GameStruct.Add(cgsGlobal);
                                    }
                                }
                                else
                                {
                                    lbCurrentGames.Items.Add(cgsGlobal);
                                    m_lcgs_folder[tvFolders.SelectedNode].GameStruct.Add(cgsGlobal);
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
                FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< Add games in folder Click");
        }

        private void tvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (tvFolders.SelectedNode != null)
                {
                    if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                    {
                        foreach (ClGameStructure cgs in m_lcgs_folder[tvFolders.SelectedNode].GameStruct)
                        {
                            lbCurrentGames.Items.Add(cgs);
                        }
                        tbCurrentFolder.Text = tvFolders.SelectedNode.Text;
                        if (m_lcgs_folder[tvFolders.SelectedNode].PictureBitmap != null)
                        {
                            pbCurrentFolder.Image = new Bitmap(m_lcgs_folder[tvFolders.SelectedNode].PictureBitmap);
                        }
                        else
                        {
                            pbCurrentFolder.Image = null;
                        }
                    }
                    refreshComboBoxFolders();
                    gbSelectedFolder.Enabled = true;
                }
                else
                {
                    gbSelectedFolder.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
                FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btNewFolder_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> New folder Click");
            try
            {
                int iNew = tvFolders.Nodes.Count + 1;
                tvFolders.Nodes.Add("Folder " + iNew.ToString());
                m_lcgs_folder.Add(tvFolders.Nodes[tvFolders.Nodes.Count - 1], new ClGameStructureWithPicture(String.Empty, null, new List<ClGameStructure>()));
                tvFolders.SelectedNode = tvFolders.Nodes[tvFolders.Nodes.Count - 1];
                tbCurrentFolder.Focus();
                refreshComboBoxFolders();
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
                FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< New folder Click");
        }

        private void btGenerate_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Generate Click");
            try
            {
                List<ClUIFolder> lFolders = new List<ClUIFolder>();
                int iIndexFirstBoot = 0;
                TreeNode tSelected = null;

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

                if (cbFolderAtFirstBoot.SelectedIndex > 0)
                {
                    tSelected = (TreeNode)(cbFolderAtFirstBoot.Items[cbFolderAtFirstBoot.SelectedIndex]);
                }
                if (tvFolders.Nodes.Count > 0)
                {
                    tvFolders.SelectedNode = null;
                    tvFolders.Sort();
                    int iIndex = 1;
                    List<String> lsImage = new List<string>();
                    foreach (TreeNode t in tvFolders.Nodes)
                    {
                        if (m_lcgs_folder.ContainsKey(t))
                        {
                            List<int> lGameIds = new List<int>();
                            if (m_lcgs_folder[t].GameStruct.Count > 0)
                            {
                                foreach (ClGameStructure cgs in m_lcgs_folder[t].GameStruct)
                                {
                                    try
                                    {
                                        int iGame = int.Parse(cgs.FolderIndex);
                                        lGameIds.Add(iGame);
                                    }
                                    catch (Exception ex)
                                    {
                                        //
                                    }
                                }
                            }
                            if (tSelected == t)
                            {
                                iIndexFirstBoot = iIndex;
                            }
                            String sImgDBPath = "images/folder.png";
                            if ((!String.IsNullOrEmpty(m_lcgs_folder[t].PicturePath)) && (m_lcgs_folder[t].PicturePath.ToLower().IndexOf(sFolderImg.ToLower()) > -1))
                            {
                                if (File.Exists(m_lcgs_folder[t].PicturePath))
                                {
                                    // picture is already in the "right" place
                                    int ipos0 = m_lcgs_folder[t].PicturePath.LastIndexOf("\\");
                                    if (ipos0 > -1)
                                    {
                                        sImgDBPath = "images/" + m_lcgs_folder[t].PicturePath.Substring(ipos0 + 1);
                                    }
                                }
                            }
                            else
                            {
                                // picture needs to be copied
                                if ((!String.IsNullOrEmpty(m_lcgs_folder[t].PicturePath)))
                                {
                                    String sName = String.Empty;
                                    int ipos0 = m_lcgs_folder[t].PicturePath.LastIndexOf("\\");
                                    if (ipos0 > -1)
                                    {
                                        sName = m_lcgs_folder[t].PicturePath.Substring(ipos0 + 1);
                                    }
                                    if (!File.Exists(sFolderImg + "\\images\\" + sName))
                                    {
                                        m_lcgs_folder[t].PictureBitmap.Save(sFolderImg + "\\images\\" + sName, ImageFormat.Png);
                                        lsImage.Add(sFolderImg + "\\images\\" + sName);
                                        sImgDBPath = "images/" + sName;
                                    }
                                    else
                                    {
                                        int iIndexImg = 1;
                                        String sNameWithoutExt = sName;
                                        int iExt = sName.LastIndexOf(".");
                                        if (iExt > -1)
                                        {
                                            sNameWithoutExt = sName.Substring(0, iExt);
                                        }
                                        while (File.Exists(sFolderImg + "\\images\\" + sNameWithoutExt + "_" + iIndexImg.ToString() + ".png"))
                                        {
                                            iIndexImg++;
                                        }
                                        m_lcgs_folder[t].PictureBitmap.Save(sFolderImg + "\\images\\" + sNameWithoutExt + "_" + iIndexImg.ToString() + ".png", ImageFormat.Png);
                                        lsImage.Add(sFolderImg + "\\images\\" + sNameWithoutExt + "_" + iIndexImg.ToString() + ".png");
                                        sImgDBPath = "images/" + sNameWithoutExt + "_" + iIndexImg.ToString() + ".png";
                                    }
                                }
                            }
                            lFolders.Add(new ClUIFolder(t.Text, lGameIds, sImgDBPath));
                        }
                        iIndex++;
                    }
                    if(lsImage.Count > 0)
                    {
                        String sList = String.Empty;
                        foreach(String s in lsImage)
                        {
                            sList += " \"" + s + "\"";
                        }
                        MyProcessHelper pPngQuant = new MyProcessHelper(Application.StartupPath + "\\pngquant\\pngquant.exe", sList + " --force --ext .png --verbose");
                        pPngQuant.DoIt();
                    }
                }
                ClDBManager cdbm = new ClDBManager(m_lcgs, m_sFolderPath, m_bsversion, m_cvh, slLogger, lFolders);

                if (iIndexFirstBoot == 0)
                {
                    if (File.Exists(sFolderSelectedCfg + "\\selected_folder"))
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
                                if (File.Exists(sFolderImg + "\\" + cuif.Imgpath.Replace("/", "\\")))
                                {
                                    File.Copy(sFolderImg + "\\" + cuif.Imgpath.Replace("/", "\\"), sFolderLaunch + "\\bsfolder" + iIndex.ToString() + "\\folder.png");
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
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
                FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< Generate Click");
        }

        private void refreshComboBoxFolders()
        {
            try
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
                    foreach (TreeNode t in tvFolders.Nodes)
                    {
                        cbFolderAtFirstBoot.Items.Add(t);
                        if (iSelected > 0)
                        {
                            if (tSelected == t)
                            {
                                iNewSelected = cbFolderAtFirstBoot.Items.Count - 1;
                            }
                        }

                    }
                }
                cbFolderAtFirstBoot.SelectedIndex = iNewSelected;
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
                FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tvFolders_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            lbCurrentGames.Items.Clear();
        }

        private void tbCurrentFolder_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tvFolders.SelectedNode != null)
                {
                    tvFolders.SelectedNode.Text = tbCurrentFolder.Text;
                    refreshComboBoxFolders();
                }
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
                FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btRemoveSelectedGame_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Remove selected games");
            try
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
                        m_lcgs_folder[tvFolders.SelectedNode].GameStruct.Remove(cgs);
                    }
                    refreshComboBoxFolders();
                }
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
                FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< Remove selected games");
        }

        private void btRemoveFolder_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Remove selected folder");
            try
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
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
                FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< Remove selected folder");
        }

        private void btBrowseImage_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Browse image Click");
            try
            {
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
                String sFolderImg = sFolderUpp + "\\bleemsync\\etc\\bleemsync\\SUP\\launchers\\folder_launch\\images";
                if (Directory.Exists(sFolderImg))
                {
                    ofdBrowsePicture.InitialDirectory = sFolderImg;
                }
                if (DialogResult.OK == ofdBrowsePicture.ShowDialog())
                {
                    String sFileName = ofdBrowsePicture.FileName;
                    try
                    {
                        /*using (Bitmap bmPicture = new Bitmap(sFileName))
                        {
                            pbCurrentFolder.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bmPicture)), 226, 226);
                            if (tvFolders.SelectedNode != null)
                            {
                                if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                                {
                                    m_lcgs_folder[tvFolders.SelectedNode].PictureBitmap = ClPbHelper.ResizeImage((Image)(new Bitmap(bmPicture)), 226, 226);
                                    m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sFileName;
                                }
                            }
                        }*/
                        String sExt = Path.GetExtension(sFileName).ToLower();
                        if (cbKeepRatioWhenBrowsing.Checked)
                        {
                            using (Bitmap bm2 = new Bitmap(sFileName))
                            {
                                int width = 226;
                                int height = 226;
                                int orig_width = bm2.Width;
                                int orig_height = bm2.Height;
                                float orig_ratio = 0;
                                if (orig_height != 0)
                                {
                                    orig_ratio = (float)(orig_width) / (float)(orig_height);
                                }
                                else
                                {
                                    orig_ratio = 0;
                                }
                                if ((orig_ratio != 0) && (height != 0) && (orig_ratio != (width / height)))
                                {
                                    using (Bitmap bm = new Bitmap(width, height))
                                    {
                                        using (Graphics gp = Graphics.FromImage(bm))
                                        {
                                            float current_ratio = (float)(width) / (float)(height);
                                            int width1 = (int)(height * orig_ratio);
                                            int height1 = (int)(width / orig_ratio);
                                            //gp = Graphics.FromImage(bm);
                                            gp.Clear(Color.Transparent);
                                            int x = 0;
                                            int y = 0;
                                            if (width1 < width)
                                            {
                                                using (Bitmap bm1 = new Bitmap(ClPbHelper.ResizeImage(bm2, width1, height)))
                                                {
                                                    x = ((width - width1) / 2);
                                                    gp.DrawImage(bm1, x, y);
                                                }
                                            }
                                            else
                                            {
                                                using (Bitmap bm1 = new Bitmap(ClPbHelper.ResizeImage(bm2, width, height1)))
                                                {
                                                    y = ((height - height1) / 2);
                                                    gp.DrawImage(bm1, x, y);
                                                }
                                            }
                                            gp.Flush();
                                        }
                                        pbCurrentFolder.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bm)), 226, 226);
                                        if (tvFolders.SelectedNode != null)
                                        {
                                            if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                                            {
                                                m_lcgs_folder[tvFolders.SelectedNode].PictureBitmap = ClPbHelper.ResizeImage((Image)(new Bitmap(bm)), 226, 226);
                                                if (sExt != ".png")
                                                {
                                                    String sNameWithoutExt = sFileName;
                                                    int iExt = sFileName.LastIndexOf(".");
                                                    if (iExt > -1)
                                                    {
                                                        sNameWithoutExt = sFileName.Substring(0, iExt);
                                                    }
                                                    m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sNameWithoutExt + ".png";
                                                }
                                                else
                                                {
                                                    m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sFileName;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    pbCurrentFolder.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bm2)), 226, 226);
                                    if (tvFolders.SelectedNode != null)
                                    {
                                        if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                                        {
                                            m_lcgs_folder[tvFolders.SelectedNode].PictureBitmap = ClPbHelper.ResizeImage((Image)(new Bitmap(bm2)), 226, 226);
                                            if (sExt != ".png")
                                            {
                                                String sNameWithoutExt = sFileName;
                                                int iExt = sFileName.LastIndexOf(".");
                                                if (iExt > -1)
                                                {
                                                    sNameWithoutExt = sFileName.Substring(0, iExt);
                                                }
                                                m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sNameWithoutExt + ".png";
                                            }
                                            else
                                            {
                                                m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sFileName;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (Bitmap bmPicture = new Bitmap(sFileName))
                            {
                                pbCurrentFolder.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bmPicture)), 226, 226);
                                if (tvFolders.SelectedNode != null)
                                {
                                    if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                                    {
                                        m_lcgs_folder[tvFolders.SelectedNode].PictureBitmap = ClPbHelper.ResizeImage((Image)(new Bitmap(bmPicture)), 226, 226);
                                        if (sExt != ".png")
                                        {
                                            String sNameWithoutExt = sFileName;
                                            int iExt = sFileName.LastIndexOf(".");
                                            if (iExt > -1)
                                            {
                                                sNameWithoutExt = sFileName.Substring(0, iExt);
                                            }
                                            m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sNameWithoutExt + ".png";
                                        }
                                        else
                                        {
                                            m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sFileName;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (null != slLogger)
                            slLogger.Fatal(ex.Message);
                    }
                }
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
                FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< Browse image Click");
        }

        private void btClearFolders_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Clear folders Click");
            if (DialogResult.Yes == FlexibleMessageBox.Show("Are you sure you want to remove all folders ?", "Removing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                try
                {
                    tvFolders.Nodes.Clear();
                    m_lcgs_folder.Clear();
                    lbCurrentGames.Items.Clear();
                    tbCurrentFolder.Text = "";
                    pbCurrentFolder.Image = null;
                    refreshComboBoxFolders();
                }
                catch(Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                    FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            slLogger.Trace("<< Clear folders Click");
        }

        private void tvFolders_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                slLogger.Trace(">> Remove selected folder");
                try
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
                catch(Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                    FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                slLogger.Trace("<< Remove selected folder");
            }
        }

        private void lbCurrentGames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                slLogger.Trace(">> Remove selected games");
                try
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
                            m_lcgs_folder[tvFolders.SelectedNode].GameStruct.Remove(cgs);
                        }
                    }
                }
                catch(Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                    FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                slLogger.Trace("<< Remove selected games");
            }
        }

        private void pbCurrentFolder_DragDrop(object sender, DragEventArgs e)
        {
            slLogger.Trace(">> Dragdrop image");
            try
            {
                String[] sFileList = (String[])e.Data.GetData(DataFormats.FileDrop, false);
                if (sFileList.Length == 1)
                {
                    String sExt = Path.GetExtension(sFileList[0]).ToLower();
                    List<String> lsAcceptedExt = new List<string>() { ".png", ".jpg", ".jpeg", ".bmp" };
                    if (lsAcceptedExt.IndexOf(sExt) > -1)
                    {
                        if (cbKeepRatioWhenBrowsing.Checked)
                        {
                            using (Bitmap bm2 = new Bitmap(sFileList[0]))
                            {
                                int width = 226;
                                int height = 226;
                                int orig_width = bm2.Width;
                                int orig_height = bm2.Height;
                                float orig_ratio = 0;
                                if (orig_height != 0)
                                {
                                    orig_ratio = (float)(orig_width) / (float)(orig_height);
                                }
                                else
                                {
                                    orig_ratio = 0;
                                }
                                if ((orig_ratio != 0) && (height != 0) && (orig_ratio != (width / height)))
                                {
                                    using (Bitmap bm = new Bitmap(width, height))
                                    {
                                        using (Graphics gp = Graphics.FromImage(bm))
                                        {
                                            float current_ratio = (float)(width) / (float)(height);
                                            int width1 = (int)(height * orig_ratio);
                                            int height1 = (int)(width / orig_ratio);
                                            //gp = Graphics.FromImage(bm);
                                            gp.Clear(Color.Transparent);
                                            int x = 0;
                                            int y = 0;
                                            if (width1 < width)
                                            {
                                                using (Bitmap bm1 = new Bitmap(ClPbHelper.ResizeImage(bm2, width1, height)))
                                                {
                                                    x = ((width - width1) / 2);
                                                    gp.DrawImage(bm1, x, y);
                                                }
                                            }
                                            else
                                            {
                                                using (Bitmap bm1 = new Bitmap(ClPbHelper.ResizeImage(bm2, width, height1)))
                                                {
                                                    y = ((height - height1) / 2);
                                                    gp.DrawImage(bm1, x, y);
                                                }
                                            }
                                            gp.Flush();
                                        }
                                        pbCurrentFolder.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bm)), 226, 226);
                                        if (tvFolders.SelectedNode != null)
                                        {
                                            if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                                            {
                                                m_lcgs_folder[tvFolders.SelectedNode].PictureBitmap = ClPbHelper.ResizeImage((Image)(new Bitmap(bm)), 226, 226);
                                                if (sExt != ".png")
                                                {
                                                    String sNameWithoutExt = sFileList[0];
                                                    int iExt = sFileList[0].LastIndexOf(".");
                                                    if (iExt > -1)
                                                    {
                                                        sNameWithoutExt = sFileList[0].Substring(0, iExt);
                                                    }
                                                    m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sNameWithoutExt + ".png";
                                                }
                                                else
                                                {
                                                    m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sFileList[0];
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    pbCurrentFolder.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bm2)), 226, 226);
                                    if (tvFolders.SelectedNode != null)
                                    {
                                        if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                                        {
                                            m_lcgs_folder[tvFolders.SelectedNode].PictureBitmap = ClPbHelper.ResizeImage((Image)(new Bitmap(bm2)), 226, 226);
                                            if (sExt != ".png")
                                            {
                                                String sNameWithoutExt = sFileList[0];
                                                int iExt = sFileList[0].LastIndexOf(".");
                                                if (iExt > -1)
                                                {
                                                    sNameWithoutExt = sFileList[0].Substring(0, iExt);
                                                }
                                                m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sNameWithoutExt + ".png";
                                            }
                                            else
                                            {
                                                m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sFileList[0];
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (Bitmap bmPicture = new Bitmap(sFileList[0]))
                            {
                                pbCurrentFolder.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bmPicture)), 226, 226);
                                if (tvFolders.SelectedNode != null)
                                {
                                    if (m_lcgs_folder.ContainsKey(tvFolders.SelectedNode))
                                    {
                                        m_lcgs_folder[tvFolders.SelectedNode].PictureBitmap = ClPbHelper.ResizeImage((Image)(new Bitmap(bmPicture)), 226, 226);
                                        if (sExt != ".png")
                                        {
                                            String sNameWithoutExt = sFileList[0];
                                            int iExt = sFileList[0].LastIndexOf(".");
                                            if (iExt > -1)
                                            {
                                                sNameWithoutExt = sFileList[0].Substring(0, iExt);
                                            }
                                            m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sNameWithoutExt + ".png";
                                        }
                                        else
                                        {
                                            m_lcgs_folder[tvFolders.SelectedNode].PicturePath = sFileList[0];
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        slLogger.Error("Extension " + sExt + " not accepted. Dragdrop a file with extension png, bmp, jpg or jpeg.");
                    }
                }
                else
                {
                    FlexibleMessageBox.Show("Only one file for drag&drop operation please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    slLogger.Error("Dragdrop only one file please.");
                }
            }
            catch (Exception ex)
            {
                slLogger.Fatal(ex.Message);
            }
            finally
            {
                e.Data.SetData(new Object());
            }
            slLogger.Trace("<< Dragdrop image");
        }

        private void pbCurrentFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }
    }
}
