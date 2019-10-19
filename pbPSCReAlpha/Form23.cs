using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace pbPSCReAlpha
{
    public partial class Form23 : Form
    {
        String _folderPath;
        SimpleLogger slLogger;
        Dictionary<String, ClPS1Game> dcPs1Games;
        Dictionary<string, ClTGDBGame> dcTgdbGames;
        ClGameStructure newGame;
        String _currentFilePathIni;
        String _currentFilePathImg;
        String _docHtmlStr;
        ClVersionHelper _versionBS;
        int _sleepTime = 200;
        int _lastSite = -1;
        

        public Form23(String sFolderPath, SimpleLogger sl, Dictionary<String, ClPS1Game> dcClPS1Games, Dictionary<string, ClTGDBGame> dcClTgdbGames, ClVersionHelper cvh)
        {
            InitializeComponent();
            _folderPath = sFolderPath;
            slLogger = sl;
            dcPs1Games = dcClPS1Games;
            dcTgdbGames = dcClTgdbGames;
            _versionBS = cvh;
            newGame = null;
            _currentFilePathIni = String.Empty;
            _docHtmlStr = String.Empty;
            lbCurrentGameIniFile.Text = _currentFilePathIni;
            btSaveIni.Enabled = false;
            btReloadTitleDiscs.Enabled = false;
            btIniReload.Enabled = false;

            pbCover.AllowDrop = true;
            _currentFilePathImg = String.Empty;
            lbCurrentPngFile.Text = _currentFilePathImg;
            btSave.Enabled = false;
            btPictureReload.Enabled = false;
        }

        public Form23(String sFolderPath, SimpleLogger sl, Dictionary<String, ClPS1Game> dcClPS1Games, Dictionary<string, ClTGDBGame> dcClTgdbGames, ClVersionHelper cvh, ClGameStructure myGame)
        {
            InitializeComponent();
            slLogger = sl;
            dcPs1Games = dcClPS1Games;
            dcTgdbGames = dcClTgdbGames;
            _versionBS = cvh;
            newGame = myGame;
            _folderPath = sFolderPath + "\\" + newGame.FolderIndex + _versionBS.GameDataFolder;
            _currentFilePathIni = String.Empty;
            _docHtmlStr = String.Empty;
            btSaveIni.Enabled = false;

            if (!newGame.IniMissing)
            {
                tbGeneTitle.Text = newGame.Title;
                tbGeneDiscs.Text = newGame.Discs;
                tbGenePublisher.Text = newGame.Publisher;
                tbGeneAlphaTitle.Text = newGame.Alphatitle;
                try
                {
                    nuGenePlayers.Value = (decimal)int.Parse(newGame.Players);
                }
                catch(Exception ex)
                {
                    //
                }
                try
                {
                    nuGeneYear.Value = (decimal)int.Parse(newGame.Year);
                }
                catch(Exception ex)
                {
                    //
                }
                _currentFilePathIni = _folderPath + "\\" + "Game.ini";
                lbCurrentGameIniFile.Text = _currentFilePathIni;
                btSaveIni.Enabled = true;
                btReloadTitleDiscs.Enabled = true;
                btIniReload.Enabled = true;
                tbGeneSearchText.Text = newGame.Title;
            }

            _currentFilePathImg = String.Empty;
            lbCurrentPngFile.Text = _currentFilePathImg;
            btSave.Enabled = false;
            btPictureReload.Enabled = false;

            if(newGame.BypassLaunchScript)
            {
                tabControlSearchPanel.SelectedTab = tabTGDBNet;
            }
            else
            {
                tabControlSearchPanel.SelectedTab = tabPsxSearch;
            }

            if (!newGame.PngMissing)
            {
                try
                {
                    pbCover.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(newGame.PictureFile)), 226, 226);
                    _currentFilePathImg = newGame.PictureFileName;
                    lbCurrentPngFile.Text = _currentFilePathImg;
                    btSave.Enabled = true;
                    btPictureReload.Enabled = true;
                }
                catch (Exception ex)
                {
                    if(null != slLogger)
                        slLogger.Fatal(ex.Message);
                }
            }
            pbCover.AllowDrop = true;
        }

        private void btLoadIni_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Load Game.ini Click");
            if (!String.IsNullOrEmpty(_currentFilePathIni))
            {
                ofdGeneLoadIni.InitialDirectory = _currentFilePathIni.Substring(0, _currentFilePathIni.LastIndexOf("\\"));
            }
            else
            if (Directory.Exists(_folderPath))
            {
                ofdGeneLoadIni.InitialDirectory = _folderPath;
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
                        tbGeneDeveloper.Clear();
                        nuGenePlayers.Value = (decimal)1;
                        nuGeneYear.Value = (decimal)1995;
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.StartsWith("Discs="))
                            {
                                tbGeneDiscs.Text = ClPbHelper.RemoveQuotes(s.Substring(6));
                            }
                            else
                            if (s.StartsWith("Title="))
                            {
                                tbGeneTitle.Text = ClPbHelper.RemoveQuotes(s.Substring(6));
                            }
                            else
                            if (s.StartsWith("Publisher="))
                            {
                                tbGenePublisher.Text = ClPbHelper.RemoveQuotes(s.Substring(10));
                            }
                            else
                            if (s.StartsWith("Developer="))
                            {
                                tbGeneDeveloper.Text = ClPbHelper.RemoveQuotes(s.Substring(10));
                            }
                            else
                            if (s.StartsWith("Players="))
                            {
                                try
                                {
                                    nuGenePlayers.Value = (decimal)(int.Parse(ClPbHelper.RemoveQuotes(s.Substring(8))));
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
                                    nuGeneYear.Value = (decimal)(int.Parse(ClPbHelper.RemoveQuotes(s.Substring(5))));
                                }
                                catch (Exception ex)
                                {
                                    //
                                }
                            }
                            else
                            if (s.StartsWith("AlphaTitle="))
                            {
                                tbGeneAlphaTitle.Text = ClPbHelper.RemoveQuotes(s.Substring(11));
                            }
                        }
                    }
                    if(null == newGame)
                    {
                        newGame = new ClGameStructure("", true, true);
                    }
                    newGame.IniMissing = false;
                    newGame.Title = tbGeneTitle.Text;
                    newGame.Discs = tbGeneDiscs.Text;
                    newGame.Publisher = tbGenePublisher.Text;
                    newGame.Developer = tbGeneDeveloper.Text;
                    newGame.Alphatitle = tbGeneAlphaTitle.Text;
                    try
                    {
                        newGame.Players = ((int)(nuGenePlayers.Value)).ToString();
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                    try
                    {
                        newGame.Year = ((int)nuGeneYear.Value).ToString();
                    }
                    catch (Exception ex)
                    {
                        //
                    }
                    _currentFilePathIni = sFileName;
                    lbCurrentGameIniFile.Text = _currentFilePathIni;
                    btSaveIni.Enabled = true;
                    btReloadTitleDiscs.Enabled = true;
                    btIniReload.Enabled = true;
                }
                catch (Exception ex)
                {
                    if (null != slLogger)
                        slLogger.Fatal(ex.Message);
                }
            }
            if (null != slLogger)
                slLogger.Trace("<< Load Game.ini Click");
        }

        private void btGenerateIni_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Save as Game.ini Click");
            String s1 = ClPbHelper.RemoveQuotes(tbGeneTitle.Text); // have to be not empty
            String s2 = ClPbHelper.RemoveQuotes(tbGeneDiscs.Text); // have to be not empty
            if ((!String.IsNullOrEmpty(s1)) && (!(String.IsNullOrEmpty(s2))))
            {
                String s3 = ClPbHelper.RemoveQuotes(tbGenePublisher.Text);
                String s3_5 = ClPbHelper.RemoveQuotes(tbGeneDeveloper.Text);
                String s4 = ClPbHelper.RemoveQuotes(tbGeneAlphaTitle.Text);
                int i1 = (int)(nuGenePlayers.Value);
                int i2 = (int)(nuGeneYear.Value);
                if(!String.IsNullOrEmpty(_currentFilePathIni))
                {
                    sfdGeneSaveIni.InitialDirectory = _currentFilePathIni.Substring(0, _currentFilePathIni.LastIndexOf("\\"));
                }
                else
                if (Directory.Exists(_folderPath))
                {
                    sfdGeneSaveIni.InitialDirectory = _folderPath;
                }
                if (DialogResult.OK == sfdGeneSaveIni.ShowDialog())
                {
                    String sFileName = sfdGeneSaveIni.FileName;
                    try
                    {
                        Dictionary<String, String> dcTosave = new Dictionary<string, string>();
                        dcTosave.Add("title", s1);
                        dcTosave.Add("discs", s2);
                        dcTosave.Add("publisher", s3);
                        dcTosave.Add("developer", s3_5);
                        dcTosave.Add("alphatitle", s4);
                        dcTosave.Add("players", i1.ToString());
                        dcTosave.Add("year", i2.ToString());
                        if (null != newGame)
                        {
                            dcTosave.Add("automation", newGame.ABautomation);
                            dcTosave.Add("highres", newGame.ABhighres);
                            dcTosave.Add("imagetype", newGame.ABimagetype);
                            dcTosave.Add("memcard", newGame.ABmemcard);
                        }
                        ClPbHelper.SaveGameIni(sFileName, dcTosave, slLogger);
                        
                        _currentFilePathIni = sFileName;
                        lbCurrentGameIniFile.Text = _currentFilePathIni;
                        btSaveIni.Enabled = true;
                        btReloadTitleDiscs.Enabled = true;
                        btIniReload.Enabled = true;

                        if (null == newGame)
                        {
                            newGame = new ClGameStructure("", true, true);
                        }
                        newGame.IniMissing = false;
                        newGame.Title = s1;
                        newGame.Discs = s2;
                        newGame.Publisher = s3;
                        newGame.Developer = s3_5;
                        newGame.Alphatitle = s4;
                        try
                        {
                            newGame.Players = i1.ToString();
                        }
                        catch (Exception ex)
                        {
                            //
                        }
                        try
                        {
                            newGame.Year = i2.ToString();
                        }
                        catch (Exception ex)
                        {
                            //
                        }
                    }
                    catch (Exception ex)
                    {
                        if (null != slLogger)
                            slLogger.Fatal(ex.Message);
                    }
                }
            }
            else
            {
                FlexibleMessageBox.Show("You have to enter at least Title and Discs to continue...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (null != slLogger)
                slLogger.Trace("<< Save as Game.ini Click");
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btGeneSearch_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Search Game Click");
            String s = tbGeneSearchText.Text.Trim().ToUpper();
            lbGeneBigDataPSX.Items.Clear();
            lbGeneBigDataPSX.DisplayMember = "DisplayTitle";
            tbHiddenLinkPSX.Text = "";
            btViewPagePSX.Enabled = false;
            btLinkPSX.Enabled = false;

            lbGeneBigDataTGDB.Items.Clear();
            lbGeneBigDataTGDB.DisplayMember = "DisplayTitle";
            tbHiddenLinkTGDB.Text = "";
            btViewPageTGDB.Enabled = false;
            btLinkTGDB.Enabled = false;

            btScraper.Enabled = false;
            btScrapeImg.Enabled = false;
            btScrapeImgProportional.Enabled = false;

            _docHtmlStr = String.Empty;
            if (s.Length < 2)
            {
                FlexibleMessageBox.Show("You have to enter at least 2 characters (other than space) to search something.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            if (dcPs1Games.Count > 0)
            {
                foreach (KeyValuePair<string, ClPS1Game> pair in dcPs1Games)
                {
                    ClPS1Game c1 = pair.Value;
                    if (c1.Title.ToUpper().Contains(s))
                    {
                        lbGeneBigDataPSX.Items.Add(c1);
                    }
                }
            }
            else
            {
                FlexibleMessageBox.Show("Error. Gamelist not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (dcTgdbGames.Count > 0)
            {
                foreach (KeyValuePair<string, ClTGDBGame> pair in dcTgdbGames)
                {
                    ClTGDBGame c1 = pair.Value;
                    if (c1.Title.ToUpper().Contains(s))
                    {
                        lbGeneBigDataTGDB.Items.Add(c1);
                    }
                }
            }
            else
            {
                FlexibleMessageBox.Show("Error. Gamelist not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (null != slLogger)
                slLogger.Trace("<< Search Game Click");
        }

        private void btLink_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Game Link Click");

            String sLink = tbHiddenLinkPSX.Text.Trim();
            if (!String.IsNullOrEmpty(sLink))
            {
                System.Diagnostics.Process.Start("http://psxdatacenter.com/" + sLink);
            }
            if (null != slLogger)
                slLogger.Trace("<< Game Link Click");
        }

        private void lbGeneBigData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Game Selection changed in search results");
            if (lbGeneBigDataPSX.SelectedIndex > -1)
            {
                ClPS1Game psGame = (ClPS1Game)(lbGeneBigDataPSX.Items[lbGeneBigDataPSX.SelectedIndex]);
                String sTitle = psGame.Title.Trim();
                int ipos = sTitle.LastIndexOf("- [");
                if(ipos > -1)
                {
                    sTitle = sTitle.Substring(0, ipos).Trim();
                }
                tbGeneTitle.Text = sTitle.Trim();
                tbGeneDiscs.Text = psGame.Serial.Trim();
                tbHiddenLinkPSX.Text = psGame.Link.Trim();
                btLinkPSX.Enabled = true;
                btViewPagePSX.Enabled = true;
            }
            else
            {
                btLinkPSX.Enabled = false;
                btViewPagePSX.Enabled = false;
            }
            if (null != slLogger)
                slLogger.Trace("<< Game Selection changed in search results");
        }

        private void btSaveIni_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Save Game.ini Click");
            String s1 = ClPbHelper.RemoveQuotes(tbGeneTitle.Text); // have to be not empty
            String s2 = ClPbHelper.RemoveQuotes(tbGeneDiscs.Text); // have to be not empty
            if ((!String.IsNullOrEmpty(s1)) && (!(String.IsNullOrEmpty(s2))))
            {
                String s3 = ClPbHelper.RemoveQuotes(tbGenePublisher.Text);
                String s3_5 = ClPbHelper.RemoveQuotes(tbGeneDeveloper.Text);
                String s4 = ClPbHelper.RemoveQuotes(tbGeneAlphaTitle.Text);
                int i1 = (int)(nuGenePlayers.Value);
                int i2 = (int)(nuGeneYear.Value);
                if (!String.IsNullOrEmpty(_currentFilePathIni))
                {
                    String sFileName = _currentFilePathIni;
                    try
                    {
                        Dictionary<String, String> dcTosave = new Dictionary<string, string>();
                        dcTosave.Add("title", s1);
                        dcTosave.Add("discs", s2);
                        dcTosave.Add("publisher", s3);
                        dcTosave.Add("developer", s3_5);
                        dcTosave.Add("alphatitle", s4);
                        dcTosave.Add("players", i1.ToString());
                        dcTosave.Add("year", i2.ToString());
                        if (null != newGame)
                        {
                            dcTosave.Add("automation", newGame.ABautomation);
                            dcTosave.Add("highres", newGame.ABhighres);
                            dcTosave.Add("imagetype", newGame.ABimagetype);
                            dcTosave.Add("memcard", newGame.ABmemcard);
                        }
                        ClPbHelper.SaveGameIni(sFileName, dcTosave, slLogger);
                        
                        _currentFilePathIni = sFileName;
                        lbCurrentGameIniFile.Text = _currentFilePathIni;
                        btSaveIni.Enabled = true;
                        btReloadTitleDiscs.Enabled = true;
                        btIniReload.Enabled = true;
                        
                        if (null == newGame)
                        {
                            newGame = new ClGameStructure("", true, true);
                        }
                        newGame.IniMissing = false;
                        newGame.Title = s1;
                        newGame.Discs = s2;
                        newGame.Publisher = s3;
                        newGame.Developer = s3_5;
                        newGame.Alphatitle = s4;
                        try
                        {
                            newGame.Players = i1.ToString();
                        }
                        catch (Exception ex)
                        {
                            //
                        }
                        try
                        {
                            newGame.Year = i2.ToString();
                        }
                        catch (Exception ex)
                        {
                            //
                        }
                    }
                    catch (Exception ex)
                    {
                        if (null != slLogger)
                            slLogger.Fatal(ex.Message);
                    }
                }
            }
            else
            {
                FlexibleMessageBox.Show("You have to enter at least Title and Discs to continue...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (null != slLogger)
                slLogger.Trace("<< Save Game.ini Click");
        }

        private void tbGeneSearchText_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Return) || (e.KeyData == Keys.Enter))
            {
                btGeneSearch_Click(sender, e);
            }
        }

        private void btGeneCopyTitle_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Copy in alphatitle Click");
            tbGeneAlphaTitle.Text = tbGeneTitle.Text;
            if (null != slLogger)
                slLogger.Trace("<< Copy in alphatitle Click");
        }

        private void btViewPage_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> View webpage Click");
            if (lbGeneBigDataPSX.SelectedIndex > -1)
            {
                try
                {
                    wbViewer.AllowNavigation = true;
                    Thread.Sleep(_sleepTime);
                    wbViewer.Navigate("about:blank");
                    Thread.Sleep(_sleepTime);
                    btScraper.Enabled = false;
                    btScrapeImg.Enabled = false;
                    btScrapeImgProportional.Enabled = false;
                    ClPS1Game psGame = (ClPS1Game)(lbGeneBigDataPSX.Items[lbGeneBigDataPSX.SelectedIndex]);
                    wbViewer.AllowNavigation = true;
                    Thread.Sleep(_sleepTime);
                    wbViewer.Navigate("http://psxdatacenter.com/" + psGame.Link.Trim());
                    Thread.Sleep(_sleepTime);
                    _lastSite = 1;
                }
                catch (Exception ex)
                {
                    if (null != slLogger)
                        slLogger.Fatal(ex.Message);
                }
            }
            if (null != slLogger)
                slLogger.Trace("<< View webpage Click");
        }

        private void wbViewer_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument htmlDocument = wbViewer.Document;
            HtmlElementCollection htmlElementCollection = htmlDocument.Images;
            this.pbTmp.Image = (Image)(new Bitmap(1, 1));
            _docHtmlStr = wbViewer.DocumentText.ToString();
            foreach (HtmlElement htmlElement in htmlElementCollection)
            {
                string imgUrl = htmlElement.GetAttribute("src");
                if (imgUrl.StartsWith("http://psxdatacenter.com/images/covers/"))
                {
                    btScraper.Enabled = true;
                    this.pbTmp.WaitOnLoad = false;
                    this.pbTmp.ImageLocation = imgUrl;
                    wbViewer.AllowNavigation = false;
                    break;
                }
                else
                if (imgUrl.StartsWith("https://cdn.thegamesdb.net/images/thumb/boxart/front/"))
                {
                    btScraper.Enabled = true;
                    this.pbTmp.WaitOnLoad = false;
                    this.pbTmp.ImageLocation = imgUrl;
                    wbViewer.AllowNavigation = false;
                    break;
                }
            }
        }

        private void btScraper_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Scrape webpage Click");
            ClGameScraper clgs = new ClGameScraper(_docHtmlStr, _lastSite);

            tbGenePublisher.Text = clgs.Publisher;
            tbGeneDeveloper.Text = clgs.Developer;
            tbGeneTitle.Text = clgs.Title;
            try
            {
                nuGenePlayers.Value = (decimal)(int.Parse(clgs.Players));
            }
            catch (Exception ex)
            {
                nuGenePlayers.Value = (decimal)1;
            }
            try
            {
                nuGeneYear.Value = (decimal)(int.Parse(clgs.Year));
            }
            catch (Exception ex)
            {
                nuGeneYear.Value = (decimal)1995;
            }
            if (null != slLogger)
                slLogger.Trace("<< Scrape webpage Click");
        }

        private void btReloadTitleDiscs_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Reload title and discs Click");
            if (!newGame.IniMissing)
            {
                tbGeneTitle.Text = newGame.Title;
                tbGeneDiscs.Text = newGame.Discs;
            }
            if (null != slLogger)
                slLogger.Trace("<< Reload title and discs Click");
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Load image Click");
            if (Directory.Exists(_folderPath))
            {
                ofdGeneLoadImage.InitialDirectory = _folderPath;
            }
            if (DialogResult.OK == ofdGeneLoadImage.ShowDialog())
            {
                String sFileName = ofdGeneLoadImage.FileName;
                try
                {
                    using (Bitmap bmPicture = new Bitmap(sFileName))
                    {
                        pbCover.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bmPicture)), 226, 226);
                    }
                    _currentFilePathImg = sFileName;
                    lbCurrentPngFile.Text = _currentFilePathImg;
                    btSave.Enabled = true;
                    btPictureReload.Enabled = true;
                }
                catch (Exception ex)
                {
                    if (null != slLogger)
                        slLogger.Fatal(ex.Message);
                }
            }
            if (null != slLogger)
                slLogger.Trace("<< Load image Click");
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Save PNG Click");
            if (!String.IsNullOrEmpty(_currentFilePathImg))
            {
                String sFileName = _currentFilePathImg;
                try
                {
                    pbCover.Image.Save(sFileName, ImageFormat.Png);

                    _currentFilePathImg = sFileName;
                    lbCurrentPngFile.Text = _currentFilePathImg;
                    btSave.Enabled = true;
                    btPictureReload.Enabled = true;

                    MyProcessHelper pPngQuant = new MyProcessHelper(Application.StartupPath + "\\pngquant\\pngquant.exe", sFileName + " --force --ext .png --verbose");
                    pPngQuant.DoIt();
                    // pngquant "test/1.png" "test1/1.png" --force --ext .png --verbose

                    if (null == newGame)
                    {
                        newGame = new ClGameStructure("", true, true);
                    }
                    newGame.PngMissing = false;
                    newGame.setPicture(sFileName, (Image)(new Bitmap(pbCover.Image)));
                }
                catch (Exception ex)
                {
                    if (null != slLogger)
                        slLogger.Fatal(ex.Message);
                }
            }
            if (null != slLogger)
                slLogger.Trace("<< Save PNG Click");
        }

        private void btSaveAs_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Save as PNG Click");
            if (Directory.Exists(_folderPath))
            {
                sfdGeneSaveImage.InitialDirectory = _folderPath;
            }
            String sDefFile = "Game.png";
            if (null == newGame)
            {

            }
            else
            {
                if (!String.IsNullOrEmpty(newGame.PictureFileName))
                {
                    sDefFile = newGame.PictureFileName;
                    sfdGeneSaveImage.FileName = sDefFile;
                }
                else
                if (!String.IsNullOrEmpty(newGame.Discs))
                {
                    sDefFile = newGame.Discs.Split(',')[0] + ".png";
                    sfdGeneSaveImage.FileName = sDefFile;
                }
            }
            if (DialogResult.OK == sfdGeneSaveImage.ShowDialog())
            {
                String sFileName = sfdGeneSaveImage.FileName;
                try
                {
                    pbCover.Image.Save(sFileName, ImageFormat.Png);

                    _currentFilePathImg = sFileName;
                    lbCurrentPngFile.Text = _currentFilePathImg;
                    btSave.Enabled = true;
                    btPictureReload.Enabled = true;

                    MyProcessHelper pPngQuant = new MyProcessHelper(Application.StartupPath + "\\pngquant\\pngquant.exe", sFileName + " --force --ext .png --verbose");
                    pPngQuant.DoIt();

                    if (null == newGame)
                    {
                        newGame = new ClGameStructure("", true, true);
                    }
                    newGame.PngMissing = false;
                    newGame.setPicture(sFileName, (Image)(new Bitmap(pbCover.Image)));
                }
                catch (Exception ex)
                {
                    if (null != slLogger)
                        slLogger.Fatal(ex.Message);
                }
            }
            // pngquant "test/1.png" "test1/1.png" --force --ext .png --verbose

            if (null != slLogger)
                slLogger.Trace("<< Save as PNG Click");
        }

        private void btScrapeImg_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Scrape image Click");
            try
            {
                using(Bitmap bm = new Bitmap(pbTmp.Image))
                {
                    pbCover.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bm)), 226, 226);
                }
            }
            catch (Exception ex)
            {
                if (null != slLogger)
                    slLogger.Fatal(ex.Message);
            }
            if (null != slLogger)
                slLogger.Trace("<< Scrape image Click");
        }

        private void pbCover_DragDrop(object sender, DragEventArgs e)
        {
            if (null != slLogger)
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
                        if ((Control.ModifierKeys == Keys.Shift))
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
                                        //pbCover.Image = (Image)(new Bitmap(bm));
                                        pbCover.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bm)), 226, 226);
                                    }
                                }
                                else
                                {
                                    pbCover.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bm2)), 226, 226);
                                }
                            }
                        }
                        else
                        {
                            using (Bitmap bmPicture = new Bitmap(sFileList[0]))
                            {
                                pbCover.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bmPicture)), 226, 226);
                            }
                        }
                    }
                    else
                    {
                        if (null != slLogger)
                            slLogger.Error("Extension " + sExt + " not accepted. Dragdrop a file with extension png, bmp, jpg or jpeg.");
                    }
                }
                else
                {
                    FlexibleMessageBox.Show("Only one file for drag&drop operation please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (null != slLogger)
                        slLogger.Error("Dragdrop only one file please.");
                }
            }
            catch (Exception ex)
            {
                if (null != slLogger)
                    slLogger.Fatal(ex.Message);
            }
            finally
            {
                e.Data.SetData(new Object());
            }
            if (null != slLogger)
                slLogger.Trace("<< Dragdrop image");
        }

        private void pbCover_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void btIniReload_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Game.ini Reload Click");
            if (newGame == null)
            {
                //
            }
            else
            if (!newGame.IniMissing)
            {
                tbGeneTitle.Text = newGame.Title;
                tbGeneDiscs.Text = newGame.Discs;
                tbGenePublisher.Text = newGame.Publisher;
                tbGeneDeveloper.Text = newGame.Developer;
                tbGeneAlphaTitle.Text = newGame.Alphatitle;
                try
                {
                    nuGenePlayers.Value = (decimal)int.Parse(newGame.Players);
                }
                catch (Exception ex)
                {
                    //
                }
                try
                {
                    nuGeneYear.Value = (decimal)int.Parse(newGame.Year);
                }
                catch (Exception ex)
                {
                    //
                }
            }
            if (null != slLogger)
                slLogger.Trace("<< Game.ini Reload Click");
        }

        private void btPictureReload_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Picture Reload Click");
            if(newGame == null)
            {
                //
            }
            else
            if(!newGame.PngMissing)
            {
                try
                {
                    using (Bitmap bm = new Bitmap(newGame.PictureFile))
                    {
                        pbCover.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bm)), 226, 226);
                    }
                    _currentFilePathImg = newGame.PictureFileName;
                    lbCurrentPngFile.Text = _currentFilePathImg;
                    btSave.Enabled = true;
                    btPictureReload.Enabled = true;
                }
                catch (Exception ex)
                {
                    if (null != slLogger)
                        slLogger.Fatal(ex.Message);
                }
            }
            if (null != slLogger)
                slLogger.Trace("<< Picture Reload Click");
        }

        private void pbCover_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //MessageBox.Show("picture complete");
        }

        private void pbCover_LocationChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("location changed");
        }

        private void pbTmp_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //
            btScrapeImg.Enabled = true;
            btScrapeImgProportional.Enabled = true;
        }

        private void lbGeneBigData_DoubleClick(object sender, EventArgs e)
        {
            btViewPage_Click(sender, e);
        }

        private void btExchangePublisherEditor_Click(object sender, EventArgs e)
        {
            String s = tbGeneDeveloper.Text;
            tbGeneDeveloper.Text = tbGenePublisher.Text;
            tbGenePublisher.Text = s;
        }

        private void btLinkTGDB_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Game Link Click");

            String sLink = tbHiddenLinkTGDB.Text.Trim();
            if (!String.IsNullOrEmpty(sLink))
            {
                System.Diagnostics.Process.Start("https://thegamesdb.net/game.php?id=" + sLink);
            }
            if (null != slLogger)
                slLogger.Trace("<< Game Link Click");
        }

        private void btViewPageTGDB_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> View webpage Click");
            if (lbGeneBigDataTGDB.SelectedIndex > -1)
            {
                try
                {
                    wbViewer.AllowNavigation = true;
                    Thread.Sleep(_sleepTime);
                    wbViewer.Navigate("about:blank");
                    Thread.Sleep(_sleepTime);
                    btScraper.Enabled = false;
                    btScrapeImg.Enabled = false;
                    btScrapeImgProportional.Enabled = false;
                    ClTGDBGame tgdbGame = (ClTGDBGame)(lbGeneBigDataTGDB.Items[lbGeneBigDataTGDB.SelectedIndex]);
                    wbViewer.AllowNavigation = true;
                    Thread.Sleep(_sleepTime);
                    wbViewer.Navigate("https://thegamesdb.net/game.php?id=" + tgdbGame.Link.Trim());
                    Thread.Sleep(_sleepTime);
                    _lastSite = 2;
                }
                catch (Exception ex)
                {
                    if (null != slLogger)
                        slLogger.Fatal(ex.Message);
                }
            }
            if (null != slLogger)
                slLogger.Trace("<< View webpage Click");
        }

        private void lbGeneBigDataTGDB_DoubleClick(object sender, EventArgs e)
        {
            btViewPageTGDB_Click(sender, e);
        }

        private void lbGeneBigDataTGDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Game Selection changed in search results");
            if (lbGeneBigDataTGDB.SelectedIndex > -1)
            {
                ClTGDBGame tgdbGame = (ClTGDBGame)(lbGeneBigDataTGDB.Items[lbGeneBigDataTGDB.SelectedIndex]);
                String sTitle = tgdbGame.Title.Trim();
                int ipos = sTitle.LastIndexOf("- [");
                if (ipos > -1)
                {
                    sTitle = sTitle.Substring(0, ipos).Trim();
                }
                tbGeneTitle.Text = sTitle.Trim();
                tbHiddenLinkTGDB.Text = tgdbGame.Link.Trim();
                btLinkTGDB.Enabled = true;
                btViewPageTGDB.Enabled = true;
            }
            else
            {
                btLinkTGDB.Enabled = false;
                btViewPageTGDB.Enabled = false;
            }
            if (null != slLogger)
                slLogger.Trace("<< Game Selection changed in search results");
        }

        private void btScrapeImgProportional_Click(object sender, EventArgs e)
        {
            if (null != slLogger)
                slLogger.Trace(">> Scrape image Click");
            try
            {
                using (Bitmap bm2 = new Bitmap(pbTmp.Image))
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
                                gp.Clear(Color.Transparent);
                                int x = 0;
                                int y = 0;
                                if (width1 < width)
                                {
                                    using (Bitmap bm1 = new Bitmap(ClPbHelper.ResizeImage(pbTmp.Image, width1, height)))
                                    {
                                        x = ((width - width1) / 2);
                                        gp.DrawImage(bm1, x, y);
                                    }
                                }
                                else
                                {
                                    using (Bitmap bm1 = new Bitmap(ClPbHelper.ResizeImage(pbTmp.Image, width, height1)))
                                    {
                                        y = ((height - height1) / 2);
                                        gp.DrawImage(bm1, x, y);
                                    }
                                }
                                gp.Flush();
                            }
                            pbCover.Image = (Image)(new Bitmap(bm));
                        }
                    }
                    else
                    {
                        pbCover.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bm2)), 226, 226);
                    }
                }
            }
            catch (Exception ex)
            {
                if (null != slLogger)
                    slLogger.Fatal(ex.Message);
            }
            if (null != slLogger)
                slLogger.Trace("<< Scrape image Click");
        }

        private void Form23_FormClosing(object sender, FormClosingEventArgs e)
        {
            wbViewer.AllowNavigation = true;
            Thread.Sleep(_sleepTime);
            wbViewer.Navigate("about:blank"); // reset page with sleep in order to prevent from crash ??? bad workaround but works... TBD
            Thread.Sleep(_sleepTime);
        }
    }
}
