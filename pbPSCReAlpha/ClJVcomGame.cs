using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pbPSCReAlpha
{
    public class ClJVcomGame
    {
        private String _title;
        private String _link;
        private String _platform;

        public ClJVcomGame(String title, String link, String platform)
        {
            _title = title;
            _link = link;
            _platform = platform;
        }

        public String Title { get => _title; set => _title = value; }
        public String Link { get => _link; set => _link = value; }
        public String Platform { get => _platform; set => _platform = value; }
        public String DisplayTitle { get => Title + (String.IsNullOrEmpty(_platform) ? "" : " (" + _platform + ")"); }

        internal static String decodeJVCom(String sLinkEncoded)
        {
            String sResult = String.Empty;
            String sCle = Properties.Settings.Default.sCleJVcom;
            for(int i=0;i<sLinkEncoded.Length;i+=2)
            {
                int a = sCle.IndexOf(sLinkEncoded[i]);
                int b = sCle.IndexOf(sLinkEncoded[i+1]);
                sResult += ((char)(16 * a + b));
            }
            return sResult;
        }
    }
}
