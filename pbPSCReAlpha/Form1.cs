using System;
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

namespace pbPSCReAlpha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            /*List<String> testItems;
            using (NaturalComparer comparer = new NaturalComparer())
            {
                testItems.Sort(comparer);
            }*/
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
                    if (((bStartAt21) && (index >= 21)) || (!bStartAt21))
                    {
                        using (StreamReader sr = new StreamReader(fi.FullName))
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null)
                            {
                                if (s.StartsWith("Title="))
                                {
                                    sTitle = s.Substring(6);
                                    tbLog.AppendText("Found: " + s1 + " " + sTitle + "\n");
                                    lsTitles.Add(sTitle);
                                    dcTitleIndexes.Add(sTitle, index);
                                }
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
    }
}
