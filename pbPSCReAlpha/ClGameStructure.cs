using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbPSCReAlpha
{
    class ClGameStructure
    {
        private string _folderIndex;
        private string _title;
        private string _alphatitle;
        private string _discs;
        private string _publisher;
        private string _year;
        private string _players;
        private Bitmap _pictureFile;
        private List<string> _filenames;
        private bool _gameDataMissing;
        private bool _pngMissing;
        private bool _pngMultiple;
        private bool _nanFolder;
        private bool _iniMissing;
        private bool _iniIncomplete;
        private bool _cueMissing;
        private bool _binMissing;
        private bool _binCueMismatch;
        private bool _pngMismatch;
        private bool _cfgMissing;
        private bool _badCueName;
        private bool _badBinName;
        private bool _cueCountMisMatchDiscsCount;
        private List<string> _errorString;
        private List<string> _filesBinOk;
        private List<string> _filesCueOk;

        public ClGameStructure(string folderIndex, bool nanFolder, bool iniMissing, bool pcsxCfgMissing, bool pngMissing, bool pngMisMatch, bool gameIniIncomplete, bool multiPictures, bool cueMissing, bool badCueName, bool binMissing, bool badBinName, bool cueCountMisMatchdiscsCount)
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
            _errorString = new List<string>();
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
        
        public ClGameStructure(string folderIndex, bool nanFolder, bool gameDataMissing)
        {
            _folderIndex = folderIndex;
            _nanFolder = nanFolder;
            _gameDataMissing = gameDataMissing;
            _title = "Undefined";
            _errorString = new List<string>();
            if (_nanFolder)
            {
                this.ErrorString.Add("Folder name has to be numeric.");
            }
            if(_gameDataMissing)
            {
                this.ErrorString.Add("Folder .\\GameData\\ not found.");
            }
        }

        public void setIniInfos(string title, string discs, string publisher, string year, string players, string alphatitle)
        {
            _title = title;
            _discs = discs;
            _publisher = publisher;
            _year = year;
            _players = players;
            _alphatitle = alphatitle;
        }

        public void setFilesList(List<string> sList)
        {
            _filenames = sList;
        }

        public void setPicture(Bitmap bmFile)
        {
            _pictureFile = bmFile;
        }

        public string Title { get => _title; set => _title = value; }
        public string FolderIndex { get => _folderIndex; set => _folderIndex = value; }
        public string IndexAndTitle { get => (GeneralError ? "* " : "") + _folderIndex + " - " + _title; }
        public string Alphatitle { get => _alphatitle; set => _alphatitle = value; }
        public string Discs { get => _discs; set => _discs = value; }
        public string Publisher { get => _publisher; set => _publisher = value; }
        public string Year { get => _year; set => _year = value; }
        public string Players { get => _players; set => _players = value; }
        public Bitmap PictureFile { get => _pictureFile; }
        public bool GameDataMissing { get => _gameDataMissing; set => _gameDataMissing = value; }
        public bool IniMissing { get => _iniMissing; set => _iniMissing = value; }
        public bool CfgMissing { get => _cfgMissing; set => _cfgMissing = value; }
        public List<string> Filenames { get => _filenames; }
        public bool CueMissing { get => _cueMissing; set => _cueMissing = value; }
        public bool BinMissing { get => _binMissing; set => _binMissing = value; }
        public bool BinCueMismatch { get => _binCueMismatch; set => _binCueMismatch = value; }
        public List<string> ErrorString { get => _errorString; set => _errorString = value; }
        public bool NanFolder { get => _nanFolder; set => _nanFolder = value; }
        public bool PngMissing { get => _pngMissing; set => _pngMissing = value; }
        public bool PngMultiple { get => _pngMultiple; set => _pngMultiple = value; }
        public bool IniIncomplete { get => _iniIncomplete; set => _iniIncomplete = value; }
        public bool PngMismatch { get => _pngMismatch; set => _pngMismatch = value; }
        public bool BadCueName { get => _badCueName; set => _badCueName = value; }
        public bool BadBinName { get => _badBinName; set => _badBinName = value; }
        public bool CueCountMisMatchDiscsCount { get => _cueCountMisMatchDiscsCount; set => _cueCountMisMatchDiscsCount = value; }
        public bool GeneralError { get => _cueCountMisMatchDiscsCount || _badBinName || _badCueName || _pngMismatch
                || _iniIncomplete || _pngMultiple || _pngMissing || _nanFolder || _binCueMismatch || _binMissing
                || _cueMissing || _cfgMissing || IniMissing || GameDataMissing; }
        public List<string> FilesBinOk { get => _filesBinOk; set => _filesBinOk = value; }
        public List<string> FilesCueOk { get => _filesCueOk; set => _filesCueOk = value; }
    }
}
