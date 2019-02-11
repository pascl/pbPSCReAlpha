using Markdig;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
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
        List<String> lsSbiNeeds;
        SimpleLogger slLogger;
        bool bAccessingDebugTab = false;
        Form5 frmCopy = null;
        ClVersionHelper currentUsedVersion;
        int iBleemsyncVersion;
        int iSimultaneous = 2;
        ClVersionHelper[] bleemsyncVersions;

        public Form1(Dictionary<string, ClPS1Game> ps1games)
        {
            InitializeComponent();
            this.Text = "pbPSCReAlpha v" + Assembly.GetExecutingAssembly().GetName().Version;

            iSimultaneous = Properties.Settings.Default.iSimultaneous;
            if (iSimultaneous <= 0)
            {
                iSimultaneous = 1;
            }
            cbSimultaneousCopiedFiles.SelectedIndex = iSimultaneous - 1;
            lbCurrentSimultaneousCopiedFiles.Text = iSimultaneous.ToString();

            this.frmCopy = new Form5(iSimultaneous);
            this.frmCopy.Visible = false;

            dcPs1Games = ps1games;
            lsSbiNeeds = new List<string>();
            String sFolderPath = Properties.Settings.Default.sFolderPath;
            tbFolderPath.Text = sFolderPath;
            bleemsyncVersions = new ClVersionHelper[2];
            bleemsyncVersions[0] = new ClVersionHelper("0.4.1", "\\GameData", "\\.pcsx", "\\System\\Databases", "\\BleemSync");
            bleemsyncVersions[1] = new ClVersionHelper("1.0.0", "", "\\.pcsx", "\\bleemsync\\etc\\bleemsync\\SYS\\databases", String.Empty);
            iBleemsyncVersion = Properties.Settings.Default.iVersionBleemSync;
            currentUsedVersion = bleemsyncVersions[iBleemsyncVersion];
            tsmiBSVersionItem.Text = "Currently use BleemSync v" + currentUsedVersion.Versionstring;

            slLogger = new SimpleLogger(tbLogDebug);
            
            try
            {
                using (XmlTextReader xmlreader = new XmlTextReader(Application.StartupPath + "\\" + "sbigames.xml"))
                {
                    String myvalue = String.Empty;
                    while (xmlreader.Read())
                    {
                        switch (xmlreader.NodeType)
                        {
                            case XmlNodeType.Element:
                                // Console.WriteLine(xmlreader.Name);
                                if ("sbi" == xmlreader.Name)
                                {
                                    // don't care no attributes
                                }
                                break;
                            case XmlNodeType.Text:
                                // Console.WriteLine(xmlreader.Value);
                                myvalue = xmlreader.Value;
                                if (lsSbiNeeds.IndexOf(myvalue) == -1)
                                {
                                    lsSbiNeeds.Add(myvalue);
                                    myvalue = String.Empty;
                                }
                                break;
                            case XmlNodeType.EndElement:
                                //
                                break;
                        }
                    }
                    slLogger.Debug("Found \"sbi needed\" games in xml: " + lsSbiNeeds.Count.ToString());
                }
            }
            catch (Exception ex)
            {
                slLogger.Fatal(ex.Message);
            }

            ReCalcFreeSpace(sFolderPath);

            String st = String.Empty;
            using (StreamReader sr = new StreamReader(Application.StartupPath + "\\" + "README.md"))
            {
                st = sr.ReadToEnd();
            }
            wbReadme.DocumentText = Markdown.ToHtml(st);
        }

        private void btCrowseGamesFolder_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Browse 'Games' Folder Click");
            if (DialogResult.OK == fbdGamesFolder.ShowDialog())
            {
                String sFolderPath = fbdGamesFolder.SelectedPath;
                tbFolderPath.Text = sFolderPath;
                ReCalcFreeSpace(sFolderPath);
            }
            slLogger.Trace("<< Browse 'Games' Folder Click");
        }

        private void ReCalcFreeSpace(String sFolderPath)
        {
            try
            {
                long lSpace = GetAvailableFreeSpace(sFolderPath.Substring(0, sFolderPath.IndexOf('\\') + 1));
                lbFreeSpace.Text = "(" + ClPbHelper.FormatBytes(lSpace) + ")";
            }
            catch (Exception ex)
            {
                slLogger.Fatal(ex.Message);
            }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Test Sort Click");
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
            foreach (String s in lsTest)
            {
                slLogger.Debug(s);
            }
            slLogger.Trace("<< Test Sort Click");
        }

        private ClGameStructure manageFolder(String sFolderIndex, DirectoryInfo di, ref List<String> lsFolders, ref List<String> lsTitles, bool bInitial = true)
        {
            ClGameStructure cgs = null;
            int index = -1;
            bool bIsNumericFolderName = int.TryParse(sFolderIndex, out index);

            if (Directory.Exists(di.FullName + currentUsedVersion.GameDataFolder))
            {
                String sTitle = String.Empty;
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
                bool bPbpPresent = false;
                bool bSbiPresent = false;
                bool bNeededSbiMissing = false;
                bool bDiscCountMatchCueCount = false;
                bool bDiscCountMatchPbpCount = false;
                bool bBadBinName = false;
                bool bBadCueName = false;
                bool bBadPbpName = false;
                bool bNameWithComma = false;
                bool bBadDiscsName = false;
                UInt16 uiGameIni = 0;
                int iNbDiscs = 0;
                int iNbCue = 0;
                int iNbBin = 0;
                int iNbSbi = 0;
                int iNbPbp = 0;
                Dictionary<String, String[]> dcBinParsed = new Dictionary<String, String[]>();
                List<String> lsBinPresent = new List<string>();
                List<String> lsSbiPresent = new List<string>();
                List<String> lsPbpPresent = new List<string>();
                List<string> sFiles = new List<string>();
                FileInfo[] inDirfileList = new DirectoryInfo(di.FullName + currentUsedVersion.GameDataFolder).GetFiles("*.*", SearchOption.TopDirectoryOnly);
                long lSizeFolder = 0;
                foreach (FileInfo fi in inDirfileList)
                {
                    lSizeFolder += fi.Length;
                    sFiles.Add(fi.Name);
                    slLogger.Debug("**** File: " + fi.Name);
                    if(fi.Name.Contains(","))
                    {
                        bNameWithComma = true;
                    }
                    if (fi.Extension.ToLower() == ".png")
                    {
                        if (bPicturePresent)
                        {
                            bMultiPictures = true;
                        }
                        else
                        {
                            bPicturePresent = true;
                            bmPictureString = fi.FullName;
                            bmPicture = new Bitmap(bmPictureString);
                            sPicture = fi.Name.Substring(0, fi.Name.IndexOf(fi.Extension)).ToLower();
                        }
                    }
                    else
                    if (fi.Extension.ToLower() == ".pbp")
                    {
                        bPbpPresent = true;
                        iNbPbp++;
                        lsPbpPresent.Add(fi.Name.ToLower());
                    }
                    else
                    if (fi.Extension.ToLower() == ".cue")
                    {
                        bCuePresent = true;
                        iNbCue++;
                        String cueName = fi.Name.Substring(0, fi.Name.IndexOf(fi.Extension));
                        List<String> lsBinParsed = new List<String>();
                        try
                        {
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
                                            lsBinParsed.Add(sBin.ToLower());
                                        }
                                    }
                                }
                                dcBinParsed.Add(cueName.ToLower(), lsBinParsed.ToArray());
                            }
                        }
                        catch(Exception ex)
                        {
                            slLogger.Fatal(ex.Message);
                        }
                    }
                    else
                    if (fi.Extension.ToLower() == ".bin")
                    {
                        bBinPresent = true;
                        iNbBin++;
                        lsBinPresent.Add(fi.Name.ToLower());
                    }
                    else
                    if (fi.Extension.ToLower() == ".sbi")
                    {
                        bSbiPresent = true;
                        iNbSbi++;
                        lsSbiPresent.Add(fi.Name.Substring(0, fi.Name.IndexOf(fi.Extension)).ToLower());
                    }
                    else
                    if (fi.Name.ToLower() == "pcsx.cfg")
                    {
                        bPcsxFilePresent = true;
                    }
                    else
                    if (fi.Name.ToLower() == "game.ini") // (fi.Name == "Game.ini")
                    {
                        try
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
                                        sTitle = s.Substring(6);
                                        sTitle = ClPbHelper.RemoveQuotes(sTitle);
                                    }
                                    else
                                    if (s.StartsWith("Publisher="))
                                    {
                                        uiGameIni++;
                                        sPublisher = s.Substring(10);
                                        sPublisher = ClPbHelper.RemoveQuotes(sPublisher);
                                    }
                                    else
                                    if (s.StartsWith("Year="))
                                    {
                                        uiGameIni++;
                                        sYear = s.Substring(5);
                                        sYear = ClPbHelper.RemoveQuotes(sYear);
                                    }
                                    else
                                    if (s.StartsWith("Players="))
                                    {
                                        uiGameIni++;
                                        sPlayers = s.Substring(8);
                                        sPlayers = ClPbHelper.RemoveQuotes(sPlayers);
                                    }
                                    else
                                    if (s.StartsWith("Discs="))
                                    {
                                        uiGameIni++;
                                        sDiscs = s.Substring(6);
                                        sDiscs = ClPbHelper.RemoveQuotes(sDiscs);
                                    }
                                    else
                                    if (s.StartsWith("AlphaTitle="))
                                    {
                                        // facultative, doesn't count: uiGameIni++;
                                        bAlphaTitlePresent = true;
                                        sAlphaTitle = s.Substring(11);
                                        sAlphaTitle = ClPbHelper.RemoveQuotes(sAlphaTitle);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            slLogger.Fatal(ex.Message);
                        }
                    }
                }
                List<String> lsVerboseError = new List<String>();
                List<String> lsBinFilesOk = new List<String>();
                List<String> lsCueFilesOk = new List<String>();
                List<String> lsPbpFilesOk = new List<String>();
                List<String> lsSbiFilesOk = new List<String>();
                if ((bGameIniPresent) && (5 == uiGameIni))
                {
                    String[] sDiscMulti = sDiscs.ToLower().Split(',');
                    bGameIniComplete = true;
                    iNbDiscs = sDiscMulti.Length;
                    if (bPicturePresent)
                    {
                        if (sDiscMulti[0] == sPicture)
                        {
                            bPngMatchDisc = true;
                        }
                    }
                    if((iBleemsyncVersion == 1) && (bPbpPresent))
                    {
                        if (iNbPbp == iNbDiscs)
                        {
                            bDiscCountMatchPbpCount = true;
                            foreach (String sDisc in sDiscMulti)
                            {
                                String s = sDisc.ToLower() + ".pbp";
                                if (((s.IndexOf("e") == 2) || (s.IndexOf("u") == 2) || (s.IndexOf("p") == 2)) && (s.IndexOf("-") != 4))
                                {
                                    lsVerboseError.Add("!! If this game doesn't run, maybe rename " + sDisc + " in Discs and change the 3rd letter with 'p' for a Japanese game, 'u' for a US game or 'e' for an European game.");
                                    bBadDiscsName = true;
                                }
                                if (lsPbpPresent.IndexOf(s) == -1)
                                {
                                    lsVerboseError.Add("Disc " + sDisc + " doesn't have a matching pbp file.");
                                    bBadPbpName = true;
                                }
                                else
                                {
                                    lsPbpFilesOk.Add(s);
                                }
                            }
                        }
                    }
                    else
                    if (bCuePresent)
                    {
                        if (iNbCue == iNbDiscs)
                        {
                            bDiscCountMatchCueCount = true;
                            foreach (String sDisc in sDiscMulti)
                            {
                                String s = sDisc.ToLower();
                                if (((s.IndexOf("e") == 2) || (s.IndexOf("u") == 2) || (s.IndexOf("p") == 2)) && (s.IndexOf("-") != 4))
                                {
                                    lsVerboseError.Add("!! If this game doesn't run, maybe rename " + sDisc + " in Discs and change the 3rd letter with 'p' for a Japanese game, 'u' for a US game or 'e' for an European game.");
                                    bBadDiscsName = true;
                                }
                                if (false == dcBinParsed.ContainsKey(s))
                                {
                                    lsVerboseError.Add("Disc " + sDisc + " doesn't have a matching cue file.");
                                    bBadCueName = true;
                                }
                                else
                                {
                                    lsCueFilesOk.Add(s + ".cue");
                                }
                                String s1 = sDisc.ToUpper();
                                if (lsSbiNeeds.IndexOf(s1) > -1)
                                {
                                    if (lsSbiPresent.IndexOf(s) == -1)
                                    {
                                        // err
                                        lsVerboseError.Add("Sbi file for " + s + " not found.");
                                        bNeededSbiMissing = true;
                                    }
                                    else
                                    {
                                        // ok
                                        lsSbiFilesOk.Add(s + ".sbi");
                                    }
                                }
                            }
                            foreach (String sCue in dcBinParsed.Keys)
                            {
                                String s = sCue.ToLower();
                                if (-1 == Array.IndexOf(sDiscMulti, s))
                                {
                                    lsVerboseError.Add("Cue file " + sCue + " doesn't have a matching disc.");
                                    bBadCueName = true;
                                }
                            }

                            List<String> lsFound = new List<String>();
                            foreach (KeyValuePair<String, String[]> entry in dcBinParsed)
                            {
                                // do something with entry.Value or entry.Key
                                foreach (String sFile in entry.Value)
                                {
                                    String s = sFile.ToLower();
                                    int iS = lsBinPresent.IndexOf(s);
                                    if (iS > -1)
                                    {
                                        lsFound.Add(s);
                                        lsBinFilesOk.Add(s);
                                    }
                                    else
                                    {
                                        bBadBinName = true;
                                        lsVerboseError.Add("File " + entry.Key + " wants a file not found: " + sFile);
                                    }
                                }
                            }
                            if (lsFound.Count != lsBinPresent.Count)
                            {
                                foreach (String sFile in lsBinPresent)
                                {
                                    String s = sFile.ToLower();
                                    int iS = lsFound.IndexOf(s);
                                    if (iS == -1)
                                    {
                                        bBadBinName = true;
                                        lsVerboseError.Add("File " + sFile + " present but not used by any cue file");
                                    }
                                }
                            }
                        }
                    }
                }
                /*if(1 == iBleemsyncVersion)
                {
                    // facultative for 1.0.0
                    bPcsxFilePresent = true;
                }*/
                cgs = new ClGameStructure(sFolderIndex, !bIsNumericFolderName, !bGameIniPresent, !bPcsxFilePresent, !bPicturePresent, !bPngMatchDisc, !bGameIniComplete, bMultiPictures, !bCuePresent, bBadCueName, !bBinPresent, bBadBinName, !bDiscCountMatchCueCount, bNeededSbiMissing, bNameWithComma, !bPbpPresent, bBadPbpName, !bDiscCountMatchPbpCount, bBadDiscsName, iBleemsyncVersion);
                if (bGameIniPresent)
                {
                    cgs.setIniInfos(sTitle, sDiscs, sPublisher, sYear, sPlayers, sAlphaTitle);
                }
                cgs.setFilesList(sFiles);
                cgs.setPicture(bmPictureString, (Image)(new Bitmap(bmPicture)));
                bmPicture.Dispose();
                cgs.setSize(lSizeFolder);
                if (true == bInitial)
                {
                    lsFolders.Add(sFolderIndex);
                    if (bAlphaTitlePresent)
                    {
                        lsTitles.Add(sAlphaTitle);
                    }
                    else
                    {
                        lsTitles.Add(sTitle);
                    }
                }
                foreach (String s in lsVerboseError)
                {
                    cgs.ErrorString.Add(s + "\n");
                }
                cgs.FilesBinOk = lsBinFilesOk;
                cgs.FilesCueOk = lsCueFilesOk;
                cgs.FilesSbiOk = lsSbiFilesOk;
                cgs.FilesPbpOk = lsPbpFilesOk;
            }
            else
            {
                cgs = new ClGameStructure(sFolderIndex, !bIsNumericFolderName, true);
                if (true == bInitial)
                {
                    lsFolders.Add(sFolderIndex);
                }
            }
            return cgs;
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

                    slLogger.Debug("** Directory: " + di.FullName);
                    String sFolderIndex = di.FullName.Substring(sFolderPath.Length);
                    if (sFolderIndex.StartsWith("\\"))
                    {
                        sFolderIndex = sFolderIndex.Substring(1);
                    }
                    String[] s2 = sFolderIndex.Split('\\');
                    sFolderIndex = s2[0];
                    ClGameStructure cgs = manageFolder(sFolderIndex, di, ref lsFolders, ref lsTitles);
                    if (cgs != null)
                    {
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
            catch (Exception ex)
            {
                slLogger.Fatal(ex.Message);
            }
            return dcGames;
        }

        private void refreshGameListFolders()
        {
            btReSort.Enabled = false;
            btNewFolder.Enabled = false;
            btLaunchPngquant.Enabled = false;
            int iSelected = -1;
            ClGameStructure cgs = null;
            if (lbGames.SelectedIndex > -1)
            {
                iSelected = lbGames.SelectedIndex;
                cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
            }
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
                        if (iSelected > -1)
                        {
                            if (((cgs.Alphatitle != String.Empty) && (dcGames[s].Alphatitle == cgs.Alphatitle)) || ((cgs.Alphatitle == String.Empty) && (dcGames[s].Title == cgs.Title))) // if (s == cgs.FolderIndex)
                            {
                                lbGames.SelectedIndex = lbGames.Items.Count - 1;
                            }
                        }
                    }
                }
                btReSort.Enabled = true;
                btNewFolder.Enabled = true;
                btLaunchPngquant.Enabled = true;
            }
            else
            {
                btNewFolder.Enabled = true;
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Refresh gamelist Click");
            refreshGameListFolders();
            slLogger.Trace("<< Refresh gamelist Click");
        }

        private void lbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            //slLogger.Trace(">> Game Selection changed in gamelist");
            if (lbGames.SelectedIndex > -1)
            {
                refreshOneFolder(false);
                lbFolderSize.Visible = true;
                lbFolderSizeLabel.Visible = true;
                ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                lbExploreTitle.Text = cgs.Title;
                lbExploreDiscs.Text = cgs.Discs;
                lbExplorePlayers.Text = cgs.Players;
                lbExplorePublisher.Text = cgs.Publisher;
                lbExploreYear.Text = cgs.Year;
                lbExploreAlphaTitle.Text = cgs.Alphatitle;
                lbFolderSize.Text = ClPbHelper.FormatBytes(cgs.FolderSize);
                gbAutoRename.Visible = true;
                try
                {
                    /*pbExploreImage.ImageLocation = cgs.PictureFileName;
                    pbExploreImage.Load();*/
                    pbExploreImage.Image = cgs.PictureFile; //  Image.FromFile(cgs.PictureFileName);
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                pbExploreImage.AllowDrop = true;
                lvFiles.Items.Clear();
                if ((cgs.Filenames != null) && (cgs.Filenames.Count > 0))
                {
                    foreach (String sFile in cgs.Filenames)
                    {
                        String s = sFile.ToLower();
                        int iIndexImg = 0; // 0=?, 1=ok, 2=ko, 3=warn, 4=info
                        if (true == cgs.GeneralError)
                        {
                            if ((cgs.CommaInFilename) && (s.Contains(",")))
                            {
                                iIndexImg = 3;
                            }
                            else
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
                            if (s.EndsWith(".pbp"))
                            {
                                if (cgs.FilesPbpOk.IndexOf(s) > -1)
                                {
                                    iIndexImg = 1;
                                }
                                else
                                {
                                    iIndexImg = 3;
                                }
                            }
                            else
                            if (s.EndsWith(".bin"))
                            {
                                if (cgs.FilesBinOk.IndexOf(s) > -1)
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
                            if (s.EndsWith(".sbi"))
                            {
                                if (cgs.Discs.ToLower().Contains(s.Substring(0, s.Length - 4)))
                                {
                                    if (cgs.FilesSbiOk.IndexOf(s) > -1)
                                    {
                                        iIndexImg = 1;
                                    }
                                    else
                                    {
                                        iIndexImg = 3;
                                    }
                                }
                            }
                            else
                            if (s == "game.ini") //if (s == "Game.ini")
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
                        //if ((s == "pcsx.cfg") || (s == "Game.ini") || (s.EndsWith(".cue")) || (s.EndsWith(".bin")) || (s.EndsWith(".png")))
                        if ((s == "pcsx.cfg") || (s == "game.ini") || (s.EndsWith(".cue")) || (s.EndsWith(".bin")) || (s.EndsWith(".pbp")) || (s.EndsWith(".png"))
                            || ((s.EndsWith(".sbi")) && (cgs.Discs.ToLower().Contains(s.Substring(0, s.Length - 4)))))
                        {
                            iIndexImg = 1;
                        }
                        lvFiles.Items.Add(sFile, iIndexImg);
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
                if (true == cgs.GeneralError)
                {
                    bool bPng = false;
                    bool bPbp = false;
                    bool bCue = false;
                    bool bBin = false;
                    bool bSbi = false;
                    if ((!cgs.IniMissing) && (!cgs.IniIncomplete))
                    {
                        if (!cgs.PngMissing) // png exist
                        {
                            if ((!cgs.PngMultiple) && (cgs.PngMismatch)) // only 1 png and not good name
                            {
                                bPng = true;
                            }
                        }
                        if (!cgs.PbpMissing) // pbp exist
                        {
                            if ((!cgs.PbpCountMisMatchDiscsCount) && (cgs.BadPbpName)) // numbers pbp and discs ok and bad pbp filename
                            {
                                bPbp = true;
                            }
                        }
                        if (!cgs.CueMissing) // cue exist
                        {
                            if ((!cgs.CueCountMisMatchDiscsCount) && (cgs.BadCueName)) // numbers cue and discs ok and bad cue filename
                            {
                                bCue = true;
                            }
                        }
                        if(cgs.NeededSbiMissing)
                        {
                            bSbi = true;
                        }
                        if (!cgs.BinMissing)
                        {
                            bBin = true;
                        }
                    }
                    btPbpRename.Enabled = bPbp;
                    btCueRename.Enabled = bCue;
                    btPngRename.Enabled = bPng;
                    btSbiRename.Enabled = bSbi;
                    btBinRename.Enabled = bBin;
                    
                    if (cgs.CueMissing)
                    {
                        btEditCue.Visible = false;
                        btEditCue.Enabled = false;
                    }
                    else
                    {
                        btEditCue.Enabled = true;
                        btEditCue.Visible = true;
                    }
                    if ((iBleemsyncVersion == 0) && (cgs.CfgMissing))
                    {
                        btAddPcsxCfg.Enabled = true;
                        btAddPcsxCfg.Visible = true;
                    }
                    else
                    {
                        btAddPcsxCfg.Visible = false;
                        btAddPcsxCfg.Enabled = false;
                    }

                    btAddFiles.Enabled = true;
                    btAddFiles.Visible = true;

                    btRefreshFolderOnly.Enabled = true;
                    btRefreshFolderOnly.Visible = true;

                    btOpenFolder.Enabled = true;
                    btOpenFolder.Visible = true;
                }
                else
                {
                    // visible if no errors
                    btEditCue.Enabled = true;
                    btEditCue.Visible = true;

                    btAddFiles.Enabled = true;
                    btAddFiles.Visible = true;

                    btRefreshFolderOnly.Enabled = true;
                    btRefreshFolderOnly.Visible = true;

                    btOpenFolder.Enabled = true;
                    btOpenFolder.Visible = true;

                    if (cgs.FilesPbpOk.Count == 0)
                    {
                        btBinRename.Enabled = true;
                    }
                    else
                    {
                        btBinRename.Enabled = false;
                    }
                    btCueRename.Enabled = false;
                    btPbpRename.Enabled = false;

                    btPngRename.Enabled = false;
                    btSbiRename.Enabled = false;

                    btAddPcsxCfg.Visible = false;
                    btAddPcsxCfg.Enabled = false;
                }
            }
            else
            {
                lbFolderSize.Visible = false;
                lbFolderSizeLabel.Visible = false;

                btAddFiles.Enabled = false;
                btAddFiles.Visible = false;

                btAddPcsxCfg.Visible = false;
                btAddPcsxCfg.Enabled = false;

                btEditCue.Visible = false;
                btEditCue.Enabled = false;

                btRefreshFolderOnly.Enabled = false;
                btRefreshFolderOnly.Visible = false;

                btOpenFolder.Enabled = false;
                btOpenFolder.Visible = false;

                pbExploreImage.AllowDrop = false;

                gbAutoRename.Visible = false;

                
                btPbpRename.Enabled = false;
                btBinRename.Enabled = false;
                btCueRename.Enabled = false;
                btPngRename.Enabled = false;
                btSbiRename.Enabled = false;
            }
            //slLogger.Trace("<< Game Selection changed in gamelist");
        }

        private void btReSort_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Resort gamelist Click");
            int iDecalage = 3000;
            String sFolderPath = tbFolderPath.Text;
            if (sFolderPath.EndsWith("\\"))
            {
                sFolderPath = sFolderPath.Substring(0, sFolderPath.Length - 1);
            }
            //String sFolderSavePath = sFolderPath.Substring(0,sFolderPath.LastIndexOf("\\")) + "saves";

            // refresh without updating display, reupdate at the end
            Dictionary<String, ClGameStructure> dcGames = generateGameListFolders(sFolderPath, out lsFolders, out lsTitles);
            if (lsFolders.Count > 0)
            {
                bool bCanContinue = true;
                foreach (KeyValuePair<String, ClGameStructure> pair in dcGames)
                {
                    ClGameStructure c1 = pair.Value;
                    bCanContinue &= ((!c1.NanFolder) & (!c1.GameDataMissing) & (!c1.IniMissing) & (!c1.IniIncomplete));
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
                                if ((sFolderPath + "\\" + s) != (sFolderPath + "\\" + (index + iDecalage).ToString()))
                                {
                                    Directory.Move(sFolderPath + "\\" + s, sFolderPath + "\\" + (index + iDecalage).ToString());
                                }
                                /*if (Directory.Exists(sFolderSavePath + "\\" + s))
                                {
                                    if ((sFolderSavePath + "\\" + s) != (sFolderSavePath + "\\" + (index + iDecalage).ToString()))
                                    {
                                        Directory.Move(sFolderSavePath + "\\" + s, sFolderSavePath + "\\" + (index + iDecalage).ToString());
                                    }
                                }*/
                            }
                        }
                        int iNewIndex = 1;
                        int iPrevIndex = iNewIndex;
                        List<int> liFoldersDone = new List<int>();
                        foreach (String s in lsTitles)
                        {
                            iPrevIndex = iNewIndex;
                            foreach (KeyValuePair<String, ClGameStructure> pair in dcGames)
                            {
                                ClGameStructure c1 = pair.Value;
                                int iIndexFolder = int.Parse(c1.FolderIndex);
                                if (((c1.Alphatitle != String.Empty) && (c1.Alphatitle == s)) || ((c1.Alphatitle == String.Empty) && (c1.Title == s)))
                                {
                                    if (liFoldersDone.IndexOf(iIndexFolder) == -1) // if same title in different folders
                                    {
                                        if ((sFolderPath + "\\" + (iIndexFolder + iDecalage).ToString()) != (sFolderPath + "\\" + (iNewIndex).ToString()))
                                        {
                                            Directory.Move(sFolderPath + "\\" + (iIndexFolder + iDecalage).ToString(), sFolderPath + "\\" + (iNewIndex).ToString());
                                        }
                                        /*if (Directory.Exists(sFolderSavePath + "\\" + (iIndexFolder + iDecalage).ToString()))
                                        {
                                            if ((sFolderSavePath + "\\" + (iIndexFolder + iDecalage).ToString()) != (sFolderSavePath + "\\" + (iNewIndex).ToString()))
                                            {
                                                Directory.Move(sFolderSavePath + "\\" + (iIndexFolder + iDecalage).ToString(), sFolderSavePath + "\\" + (iNewIndex).ToString());
                                            }
                                        }*/
                                        liFoldersDone.Add(iIndexFolder);
                                        iNewIndex++;
                                        break;
                                    }
                                }
                            }
                            if (iNewIndex == iPrevIndex)
                            {
                                // just in case
                                iNewIndex++;
                            }
                        }
                        refreshGameListFolders();
                    }
                    catch (Exception ex)
                    {
                        slLogger.Fatal(ex.Message);
                        FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    FlexibleMessageBox.Show("Correct the wrong detected folders (not numbered names, GameData or Game.ini missing).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            slLogger.Trace("<< Resort gamelist Click");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.sFolderPath = tbFolderPath.Text;
            Properties.Settings.Default.iVersionBleemSync = iBleemsyncVersion;
            Properties.Settings.Default.iSimultaneous = iSimultaneous;
            Properties.Settings.Default.Save();
            //slLogger.Trace("Saving parameters for next time. Bye.");
        }

        private void btNewFolder_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Create new folder Click");
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
                        int iCount = lsFolders.Count;
                        int iNext = 1 + iCount;
                        while (Directory.Exists(sFolderPath + "\\" + iNext.ToString()))
                        {
                            iNext++;
                        }
                        Directory.CreateDirectory(sFolderPath + "\\" + iNext.ToString());
                        if (!Directory.Exists(sFolderPath + "\\" + iNext.ToString() + currentUsedVersion.GameDataFolder))
                        {
                            Directory.CreateDirectory(sFolderPath + "\\" + iNext.ToString() + currentUsedVersion.GameDataFolder);
                        }
                        if (iBleemsyncVersion == 0)
                        {
                            File.Copy(Application.StartupPath + "\\" + "pcsx.cfg", sFolderPath + "\\" + iNext.ToString() + currentUsedVersion.GameDataFolder + "\\" + "pcsx.cfg");
                        }
                    }
                    catch (Exception ex)
                    {
                        slLogger.Fatal(ex.Message);
                    }
                    refreshGameListFolders();
                }
                else
                {
                    FlexibleMessageBox.Show("Correct the wrong folder names before doing this.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                try
                {
                    int iNext = 1;
                    Directory.CreateDirectory(sFolderPath + "\\" + iNext.ToString());
                    if (!Directory.Exists(sFolderPath + "\\" + iNext.ToString() + currentUsedVersion.GameDataFolder))
                    {
                        Directory.CreateDirectory(sFolderPath + "\\" + iNext.ToString() + currentUsedVersion.GameDataFolder);
                    }
                    File.Copy(Application.StartupPath + "\\" + "pcsx.cfg", sFolderPath + "\\" + iNext.ToString() + currentUsedVersion.GameDataFolder + "\\" + "pcsx.cfg");
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                refreshGameListFolders();
            }
            slLogger.Trace("<< Create new folder Click");
        }

        private void btLaunchBleemsync_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Recreate database Click");
            String sFolderPath = tbFolderPath.Text;
            if (sFolderPath.EndsWith("\\"))
            {
                sFolderPath = sFolderPath.Substring(0, sFolderPath.Length - 1);
            }
            if (Directory.Exists(sFolderPath))
            {
                //
                List<ClGameStructure> lcgs = new List<ClGameStructure>();
                foreach(ClGameStructure cgs in lbGames.Items)
                {
                    lcgs.Add(cgs);
                }
                ClDBManager cdbm = new ClDBManager(lcgs, sFolderPath, iBleemsyncVersion, currentUsedVersion, slLogger);
                // TODO creer aussi le second fichier db
                if(!cdbm.BDone)
                {
                    FlexibleMessageBox.Show("There is a problem during database creation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    FlexibleMessageBox.Show("Database regenerated. Now you can properly unplug your usb drive and plug it in your PSC.", "Job done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            slLogger.Trace("<< Recreate database Click");
            /*slLogger.Trace(">> Launch BleemSync Click");
            String sFolderPath = tbFolderPath.Text;
            if (sFolderPath.EndsWith("\\"))
            {
                sFolderPath = sFolderPath.Substring(0, sFolderPath.Length - 1);
            }
            if (Directory.Exists(sFolderPath))
            {
                String[] sFolderDecomposed = sFolderPath.Split('\\');
                if ((sFolderDecomposed.Length > 1) && (sFolderDecomposed[sFolderDecomposed.Length - 1] == "Games"))
                {
                    sFolderDecomposed[sFolderDecomposed.Length - 1] = "BleemSync";
                    String sFolderBleemsync = String.Join("\\", sFolderDecomposed);
                    if (Directory.Exists(sFolderBleemsync))
                    {
                        if (File.Exists(sFolderBleemsync + "\\BleemSync.exe"))
                        {
                            MyProcessHelper mph = new MyProcessHelper(sFolderBleemsync + "\\BleemSync.exe");
                            String s = mph.DoIt();
                            slLogger.Info(s);
                        }
                        else
                        {
                            FlexibleMessageBox.Show("There is not the BleemSync executable here: " + sFolderBleemsync, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        FlexibleMessageBox.Show("There is not a BleemSync folder: " + sFolderBleemsync, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    FlexibleMessageBox.Show("There is a problem with the folder path: " + sFolderPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                FlexibleMessageBox.Show("Folder " + sFolderPath + " not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< Launch BleemSync Click");
            */
        }

        private void btClearLog_Click(object sender, EventArgs e)
        {
            // slLogger.Trace(">> ClearLog Click"); // never displayed due to next line...
            tbLogDebug.Clear();
            // slLogger.Trace("<< ClearLog Click"); // want to clear, stupid to re-write something :)
        }

        private void tabControlAll_Selected(object sender, TabControlEventArgs e)
        {
            int iDbgIndex = tabControlAll.TabPages.IndexOf(tabControlAll.TabPages["tabDebug"]);
            if (tabControlAll.SelectedIndex == iDbgIndex)
            {
                bAccessingDebugTab = true;
            }
        }

        private void DebugLogScrollToEnd()
        {
            tbLogDebug.SelectionStart = tbLogDebug.Text.Length;
            tbLogDebug.ScrollToCaret();
        }

        private void tabDebug_Paint(object sender, PaintEventArgs e)
        {
            if (true == bAccessingDebugTab)
            {
                DebugLogScrollToEnd();
                bAccessingDebugTab = false;
            }
        }

        private void btEditGameIni_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Edit Game.ini Click");
            String sFolderPath = tbFolderPath.Text;
            Form23 f = null;
            if (lbGames.SelectedIndex > -1)
            {
                ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                f = new Form23(sFolderPath, slLogger, dcPs1Games, currentUsedVersion, cgs);
            }
            else
            {
                f = new Form23(sFolderPath, slLogger, dcPs1Games, currentUsedVersion);
            }
            f.ShowDialog();
            refreshOneFolder();
            slLogger.Trace("<< Edit Game.ini Click");
        }

        private void btAddPcsxCfg_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Add pcsx.cfg Click");
            String sFolderPath = tbFolderPath.Text;
            if (lbGames.SelectedIndex > -1)
            {
                try
                {
                    ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                    File.Copy(Application.StartupPath + "\\" + "pcsx.cfg", sFolderPath + "\\" + cgs.FolderIndex.ToString() + currentUsedVersion.GameDataFolder + "\\" + "pcsx.cfg");
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                refreshOneFolder();
            }
            slLogger.Trace("<< Add pcsx.cfg Click");
        }

        private void btEditCue_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Edit cue file Click");
            String sFolderPath = tbFolderPath.Text;
            Form4 f = null;
            if (lbGames.SelectedIndex > -1)
            {
                ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                f = new Form4(sFolderPath, slLogger, cgs, currentUsedVersion);
                f.ShowDialog();
                refreshOneFolder();
            }
            slLogger.Trace("<< Edit cue file Click");
        }

        void pbCopyFiles(String[] sFiles, String dstFolder)
        {
            if (Directory.Exists(dstFolder))
            {
                foreach (string sFile in sFiles)
                {
                    //File.Copy(sFile, sMyFolder + "\\" + sFile.Substring(sFile.LastIndexOf('\\')));
                    //FlexibleMessageBox.Show("File Copied from" + sFile + "\n to" + sMyFolder);
                    if (this.frmCopy != null)
                    {
                        this.frmCopy.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                        this.frmCopy.Visible = true;
                    }
                    else
                    {
                        this.frmCopy = new Form5(iSimultaneous);
                        this.frmCopy.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                        this.frmCopy.Visible = true;
                    }
                    ClPbProgessBarLabeled pbl = this.frmCopy.addNewLine(sFile.Substring(sFile.LastIndexOf('\\')));
                    // TODO deporter la suite ailleurs pour en mettre qu'un ou deux simultanement et le reste en file d'attente...
                    ClPbWebClient wc = new ClPbWebClient(pbl, slLogger, sFile, dstFolder + "\\" + sFile.Substring(sFile.LastIndexOf('\\')));
                    pbl.PbPanel.Tag = wc;
                    //wc.DownloadFileAsync(new Uri(sFile), );
                }
            }
            else
            {
                slLogger.Error("Destination directory doesn't exist");
                FlexibleMessageBox.Show("Directory doesn't exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lvFiles_DragDrop(object sender, DragEventArgs e)
        {
            slLogger.Trace(">> DragDrop file");
            if (lbGames.SelectedIndex > -1)
            {
                try
                {
                    ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                    if (!cgs.GameDataMissing)
                    {
                        String sFolderPath = tbFolderPath.Text;
                        String[] sFileList = (String[])e.Data.GetData(DataFormats.FileDrop, false);
                        String sPath = sFolderPath + "\\" + cgs.FolderIndex + currentUsedVersion.GameDataFolder;
                        pbCopyFiles(sFileList, sPath);
                    }
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                tmRefreshFolder.Enabled = true;
            }
            slLogger.Trace("<< DragDrop file");
        }

        private void lvFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void btAddFiles_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Add Files Click");
            if (lbGames.SelectedIndex > -1)
            {
                try
                {
                    ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                    String sFolderPath = tbFolderPath.Text;
                    String sPath = sFolderPath + "\\" + cgs.FolderIndex + currentUsedVersion.GameDataFolder;
                    if (Directory.Exists(sFolderPath))
                    {
                        ofdAddFiles.InitialDirectory = sFolderPath;
                    }
                    if (DialogResult.OK == ofdAddFiles.ShowDialog())
                    {
                        String[] sFileList = ofdAddFiles.FileNames;
                        pbCopyFiles(sFileList, sPath);
                    }
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                tmRefreshFolder.Enabled = true;
            }
            slLogger.Trace("<< Add Files Click");
        }

        private void lvFiles_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null) { return; }

            slLogger.Trace(">> Filename edit");
            if (lbGames.SelectedIndex > -1)
            {
                // e.Item // index
                // e.Label // new name
                try
                {
                    ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                    String sFolderPath = tbFolderPath.Text;
                    String sPath = sFolderPath + "\\" + cgs.FolderIndex + currentUsedVersion.GameDataFolder + "\\";
                    char[] invalidFileChars = Path.GetInvalidFileNameChars();
                    if (cgs.Filenames[e.Item] != e.Label)
                    {
                        if (e.Label.IndexOfAny(invalidFileChars) == -1)
                        {
                            if ((cgs.Filenames.IndexOf(e.Label) == -1) && (!File.Exists(sPath + e.Label)))
                            {
                                slLogger.Debug("Renaming " + sPath + cgs.Filenames[e.Item] + " to " + sPath + e.Label);
                                File.Move(sPath + cgs.Filenames[e.Item], sPath + e.Label);
                                tmRefreshFolder.Enabled = true;
                            }
                            else
                            {
                                slLogger.Error("Can't overwrite filename " + sPath + e.Label);
                                e.CancelEdit = true;
                                lvFiles.Items[e.Item].Text = cgs.Filenames[e.Item];
                            }
                        }
                        else
                        {
                            slLogger.Error("Invalid characters in filename: " + e.Label);
                            e.CancelEdit = true;
                            lvFiles.Items[e.Item].Text = cgs.Filenames[e.Item];
                        }
                    }
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                //refreshOneFolder(); // launched by activated timer
            }
            slLogger.Trace("<< Filename edit");
        }

        private void lvFiles_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvFiles.SelectedItems.Count > 0)
            {
                if (e.KeyData == Keys.F2)
                {
                    slLogger.Trace(">> F2 Key detected");
                    lvFiles.SelectedItems[0].BeginEdit();
                    slLogger.Trace("<< F2 Key detected");
                }
                else
                if (e.KeyData == Keys.Delete)
                {
                    slLogger.Trace(">> DEL Key detected");
                    if (lbGames.SelectedIndex > -1)
                    {
                        try
                        {
                            ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                            String sFolderPath = tbFolderPath.Text;
                            String sPath = sFolderPath + "\\" + cgs.FolderIndex + currentUsedVersion.GameDataFolder + "\\";
                            int iFound = cgs.Filenames.IndexOf(lvFiles.SelectedItems[0].Text);
                            if (iFound > -1)
                            {
                                slLogger.Debug("Deleting " + sPath + cgs.Filenames[iFound]);
                                File.Delete(sPath + cgs.Filenames[iFound]);
                                cgs.Filenames.Remove(cgs.Filenames[iFound]);
                                lvFiles.SelectedItems[0].Remove();
                                refreshOneFolder();
                            }
                        }
                        catch (Exception ex)
                        {
                            slLogger.Fatal(ex.Message);
                        }
                    }
                    slLogger.Trace("<< DEL Key detected");
                }
            }
        }

        private void pbExploreImage_DragDrop(object sender, DragEventArgs e)
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
                        using (Bitmap bmPicture = new Bitmap(sFileList[0]))
                        {
                            pbExploreImage.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bmPicture)), 226, 226);
                        }
                        if (lbGames.SelectedIndex > -1)
                        {
                            try
                            {
                                ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                                String sFolderPath = tbFolderPath.Text;
                                String sPath = sFolderPath + "\\" + cgs.FolderIndex + currentUsedVersion.GameDataFolder + "\\";
                                if (!String.IsNullOrEmpty(cgs.PictureFileName))
                                {
                                    String sFileName = cgs.PictureFileName;
                                    slLogger.Debug("Saving image after dragdrop operation: " + sFileName);
                                    pbExploreImage.Image.Save(sFileName, ImageFormat.Png);
                                    MyProcessHelper pPngQuant = new MyProcessHelper(Application.StartupPath + "\\pngquant\\pngquant.exe", sFileName + " --force --ext .png --verbose");
                                    pPngQuant.DoIt();
                                    refreshOneFolder();
                                }
                                else
                                {
                                    //savefiledialog
                                    if (Directory.Exists(sPath))
                                    {
                                        sfdSaveImage.InitialDirectory = sPath;
                                    }
                                    String sDefFile = "Game.png";
                                    if (!String.IsNullOrEmpty(cgs.Discs))
                                    {
                                        sDefFile = cgs.Discs.Split(',')[0] + ".png";
                                        sfdSaveImage.FileName = sDefFile;
                                    }
                                    if (DialogResult.OK == sfdSaveImage.ShowDialog())
                                    {
                                        String sFileName = sfdSaveImage.FileName;
                                        slLogger.Debug("Saving image after dragdrop operation: " + sFileName);
                                        pbExploreImage.Image.Save(sFileName, ImageFormat.Png);
                                        MyProcessHelper pPngQuant = new MyProcessHelper(Application.StartupPath + "\\pngquant\\pngquant.exe", sFileName + " --force --ext .png --verbose");
                                        pPngQuant.DoIt();
                                        refreshOneFolder();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                slLogger.Fatal(ex.Message);
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
            slLogger.Trace("<< Dragdrop image");
        }

        private void pbExploreImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void refreshOneFolder(bool bRefreshListBox = true)
        {
            ClGameStructure cgsSave = null;
            int iIndex = lbGames.SelectedIndex;
            if (iIndex > -1)
            {
                cgsSave = (ClGameStructure)(lbGames.Items[iIndex]);
                String sFolderPath = tbFolderPath.Text;
                String sFolder = sFolderPath + "\\" + cgsSave.FolderIndex;

                int iFileIndex = -1;
                ListView.SelectedIndexCollection indices = lvFiles.SelectedIndices;
                if (indices.Count > 0)
                {
                    iFileIndex = indices[0];
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(sFolder);
                slLogger.Debug("Refreshing " + sFolder);
                ClGameStructure cgs = manageFolder(cgsSave.FolderIndex, directoryInfo, ref lsFolders, ref lsTitles, false);
                //if (true == bRefreshListBox)
                {
                    if (!cgs.IsSame(cgsSave))
                    {
                        lbGames.Items.RemoveAt(iIndex);
                        lbGames.Items.Insert(iIndex, cgs);
                        lbGames.SelectedIndex = iIndex;
                        if ((iFileIndex > -1) && (iFileIndex < lvFiles.Items.Count))
                        {
                            lvFiles.Items[iFileIndex].Selected = true;
                            lvFiles.Select();
                            lvFiles.EnsureVisible(iFileIndex);
                        }
                    }
                }
                ReCalcFreeSpace(sFolderPath);
            }
        }

        private void btRefreshFolderOnly_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Refresh folder Click");
            refreshOneFolder();
            slLogger.Trace("<< Refresh folder Click");
        }

        private void btOpenFolder_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Open folder Click");
            if (lbGames.SelectedIndex > -1)
            {
                try
                {
                    ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                    String sFolderPath = tbFolderPath.Text;
                    String sPath = sFolderPath + "\\" + cgs.FolderIndex;
                    if (!cgs.GameDataMissing)
                    {
                        sPath += currentUsedVersion.GameDataFolder;
                    }
                    sPath += "\\";
                    MyProcessHelper explo = new MyProcessHelper("explorer.exe", sPath);
                    explo.DoIt();
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
            }
            slLogger.Trace("<< Open folder Click");
        }

        private long GetAvailableFreeSpace(String driveName)
        {
            String sDrive = driveName.ToUpper();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == sDrive)
                {
                    return drive.AvailableFreeSpace;
                }
            }
            return -1;
        }

        private void tbFolderPath_Leave(object sender, EventArgs e)
        {
            String sFolderPath = tbFolderPath.Text;
            ReCalcFreeSpace(sFolderPath);
        }

        private void tmRefreshFolder_Tick(object sender, EventArgs e)
        {
            refreshOneFolder();
            tmRefreshFolder.Enabled = false;
        }

        private void btCueRename_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Cue AutoRename Click");
            if (lbGames.SelectedIndex > -1)
            {
                try
                {
                    ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                    String sFolderPath = tbFolderPath.Text;
                    String sPath = sFolderPath + "\\" + cgs.FolderIndex + "\\";
                    if ((!cgs.GameDataMissing) && (!cgs.IniMissing) && (!cgs.IniIncomplete) && (!cgs.CueMissing) && (!cgs.CueCountMisMatchDiscsCount) && (cgs.BadCueName))
                    {
                        String[] sDiscs = cgs.Discs.Split(',');
                        List<String> lsFilenamesOk = cgs.FilesCueOk;
                        List<String> lsFileNamesCueLower = new List<string>();
                        List<String> lsFileToRename = new List<string>();
                        foreach (String s in cgs.Filenames)
                        {
                            if (s.ToLower().EndsWith(".cue"))
                            {
                                lsFileNamesCueLower.Add(s.ToLower());
                            }
                        }
                        if (lsFileNamesCueLower.Count > 0)
                        {
                            using (NaturalComparer comparer = new NaturalComparer())
                            {
                                lsFileNamesCueLower.Sort(comparer);
                            }
                            foreach (String sOneFile in lsFileNamesCueLower)
                            {
                                if (lsFilenamesOk.IndexOf(sOneFile) > -1)
                                {
                                    //
                                }
                                else
                                {
                                    lsFileToRename.Add(sOneFile);
                                }
                            }
                            String[] sFileToRename = lsFileToRename.ToArray();
                            int iIndex = 0;
                            String sQuestion = String.Empty;
                            foreach (String s in sDiscs)
                            {
                                String sDisc = s.ToLower();
                                if (lsFilenamesOk.IndexOf(sDisc + ".cue") > -1)
                                {
                                    iIndex++;
                                }
                                else
                                {
                                    if (iIndex < sFileToRename.Length)
                                    {
                                        if (File.Exists(sPath + currentUsedVersion.GameDataFolder + "\\" + sFileToRename[iIndex]))
                                        {
                                            sQuestion = sQuestion + Environment.NewLine + sPath + currentUsedVersion.GameDataFolder + "\\" + sFileToRename[iIndex] + " >> " + sPath + currentUsedVersion.GameDataFolder + "\\" + s + ".cue";
                                        }
                                        iIndex++;
                                    }
                                }
                            }
                            if (DialogResult.Yes == FlexibleMessageBox.Show("Do you want to rename those files ?" + sQuestion, "Renaming...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                iIndex = 0;
                                foreach (String s in sDiscs)
                                {
                                    String sDisc = s.ToLower();
                                    if (lsFilenamesOk.IndexOf(sDisc + ".cue") > -1)
                                    {
                                        iIndex++;
                                    }
                                    else
                                    {
                                        if (iIndex < sFileToRename.Length)
                                        {
                                            if (File.Exists(sPath + currentUsedVersion.GameDataFolder + "\\" + sFileToRename[iIndex]))
                                            {
                                                File.Move(sPath + currentUsedVersion.GameDataFolder + "\\" + sFileToRename[iIndex], sPath + currentUsedVersion.GameDataFolder + "\\" + s + ".cue");
                                                slLogger.Debug("Renaming file " + sFileToRename[iIndex] + " -> " + s + ".cue");
                                            }
                                            iIndex++;
                                        }
                                    }
                                }
                            }
                        }
                        refreshOneFolder();
                    }
                    else
                    {
                        //
                    }
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
            }
            slLogger.Trace("<< Cue AutoRename Click");
        }

        private void btPngRename_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Png AutoRename Click");
            if (lbGames.SelectedIndex > -1)
            {
                try
                {
                    ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                    String sFolderPath = tbFolderPath.Text;
                    String sPath = sFolderPath + "\\" + cgs.FolderIndex + "\\";
                    if ((!cgs.GameDataMissing) && (!cgs.IniMissing) && (!cgs.IniIncomplete) && (!cgs.PngMissing) && (!cgs.PngMultiple) && (cgs.PngMismatch))
                    {
                        String sSrcName = cgs.PictureFileName;
                        String sDiscFirst = cgs.Discs.Split(',')[0];
                        String sDstName = sPath + currentUsedVersion.GameDataFolder + "\\" + sDiscFirst + ".png";
                        if (sSrcName.ToLower() != sDstName.ToLower())
                        {
                            if (File.Exists(sSrcName))
                            {
                                if (DialogResult.Yes == FlexibleMessageBox.Show("Do you want to rename this file ?" + sSrcName + " >> " + sDstName, "Renaming...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    File.Move(sSrcName, sDstName);
                                    slLogger.Debug("Renaming file " + sSrcName + " -> " + sDstName);
                                    refreshOneFolder();
                                }
                            }
                            else
                            {
                                //
                            }
                        }
                        else
                        {
                            //
                        }
                    }
                    else
                    {
                        //
                    }
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
            }
            slLogger.Trace("<< Png AutoRename Click");
        }

        private void btBinRename_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Bin AutoRename Click");
            if (lbGames.SelectedIndex > -1)
            {
                try
                {
                    ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                    String sFolderPath = tbFolderPath.Text;
                    String sPath = sFolderPath + "\\" + cgs.FolderIndex + currentUsedVersion.GameDataFolder + "\\";
                    String[] sDisc = cgs.Discs.Split(',');
                    List<String> sFilesOrigine = new List<string>();
                    foreach (String s in cgs.Filenames)
                    {
                        if (s.ToLower().EndsWith(".bin"))
                        {
                            sFilesOrigine.Add(s);
                        }
                    }
                    List<String> sFiles = new List<string>();
                    List<String> sFilesToSplit = new List<string>();
                    bool bSerialFound = false;
                    foreach (String sOneFile in sFilesOrigine)
                    {
                        String sLow = sOneFile.ToLower();
                        for(int i=0;i<sDisc.Length;i++)
                        {
                            // need to rename serialnumbers if present, to prevent from detecting false common strings
                            // for example, Street Fighter Collection [SLUS-00423,SLUS-00584] -> SLUS-00, then 4 for common string
                            String s = sDisc[i].ToLower();
                            int iPos = sLow.IndexOf(s);
                            if (iPos > -1)
                            {
                                bSerialFound = true;
                                int iLen = s.Length;
                                sLow = sLow.Remove(iPos, iLen);
                                sLow = sLow.Insert(iPos, (i + 1).ToString());
                            }
                        }
                        sFiles.Add(sLow);
                        sFilesToSplit.Add(sLow);
                    }
                    String sCommonStr = String.Empty;
                    List<String> lsCommonstrings = new List<string>();
                    int iIter = 0;
                    do
                    {
                        String sPreviousFile = String.Empty;
                        sCommonStr = String.Empty;
                        ClPbHelper.LongestCommonSubstring(sFiles[0].ToLower(), sFiles[sFiles.Count-1].ToLower(), out sCommonStr);
                        foreach (String sOneFile in sFiles)
                        {
                            String s = sOneFile.ToLower();
                            //if (String.IsNullOrEmpty(sPreviousFile))
                            //{
                            //    sPreviousFile = s;
                            //}
                            //else
                            //{
                            //    if (String.IsNullOrEmpty(sCommonStr))
                            //    {
                            //        ClPbHelper.LongestCommonSubstring(sPreviousFile, s, out sCommonStr);
                            //    }
                            //    else
                            //    {
                                    ClPbHelper.LongestCommonSubstring(sCommonStr, s, out sCommonStr);
                                //}
                            //}
                        }
                        if (!String.IsNullOrEmpty(sCommonStr))
                        {
                            lsCommonstrings.Add(sCommonStr);
                            iIter++;
                            for (int i = 0; i < sFiles.Count; i++)
                            {
                                int iPos = sFiles[i].IndexOf(sCommonStr);
                                int iLen = sCommonStr.Length;
                                sFiles[i] = sFiles[i].Remove(iPos, iLen);
                                //sFiles[i] = sFiles[i].Insert(iPos, "/");
                            }
                        }
                    } while (!String.IsNullOrEmpty(sCommonStr));

                    String ss = "***** " + iIter.ToString() + " *****";
                    int iInd = 0;
                    Dictionary<String, String> dcFiles = new Dictionary<string, string>();
                    Dictionary<String, String> dcFilesToSplit = new Dictionary<string, string>();
                    foreach (String sCommon in lsCommonstrings)
                    {
                        for (int i = 0; i < sFilesToSplit.Count; i++)
                        {
                            int iPos = sFilesToSplit[i].IndexOf(sCommon);
                            int iLen = sCommon.Length;
                            sFilesToSplit[i] = sFilesToSplit[i].Remove(iPos, iLen);
                            sFilesToSplit[i] = sFilesToSplit[i].Insert(iPos, "/");
                        }
                    }
                    foreach (String s in sFilesToSplit)
                    {
                        dcFilesToSplit.Add(s, sFilesOrigine[iInd]);
                        ss += Environment.NewLine + s + " - " + sFilesOrigine[iInd];
                        iInd++;
                    }
                    iInd = 0;
                    foreach (String s in sFiles)
                    {
                        dcFiles.Add(s, sFilesOrigine[iInd]);
                        iInd++;
                    }
                    if (sDisc.Length == 1)
                    {
                        if (sFiles.Count == 1)
                        {
                            String s = sFiles[0];
                            if (dcFiles.ContainsKey(s))
                            {
                                String sSrcName = sPath + dcFiles[s];
                                String sDstName = sPath + sDisc[0] + ".bin";
                                if (sSrcName.ToLower() != sDstName.ToLower())
                                {
                                    if (File.Exists(sSrcName))
                                    {
                                        if (DialogResult.Yes == FlexibleMessageBox.Show("Do you want to rename this file ?" + Environment.NewLine + sSrcName + " >> " + sDstName, "Renaming...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                        {
                                            File.Move(sSrcName, sDstName);
                                            slLogger.Debug("Renaming file " + sSrcName + " -> " + sDstName);
                                            refreshOneFolder();
                                        }
                                    }
                                }
                                else
                                {
                                    slLogger.Debug("No renaming to do");
                                }
                            }
                        }
                        else
                        {
                            // iIter==1: filenames are 1_toto.bin, 2_toto.bin, etc
                            // iIter==2: filenames are toto_1.bin, toto_2.bin, etc
                            using (NaturalComparer comparer = new NaturalComparer())
                            {
                                sFiles.Sort(comparer);
                            }
                            int iInc = 1;
                            String sQuestion = String.Empty;
                            foreach (String s in sFiles)
                            {
                                if (dcFiles.ContainsKey(s))
                                {
                                    String sSrcName = sPath + dcFiles[s];
                                    String sDstName = sPath + sDisc[0] + "_" + iInc.ToString("00") + ".bin";
                                    if (sSrcName.ToLower() != sDstName.ToLower())
                                    {
                                        if (File.Exists(sSrcName))
                                        {
                                            sQuestion = sQuestion + Environment.NewLine + sSrcName + " >> " + sDstName;
                                        }
                                    }
                                    iInc++;
                                }
                            }
                            if (!String.IsNullOrEmpty(sQuestion))
                            {
                                if (DialogResult.Yes == FlexibleMessageBox.Show("Do you want to rename those files ?" + sQuestion, "Renaming...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    int iIncr = 1;
                                    foreach (String s in sFiles)
                                    {
                                        if (dcFiles.ContainsKey(s))
                                        {
                                            String sSrcName = sPath + dcFiles[s];
                                            String sDstName = sPath + sDisc[0] + "_" + iIncr.ToString("00") + ".bin";
                                            if (sSrcName.ToLower() != sDstName.ToLower())
                                            {
                                                if (File.Exists(sSrcName))
                                                {
                                                    File.Move(sSrcName, sDstName);
                                                    slLogger.Debug("Renaming file " + sSrcName + " -> " + sDstName);
                                                }
                                            }
                                            iIncr++;
                                        }
                                    }
                                    refreshOneFolder();
                                }
                            }
                            else
                            {
                                slLogger.Debug("No renaming to do");
                            }
                        }
                    }
                    else
                    {
                        if (sDisc.Length == sFiles.Count)
                        {
                            // iIter==1: filenames are 1_toto.bin, 2_toto.bin, etc
                            // iIter==2: filenames are toto_1.bin, toto2.bin, etc
                            using (NaturalComparer comparer = new NaturalComparer())
                            {
                                sFiles.Sort(comparer);
                            }
                            int iInc = 0;
                            String sQuestion = String.Empty;
                            foreach (String s in sFiles)
                            {
                                if (dcFiles.ContainsKey(s))
                                {
                                    String sSrcName = sPath + dcFiles[s];
                                    String sDstName = sPath + sDisc[iInc] + ".bin";
                                    if (sSrcName.ToLower() != sDstName.ToLower())
                                    {
                                        if (File.Exists(sSrcName))
                                        {
                                            sQuestion = sQuestion + Environment.NewLine + sSrcName + " >> " + sDstName;
                                        }
                                    }
                                    iInc++;
                                }
                            }
                            if (!String.IsNullOrEmpty(sQuestion))
                            {
                                if (DialogResult.Yes == FlexibleMessageBox.Show("Do you want to rename those files ?" + sQuestion, "Renaming...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                {
                                    int iIncr = 0;
                                    foreach (String s in sFiles)
                                    {
                                        if (dcFiles.ContainsKey(s))
                                        {
                                            String sSrcName = sPath + dcFiles[s];
                                            String sDstName = sPath + sDisc[iIncr] + ".bin";
                                            if (sSrcName.ToLower() != sDstName.ToLower())
                                            {
                                                if (File.Exists(sSrcName))
                                                {
                                                    File.Move(sSrcName, sDstName);
                                                    slLogger.Debug("Renaming file " + sSrcName + " -> " + sDstName);
                                                }
                                            }
                                            iIncr++;
                                        }
                                    }
                                    refreshOneFolder();
                                }
                            }
                            else
                            {
                                slLogger.Debug("No renaming to do");
                            }
                        }
                        else
                        if (sDisc.Length < sFiles.Count)
                        {
                            // multi discs + multi tracks
                            // 2: filenames are: 1_1_toto.bin, 1_2_toto.bin, 2_1_toto.bin, 2_2_toto.bin, etc
                            // 3: filenames are: toto_1_1.bin, toto_1_2.bin, toto_2_1.bin, toto_2_2.bin, etc
                            if (lsCommonstrings.Count > 0)
                            {
                                /*
                                String sTest = String.Empty;
                                foreach (String s in lsCommonstrings)
                                {
                                    sTest += Environment.NewLine + s;
                                }
                                FlexibleMessageBox.Show(ss + Environment.NewLine + sTest);
                                */
                                List<String> lsWorkDisc = new List<String>();
                                List<String>[] lsWorkTrack = new List<String>[sDisc.Length];
                                Dictionary<String,String[]> dcTracks = new Dictionary<String,String[]>();
                                bool bStop = false;
                                foreach (String s in dcFilesToSplit.Keys)
                                {
                                    if (!bStop)
                                    {
                                        String[] sArr = s.Split(new String[] { "/" }, StringSplitOptions.RemoveEmptyEntries); // assume format [/]DISC/TRACK/
                                        if (sArr.Length == 2)
                                        {
                                            if (lsWorkDisc.IndexOf(sArr[0]) == -1)
                                            {
                                                lsWorkDisc.Add(sArr[0]);
                                            }
                                            int iIndex = lsWorkDisc.IndexOf(sArr[0]);
                                            if(lsWorkTrack[iIndex] == null)
                                            {
                                                lsWorkTrack[iIndex] = new List<string>();
                                            }
                                            if (lsWorkTrack[iIndex].IndexOf(sArr[1]) == -1)
                                            {
                                                lsWorkTrack[iIndex].Add(sArr[1]);
                                            }
                                            else
                                            {
                                                // stop. if here, there is a problem
                                                bStop = true;
                                                slLogger.Error("Problem A2 were detected during parsing bin filenames [" + dcFilesToSplit[s] + "] - Track already found.");
                                            }
                                        }
                                        else
                                        {
                                            bStop = true;
                                            slLogger.Error("Problem A1 were detected during parsing bin filenames: [" + dcFilesToSplit[s] + "] - Not an expected format.");
                                        }
                                    }
                                }
                                if (!bStop)
                                {
                                    using (NaturalComparer comparer = new NaturalComparer())
                                    {
                                        lsWorkDisc.Sort(comparer);
                                    }
                                    for (int i = 0; i < lsWorkTrack.Length; i++)
                                    {
                                        using (NaturalComparer comparer = new NaturalComparer())
                                        {
                                            if (lsWorkTrack[i] == null)
                                            {
                                                // should go out, a disc is defined but no tracks found
                                                bStop = true;
                                                slLogger.Error("Problem A3 were detected during sorting tracks - No tracks for one disc.");
                                            }
                                            else
                                            {
                                                lsWorkTrack[i].Sort(comparer);
                                            }
                                        }
                                    }
                                }
                                if (!bStop)
                                {
                                    String[] sCommons = lsCommonstrings.ToArray();
                                    int iCommonSubstring = lsCommonstrings.Count;
                                    String sCommonStart = sPath;
                                    switch (iCommonSubstring)
                                    {
                                        case 2:
                                            sCommonStart = sPath;
                                            break;
                                        case 3:
                                            sCommonStart = sPath + sCommons[0];
                                            break;
                                        default:
                                            bStop = true;
                                            slLogger.Error("Problem A4 were detected during recreating filenames - Wrong format for origin filenames.");
                                            break;
                                    }
                                    if (!bStop)
                                    {
                                        String sQuestion = String.Empty;
                                        for (int i = 0; i < lsWorkDisc.Count; i++)
                                        {
                                            for (int j = 0; j < lsWorkTrack[i].Count; j++)
                                            {
                                                String sSrcName = String.Empty;
                                                if (dcFiles.ContainsKey(lsWorkDisc[i] + lsWorkTrack[i][j]))
                                                {
                                                    sSrcName = sCommonStart + dcFiles[lsWorkDisc[i] + lsWorkTrack[i][j]];
                                                }
                                                if (!String.IsNullOrEmpty(sSrcName))
                                                {
                                                    String sDstName = sPath + sDisc[i] + "_" + (1 + j).ToString("00") + ".bin";
                                                    if (sSrcName.ToLower() != sDstName.ToLower())
                                                    {
                                                        if (File.Exists(sSrcName))
                                                        {
                                                            sQuestion = sQuestion + Environment.NewLine + sSrcName + " >> " + sDstName;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (!String.IsNullOrEmpty(sQuestion))
                                        {
                                            if (DialogResult.Yes == FlexibleMessageBox.Show("Do you want to rename those files ?" + sQuestion, "Renaming...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                                            {
                                                for (int i = 0; i < lsWorkDisc.Count; i++)
                                                {
                                                    for (int j = 0; j < lsWorkTrack[i].Count; j++)
                                                    {
                                                        String sSrcName = String.Empty;
                                                        if (dcFiles.ContainsKey(lsWorkDisc[i] + lsWorkTrack[i][j]))
                                                        {
                                                            sSrcName = sCommonStart + dcFiles[lsWorkDisc[i] + lsWorkTrack[i][j]];
                                                        }
                                                        if (!String.IsNullOrEmpty(sSrcName))
                                                        {
                                                            String sDstName = sPath + sDisc[i] + "_" + (1 + j).ToString("00") + ".bin";
                                                            if (sSrcName.ToLower() != sDstName.ToLower())
                                                            {
                                                                if (File.Exists(sSrcName))
                                                                {
                                                                    File.Move(sSrcName, sDstName);
                                                                    slLogger.Debug("Renaming file " + sSrcName + " -> " + sDstName);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                refreshOneFolder();
                                            }
                                        }
                                        else
                                        {
                                            slLogger.Debug("No renaming to do");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                slLogger.Trace("<< Bin AutoRename Click");
            }
        }

        private void btSbiRename_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Sbi AutoRename Click");
            if (lbGames.SelectedIndex > -1)
            {
                try
                {
                    ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                    String sFolderPath = tbFolderPath.Text;
                    String sPath = sFolderPath + "\\" + cgs.FolderIndex + "\\";
                    if ((!cgs.GameDataMissing) && (!cgs.IniMissing) && (!cgs.IniIncomplete))
                    {
                        List<String> lsDiscNeedSbi = new List<string>();
                        String[] sDiscs = cgs.Discs.Split(',');
                        foreach (String sDisc in sDiscs)
                        {
                            String s1 = sDisc.ToUpper();
                            if (lsSbiNeeds.IndexOf(s1) > -1)
                            {
                                // sbi needed
                                lsDiscNeedSbi.Add(sDisc);
                            }
                        }
                        List<String> lsFilenamesOk = cgs.FilesSbiOk;
                        List<String> lsFileNamesSbiLower = new List<string>();
                        List<String> lsFileToRename = new List<string>();
                        foreach (String s in cgs.Filenames)
                        {
                            if (s.ToLower().EndsWith(".sbi"))
                            {
                                lsFileNamesSbiLower.Add(s.ToLower());
                            }
                        }
                        if (lsFileNamesSbiLower.Count > 0)
                        {
                            using (NaturalComparer comparer = new NaturalComparer())
                            {
                                lsFileNamesSbiLower.Sort(comparer);
                            }
                            foreach (String sOneFile in lsFileNamesSbiLower)
                            {
                                if (lsFilenamesOk.IndexOf(sOneFile) > -1)
                                {
                                    //
                                }
                                else
                                {
                                    lsFileToRename.Add(sOneFile);
                                }
                            }
                            String[] sFileToRename = lsFileToRename.ToArray();
                            int iIndex = 0;
                            String sQuestion = String.Empty;
                            foreach (String s in lsDiscNeedSbi)
                            {
                                String sDisc = s.ToLower();
                                if (lsFilenamesOk.IndexOf(sDisc + ".sbi") > -1)
                                {
                                    iIndex++;
                                }
                                else
                                {
                                    if (iIndex < sFileToRename.Length)
                                    {
                                        String sSrcName = sPath + currentUsedVersion.GameDataFolder + "\\" + sFileToRename[iIndex];
                                        String sDstName = sPath + currentUsedVersion.GameDataFolder + "\\" + s + ".sbi";
                                        if (sSrcName.ToLower() != sDstName.ToLower())
                                        {
                                            if (File.Exists(sSrcName))
                                            {
                                                sQuestion = sQuestion + Environment.NewLine + sSrcName + " >> " + sDstName;
                                            }
                                        }
                                        iIndex++;
                                    }
                                }
                            }
                            if (DialogResult.Yes == FlexibleMessageBox.Show("Do you want to rename those files ?" + sQuestion, "Renaming...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                iIndex = 0;
                                foreach (String s in lsDiscNeedSbi)
                                {
                                    String sDisc = s.ToLower();
                                    if (lsFilenamesOk.IndexOf(sDisc + ".sbi") > -1)
                                    {
                                        iIndex++;
                                    }
                                    else
                                    {
                                        if (iIndex < sFileToRename.Length)
                                        {
                                            String sSrcName = sPath + currentUsedVersion.GameDataFolder + "\\" + sFileToRename[iIndex];
                                            String sDstName = sPath + currentUsedVersion.GameDataFolder + "\\" + s + ".sbi";
                                            if (sSrcName.ToLower() != sDstName.ToLower())
                                            {
                                                if (File.Exists(sSrcName))
                                                {
                                                    File.Move(sSrcName, sDstName);
                                                    slLogger.Debug("Renaming file " + sSrcName + " -> " + sDstName);
                                                }
                                            }
                                            iIndex++;
                                        }
                                    }
                                }
                            }
                        }
                        refreshOneFolder();
                    }
                    else
                    {
                        //
                    }
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
            }
            slLogger.Trace("<< Sbi AutoRename Click");
        }

        private void btLaunchPngquant_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Compress all PNG Click");
            String sList = String.Empty;
            String sFolderPath = tbFolderPath.Text;
            var fileList = new DirectoryInfo(sFolderPath).GetFiles("*.png", SearchOption.AllDirectories);
            if (fileList.Length > 0)
            {
                foreach (FileInfo fi in fileList)
                {
                    try
                    {
                        using (FileStream fileStream = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read))
                        {
                            Image img = ClPbHelper.ResizeImage((Image)(new Bitmap(Image.FromStream(fileStream))), 226, 226);
                            fileStream.Close();
                            img.Save(fi.FullName, ImageFormat.Png);
                        }
                    }
                    catch(Exception ex)
                    {
                        slLogger.Fatal(ex.Message);
                    }
                    sList += " \"" + fi.FullName + "\"";
                }
                // pngquant "test/1.png" "test1/1.png" --force --ext .png --verbose
                MyProcessHelper pPngQuant = new MyProcessHelper(Application.StartupPath + "\\pngquant\\pngquant.exe", sList + " --force --ext .png --verbose");
                pPngQuant.DoIt();
            }
            slLogger.Trace("<< Compress all PNG Click");
        }

        private void lbGames_KeyDown(object sender, KeyEventArgs e)
        {
            if (lbGames.SelectedIndex > -1)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    slLogger.Trace(">> Suppr folder Key");
                    try
                    {
                        ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                        String sFolderPath = tbFolderPath.Text;
                        if (sFolderPath.EndsWith("\\"))
                        {
                            sFolderPath = sFolderPath.Substring(0, sFolderPath.Length - 1);
                        }
                        //String sFolderSavePath = sFolderPath.Substring(0, sFolderPath.LastIndexOf("\\")) + "saves";
                        String sPath = sFolderPath + "\\" + cgs.FolderIndex;
                        if (Directory.Exists(sPath))
                        {
                            if ((e.Shift) || (DialogResult.Yes == FlexibleMessageBox.Show("Are you sure you want to delete this folder ?\n" + sPath, "Removing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                            {
                                slLogger.Debug("Removing folder " + sPath);
                                Directory.Delete(sPath, true);
                                /*if(Directory.Exists(sFolderSavePath + "\\" + cgs.FolderIndex))
                                {
                                    // don't remove, just move in case out of sync
                                    int index = 0;
                                    while (Directory.Exists(sFolderSavePath + "\\" + "bak" + index + "_" + cgs.FolderIndex))
                                    {
                                        index++;
                                    }
                                    Directory.Move(sFolderSavePath + "\\" + cgs.FolderIndex, sFolderSavePath + "\\" + "bak" + index + "_" + cgs.FolderIndex);
                                }
                                */
                                refreshGameListFolders();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        slLogger.Fatal(ex.Message);
                    }
                    slLogger.Trace("<< Suppr folder Key");
                }
            }
        }

        private void tsmiBSv041_CheckedChanged(object sender, EventArgs e)
        {
            //
            //MessageBox.Show(tsmiBSv041.Checked.ToString() + " -- " + tsmiBSv100.Checked.ToString());
            tsmiBSv100.Checked = !tsmiBSv041.Checked;
            if (tsmiBSv041.Checked)
            {
                iBleemsyncVersion = 0;
            }
            else
            {
                iBleemsyncVersion = 1;
            }
            currentUsedVersion = bleemsyncVersions[iBleemsyncVersion];
            tsmiBSVersionItem.Text = "Currently use BleemSync v" + currentUsedVersion.Versionstring;
            refreshGameListFolders();
        }

        private void tsmiBSv100_CheckedChanged(object sender, EventArgs e)
        {
            //
            //MessageBox.Show(tsmiBSv041.Checked.ToString() + " -- " + tsmiBSv100.Checked.ToString());
            tsmiBSv041.Checked = !tsmiBSv100.Checked;
            if (tsmiBSv100.Checked)
            {
                iBleemsyncVersion = 1;
            }
            else
            {
                iBleemsyncVersion = 0;
            }
            currentUsedVersion = bleemsyncVersions[iBleemsyncVersion];
            tsmiBSVersionItem.Text = "Currently use BleemSync v" + currentUsedVersion.Versionstring;
            refreshGameListFolders();
        }

        private void btDowngradeFolders_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Downgrade folder Click");
            // TODO si les game.ini n'existent pas, allez fouiller le fichier db
            String sFolderPath = tbFolderPath.Text;
            if (DialogResult.Yes == FlexibleMessageBox.Show("Do you really want downgrade your folders to 0.4.1 ?", "Moving...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                DirectoryInfo[] dirList = new DirectoryInfo(sFolderPath).GetDirectories("*", SearchOption.TopDirectoryOnly);
                ClVersionHelper srcVersion = bleemsyncVersions[1];
                ClVersionHelper dstVersion = bleemsyncVersions[0];
                foreach (DirectoryInfo di in dirList)
                {
                    try
                    { 
                        slLogger.Debug("** Directory: " + di.FullName);
                        String sFolderIndex = di.FullName.Substring(sFolderPath.Length);
                        if (sFolderIndex.StartsWith("\\"))
                        {
                            sFolderIndex = sFolderIndex.Substring(1);
                        }
                        String[] s2 = sFolderIndex.Split('\\');
                        sFolderIndex = s2[0];
                        if (Directory.Exists(di.FullName + srcVersion.GameDataFolder))
                        {
                            if (!Directory.Exists(di.FullName + dstVersion.GameDataFolder))
                            {
                                Directory.CreateDirectory(di.FullName + dstVersion.GameDataFolder);
                            }
                            FileInfo[] inDirfileList = new DirectoryInfo(di.FullName + srcVersion.GameDataFolder).GetFiles("*.*", SearchOption.TopDirectoryOnly);
                            foreach (FileInfo fi in inDirfileList)
                            {
                                String sPath = fi.FullName.Substring((di.FullName + srcVersion.GameDataFolder).Length);
                                String[] sSubFolders = sPath.Split(new char[] { '\\' }, StringSplitOptions.None);
                                if (sSubFolders.Length > 1)
                                {
                                    for (int i = 0; i < sSubFolders.Length - 1; i++)
                                    {
                                        String sSubs = String.Empty;
                                        int j = 0;
                                        while (j < i)
                                        {
                                            sSubs += "\\" + sSubFolders[j];
                                            j++;
                                        }
                                        if (!Directory.Exists(di.FullName + dstVersion.GameDataFolder + sSubs + "\\" + sSubFolders[i]))
                                        {
                                            Directory.CreateDirectory(di.FullName + dstVersion.GameDataFolder + sSubs + "\\" + sSubFolders[i]);
                                        }
                                    }
                                }
                                slLogger.Debug("Moving file " + fi.FullName + " to " + di.FullName + dstVersion.GameDataFolder);
                                File.Move(di.FullName + srcVersion.GameDataFolder + "\\" + sPath, di.FullName + dstVersion.GameDataFolder + "\\" + sPath);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        slLogger.Fatal(ex.Message);
                    }
                } // foreach
            }
            slLogger.Trace("<< Downgrade folder Click");
        }

        private void btUpgradeFolders_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Upgrade folder Click");
            String sFolderPath = tbFolderPath.Text;
            if (DialogResult.Yes == FlexibleMessageBox.Show("Do you really want to upgrade your folders to 1.0.0 ?", "Moving...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                DirectoryInfo[] dirList = new DirectoryInfo(sFolderPath).GetDirectories("*", SearchOption.TopDirectoryOnly);
                ClVersionHelper srcVersion = bleemsyncVersions[0];
                ClVersionHelper dstVersion = bleemsyncVersions[1];
                foreach (DirectoryInfo di in dirList)
                {
                    try
                    {
                        slLogger.Debug("** Directory: " + di.FullName);
                        String sFolderIndex = di.FullName.Substring(sFolderPath.Length);
                        if (sFolderIndex.StartsWith("\\"))
                        {
                            sFolderIndex = sFolderIndex.Substring(1);
                        }
                        String[] s2 = sFolderIndex.Split('\\');
                        sFolderIndex = s2[0];
                        if (Directory.Exists(di.FullName + srcVersion.GameDataFolder))
                        {
                            if (!Directory.Exists(di.FullName + dstVersion.GameDataFolder))
                            {
                                Directory.CreateDirectory(di.FullName + dstVersion.GameDataFolder);
                            }
                            FileInfo[] inDirfileList = new DirectoryInfo(di.FullName + srcVersion.GameDataFolder).GetFiles("*.*", SearchOption.TopDirectoryOnly);
                            foreach (FileInfo fi in inDirfileList)
                            {
                                String sPath = fi.FullName.Substring((di.FullName + srcVersion.GameDataFolder).Length);
                                String[] sSubFolders = sPath.Split(new char[] { '\\' }, StringSplitOptions.None);
                                if (sSubFolders.Length > 1)
                                {
                                    for (int i = 0; i < sSubFolders.Length - 1; i++)
                                    {
                                        String sSubs = String.Empty;
                                        int j = 0;
                                        while (j < i)
                                        {
                                            sSubs += "\\" + sSubFolders[j];
                                            j++;
                                        }
                                        if (!Directory.Exists(di.FullName + dstVersion.GameDataFolder + sSubs + "\\" + sSubFolders[i]))
                                        {
                                            Directory.CreateDirectory(di.FullName + dstVersion.GameDataFolder + sSubs + "\\" + sSubFolders[i]);
                                        }
                                    }
                                }
                                slLogger.Debug("Moving file " + fi.FullName + " to " + di.FullName + dstVersion.GameDataFolder);
                                File.Move(di.FullName + srcVersion.GameDataFolder + "\\" + sPath, di.FullName + dstVersion.GameDataFolder + "\\" + sPath);
                            }
                            if ((Directory.GetFiles(di.FullName + srcVersion.GameDataFolder).Length == 0) && (Directory.GetDirectories(di.FullName + srcVersion.GameDataFolder).Length == 0))
                            {
                                Directory.Delete(di.FullName + srcVersion.GameDataFolder);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        slLogger.Fatal(ex.Message);
                    }
                } // foreach
            }
            slLogger.Trace("<< Upgrade folder Click");
        }

        private Dictionary<String, Dictionary<String, String>> ReadDB(String sFilename, int bleemsyncVersion)
        {
            Dictionary<String, Dictionary<String, String>> dcListFromDB = new Dictionary<String, Dictionary<string, string>>();
            Dictionary<String, List<String>> dcListDiscsFromDB = new Dictionary<String, List<string>>();

            String cs = "URI=file:" + sFilename;
            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                try
                {
                    con.Open();

                    string stm = "SELECT * FROM DISC ORDER BY GAME_ID ASC, DISC_NUMBER ASC";

                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                String sId = rdr["GAME_ID"].ToString().Trim();
                                if (!dcListDiscsFromDB.ContainsKey(sId))
                                {
                                    dcListDiscsFromDB.Add(sId, new List<String>());
                                }
                                dcListDiscsFromDB[sId].Add(rdr["BASENAME"].ToString().Trim());
                            }
                        }
                    }
                    switch (bleemsyncVersion)
                    {
                        case 0:
                            stm = "SELECT * FROM GAME ORDER BY GAME_ID ASC";
                            break;
                        case 1:
                            stm = "SELECT * FROM MENU_ENTRIES ORDER BY GAME_ID ASC";
                            break;
                        default:
                            stm = "SELECT * FROM GAME ORDER BY GAME_ID ASC";
                            break;
                    }

                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                String sId = rdr["GAME_ID"].ToString().Trim();
                                Dictionary<String, String> dcLineFromDB = new Dictionary<string, string>();
                                dcLineFromDB.Add("title", rdr["GAME_TITLE_STRING"].ToString().Trim());
                                dcLineFromDB.Add("publisher", rdr["PUBLISHER_NAME"].ToString().Trim());
                                dcLineFromDB.Add("year", rdr["RELEASE_YEAR"].ToString().Trim());
                                dcLineFromDB.Add("players", rdr["PLAYERS"].ToString().Trim());
                                dcLineFromDB.Add("alphatitle", String.Empty);
                                if (dcListDiscsFromDB.ContainsKey(sId))
                                {
                                    dcLineFromDB.Add("discs", String.Join(",", (dcListDiscsFromDB[sId].ToArray())));
                                }
                                else
                                {
                                    dcLineFromDB.Add("discs", String.Empty); // not found in the other table
                                }
                                dcListFromDB.Add(sId, dcLineFromDB);
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
            return dcListFromDB;
        }
    
        private Dictionary<String, String> ReadFromGameIni(String sFilename)
        {
            Dictionary<String, String> dcFromGameIni = new Dictionary<string, string>();
            using (StreamReader sr = new StreamReader(sFilename))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    s = s.Trim();
                    if (s.StartsWith("Discs="))
                    {
                        dcFromGameIni.Add("discs", ClPbHelper.RemoveQuotes(s.Substring(6)));
                    }
                    else
                    if (s.StartsWith("Title="))
                    {
                        dcFromGameIni.Add("title", ClPbHelper.RemoveQuotes(s.Substring(6)));
                    }
                    else
                    if (s.StartsWith("Publisher="))
                    {
                        dcFromGameIni.Add("publisher", ClPbHelper.RemoveQuotes(s.Substring(10)));
                    }
                    else
                    if (s.StartsWith("Players="))
                    {
                        dcFromGameIni.Add("players", ClPbHelper.RemoveQuotes(s.Substring(8)));
                    }
                    else
                    if (s.StartsWith("Year="))
                    {
                        dcFromGameIni.Add("year", ClPbHelper.RemoveQuotes(s.Substring(5)));
                    }
                    else
                    if (s.StartsWith("AlphaTitle="))
                    {
                        dcFromGameIni.Add("alphatitle", ClPbHelper.RemoveQuotes(s.Substring(11)));
                    }
                }
            }
            if (!dcFromGameIni.ContainsKey("discs")) dcFromGameIni.Add("discs", String.Empty);
            if (!dcFromGameIni.ContainsKey("title")) dcFromGameIni.Add("title", String.Empty);
            if (!dcFromGameIni.ContainsKey("publisher")) dcFromGameIni.Add("publisher", String.Empty);
            if (!dcFromGameIni.ContainsKey("players")) dcFromGameIni.Add("players", String.Empty);
            if (!dcFromGameIni.ContainsKey("year")) dcFromGameIni.Add("year", String.Empty);
            if (!dcFromGameIni.ContainsKey("alphatitle")) dcFromGameIni.Add("alphatitle", String.Empty);

            return dcFromGameIni;
        }

        private void btReadBS041Database_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Read BS0.4.1 database Click");
            String sFolderPath = tbFolderPath.Text;
            if (sFolderPath.EndsWith("\\"))
            {
                sFolderPath = sFolderPath.Substring(0, sFolderPath.Length - 1);
            }
            ClVersionHelper srcVersion = bleemsyncVersions[0];

            String sFolderBase = sFolderPath.Substring(0, sFolderPath.LastIndexOf('\\'));
            String sFilePath = sFolderBase + srcVersion.DbFolder;
            String sFileName = "regional.db";
            ofdLoadDatabaseFile.FileName = sFileName;
            if (Directory.Exists(sFilePath))
            {
                ofdLoadDatabaseFile.InitialDirectory = sFilePath;
            }

            if (DialogResult.OK == ofdLoadDatabaseFile.ShowDialog())
            {
                // read db file
                // search in folders if there is a game.ini file
                // if not, create it
                // if yes, (and different if can be detected) ask user (choose left, right or keep 2 (one with .bak)
                // if yes (and identical), leave the existing
                Dictionary<String, Dictionary<String, String>> dcListFromDB = ReadDB(ofdLoadDatabaseFile.FileName, 0);
                if (Directory.Exists(sFolderPath))
                {
                    DirectoryInfo[] dirList = new DirectoryInfo(sFolderPath).GetDirectories("*", SearchOption.TopDirectoryOnly);
                    foreach (DirectoryInfo di in dirList)
                    {
                        String sDir = di.Name;
                        String sMyIniFile = di.FullName + currentUsedVersion.GameDataFolder + "\\" + "Game.ini";
                        if (File.Exists(sMyIniFile))
                        {
                            Dictionary<String, String> dcFromGameIni = ReadFromGameIni(sMyIniFile);

                            if (dcListFromDB.ContainsKey(sDir))
                            {
                                if ((dcFromGameIni["discs"] != dcListFromDB[sDir]["discs"])
                                    || (dcFromGameIni["title"] != dcListFromDB[sDir]["title"])
                                    || (dcFromGameIni["publisher"] != dcListFromDB[sDir]["publisher"])
                                    || (dcFromGameIni["players"] != dcListFromDB[sDir]["players"])
                                    || (dcFromGameIni["year"] != dcListFromDB[sDir]["year"])
                                    || (dcFromGameIni["alphatitle"] != dcListFromDB[sDir]["alphatitle"]))
                                {
                                    Form6 frm = new Form6(sMyIniFile, dcFromGameIni, dcListFromDB[sDir], slLogger);
                                    frm.ShowDialog();
                                }
                            }
                            else
                            {
                                // equal, do nothing
                            }
                        }
                        else
                        {
                            // game.ini doesn't exist, create it without asking user
                            if (dcListFromDB.ContainsKey(sDir))
                            {
                                slLogger.Debug("Creating Game.ini file in folder " + sDir);
                                ClPbHelper.SaveGameIni(sMyIniFile, dcListFromDB[sDir], slLogger);
                            }
                        }
                    }
                    dirList = null;
                }
            }
            slLogger.Trace("<< Read BS0.4.1 database Click");
        }

        private void btReadBS100Database_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Read BS1.0.0 database Click");
            String sFolderPath = tbFolderPath.Text;
            if (sFolderPath.EndsWith("\\"))
            {
                sFolderPath = sFolderPath.Substring(0, sFolderPath.Length - 1);
            }
            ClVersionHelper srcVersion = bleemsyncVersions[1];

            String sFolderBase = sFolderPath.Substring(0, sFolderPath.LastIndexOf('\\'));
            String sFilePath = sFolderBase + srcVersion.DbFolder;
            String sFileName = "regional.db";
            ofdLoadDatabaseFile.FileName = sFileName;
            if (Directory.Exists(sFilePath))
            {
                ofdLoadDatabaseFile.InitialDirectory = sFilePath;
            }
            
            if (DialogResult.OK == ofdLoadDatabaseFile.ShowDialog())
            {
                // read db file
                // search in folders if there is a game.ini file
                // if not, create it
                // if yes, (and different if can be detected) ask user (choose left, right or keep 2 (one with .bak)
                // if yes (and identical), leave the existing
                Dictionary<String, Dictionary<String, String>> dcListFromDB = ReadDB(ofdLoadDatabaseFile.FileName, 1);

                if (Directory.Exists(sFolderPath))
                {
                    DirectoryInfo[] dirList = new DirectoryInfo(sFolderPath).GetDirectories("*", SearchOption.TopDirectoryOnly);
                    foreach (DirectoryInfo di in dirList)
                    {
                        String sDir = di.Name;
                        String sMyIniFile = di.FullName + currentUsedVersion.GameDataFolder + "\\" + "Game.ini";
                        if (File.Exists(sMyIniFile))
                        {
                            Dictionary<String, String> dcFromGameIni = ReadFromGameIni(sMyIniFile);
                            
                            if (dcListFromDB.ContainsKey(sDir))
                            {
                                if ((dcFromGameIni["discs"] != dcListFromDB[sDir]["discs"])
                                    || (dcFromGameIni["title"] != dcListFromDB[sDir]["title"])
                                    || (dcFromGameIni["publisher"] != dcListFromDB[sDir]["publisher"])
                                    || (dcFromGameIni["players"] != dcListFromDB[sDir]["players"])
                                    || (dcFromGameIni["year"] != dcListFromDB[sDir]["year"])
                                    || (dcFromGameIni["alphatitle"] != dcListFromDB[sDir]["alphatitle"]))
                                {
                                    Form6 frm = new Form6(sMyIniFile, dcFromGameIni, dcListFromDB[sDir], slLogger);
                                    frm.ShowDialog();
                                }
                            }
                            else
                            {
                                // equal, do nothing
                            }
                        }
                        else
                        {
                            // game.ini doesn't exist, create it without asking user
                            if (dcListFromDB.ContainsKey(sDir))
                            {
                                slLogger.Debug("Creating Game.ini file in folder " + sDir);
                                ClPbHelper.SaveGameIni(sMyIniFile, dcListFromDB[sDir], slLogger);
                            }
                        }
                    }
                    dirList = null;
                }
            }
            slLogger.Trace("<< Read BS1.0.0 database Click");
        }

        private void btPbpRename_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Pbp AutoRename Click");
            if (lbGames.SelectedIndex > -1)
            {
                try
                {
                    ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                    String sFolderPath = tbFolderPath.Text;
                    String sPath = sFolderPath + "\\" + cgs.FolderIndex + "\\";
                    if ((!cgs.GameDataMissing) && (!cgs.IniMissing) && (!cgs.IniIncomplete) && (!cgs.PbpMissing) && (!cgs.PbpCountMisMatchDiscsCount) && (cgs.BadPbpName))
                    {
                        String[] sDiscs = cgs.Discs.Split(',');
                        List<String> lsFilenamesOk = cgs.FilesPbpOk;
                        List<String> lsFileNamesPbpLower = new List<string>();
                        List<String> lsFileToRename = new List<string>();
                        foreach (String s in cgs.Filenames)
                        {
                            if (s.ToLower().EndsWith(".pbp"))
                            {
                                lsFileNamesPbpLower.Add(s.ToLower());
                            }
                        }
                        if (lsFileNamesPbpLower.Count > 0)
                        {
                            using (NaturalComparer comparer = new NaturalComparer())
                            {
                                lsFileNamesPbpLower.Sort(comparer);
                            }
                            foreach (String sOneFile in lsFileNamesPbpLower)
                            {
                                if (lsFilenamesOk.IndexOf(sOneFile) > -1)
                                {
                                    //
                                }
                                else
                                {
                                    lsFileToRename.Add(sOneFile);
                                }
                            }
                            String[] sFileToRename = lsFileToRename.ToArray();
                            int iIndex = 0;
                            String sQuestion = String.Empty;
                            foreach (String s in sDiscs)
                            {
                                String sDisc = s.ToLower();
                                if (lsFilenamesOk.IndexOf(sDisc + ".pbp") > -1)
                                {
                                    iIndex++;
                                }
                                else
                                {
                                    if (iIndex < sFileToRename.Length)
                                    {
                                        if (File.Exists(sPath + currentUsedVersion.GameDataFolder + "\\" + sFileToRename[iIndex]))
                                        {
                                            sQuestion = sQuestion + Environment.NewLine + sPath + currentUsedVersion.GameDataFolder + "\\" + sFileToRename[iIndex] + " >> " + sPath + currentUsedVersion.GameDataFolder + "\\" + s + ".pbp";
                                        }
                                        iIndex++;
                                    }
                                }
                            }
                            if (DialogResult.Yes == FlexibleMessageBox.Show("Do you want to rename those files ?" + sQuestion, "Renaming...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {
                                iIndex = 0;
                                foreach (String s in sDiscs)
                                {
                                    String sDisc = s.ToLower();
                                    if (lsFilenamesOk.IndexOf(sDisc + ".pbp") > -1)
                                    {
                                        iIndex++;
                                    }
                                    else
                                    {
                                        if (iIndex < sFileToRename.Length)
                                        {
                                            if (File.Exists(sPath + currentUsedVersion.GameDataFolder + "\\" + sFileToRename[iIndex]))
                                            {
                                                File.Move(sPath + currentUsedVersion.GameDataFolder + "\\" + sFileToRename[iIndex], sPath + currentUsedVersion.GameDataFolder + "\\" + s + ".pbp");
                                                slLogger.Debug("Renaming file " + sFileToRename[iIndex] + " -> " + s + ".pbp");
                                            }
                                            iIndex++;
                                        }
                                    }
                                }
                            }
                        }
                        refreshOneFolder();
                    }
                    else
                    {
                        //
                    }
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
            }
            slLogger.Trace("<< Pbp AutoRename Click");
        }

        private void btValidateCfg_Click(object sender, EventArgs e)
        {
            //
            if (cbSimultaneousCopiedFiles.SelectedIndex > -1)
            {
                iSimultaneous = cbSimultaneousCopiedFiles.SelectedIndex + 1;
                lbCurrentSimultaneousCopiedFiles.Text = iSimultaneous.ToString();

                Properties.Settings.Default.iSimultaneous = iSimultaneous;
                frmCopy.SimultaneousCopiedFiles = iSimultaneous;
            }
        }

        private void btCheckBin_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7(dcPs1Games);
            f.ShowDialog();
        }

        private void btCheckMemCard_Click(object sender, EventArgs e)
        {
            String sFolderPath = tbFolderPath.Text;
            if (sFolderPath.EndsWith("\\"))
            {
                sFolderPath = sFolderPath.Substring(0, sFolderPath.Length - 1);
            }
            //String sFolderSavePath = sFolderPath.Substring(0, sFolderPath.LastIndexOf("\\")) + "saves";
            Form8 f = new Form8(sFolderPath);
            f.ShowDialog();
        }

        private void btIniFileCopy_Click(object sender, EventArgs e)
        {
            if(1 == iBleemsyncVersion)
            {
                String sFolderPath = tbFolderPath.Text;
                if (sFolderPath.EndsWith("\\"))
                {
                    sFolderPath = sFolderPath.Substring(0, sFolderPath.Length - 1);
                }
                String sInicfgPath = String.Empty;
                int ipos = sFolderPath.LastIndexOf("\\");
                if(ipos > -1)
                {
                    sInicfgPath = sFolderPath.Substring(0, ipos);
                }
                else
                {
                    sInicfgPath = sFolderPath;
                }
                try
                {
                    sInicfgPath += "\\bleemsync\\etc\\bleemsync\\CFG\\";
                    if (Directory.Exists(sInicfgPath))
                    {
                        File.Copy(Application.StartupPath + "\\" + "bleemsync_cfg.INI", sInicfgPath + "\\" + "bleemsync_cfg.INI");
                        FlexibleMessageBox.Show("File Copied to " + sInicfgPath);
                    }
                }
                catch(Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
            }
        }
    }
}