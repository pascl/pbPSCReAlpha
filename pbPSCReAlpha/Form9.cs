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

        public Form9(List<ClGameStructure> lcgs, String sFolderPath, int bleemsyncVersion, ClVersionHelper cvh, SimpleLogger sl)
        {
            InitializeComponent();
            slLogger = sl;
            m_SelectionDBCreation = 1;
            m_bsversion = bleemsyncVersion;
            m_lcgs = lcgs;
            m_sFolderPath = sFolderPath;
            m_cvh = cvh;
            manageRadioButton();
        }

        private void btGenerateDB_Click(object sender, EventArgs e)
        {
            if (0 == m_lcgs.Count)
            {
                ClDBManager cdbm = new ClDBManager(m_lcgs, m_sFolderPath, m_bsversion, m_cvh, slLogger);
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
                                    if(iNbGames < 0)
                                    {
                                        iNbGames = 0;
                                    }
                                }
                                List<ClGameStructure> lcgs = new List<ClGameStructure>();
                                ClDBManager cdbm20 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "empty.db");
                                for (int j = iCurrentIndex; j < Math.Min((iCurrentIndex + iNbGames), m_lcgs.Count); j++)
                                {
                                    lcgs.Add(m_lcgs[j]);
                                }
                                if (0 == i)
                                {
                                    ClDBManager cdbm2 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional.db", iCurrentIndex);
                                }
                                else
                                {
                                    ClDBManager cdbm2 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional" + i.ToString() + ".db", iCurrentIndex);
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
                                    ClDBManager cdbm31 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional.db");
                                }
                                else
                                {
                                    for (int j = iCurrentIndex; j < Math.Min((iCurrentIndex + iNbGames), m_lcgs.Count); j++)
                                    {
                                        lcgs.Add(m_lcgs[j]);
                                    }
                                    ClDBManager cdbm3 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional" + i.ToString() + ".db", iCurrentIndex);
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
                                for (int j = iCurrentIndex; j < Math.Min((iCurrentIndex + iNbGames), m_lcgs.Count); j++)
                                {
                                    lcgs.Add(m_lcgs[j]);
                                }
                                if (0 == i)
                                {
                                    ClDBManager cdbm4 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional.db", iCurrentIndex);
                                }
                                else
                                {
                                    ClDBManager cdbm4 = new ClDBManager(lcgs, m_sFolderPath, m_bsversion, slLogger, m_sFolderPath + m_cvh.DbFolder + "\\" + "regional" + i.ToString() + ".db", iCurrentIndex);
                                }
                                iCurrentIndex += iNbGames;
                            }
                        }
                        break;
                    default: // also case 1:
                        ClDBManager cdbm = new ClDBManager(m_lcgs, m_sFolderPath, m_bsversion, m_cvh, slLogger);
                        break;
                }
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
                    if (m_bsversion == 1)
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
                    if (m_bsversion == 1)
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
                    if (m_bsversion == 1)
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
                    if (m_bsversion == 1)
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
    }
}
