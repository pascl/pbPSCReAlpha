namespace pbPSCReAlpha
{
    internal class ClPS1Game
    {
        private string _title;
        private string _serial;
        private string _link;

        public ClPS1Game(string title, string serial, string link)
        {
            _title = title;
            _serial = serial;
            _link = link;
        }

        public string Title { get => _title; set => _title = value; }
        public string Serial { get => _serial; set => _serial = value; }
        public string Link { get => _link; set => _link = value; }

        public string DisplayTitle { get => Title + " " + ((Serial.Contains("ES")) ? "(EUR)" : ((Serial.Contains("US")) ? "(USA)" : ((Serial.Contains("PM")) ? "(JAP)" : ((Serial.Contains("PS")) ? "(JAP)" : "")))); }
        
    }
}