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

            if ((args != null) && (args.Length == 1))
            {
                if (args[0].Trim() == "-e")
                {
                    bRunAForm = true;
                    Application.Run(new Form23(Application.StartupPath, null, dcPs1Games, new ClVersionHelper("BleemSync v1.0.0", "", String.Empty, "..\\bleemsync\\etc\\bleemsync\\SYS\\databases", String.Empty)));
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
                Application.Run(new Form1(dcPs1Games));
            }
            
            
        }
    }
}
