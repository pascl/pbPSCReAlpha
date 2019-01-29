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
            private int _disc_number;
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
            private int _position;

            public int Game_id { get => _game_id; set => _game_id = value; }
            public string Game_title_string { get => _game_title_string; set => _game_title_string = value; }
            public string Publisher_name { get => _publisher_name; set => _publisher_name = value; }
            public int Release_year { get => _release_year; set => _release_year = value; }
            public int Players { get => _players; set => _players = value; }
            public string Rating_image { get => _rating_image; set => _rating_image = value; }
            public string Game_manual_qr_image { get => _game_manual_qr_image; set => _game_manual_qr_image = value; }
            public string Link_game_id { get => _link_game_id; set => _link_game_id = value; }
            public int Position { get => _position; set => _position = value; }

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
            }

            public SQLiteCommand generateInsertCommand(SQLiteConnection conn, int bs_version)
            {
                SQLiteCommand s = null;
                switch (bs_version)
                {
                    case 0:
                        s = new SQLiteCommand("INSERT INTO GAME"
                            + " (GAME_TITLE_STRING, PUBLISHER_NAME, RELEASE_YEAR, PLAYERS, RATING_IMAGE, GAME_MANUAL_QR_IMAGE, LINK_GAME_ID)"
                            + " VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7)", conn);
                        s.Parameters.Add("@p1", System.Data.DbType.String).Value = _game_title_string;
                        s.Parameters.Add("@p2", System.Data.DbType.String).Value = _publisher_name;
                        s.Parameters.Add("@p3", System.Data.DbType.Int32).Value = _release_year;
                        s.Parameters.Add("@p4", System.Data.DbType.Int32).Value = _players;
                        s.Parameters.Add("@p5", System.Data.DbType.String).Value = _rating_image;
                        s.Parameters.Add("@p6", System.Data.DbType.String).Value = _game_manual_qr_image;
                        s.Parameters.Add("@p7", System.Data.DbType.String).Value = _link_game_id;
                        break;
                    case 1:
                        s = new SQLiteCommand("INSERT INTO MENU_ENTRIES"
                            + " (GAME_TITLE_STRING, PUBLISHER_NAME, RELEASE_YEAR, PLAYERS, RATING_IMAGE, GAME_MANUAL_QR_IMAGE, LINK_GAME_ID, POSITION)"
                            + " VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", conn);
                        s.Parameters.Add("@p1", System.Data.DbType.String).Value = _game_title_string;
                        s.Parameters.Add("@p2", System.Data.DbType.String).Value = _publisher_name;
                        s.Parameters.Add("@p3", System.Data.DbType.Int32).Value = _release_year;
                        s.Parameters.Add("@p4", System.Data.DbType.Int32).Value = _players;
                        s.Parameters.Add("@p5", System.Data.DbType.String).Value = _rating_image;
                        s.Parameters.Add("@p6", System.Data.DbType.String).Value = _game_manual_qr_image;
                        s.Parameters.Add("@p7", System.Data.DbType.String).Value = _link_game_id;
                        s.Parameters.Add("@p8", System.Data.DbType.Int32).Value = _position;
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

        private bool _bDone;

        public bool BDone { get => _bDone; set => _bDone = value; }
        SimpleLogger slLogger;

        public void BleemSyncUI_AddDB(List<ClGameStructure> lcgs, String sFolderPath, ClVersionHelper cvh, SimpleLogger sl)
        {
            try
            {
                String sFolderBase = sFolderPath.Substring(0, sFolderPath.LastIndexOf('\\'));
                String sFilename = sFolderBase + cvh.DbFolder + "\\" + "BleemSync.db";
                if (!Directory.Exists(sFolderBase + cvh.DbFolder))
                {
                    Directory.CreateDirectory(sFolderBase + cvh.DbFolder);
                }
                if (File.Exists(sFilename))
                {
                    File.Delete(sFilename);
                    Thread.Sleep(200);
                }
                SQLiteConnection.CreateFile(sFilename);
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + sFilename + ";Version=3;");
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

                    tran.Commit();
                }
                m_dbConnection.Close();
                slLogger.Debug("Creating DB2 ok");
                _bDone = true;
            }
            catch (Exception ex)
            {
                _bDone = false;
                slLogger.Fatal(ex.Message);
            }
        }

        public ClDBManager(List<ClGameStructure> lcgs, String sFolderPath, int bleemsyncVersion, ClVersionHelper cvh, SimpleLogger sl)
        {
            slLogger = sl;

            /*
             * 
             * 0.4.1 [0]
             * 
             * CREATE TABLE "DISC" ( "DISC_ID" INTEGER NOT NULL CONSTRAINT "PK_DISC" PRIMARY KEY AUTOINCREMENT, "GAME_ID" INTEGER NOT NULL, "DISC_NUMBER" INTEGER NOT NULL, "BASENAME" TEXT NULL, CONSTRAINT "FK_DISC_GAME_GAME_ID" FOREIGN KEY ("GAME_ID") REFERENCES "GAME" ("GAME_ID") ON DELETE CASCADE )
             * 
             * CREATE TABLE "GAME" ( "GAME_ID" INTEGER NOT NULL CONSTRAINT "PK_GAME" PRIMARY KEY AUTOINCREMENT, "GAME_TITLE_STRING" TEXT NULL, "PUBLISHER_NAME" TEXT NULL, "RELEASE_YEAR" INTEGER NOT NULL, "PLAYERS" INTEGER NOT NULL, "RATING_IMAGE" TEXT NULL, "GAME_MANUAL_QR_IMAGE" TEXT NULL, "LINK_GAME_ID" TEXT NULL )
             * 
             * 1.0.0 [1]
             * 
             * CREATE TABLE "DISC" ( "DISC_ID" INTEGER NOT NULL CONSTRAINT "PK_DISC" PRIMARY KEY AUTOINCREMENT, "GAME_ID" INTEGER NOT NULL, "DISC_NUMBER" INTEGER NOT NULL, "BASENAME" TEXT NULL, CONSTRAINT "FK_DISC_GAME_GAME_ID" FOREIGN KEY ("GAME_ID") REFERENCES "MENU_ENTRIES" ("GAME_ID") ON DELETE CASCADE )
             * 
             * CREATE TABLE "MENU_ENTRIES" ( "GAME_ID" INTEGER NOT NULL CONSTRAINT "PK_GAME" PRIMARY KEY AUTOINCREMENT, "GAME_TITLE_STRING" TEXT NULL, "PUBLISHER_NAME" TEXT NULL, "RELEASE_YEAR" INTEGER NOT NULL, "PLAYERS" INTEGER NOT NULL, "RATING_IMAGE" TEXT NULL, "GAME_MANUAL_QR_IMAGE" TEXT NULL, "LINK_GAME_ID" TEXT NULL , "POSITION" INTEGER NULL)
             * 
             * CREATE TABLE "__EFMigrationsHistory" ( "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY, "ProductVersion" TEXT NOT NULL )
             * 
             * CREATE VIEW GAME AS SELECT * FROM MENU_ENTRIES ORDER BY POSITION, GAME_TITLE_STRING
             * 
             * common
             * 
             * CREATE TABLE "LANGUAGE_SPECIFIC" ( "LANGUAGE_ID" TEXT NOT NULL CONSTRAINT "PK_LANGUAGE_SPECIFIC" PRIMARY KEY, "DEFAULT_VALUE" TEXT NULL, "VALUE" TEXT NULL )
             * 
             * CREATE TABLE sqlite_sequence(name,seq)
             * 
             * CREATE INDEX "IX_DISC_GAME_ID" ON "DISC" ("GAME_ID")
             * 
             */
            try
            {
                String sFolderBase = sFolderPath.Substring(0, sFolderPath.LastIndexOf('\\'));
                String sFilename = sFolderBase + cvh.DbFolder + "\\" + "regional.db";
                if(!Directory.Exists(sFolderBase + cvh.DbFolder))
                {
                    Directory.CreateDirectory(sFolderBase + cvh.DbFolder);
                }
                if(File.Exists(sFilename))
                {
                    File.Delete(sFilename);
                    Thread.Sleep(200);
                }
                SQLiteConnection.CreateFile(sFilename);
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=" + sFilename  + ";Version=3;");
                SQLiteCommand command;
                m_dbConnection.Open();

                String sql = String.Empty;

                using (var tran = m_dbConnection.BeginTransaction())
                {
                    switch (bleemsyncVersion)
                    {
                        case 0:
                            sql = "CREATE TABLE \"DISC\" ( \"DISC_ID\" INTEGER NOT NULL CONSTRAINT \"PK_DISC\" PRIMARY KEY AUTOINCREMENT, \"GAME_ID\" INTEGER NOT NULL, \"DISC_NUMBER\" INTEGER NOT NULL, \"BASENAME\" TEXT NULL, CONSTRAINT \"FK_DISC_GAME_GAME_ID\" FOREIGN KEY (\"GAME_ID\") REFERENCES \"GAME\" (\"GAME_ID\") ON DELETE CASCADE )";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE TABLE \"GAME\" ( \"GAME_ID\" INTEGER NOT NULL CONSTRAINT \"PK_GAME\" PRIMARY KEY AUTOINCREMENT, \"GAME_TITLE_STRING\" TEXT NULL, \"PUBLISHER_NAME\" TEXT NULL, \"RELEASE_YEAR\" INTEGER NOT NULL, \"PLAYERS\" INTEGER NOT NULL, \"RATING_IMAGE\" TEXT NULL, \"GAME_MANUAL_QR_IMAGE\" TEXT NULL, \"LINK_GAME_ID\" TEXT NULL )";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            break;
                        case 1:
                            sql = "CREATE TABLE \"DISC\" ( \"DISC_ID\" INTEGER NOT NULL CONSTRAINT \"PK_DISC\" PRIMARY KEY AUTOINCREMENT, \"GAME_ID\" INTEGER NOT NULL, \"DISC_NUMBER\" INTEGER NOT NULL, \"BASENAME\" TEXT NULL, CONSTRAINT \"FK_DISC_GAME_GAME_ID\" FOREIGN KEY (\"GAME_ID\") REFERENCES \"MENU_ENTRIES\" (\"GAME_ID\") ON DELETE CASCADE )";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE TABLE \"MENU_ENTRIES\" ( \"GAME_ID\" INTEGER NOT NULL CONSTRAINT \"PK_GAME\" PRIMARY KEY AUTOINCREMENT, \"GAME_TITLE_STRING\" TEXT NULL, \"PUBLISHER_NAME\" TEXT NULL, \"RELEASE_YEAR\" INTEGER NOT NULL, \"PLAYERS\" INTEGER NOT NULL, \"RATING_IMAGE\" TEXT NULL, \"GAME_MANUAL_QR_IMAGE\" TEXT NULL, \"LINK_GAME_ID\" TEXT NULL , \"POSITION\" INTEGER NULL)";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE TABLE \"__EFMigrationsHistory\" ( \"MigrationId\" TEXT NOT NULL CONSTRAINT \"PK___EFMigrationsHistory\" PRIMARY KEY, \"ProductVersion\" TEXT NOT NULL )";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            sql = "CREATE VIEW GAME AS SELECT * FROM MENU_ENTRIES ORDER BY POSITION, GAME_TITLE_STRING";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            break;
                    }
                    sql = "CREATE TABLE \"LANGUAGE_SPECIFIC\"( \"LANGUAGE_ID\" TEXT NOT NULL CONSTRAINT \"PK_LANGUAGE_SPECIFIC\" PRIMARY KEY, \"DEFAULT_VALUE\" TEXT NULL, \"VALUE\" TEXT NULL )";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();
                    /*sql = "CREATE TABLE sqlite_sequence(name,seq)";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();*/
                    sql = "CREATE INDEX \"IX_DISC_GAME_ID\" ON \"DISC\"(\"GAME_ID\")";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();

                    tran.Commit();
                }
                using (var tran = m_dbConnection.BeginTransaction())
                {
                    String sTableUsedForGames = String.Empty;
                    switch (bleemsyncVersion)
                    {
                        case 0:
                            break;
                        case 1:
                            sql = "INSERT INTO __EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20190115023630_Seed', '2.1.1-rtm-30846')";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                            break;
                    }
                    int iGame = 0;
                    foreach (ClGameStructure cgs in lcgs)
                    {
                        iGame++;
                        ClGameTable cgt = new ClGameTable(cgs);
                        //cgt.Position = iGame; // can't order in bleemsyncui if other than 0 for now
                        command = cgt.generateInsertCommand(m_dbConnection, bleemsyncVersion);
                        command.ExecuteNonQuery();
                        String[] sDiscSplit = cgs.Discs.Split(',');
                        int iDiscCount = sDiscSplit.Length;
                        foreach (String disc in sDiscSplit)
                        {
                            ClDiscTable cdt = new ClDiscTable(iGame, iDiscCount, disc);
                            command = cdt.generateInsertCommand(m_dbConnection);
                            command.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                m_dbConnection.Close();
                slLogger.Debug("Creating DB ok");
                _bDone = true;
                if (1 == bleemsyncVersion)
                {
                    // create the second db file
                    BleemSyncUI_AddDB(lcgs, sFolderPath, cvh, sl);
                }
            }
            catch(Exception ex)
            {
                slLogger.Fatal(ex.Message);
                _bDone = false;
            }
        }
    }
}
