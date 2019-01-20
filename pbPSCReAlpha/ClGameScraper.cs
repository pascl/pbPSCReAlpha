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

        public ClGameScraper(String sHtml)
        {
            if (!String.IsNullOrEmpty(sHtml))
            {
                doScrape(sHtml);
            }
        }

        private String loadHtmlPage(String sLink)
        {
            String sHtml = String.Empty;
            return sHtml;
        }

        private void doScrape(String sHtmlContent)
        {
            try
            {
                String sImg = "<img border=\"0\" src=\"../../../images/covers/";

                using (StringReader reader = new StringReader(sHtmlContent))
                {
                    //
                    String s = String.Empty;
                    String sAdd = String.Empty;
                    bool bOfficialTitle = false;
                    bool bPublisher = false;
                    bool bYear = false;
                    bool bPlayers = false;
                    bool bMultitap = false;
                    while ((s = reader.ReadLine()) != null)
                    {
                        s = s.Trim();
                        s = s.Replace("&nbsp;", " ");
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
                        if (s.StartsWith(sImg))
                        {
                            //
                            _imgUrl = "http://psxdatacenter.com/images/covers/" + s.Substring(sImg.Length, s.IndexOf("\" width=") - sImg.Length);
                            /*
                            pbCover.LoadAsync("http://psxdatacenter.com/images/covers/" + s.Substring(sImg.Length, s.IndexOf("\" width=") - sImg.Length));
                            btSavePng.Enabled = true;
                            btLink.Enabled = true;
                            */
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
