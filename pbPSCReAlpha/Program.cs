using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace pbPSCReAlpha
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            bool bRunAForm = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Dictionary<string, ClPS1Game> dcPs1Games = new Dictionary<string, ClPS1Game>();
            Dictionary<string, ClTGDBGame> dcTgdbGames = new Dictionary<string, ClTGDBGame>();
            Dictionary<int, string> dcTgdbPlatforms = new Dictionary<int, string>();
            Dictionary<string, ClIGNGame> dcIgnGames = new Dictionary<string, ClIGNGame>();
            Dictionary<string, ClJVcomGame> dcJVcomGames = new Dictionary<string, ClJVcomGame>();

            try
            {
                using (XmlTextReader xmlreader = new XmlTextReader(Application.StartupPath + "\\" + "ps1games.xml"))
                {
                    String mykey = String.Empty;
                    String mylink = String.Empty;
                    String myvalue = String.Empty;
                    String mylang = String.Empty;
                    while (xmlreader.Read())
                    {
                        switch (xmlreader.NodeType)
                        {
                            case XmlNodeType.Element:
                                // Console.WriteLine(xmlreader.Name);
                                if ("game" == xmlreader.Name)
                                {
                                    while (xmlreader.MoveToNextAttribute())
                                    {
                                        // Console.Write(" " + xmlreader.Name + "='" + xmlreader.Value + "'");
                                        if ("serial" == xmlreader.Name)
                                        {
                                            mykey = xmlreader.Value;
                                        }
                                        else if ("link" == xmlreader.Name)
                                        {
                                            mylink = xmlreader.Value;
                                        }
                                        else if ("lang" == xmlreader.Name)
                                        {
                                            mylang = xmlreader.Value;
                                        }
                                    }
                                }
                                break;
                            case XmlNodeType.Text:
                                // Console.WriteLine(xmlreader.Value);
                                myvalue = xmlreader.Value;
                                if (!dcPs1Games.ContainsKey(mykey))
                                {
                                    dcPs1Games.Add(mykey, new ClPS1Game(myvalue, mykey, mylink, mylang));
                                    myvalue = String.Empty;
                                    mykey = String.Empty;
                                    mylink = String.Empty;
                                    mylang = String.Empty;
                                }
                                break;
                            case XmlNodeType.EndElement:
                                //
                                break;
                        }
                    }
                    //slLogger.Debug("Found games in xml for search function: " + dcPs1Games.Count.ToString());
                }
            }
            catch (Exception ex)
            {
                //slLogger.Fatal(ex.Message);
            }

            try
            {
                using (XmlTextReader xmlreader = new XmlTextReader(Application.StartupPath + "\\" + "tgdbplatforms.xml"))
                {
                    int mykey = 0;
                    String myvalue = String.Empty;
                    while (xmlreader.Read())
                    {
                        switch (xmlreader.NodeType)
                        {
                            case XmlNodeType.Element:
                                // Console.WriteLine(xmlreader.Name);
                                if ("platform" == xmlreader.Name)
                                {
                                    while (xmlreader.MoveToNextAttribute())
                                    {
                                        // Console.Write(" " + xmlreader.Name + "='" + xmlreader.Value + "'");
                                        if ("id" == xmlreader.Name)
                                        {
                                            try
                                            {
                                                int.TryParse(xmlreader.Value, out mykey);
                                            }
                                            catch (Exception exept)
                                            {
                                                //
                                                mykey = 0;
                                            }
                                        }
                                    }
                                }
                            break;
                            case XmlNodeType.Text:
                                // Console.WriteLine(xmlreader.Value);
                                myvalue = xmlreader.Value;
                                if (!dcTgdbPlatforms.ContainsKey(mykey))
                                {
                                    dcTgdbPlatforms.Add(mykey, myvalue);
                                    myvalue = String.Empty;
                                    mykey = 0;
                                }
                                break;
                            case XmlNodeType.EndElement:
                                //
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //slLogger.Fatal(ex.Message);
            }

            try
            {
                using (XmlTextReader xmlreader = new XmlTextReader(Application.StartupPath + "\\" + "tgdbgames.xml"))
                {
                    String mylink = String.Empty;
                    String myvalue = String.Empty;
                    String myplatform = String.Empty;
                    int iPlatform = 0;
                    while (xmlreader.Read())
                    {
                        switch (xmlreader.NodeType)
                        {
                            case XmlNodeType.Element:
                                // Console.WriteLine(xmlreader.Name);
                                if ("game" == xmlreader.Name)
                                {
                                    while (xmlreader.MoveToNextAttribute())
                                    {
                                        // Console.Write(" " + xmlreader.Name + "='" + xmlreader.Value + "'");
                                        if ("platform" == xmlreader.Name)
                                        {
                                            myplatform = xmlreader.Value;
                                        }
                                        else if ("id" == xmlreader.Name)
                                        {
                                            mylink = xmlreader.Value;
                                        }
                                    }
                                }
                                break;
                            case XmlNodeType.Text:
                                // Console.WriteLine(xmlreader.Value);
                                myvalue = xmlreader.Value;
                                if (!dcTgdbGames.ContainsKey(mylink))
                                {
                                    if (int.TryParse(myplatform, out iPlatform))
                                    {
                                        if (dcTgdbPlatforms.ContainsKey(iPlatform))
                                        {
                                            dcTgdbGames.Add(mylink, new ClTGDBGame(myvalue, mylink, myplatform, dcTgdbPlatforms));
                                            myvalue = String.Empty;
                                            mylink = String.Empty;
                                            myplatform = String.Empty;
                                            iPlatform = 0;
                                        }
                                    }
                                }
                                break;
                            case XmlNodeType.EndElement:
                                //
                                break;
                        }
                    }
                    //slLogger.Debug("Found games in xml for search function: " + dcPs1Games.Count.ToString());
                }
            }
            catch (Exception ex)
            {
                //slLogger.Fatal(ex.Message);
            }

            /*
            // parsing ign file. problem: can't be more than 5000 games for any letter through ign site. So there is a lot of missing games...
            try
            {
                using (XmlTextReader xmlreader = new XmlTextReader(Application.StartupPath + "\\" + "igngames.xml"))
                {
                    String mylink = String.Empty;
                    String myvalue = String.Empty;
                    String myplatform = String.Empty;
                    int iPlatform = 0;
                    while (xmlreader.Read())
                    {
                        switch (xmlreader.NodeType)
                        {
                            case XmlNodeType.Element:
                                // Console.WriteLine(xmlreader.Name);
                                if ("game" == xmlreader.Name)
                                {
                                    while (xmlreader.MoveToNextAttribute())
                                    {
                                        // Console.Write(" " + xmlreader.Name + "='" + xmlreader.Value + "'");
                                        if ("platform" == xmlreader.Name)
                                        {
                                            myplatform = xmlreader.Value;
                                        }
                                        else if ("link" == xmlreader.Name)
                                        {
                                            mylink = xmlreader.Value;
                                        }
                                    }
                                }
                                break;
                            case XmlNodeType.Text:
                                // Console.WriteLine(xmlreader.Value);
                                myvalue = xmlreader.Value;
                                if (!dcIgnGames.ContainsKey(mylink + " * " + myplatform))
                                {
                                    dcIgnGames.Add(mylink + " * " + myplatform, new ClIGNGame(myvalue, mylink, myplatform));
                                    myvalue = String.Empty;
                                    mylink = String.Empty;
                                    myplatform = String.Empty;
                                }
                                break;
                            case XmlNodeType.EndElement:
                                //
                                break;
                        }
                    }
                    //slLogger.Debug("Found games in xml for search function: " + dcPs1Games.Count.ToString());
                }
            }
            catch (Exception ex)
            {
                //slLogger.Fatal(ex.Message);
            }
            */

            if ((args != null) && (args.Length == 1))
            {
                if (args[0].Trim() == "-e")
                {
                    bRunAForm = true;
                    Application.Run(new Form23(Application.StartupPath, null, dcPs1Games, dcTgdbGames, dcIgnGames, dcJVcomGames, new ClVersionHelper("BleemSync v1.0.0", "", String.Empty, "..\\bleemsync\\etc\\bleemsync\\SYS\\databases", String.Empty, String.Empty)));
                }
                else
                if (args[0].Trim() == "-b")
                {
                    bRunAForm = true;
                    Application.Run(new Form7(dcPs1Games));
                }
                else
                if (args[0].Trim() == "-m")
                {
                    bRunAForm = true;
                    Application.Run(new Form8(null));
                }
            }
            if (!bRunAForm)
            {
                Application.Run(new Form1(dcPs1Games, dcTgdbGames, dcIgnGames, dcJVcomGames));
            }
            
            
        }
    }
}
