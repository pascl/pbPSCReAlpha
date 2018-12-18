﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace pbPSCReAlpha
{
    public partial class Form1 : Form
    {
        Dictionary<String, String> dcPs1Games;
        String sSeparator = "/##/";
        public Form1()
        {
            InitializeComponent();
            dcPs1Games = new Dictionary<string, string>();
            try
            {
                using (XmlTextReader xmlreader = new XmlTextReader(Application.StartupPath + "\\" + "ps1games.xml"))
                {
                    String mykey = String.Empty;
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
                                    }
                                }
                                break;
                            case XmlNodeType.Text:
                                // Console.WriteLine(xmlreader.Value);
                                myvalue = xmlreader.Value;
                                if (!dcPs1Games.ContainsKey(mykey))
                                {
                                    dcPs1Games.Add(mykey, myvalue);
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
                tbLog.AppendText(ex.Message + "\n");
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
                tbLog.AppendText(ex.Message + "\n");
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
                        tbLog.AppendText(ex.Message + "\n");
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
                    tbLog.AppendText(ex.Message + "\n");
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
            if (dcPs1Games.Count > 0)
            {
                if (s.Length > 2)
                {
                    foreach (KeyValuePair<string, string> pair in dcPs1Games)
                    {
                        if (pair.Value.ToUpper().Contains(s))
                        {
                            lbGeneBigData.Items.Add(pair.Value + " " + sSeparator + " " + pair.Key);
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
            //
            String[] sp = (lbGeneBigData.Items[lbGeneBigData.SelectedIndex].ToString()).Split(new String[] {sSeparator}, StringSplitOptions.None);
            if (sp.Length > 1)
            {
                tbGeneTitle.Text = sp[0].Trim();
                tbGeneDiscs.Text = sp[1].Trim();
            }
        }
    }
}
