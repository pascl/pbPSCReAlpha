using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pbPSCReAlpha
{
    public partial class Form9 : Form
    {
        SimpleLogger slLogger;
        int m_SelectionDBCreation;
        int m_bsversion;
        List<ClGameStructure> m_lcgs;
        String m_sFolderPath;
        ClVersionHelper m_cvh;
        Form1 m_frmParent;

        public Form9(List<ClGameStructure> lcgs, String sFolderPath, int bleemsyncVersion, ClVersionHelper cvh, SimpleLogger sl, Form1 frm)
        {
            InitializeComponent();
            slLogger = sl;
            m_SelectionDBCreation = 1;
            m_bsversion = bleemsyncVersion;
            m_lcgs = lcgs;
            m_sFolderPath = sFolderPath;
            m_cvh = cvh;
            m_frmParent = frm;
            int iMaxGames = Properties.Settings.Default.iMaxGamesPerFolder;
            if ((iMaxGames >= nudMaxGamesPerFolder.Minimum) && (iMaxGames <= nudMaxGamesPerFolder.Maximum))
            {
                nudMaxGamesPerFolder.Value = (decimal)(iMaxGames);
            }
            else
            {
                Properties.Settings.Default.iMaxGamesPerFolder = 40;
                nudMaxGamesPerFolder.Value = (decimal)(40);
            }
            manageRadioButton();
        }

        private void addInListOrAnother(bool bSelectList, String sToAdd, List<String> lsIfTrue, List<String> lsIfFalse)
        {
            if(bSelectList)
            {
                lsIfTrue.Add(sToAdd);
            }
            else
            {
                lsIfFalse.Add(sToAdd);
            }
        }

        private void btGenerateDB_Click(object sender, EventArgs e)
        {
            List<String> lsFilesOk = new List<string>();
            List<String> lsFilesKo = new List<string>();
            bool bOkForDB = false;
            try
            {
                if (0 == m_lcgs.Count)
                {
                    List<ClGameStructure> lcgs = new List<ClGameStructure>();
                    ClDBManager cdbm1 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "empty.db");
                    addInListOrAnother(cdbm1.BDone, "empty.db", lsFilesOk, lsFilesKo);
                    bOkForDB = cdbm1.BDone;
                    ClDBManager cdbm = new ClDBManager(m_lcgs, m_sFolderPath, m_bsversion, m_cvh, slLogger);
                    addInListOrAnother(cdbm.BDone, "regional.db", lsFilesOk, lsFilesKo);
                    bOkForDB &= cdbm.BDone;
                }
                else
                {
                    int iInternalGamesCount = 20; // in a variable, in case changes one day
                    int iCurrentIndex = 0;
                    switch (m_SelectionDBCreation)
                    {
                        case 2:
                            {
                                int iMaxPage = (int)(nudMaxGamesPerFolder.Value);
                                int iCountPageWanted = (int)(Math.Ceiling((decimal)((float)(iInternalGamesCount + m_lcgs.Count) / (float)iMaxPage)));
                                int iFinalCountPerPage = (int)(Math.Ceiling((decimal)((float)(iInternalGamesCount + m_lcgs.Count) / (float)iCountPageWanted)));
                                iFinalCountPerPage = Math.Max(iFinalCountPerPage, 20); // not less than 20
                                for (int i = 0; i < iCountPageWanted; i++)
                                {
                                    int iNbGames = iFinalCountPerPage;
                                    if (0 == i)
                                    {
                                        iNbGames -= iInternalGamesCount;
                                        if (iNbGames < 0)
                                        {
                                            iNbGames = 0;
                                        }
                                    }
                                    List<ClGameStructure> lcgs = new List<ClGameStructure>();
                                    ClDBManager cdbm20 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "empty.db");
                                    addInListOrAnother(cdbm20.BDone, "empty.db", lsFilesOk, lsFilesKo);
                                    bOkForDB = cdbm20.BDone;
                                    for (int j = iCurrentIndex; j < Math.Min((iCurrentIndex + iNbGames), m_lcgs.Count); j++)
                                    {
                                        lcgs.Add(m_lcgs[j]);
                                    }
                                    if (0 == i)
                                    {
                                        ClDBManager cdbm2 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional.db", iCurrentIndex);
                                        addInListOrAnother(cdbm2.BDone, "regional.db", lsFilesOk, lsFilesKo);
                                        bOkForDB &= cdbm2.BDone;
                                    }
                                    else
                                    {
                                        ClDBManager cdbm2 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional" + i.ToString() + ".db", iCurrentIndex);
                                        addInListOrAnother(cdbm2.BDone, "regional" + i.ToString() + ".db", lsFilesOk, lsFilesKo);
                                        bOkForDB &= cdbm2.BDone;
                                    }
                                    iCurrentIndex += iNbGames;
                                }
                            }
                            break;
                        case 3:
                            {
                                int iMaxPage = (int)(nudMaxGamesPerFolder.Value);
                                int iCountPageWanted = (int)(Math.Ceiling((decimal)((float)(m_lcgs.Count) / (float)(iMaxPage))));
                                int iFinalCountPerPage = (int)(Math.Ceiling((decimal)((float)(m_lcgs.Count) / (float)(iCountPageWanted))));
                                iFinalCountPerPage = Math.Max(iFinalCountPerPage, 20); // not less than 20
                                iCountPageWanted++;
                                for (int i = 0; i < iCountPageWanted; i++)
                                {
                                    int iNbGames = iFinalCountPerPage;
                                    List<ClGameStructure> lcgs = new List<ClGameStructure>();
                                    if (0 == i)
                                    {
                                        ClDBManager cdbm30 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "empty.db");
                                        addInListOrAnother(cdbm30.BDone, "empty.db", lsFilesOk, lsFilesKo);
                                        bOkForDB = cdbm30.BDone;
                                        ClDBManager cdbm31 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional.db");
                                        addInListOrAnother(cdbm31.BDone, "regional.db", lsFilesOk, lsFilesKo);
                                        bOkForDB &= cdbm31.BDone;
                                    }
                                    else
                                    {
                                        for (int j = iCurrentIndex; j < Math.Min((iCurrentIndex + iNbGames), m_lcgs.Count); j++)
                                        {
                                            lcgs.Add(m_lcgs[j]);
                                        }
                                        ClDBManager cdbm3 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional" + i.ToString() + ".db", iCurrentIndex);
                                        addInListOrAnother(cdbm3.BDone, "regional" + i.ToString() + ".db", lsFilesOk, lsFilesKo);
                                        bOkForDB &= cdbm3.BDone;
                                        iCurrentIndex += iNbGames;
                                    }
                                }
                            }
                            break;
                        case 4:
                            {
                                int iMaxPage = (int)(nudMaxGamesPerFolder.Value);
                                int iCountPageWanted = (int)(Math.Ceiling((decimal)((float)(m_lcgs.Count) / (float)iMaxPage)));
                                int iFinalCountPerPage = (int)(Math.Ceiling((decimal)((float)(m_lcgs.Count) / (float)iCountPageWanted)));
                                iFinalCountPerPage = Math.Max(iFinalCountPerPage, 20); // not less than 20
                                for (int i = 0; i < iCountPageWanted; i++)
                                {
                                    int iNbGames = iFinalCountPerPage;

                                    List<ClGameStructure> lcgs = new List<ClGameStructure>();
                                    ClDBManager cdbm40 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "empty.db");
                                    addInListOrAnother(cdbm40.BDone, "empty.db", lsFilesOk, lsFilesKo);
                                    bOkForDB = cdbm40.BDone;
                                    for (int j = iCurrentIndex; j < Math.Min((iCurrentIndex + iNbGames), m_lcgs.Count); j++)
                                    {
                                        lcgs.Add(m_lcgs[j]);
                                    }
                                    if (0 == i)
                                    {
                                        ClDBManager cdbm4 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional.db", iCurrentIndex);
                                        addInListOrAnother(cdbm4.BDone, "regional.db", lsFilesOk, lsFilesKo);
                                        bOkForDB &= cdbm4.BDone;
                                    }
                                    else
                                    {
                                        ClDBManager cdbm4 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional" + i.ToString() + ".db", iCurrentIndex);
                                        addInListOrAnother(cdbm4.BDone, "regional" + i.ToString() + ".db", lsFilesOk, lsFilesKo);
                                        bOkForDB &= cdbm4.BDone;
                                    }
                                    iCurrentIndex += iNbGames;
                                }
                            }
                            break;
                        default: // also case 1:
                            {
                                List<ClGameStructure> lcgs = new List<ClGameStructure>();
                                ClDBManager cdbm1 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "empty.db");
                                addInListOrAnother(cdbm1.BDone, "empty.db", lsFilesOk, lsFilesKo);
                                bOkForDB = cdbm1.BDone;
                                ClDBManager cdbm = new ClDBManager(m_lcgs, m_sFolderPath, m_bsversion, m_cvh, slLogger);
                                addInListOrAnother(cdbm.BDone, "regional.db", lsFilesOk, lsFilesKo);
                                bOkForDB &= cdbm.BDone;
                            }
                            break;
                    }
                    if(bOkForDB)
                    {
                        if (m_SelectionDBCreation != 1) // already done if 1
                        {
                            if ((Constant.iBLEEMSYNC_V100 == m_bsversion) || (Constant.iBLEEMSYNC_V120 == m_bsversion))
                            {
                                // create the second db file
                                ClDBManager.BleemSyncUI_AddDB(m_lcgs, m_sFolderPath, m_cvh, slLogger, m_bsversion);
                            }
                            if (Constant.iAUTOBLEEM_V06 == m_bsversion)
                            {
                                // create the files for autobleem in order to prevent a scan at start
                                ClDBManager.AutoBleem_CreateFiles(m_lcgs, m_sFolderPath, m_cvh, slLogger);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                bOkForDB = false;
                slLogger.Fatal(ex.Message);
            }
            m_frmParent.bNeedRecreateDB = !bOkForDB;
            if (!bOkForDB)
            {
                String sMsg = "There is a problem during database creation";
                if (lsFilesKo.Count > 0)
                {
                    sMsg += Environment.NewLine + "---------------" + Environment.NewLine + "Files ko:";
                    foreach (String sFile in lsFilesKo)
                    {
                        sMsg += Environment.NewLine + " -> " + sFile;
                    }
                }
                if (lsFilesOk.Count > 0)
                {
                    sMsg += Environment.NewLine + "---------------" + Environment.NewLine + "Files ok:";
                    foreach (String sFile in lsFilesOk)
                    {
                        sMsg += Environment.NewLine + " -> " + sFile;
                    }
                }
                FlexibleMessageBox.Show(sMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                String sMsg = "Database regenerated. Now you can properly unplug your usb drive and plug it in your PSC.";
                if (lsFilesOk.Count > 0)
                {
                    sMsg += Environment.NewLine + "---------------" + Environment.NewLine + "Files ok:";
                    foreach (String sFile in lsFilesOk)
                    {
                        sMsg += Environment.NewLine + " -> " + sFile;
                    }
                }
                if (lsFilesKo.Count > 0)
                {
                    sMsg += Environment.NewLine + "---------------" + Environment.NewLine + "Files ko:";
                    foreach (String sFile in lsFilesKo)
                    {
                        sMsg += Environment.NewLine + " -> " + sFile;
                    }
                }
                FlexibleMessageBox.Show(sMsg, "Job done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rbDBCreationOneFile_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void rbDBCreationOneFile_Click(object sender, EventArgs e)
        {
            m_SelectionDBCreation = 1;
            manageRadioButton();
        }

        private void rbDBCreationSeveralFiles_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void rbDBCreationSeveralFiles_Click(object sender, EventArgs e)
        {
            m_SelectionDBCreation = 2;
            manageRadioButton();
        }

        private void rbDBCreationSeveralFilesWithFirstEmpty_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void rbDBCreationSeveralFilesWithFirstEmpty_Click(object sender, EventArgs e)
        {
            m_SelectionDBCreation = 3;
            manageRadioButton();
        }

        private void manageRadioButton()
        {
            switch(m_SelectionDBCreation)
            {
                case 2:
                    if (m_bsversion == Constant.iBLEEMSYNC_V100)
                    {
                        rbDBCreationOneFile.Enabled = true;
                        rbDBCreationSeveralFiles.Enabled = true;
                        rbDBCreationSeveralFilesWithFirstEmpty.Enabled = true;
                        rbDBCreationSeveralFilesWithFirstNoSpecial.Enabled = true;
                        nudMaxGamesPerFolder.Enabled = true;

                        rbDBCreationSeveralFiles.Checked = true;
                    }
                    else
                    {
                        m_SelectionDBCreation = 1;
                        manageRadioButton();
                    }
                    break;
                case 3:
                    if (m_bsversion == Constant.iBLEEMSYNC_V100)
                    {
                        rbDBCreationOneFile.Enabled = true;
                        rbDBCreationSeveralFiles.Enabled = true;
                        rbDBCreationSeveralFilesWithFirstEmpty.Enabled = true;
                        rbDBCreationSeveralFilesWithFirstNoSpecial.Enabled = true;
                        nudMaxGamesPerFolder.Enabled = true;

                        rbDBCreationSeveralFilesWithFirstEmpty.Checked = true;
                    }
                    else
                    {
                        m_SelectionDBCreation = 1;
                        manageRadioButton();
                    }
                    break;
                case 4:
                    if (m_bsversion == Constant.iBLEEMSYNC_V100)
                    {
                        rbDBCreationOneFile.Enabled = true;
                        rbDBCreationSeveralFiles.Enabled = true;
                        rbDBCreationSeveralFilesWithFirstEmpty.Enabled = true;
                        rbDBCreationSeveralFilesWithFirstNoSpecial.Enabled = true;
                        nudMaxGamesPerFolder.Enabled = true;

                        rbDBCreationSeveralFilesWithFirstNoSpecial.Checked = true;
                    }
                    else
                    {
                        m_SelectionDBCreation = 1;
                        manageRadioButton();
                    }
                    break;
                default: // also case 1:
                    rbDBCreationOneFile.Checked = true;
                    rbDBCreationOneFile.Enabled = true;
                    nudMaxGamesPerFolder.Enabled = false;
                    if (m_bsversion == Constant.iBLEEMSYNC_V100)
                    {
                        
                        rbDBCreationSeveralFiles.Enabled = true;
                        rbDBCreationSeveralFilesWithFirstEmpty.Enabled = true;
                        rbDBCreationSeveralFilesWithFirstNoSpecial.Enabled = true;
                    }
                    else
                    {
                        rbDBCreationSeveralFiles.Enabled = false;
                        rbDBCreationSeveralFilesWithFirstEmpty.Enabled = false;
                        rbDBCreationSeveralFilesWithFirstNoSpecial.Enabled = false;
                    }
                    break;
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rbDBCreationSeveralFilesWithFirstNoSpecial_CheckedChanged(object sender, EventArgs e)
        {
            //
        }

        private void rbDBCreationSeveralFilesWithFirstNoSpecial_Click(object sender, EventArgs e)
        {
            m_SelectionDBCreation = 4;
            manageRadioButton();
        }
        

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.iMaxGamesPerFolder = (int)(nudMaxGamesPerFolder.Value);
            Properties.Settings.Default.Save();
        }
    }
}
