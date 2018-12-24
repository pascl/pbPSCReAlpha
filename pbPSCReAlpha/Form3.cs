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
    public partial class Form3 : Form
    {
        String _folderPath;
        SimpleLogger slLogger;
        Dictionary<String, ClPS1Game> dcPs1Games;
        ClGameStructure newGame;

        public Form3(String sFolderPath, SimpleLogger sl, Dictionary<String, ClPS1Game> dcClPS1Games)
        {
            InitializeComponent();
            _folderPath = sFolderPath;
            slLogger = sl;
            dcPs1Games = dcClPS1Games;
            newGame = null;
        }

        public Form3(String sFolderPath, SimpleLogger sl, Dictionary<String, ClPS1Game> dcClPS1Games, ClGameStructure myGame)
        {
            InitializeComponent();
            slLogger = sl;
            dcPs1Games = dcClPS1Games;
            newGame = myGame;
            _folderPath = sFolderPath + "\\" + newGame.FolderIndex + "\\GameData";

            if (!newGame.PngMissing)
            {
                try
                {
                    pbCover.Image = (Image)(new Bitmap(newGame.PictureFile));
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
            }
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
                    Bitmap bmPicture = new Bitmap(sFileName);
                    pbCover.Image = (Image)(new Bitmap(bmPicture));
                    bmPicture.Dispose();
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
            if (Directory.Exists(_folderPath))
            {
                sfdGeneSaveImage.InitialDirectory = _folderPath;
            }
            String sDefFile = "Game.png";
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
            if (DialogResult.OK == sfdGeneSaveImage.ShowDialog())
            {
                String sFileName = sfdGeneSaveImage.FileName;
                pbCover.Image.Save(sFileName, ImageFormat.Png);

                MyProcessHelper pPngQuant = new MyProcessHelper(Application.StartupPath + "\\pngquant\\pngquant.exe", sFileName + " --force --ext .png --verbose");
                pPngQuant.DoIt();
            }
            // pngquant "test/1.png" "test1/1.png" --force --ext .png --verbose
            
            slLogger.Trace("<< Save PNG Click");
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btCompress_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Compress all PNG Click");
            String sList = String.Empty;
            String sFolderPath = String.Empty;
            if (newGame != null)
            {
                sFolderPath = _folderPath.Substring(0, _folderPath.LastIndexOf("\\" + newGame.FolderIndex + "\\GameData"));
            }
            else
            {
                sFolderPath = _folderPath;
            }
            var fileList = new DirectoryInfo(sFolderPath).GetFiles("*.png", SearchOption.AllDirectories);
            foreach (FileInfo fi in fileList)
            {
                sList += " \"" + fi.FullName + "\"";
            }
            // pngquant "test/1.png" "test1/1.png" --force --ext .png --verbose
            MyProcessHelper pPngQuant = new MyProcessHelper(Application.StartupPath + "\\pngquant\\pngquant.exe", sList + " --force --ext .png --verbose");
            pPngQuant.DoIt();
            slLogger.Trace("<< Compress all PNG Click");
        }
    }
}
