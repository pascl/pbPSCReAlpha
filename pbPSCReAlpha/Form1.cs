using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace pbPSCReAlpha
{
    public partial class Form1 : Form
    {
        Dictionary<String, ClPS1Game> dcPs1Games;
        List<String> lsFolders;
        List<String> lsTitles;

        public Form1()
        {
            InitializeComponent();
            tabControlAll.TabPages.Remove(tabResortAlphabetic);
            dcPs1Games = new Dictionary<string, ClPS1Game>();
            tbFolderPath.Text = Properties.Settings.Default.sFolderPath;
            try
            {
                using (XmlTextReader xmlreader = new XmlTextReader(Application.StartupPath + "\\" + "ps1games.xml"))
                {
                    String mykey = String.Empty;
                    String mylink = String.Empty;
                    String myvalue = String.Empty;
                    while (xmlreader.Read())
                    {
                        switch (xmlreader.NodeType)
                        {
                            case XmlNodeType.Element:
                                // Console.WriteLine(xmlreader.Name);
                                if ("game" == xmlreader.Name)
                                {
                                    while (xmlreader.MoveToNextAttribute())
                                    {
                                        // Console.Write(" " + xmlreader.Name + "='" + xmlreader.Value + "'");
                                        if ("serial" == xmlreader.Name)
                                        {
                                            mykey = xmlreader.Value;
                                        }
                                        else if ("link" == xmlreader.Name)
                                        {
                                            mylink = xmlreader.Value;
                                        }
                                    }
                                }
                                break;
                            case XmlNodeType.Text:
                                // Console.WriteLine(xmlreader.Value);
                                myvalue = xmlreader.Value;
                                if (!dcPs1Games.ContainsKey(mykey))
                                {
                                    dcPs1Games.Add(mykey, new ClPS1Game(myvalue, mykey, mylink));
                                    myvalue = String.Empty;
                                    mykey = String.Empty;
                                    mylink = String.Empty;
                                }
                                break;
                            case XmlNodeType.EndElement:
                                //
                                break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                tbLogExplorer.AppendText(ex.Message + "\n");
            }
        }

        private void btCrowseGamesFolder_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == fbdGamesFolder.ShowDialog())
            {
                String sFolderPath = fbdGamesFolder.SelectedPath;
                tbFolderPath.Text = sFolderPath;
            }
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            List<String> lsTitles = new List<string>();
            Dictionary<String, int> dcTitleIndexes = new Dictionary<string, int>();
            String sFolderPath = tbFolderPath.Text;
            bool bStartAt21 = cbStartAt21.Checked;
            try
            {
                var fileList = new DirectoryInfo(sFolderPath).GetFiles("*.ini", SearchOption.AllDirectories);
                foreach(FileInfo fi in fileList)
                {
                    String s1 = fi.DirectoryName.Substring(sFolderPath.Length);
                    if(s1.StartsWith("\\"))
                    {
                        s1 = s1.Substring(1);
                    }
                    //tbLog.AppendText(s1 + "\n");
                    String[] s2 = s1.Split('\\');
                    s1 = s2[0];
                    int index = int.Parse(s1);
                    String sTitle = "Undefined";
                    String sAlphaTitle = "Undefined";
                    if (((bStartAt21) && (index >= 21)) || (!bStartAt21))
                    {
                        using (StreamReader sr = new StreamReader(fi.FullName))
                        {
                            string s = "";
                            bool alphaTitle = false;
                            while ((s = sr.ReadLine()) != null)
                            {
                                if (s.StartsWith("Title="))
                                {
                                    if (!alphaTitle)
                                    {
                                        sTitle = s.Substring(6).Trim();
                                    }
                                }
                                if (s.StartsWith("AlphaTitle="))
                                {
                                    alphaTitle = true;
                                    sAlphaTitle = s.Substring(11).Trim();
                                }
                            }
                            if (alphaTitle)
                            {
                                tbLog.AppendText("Found: " + s1 + " " + sAlphaTitle + " (" + sTitle + ")" + "\n");
                                lsTitles.Add(sAlphaTitle);
                                dcTitleIndexes.Add(sAlphaTitle, index);
                            }
                            else
                            { 
                                tbLog.AppendText("Found: " + s1 + " " + sTitle + "\n");
                                lsTitles.Add(sTitle);
                                dcTitleIndexes.Add(sTitle, index);
                            }
                        }
                        //tbLog.AppendText(fi.DirectoryName + " -- " + fi.Name + "\n");
                    }
                }
                foreach(FileInfo fi in fileList)
                {
                    String s1 = fi.DirectoryName.Substring(sFolderPath.Length);
                    if (s1.StartsWith("\\"))
                    {
                        s1 = s1.Substring(1);
                    }
                    //tbLog.AppendText(s1 + "\n");
                    String[] s2 = s1.Split('\\');
                    s1 = s2[0];
                    int index = int.Parse(s1);
                    if (((bStartAt21) && (index >= 21)) || (!bStartAt21))
                    {
                        Thread.Sleep(100);
                        //tbLog.AppendText("o: " + sFolderPath + "\\" + index.ToString() + "\ts: " + sFolderPath + "\\" + (index + 1000).ToString() + "\n");
                        Directory.Move(sFolderPath + "\\" + index.ToString(), sFolderPath + "\\" + (index + 1000).ToString());
                    }
                }
                if(lsTitles.Count > 0)
                {
                    using (NaturalComparer comparer = new NaturalComparer())
                    {
                        lsTitles.Sort(comparer);
                    }
                    int newindex = 1;
                    if (bStartAt21)
                    {
                        newindex = 21;
                    }
                    foreach(String s in lsTitles)
                    {
                        Thread.Sleep(100);
                        int oldindex = dcTitleIndexes[s];
                        Directory.Move(sFolderPath + "\\" + (oldindex + 1000).ToString(), sFolderPath + "\\" + newindex.ToString());
                        tbLog.AppendText("New: " + newindex.ToString() + " " + s + "\n");
                        newindex++;
                    }
                }
            }
            catch (Exception ex)
            {
                tbLogExplorer.AppendText(ex.Message + "\n");
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            List<String> lsTest = new List<string>();
            lsTest.Add("Toto");
            lsTest.Add("Fighting Force 2");
            lsTest.Add("Machin");
            lsTest.Add("Fighting Force");
            lsTest.Add("Tekken");
            lsTest.Add("Final Fantasy IX");
            lsTest.Add("Tekken 3");
            lsTest.Add("Tekken 2");
            lsTest.Add("Final Fantasy VII");
            lsTest.Add("Tototi");
            lsTest.Add("Final Fantasy VIII");
            lsTest.Add("Toto ti");
            lsTest.Add("Toto ti6");
            using (NaturalComparer comparer = new NaturalComparer())
            {
                lsTest.Sort(comparer);
            }
            foreach(String s in lsTest)
            {
                tbLog.AppendText(s + "\n");
            }
        }

        private void btGenerateIni_Click(object sender, EventArgs e)
        {
            String s1 = tbGeneTitle.Text.Trim(); // have to be not empty
            String s2 = tbGeneDiscs.Text.Trim(); // have to be not empty
            if ((!String.IsNullOrEmpty(s1)) && (!(String.IsNullOrEmpty(s2))))
            {
                String s3 = tbGenePublisher.Text.Trim();
                String s4 = tbGeneAlphaTitle.Text.Trim();
                int i1 = (int)(nuGenePlayers.Value);
                int i2 = (int)(nuGeneYear.Value);
                if (Directory.Exists(tbFolderPath.Text))
                {
                    sfdGeneSaveIni.InitialDirectory = tbFolderPath.Text;
                }
                if(DialogResult.OK == sfdGeneSaveIni.ShowDialog())
                {
                    String sFileName = sfdGeneSaveIni.FileName;
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sFileName))
                        {
                            sw.WriteLine("[Game]");
                            sw.WriteLine("Discs=" + s2);
                            sw.WriteLine("Title=" + s1);
                            sw.WriteLine("Publisher=" + s3);
                            sw.WriteLine("Players=" + i1.ToString());
                            sw.WriteLine("Year=" + i2.ToString());
                            if (!String.IsNullOrEmpty(s4))
                            {
                                sw.WriteLine("AlphaTitle=" + s4);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        tbLogExplorer.AppendText(ex.Message + "\n");
                    }
                }
            }
            else
                MessageBox.Show("You have to enter at least Title and Discs to continue...");
        }

        private void btLoadIni_Click(object sender, EventArgs e)
        {
            //
            if(Directory.Exists(tbFolderPath.Text))
            {
                ofdGeneLoadIni.InitialDirectory = tbFolderPath.Text;
            }
            if (DialogResult.OK == ofdGeneLoadIni.ShowDialog())
            {
                String sFileName = ofdGeneLoadIni.FileName;
                try
                {
                    using (StreamReader sr = new StreamReader(sFileName))
                    {
                        String s;
                        tbGeneDiscs.Clear();
                        tbGeneTitle.Clear();
                        tbGeneAlphaTitle.Clear();
                        tbGenePublisher.Clear();
                        nuGenePlayers.Value = (decimal)1;
                        nuGeneYear.Value = (decimal)1995;
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.StartsWith("Discs="))
                            {
                                tbGeneDiscs.Text = s.Substring(6);
                            }
                            else
                            if (s.StartsWith("Title="))
                            {
                                tbGeneTitle.Text = s.Substring(6);
                            }
                            else
                            if (s.StartsWith("Publisher="))
                            {
                                tbGenePublisher.Text = s.Substring(10);
                            }
                            else
                            if (s.StartsWith("Players="))
                            {
                                try
                                {
                                    nuGenePlayers.Value = (decimal)(int.Parse(s.Substring(8)));
                                }
                                catch (Exception ex)
                                {
                                    //
                                }
                            }
                            else
                            if (s.StartsWith("Year="))
                            {
                                try
                                {
                                    nuGeneYear.Value = (decimal)(int.Parse(s.Substring(5)));
                                }
                                catch (Exception ex)
                                {
                                    //
                                }
                            }
                            else
                            if (s.StartsWith("AlphaTitle="))
                            {
                                tbGeneAlphaTitle.Text = s.Substring(11);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    tbLogExplorer.AppendText(ex.Message + "\n");
                }
            }
        }

        private void btGeneCopyTitle_Click(object sender, EventArgs e)
        {
            tbGeneAlphaTitle.Text = tbGeneTitle.Text.Trim();
        }

        private void btGeneSearch_Click(object sender, EventArgs e)
        {
            String s = tbGeneSearchText.Text.Trim().ToUpper();
            lbGeneBigData.Items.Clear();
            lbGeneBigData.DisplayMember = "DisplayTitle";
            tbHiddenLink.Text = "";
            //btDownInfo.Enabled = false;
            if (dcPs1Games.Count > 0)
            {
                if (s.Length > 2)
                {
                    foreach (KeyValuePair<string, ClPS1Game> pair in dcPs1Games)
                    {
                        ClPS1Game c1 = pair.Value;
                        if (c1.Title.ToUpper().Contains(s))
                        {
                            lbGeneBigData.Items.Add(c1);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You have to enter at least 2 characters (other than space) to search something.");
                }
            }
            else
            {
                MessageBox.Show("Error. Gamelist not loaded.");
            }
        }

        private void lbGeneBigData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbGeneBigData.SelectedIndex > -1)
            {
                ClPS1Game psGame = (ClPS1Game)(lbGeneBigData.Items[lbGeneBigData.SelectedIndex]);
                tbGeneTitle.Text = psGame.Title.Trim();
                tbGeneDiscs.Text = psGame.Serial.Trim();
                tbHiddenLink.Text = psGame.Link.Trim();
                btLink.Enabled = true;
            }
        }
        
        private void btLink_Click(object sender, EventArgs e)
        {
            //
            String sLink = tbHiddenLink.Text.Trim();
            if (!String.IsNullOrEmpty(sLink))
            {
                System.Diagnostics.Process.Start("http://psxdatacenter.com/" + sLink);
            }
        }

        private Dictionary<String, ClGameStructure> generateGameListFolders(String sFolderPath, out List<String> lsFolders, out List<String> lsTitles)
        {
            Dictionary<String, ClGameStructure> dcGames = new Dictionary<String, ClGameStructure>();
            lsFolders = new List<String>();
            lsTitles = new List<string>();
            try
            {
                DirectoryInfo[] dirList = new DirectoryInfo(sFolderPath).GetDirectories("*", SearchOption.TopDirectoryOnly);
                foreach (DirectoryInfo di in dirList)
                {
                    tbLogExplorer.AppendText(di.FullName + "\n");
                    String sFolderIndex = di.FullName.Substring(sFolderPath.Length);
                    if (sFolderIndex.StartsWith("\\"))
                    {
                        sFolderIndex = sFolderIndex.Substring(1);
                    }
                    //tbLog.AppendText(sFolderIndex + "\n");
                    String[] s2 = sFolderIndex.Split('\\');
                    sFolderIndex = s2[0];
                    int index = -1;
                    bool bIsNumericFolderName = int.TryParse(sFolderIndex, out index);

                    if (Directory.Exists(di.FullName + "\\GameData"))
                    {
                        String sTitle = "Undefined";
                        String sAlphaTitle = String.Empty;
                        String sDiscs = String.Empty;
                        String sPublisher = String.Empty;
                        String sYear = String.Empty;
                        String sPlayers = String.Empty;
                        String sPicture = String.Empty;
                        String bmPictureString = String.Empty;
                        Bitmap bmPicture = new Bitmap(1, 1);
                        bool bAlphaTitlePresent = false;
                        bool bGameIniPresent = false;
                        bool bGameIniComplete = false;
                        bool bPcsxFilePresent = false;
                        bool bPicturePresent = false;
                        bool bPngMatchDisc = false;
                        bool bMultiPictures = false;
                        bool bCuePresent = false;
                        bool bBinPresent = false;
                        bool bDiscCountMatchCueCount = false;
                        bool bBadBinName = false;
                        bool bBadCueName = false;
                        UInt16 uiGameIni = 0;
                        int iNbDiscs = 0;
                        int iNbCue = 0;
                        int iNbBin = 0;
                        Dictionary<String, String[]> dcBinParsed = new Dictionary<String, String[]>();
                        List<String> lsBinPresent = new List<string>();
                        List<string> sFiles = new List<string>();
                        FileInfo[] inDirfileList = new DirectoryInfo(di.FullName + "\\GameData").GetFiles("*.*", SearchOption.AllDirectories);
                        foreach (FileInfo fi in inDirfileList)
                        {
                            sFiles.Add(fi.Name);
                            tbLogExplorer.AppendText(fi.Name + "\n");
                            if (fi.Extension == ".png")
                            {
                                if (bPicturePresent)
                                {
                                    bMultiPictures = true;
                                }
                                bPicturePresent = true;
                                bmPictureString = fi.FullName;
                                bmPicture = new Bitmap(bmPictureString);
                                sPicture = fi.Name.Substring(0, fi.Name.IndexOf(fi.Extension));
                            }
                            else
                            if (fi.Extension == ".cue")
                            {
                                bCuePresent = true;
                                iNbCue++;
                                String cueName = fi.Name.Substring(0, fi.Name.IndexOf(fi.Extension));
                                List<String> lsBinParsed = new List<String>();
                                using (StreamReader sr = new StreamReader(fi.FullName))
                                {
                                    string s = String.Empty;
                                    while ((s = sr.ReadLine()) != null)
                                    {
                                        s = s.Trim();
                                        if (s.ToUpper().StartsWith("FILE"))
                                        {
                                            int ipos1 = s.IndexOf("\"");
                                            int ipos2 = s.LastIndexOf("\"");
                                            if ((ipos1 > -1) && (ipos2 > -1) && (ipos1 != ipos2))
                                            {
                                                //
                                                String sBin = s.Substring(ipos1 + 1, ipos2 - ipos1 - 1);
                                                lsBinParsed.Add(sBin);
                                            }
                                        }
                                    }
                                    dcBinParsed.Add(cueName, lsBinParsed.ToArray());
                                }
                            }
                            else
                            if (fi.Extension == ".bin")
                            {
                                bBinPresent = true;
                                iNbBin++;
                                lsBinPresent.Add(fi.Name);
                            }
                            else
                            if (fi.Name == "pcsx.cfg")
                            {
                                bPcsxFilePresent = true;
                            }
                            else
                            if (fi.Name == "Game.ini")
                            {
                                bGameIniPresent = true;
                                using (StreamReader sr = new StreamReader(fi.FullName))
                                {
                                    string s = String.Empty;
                                    while ((s = sr.ReadLine()) != null)
                                    {
                                        if (s.StartsWith("Title="))
                                        {
                                            uiGameIni++;
                                            sTitle = s.Substring(6).Trim();
                                        }
                                        else
                                        if (s.StartsWith("Publisher="))
                                        {
                                            uiGameIni++;
                                            sPublisher = s.Substring(10).Trim();
                                        }
                                        else
                                        if (s.StartsWith("Year="))
                                        {
                                            uiGameIni++;
                                            sYear = s.Substring(5).Trim();
                                        }
                                        else
                                        if (s.StartsWith("Players="))
                                        {
                                            uiGameIni++;
                                            sPlayers = s.Substring(8).Trim();
                                        }
                                        else
                                        if (s.StartsWith("Discs="))
                                        {
                                            uiGameIni++;
                                            sDiscs = s.Substring(6).Trim();
                                        }
                                        else
                                        if (s.StartsWith("AlphaTitle="))
                                        {
                                            // facultative, doesn't count: uiGameIni++;
                                            bAlphaTitlePresent = true;
                                            sAlphaTitle = s.Substring(11).Trim();
                                        }
                                    }
                                }
                            }
                        }
                        List<String> lsVerboseError = new List<String>();
                        List<String> lsBinFilesOk = new List<String>();
                        List<String> lsCueFilesOk = new List<String>();
                        if ((bGameIniPresent) && (5 == uiGameIni))
                        {
                            String[] sDiscMulti = sDiscs.Split(',');
                            bGameIniComplete = true;
                            iNbDiscs = sDiscMulti.Length;
                            if (bPicturePresent)
                            {
                                if (sDiscMulti[0] == sPicture)
                                {
                                    bPngMatchDisc = true;
                                }
                            }
                            if (bCuePresent)
                            {
                                if (iNbCue == iNbDiscs)
                                {
                                    bDiscCountMatchCueCount = true;
                                    foreach (String s in sDiscMulti)
                                    {
                                        if (false == dcBinParsed.ContainsKey(s))
                                        {
                                            lsVerboseError.Add("Disc " + s + " doesn't have a matching cue file.");
                                            bBadCueName = true;
                                        }
                                        else
                                        {
                                            lsCueFilesOk.Add(s);
                                        }
                                    }
                                    foreach (String s in dcBinParsed.Keys)
                                    {
                                        if (-1 == Array.IndexOf(sDiscMulti, s))
                                        {
                                            lsVerboseError.Add("Cue file " + s + " dosen't have a matching disc.");
                                            bBadCueName = true;
                                        }
                                    }

                                    List<String> lsFound = new List<String>();
                                    foreach (KeyValuePair<String, String[]> entry in dcBinParsed)
                                    {
                                        // do something with entry.Value or entry.Key
                                        foreach (String s in entry.Value)
                                        {
                                            int iS = lsBinPresent.IndexOf(s);
                                            if (iS > -1)
                                            {
                                                lsFound.Add(s);
                                                lsBinFilesOk.Add(s);
                                            }
                                            else
                                            {
                                                bBadBinName = true;
                                                lsVerboseError.Add("File " + entry.Key + " wants a file not found: " + s);
                                            }
                                        }
                                    }
                                    if (lsFound.Count != lsBinPresent.Count)
                                    {
                                        foreach (String s in lsBinPresent)
                                        {
                                            int iS = lsFound.IndexOf(s);
                                            if (iS == -1)
                                            {
                                                bBadBinName = true;
                                                lsVerboseError.Add("File " + s + " present but not used by any cue file");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        ClGameStructure cgs = new ClGameStructure(sFolderIndex, !bIsNumericFolderName, !bGameIniPresent, !bPcsxFilePresent, !bPicturePresent, !bPngMatchDisc, !bGameIniComplete, bMultiPictures, !bCuePresent, bBadCueName, !bBinPresent, bBadBinName, !bDiscCountMatchCueCount);
                        cgs.setIniInfos(sTitle, sDiscs, sPublisher, sYear, sPlayers, sAlphaTitle);
                        cgs.setFilesList(sFiles);
                        cgs.setPicture(bmPictureString, (Image)(new Bitmap(bmPicture)));
                        bmPicture.Dispose();
                        lsFolders.Add(sFolderIndex);
                        if(bAlphaTitlePresent)
                        {
                            lsTitles.Add(sAlphaTitle);
                        }
                        else
                        {
                            lsTitles.Add(sTitle);
                        }
                        foreach (String s in lsVerboseError)
                        {
                            cgs.ErrorString.Add(s + "\n");
                        }
                        cgs.FilesBinOk = lsBinFilesOk;
                        cgs.FilesCueOk = lsCueFilesOk;
                        dcGames.Add(sFolderIndex, cgs);
                    }
                    else
                    {
                        ClGameStructure cgs = new ClGameStructure(sFolderIndex, !bIsNumericFolderName, true);
                        lsFolders.Add(sFolderIndex);
                        dcGames.Add(sFolderIndex, cgs);
                    }
                } // foreach
                if (lsFolders.Count > 0)
                {
                    using (NaturalComparer comparer = new NaturalComparer())
                    {
                        lsFolders.Sort(comparer);
                    }
                }
                if (lsTitles.Count > 0)
                {
                    using (NaturalComparer comparer = new NaturalComparer())
                    {
                        lsTitles.Sort(comparer);
                    }
                }
            }
            catch(Exception ex)
            {
                tbLogExplorer.AppendText(ex.Message + "\n");
            }
            return dcGames;
        }

        private void refreshGameListFolders()
        {
            btReSort.Enabled = false;
            lbGames.Items.Clear();
            String sFolderPath = tbFolderPath.Text;
            Dictionary<String, ClGameStructure> dcGames = generateGameListFolders(sFolderPath, out lsFolders, out lsTitles);
            if (lsFolders.Count > 0)
            {
                lbGames.DisplayMember = "IndexAndTitle";
                foreach (string s in lsFolders)
                {
                    if (dcGames.ContainsKey(s))
                    {
                        lbGames.Items.Add(dcGames[s]);
                    }
                }
                btReSort.Enabled = true;
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            refreshGameListFolders();
        }

        private void lbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            if (lbGames.SelectedIndex > -1)
            {
                ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                lbExploreTitle.Text = cgs.Title;
                lbExploreDiscs.Text = cgs.Discs;
                lbExplorePlayers.Text = cgs.Players;
                lbExplorePublisher.Text = cgs.Publisher;
                lbExploreYear.Text = cgs.Year;
                lbExploreAlphaTitle.Text = cgs.Alphatitle;
                try
                {
                    /*pbExploreImage.ImageLocation = cgs.PictureFileName;
                    pbExploreImage.Load();*/
                    pbExploreImage.Image = cgs.PictureFile; //  Image.FromFile(cgs.PictureFileName);
                }
                catch (Exception ex)
                {
                    tbLogExplorer.AppendText(ex.Message + "\n");
                }
                lvFiles.Items.Clear();
                if ((cgs.Filenames != null) && (cgs.Filenames.Count > 0))
                {
                    foreach (String s in cgs.Filenames)
                    {
                        int iIndexImg = 0; // 0=?, 1=ok, 2=ko, 3=warn, 4=info
                        if (true == cgs.GeneralError)
                        {
                            if ((s == "pcsx.cfg") && (!cgs.CfgMissing))
                            {
                                iIndexImg = 1;
                            }
                            else
                            if ((s.EndsWith(".png")) && (!cgs.PngMissing))
                            {
                                if ((!cgs.PngMismatch) && (!cgs.PngMultiple))
                                {
                                    iIndexImg = 1;
                                }
                                else
                                {
                                    if (cgs.PngMismatch)
                                    {
                                        iIndexImg = 2;
                                    }
                                    if (cgs.PngMultiple)
                                    {
                                        iIndexImg = 3;
                                    }
                                }
                            }
                            else
                            if (s.EndsWith(".bin"))
                            {
                                if(cgs.FilesBinOk.IndexOf(s) > -1)
                                {
                                    iIndexImg = 1;
                                }
                                else
                                {
                                    iIndexImg = 3;
                                }
                            }
                            else
                            if (s.EndsWith(".cue"))
                            {
                                if (cgs.FilesCueOk.IndexOf(s) > -1)
                                {
                                    iIndexImg = 1;
                                }
                                else
                                {
                                    iIndexImg = 3;
                                }
                            }
                            else
                            if (s == "Game.ini")
                            {
                                if (cgs.IniIncomplete)
                                {
                                    iIndexImg = 2;
                                }
                                else
                                {
                                    iIndexImg = 1;
                                }
                            }
                        }
                        else
                        if ((s == "pcsx.cfg") || (s == "Game.ini") || (s.EndsWith(".cue")) || (s.EndsWith(".bin")) || (s.EndsWith(".png")))
                        {
                            iIndexImg = 1;
                        }
                        lvFiles.Items.Add(s, iIndexImg);
                    }
                }
                tbErrString.Clear();
                if ((cgs.ErrorString != null) && (cgs.ErrorString.Count > 0))
                {
                    foreach (String s in cgs.ErrorString)
                    {
                        tbErrString.AppendText(s + "\n");
                    }
                }
            }
        }

        private void btReSort_Click(object sender, EventArgs e)
        {
            int iDecalage = 3000;
            String sFolderPath = tbFolderPath.Text;
            // refresh without updating display, reupdate at the end
            Dictionary<String, ClGameStructure> dcGames = generateGameListFolders(sFolderPath, out lsFolders, out lsTitles);
            if (lsFolders.Count > 0)
            {
                bool bCanContinue = true;
                foreach (KeyValuePair<String, ClGameStructure> pair in dcGames)
                {
                    ClGameStructure c1 = pair.Value;
                    bCanContinue &= (!c1.NanFolder);
                }
                if (bCanContinue)
                {
                    try
                    {
                        foreach (String s in lsFolders)
                        {
                            if (dcGames.ContainsKey(s))
                            {
                                int index = int.Parse(s);
                                Directory.Move(sFolderPath + "\\" + index.ToString(), sFolderPath + "\\" + (index + iDecalage).ToString());
                                //lbGames.Items.Add(dcGames[s]);
                            }
                        }
                        int iNewIndex = 1;
                        foreach (String s in lsTitles)
                        {
                            foreach (KeyValuePair<String, ClGameStructure> pair in dcGames)
                            {
                                ClGameStructure c1 = pair.Value;
                                int iIndexFolder = int.Parse(c1.FolderIndex);
                                if (((c1.Alphatitle != String.Empty) && (c1.Alphatitle == s)) || ((c1.Alphatitle == String.Empty) && (c1.Title == s)))
                                {
                                    Directory.Move(sFolderPath + "\\" + (iIndexFolder + iDecalage).ToString(), sFolderPath + "\\" + (iNewIndex).ToString());
                                    iNewIndex++;
                                    break;
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        tbLogExplorer.AppendText(ex.Message + "\n");
                    }
                    refreshGameListFolders();
                }
                else
                {
                    MessageBox.Show("Correct the wrong folder names before doing this.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.sFolderPath = tbFolderPath.Text;
            Properties.Settings.Default.Save();
        }
    }
}
