using System;
using System.Collections.Generic;

namespace pbPSCReAlpha
{
    public class ClTGDBGame
    {
        private String _title;
        private String _link;
        private String _platform;
        private String _platformStr;
        private Dictionary<int, string> _dcTgdbPlatforms;

        public ClTGDBGame(String title, String link, String platform, Dictionary<int, string> dcClTgdbPlatforms)
        {
            _title = title;
            _link = link;
            _platform = platform;
            int iKey = 0;
            try
            {
                iKey = int.Parse(_platform);
            }
            catch(Exception ex)
            {
                //
            }
            if (dcClTgdbPlatforms.ContainsKey(iKey))
            {
                _platformStr = dcClTgdbPlatforms[iKey];
            }
            else
            {
                _platformStr = String.Empty;
            }
        }

        public String Title { get => _title; set => _title = value; }
        public String Link { get => _link; set => _link = value; }
        public String Platform { get => _platform; set => _platform = value; }
        public String DisplayTitle { get => Title + (String.IsNullOrEmpty(_platformStr) ? "" : " (" + _platformStr + ")"); }
    }
}