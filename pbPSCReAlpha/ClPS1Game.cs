using System;

namespace pbPSCReAlpha
{
    public class ClPS1Game
    {
        private String _title;
        private String _serial;
        private String _link;

        public ClPS1Game(String title, String serial, String link)
        {
            _title = title;
            _serial = serial;
            _link = link;
        }

        public String Title { get => _title; set => _title = value; }
        public String Serial { get => _serial; set => _serial = value; }
        public String Link { get => _link; set => _link = value; }

        public String DisplayTitle { get => ((Serial.Contains("ES")) ? "[EUR]" : ((Serial.Contains("US")) ? "[USA]" : ((Serial.Contains("PM")) ? "[JAP]" : ((Serial.Contains("PS")) ? "[JAP]" : "")))) + " " + Title; }
        
    }
}