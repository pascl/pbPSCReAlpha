﻿using Markdig;
using System;
using System.Collections.Generic;
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

        public Form1()
        {
            InitializeComponent();
            this.frmCopy = new Form5();
            this.frmCopy.Visible = false;
            this.Text = "pbPSCReAlpha v" + Assembly.GetExecutingAssembly().GetName().Version;
            dcPs1Games = new Dictionary<string, ClPS1Game>();
            lsSbiNeeds = new List<string>();
            tbFolderPath.Text = Properties.Settings.Default.sFolderPath;
            slLogger = new SimpleLogger(tbLogDebug);
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
                    slLogger.Debug("Found games in xml for search function: " + dcPs1Games.Count.ToString());
                }
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
            }
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
            }
            slLogger.Trace("<< Browse 'Games' Folder Click");
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
            foreach(String s in lsTest)
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

            if (Directory.Exists(di.FullName + "\\GameData"))
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
                bool bSbiPresent = false;
                bool bNeededSbiMissing = false;
                bool bDiscCountMatchCueCount = false;
                bool bBadBinName = false;
                bool bBadCueName = false;
                UInt16 uiGameIni = 0;
                int iNbDiscs = 0;
                int iNbCue = 0;
                int iNbBin = 0;
                int iNbSbi = 0;
                Dictionary<String, String[]> dcBinParsed = new Dictionary<String, String[]>();
                List<String> lsBinPresent = new List<string>();
                List<String> lsSbiPresent = new List<string>();
                List<string> sFiles = new List<string>();
                FileInfo[] inDirfileList = new DirectoryInfo(di.FullName + "\\GameData").GetFiles("*.*", SearchOption.AllDirectories);
                foreach (FileInfo fi in inDirfileList)
                {
                    sFiles.Add(fi.Name);
                    slLogger.Debug("**** File: " + fi.Name);
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
                    if (fi.Extension.ToLower() == ".cue")
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
                                        lsBinParsed.Add(sBin.ToLower());
                                    }
                                }
                            }
                            dcBinParsed.Add(cueName.ToLower(), lsBinParsed.ToArray());
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
                    if (bCuePresent)
                    {
                        if (iNbCue == iNbDiscs)
                        {
                            bDiscCountMatchCueCount = true;
                            foreach (String sDisc in sDiscMulti)
                            {
                                String s = sDisc.ToLower(); // now useless
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
                cgs = new ClGameStructure(sFolderIndex, !bIsNumericFolderName, !bGameIniPresent, !bPcsxFilePresent, !bPicturePresent, !bPngMatchDisc, !bGameIniComplete, bMultiPictures, !bCuePresent, bBadCueName, !bBinPresent, bBadBinName, !bDiscCountMatchCueCount, bNeededSbiMissing);
                if (bGameIniPresent)
                {
                    cgs.setIniInfos(sTitle, sDiscs, sPublisher, sYear, sPlayers, sAlphaTitle);
                }
                cgs.setFilesList(sFiles);
                cgs.setPicture(bmPictureString, (Image)(new Bitmap(bmPicture)));
                bmPicture.Dispose();
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
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
            }
            return dcGames;
        }

        private void refreshGameListFolders()
        {
            btReSort.Enabled = false;
            btNewFolder.Enabled = false;
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
                        if(iSelected > -1)
                        {
                            if(((cgs.Alphatitle != String.Empty) && (dcGames[s].Alphatitle == cgs.Alphatitle)) || ((cgs.Alphatitle == String.Empty) && (dcGames[s].Title == cgs.Title))) // if (s == cgs.FolderIndex)
                            {
                                lbGames.SelectedIndex = lbGames.Items.Count - 1;
                            }
                        }
                    }
                }
                btReSort.Enabled = true;
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
            slLogger.Trace(">> Game Selection changed in gamelist");
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
                        if ((s == "pcsx.cfg") || (s == "game.ini") || (s.EndsWith(".cue")) || (s.EndsWith(".bin")) || (s.EndsWith(".png")) 
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
                if(true == cgs.GeneralError)
                {
                    /*if(cgs.IniIncomplete || cgs.IniMissing)
                    {

                    }
                    else
                    {

                    }*/
                    /*if(cgs.PngMissing)
                    {

                    }
                    else
                    {

                    }*/
                    if(cgs.CueMissing)
                    {
                        btEditCue.Visible = false;
                        btEditCue.Enabled = false;
                    }
                    else
                    {
                        btEditCue.Enabled = true;
                        btEditCue.Visible = true;
                    }
                    if (cgs.CfgMissing)
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
                }
            }
            else
            {
                btAddFiles.Enabled = false;
                btAddFiles.Visible = false;

                btAddPcsxCfg.Visible = false;
                btAddPcsxCfg.Enabled = false;

                btEditCue.Visible = false;
                btEditCue.Enabled = false;

                btRefreshFolderOnly.Enabled = false;
                btRefreshFolderOnly.Visible = false;

                pbExploreImage.AllowDrop = false;
            }
            slLogger.Trace("<< Game Selection changed in gamelist");
        }

        private void btReSort_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Resort gamelist Click");
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
                                if ((sFolderPath + "\\" + index.ToString()) != (sFolderPath + "\\" + (index + iDecalage).ToString()))
                                {
                                    Directory.Move(sFolderPath + "\\" + index.ToString(), sFolderPath + "\\" + (index + iDecalage).ToString());
                                }
                                //lbGames.Items.Add(dcGames[s]);
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
                                        liFoldersDone.Add(iIndexFolder);
                                        iNewIndex++;
                                        break;
                                    }
                                }
                            }
                            if(iNewIndex == iPrevIndex)
                            {
                                // just in case
                                iNewIndex++;
                            }
                        }
                        refreshGameListFolders();
                    }
                    catch(Exception ex)
                    {
                        slLogger.Fatal(ex.Message);
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Correct the wrong detected folders (not numbered names, GameData or Game.ini missing).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            slLogger.Trace("<< Resort gamelist Click");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.sFolderPath = tbFolderPath.Text;
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
                        while(Directory.Exists(sFolderPath + "\\" + iNext.ToString()))
                        {
                            iNext++;
                        }
                        Directory.CreateDirectory(sFolderPath + "\\" + iNext.ToString());
                        Directory.CreateDirectory(sFolderPath + "\\" + iNext.ToString() + "\\" + "GameData");
                        File.Copy(Application.StartupPath + "\\" + "pcsx.cfg", sFolderPath + "\\" + iNext.ToString() + "\\" + "GameData" + "\\" + "pcsx.cfg");
                    }
                    catch(Exception ex)
                    {
                        slLogger.Fatal(ex.Message);
                    }
                    refreshGameListFolders();
                }
                else
                {
                    MessageBox.Show("Correct the wrong folder names before doing this.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            slLogger.Trace("<< Create new folder Click");
        }
        
        private void btLaunchBleemsync_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Launch BleemSync Click");
            String sFolderPath = tbFolderPath.Text;
            if(sFolderPath.EndsWith("\\"))
            {
                sFolderPath = sFolderPath.Substring(0, sFolderPath.Length - 1);
            }
            if (Directory.Exists(sFolderPath))
            {
                String[] sFolderDecomposed = sFolderPath.Split('\\');
                if((sFolderDecomposed.Length > 1) && (sFolderDecomposed[sFolderDecomposed.Length - 1] == "Games"))
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
                            MessageBox.Show("There is not the BleemSync executable here: " + sFolderBleemsync, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is not a BleemSync folder: " + sFolderBleemsync, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("There is a problem with the folder path: " + sFolderPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Folder " + sFolderPath + " not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< Launch BleemSync Click");
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
            if(true == bAccessingDebugTab)
            { 
                DebugLogScrollToEnd();
                bAccessingDebugTab = false;
            }
        }

        private void btEditGameIni_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Edit Game.ini Click");
            String sFolderPath = tbFolderPath.Text;
            Form2 f = null;
            if (lbGames.SelectedIndex > -1)
            {
                ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                f = new Form2(sFolderPath, slLogger, dcPs1Games, cgs);
            }
            else
            {
                f = new Form2(sFolderPath, slLogger, dcPs1Games);
            }
            f.ShowDialog();
            refreshOneFolder();
            slLogger.Trace("<< Edit Game.ini Click");
        }

        private void btEditPng_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Edit image Click");
            String sFolderPath = tbFolderPath.Text;
            Form3 f = null;
            if (lbGames.SelectedIndex > -1)
            {
                ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                f = new Form3(sFolderPath, slLogger, cgs);
            }
            else
            {
                f = new Form3(sFolderPath, slLogger);
            }
            f.ShowDialog();
            refreshOneFolder();
            slLogger.Trace("<< Edit image Click");
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
                    File.Copy(Application.StartupPath + "\\" + "pcsx.cfg", sFolderPath + "\\" + cgs.FolderIndex.ToString() + "\\" + "GameData" + "\\" + "pcsx.cfg");
                }
                catch(Exception ex)
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
                f = new Form4(sFolderPath, slLogger, cgs);
            }
            else
            {
                f = new Form4(sFolderPath, slLogger);
            }
            f.ShowDialog();
            refreshOneFolder();
            slLogger.Trace("<< Edit cue file Click");
        }

        void pbCopyFiles(String[] sFiles, String dstFolder)
        {
            if (Directory.Exists(dstFolder))
            {
                foreach (string sFile in sFiles)
                {
                    //File.Copy(sFile, sMyFolder + "\\" + sFile.Substring(sFile.LastIndexOf('\\')));
                    //MessageBox.Show("File Copied from" + sFile + "\n to" + sMyFolder);
                    if (this.frmCopy != null)
                    {
                        this.frmCopy.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                        this.frmCopy.Visible = true;
                    }
                    else
                    {
                        this.frmCopy = new Form5();
                        this.frmCopy.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                        this.frmCopy.Visible = true;
                    }
                    ClPbProgessBarLabeled pbl = this.frmCopy.addNewLine(sFile.Substring(sFile.LastIndexOf('\\')));
                    ClPbWebClient wc = new ClPbWebClient(pbl, slLogger);
                    wc.DownloadFileAsync(new Uri(sFile), dstFolder + "\\" + sFile.Substring(sFile.LastIndexOf('\\')));
                }
            }
            else
            {
                slLogger.Error("Destination directory doesn't exist");
                MessageBox.Show("Directory doesn't exist");
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
                        String sPath = sFolderPath + "\\" + cgs.FolderIndex + "\\" + "GameData";
                        pbCopyFiles(sFileList, sPath);
                    }
                }
                catch(Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                refreshOneFolder(); // refresh but probably copying not done yet...
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
                    String sPath = sFolderPath + "\\" + cgs.FolderIndex + "\\" + "GameData";
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
                catch(Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                refreshOneFolder(); // refresh but probably copying not done yet...
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
                    String sPath = sFolderPath + "\\" + cgs.FolderIndex + "\\" + "GameData" + "\\";
                    char[] invalidFileChars = Path.GetInvalidFileNameChars();
                    if (cgs.Filenames[e.Item] != e.Label)
                    {
                        if (e.Label.IndexOfAny(invalidFileChars) == -1)
                        {
                            if ((cgs.Filenames.IndexOf(e.Label) == -1) && (!File.Exists(sPath + e.Label)))
                            {
                                slLogger.Debug("Renaming " + sPath + cgs.Filenames[e.Item] + " to " + sPath + e.Label);
                                File.Move(sPath + cgs.Filenames[e.Item], sPath + e.Label);
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
                refreshOneFolder();
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
                            String sPath = sFolderPath + "\\" + cgs.FolderIndex + "\\" + "GameData" + "\\";
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
                    String sExt = Path.GetExtension(sFileList[0]);
                    List<String> lsAcceptedExt = new List<string>() { ".png", ".jpg", ".jpeg", ".bmp" };
                    if (lsAcceptedExt.IndexOf(sExt) > -1)
                    {
                        Bitmap bmPicture = new Bitmap(sFileList[0]);
                        pbExploreImage.Image = (Image)(new Bitmap(bmPicture));
                        bmPicture.Dispose();
                        if (lbGames.SelectedIndex > -1)
                        {
                            try
                            {
                                ClGameStructure cgs = (ClGameStructure)(lbGames.Items[lbGames.SelectedIndex]);
                                String sFolderPath = tbFolderPath.Text;
                                String sPath = sFolderPath + "\\" + cgs.FolderIndex + "\\" + "GameData" + "\\";
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
                    MessageBox.Show("Only one file for drag&drop operation please.");
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

        private void refreshOneFolder()
        {
            ClGameStructure cgsSave = null;
            int iIndex = lbGames.SelectedIndex;
            if (iIndex > -1)
            {
                cgsSave = (ClGameStructure)(lbGames.Items[iIndex]);
                String sFolderPath = tbFolderPath.Text;
                String sFolder = sFolderPath + "\\" + cgsSave.FolderIndex;

                DirectoryInfo directoryInfo = new DirectoryInfo(sFolder);
                slLogger.Debug("Refreshing " + sFolder);
                ClGameStructure cgs = manageFolder(cgsSave.FolderIndex, directoryInfo, ref lsFolders, ref lsTitles, false);
                if (cgs != null)
                {
                    lbGames.Items.RemoveAt(iIndex);
                    lbGames.Items.Insert(iIndex, cgs);
                    lbGames.SelectedIndex = iIndex;
                }
            }
        }

        private void btRefreshFolderOnly_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Refresh folder Click");
            refreshOneFolder();
            slLogger.Trace("<< Refresh folder Click");
        }
    }
}
