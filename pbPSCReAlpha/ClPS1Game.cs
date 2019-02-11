using System;

namespace pbPSCReAlpha
{
    public class ClPS1Game
    {
        private String _title;
        private String _serial;
        private String _link;
        private String _lang;

        public ClPS1Game(String title, String serial, String link, String lang)
        {
            _title = title;
            _serial = serial;
            _link = link;
            _lang = lang;
        }

        public String Title { get => _title; set => _title = value; }
        public String Serial { get => _serial; set => _serial = value; }
        public String Link { get => _link; set => _link = value; }
        public String Lang { get => _lang; set => _lang = value; }

        public String DisplayTitle { get => ((Serial.Contains("ES")) ? "[EUR]" : ((Serial.Contains("US")) ? "[USA]" : ((Serial.Contains("PM")) ? "[JAP]" : ((Serial.Contains("PS")) ? "[JAP]" : "")))) + " " + Title + " " + Lang; }
    }
}