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
    public partial class Form2 : Form
    {
        String _folderPath;
        SimpleLogger slLogger;
        Dictionary<String, ClPS1Game> dcPs1Games;
        ClGameStructure newGame;

        public Form2(String sFolderPath, SimpleLogger sl, Dictionary<String, ClPS1Game> dcClPS1Games)
        {
            InitializeComponent();
            _folderPath = sFolderPath;
            slLogger = sl;
            dcPs1Games = dcClPS1Games;
            newGame = null;
        }

        public Form2(String sFolderPath, SimpleLogger sl, Dictionary<String, ClPS1Game> dcClPS1Games, ClGameStructure myGame)
        {
            InitializeComponent();
            slLogger = sl;
            dcPs1Games = dcClPS1Games;
            newGame = myGame;
            _folderPath = sFolderPath + "\\" + newGame.FolderIndex + "\\GameData";

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
            }
        }

        private void btLoadIni_Click(object sender, EventArgs e)
        {
            slLogger.Trace(">> Load Game.ini Click");
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
            slLogger.Trace(">> Save Game.ini Click");
            String s1 = ClPbHelper.RemoveQuotes(tbGeneTitle.Text.Trim()); // have to be not empty
            String s2 = ClPbHelper.RemoveQuotes(tbGeneDiscs.Text.Trim()); // have to be not empty
            if ((!String.IsNullOrEmpty(s1)) && (!(String.IsNullOrEmpty(s2))))
            {
                String s3 = ClPbHelper.RemoveQuotes(tbGenePublisher.Text.Trim());
                String s4 = ClPbHelper.RemoveQuotes(tbGeneAlphaTitle.Text.Trim());
                int i1 = (int)(nuGenePlayers.Value);
                int i2 = (int)(nuGeneYear.Value);
                if (Directory.Exists(_folderPath))
                {
                    sfdGeneSaveIni.InitialDirectory = _folderPath;
                }
                if (DialogResult.OK == sfdGeneSaveIni.ShowDialog())
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
                    catch (Exception ex)
                    {
                        slLogger.Fatal(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("You have to enter at least Title and Discs to continue...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            slLogger.Trace("<< Save Game.ini Click");
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
                    MessageBox.Show("You have to enter at least 2 characters (other than space) to search something.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Error. Gamelist not loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            }
            slLogger.Trace("<< Game Selection changed in search results");
        }
    }
}
