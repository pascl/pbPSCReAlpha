﻿using System;
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
        String _year = "1995";
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

        private void doScrapeTGDB(String sHtmlContent)
        {
            try
            {
                String sImg = "src=\"https://cdn.thegamesdb.net/images/thumb/boxart/front/";

                using (StringReader reader = new StringReader(sHtmlContent))
                {
                    //
                    String s = String.Empty;
                    while ((s = reader.ReadLine()) != null)
                    {
                        s = s.Trim();
                        s = s.Replace("&nbsp;", " ");
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
                        else
                        if (s.Contains(sImg))
                        {
                            int pos1 = s.IndexOf(sImg);
                            String s1 = s.Substring(pos1 + sImg.Length, s.IndexOf("\"/>") - pos1 - sImg.Length);
                            _imgUrl = "https://cdn.thegamesdb.net/images/thumb/boxart/front/" + s.Substring(pos1 + sImg.Length, s.IndexOf("\"/>") - pos1 - sImg.Length);
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
                String sImg = "<img border=\"0\" src=\"../../../images/covers/";

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
