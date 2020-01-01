using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace pbPSCReAlpha
{
    public class ClDBManager
    {
        public class ClDiscTable
        {
            private int _disc_id;
            private int _game_id;
            private int _disc_number; // not the total count, the current number of this disc !
            private String _basename;

            public int Disc_id { get => _disc_id; set => _disc_id = value; }
            public int Game_id { get => _game_id; set => _game_id = value; }
            public int Disc_number { get => _disc_number; set => _disc_number = value; }
            public string Basename { get => _basename; set => _basename = value; }

            public ClDiscTable(int iGameId, int iDiscNb, String sBasename)
            {
                _game_id = iGameId;
                _disc_number = iDiscNb;
                _basename = sBasename;
            }

            public SQLiteCommand generateInsertCommand(SQLiteConnection conn)
            {
                SQLiteCommand s = new SQLiteCommand("INSERT INTO DISC"
                    + " (GAME_ID, DISC_NUMBER, BASENAME)"
                    + " VALUES (@p1, @p2, @p3)", conn);
                s.Parameters.Add("@p1", System.Data.DbType.Int32).Value = _game_id;
                s.Parameters.Add("@p2", System.Data.DbType.Int32).Value = _disc_number;
                s.Parameters.Add("@p3", System.Data.DbType.String).Value = _basename;
                return s;
            }
        }

        public class ClFolderEntriesTable
        {
            private int _folder_id;
            private String _folder_name;
            private String _folder_image_path;

            public int Folder_id { get => _folder_id; set => _folder_id = value; }
            public string Folder_name { get => _folder_name; set => _folder_name = value; }
            public string Folder_image_path { get => _folder_image_path; set => _folder_image_path = value; }
            
            public ClFolderEntriesTable(int iFolderId, String sFoldername, String sImgPath)
            {
                _folder_id = iFolderId;
                _folder_name = sFoldername;
                _folder_image_path = sImgPath;
            }
            
            public SQLiteCommand generateInsertCommand(SQLiteConnection conn)
            {
                SQLiteCommand s = new SQLiteCommand("INSERT INTO FOLDER_ENTRIES"
                    + " (FOLDER_ID, FOLDER_NAME, FOLDER_IMAGE_PATH)"
                    + " VALUES (@p1, @p2, @p3)", conn);
                s.Parameters.Add("@p1", System.Data.DbType.Int32).Value = _folder_id;
                s.Parameters.Add("@p2", System.Data.DbType.String).Value = _folder_name;
                s.Parameters.Add("@p3", System.Data.DbType.String).Value = _folder_image_path;
                return s;
            }

            public SQLiteCommand BleemSyncUI_generateInsertCommand(SQLiteConnection conn)
            {
                SQLiteCommand s = new SQLiteCommand("INSERT INTO FolderNodes"
                    + " (Id, Name, ImagePath)"
                    + " VALUES (@p1, @p2, @p3)", conn);
                s.Parameters.Add("@p1", System.Data.DbType.Int32).Value = _folder_id;
                s.Parameters.Add("@p2", System.Data.DbType.String).Value = _folder_name;
                s.Parameters.Add("@p3", System.Data.DbType.String).Value = _folder_image_path;
                return s;
            }
        }

        public class ClFolderItemsTable
        {
            private int _folder_id;
            private int _game_id;

            public int Folder_id { get => _folder_id; set => _folder_id = value; }
            public int Game_id { get => _game_id; set => _game_id = value; }

            public ClFolderItemsTable(int iFolderId, int iGameId)
            {
                _folder_id = iFolderId;
                _game_id = iGameId;
            }
            
            public SQLiteCommand generateInsertCommand(SQLiteConnection conn)
            {
                SQLiteCommand s = new SQLiteCommand("INSERT INTO FOLDER_ITEMS"
                    + " (FOLDER_ID, GAME_ID)"
                    + " VALUES (@p1, @p2)", conn);
                s.Parameters.Add("@p1", System.Data.DbType.Int32).Value = _folder_id;
                s.Parameters.Add("@p2", System.Data.DbType.Int32).Value = _game_id;
                return s;
            }

            public SQLiteCommand BleemSyncUI_generateInsertCommand(SQLiteConnection conn)
            {
                SQLiteCommand s = new SQLiteCommand("INSERT INTO FolderItems"
                    + " (FolderId, NodeId)"
                    + " VALUES (@p1, @p2)", conn);
                s.Parameters.Add("@p1", System.Data.DbType.Int32).Value = _folder_id;
                s.Parameters.Add("@p2", System.Data.DbType.Int32).Value = _game_id;
                return s;
            }
        }

        public class ClGameTable
        {
            private int _game_id;
            private String _game_title_string;
            private String _publisher_name;
            private int _release_year;
            private int _players;
            private String _rating_image;
            private String _game_manual_qr_image;
            private String _link_game_id;

            // bs1.0.0
            private int _position;

            // ab0.6.0
            private String _path;
            private String _sspath;
            private String _memcard;
            
            public int Game_id { get => _game_id; set => _game_id = value; }
            public string Game_title_string { get => _game_title_string; set => _game_title_string = value; }
            public string Publisher_name { get => _publisher_name; set => _publisher_name = value; }
            public int Release_year { get => _release_year; set => _release_year = value; }
            public int Players { get => _players; set => _players = value; }
            public string Rating_image { get => _rating_image; set => _rating_image = value; }
            public string Game_manual_qr_image { get => _game_manual_qr_image; set => _game_manual_qr_image = value; }
            public string Link_game_id { get => _link_game_id; set => _link_game_id = value; }

            public int Position { get => _position; set => _position = value; }

            public string Path { get => _path; set => _path = value; }
            public string Sspath { get => _sspath; set => _sspath = value; }
            public string Memcard { get => _memcard; set => _memcard = value; }

            public ClGameTable(ClGameStructure cgs)
            {
                _game_title_string = cgs.Title;
                _publisher_name = cgs.Publisher;
                try
                {
                    _release_year = int.Parse(cgs.Year);
                }
                catch(Exception ex)
                {
                    _release_year = 1995;
                }
                try
                {
                    _players = int.Parse(cgs.Players);
                }
                catch(Exception ex)
                {
                    _players = 1;
                }
                _rating_image = "CERO_A";
                _game_manual_qr_image = "QR_Code_GM";
                _link_game_id = String.Empty;

                _position = 0;

                _path = "/media/Games/" + cgs.FolderIndex + "/";
                _sspath = "/media/Games/!SaveStates/" + cgs.FolderIndex + "/";
                _memcard = "SONY";
            }

            public SQLiteCommand generateInsertCommand(SQLiteConnection conn, int bs_version, int game_id)
            {
                _game_id = game_id;
                SQLiteCommand s = null;
                switch (bs_version)
                {
                    case Constant.iBLEEMSYNC_V041:
                    case Constant.iSTRUCT_INTERNAL:
                        s = new SQLiteCommand("INSERT INTO GAME"
                            + " (GAME_ID, GAME_TITLE_STRING, PUBLISHER_NAME, RELEASE_YEAR, PLAYERS, RATING_IMAGE, GAME_MANUAL_QR_IMAGE, LINK_GAME_ID)"
                            + " VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7)", conn);
                        s.Parameters.Add("@p0", System.Data.DbType.Int32).Value = _game_id;
                        s.Parameters.Add("@p1", System.Data.DbType.String).Value = _game_title_string;
                        s.Parameters.Add("@p2", System.Data.DbType.String).Value = _publisher_name;
                        s.Parameters.Add("@p3", System.Data.DbType.Int32).Value = _release_year;
                        s.Parameters.Add("@p4", System.Data.DbType.Int32).Value = _players;
                        s.Parameters.Add("@p5", System.Data.DbType.String).Value = _rating_image;
                        s.Parameters.Add("@p6", System.Data.DbType.String).Value = _game_manual_qr_image;
                        s.Parameters.Add("@p7", System.Data.DbType.String).Value = _link_game_id;
                        break;
                    case Constant.iBLEEMSYNC_V100:
                    case Constant.iBLEEMSYNC_V120:
                        s = new SQLiteCommand("INSERT INTO MENU_ENTRIES"
                            + " (GAME_ID, GAME_TITLE_STRING, PUBLISHER_NAME, RELEASE_YEAR, PLAYERS, RATING_IMAGE, GAME_MANUAL_QR_IMAGE, LINK_GAME_ID, POSITION)"
                            + " VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", conn);
                        s.Parameters.Add("@p0", System.Data.DbType.Int32).Value = _game_id;
                        s.Parameters.Add("@p1", System.Data.DbType.String).Value = _game_title_string;
                        s.Parameters.Add("@p2", System.Data.DbType.String).Value = _publisher_name;
                        s.Parameters.Add("@p3", System.Data.DbType.Int32).Value = _release_year;
                        s.Parameters.Add("@p4", System.Data.DbType.Int32).Value = _players;
                        s.Parameters.Add("@p5", System.Data.DbType.String).Value = _rating_image;
                        s.Parameters.Add("@p6", System.Data.DbType.String).Value = _game_manual_qr_image;
                        s.Parameters.Add("@p7", System.Data.DbType.String).Value = _link_game_id;
                        s.Parameters.Add("@p8", System.Data.DbType.Int32).Value = _position;
                        break;
                    case Constant.iAUTOBLEEM_V06:
                    case Constant.iAUTOBLEEM_V08:
                        s = new SQLiteCommand("INSERT INTO GAME"
                            + " (GAME_ID, GAME_TITLE_STRING, PUBLISHER_NAME, RELEASE_YEAR, PLAYERS, RATING_IMAGE, GAME_MANUAL_QR_IMAGE, LINK_GAME_ID, PATH, SSPATH, MEMCARD)"
                            + " VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10)", conn);
                        s.Parameters.Add("@p0", System.Data.DbType.Int32).Value = _game_id;
                        s.Parameters.Add("@p1", System.Data.DbType.String).Value = _game_title_string;
                        s.Parameters.Add("@p2", System.Data.DbType.String).Value = _publisher_name;
                        s.Parameters.Add("@p3", System.Data.DbType.Int32).Value = _release_year;
                        s.Parameters.Add("@p4", System.Data.DbType.Int32).Value = _players;
                        s.Parameters.Add("@p5", System.Data.DbType.String).Value = _rating_image;
                        s.Parameters.Add("@p6", System.Data.DbType.String).Value = _game_manual_qr_image;
                        s.Parameters.Add("@p7", System.Data.DbType.String).Value = _link_game_id;
                        s.Parameters.Add("@p8", System.Data.DbType.String).Value = _path;
                        s.Parameters.Add("@p9", System.Data.DbType.String).Value = _sspath;
                        s.Parameters.Add("@p10", System.Data.DbType.String).Value = _memcard;
                        break;
                }
                return s;
            }
        }

        public class ClLanguageSpecific
        {
            private int _language_id;
            private String _default_value;
            private String _value;

            public int Language_id { get => _language_id; set => _language_id = value; }
            public string Default_value { get => _default_value; set => _default_value = value; }
            public string Value { get => _value; set => _value = value; }
        }

        public class ClSqliteSequence
        {
            private String _name;
            private int _seq;

            public string Name { get => _name; set => _name = value; }
            public int Seq { get => _seq; set => _seq = value; }
        }

        public class ClEFMMigrationsHistory
        {
            private String _migration_id;
            private String _product_version;

            public string Migration_id { get => _migration_id; set => _migration_id = value; }
            public string Product_version { get => _product_version; set => _product_version = value; }
        }
        
        public class ClGameGenre
        {
            private int _id;
            private String _name;
            private int _game_manager_node_id;

            public int Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }
            public int Game_manager_node_id { get => _game_manager_node_id; set => _game_manager_node_id = value; }
        }

        public class ClGameManagerFiles
        {
            private int _id;
            private String _name;
            private String _path;
            private int _node_id;

            public int Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }
            public string Path { get => _path; set => _path = value; }
            public int Node_id { get => _node_id; set => _node_id = value; }

            public ClGameManagerFiles(String sName, String sPath, int iNode)
            {
                _name = sName;
                _path = sPath;
                _node_id = iNode;
            }

            public SQLiteCommand generateInsertCommand(SQLiteConnection conn)
            {
                SQLiteCommand s = new SQLiteCommand("INSERT INTO GameManagerFiles"
                    + " (Name, Path, NodeId)"
                    + " VALUES (@p1, @p2, @p3)", conn);
                s.Parameters.Add("@p1", System.Data.DbType.String).Value = _name;
                s.Parameters.Add("@p2", System.Data.DbType.String).Value = _path;
                s.Parameters.Add("@p3", System.Data.DbType.Int32).Value = _node_id;
                return s;
            }
        }

        public class ClGameManagerNodes
        {
            private int _id;
            private String _name;
            private String _sort_name;
            private String _description;
            private String _release_date;
            private int _players;
            private String _developer;
            private String _publisher;
            private int _type;
            private int _system_id;
            private int parent_id;
            private int _position;

            public int Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }
            public string Sort_name { get => _sort_name; set => _sort_name = value; }
            public string Description { get => _description; set => _description = value; }
            public string Release_date { get => _release_date; set => _release_date = value; }
            public int Players { get => _players; set => _players = value; }
            public string Developer { get => _developer; set => _developer = value; }
            public string Publisher { get => _publisher; set => _publisher = value; }
            public int Type { get => _type; set => _type = value; }
            public int System_id { get => _system_id; set => _system_id = value; }
            public int Parent_id { get => parent_id; set => parent_id = value; }
            public int Position { get => _position; set => _position = value; }

            public ClGameManagerNodes(ClGameStructure cgs)
            {
                _name = cgs.Title;
                if(!String.IsNullOrEmpty(cgs.Alphatitle))
                {
                    _sort_name = cgs.Alphatitle;
                }
                else
                {
                    _sort_name = cgs.Title;
                }
                try
                {
                    _release_date = int.Parse(cgs.Year).ToString() + "-01-02 03:04:05";
                }
                catch(Exception ex)
                {
                    _release_date = "1995-01-01 05:12:00";
                }
                _developer = cgs.Developer;
                _publisher = cgs.Publisher;
                try
                {
                    _players = int.Parse(cgs.Players);
                }
                catch(Exception ex)
                {
                    _players = 1;
                }
                _type = 1;
                _position = 0;
            }

            public SQLiteCommand generateInsertCommand(SQLiteConnection conn)
            {
                SQLiteCommand s = new SQLiteCommand("INSERT INTO GameManagerNodes"
                    + " (Name, SortName, ReleaseDate, Players, Publisher, Type, Position)"
                    + " VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", conn);
                s.Parameters.Add("@p1", System.Data.DbType.String).Value = _name;
                s.Parameters.Add("@p2", System.Data.DbType.String).Value = _sort_name;
                s.Parameters.Add("@p3", System.Data.DbType.String).Value = _release_date;
                s.Parameters.Add("@p4", System.Data.DbType.Int32).Value = _players;
                s.Parameters.Add("@p5", System.Data.DbType.String).Value = _publisher;
                s.Parameters.Add("@p6", System.Data.DbType.Int32).Value = _type;
                s.Parameters.Add("@p7", System.Data.DbType.Int32).Value = _position;
                return s;
            }
        }

        public class ClGameMeta
        {
            private int _id;
            private String _key;
            private String _value;
            private String _type;
            private int _game_id;

            public int Id { get => _id; set => _id = value; }
            public string Key { get => _key; set => _key = value; }
            public string Value { get => _value; set => _value = value; }
            public string Type { get => _type; set => _type = value; }
            public int Game_id { get => _game_id; set => _game_id = value; }
        }

        public class ClGameSystem
        {
            private int _id;
            private String _name;

            public int Id { get => _id; set => _id = value; }
            public string Name { get => _name; set => _name = value; }
        }
        
        public class ClSubdirGamesToDisplayOnRowTable
        {
            // AB 0.8
            /*CREATE TABLE SUBDIR_GAMES_TO_DISPLAY_ON_ROW ( SUBDIR_ROW_INDEX integer, GAME_ID integer )*/
            private int _game_id;
            private int _subdir_row_id;

            public int Subdir_row_id { get => _subdir_row_id; set => _subdir_row_id = value; }
            public int Game_id { get => _game_id; set => _game_id = value; }

            public ClSubdirGamesToDisplayOnRowTable(int iGameId)
            {
                _subdir_row_id = 0;
                _game_id = iGameId;
            }

            public SQLiteCommand generateInsertCommand(SQLiteConnection conn)
            {
                SQLiteCommand s = new SQLiteCommand("INSERT INTO SUBDIR_GAMES_TO_DISPLAY_ON_ROW"
                    + " (SUBDIR_ROW_INDEX, GAME_ID)"
                    + " VALUES (@p1, @p2)", conn);
                s.Parameters.Add("@p1", System.Data.DbType.Int32).Value = _subdir_row_id;
                s.Parameters.Add("@p2", System.Data.DbType.Int32).Value = _game_id;
                return s;
            }
        }

        public class ClSubdirRowsTable
        {
            // AB 0.8
            /*CREATE TABLE SUBDIR_ROWS ( SUBDIR_ROW_INDEX integer NOT NULL UNIQUE, SUBDIR_ROW_NAME text, INDENT_LEVEL integer, NUM_GAMES integer, PRIMARY KEY ( SUBDIR_ROW_INDEX ) )*/
            private int _subdir_row_id;
            private String _subdir_row_name;
            private int _indent_level;
            private int _num_games;

            public int Subdir_row_id { get => _subdir_row_id; set => _subdir_row_id = value; }
            public string Subdir_row_name { get => _subdir_row_name; set => _subdir_row_name = value; }
            public int Indent_level { get => _indent_level; set => _indent_level = value; }
            public int Num_games { get => _num_games; set => _num_games = value; }

            public ClSubdirRowsTable(int iSubdirRowId, String sSubdirRowName, int iIndentLevel, int iNumGames)
            {
                _subdir_row_id = iSubdirRowId;
                _subdir_row_name = sSubdirRowName;
                _indent_level = iIndentLevel;
                _num_games = iNumGames;
            }

            public SQLiteCommand generateInsertCommand(SQLiteConnection conn)
            {
                SQLiteCommand s = new SQLiteCommand("INSERT INTO SUBDIR_ROWS"
                    + " (SUBDIR_ROW_INDEX, SUBDIR_ROW_NAME, INDENT_LEVEL, NUM_GAMES)"
                    + " VALUES (@p1, @p2, @p3, @p4)", conn);
                s.Parameters.Add("@p1", System.Data.DbType.Int32).Value = _subdir_row_id;
                s.Parameters.Add("@p2", System.Data.DbType.String).Value = _subdir_row_name;
                s.Parameters.Add("@p3", System.Data.DbType.Int32).Value = _indent_level;
                s.Parameters.Add("@p4", System.Data.DbType.Int32).Value = _num_games;
                return s;
            }
        }


        private bool _bDone;

        public bool BDone { get => _bDone; set => _bDone = value; }
        SimpleLogger slLogger;

        public static List<ClUIFolder> ReadDBFolder(String sFilename, int bleemsyncVersion, SimpleLogger slLogger)
        {
            List<ClUIFolder> lFoldersFromDB = new List<ClUIFolder>();
            Dictionary<int, List<int>> dcListGamesInFoldersFromDB = new Dictionary<int, List<int>>();

            String cs = "URI=file:" + sFilename;
            using (SQLiteConnection con = new SQLiteConnection(cs))
            {
                try
                {
                    con.Open();
                    string stm = "SELECT * FROM FOLDER_ITEMS ORDER BY FOLDER_ID ASC";
                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int iFolderId = int.Parse(rdr["FOLDER_ID"].ToString().Trim());
                                int iGameId = int.Parse(rdr["GAME_ID"].ToString().Trim());
                                if (!dcListGamesInFoldersFromDB.ContainsKey(iFolderId))
                                {
                                    dcListGamesInFoldersFromDB.Add(iFolderId, new List<int>());
                                }
                                dcListGamesInFoldersFromDB[iFolderId].Add(iGameId);
                            }
                        }
                    }

                    stm = "SELECT * FROM FOLDER_ENTRIES ORDER BY FOLDER_ID ASC";
                    using (SQLiteCommand cmd = new SQLiteCommand(stm, con))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                int iId = int.Parse(rdr["FOLDER_ID"].ToString().Trim());
                                if (dcListGamesInFoldersFromDB.ContainsKey(iId))
                                {
                                    lFoldersFromDB.Add(new ClUIFolder(rdr["FOLDER_NAME"].ToString().Trim(), dcListGamesInFoldersFromDB[iId], rdr["FOLDER_IMAGE_PATH"].ToString().Trim()));
                                }
                                else
                                {
                                    lFoldersFromDB.Add(new ClUIFolder(rdr["FOLDER_NAME"].ToString().Trim(), new List<int>(), rdr["FOLDER_IMAGE_PATH"].ToString().Trim()));
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    slLogger.Fatal(ex.Message);
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                    SQLiteConnection.ClearAllPools();
                }
            }
            return lFoldersFromDB;
        }

        public static bool AutoBleem_CreateFiles(List<ClGameStructure> lcgs, String sFolderPath, ClVersionHelper cvh, SimpleLogger sl, int bs_version)
        {
            bool bDone = false;
            try
            {
                //String sFolderBase = sFolderPath.Substring(0, sFolderPath.LastIndexOf('\\'));
                //String sFilename = sFolderBase + cvh.DbFolder + "\\" + "BleemSync.db";
                String sFilename1 = sFolderPath + cvh.CfgFolder + "\\" + "autobleem.prev";
                String sFilename2 = sFolderPath + cvh.CfgFolder + "\\" + "autobleem.list";

                // autobleem 0.8
                String sFilename3 = sFolderPath + cvh.CfgFolder + "\\" + "duplicateGames.txt";
                String sFilename4 = sFolderPath + cvh.CfgFolder + "\\" + "gameHierarchy_afterScanAndRemovingDuplicates.txt";
                String sFilename5 = sFolderPath + cvh.CfgFolder + "\\" + "gameHierarchy_beforeScan.txt";
                String sFilename6 = sFolderPath + cvh.CfgFolder + "\\" + "gamesThatFailedVerifyCheck.txt";

                if (!Directory.Exists(sFolderPath + cvh.CfgFolder))
                {
                    Directory.CreateDirectory(sFolderPath + cvh.CfgFolder);
                }
                CreateBakFile(sFilename1);
                CreateBakFile(sFilename2);
                if (bs_version == Constant.iAUTOBLEEM_V08)
                {
                    CreateBakFile(sFilename3);
                    CreateBakFile(sFilename4);
                    CreateBakFile(sFilename5);
                    CreateBakFile(sFilename6);
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sFilename3))
                        {
                            sw.WriteLine("");
                        }
                        using (StreamWriter sw = new StreamWriter(sFilename6))
                        {
                            sw.WriteLine("");
                        }
                    }
                    catch (Exception ex)
                    {
                        sl.Fatal(ex.Message);
                    }
                }

                List<String> lsFolders = new List<string>();
                DirectoryInfo[] dirList = new DirectoryInfo(sFolderPath).GetDirectories("*", SearchOption.TopDirectoryOnly);
                foreach (DirectoryInfo di in dirList)
                {
                    //slLogger.Debug("** Directory: " + di.FullName);
                    String sFolderIndex = di.FullName.Substring(sFolderPath.Length);
                    if (sFolderIndex.StartsWith("\\"))
                    {
                        sFolderIndex = sFolderIndex.Substring(1);
                    }
                    String[] s2 = sFolderIndex.Split('\\');
                    sFolderIndex = s2[0];
                    if ((sFolderIndex != "!SaveStates") && (sFolderIndex != "!MemCards"))
                    {
                        lsFolders.Add(sFolderIndex);
                    }
                } // foreach
                using (NaturalComparer comparer = new NaturalComparer())
                {
                    lsFolders.Sort(comparer); // really useful here ?
                }
                if (lsFolders.Count > 0)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sFilename1))
                        {
                            foreach (String s in lsFolders)
                            {
                                if (bs_version == Constant.iAUTOBLEEM_V08)
                                {
                                    sw.Write("/media/Games/" + s + "\n"); // writeline puts \r\n
                                }
                                else
                                {
                                    sw.Write(s + "\n"); // writeline puts \r\n
                                }
                            }
                        }
                        using (StreamWriter sw = new StreamWriter(sFilename2))
                        {
                            int i = 1;
                            foreach (String s in lsFolders)
                            {
                                sw.Write(i.ToString() + ",/media/Games/" + s + ",/media/Games/!SaveStates/" + s + "\n"); // writeline puts \r\n
                                i++;
                            }
                        }
                        if (bs_version == Constant.iAUTOBLEEM_V08)
                        {
/*Games in each row
0: Games (4 games)
      31
      32
      33
      34


Games to display in each row
0: Games (4 games)
      31
      32
      33
      34
*/
                            using (StreamWriter sw = new StreamWriter(sFilename4))
                            {
                                sw.Write("Games in each row" + "\n");
                                sw.Write("0: Games (" + lsFolders.Count + " games)" + "\n");
                                foreach (String s in lsFolders)
                                {
                                    sw.Write("      " + s + "\n"); // writeline puts \r\n
                                }
                                sw.Write("\n\n");
                                sw.Write("Games to display in each row" + "\n");
                                sw.Write("0: Games (" + lsFolders.Count + " games)" + "\n");
                                foreach (String s in lsFolders)
                                {
                                    sw.Write("      " + s + "\n"); // writeline puts \r\n
                                }
                            }
                            using (StreamWriter sw = new StreamWriter(sFilename5))
                            {
                                sw.Write("Games in each row" + "\n");
                                sw.Write("0: Games(" + lsFolders.Count + " games)" + "\n");
                                foreach (String s in lsFolders)
                                {
                                    sw.Write("      " + s + "\n"); // writeline puts \r\n
                                }
                                sw.Write("\n\n");
                                sw.Write("Games to display in each row" + "\n");
                                sw.Write("0: Games(" + lsFolders.Count + " games)" + "\n");
                                foreach (String s in lsFolders)
                                {
                                    sw.Write("      " + s + "\n"); // writeline puts \r\n
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        sl.Fatal(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sFilename1))
                        {
                            sw.WriteLine("");
                        }
                        using (StreamWriter sw = new StreamWriter(sFilename2))
                        {
                            sw.WriteLine("");
                        }
                    }
                    catch (Exception ex)
                    {
                        sl.Fatal(ex.Message);
                    }
                }
                bDone = true;
            }
            catch(Exception ex)
            {
                bDone = false;
                sl.Fatal(ex.Message);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return bDone;
        }

        private static void CreateBakFile(string sFilename)
        {
            if (File.Exists(sFilename))
            {
                if (File.Exists(sFilename + ".bak"))
                {
                    File.Delete(sFilename + ".bak");
                    Thread.Sleep(100);
                }
                File.Move(sFilename, sFilename + ".bak");
                Thread.Sleep(100);
            }
        }

        public static bool BleemSyncUI_AddDB(List<ClGameStructure> lcgs, String sFolderPath, ClVersionHelper cvh, SimpleLogger sl, int bs_version, List<ClUIFolder> lFolders)
        {
            bool bDone = false;
            try
            {
                //String sFolderBase = sFolderPath.Substring(0, sFolderPath.LastIndexOf('\\'));
                //String sFilename = sFolderBase + cvh.DbFolder + "\\" + "BleemSync.db";
                String sFilename = sFolderPath + cvh.DbFolder + "\\" + "BleemSync.db";
                if (!Directory.Exists(sFolderPath + cvh.DbFolder))
                {
                    Directory.CreateDirectory(sFolderPath + cvh.DbFolder);
                }
                if (File.Exists(sFilename))
                {
                    if (File.Exists(sFilename + ".bak"))
                    {
                        File.Delete(sFilename + ".bak");
                        Thread.Sleep(100);
                    }
                    File.Move(sFilename, sFilename + ".bak");
                    Thread.Sleep(100);
                }
                SQLiteConnection.CreateFile(sFilename);
                using (SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + sFilename + ";Version=3;"))
                {
                    try
                    {
                        SQLiteCommand command;
                        m_dbConnection.Open();

                        String sql = String.Empty;
                        using (var tran = m_dbConnection.BeginTransaction())
                        {
                            sql = "CREATE TABLE \"GameGenre\" ( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_GameGenre\" PRIMARY KEY AUTOINCREMENT, \"Name\" TEXT NULL, \"GameManagerNodeId\" INTEGER NULL, CONSTRAINT \"FK_GameGenre_GameManagerNodes_GameManagerNodeId\" FOREIGN KEY (\"GameManagerNodeId\") REFERENCES \"GameManagerNodes\" (\"Id\") ON DELETE RESTRICT )";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE TABLE \"GameManagerFiles\"( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_GameManagerFiles\" PRIMARY KEY AUTOINCREMENT, \"Name\" TEXT NULL, \"Path\" TEXT NULL, \"NodeId\" INTEGER NOT NULL, CONSTRAINT \"FK_GameManagerFiles_GameManagerNodes_NodeId\" FOREIGN KEY (\"NodeId\") REFERENCES \"GameManagerNodes\"(\"Id\") ON DELETE CASCADE )";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE TABLE \"GameManagerNodes\"( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_GameManagerNodes\" PRIMARY KEY AUTOINCREMENT, \"Name\" TEXT NULL, \"SortName\" TEXT NULL, \"Description\" TEXT NULL, \"ReleaseDate\" TEXT NULL, \"Players\" INTEGER NULL, \"Developer\" TEXT NULL, \"Publisher\" TEXT NULL, \"Type\" INTEGER NOT NULL, \"SystemId\" INTEGER NULL, \"ParentId\" INTEGER NULL, \"Position\" INTEGER NOT NULL DEFAULT 0, CONSTRAINT \"FK_GameManagerNodes_GameManagerNodes_ParentId\" FOREIGN KEY (\"ParentId\") REFERENCES \"GameManagerNodes\"(\"Id\") ON DELETE RESTRICT, CONSTRAINT \"FK_GameManagerNodes_GameSystem_SystemId\" FOREIGN KEY (\"SystemId\") REFERENCES \"GameSystem\"(\"Id\") ON DELETE RESTRICT )";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE TABLE \"GameMeta\"( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_GameMeta\" PRIMARY KEY AUTOINCREMENT, \"Key\" TEXT NULL, \"Value\" TEXT NULL, \"Type\" TEXT NULL, \"GameId\" INTEGER NULL, CONSTRAINT \"FK_GameMeta_GameManagerNodes_GameId\" FOREIGN KEY (\"GameId\") REFERENCES \"GameManagerNodes\"(\"Id\") ON DELETE RESTRICT )";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE TABLE \"GameSystem\"( \"Id\" INTEGER NOT NULL CONSTRAINT \"PK_GameSystem\" PRIMARY KEY AUTOINCREMENT, \"Name\" INTEGER NOT NULL )";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE TABLE \"__EFMigrationsHistory\"( \"MigrationId\" TEXT NOT NULL CONSTRAINT \"PK___EFMigrationsHistory\" PRIMARY KEY, \"ProductVersion\" TEXT NOT NULL )";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE INDEX \"IX_GameGenre_GameManagerNodeId\" ON \"GameGenre\" (\"GameManagerNodeId\")";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE INDEX \"IX_GameManagerFiles_NodeId\" ON \"GameManagerFiles\" (\"NodeId\")";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE INDEX \"IX_GameManagerNodes_ParentId\" ON \"GameManagerNodes\" (\"ParentId\")";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE INDEX \"IX_GameManagerNodes_SystemId\" ON \"GameManagerNodes\" (\"SystemId\")";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE INDEX \"IX_GameMeta_GameId\" ON \"GameMeta\" (\"GameId\")";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();

                            tran.Commit();
                        }
                        if (lcgs.Count > 0)
                        {
                            using (var tran = m_dbConnection.BeginTransaction())
                            {
                                // INSERT INTO GameManagerFiles Name Game.ini Path /media/games/1/Game.ini NodeId 1
                                // INSERT INTO GameManagerNodes Name Chrono Cross SortName Chrono Cross ReleaseDate 2000-01-01 00:00:00 Players 1 Publisher Squaresoft Type 1 Position 0

                                int iGame = 0;
                                foreach (ClGameStructure cgs in lcgs)
                                {
                                    int iNode = int.Parse(cgs.FolderIndex);
                                    foreach (String s in cgs.Filenames)
                                    {
                                        ClGameManagerFiles cgmf = new ClGameManagerFiles(s, "/media/games/" + iNode.ToString() + "/" + s, iNode);
                                        command = cgmf.generateInsertCommand(m_dbConnection);
                                        command.ExecuteNonQuery();
                                    }
                                    iGame++;
                                    ClGameManagerNodes cgmn = new ClGameManagerNodes(cgs);
                                    cgmn.Position = iGame;
                                    command = cgmn.generateInsertCommand(m_dbConnection);
                                    command.ExecuteNonQuery();
                                }

                                sql = "INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20190116023850_Seed', '2.1.1-rtm-30846')";
                                command = new SQLiteCommand(sql, m_dbConnection);
                                command.ExecuteNonQuery();
                                sql = "INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20190116024555_AddOrderingPosition', '2.1.1-rtm-30846')";
                                command = new SQLiteCommand(sql, m_dbConnection);
                                command.ExecuteNonQuery();
                                // ADD 1.2
                                if (bs_version == Constant.iBLEEMSYNC_V120)
                                {
                                    sql = "INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20190624000000_Folders', '2.1.1-rtm-30846')";
                                    command = new SQLiteCommand(sql, m_dbConnection);
                                    command.ExecuteNonQuery();
                                    sql = "CREATE TABLE \"FolderNodes\" ( \"Id\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, \"Name\" TEXT NOT NULL, \"ImagePath\" TEXT NOT NULL )";
                                    command = new SQLiteCommand(sql, m_dbConnection);
                                    command.ExecuteNonQuery();
                                    sql = "CREATE TABLE \"FolderItems\" ( \"FolderId\" INTEGER NOT NULL, \"NodeId\" INTEGER NOT NULL, FOREIGN KEY(\"FolderId\") REFERENCES \"FolderNodes\"(\"Id\") ON DELETE CASCADE, FOREIGN KEY(\"NodeId\") REFERENCES \"GameManagerNodes\"(\"Id\") ON DELETE CASCADE, UNIQUE(\"FolderId\", \"NodeId\"))";
                                    command = new SQLiteCommand(sql, m_dbConnection);
                                    command.ExecuteNonQuery();
                                    if(lFolders != null)
                                    {
                                        if (lFolders.Count > 0)
                                        {
                                            int iFolderIndex = 1;
                                            foreach (ClUIFolder cuif in lFolders)
                                            {
                                                ClFolderEntriesTable cfet = new ClFolderEntriesTable(iFolderIndex, cuif.Title, cuif.Imgpath);
                                                command = cfet.BleemSyncUI_generateInsertCommand(m_dbConnection);
                                                command.ExecuteNonQuery();
                                                if (cuif.ListGameIds.Count > 0)
                                                {
                                                    foreach (int iGameId in cuif.ListGameIds)
                                                    {
                                                        ClFolderItemsTable cfit = new ClFolderItemsTable(iFolderIndex, iGameId);
                                                        command = cfit.BleemSyncUI_generateInsertCommand(m_dbConnection);
                                                        command.ExecuteNonQuery();
                                                    }
                                                }
                                                iFolderIndex++;
                                            }
                                        }
                                    }
                                }

                                tran.Commit();
                            }
                        }
                        m_dbConnection.Close();
                        sl.Debug("Creating DB2 ok");
                        bDone = true;
                    }
                    catch (Exception ex)
                    {
                        bDone = false;
                        sl.Fatal(ex.Message);
                    }
                    finally
                    {
                        m_dbConnection.Dispose();
                        SQLiteConnection.ClearAllPools();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
            }
            catch (Exception ex)
            {
                bDone = false;
                sl.Fatal(ex.Message);
            }
            return bDone;
        }

        public static bool BleemSyncUI_AddDB(List<ClGameStructure> lcgs, String sFolderPath, ClVersionHelper cvh, SimpleLogger sl, int bs_version)
        {
            return BleemSyncUI_AddDB(lcgs, sFolderPath, cvh, sl, bs_version, null);
        }

        private void doBackupExistingFile(String sFilename)
        {
            if (File.Exists(sFilename))
            {
                if (File.Exists(sFilename + ".bak"))
                {
                    File.Delete(sFilename + ".bak");
                    Thread.Sleep(100);
                }
                File.Move(sFilename, sFilename + ".bak");
                Thread.Sleep(100);
            }
        }
        
        private bool doDBStructure(int bleemsyncVersion, SQLiteConnection sqlconn)
        {
            bool b = false;
            String sql = String.Empty;
            try
            {
                using (var tran = sqlconn.BeginTransaction())
                {
                    SQLiteCommand cmd;
                    switch (bleemsyncVersion)
                    {
                        case Constant.iBLEEMSYNC_V041: // bs0.4.1
                        case Constant.iSTRUCT_INTERNAL:
                            sql = "CREATE TABLE \"DISC\" ( \"DISC_ID\" INTEGER NOT NULL CONSTRAINT \"PK_DISC\" PRIMARY KEY AUTOINCREMENT, \"GAME_ID\" INTEGER NOT NULL, \"DISC_NUMBER\" INTEGER NOT NULL, \"BASENAME\" TEXT NULL, CONSTRAINT \"FK_DISC_GAME_GAME_ID\" FOREIGN KEY (\"GAME_ID\") REFERENCES \"GAME\" (\"GAME_ID\") ON DELETE CASCADE )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE \"GAME\" ( \"GAME_ID\" INTEGER NOT NULL CONSTRAINT \"PK_GAME\" PRIMARY KEY AUTOINCREMENT, \"GAME_TITLE_STRING\" TEXT NULL, \"PUBLISHER_NAME\" TEXT NULL, \"RELEASE_YEAR\" INTEGER NOT NULL, \"PLAYERS\" INTEGER NOT NULL, \"RATING_IMAGE\" TEXT NULL, \"GAME_MANUAL_QR_IMAGE\" TEXT NULL, \"LINK_GAME_ID\" TEXT NULL )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE \"LANGUAGE_SPECIFIC\"( \"LANGUAGE_ID\" TEXT NOT NULL CONSTRAINT \"PK_LANGUAGE_SPECIFIC\" PRIMARY KEY, \"DEFAULT_VALUE\" TEXT NULL, \"VALUE\" TEXT NULL )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE INDEX \"IX_DISC_GAME_ID\" ON \"DISC\"(\"GAME_ID\")";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            break;
                        case Constant.iBLEEMSYNC_V100: // bs1.0.0
                            sql = "CREATE TABLE \"DISC\" ( \"DISC_ID\" INTEGER NOT NULL CONSTRAINT \"PK_DISC\" PRIMARY KEY AUTOINCREMENT, \"GAME_ID\" INTEGER NOT NULL, \"DISC_NUMBER\" INTEGER NOT NULL, \"BASENAME\" TEXT NULL, CONSTRAINT \"FK_DISC_GAME_GAME_ID\" FOREIGN KEY (\"GAME_ID\") REFERENCES \"MENU_ENTRIES\" (\"GAME_ID\") ON DELETE CASCADE )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE \"MENU_ENTRIES\" ( \"GAME_ID\" INTEGER NOT NULL CONSTRAINT \"PK_GAME\" PRIMARY KEY AUTOINCREMENT, \"GAME_TITLE_STRING\" TEXT NULL, \"PUBLISHER_NAME\" TEXT NULL, \"RELEASE_YEAR\" INTEGER NOT NULL, \"PLAYERS\" INTEGER NOT NULL, \"RATING_IMAGE\" TEXT NULL, \"GAME_MANUAL_QR_IMAGE\" TEXT NULL, \"LINK_GAME_ID\" TEXT NULL , \"POSITION\" INTEGER NULL)";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE \"__EFMigrationsHistory\" ( \"MigrationId\" TEXT NOT NULL CONSTRAINT \"PK___EFMigrationsHistory\" PRIMARY KEY, \"ProductVersion\" TEXT NOT NULL )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE VIEW GAME AS SELECT * FROM MENU_ENTRIES ORDER BY POSITION, GAME_TITLE_STRING";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE \"LANGUAGE_SPECIFIC\"( \"LANGUAGE_ID\" TEXT NOT NULL CONSTRAINT \"PK_LANGUAGE_SPECIFIC\" PRIMARY KEY, \"DEFAULT_VALUE\" TEXT NULL, \"VALUE\" TEXT NULL )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE INDEX \"IX_DISC_GAME_ID\" ON \"DISC\"(\"GAME_ID\")";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20190115023630_Seed', '2.1.1-rtm-30846')";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            break;
                        case Constant.iBLEEMSYNC_V120: // bs1.2.0
                            sql = "CREATE TABLE \"DISC\" ( \"DISC_ID\" INTEGER NOT NULL CONSTRAINT \"PK_DISC\" PRIMARY KEY AUTOINCREMENT, \"GAME_ID\" INTEGER NOT NULL, \"DISC_NUMBER\" INTEGER NOT NULL, \"BASENAME\" TEXT NULL, CONSTRAINT \"FK_DISC_GAME_GAME_ID\" FOREIGN KEY (\"GAME_ID\") REFERENCES \"MENU_ENTRIES\" (\"GAME_ID\") ON DELETE CASCADE )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE \"MENU_ENTRIES\" ( \"GAME_ID\" INTEGER NOT NULL CONSTRAINT \"PK_GAME\" PRIMARY KEY AUTOINCREMENT, \"GAME_TITLE_STRING\" TEXT NULL, \"PUBLISHER_NAME\" TEXT NULL, \"RELEASE_YEAR\" INTEGER NOT NULL, \"PLAYERS\" INTEGER NOT NULL, \"RATING_IMAGE\" TEXT NULL, \"GAME_MANUAL_QR_IMAGE\" TEXT NULL, \"LINK_GAME_ID\" TEXT NULL , \"POSITION\" INTEGER NULL)";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE \"__EFMigrationsHistory\" ( \"MigrationId\" TEXT NOT NULL CONSTRAINT \"PK___EFMigrationsHistory\" PRIMARY KEY, \"ProductVersion\" TEXT NOT NULL )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE VIEW GAME AS SELECT * FROM MENU_ENTRIES ORDER BY POSITION, GAME_TITLE_STRING";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE \"LANGUAGE_SPECIFIC\"( \"LANGUAGE_ID\" TEXT NOT NULL CONSTRAINT \"PK_LANGUAGE_SPECIFIC\" PRIMARY KEY, \"DEFAULT_VALUE\" TEXT NULL, \"VALUE\" TEXT NULL )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE INDEX \"IX_DISC_GAME_ID\" ON \"DISC\"(\"GAME_ID\")";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20190115023630_Seed', '2.1.1-rtm-30846')";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            // ADD 1.2
                            sql = "INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20190624000000_Folders', '2.1.1-rtm-30846')";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE \"FOLDER_ENTRIES\" ( \"FOLDER_ID\" INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, \"FOLDER_NAME\" TEXT NOT NULL, \"FOLDER_IMAGE_PATH\" TEXT NOT NULL )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE \"FOLDER_ITEMS\" ( \"FOLDER_ID\" INTEGER NOT NULL, \"GAME_ID\" INTEGER NOT NULL, FOREIGN KEY(\"FOLDER_ID\") REFERENCES \"FOLDER_ENTRIES\"(\"FOLDER_ID\") ON DELETE CASCADE, FOREIGN KEY(\"GAME_ID\") REFERENCES \"MENU_ENTRIES\"(\"GAME_ID\") ON DELETE CASCADE, UNIQUE(\"FOLDER_ID\", \"GAME_ID\"))";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            break;
                        case Constant.iAUTOBLEEM_V06: // ab0.6.0
                            sql = "CREATE TABLE DISC ( [GAME_ID] integer, [DISC_NUMBER] integer, [BASENAME] text, UNIQUE ([GAME_ID], [DISC_NUMBER]) )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE GAME ( GAME_ID integer NOT NULL UNIQUE, GAME_TITLE_STRING text, PUBLISHER_NAME text, RELEASE_YEAR integer, PLAYERS integer, RATING_IMAGE text, GAME_MANUAL_QR_IMAGE text, LINK_GAME_ID integer, PATH text null, SSPATH text null, MEMCARD text null, PRIMARY KEY ( GAME_ID ) )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE LANGUAGE_SPECIFIC ( [DEFAULT_VALUE] text, [LANGUAGE_ID] integer, [VALUE] text, UNIQUE ([DEFAULT_VALUE], [LANGUAGE_ID]) )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            break;
                        case Constant.iAUTOBLEEM_V08: // ab0.8.5
                            sql = "CREATE TABLE DISC ( [GAME_ID] integer, [DISC_NUMBER] integer, [BASENAME] text, UNIQUE ([GAME_ID], [DISC_NUMBER]) )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE GAME ( GAME_ID integer NOT NULL UNIQUE, GAME_TITLE_STRING text, PUBLISHER_NAME text, RELEASE_YEAR integer, PLAYERS integer, RATING_IMAGE text, GAME_MANUAL_QR_IMAGE text, LINK_GAME_ID integer, PATH text null, SSPATH text null, MEMCARD text null, PRIMARY KEY ( GAME_ID ) )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE LANGUAGE_SPECIFIC ( [DEFAULT_VALUE] text, [LANGUAGE_ID] integer, [VALUE] text, UNIQUE ([DEFAULT_VALUE], [LANGUAGE_ID]) )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE SUBDIR_GAMES_TO_DISPLAY_ON_ROW ( SUBDIR_ROW_INDEX integer, GAME_ID integer )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            sql = "CREATE TABLE SUBDIR_ROWS ( SUBDIR_ROW_INDEX integer NOT NULL UNIQUE, SUBDIR_ROW_NAME text, INDENT_LEVEL integer, NUM_GAMES integer, PRIMARY KEY ( SUBDIR_ROW_INDEX ) )";
                            cmd = new SQLiteCommand(sql, sqlconn);
                            cmd.ExecuteNonQuery();
                            break;
                    }
                    tran.Commit();
                    b = true;
                }
            }
            catch(Exception ex)
            {
                b = false;
                slLogger.Fatal(ex.Message);
            }
            return b;
        }

        private bool doAddGamesInDB(List<ClGameStructure> lcgs, int bleemsyncVersion, SQLiteConnection sqlconn, int start)
        {
            bool b = false;
            String sql = String.Empty;
            try
            {
                using (var tran = sqlconn.BeginTransaction())
                {
                    SQLiteCommand cmd;
                    int iGame = start;
                    if (lcgs.Count > 0)
                    {
                        if (bleemsyncVersion == Constant.iAUTOBLEEM_V08)
                        {
                            ClSubdirRowsTable csrt = new ClSubdirRowsTable(0, "Games", 0, lcgs.Count);
                            cmd = csrt.generateInsertCommand(sqlconn);
                            cmd.ExecuteNonQuery();
                        }
                        foreach (ClGameStructure cgs in lcgs)
                        {
                            int iG1 = 1+iGame;
                            if (int.TryParse(cgs.FolderIndex, out iG1))
                            {
                                iGame = iG1;
                            }
                            else
                            {
                                iGame++;
                            }
                            ClGameTable cgt = new ClGameTable(cgs);
                            cgt.Position = iGame; // can't order in bleemsyncui if other than 0 for now
                            cmd = cgt.generateInsertCommand(sqlconn, bleemsyncVersion, iGame);
                            cmd.ExecuteNonQuery();
                            String[] sDiscSplit = cgs.Discs.Split(',');
                            int iDiscCount = sDiscSplit.Length;
                            int iDisc = 1;
                            foreach (String disc in sDiscSplit)
                            {
                                ClDiscTable cdt = new ClDiscTable(iGame, iDisc, disc);
                                cmd = cdt.generateInsertCommand(sqlconn);
                                cmd.ExecuteNonQuery();
                                iDisc++;
                            }
                            if(bleemsyncVersion == Constant.iAUTOBLEEM_V08)
                            {
                                ClSubdirGamesToDisplayOnRowTable csgtor = new ClSubdirGamesToDisplayOnRowTable(iGame);
                                cmd = csgtor.generateInsertCommand(sqlconn);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    tran.Commit();
                    b = true;
                }
            }
            catch (Exception ex)
            {
                b = false;
                slLogger.Fatal(ex.Message);
            }
            return b;
        }

        public ClDBManager(List<ClGameStructure> lcgs, String sFolderPath, int bleemsyncVersion, ClVersionHelper cvh, SimpleLogger sl, List<ClUIFolder> lFolders)
        {
            slLogger = sl;
            try
            {
                String sFilename = sFolderPath + cvh.DbFolder + "\\" + "regional.db";
                if (!Directory.Exists(sFolderPath + cvh.DbFolder))
                {
                    Directory.CreateDirectory(sFolderPath + cvh.DbFolder);
                }
                doBackupExistingFile(sFilename);
                
                SQLiteConnection.CreateFile(sFilename);
                using (SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + sFilename + ";Version=3;"))
                {
                    try
                    {
                        m_dbConnection.Open();

                        String sql = String.Empty;
                        _bDone = doDBStructure(bleemsyncVersion, m_dbConnection);
                        if(_bDone)
                        {
                            _bDone = doAddGamesInDB(lcgs, bleemsyncVersion, m_dbConnection, 0);
                        }
                        if(_bDone)
                        {
                            if(lFolders != null)
                            {
                                //
                                _bDone = doAddFoldersInDB(lFolders, bleemsyncVersion, m_dbConnection);
                            }
                        }
                        m_dbConnection.Close();
                        if(_bDone)
                            slLogger.Debug("Creating DB ok");
                    }
                    catch (Exception ex)
                    {
                        _bDone = false;
                        slLogger.Fatal(ex.Message);
                    }
                    finally
                    {
                        m_dbConnection.Dispose();
                        SQLiteConnection.ClearAllPools();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
                if (true == _bDone)
                {
                    if ((Constant.iBLEEMSYNC_V100 == bleemsyncVersion) || (Constant.iBLEEMSYNC_V120 == bleemsyncVersion))
                    {
                        // create the second db file
                        _bDone = BleemSyncUI_AddDB(lcgs, sFolderPath, cvh, sl, bleemsyncVersion, lFolders);
                    }
                    if ((Constant.iAUTOBLEEM_V06 == bleemsyncVersion) || (Constant.iAUTOBLEEM_V08 == bleemsyncVersion))
                    {
                        // create the files for autobleem in order to prevent a scan at start
                        _bDone = AutoBleem_CreateFiles(lcgs, sFolderPath, cvh, sl, bleemsyncVersion);
                    }
                }
            }
            catch (Exception ex)
            {
                slLogger.Fatal(ex.Message);
                _bDone = false;
            }
        }

        private bool doAddFoldersInDB(List<ClUIFolder> lFolders, int bleemsyncVersion, SQLiteConnection sqlconn)
        {
            bool b = false;
            String sql = String.Empty;
            try
            {
                if (bleemsyncVersion == Constant.iBLEEMSYNC_V120)
                {
                    using (var tran = sqlconn.BeginTransaction())
                    {
                        SQLiteCommand cmd;
                        if (lFolders.Count > 0)
                        {
                            int iFolderIndex = 1;
                            foreach (ClUIFolder cuif in lFolders)
                            {
                                ClFolderEntriesTable cfet = new ClFolderEntriesTable(iFolderIndex, cuif.Title, cuif.Imgpath);
                                cmd = cfet.generateInsertCommand(sqlconn);
                                cmd.ExecuteNonQuery();
                                if (cuif.ListGameIds.Count > 0)
                                {
                                    foreach (int iGameId in cuif.ListGameIds)
                                    {
                                        ClFolderItemsTable cfit = new ClFolderItemsTable(iFolderIndex, iGameId);
                                        cmd = cfit.generateInsertCommand(sqlconn);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                                iFolderIndex++;
                            }
                        }
                        tran.Commit();
                        b = true;
                    }
                }
                else
                {
                    b = true;
                }
            }
            catch (Exception ex)
            {
                b = false;
                slLogger.Fatal(ex.Message);
            }
            return b;
        }

        public ClDBManager(List<ClGameStructure> lcgs, String sFolderPath, int bleemsyncVersion, ClVersionHelper cvh, SimpleLogger sl)
            : this(lcgs, sFolderPath, bleemsyncVersion,cvh, sl, null)
        {
            
        }

        public ClDBManager(List<ClGameStructure> lcgs, String sFolderPath, int bleemsyncVersion, SimpleLogger sl, String sFullFileName)
            : this(lcgs, sFolderPath, bleemsyncVersion, sl, sFullFileName, 0)
        {
            
        }

        public ClDBManager(List<ClGameStructure> lcgs, String sFolderPath, int bleemsyncVersion, SimpleLogger sl, String sFullFileName, int iStart)
        {
            // with a filename (with path), in order to have multi db files for folders
            slLogger = sl;
            try
            {
                doBackupExistingFile(sFullFileName);

                SQLiteConnection.CreateFile(sFullFileName);
                using (SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + sFullFileName + ";Version=3;"))
                {
                    try
                    {
                        m_dbConnection.Open();

                        String sql = String.Empty;
                        _bDone = doDBStructure(bleemsyncVersion, m_dbConnection);
                        if (_bDone)
                        {
                            _bDone = doAddGamesInDB(lcgs, bleemsyncVersion, m_dbConnection, iStart);
                        }
                        m_dbConnection.Close();
                        if (_bDone)
                            slLogger.Debug("Creating DB " + sFullFileName + " ok");
                    }
                    catch (Exception ex)
                    {
                        _bDone = false;
                        slLogger.Fatal(ex.Message);
                    }
                    finally
                    {
                        m_dbConnection.Dispose();
                        SQLiteConnection.ClearAllPools();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }
                }
            }
            catch (Exception ex)
            {
                slLogger.Fatal(ex.Message);
                _bDone = false;
            }
        }
    }
}
