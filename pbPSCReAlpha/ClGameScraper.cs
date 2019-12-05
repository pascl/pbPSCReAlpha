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
        String _developer;
        String _year = "1919";
        String _players = "1";
        String _imgUrl;

        public string Title { get => _title; set => _title = value; }
        public string Publisher { get => _publisher; set => _publisher = value; }
        public string Developer { get => _developer; set => _developer = value; }
        public string Year { get => _year; set => _year = value; }
        public string Players { get => _players; set => _players = value; }
        public string ImgUrl { get => _imgUrl; set => _imgUrl = value; }

        public ClGameScraper(String sHtml, int pattern)
        {
            if (!String.IsNullOrEmpty(sHtml))
            {
                switch(pattern)
                {
                    case 1:
                        doScrapePsxDataCenter(sHtml);
                        break;
                    case 2:
                        doScrapeTGDB(sHtml);
                        break;
                    case 3:
                        doScrapeIGN(sHtml);
                        break;
                    case 4:
                        doScrapeJVcom(sHtml);
                        break;
                    default:
                        // default values
                        break;
                }
            }
        }

        private String loadHtmlPage(String sLink)
        {
            String sHtml = String.Empty;
            return sHtml;
        }

        private void doScrapeJVcom(String sHtmlContent)
        {
            _players = "1"; // no players information on jvcom
            _imgUrl = String.Empty;
            try
            {
                using (StringReader reader = new StringReader(sHtmlContent))
                {
                    //
                    String s = String.Empty;
                    s = reader.ReadToEnd();
                    {
                        s = s.Trim();
                        s = s.Replace("&nbsp;", " ");
                        s = s.Replace("&amp;", "&");
                        s = s.Replace("  ", " ");
                        if (s.IndexOf("gameHeaderBanner__title\">") > -1)
                        {
                            int ipos1 = s.IndexOf("gameHeaderBanner__title\">");
                            int ilen1 = "gameHeaderBanner__title\">".Length;
                            if (ipos1 > -1)
                            {
                                String s1 = s.Substring(ipos1 + ilen1);
                                int ipos2 = s1.IndexOf("</span>");
                                if (ipos2 > -1)
                                {
                                    _title = s1.Substring(0, ipos2).Trim();
                                }
                            }
                        }
                        if (s.IndexOf("Editeur(s) / Développeur(s)</div>") > -1)
                        {
                            int ipos1 = s.IndexOf("Editeur(s) / Développeur(s)</div>");
                            int ilen1 = "Editeur(s) / Développeur(s)</div>".Length;
                            if (ipos1 > -1)
                            {
                                String s1 = s.Substring(ipos1 + ilen1);
                                int ipos2 = s1.IndexOf("</div>");
                                if (ipos2 > -1)
                                {
                                    s1 = s1.Substring(0, ipos2);
                                    String sPubs = String.Empty;
                                    do
                                    {
                                        int ipos3 = s1.IndexOf("gameCharacteristicsDetailed__characValue\">");
                                        int ilen3 = "gameCharacteristicsDetailed__characValue\">".Length;
                                        int ipos4 = s1.IndexOf("</span>");
                                        if((ipos3 > -1) && (ipos4 > -1))
                                        {
                                            if(String.IsNullOrEmpty(sPubs))
                                            {
                                                sPubs = s1.Substring(ipos3 + ilen3, ipos4 - ipos3 - ilen3).Trim();
                                            }
                                            else
                                            {
                                                sPubs += ", " + s1.Substring(ipos3 + ilen3, ipos4 - ipos3 - ilen3).Trim();
                                            }
                                            s1 = s1.Substring(ipos4 + 7);
                                        }
                                    } while (s1.IndexOf("gameCharacteristicsDetailed__characValue\">") > -1);
                                    _publisher = sPubs;
                                }
                            }
                        }
                        if (s.IndexOf("<div class=\"gameCharacteristicsMain__releaseDate\">") > -1)
                        {
                            int ipos1 = s.IndexOf("<div class=\"gameCharacteristicsMain__releaseDate\">");
                            int ilen1 = "<div class=\"gameCharacteristicsMain__releaseDate\">".Length;
                            if (ipos1 > -1)
                            {
                                String s1 = s.Substring(ipos1 + ilen1);
                                int ipos2 = s1.IndexOf("</div>");
                                if (ipos2 > -1)
                                {
                                    String sDate = s1.Substring(0, ipos2).Trim();
                                    try
                                    {
                                        String[] sDates = sDate.Split(' ');
                                        int year = int.Parse(sDates[sDates.Length - 1]);
                                        _year = year.ToString();
                                    }
                                    catch (Exception ex)
                                    {
                                        _year = "1920";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void doScrapeIGN(String sHtmlContent)
        {
            _players = "1"; // no players information on ign
            _imgUrl = String.Empty;
            try
            {
                using (StringReader reader = new StringReader(sHtmlContent))
                {
                    //
                    String s = String.Empty;
                    while ((s = reader.ReadLine()) != null)
                    {
                        s = s.Trim();
                        s = s.Replace("&nbsp;", " ");
                        s = s.Replace("&amp;", "&");
                        s = s.Replace("  ", " ");
                        if (s.IndexOf("</span></h1>") > -1)
                        {
                            int ipos1 = s.IndexOf("<h1 class=");
                            int ipos2 = s.IndexOf("</span></h1>");
                            if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                            {
                                String s1 = s.Substring(ipos1, ipos2 - ipos1);
                                int ipos3 = s1.IndexOf("<span>");
                                if (ipos3 > -1)
                                {
                                    _title = s1.Substring(ipos3 + 6).Trim();
                                }
                            }
                        }
                        if (s.IndexOf("Publisher</span>") > -1)
                        {
                            int ipos1 = s.IndexOf("Publisher</span>");
                            if(ipos1 > -1)
                            {
                                String s1 = s.Substring(ipos1 + 16);
                                int ipos2 = s1.IndexOf("</div>");
                                if(ipos2 > -1)
                                {
                                    String sPub = s1.Substring(0, ipos2).Trim();
                                    _publisher = sPub;
                                }
                            }
                        }
                        if (s.IndexOf("Developer</span>") > -1)
                        {
                            int ipos1 = s.IndexOf("Developer</span>");
                            if (ipos1 > -1)
                            {
                                String s1 = s.Substring(ipos1 + 16);
                                int ipos2 = s1.IndexOf("</div>");
                                if (ipos2 > -1)
                                {
                                    String sDev = s1.Substring(0, ipos2).Trim();
                                    _developer = sDev;
                                }
                            }
                        }
                        if (s.IndexOf("Release Date</span>") > -1)
                        {
                            int ipos1 = s.IndexOf("Release Date</span>");
                            if (ipos1 > -1)
                            {
                                String s1 = s.Substring(ipos1 + 19);
                                int ipos2 = s1.IndexOf("</div>");
                                if (ipos2 > -1)
                                {
                                    String sDate = s1.Substring(0, ipos2).Trim();
                                    try
                                    {
                                        DateTime dt = Convert.ToDateTime(sDate);
                                        _year = dt.Year.ToString();
                                    }
                                    catch(Exception ex)
                                    {
                                        _year = "1930";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void doScrapeTGDB(String sHtmlContent)
        {
            try
            {
                using (StringReader reader = new StringReader(sHtmlContent))
                {
                    //
                    String s = String.Empty;
                    while ((s = reader.ReadLine()) != null)
                    {
                        s = s.Trim();
                        s = s.Replace("&nbsp;", " ");
                        s = s.Replace("&amp;", "&");
                        s = s.Replace("  ", " ");
                        if (s.IndexOf("</h1>") > -1)
                        {
                            int ipos1 = s.IndexOf("<h1>");
                            int ipos2 = s.IndexOf("</h1>");
                            if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                            {
                                _title = s.Substring(ipos1 + 4, ipos2 - ipos1 - 4).Trim();
                            }
                        }
                        else
                        if (s.IndexOf("<p>Publishers(s):") > -1)
                        {
                            int ipos1 = s.IndexOf("\">");
                            int ipos2 = s.IndexOf("</a>");
                            if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                            {
                                String sPub = s.Substring(ipos1 + 2, ipos2 - ipos1 - 2).Trim();
                                if (sPub.EndsWith("."))
                                {
                                    sPub = sPub.Substring(0, sPub.Length - 1);
                                }
                                _publisher = sPub;
                            }
                        }
                        else
                        if (s.IndexOf("<p>Developer(s):") > -1)
                        {
                            int ipos1 = s.IndexOf("\">");
                            int ipos2 = s.IndexOf("</a>");
                            if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                            {
                                String sDev = s.Substring(ipos1 + 2, ipos2 - ipos1 - 2).Trim();
                                if (sDev.EndsWith("."))
                                {
                                    sDev = sDev.Substring(0, sDev.Length - 1);
                                }
                                _developer = sDev;
                            }
                        }
                        else
                        if (s.IndexOf("<p>ReleaseDate:") > -1)
                        {
                            int ipos1 = s.IndexOf(" ");
                            int ipos2 = s.IndexOf("-");
                            if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                            {
                                _year = s.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim();
                            }
                        }
                        else
                        if (s.IndexOf("<p>Players:") > -1)
                        {
                            int ipos1 = s.IndexOf(" ");
                            int ipos2 = s.IndexOf("</p>");
                            if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                            {
                                if (s.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("8"))
                                {
                                    _players = "8";
                                }
                                else
                                if (s.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("5"))
                                {
                                    _players = "5";
                                }
                                else
                                if (s.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("4"))
                                {
                                    _players = "4";
                                }
                                else
                                if (s.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("2"))
                                {
                                    _players = "2";
                                }
                                else
                                {
                                    _players = "1";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        private void doScrapePsxDataCenter(String sHtmlContent)
        {
            try
            {
                using (StringReader reader = new StringReader(sHtmlContent))
                {
                    //
                    String s = String.Empty;
                    String sAdd = String.Empty;
                    bool bOfficialTitle = false;
                    bool bPublisher = false;
                    bool bDeveloper = false;
                    bool bYear = false;
                    bool bPlayers = false;
                    bool bMultitap = false;
                    while ((s = reader.ReadLine()) != null)
                    {
                        s = s.Trim();
                        s = s.Replace("&nbsp;", " ");
                        s = s.Replace("&amp;", "&");
                        s = s.Replace("  ", " ");
                        if (bOfficialTitle)
                        {
                            sAdd += s;
                            if (sAdd.IndexOf("</td>") > -1)
                            {
                                int ipos1 = sAdd.IndexOf(">");
                                int ipos2 = sAdd.IndexOf("</td>");
                                if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                                {
                                    _title = sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim();
                                    bOfficialTitle = false;
                                    sAdd = String.Empty;
                                }
                            }
                        }
                        else
                        if (bPublisher)
                        {
                            sAdd += s;
                            if (sAdd.IndexOf("</td>") > -1)
                            {
                                int ipos1 = sAdd.LastIndexOf("> ");
                                int ipos2 = sAdd.IndexOf("</td>");
                                if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                                {
                                    String sPub = sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim();
                                    if (sPub.EndsWith("."))
                                    {
                                        sPub = sPub.Substring(0, sPub.Length - 1);
                                    }
                                    _publisher = sPub;
                                    bPublisher = false;
                                    sAdd = String.Empty;
                                }
                            }
                        }
                        else
                        if (bDeveloper)
                        {
                            sAdd += s;
                            if (sAdd.IndexOf("</td>") > -1)
                            {
                                int ipos1 = sAdd.LastIndexOf("> ");
                                int ipos2 = sAdd.IndexOf("</td>");
                                if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                                {
                                    String sDev = sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim();
                                    if (sDev.EndsWith("."))
                                    {
                                        sDev = sDev.Substring(0, sDev.Length - 1);
                                    }
                                    _developer = sDev;
                                    bDeveloper = false;
                                    sAdd = String.Empty;
                                }
                            }
                        }
                        else
                        if (bYear)
                        {
                            sAdd += s;
                            if (sAdd.IndexOf("</td>") > -1)
                            {
                                int ipos1 = sAdd.LastIndexOf(" ");
                                int ipos2 = sAdd.IndexOf("</td>");
                                if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                                {
                                    _year = sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim();
                                    bYear = false;
                                    sAdd = String.Empty;
                                }
                            }
                        }
                        else
                        if (bPlayers)
                        {
                            sAdd += s;
                            if (sAdd.IndexOf("</td>") > -1)
                            {
                                int ipos1 = sAdd.IndexOf(">");
                                int ipos2 = sAdd.IndexOf("</td>");
                                if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                                {
                                    if (sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("8"))
                                    {
                                        _players = "8";
                                    }
                                    else
                                    if (sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("5"))
                                    {
                                        _players = "5";
                                    }
                                    else
                                    if (sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("4"))
                                    {
                                        _players = "4";
                                    }
                                    else
                                    if (sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("2"))
                                    {
                                        _players = "2";
                                    }
                                    else
                                    {
                                        _players = "1";
                                    }
                                    bPlayers = false;
                                    sAdd = String.Empty;
                                }
                            }
                        }
                        else
                        if(bMultitap)
                        {
                            sAdd += s;
                            if (sAdd.IndexOf("</td>") > -1)
                            {
                                if (sAdd.ToLower().Trim().Contains("yes"))
                                {
                                    int ipos1 = sAdd.IndexOf(">");
                                    int ipos2 = sAdd.IndexOf("</td>");
                                    if ((ipos1 > -1) && (ipos2 > -1) && (ipos2 > ipos1))
                                    {
                                        if (sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("8"))
                                        {
                                            _players = "8";
                                        }
                                        else
                                        if (sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("5"))
                                        {
                                            _players = "5";
                                        }
                                        else
                                        if (sAdd.Substring(ipos1 + 1, ipos2 - ipos1 - 1).Trim().Contains("4"))
                                        {
                                            _players = "4";
                                        }
                                        bMultitap = false;
                                        sAdd = String.Empty;
                                    }
                                }
                                else
                                {
                                    bMultitap = false;
                                    sAdd = String.Empty;
                                }
                            }
                        }
                        else
                        if (s.StartsWith("Official Title"))
                        {
                            bOfficialTitle = true;
                        }
                        else
                        if (s.StartsWith("Publisher"))
                        {
                            bPublisher = true;
                        }
                        else
                        if (s.StartsWith("Developer"))
                        {
                            bDeveloper = true;
                        }
                        else
                        if (s.StartsWith("Date Released"))
                        {
                            bYear = true;
                        }
                        else
                        if (s.StartsWith("Number Of Players"))
                        {
                            bPlayers = true;
                        }
                        else
                        if(s.StartsWith("Multi-Tap Function Compatible"))
                        {
                            bMultitap = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}
