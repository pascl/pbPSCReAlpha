using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbPSCReAlpha
{
    public class ClGameStructure
    {
        private String _folderIndex = String.Empty;
        private String _title = String.Empty;
        private String _alphatitle = String.Empty;
        private String _discs = String.Empty;
        private String _publisher = String.Empty;
        private String _year = String.Empty;
        private String _players = String.Empty;
        private Image _pictureFile;
        private String _pictureFileName = String.Empty;
        private List<String> _filenames;
        private bool _gameDataMissing;
        private bool _pngMissing;
        private bool _pngMultiple;
        private bool _nanFolder;
        private bool _iniMissing;
        private bool _iniIncomplete;
        private bool _cueMissing;
        private bool _binMissing;
        private bool _pngMismatch;
        private bool _cfgMissing;
        private bool _badCueName;
        private bool _badBinName;
        private bool _cueCountMisMatchDiscsCount;
        private bool _neededSbiMissing;
        private List<String> _errorString;
        private List<String> _filesBinOk;
        private List<String> _filesCueOk;
        private List<String> _filesSbiOk;
        private long _size;

        public ClGameStructure(String folderIndex, bool nanFolder, bool iniMissing, bool pcsxCfgMissing, bool pngMissing, bool pngMisMatch, bool gameIniIncomplete, bool multiPictures, bool cueMissing, bool badCueName, bool binMissing, bool badBinName, bool cueCountMisMatchdiscsCount, bool bNeededSbiMissing)
        {
            _folderIndex = folderIndex;
            _gameDataMissing = false; // if i have all these variables, i have at least the folder...
            _nanFolder = nanFolder;
            _iniMissing = iniMissing;
            _cfgMissing = pcsxCfgMissing;
            _pngMissing = pngMissing;
            _pngMismatch = pngMisMatch;
            _iniIncomplete = gameIniIncomplete;
            _pngMultiple = multiPictures;
            _cueMissing = cueMissing;
            _badCueName = badCueName;
            _binMissing = binMissing;
            _badBinName = badBinName;
            _cueCountMisMatchDiscsCount = cueCountMisMatchdiscsCount;
            _neededSbiMissing = bNeededSbiMissing;
            _errorString = new List<String>();
            _size = 0;
            if (_nanFolder)
            {
                this.ErrorString.Add("Folder name has to be numeric.");
            }
            if (_iniMissing)
            {
                this.ErrorString.Add("Game.ini not found in the folder.");
            }
            if (_cfgMissing)
            {
                this.ErrorString.Add("pcsx.cfg not found in the folder.");
            }
            if (_pngMissing)
            {
                this.ErrorString.Add("Picture file not found in the folder.");
            }
            if (_cueMissing)
            {
                this.ErrorString.Add("Cue files not found in the folder.");
            }
            if (_binMissing)
            {
                this.ErrorString.Add("Bin files not found in the folder.");
            }
            if (_pngMultiple)
            {
                this.ErrorString.Add("Several picture files found in the folder.");
            }
            if ((!_pngMissing) && (_pngMismatch))
            {
                // no need display this error if png missing
                this.ErrorString.Add("Picture file mismatch the first parameter in Discs of Game.ini.");
            }
            if ((!_iniMissing) && (_iniIncomplete))
            {
                // no need display this error if ini missing
                this.ErrorString.Add("Game.ini is incomplete, needs 5 parameters.");
            }
            if ((!_cueMissing) && (!_iniMissing) && (!_iniIncomplete) && (_cueCountMisMatchDiscsCount))
            {
                this.ErrorString.Add("Count of cue files doesn't match discs parameter in Game.ini.");
            }
            if ((!_cueMissing) && (_badCueName))
            {
                // no need display this error if cue missing
                this.ErrorString.Add("At least one cue file doesn't match discs parameter in Game.ini.");
            }
            if ((!_binMissing) && (_badBinName))
            {
                // no need display this error if bin missing
                this.ErrorString.Add("At least one bin file doesn't match entries in cue files.");
            }
        }
        
        public ClGameStructure(String folderIndex, bool nanFolder, bool gameDataMissing)
        {
            _folderIndex = folderIndex;
            _nanFolder = nanFolder;
            _gameDataMissing = gameDataMissing;
            _title = "ZZZZ" + folderIndex;
            _errorString = new List<String>();
            if (_nanFolder)
            {
                this.ErrorString.Add("Folder name has to be numeric.");
            }
            if(_gameDataMissing)
            {
                this.ErrorString.Add("Folder .\\GameData\\ not found.");
            }
        }

        public void setIniInfos(String title, String discs, String publisher, String year, String players, String alphatitle)
        {
            _title = title;
            _discs = discs;
            _publisher = publisher;
            _year = year;
            _players = players;
            _alphatitle = alphatitle;
        }

        public void setFilesList(List<String> sList)
        {
            _filenames = sList;
            _filenames.Sort();
        }

        public void setPicture(String imgFileName, Image imgFile)
        {
            _pictureFile = imgFile;
            _pictureFileName = imgFileName;
        }

        public void setSize(long lSize)
        {
            _size = lSize;
        }

        public String Title { get => _title; set => _title = value; }
        public String FolderIndex { get => _folderIndex; set => _folderIndex = value; }
        public String IndexAndTitle { get => (GeneralError ? "* " : "") + _folderIndex + " - " + _title; }
        public String Alphatitle { get => _alphatitle; set => _alphatitle = value; }
        public String Discs { get => _discs; set => _discs = value; }
        public String Publisher { get => _publisher; set => _publisher = value; }
        public String Year { get => _year; set => _year = value; }
        public String Players { get => _players; set => _players = value; }
        public Image PictureFile { get => _pictureFile; }
        public bool GameDataMissing { get => _gameDataMissing; set => _gameDataMissing = value; }
        public bool IniMissing { get => _iniMissing; set => _iniMissing = value; }
        public bool CfgMissing { get => _cfgMissing; set => _cfgMissing = value; }
        public List<String> Filenames { get => _filenames; }
        public bool CueMissing { get => _cueMissing; set => _cueMissing = value; }
        public bool BinMissing { get => _binMissing; set => _binMissing = value; }
        public List<String> ErrorString { get => _errorString; set => _errorString = value; }
        public bool NanFolder { get => _nanFolder; set => _nanFolder = value; }
        public bool PngMissing { get => _pngMissing; set => _pngMissing = value; }
        public bool PngMultiple { get => _pngMultiple; set => _pngMultiple = value; }
        public bool IniIncomplete { get => _iniIncomplete; set => _iniIncomplete = value; }
        public bool PngMismatch { get => _pngMismatch; set => _pngMismatch = value; }
        public bool BadCueName { get => _badCueName; set => _badCueName = value; }
        public bool BadBinName { get => _badBinName; set => _badBinName = value; }
        public bool CueCountMisMatchDiscsCount { get => _cueCountMisMatchDiscsCount; set => _cueCountMisMatchDiscsCount = value; }
        public bool GeneralError { get => _cueCountMisMatchDiscsCount || _badBinName || _badCueName || _pngMismatch
                || _iniIncomplete || _pngMultiple || _pngMissing || _nanFolder || _binMissing
                || _cueMissing || _cfgMissing || _iniMissing || _gameDataMissing || _neededSbiMissing; }
        public List<String> FilesBinOk { get => _filesBinOk; set => _filesBinOk = value; }
        public List<String> FilesCueOk { get => _filesCueOk; set => _filesCueOk = value; }
        public List<String> FilesSbiOk { get => _filesSbiOk; set => _filesSbiOk = value; }
        public string PictureFileName { get => _pictureFileName; set => _pictureFileName = value; }
        public bool NeededSbiMissing { get => _neededSbiMissing; set => _neededSbiMissing = value; }
        public long FolderSize { get => _size; }
    }
}
