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
    public partial class Form8 : Form
    {
        ps1card _memCardLeft;
        ps1card _memCardRight;
        
        //Temp buffer used to store saves
        byte[] tempBuffer = null;
        string tempBufferName = null;

        public Form8(String sFolderPath)
        {
            InitializeComponent();
            _memCardLeft = new ps1card();
            _memCardRight = new ps1card();
            gbLeft.Enabled = false;
            gbRight.Enabled = false;

            rbSelectCombobox.Enabled = false;
            rbSelectFile.Checked = true;

            btLeftToRight.Enabled = false;
            btRightToLeft.Enabled = false;

            cbMemcards.Items.Clear();

            if (null != sFolderPath)
            {
                try
                {
                    List<String> lsFoundMemCards = new List<String>();

                    // .mcd
                    DirectoryInfo[] dirList = new DirectoryInfo(sFolderPath).GetDirectories("memcards", SearchOption.AllDirectories);
                    foreach (DirectoryInfo di in dirList)
                    {
                        FileInfo[] inDirfileList = new DirectoryInfo(di.FullName).GetFiles("card1.mcd", SearchOption.TopDirectoryOnly);
                        foreach (FileInfo fi in inDirfileList)
                        {
                            lsFoundMemCards.Add(fi.FullName);
                        }
                    } // foreach
                    if (lsFoundMemCards.Count > 0)
                    {
                        using (NaturalComparer comparer = new NaturalComparer())
                        {
                            lsFoundMemCards.Sort(comparer);
                        }
                        foreach (String s in lsFoundMemCards)
                        {
                            cbMemcards.Items.Add(s);
                        }
                    }
                    if (cbMemcards.Items.Count > 0)
                    {
                        cbMemcards.SelectedIndex = 0;
                        rbSelectCombobox.Enabled = true;
                        rbSelectCombobox.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    FlexibleMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        //Open a Memory Card from the given filename
        private void openCard(string fileName, int pos)
        {
            //Container for the error message
            string errorMsg = null;
            ps1card _memCard = new ps1card();

            //Try to open card
            errorMsg = _memCard.openMemoryCard(fileName);

            //If card is sucesfully opened proceed further, else destroy it
            if (errorMsg == null)
            {
                switch (pos)
                {
                    case 0:
                        _memCardLeft = _memCard;
                        break;
                    case 1:
                        _memCardRight = _memCard;
                        break;
                }
                //Backup opened card
                //backupMemcard(fileName);

                //Make a new tab for the opened card
                //createTabPage();
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btBrowseMcd_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == ofdLoadMem.ShowDialog())
            {
                String sMemFile = ofdLoadMem.FileName;
                tbMcdFile.Text = sMemFile;
            }
        }

        private void tbMcdFile_DragDrop(object sender, DragEventArgs e)
        {
            String[] sFileList = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            if (sFileList.Length == 1)
            {
                String sExt = Path.GetExtension(sFileList[0]).ToLower();
                List<String> lsAcceptedExt = new List<string>() { ".mcd" };
                if (lsAcceptedExt.IndexOf(sExt) > -1)
                {
                    tbMcdFile.Text = sFileList[0];
                }
            }
        }

        private void tbMcdFile_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void tbMcdFile_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Return) || (e.KeyData == Keys.Enter))
            {
                //
            }
        }

        
        private Bitmap prepareIcons(int slotNumber, ps1card _memCard)
        {
            Bitmap iconBitmap = new Bitmap(48, 16);
            Graphics iconGraphics = Graphics.FromImage(iconBitmap);
            
            iconGraphics.FillRegion(new SolidBrush(Color.FromArgb(0xFF, 0x30, 0x30, 0x30)), new Region(new Rectangle(0, 0, 16, 16)));
            
            //Draw icon
            iconGraphics.DrawImage(_memCard.iconData[slotNumber, 0], 0, 0, 16, 16);

            //Draw flag depending of the region
            switch (_memCard.saveRegion[slotNumber])
            {
                default:        //Formatted save, Corrupted save, Unknown region
                    iconGraphics.DrawImage(Properties.Resources.naflag, 17, 0, 30, 16);
                    break;

                case 0x4142:    //American region
                    iconGraphics.DrawImage(Properties.Resources.amflag, 17, 0, 30, 16);
                    break;

                case 0x4542:    //European region
                    iconGraphics.DrawImage(Properties.Resources.euflag, 17, 0, 30, 16);
                    break;

                case 0x4942:    //Japanese region
                    iconGraphics.DrawImage(Properties.Resources.jpflag, 17, 0, 30, 16);
                    break;
            }

            //Check if save is deleted and color the icon
            if (_memCard.saveType[slotNumber] == 4)
                iconGraphics.FillRegion(new SolidBrush(Color.FromArgb(0xA0, 0xFF, 0xFF, 0xFF)), new Region(new Rectangle(0, 0, 16, 16)));

            iconGraphics.Dispose();

            return iconBitmap;
        }

        private void refreshListView(ImageList iconList, ListView cardList, ps1card _memCard)
        {
            //Temporary FontFamily
            FontFamily tempFontFamily = null;
            
            //Remove all icons from the list
            iconList.Images.Clear();

            //Remove all items from the list
            cardList.Items.Clear();

            //Add linked slot icons to iconList
            iconList.Images.Add(Properties.Resources.linked);
            iconList.Images.Add(Properties.Resources.linked_disabled);

            //Add 15 List items along with icons
            for (int i = 0; i < 15; i++)
            {
                //Add save icons to the list
                iconList.Images.Add(prepareIcons(i, _memCard));

                switch (_memCard.saveType[i])
                {
                    default:        //Corrupted
                        cardList.Items.Add("Corrupted slot");
                        break;

                    case 0:         //Formatted save
                        cardList.Items.Add("Free slot");
                        break;

                    case 1:         //Initial save
                    case 4:         //Deleted initial save
                        cardList.Items.Add(_memCard.saveName[i, 0]);
                        cardList.Items[i].SubItems.Add(_memCard.saveProdCode[i]);
                        cardList.Items[i].SubItems.Add(_memCard.saveIdentifier[i]);
                        cardList.Items[i].ImageIndex = i + 2;      //Skip two linked slot icons
                        break;

                    case 2:         //Middle link
                        cardList.Items.Add("Linked slot (middle link)");
                        cardList.Items[i].ImageIndex = 0;
                        break;

                    case 5:         //Middle link deleted
                        cardList.Items.Add("Linked slot (middle link)");
                        cardList.Items[i].ImageIndex = 1;
                        break;

                    case 3:         //End link
                        cardList.Items.Add("Linked slot (end link)");
                        cardList.Items[i].ImageIndex = 0;
                        break;

                    case 6:         //End link deleted
                        cardList.Items.Add("Linked slot (end link)");
                        cardList.Items[i].ImageIndex = 1;
                        break;

                }
            }
        }
        
        //Copy save selected save from Memory Card
        private bool copySave(ImageList iconList, ListView cardList, int pos)
        {
            bool bResult = false;
            ps1card _memCard = null;
            switch(pos)
            {
                case 0:
                    _memCard = _memCardLeft;
                    break;
                case 1:
                    _memCard = _memCardRight;
                    break;
            }
           
            //Check if there are any cards available
            if (_memCard != null)
            {

                //Check if a save is selected
                if (cardList.SelectedIndices.Count == 0) return bResult;

                int slotNumber = cardList.SelectedIndices[0];
                string saveName = _memCard.saveName[slotNumber, 0];

                //Check the save type
                switch (_memCard.saveType[slotNumber])
                {
                    default:
                        break;

                    case 1:         //Initial save
                    case 4:         //Deleted initial
                        tempBuffer = _memCard.getSaveBytes(slotNumber);
                        tempBufferName = _memCard.saveName[slotNumber, 0];
                        bResult = true;
                        break;

                    case 2:
                    case 3:
                    case 5:
                    case 6:
                        FlexibleMessageBox.Show("The selected slot is linked. Select the initial save slot to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
            }
            return bResult;
        }

        //Format selected save
        private void formatSave(ImageList iconList, ListView cardList, int pos)
        {
            ps1card _memCard = null;
            switch (pos)
            {
                case 0:
                    _memCard = _memCardLeft;
                    break;
                case 1:
                    _memCard = _memCardRight;
                    break;
            }
            //Check if there are any cards available
            if (_memCard != null)
            {
                if (cardList.SelectedIndices.Count == 0) return;

                int slotNumber = cardList.SelectedIndices[0];

                //Check the save type
                switch (_memCard.saveType[slotNumber])
                {
                    default:    //Slot is either initial, deleted initial or corrupted so it can be safetly formatted
                        if (DialogResult.Yes == FlexibleMessageBox.Show("Formatted slots cannot be restored.\nDo you want to proceed with this operation?", "Removing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            _memCard.formatSave(slotNumber);
                            refreshListView(iconList, cardList, _memCard);
                        }
                        break;

                    case 2:
                    case 3:
                    case 5:
                    case 6:
                        FlexibleMessageBox.Show("The selected slot is linked. Select the initial save slot to proceed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
            }
        }

        //Paste save to Memory Card
        private void pasteSave(ImageList iconList, ListView cardList, int pos)
        {
            ps1card _memCard = null;
            switch (pos)
            {
                case 0:
                    _memCard = _memCardLeft;
                    break;
                case 1:
                    _memCard = _memCardRight;
                    break;
            }
            //Check if there are any cards available
            if (_memCard != null)
            {

                int slotNumber = 0;
                int requiredSlots = 0;

                //Check if temp buffer contains anything
                if (tempBuffer != null)
                {
                    //Check if the slot to paste the save on is free
                    while ((slotNumber < 15 ) && (_memCard.saveType[slotNumber] != 0))
                    {
                        slotNumber++;
                    }
                    if ((slotNumber < 15) && (_memCard.saveType[slotNumber] == 0))
                    {
                        if (_memCard.setSaveBytes(slotNumber, tempBuffer, out requiredSlots))
                        {
                            refreshListView(iconList, cardList, _memCard);
                        }
                        else
                        {
                            FlexibleMessageBox.Show("To complete this operation " + requiredSlots.ToString() + " consecutive free slots are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        FlexibleMessageBox.Show("Not available empty slot.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    FlexibleMessageBox.Show("Temp buffer is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        
        private void btLeftToRight_Click(object sender, EventArgs e)
        {
            if (lvCardListLeft.SelectedItems.Count > 0)
            {
                if (copySave(iconListLeft, lvCardListLeft, 0))
                    pasteSave(iconListRight, lvCardListRight, 1);
            }
            else
            {
                FlexibleMessageBox.Show("Select a slot on the left-side first please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btRightToLeft_Click(object sender, EventArgs e)
        {
            if (lvCardListRight.SelectedItems.Count > 0)
            {
                if (copySave(iconListRight, lvCardListRight, 1))
                pasteSave(iconListLeft, lvCardListLeft, 0);
            }
            else
            {
                FlexibleMessageBox.Show("Select a slot on the right-side first please.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
}

        private void btSaveasRight_Click(object sender, EventArgs e)
        {
            int ipos = lbRightMemCardFile.Text.LastIndexOf("\\");
            if (ipos > -1)
            {
                String sPath = lbRightMemCardFile.Text.Substring(0, ipos);
                if (Directory.Exists(sPath))
                {
                    sfdSaveMem.InitialDirectory = sPath;
                }
            }
            if(DialogResult.OK == sfdSaveMem.ShowDialog())
            {
                _memCardRight.saveMemoryCard(sfdSaveMem.FileName, _memCardRight.cardType);
            }
        }

        private void btSaveRight_Click(object sender, EventArgs e)
        {
            //saveMemoryCard(listIndex, PScard[listIndex].cardLocation, PScard[listIndex].cardType);
            _memCardRight.saveMemoryCard(lbRightMemCardFile.Text, _memCardRight.cardType);
        }

        private void btSaveLeft_Click(object sender, EventArgs e)
        {
            _memCardLeft.saveMemoryCard(lbLeftMemCardFile.Text, _memCardLeft.cardType);
        }

        private void btSaveasLeft_Click(object sender, EventArgs e)
        {
            int ipos = lbLeftMemCardFile.Text.LastIndexOf("\\");
            if (ipos > -1)
            {
                String sPath = lbLeftMemCardFile.Text.Substring(0, ipos);
                if (Directory.Exists(sPath))
                {
                    sfdSaveMem.InitialDirectory = sPath;
                }
            }
            if (DialogResult.OK == sfdSaveMem.ShowDialog())
            {
                _memCardLeft.saveMemoryCard(sfdSaveMem.FileName, _memCardLeft.cardType);
            }
        }

        private void lvCardListRight_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvCardListRight.SelectedItems.Count > 0)
            {
                if (e.KeyData == Keys.Delete)
                {
                    formatSave(iconListRight, lvCardListRight, 1);
                }
            }
        }

        private void lvCardListLeft_KeyDown(object sender, KeyEventArgs e)
        {
            if (lvCardListLeft.SelectedItems.Count > 0)
            {
                if (e.KeyData == Keys.Delete)
                {
                    formatSave(iconListLeft, lvCardListLeft, 0);
                }
            }
        }

        private void lklbMemCardRex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ShendoXT/memcardrex");
        }

        private void rbManager_CheckedChanged(object sender, EventArgs e)
        {
            if(rbSelectFile.Checked)
            {
                tbMcdFile.Enabled = true;
                btBrowseMcd.Enabled = true;
                cbMemcards.Enabled = false;
            }
            else
            if(rbSelectCombobox.Checked)
            {
                tbMcdFile.Enabled = false;
                btBrowseMcd.Enabled = false;
                cbMemcards.Enabled = true;
            }
        }

        private void btOpenFileRight_Click(object sender, EventArgs e)
        {
            String sFilename = String.Empty;
            if (rbSelectFile.Checked)
            {
                sFilename = tbMcdFile.Text.Trim();
            }
            else
            if (rbSelectCombobox.Checked)
            {
                if (cbMemcards.SelectedIndex > -1)
                {
                    sFilename = cbMemcards.Items[cbMemcards.SelectedIndex].ToString();
                }
            }
            try
            {
                openCard(sFilename, 1);
                lbRightMemCardFile.Text = sFilename;
                gbRight.Enabled = true;
                refreshListView(iconListRight, lvCardListRight, _memCardRight); //TODO
            }
            catch (Exception ex)
            {
                gbRight.Enabled = false;
            }
            if (gbLeft.Enabled && gbRight.Enabled)
            {
                btLeftToRight.Enabled = true;
                btRightToLeft.Enabled = true;
            }
            else
            {
                btLeftToRight.Enabled = false;
                btRightToLeft.Enabled = false;
            }
        }

        private void btOpenFileLeft_Click(object sender, EventArgs e)
        {
            String sFilename = String.Empty;
            if (rbSelectFile.Checked)
            {
                sFilename = tbMcdFile.Text.Trim();
            }
            else
            if (rbSelectCombobox.Checked)
            {
                if (cbMemcards.SelectedIndex > -1)
                {
                    sFilename = cbMemcards.Items[cbMemcards.SelectedIndex].ToString();
                }
            }
            try
            {
                openCard(sFilename, 0);
                lbLeftMemCardFile.Text = sFilename;
                gbLeft.Enabled = true;
                refreshListView(iconListLeft, lvCardListLeft, _memCardLeft); //TODO
            }
            catch (Exception ex)
            {
                gbLeft.Enabled = false;
            }
            if(gbLeft.Enabled && gbRight.Enabled)
            {
                btLeftToRight.Enabled = true;
                btRightToLeft.Enabled = true;
            }
            else
            {
                btLeftToRight.Enabled = false;
                btRightToLeft.Enabled = false;
            }
        }
    }
}
