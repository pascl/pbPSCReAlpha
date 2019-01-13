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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        String _folderPath;
        SimpleLogger slLogger;
        ClGameStructure newGame;

        public Form4(String sFolderPath, SimpleLogger sl)
        {
            InitializeComponent();
            _folderPath = sFolderPath;
            slLogger = sl;
            newGame = null;
        }

        public Form4(String sFolderPath, SimpleLogger sl, ClGameStructure myGame)
        {
            InitializeComponent();
            slLogger = sl;
            newGame = myGame;
            _folderPath = sFolderPath + "\\" + newGame.FolderIndex + "\\GameData";

            if (!newGame.CueMissing)
            {
                int cueCount = 0;

                foreach(String s in newGame.Filenames)
                {
                    if(s.EndsWith(".cue"))
                    {
                        cueCount++;
                        GroupBox gb = new GroupBox();
                        gb.Text = s;
                        gb.Width = 400;
                        gb.Height = 250;
                        gb.Parent = flpCueFiles;


                        TextBox tb = new TextBox();
                        tb.Multiline = true;
                        tb.Parent = gb;
                        tb.Dock = DockStyle.Top;
                        tb.Height = 200;
                        tb.ScrollBars = ScrollBars.Both;
                        //tb.ReadOnly = true;

                        if(File.Exists(_folderPath + "\\" + s))
                        {
                            using (StreamReader sr = new StreamReader(_folderPath + "\\" + s))
                            {
                                string sline = String.Empty;
                                while ((sline = sr.ReadLine()) != null)
                                {
                                    tb.AppendText(sline + Environment.NewLine);
                                }
                            }
                        }

                        Button btSave = new Button();
                        btSave.Text = "Save";
                        btSave.Parent = gb;
                        btSave.Top = 220;
                        btSave.Left = 4;
                        //btSave.Enabled = false;
                        btSave.Tag = (object)(gb);
                        btSave.Click += cueSave;
                    }
                }
                if(cueCount > 1)
                {
                    this.Width = 850;
                }
            }
        }

        private void cueSave(object sender, EventArgs e)
        {
            slLogger.Trace(">> Save cue Click");
            Button bt = (Button)(sender);
            GroupBox gb = (GroupBox)(bt.Tag);
            TextBox tb = null;

            try
            {

                if (gb.HasChildren)
                {
                    foreach (Control ct in gb.Controls)
                    {
                        if (ct is TextBox)
                        {
                            tb = (TextBox)ct;
                        }
                    }
                    if (tb != null)
                    {
                        slLogger.Debug("Saving " + _folderPath + "\\" + gb.Text);
                        using (StreamWriter sw = new StreamWriter(_folderPath + "\\" + gb.Text))
                        {
                            sw.WriteLine(tb.Text);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
            }
            slLogger.Trace("<< Save cue Click");
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
