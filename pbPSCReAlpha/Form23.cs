using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbPSCReAlpha
{
    public partial class Form23 : Form
    {
        String _folderPath;
        SimpleLogger slLogger;
        Dictionary<String, ClPS1Game> dcPs1Games;
        ClGameStructure newGame;
        String _currentFilePathIni;
        String _currentFilePathImg;
        String _docHtmlStr;
        ClVersionHelper _versionBS;

        public Form23(String sFolderPath, SimpleLogger sl, Dictionary<String, ClPS1Game> dcClPS1Games, ClVersionHelper cvh)
        {
            InitializeComponent();
            _folderPath = sFolderPath;
            slLogger = sl;
            dcPs1Games = dcClPS1Games;
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

        public Form23(String sFolderPath, SimpleLogger sl, Dictionary<String, ClPS1Game> dcClPS1Games, ClVersionHelper cvh, ClGameStructure myGame)
        {
            InitializeComponent();
            slLogger = sl;
            dcPs1Games = dcClPS1Games;
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
                    slLogger.Fatal(ex.Message);
                }
            }
            pbCover.AllowDrop = true;
        }

        private void btLoadIni_Click(object sender, EventArgs e)
        {
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
                    slLogger.Fatal(ex.Message);
                }
            }
            slLogger.Trace("<< Load Game.ini Click");
        }

        private void btGenerateIni_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Save as Game.ini Click");
            String s1 = ClPbHelper.RemoveQuotes(tbGeneTitle.Text); // have to be not empty
            String s2 = ClPbHelper.RemoveQuotes(tbGeneDiscs.Text); // have to be not empty
            if ((!String.IsNullOrEmpty(s1)) && (!(String.IsNullOrEmpty(s2))))
            {
                String s3 = ClPbHelper.RemoveQuotes(tbGenePublisher.Text);
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
                        dcTosave.Add("alphatitle", s4);
                        dcTosave.Add("players", i1.ToString());
                        dcTosave.Add("year", i2.ToString());
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
                        slLogger.Fatal(ex.Message);
                    }
                }
            }
            else
            {
                FlexibleMessageBox.Show("You have to enter at least Title and Discs to continue...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< Save as Game.ini Click");
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btGeneSearch_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Search Game Click");
            String s = tbGeneSearchText.Text.Trim().ToUpper();
            lbGeneBigData.Items.Clear();
            lbGeneBigData.DisplayMember = "DisplayTitle";
            tbHiddenLink.Text = "";
            btScraper.Enabled = false;
            btScrapeImg.Enabled = false;
            btViewPage.Enabled = false;
            btLink.Enabled = false;
            _docHtmlStr = String.Empty;
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
                    FlexibleMessageBox.Show("You have to enter at least 2 characters (other than space) to search something.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                FlexibleMessageBox.Show("Error. Gamelist not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< Search Game Click");
        }

        private void btLink_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Game Link Click");

            String sLink = tbHiddenLink.Text.Trim();
            if (!String.IsNullOrEmpty(sLink))
            {
                System.Diagnostics.Process.Start("http://psxdatacenter.com/" + sLink);
            }
            slLogger.Trace("<< Game Link Click");
        }

        private void lbGeneBigData_SelectedIndexChanged(object sender, EventArgs e)
        {
            slLogger.Trace(">> Game Selection changed in search results");
            if (lbGeneBigData.SelectedIndex > -1)
            {
                ClPS1Game psGame = (ClPS1Game)(lbGeneBigData.Items[lbGeneBigData.SelectedIndex]);
                tbGeneTitle.Text = psGame.Title.Trim();
                tbGeneDiscs.Text = psGame.Serial.Trim();
                tbHiddenLink.Text = psGame.Link.Trim();
                btLink.Enabled = true;
                btViewPage.Enabled = true;
            }
            else
            {
                btLink.Enabled = false;
                btViewPage.Enabled = false;
            }
            slLogger.Trace("<< Game Selection changed in search results");
        }

        private void btSaveIni_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Save Game.ini Click");
            String s1 = ClPbHelper.RemoveQuotes(tbGeneTitle.Text); // have to be not empty
            String s2 = ClPbHelper.RemoveQuotes(tbGeneDiscs.Text); // have to be not empty
            if ((!String.IsNullOrEmpty(s1)) && (!(String.IsNullOrEmpty(s2))))
            {
                String s3 = ClPbHelper.RemoveQuotes(tbGenePublisher.Text);
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
                        dcTosave.Add("alphatitle", s4);
                        dcTosave.Add("players", i1.ToString());
                        dcTosave.Add("year", i2.ToString());
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
                        slLogger.Fatal(ex.Message);
                    }
                }
            }
            else
            {
                FlexibleMessageBox.Show("You have to enter at least Title and Discs to continue...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
            slLogger.Trace(">> Copy in alphatitle Click");
            tbGeneAlphaTitle.Text = tbGeneTitle.Text;
            slLogger.Trace("<< Copy in alphatitle Click");
        }

        private void btViewPage_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> View webpage Click");
            if (lbGeneBigData.SelectedIndex > -1)
            {
                try
                {
                    wbViewer.Navigate("about:blank");
                    btScraper.Enabled = false;
                    btScrapeImg.Enabled = false;
                    ClPS1Game psGame = (ClPS1Game)(lbGeneBigData.Items[lbGeneBigData.SelectedIndex]);
                    //wbViewer.Url = new Uri("http://psxdatacenter.com/" + psGame.Link.Trim());
                    wbViewer.Navigate("http://psxdatacenter.com/" + psGame.Link.Trim());
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
            }
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
                    break;
                }
            }
        }

        private void btScraper_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Scrape webpage Click");
            ClGameScraper clgs = new ClGameScraper(_docHtmlStr);

            tbGenePublisher.Text = clgs.Publisher;
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
            slLogger.Trace("<< Scrape webpage Click");
        }

        private void btReloadTitleDiscs_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Reload title and discs Click");
            if (!newGame.IniMissing)
            {
                tbGeneTitle.Text = newGame.Title;
                tbGeneDiscs.Text = newGame.Discs;
            }
            slLogger.Trace("<< Reload title and discs Click");
        }

        private void btLoad_Click(object sender, EventArgs e)
        {
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
                    slLogger.Fatal(ex.Message);
                }
            }
            slLogger.Trace("<< Load image Click");
        }

        private void btSave_Click(object sender, EventArgs e)
        {
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
                    slLogger.Fatal(ex.Message);
                }
            }
            slLogger.Trace("<< Save PNG Click");
        }

        private void btSaveAs_Click(object sender, EventArgs e)
        {
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
                    slLogger.Fatal(ex.Message);
                }
            }
            // pngquant "test/1.png" "test1/1.png" --force --ext .png --verbose

            slLogger.Trace("<< Save as PNG Click");
        }

        private void btScrapeImg_Click(object sender, EventArgs e)
        {
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
                slLogger.Fatal(ex.Message);
            }
            slLogger.Trace("<< Scrape image Click");
            
        }

        private void pbCover_DragDrop(object sender, DragEventArgs e)
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
                        using (Bitmap bmPicture = new Bitmap(sFileList[0]))
                        {
                            pbCover.Image = ClPbHelper.ResizeImage((Image)(new Bitmap(bmPicture)), 226, 226);
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

        private void pbCover_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void btIniReload_Click(object sender, EventArgs e)
        {
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
            slLogger.Trace("<< Game.ini Reload Click");
        }

        private void btPictureReload_Click(object sender, EventArgs e)
        {
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
                    slLogger.Fatal(ex.Message);
                }
            }
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
        }
    }
}
