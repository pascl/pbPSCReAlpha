using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private String _developer = String.Empty;
        private String _year = String.Empty;
        private String _players = String.Empty;

        private String _ABautomation = "0";
        private String _ABhighres = "0";
        private String _ABimagetype = "0";
        private String _ABmemcard = "SONY";

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
        private bool _pbpMissing;
        private bool _pngMismatch;
        private bool _cfgMissing;
        private bool _badCueName;
        private bool _badBinName;
        private bool _badPbpName;
        private bool _badDiscsName;
        private bool _cueCountMisMatchDiscsCount;
        private bool _pbpCountMisMatchDiscsCount;
        private bool _neededSbiMissing;
        private bool _commaInFilename;
        private bool _specialCharsInFilename;
        private List<String> _errorString;
        private List<String> _filesBinOk;
        private List<String> _filesCueOk;
        private List<String> _filesSbiOk;
        private List<String> _filesPbpOk;
        private long _size;
        private int _bleemSyncVersion;

        
        public ClGameStructure(String folderIndex, bool nanFolder, bool iniMissing, bool pcsxCfgMissing, bool pngMissing, bool pngMisMatch, bool gameIniIncomplete, bool multiPictures, bool cueMissing, bool badCueName, bool binMissing, bool badBinName, bool cueCountMisMatchdiscsCount, bool bNeededSbiMissing, bool bNameWithComma, bool bPbpMissing, bool badPbpName, bool pbpCountMisMatchdiscsCount, bool badDiscsName, int iBleemSyncVersion)
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
            _badPbpName = badPbpName;
            _badDiscsName = badDiscsName;
            _pbpMissing = bPbpMissing;
            _commaInFilename = bNameWithComma;
            _cueCountMisMatchDiscsCount = cueCountMisMatchdiscsCount;
            _pbpCountMisMatchDiscsCount = pbpCountMisMatchdiscsCount;
            _neededSbiMissing = bNeededSbiMissing;

            _bleemSyncVersion = iBleemSyncVersion;

            _errorString = new List<String>();
            _size = 0;
            if(_bleemSyncVersion == Constant.iAUTOBLEEM_V06)
            {
                _nanFolder = false;
            }

            if (((_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iBLEEMSYNC_V100) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (_nanFolder))
            {
                this.ErrorString.Add("Folder name has to be numeric.");
            }
            if (_iniMissing)
            {
                this.ErrorString.Add("Game.ini not found in the folder.");
            }
            if (((_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iAUTOBLEEM_V06) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (_cfgMissing))
            {
                this.ErrorString.Add("pcsx.cfg not found in the folder.");
            }
            if ((_bleemSyncVersion == Constant.iBLEEMSYNC_V100) && (!_cfgMissing))
            {
                this.ErrorString.Add("!! pcsx.cfg is not necessary anymore in the folder with BleemSync1.0/1.1.");
            }
            if (_pngMissing)
            {
                this.ErrorString.Add("Picture file not found in the folder.");
            }
            if ((_cueMissing) && (_pbpMissing)) // found no cue nor pbp in the folder
            {
                this.ErrorString.Add("Cue or Pbp files not found in the folder.");
            }
            if(((_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (!_pbpMissing))
            {
                this.ErrorString.Add("Pbp files won't start with selected version.");
            }
            if ((_pbpMissing) && (_cueMissing) && (_binMissing)) // if a cue, need bin in the folder
            {
                this.ErrorString.Add("Bin files not found in the folder.");
            }
            if(_commaInFilename)
            {
                this.ErrorString.Add("Files cannot contain commas ','.");
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
            if (((_bleemSyncVersion == Constant.iBLEEMSYNC_V100) || (_bleemSyncVersion == Constant.iAUTOBLEEM_V06)) && (!_pbpMissing) && (!_iniMissing) && (!_iniIncomplete) && (_pbpCountMisMatchDiscsCount))
            {
                this.ErrorString.Add("Count of pbp files doesn't match discs parameter in Game.ini.");
            }
            if (((((_bleemSyncVersion == Constant.iBLEEMSYNC_V100) || (_bleemSyncVersion == Constant.iAUTOBLEEM_V06)) && (_pbpMissing)) || (_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (!_cueMissing) && (!_iniMissing) && (!_iniIncomplete) && (_cueCountMisMatchDiscsCount)) // if pbp present, no need cue
            {
                this.ErrorString.Add("Count of cue files doesn't match discs parameter in Game.ini.");
            }
            if (((_bleemSyncVersion == Constant.iBLEEMSYNC_V100) || (_bleemSyncVersion == Constant.iAUTOBLEEM_V06)) && (!_pbpMissing) && (_badPbpName))
            {
                // no need display this error if pbp missing
                this.ErrorString.Add("At least one pbp file doesn't match discs parameter in Game.ini.");
            }
            if (((((_bleemSyncVersion == Constant.iBLEEMSYNC_V100) || (_bleemSyncVersion == Constant.iAUTOBLEEM_V06)) && (_pbpMissing)) || (_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (!_cueMissing) && (_badCueName)) // if pbp present, no need cue
            {
                // no need display this error if cue missing
                this.ErrorString.Add("At least one cue file doesn't match discs parameter in Game.ini.");
            }
            if (((((_bleemSyncVersion == Constant.iBLEEMSYNC_V100) || (_bleemSyncVersion == Constant.iAUTOBLEEM_V06)) && (_pbpMissing)) || (_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (!_cueMissing) && (!_binMissing) && (_badBinName)) // if pbp present, no need bin
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
            _iniMissing = true;
            _errorString = new List<String>();
            if (_nanFolder)
            {
                this.ErrorString.Add("Folder name has to be numeric.");
            }
            if(_gameDataMissing)
            {
                this.ErrorString.Add("Folder .\\GameData\\ not found.");
            }
            if (_iniMissing)
            {
                this.ErrorString.Add("Game.ini not found in the folder.");
            }
        }

        public void setIniInfos(String title, String discs, String publisher, String developer, String year, String players, String alphatitle)
        {
            _title = title;
            _discs = discs;
            _publisher = publisher;
            _developer = developer;
            _year = year;
            _players = players;
            _alphatitle = alphatitle;
        }

        public void setIniAutoBleemInfo(String sAutomation, String sHighres, String sImagetype, String sMemcard)
        {
            _ABautomation = sAutomation;
            _ABhighres = sHighres;
            _ABimagetype = sImagetype;
            _ABmemcard = sMemcard;
        }

        public void setFilesList(List<String> sList)
        {
            _specialCharsInFilename = false;
            _filenames = sList;
            _filenames.Sort();
            foreach(String s in _filenames)
            {
                String sTest = Regex.Replace(s, @"[^a-zA-Z0-9_\-\s\.\(\[\)\]\']", "");
                if(sTest != s)
                {
                    _specialCharsInFilename = true;
                    this.ErrorString.Add("Files cannot contain some special characters.");
                    break;
                }
            }
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

        public bool IsSame(ClGameStructure cgs)
        {
            bool b = true;
            if (b) { b &= (Title == cgs.Title); }
            if (b) { b &= (FolderIndex == cgs.FolderIndex); }
            if (b) { b &= (IndexAndTitle == cgs.IndexAndTitle); }
            if (b) { b &= (Alphatitle == cgs.Alphatitle); }
            if (b) { b &= (Discs == cgs.Discs); }
            if (b) { b &= (Publisher == cgs.Publisher); }
            if (b) { b &= (Developer == cgs.Developer); }
            if (b) { b &= (Year == cgs.Year); }
            if (b) { b &= (Players == cgs.Players); }
            if (b) { b &= (GameDataMissing == cgs.GameDataMissing); }
            if (b) { b &= (IniMissing == cgs.IniMissing); }
            if (b) { b &= (CfgMissing == cgs.CfgMissing); }
            if (b) { b &= (CueMissing == cgs.CueMissing); }
            if (b) { b &= (BinMissing == cgs.BinMissing); }
            if (b) { b &= (NanFolder == cgs.NanFolder); }
            if (b) { b &= (PngMissing == cgs.PngMissing); }
            if (b) { b &= (PngMultiple == cgs.PngMultiple); }
            if (b) { b &= (IniIncomplete == cgs.IniIncomplete); }
            if (b) { b &= (PngMismatch == cgs.PngMismatch); }
            if (b) { b &= (BadCueName == cgs.BadCueName); }
            if (b) { b &= (BadBinName == cgs.BadBinName); }
            if (b) { b &= (CueCountMisMatchDiscsCount == cgs.CueCountMisMatchDiscsCount); }
            if (b) { b &= (PictureFileName == cgs.PictureFileName); }
            if (b) { b &= (NeededSbiMissing == cgs.NeededSbiMissing); }
            if (b) { b &= (CommaInFilename == cgs.CommaInFilename); }
            if (b) { b &= (PbpMissing == cgs.PbpMissing); }
            if (b) { b &= (BadPbpName == cgs.BadPbpName); }
            if (b) { b &= (PbpCountMisMatchDiscsCount == cgs.PbpCountMisMatchDiscsCount); }
            if (b) { b &= (BadDiscsName == cgs.BadDiscsName); }
            if (b) { b &= (PbpErrors == cgs.PbpErrors); }
            if (b) { b &= (CueErrors == cgs.CueErrors); }
            if (b) { b &= (BinErrors == cgs.BinErrors); }
            if (b) { b &= (SbiErrors == cgs.SbiErrors); }
            if (b) { b &= (PngErrors == cgs.PngErrors); }
            if (b) { b &= (IniErrors == cgs.IniErrors); }
            if (b) { b &= (FileErrors == cgs.FileErrors); }
            if (b) { b &= (GeneralError == cgs.GeneralError); }
            if (b) { b &= (GeneralWarning == cgs.GeneralWarning); }
            if ((b) && (ErrorString != null) && (cgs.ErrorString != null)) { b &= (ErrorString.Count == cgs.ErrorString.Count); }
            if ((b) && (FilesBinOk != null) && (cgs.FilesBinOk != null)) { b &= (FilesBinOk.Count == cgs.FilesBinOk.Count); }
            if ((b) && (FilesCueOk != null) && (cgs.FilesCueOk != null)) { b &= (FilesCueOk.Count == cgs.FilesCueOk.Count); }
            if ((b) && (FilesSbiOk != null) && (cgs.FilesSbiOk != null)) { b &= (FilesSbiOk.Count == cgs.FilesSbiOk.Count); }
            if ((b) && (FilesPbpOk != null) && (cgs.FilesPbpOk != null)) { b &= (FilesPbpOk.Count == cgs.FilesPbpOk.Count); }
            if ((b) && (Filenames != null) && (cgs.Filenames != null)) { b &= (Filenames.Count == cgs.Filenames.Count); }

            return b;
        }

        public String Title { get => _title; set => _title = value; }
        public String FolderIndex { get => _folderIndex; set => _folderIndex = value; }
        public String IndexAndTitle { get => (GeneralError ? "* " : (GeneralWarning ? "! " : "")) + _folderIndex + " - " + _title; }
        public String Alphatitle { get => _alphatitle; set => _alphatitle = value; }
        public String Discs { get => _discs; set => _discs = value; }
        public String Publisher { get => _publisher; set => _publisher = value; }
        public String Developer { get => _developer; set => _developer = value; }
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
        public List<String> FilesBinOk { get => _filesBinOk; set => _filesBinOk = value; }
        public List<String> FilesCueOk { get => _filesCueOk; set => _filesCueOk = value; }
        public List<String> FilesSbiOk { get => _filesSbiOk; set => _filesSbiOk = value; }
        public List<String> FilesPbpOk { get => _filesPbpOk; set => _filesPbpOk = value; }
        public string PictureFileName { get => _pictureFileName; set => _pictureFileName = value; }
        public bool NeededSbiMissing { get => _neededSbiMissing; set => _neededSbiMissing = value; }
        public long FolderSize { get => _size; }
        public bool CommaInFilename { get => _commaInFilename; set => _commaInFilename = value; }
        public bool PbpMissing { get => _pbpMissing; set => _pbpMissing = value; }
        public bool BadPbpName { get => _badPbpName; set => _badPbpName = value; }
        public bool PbpCountMisMatchDiscsCount { get => _pbpCountMisMatchDiscsCount; set => _pbpCountMisMatchDiscsCount = value; }
        public bool BadDiscsName { get => _badDiscsName; set => _badDiscsName = value; }
        public bool SpecialCharsInFilename { get => _specialCharsInFilename; set => _specialCharsInFilename = value; }

        public string ABautomation { get => _ABautomation; set => _ABautomation = value; }
        public string ABhighres { get => _ABhighres; set => _ABhighres = value; }
        public string ABimagetype { get => _ABimagetype; set => _ABimagetype = value; }
        public string ABmemcard { get => _ABmemcard; set => _ABmemcard = value; }

        public bool PbpErrors { get => (((_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (!_pbpMissing)) || (_cueMissing && ((_bleemSyncVersion == Constant.iBLEEMSYNC_V100) || (_bleemSyncVersion == Constant.iAUTOBLEEM_V06)) && (_pbpMissing || _badPbpName || _pbpCountMisMatchDiscsCount)); }
        public bool CueErrors { get => ((((_bleemSyncVersion == Constant.iBLEEMSYNC_V100) || (_bleemSyncVersion == Constant.iAUTOBLEEM_V06)) && _pbpMissing) || (_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (_cueMissing || _badCueName || _cueCountMisMatchDiscsCount); }
        public bool BinErrors { get => ((((_bleemSyncVersion == Constant.iBLEEMSYNC_V100) || (_bleemSyncVersion == Constant.iAUTOBLEEM_V06)) && _pbpMissing) || (_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (!_cueMissing) && (_binMissing || _badBinName); }
        public bool SbiErrors { get => _neededSbiMissing; }
        public bool PngErrors { get => _pngMissing || _pngMismatch || _pngMultiple; }
        public bool IniErrors { get => _iniMissing || _iniIncomplete; }
        public bool FileErrors { get => (((_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iBLEEMSYNC_V100) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (_nanFolder)) || (((_bleemSyncVersion == Constant.iBLEEMSYNC_V041) || (_bleemSyncVersion == Constant.iAUTOBLEEM_V06) || (_bleemSyncVersion == Constant.iSTRUCT_INTERNAL)) && (_cfgMissing)) || _gameDataMissing || _commaInFilename || _specialCharsInFilename; }

        public bool GeneralError { get => PbpErrors || CueErrors || BinErrors || SbiErrors || PngErrors || IniErrors || FileErrors; }
        public bool GeneralWarning { get => BadDiscsName || ((_bleemSyncVersion == Constant.iBLEEMSYNC_V100) && (!_cfgMissing)); }
        
    }
}
