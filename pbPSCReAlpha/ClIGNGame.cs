using System;

namespace pbPSCReAlpha
{
    public class ClIGNGame
    {
        private String _title;
        private String _link;
        private String _platform;

        public ClIGNGame(String title, String link, String platform)
        {
            _title = title;
            _link = link;
            _platform = platform;
        }

        public String Title { get => _title; set => _title = value; }
        public String Link { get => _link; set => _link = value; }
        public String Platform { get => _platform; set => _platform = value; }
        public String DisplayTitle { get => Title + (String.IsNullOrEmpty(_platform) ? "" : " (" + _platform + ")"); }
    }
}
