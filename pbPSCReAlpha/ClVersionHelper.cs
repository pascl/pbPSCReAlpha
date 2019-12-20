using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbPSCReAlpha
{
    public class ClVersionHelper
    {
        String _versionstring;
        String _gameDataFolder;
        String _saveFolder;
        String _dbFolder;
        String _cfgFolder;
        String _retroarchCfgFolder;

        public ClVersionHelper(String sVersion, String sFolderGamedata, String sFolderSave, String sFolderDb, String sFolderCfg, String sRetroarchCfg)
        {
            _versionstring = sVersion;
            _gameDataFolder = sFolderGamedata;
            _saveFolder = sFolderSave;
            _dbFolder = sFolderDb;
            _cfgFolder = sFolderCfg;
            _retroarchCfgFolder = sRetroarchCfg;
        }

        public string Versionstring { get => _versionstring; set => _versionstring = value; }
        public string GameDataFolder { get => _gameDataFolder; set => _gameDataFolder = value; }
        public string SaveFolder { get => _saveFolder; set => _saveFolder = value; }
        public string DbFolder { get => _dbFolder; set => _dbFolder = value; }
        public string CfgFolder { get => _cfgFolder; set => _cfgFolder = value; }
        public string RetroarchCfgFolder { get => _retroarchCfgFolder; set => _retroarchCfgFolder = value; }
    }
}
