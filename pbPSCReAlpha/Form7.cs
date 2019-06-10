using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbPSCReAlpha
{
    public partial class Form7 : Form
    {
        Dictionary<String, ClPS1Game> dcPs1Games;

        public Form7(Dictionary<string, ClPS1Game> ps1games)
        {
            InitializeComponent();

            dcPs1Games = ps1games;
        }

        private void btBinFindSerial_Click(object sender, EventArgs e)
        {
            lbResultBinFindSerial.Text = "Running...";
            tbSerialFound.Text = String.Empty;
            lbGameFound.Text = String.Empty;

            try
            { 
                using (FileStream fs = new FileStream(tbBinFile.Text, FileMode.Open))
                {
                    List<String> lsSerialStart = new List<string>() { "SCUS", "SLUS", "SCES", "SLES", "SCPS", "SLPS", "SCPM", "SLPM"};
                    String sInfoSearch1 = "CD001";
                    String sInfoSearch2 = "PLAYSTATION";
                    long len1 = fs.Length;
                    int len2 = 20;
                    bool bFound = false;
                    bool bFound2 = false;
                    byte[] bSearchSerial = new byte[len2];
                    byte[] bSearchInfo = new byte[53];
                    String s = String.Empty;
                    String s1 = String.Empty;
                    for (int index=0;index<len1;index+= len2)
                    {
                        fs.Seek(index, SeekOrigin.Begin);
                        fs.Read(bSearchSerial, 0, len2);
                        for(int i=0;i< len2; i++)
                        {
                            if((!bFound) && (bSearchSerial[i] == (byte)('S')))
                            {
                                index += i;
                                fs.Seek(index, SeekOrigin.Begin);
                                fs.Read(bSearchSerial, 0, len2);
                                s = Encoding.UTF8.GetString(bSearchSerial);
                                s = s.Replace(".", "").Replace("_", "").Replace("-", "").Trim();
                                if (s.Length >= 9)
                                {
                                    if (lsSerialStart.IndexOf(s.Substring(0, 4)) > -1)
                                    {
                                        bFound = true;
                                        s = (s.Substring(0, 4) + "-" + (s.Substring(4, 6)).Replace("P", "").Substring(0, 5)).ToUpper();
                                    }
                                }
                            }
                            else
                            if ((!bFound2) && (bSearchSerial[i] == (byte)('C')) && (i < len1-1) && (bSearchSerial[1+i] == (byte)('D')))
                            {
                                index += i;
                                fs.Seek(index, SeekOrigin.Begin);
                                fs.Read(bSearchSerial, 0, 5);
                                bSearchSerial[5] = 0;
                                s = Encoding.UTF8.GetString(bSearchSerial);
                                if (s.IndexOf(sInfoSearch1) == 0)
                                {
                                    index += 7;
                                    fs.Seek(index, SeekOrigin.Begin);
                                    fs.Read(bSearchSerial, 0, 11);
                                    bSearchSerial[11] = 0;
                                    s = Encoding.UTF8.GetString(bSearchSerial);
                                    if (s.IndexOf(sInfoSearch2) == 0)
                                    {
                                        index += 11;
                                        fs.Seek(index, SeekOrigin.Begin);
                                        fs.Read(bSearchInfo, 0, 53);
                                        s1 = Encoding.UTF8.GetString(bSearchInfo);
                                        bFound2 = true;
                                    }
                                }
                            }
                            if (bFound && bFound2)
                            {
                                break;
                            }
                        }
                        if (bFound && bFound2)
                        {
                            break;
                        }
                    }
                    if (bFound)
                    {
                        lbResultBinFindSerial.Text = String.Empty; // "Serial found ->";
                        tbSerialFound.Text = s;
                        if(!String.IsNullOrEmpty(s1))
                        {
                            lbGameInfoFound.Text = s1.Trim();
                        }
                        else
                        {
                            lbGameInfoFound.Text = String.Empty;
                        }
                        foreach (KeyValuePair<string, ClPS1Game> pair in dcPs1Games)
                        {
                            ClPS1Game c1 = pair.Value;
                            if (c1.Serial.ToUpper().Contains(s))
                            {
                                lbGameFound.Text = c1.Title;
                                break;
                            }
                        }
                    }
                    else
                    {
                        lbResultBinFindSerial.Text = "No serial found.";
                        tbSerialFound.Text = String.Empty;
                        lbGameFound.Text = String.Empty;
                    }
                }
            }
            catch(Exception ex)
            {
                lbResultBinFindSerial.Text = ex.Message;
                tbSerialFound.Text = String.Empty;
            }
        }

        private void btBrowseBin_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ofdLoadBin.ShowDialog())
            {
                String sBinFile = ofdLoadBin.FileName;
                tbBinFile.Text = sBinFile;
            }
        }

        private void tbBinFile_DragDrop(object sender, DragEventArgs e)
        {
            String[] sFileList = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            if (sFileList.Length == 1)
            {
                String sExt = Path.GetExtension(sFileList[0]).ToLower();
                List<String> lsAcceptedExt = new List<string>() { ".bin" };
                if (lsAcceptedExt.IndexOf(sExt) > -1)
                {
                    tbBinFile.Text = sFileList[0];
                }
            }
        }

        private void tbBinFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void tbBinFile_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Return) || (e.KeyData == Keys.Enter))
            {
                btBinFindSerial_Click(sender, e);
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
