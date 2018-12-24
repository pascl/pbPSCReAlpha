using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace pbPSCReAlpha
{
    class ClGameScraper
    {
        String _title;
        String _publisher;
        String _year = "1995";
        String _players = "1";
        String _imgUrl;

        public string Title { get => _title; set => _title = value; }
        public string Publisher { get => _publisher; set => _publisher = value; }
        public string Year { get => _year; set => _year = value; }
        public string Players { get => _players; set => _players = value; }
        public string ImgUrl { get => _imgUrl; set => _imgUrl = value; }

        public ClGameScraper(String linkToScrape)
        {
            //
        }

        private String loadHtmlPage(String sLink)
        {
            String sHtml = String.Empty;
            return sHtml;
        }

        private void doScrape(String sHtmlContent)
        {
            //
        }
    }
}
