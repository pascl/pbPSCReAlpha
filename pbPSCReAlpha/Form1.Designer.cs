namespace pbPSCReAlpha
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.fbdGamesFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControlAll = new System.Windows.Forms.TabControl();
            this.tabExplorer = new System.Windows.Forms.TabPage();
            this.lbFreeSpace = new System.Windows.Forms.Label();
            this.gbExploreEdit = new System.Windows.Forms.GroupBox();
            this.gbAutoRename = new System.Windows.Forms.GroupBox();
            this.tbFolderPath = new System.Windows.Forms.TextBox();
            this.gbExploreDetails = new System.Windows.Forms.GroupBox();
            this.lbFolderSizeLabel = new System.Windows.Forms.Label();
            this.lbFolderSize = new System.Windows.Forms.Label();
            this.tbErrString = new System.Windows.Forms.TextBox();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.ilFlags = new System.Windows.Forms.ImageList(this.components);
            this.lbExploreAlphaTitle = new System.Windows.Forms.Label();
            this.lbExploreYear = new System.Windows.Forms.Label();
            this.lbExplorePlayers = new System.Windows.Forms.Label();
            this.lbExplorePublisher = new System.Windows.Forms.Label();
            this.lbExploreDiscs = new System.Windows.Forms.Label();
            this.lbExploreTitle = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbGames = new System.Windows.Forms.ListBox();
            this.tabTransform = new System.Windows.Forms.TabPage();
            this.gbTransform = new System.Windows.Forms.GroupBox();
            this.tabConfig = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btIniFileCopy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCurrentSimultaneousCopiedFiles = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btValidateCfg = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSimultaneousCopiedFiles = new System.Windows.Forms.ComboBox();
            this.btCheckMemCard = new System.Windows.Forms.Button();
            this.btCheckBin = new System.Windows.Forms.Button();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.btClearLog = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.tbLogDebug = new System.Windows.Forms.TextBox();
            this.tabReadMe = new System.Windows.Forms.TabPage();
            this.wbReadme = new System.Windows.Forms.WebBrowser();
            this.ofdAddFiles = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveImage = new System.Windows.Forms.SaveFileDialog();
            this.tmRefreshFolder = new System.Windows.Forms.Timer(this.components);
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiBSVersionItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBSv041 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBSv100 = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdLoadDatabaseFile = new System.Windows.Forms.OpenFileDialog();
            this.btLaunchPngquant = new System.Windows.Forms.Button();
            this.btLaunchBleemsync = new System.Windows.Forms.Button();
            this.btM3uGenerate = new System.Windows.Forms.Button();
            this.btPbpRename = new System.Windows.Forms.Button();
            this.btSbiRename = new System.Windows.Forms.Button();
            this.btPngRename = new System.Windows.Forms.Button();
            this.btBinRename = new System.Windows.Forms.Button();
            this.btCueRename = new System.Windows.Forms.Button();
            this.btOpenFolder = new System.Windows.Forms.Button();
            this.btRefreshFolderOnly = new System.Windows.Forms.Button();
            this.btAddFiles = new System.Windows.Forms.Button();
            this.btEditCue = new System.Windows.Forms.Button();
            this.btAddPcsxCfg = new System.Windows.Forms.Button();
            this.btEditGameIni = new System.Windows.Forms.Button();
            this.btNewFolder = new System.Windows.Forms.Button();
            this.btReSort = new System.Windows.Forms.Button();
            this.btCrowseGamesFolder = new System.Windows.Forms.Button();
            this.pbExploreImage = new System.Windows.Forms.PictureBox();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btReadBS100Database = new System.Windows.Forms.Button();
            this.btReadBS041Database = new System.Windows.Forms.Button();
            this.btUpgradeFolders = new System.Windows.Forms.Button();
            this.btDowngradeFolders = new System.Windows.Forms.Button();
            this.tabControlAll.SuspendLayout();
            this.tabExplorer.SuspendLayout();
            this.gbExploreEdit.SuspendLayout();
            this.gbAutoRename.SuspendLayout();
            this.gbExploreDetails.SuspendLayout();
            this.tabTransform.SuspendLayout();
            this.gbTransform.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.tabReadMe.SuspendLayout();
            this.msMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExploreImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAll
            // 
            this.tabControlAll.Controls.Add(this.tabExplorer);
            this.tabControlAll.Controls.Add(this.tabTransform);
            this.tabControlAll.Controls.Add(this.tabConfig);
            this.tabControlAll.Controls.Add(this.tabDebug);
            this.tabControlAll.Controls.Add(this.tabReadMe);
            this.tabControlAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAll.Location = new System.Drawing.Point(0, 24);
            this.tabControlAll.Name = "tabControlAll";
            this.tabControlAll.SelectedIndex = 0;
            this.tabControlAll.Size = new System.Drawing.Size(704, 603);
            this.tabControlAll.TabIndex = 6;
            this.tabControlAll.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlAll_Selected);
            // 
            // tabExplorer
            // 
            this.tabExplorer.Controls.Add(this.btLaunchPngquant);
            this.tabExplorer.Controls.Add(this.lbFreeSpace);
            this.tabExplorer.Controls.Add(this.btLaunchBleemsync);
            this.tabExplorer.Controls.Add(this.gbExploreEdit);
            this.tabExplorer.Controls.Add(this.btNewFolder);
            this.tabExplorer.Controls.Add(this.btReSort);
            this.tabExplorer.Controls.Add(this.btCrowseGamesFolder);
            this.tabExplorer.Controls.Add(this.tbFolderPath);
            this.tabExplorer.Controls.Add(this.gbExploreDetails);
            this.tabExplorer.Controls.Add(this.lbGames);
            this.tabExplorer.Controls.Add(this.btRefresh);
            this.tabExplorer.Location = new System.Drawing.Point(4, 22);
            this.tabExplorer.Name = "tabExplorer";
            this.tabExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.tabExplorer.Size = new System.Drawing.Size(696, 577);
            this.tabExplorer.TabIndex = 2;
            this.tabExplorer.Text = "Explorer";
            this.tabExplorer.UseVisualStyleBackColor = true;
            // 
            // lbFreeSpace
            // 
            this.lbFreeSpace.Location = new System.Drawing.Point(339, 16);
            this.lbFreeSpace.Name = "lbFreeSpace";
            this.lbFreeSpace.Size = new System.Drawing.Size(102, 16);
            this.lbFreeSpace.TabIndex = 11;
            this.lbFreeSpace.Text = "--";
            this.lbFreeSpace.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gbExploreEdit
            // 
            this.gbExploreEdit.Controls.Add(this.btM3uGenerate);
            this.gbExploreEdit.Controls.Add(this.gbAutoRename);
            this.gbExploreEdit.Controls.Add(this.btOpenFolder);
            this.gbExploreEdit.Controls.Add(this.btRefreshFolderOnly);
            this.gbExploreEdit.Controls.Add(this.btAddFiles);
            this.gbExploreEdit.Controls.Add(this.btEditCue);
            this.gbExploreEdit.Controls.Add(this.btAddPcsxCfg);
            this.gbExploreEdit.Controls.Add(this.btEditGameIni);
            this.gbExploreEdit.Location = new System.Drawing.Point(206, 415);
            this.gbExploreEdit.Name = "gbExploreEdit";
            this.gbExploreEdit.Size = new System.Drawing.Size(484, 155);
            this.gbExploreEdit.TabIndex = 9;
            this.gbExploreEdit.TabStop = false;
            this.gbExploreEdit.Text = "Edit";
            // 
            // gbAutoRename
            // 
            this.gbAutoRename.Controls.Add(this.btPbpRename);
            this.gbAutoRename.Controls.Add(this.btSbiRename);
            this.gbAutoRename.Controls.Add(this.btPngRename);
            this.gbAutoRename.Controls.Add(this.btBinRename);
            this.gbAutoRename.Controls.Add(this.btCueRename);
            this.gbAutoRename.Location = new System.Drawing.Point(40, 95);
            this.gbAutoRename.Name = "gbAutoRename";
            this.gbAutoRename.Size = new System.Drawing.Size(438, 54);
            this.gbAutoRename.TabIndex = 11;
            this.gbAutoRename.TabStop = false;
            this.gbAutoRename.Text = "Auto-Rename";
            this.gbAutoRename.Visible = false;
            // 
            // tbFolderPath
            // 
            this.tbFolderPath.Location = new System.Drawing.Point(447, 12);
            this.tbFolderPath.Name = "tbFolderPath";
            this.tbFolderPath.Size = new System.Drawing.Size(160, 20);
            this.tbFolderPath.TabIndex = 5;
            this.tbFolderPath.Text = "F:\\Games";
            this.tbFolderPath.Leave += new System.EventHandler(this.tbFolderPath_Leave);
            // 
            // gbExploreDetails
            // 
            this.gbExploreDetails.Controls.Add(this.lbFolderSizeLabel);
            this.gbExploreDetails.Controls.Add(this.lbFolderSize);
            this.gbExploreDetails.Controls.Add(this.tbErrString);
            this.gbExploreDetails.Controls.Add(this.lvFiles);
            this.gbExploreDetails.Controls.Add(this.lbExploreAlphaTitle);
            this.gbExploreDetails.Controls.Add(this.lbExploreYear);
            this.gbExploreDetails.Controls.Add(this.lbExplorePlayers);
            this.gbExploreDetails.Controls.Add(this.lbExplorePublisher);
            this.gbExploreDetails.Controls.Add(this.lbExploreDiscs);
            this.gbExploreDetails.Controls.Add(this.lbExploreTitle);
            this.gbExploreDetails.Controls.Add(this.label14);
            this.gbExploreDetails.Controls.Add(this.label13);
            this.gbExploreDetails.Controls.Add(this.label12);
            this.gbExploreDetails.Controls.Add(this.label11);
            this.gbExploreDetails.Controls.Add(this.label10);
            this.gbExploreDetails.Controls.Add(this.label9);
            this.gbExploreDetails.Controls.Add(this.pbExploreImage);
            this.gbExploreDetails.Location = new System.Drawing.Point(206, 34);
            this.gbExploreDetails.Name = "gbExploreDetails";
            this.gbExploreDetails.Size = new System.Drawing.Size(484, 375);
            this.gbExploreDetails.TabIndex = 4;
            this.gbExploreDetails.TabStop = false;
            this.gbExploreDetails.Text = "Details";
            // 
            // lbFolderSizeLabel
            // 
            this.lbFolderSizeLabel.AutoSize = true;
            this.lbFolderSizeLabel.Location = new System.Drawing.Point(360, 156);
            this.lbFolderSizeLabel.Name = "lbFolderSizeLabel";
            this.lbFolderSizeLabel.Size = new System.Drawing.Size(60, 13);
            this.lbFolderSizeLabel.TabIndex = 19;
            this.lbFolderSizeLabel.Text = "Folder size:";
            this.lbFolderSizeLabel.Visible = false;
            // 
            // lbFolderSize
            // 
            this.lbFolderSize.Location = new System.Drawing.Point(419, 156);
            this.lbFolderSize.Name = "lbFolderSize";
            this.lbFolderSize.Size = new System.Drawing.Size(60, 13);
            this.lbFolderSize.TabIndex = 18;
            this.lbFolderSize.Text = "---";
            this.lbFolderSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbFolderSize.Visible = false;
            // 
            // tbErrString
            // 
            this.tbErrString.Location = new System.Drawing.Point(6, 289);
            this.tbErrString.Multiline = true;
            this.tbErrString.Name = "tbErrString";
            this.tbErrString.ReadOnly = true;
            this.tbErrString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbErrString.Size = new System.Drawing.Size(473, 80);
            this.tbErrString.TabIndex = 17;
            // 
            // lvFiles
            // 
            this.lvFiles.AllowDrop = true;
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.GridLines = true;
            this.lvFiles.LabelEdit = true;
            this.lvFiles.LargeImageList = this.ilFlags;
            this.lvFiles.Location = new System.Drawing.Point(6, 175);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(473, 108);
            this.lvFiles.SmallImageList = this.ilFlags;
            this.lvFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvFiles.StateImageList = this.ilFlags;
            this.lvFiles.TabIndex = 16;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.List;
            this.lvFiles.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvFiles_AfterLabelEdit);
            this.lvFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragDrop);
            this.lvFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvFiles_DragEnter);
            this.lvFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvFiles_KeyDown);
            // 
            // ilFlags
            // 
            this.ilFlags.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilFlags.ImageStream")));
            this.ilFlags.TransparentColor = System.Drawing.Color.Transparent;
            this.ilFlags.Images.SetKeyName(0, "question.png");
            this.ilFlags.Images.SetKeyName(1, "ok.png");
            this.ilFlags.Images.SetKeyName(2, "ko.png");
            this.ilFlags.Images.SetKeyName(3, "warning.png");
            this.ilFlags.Images.SetKeyName(4, "information.png");
            // 
            // lbExploreAlphaTitle
            // 
            this.lbExploreAlphaTitle.AutoSize = true;
            this.lbExploreAlphaTitle.Location = new System.Drawing.Point(225, 129);
            this.lbExploreAlphaTitle.Name = "lbExploreAlphaTitle";
            this.lbExploreAlphaTitle.Size = new System.Drawing.Size(10, 13);
            this.lbExploreAlphaTitle.TabIndex = 15;
            this.lbExploreAlphaTitle.Text = "-";
            // 
            // lbExploreYear
            // 
            this.lbExploreYear.AutoSize = true;
            this.lbExploreYear.Location = new System.Drawing.Point(225, 107);
            this.lbExploreYear.Name = "lbExploreYear";
            this.lbExploreYear.Size = new System.Drawing.Size(10, 13);
            this.lbExploreYear.TabIndex = 14;
            this.lbExploreYear.Text = "-";
            // 
            // lbExplorePlayers
            // 
            this.lbExplorePlayers.AutoSize = true;
            this.lbExplorePlayers.Location = new System.Drawing.Point(225, 85);
            this.lbExplorePlayers.Name = "lbExplorePlayers";
            this.lbExplorePlayers.Size = new System.Drawing.Size(10, 13);
            this.lbExplorePlayers.TabIndex = 13;
            this.lbExplorePlayers.Text = "-";
            // 
            // lbExplorePublisher
            // 
            this.lbExplorePublisher.AutoSize = true;
            this.lbExplorePublisher.Location = new System.Drawing.Point(225, 63);
            this.lbExplorePublisher.Name = "lbExplorePublisher";
            this.lbExplorePublisher.Size = new System.Drawing.Size(10, 13);
            this.lbExplorePublisher.TabIndex = 12;
            this.lbExplorePublisher.Text = "-";
            // 
            // lbExploreDiscs
            // 
            this.lbExploreDiscs.AutoSize = true;
            this.lbExploreDiscs.Location = new System.Drawing.Point(225, 41);
            this.lbExploreDiscs.Name = "lbExploreDiscs";
            this.lbExploreDiscs.Size = new System.Drawing.Size(10, 13);
            this.lbExploreDiscs.TabIndex = 11;
            this.lbExploreDiscs.Text = "-";
            // 
            // lbExploreTitle
            // 
            this.lbExploreTitle.AutoSize = true;
            this.lbExploreTitle.Location = new System.Drawing.Point(225, 19);
            this.lbExploreTitle.Name = "lbExploreTitle";
            this.lbExploreTitle.Size = new System.Drawing.Size(10, 13);
            this.lbExploreTitle.TabIndex = 10;
            this.lbExploreTitle.Text = "-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(162, 129);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "AlphaTitle:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(162, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Year:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(162, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Players:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(162, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Publisher:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(162, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Discs:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(162, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Title:";
            // 
            // lbGames
            // 
            this.lbGames.FormattingEnabled = true;
            this.lbGames.Location = new System.Drawing.Point(3, 34);
            this.lbGames.Name = "lbGames";
            this.lbGames.ScrollAlwaysVisible = true;
            this.lbGames.Size = new System.Drawing.Size(197, 485);
            this.lbGames.TabIndex = 1;
            this.lbGames.SelectedIndexChanged += new System.EventHandler(this.lbGames_SelectedIndexChanged);
            this.lbGames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbGames_KeyDown);
            // 
            // tabTransform
            // 
            this.tabTransform.Controls.Add(this.gbTransform);
            this.tabTransform.Location = new System.Drawing.Point(4, 22);
            this.tabTransform.Name = "tabTransform";
            this.tabTransform.Padding = new System.Windows.Forms.Padding(3);
            this.tabTransform.Size = new System.Drawing.Size(696, 577);
            this.tabTransform.TabIndex = 5;
            this.tabTransform.Text = "Transformer";
            this.tabTransform.UseVisualStyleBackColor = true;
            // 
            // gbTransform
            // 
            this.gbTransform.Controls.Add(this.btReadBS100Database);
            this.gbTransform.Controls.Add(this.btReadBS041Database);
            this.gbTransform.Controls.Add(this.btUpgradeFolders);
            this.gbTransform.Controls.Add(this.btDowngradeFolders);
            this.gbTransform.Location = new System.Drawing.Point(8, 6);
            this.gbTransform.Name = "gbTransform";
            this.gbTransform.Size = new System.Drawing.Size(680, 268);
            this.gbTransform.TabIndex = 0;
            this.gbTransform.TabStop = false;
            this.gbTransform.Text = "Folder modifications";
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.label6);
            this.tabConfig.Controls.Add(this.label5);
            this.tabConfig.Controls.Add(this.btIniFileCopy);
            this.tabConfig.Controls.Add(this.label4);
            this.tabConfig.Controls.Add(this.label3);
            this.tabConfig.Controls.Add(this.lbCurrentSimultaneousCopiedFiles);
            this.tabConfig.Controls.Add(this.label2);
            this.tabConfig.Controls.Add(this.groupBox1);
            this.tabConfig.Controls.Add(this.btCheckMemCard);
            this.tabConfig.Controls.Add(this.btCheckBin);
            this.tabConfig.Location = new System.Drawing.Point(4, 22);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfig.Size = new System.Drawing.Size(696, 577);
            this.tabConfig.TabIndex = 6;
            this.tabConfig.Text = "Configuration";
            this.tabConfig.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(187, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(503, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "The ini has parameters to be the nearest to the stock UI (no boot menu and splash" +
    "screen, default theme).";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(170, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(476, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "For BS1.0.0, copy the bleemsync_cfg.INI file from the exe path to your usb drive " +
    "(overwrite existing).";
            // 
            // btIniFileCopy
            // 
            this.btIniFileCopy.Location = new System.Drawing.Point(8, 240);
            this.btIniFileCopy.Name = "btIniFileCopy";
            this.btIniFileCopy.Size = new System.Drawing.Size(150, 46);
            this.btIniFileCopy.TabIndex = 12;
            this.btIniFileCopy.Text = "Copy bleemsync_cfg.INI file";
            this.btIniFileCopy.UseVisualStyleBackColor = true;
            this.btIniFileCopy.Click += new System.EventHandler(this.btIniFileCopy_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(170, 205);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(402, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Display another window. Manage memory card files and merge slots between 2 files." +
    "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(275, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Display another window. Find a serial number in a bin file.";
            // 
            // lbCurrentSimultaneousCopiedFiles
            // 
            this.lbCurrentSimultaneousCopiedFiles.Location = new System.Drawing.Point(458, 43);
            this.lbCurrentSimultaneousCopiedFiles.Name = "lbCurrentSimultaneousCopiedFiles";
            this.lbCurrentSimultaneousCopiedFiles.Size = new System.Drawing.Size(230, 18);
            this.lbCurrentSimultaneousCopiedFiles.TabIndex = 2;
            this.lbCurrentSimultaneousCopiedFiles.Text = "---";
            this.lbCurrentSimultaneousCopiedFiles.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(458, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current value";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btValidateCfg);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbSimultaneousCopiedFiles);
            this.groupBox1.Location = new System.Drawing.Point(8, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Files";
            // 
            // btValidateCfg
            // 
            this.btValidateCfg.Location = new System.Drawing.Point(362, 71);
            this.btValidateCfg.Name = "btValidateCfg";
            this.btValidateCfg.Size = new System.Drawing.Size(75, 23);
            this.btValidateCfg.TabIndex = 2;
            this.btValidateCfg.Text = "OK";
            this.btValidateCfg.UseVisualStyleBackColor = true;
            this.btValidateCfg.Click += new System.EventHandler(this.btValidateCfg_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Maximum files to be copied simultaneously:";
            // 
            // cbSimultaneousCopiedFiles
            // 
            this.cbSimultaneousCopiedFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSimultaneousCopiedFiles.FormattingEnabled = true;
            this.cbSimultaneousCopiedFiles.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.cbSimultaneousCopiedFiles.Location = new System.Drawing.Point(242, 13);
            this.cbSimultaneousCopiedFiles.Name = "cbSimultaneousCopiedFiles";
            this.cbSimultaneousCopiedFiles.Size = new System.Drawing.Size(121, 21);
            this.cbSimultaneousCopiedFiles.TabIndex = 0;
            // 
            // btCheckMemCard
            // 
            this.btCheckMemCard.Location = new System.Drawing.Point(8, 188);
            this.btCheckMemCard.Name = "btCheckMemCard";
            this.btCheckMemCard.Size = new System.Drawing.Size(150, 46);
            this.btCheckMemCard.TabIndex = 9;
            this.btCheckMemCard.Text = "MemCard";
            this.btCheckMemCard.UseVisualStyleBackColor = true;
            this.btCheckMemCard.Click += new System.EventHandler(this.btCheckMemCard_Click);
            // 
            // btCheckBin
            // 
            this.btCheckBin.Location = new System.Drawing.Point(8, 136);
            this.btCheckBin.Name = "btCheckBin";
            this.btCheckBin.Size = new System.Drawing.Size(150, 46);
            this.btCheckBin.TabIndex = 8;
            this.btCheckBin.Text = "Check Bin";
            this.btCheckBin.UseVisualStyleBackColor = true;
            this.btCheckBin.Click += new System.EventHandler(this.btCheckBin_Click);
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.btClearLog);
            this.tabDebug.Controls.Add(this.btTest);
            this.tabDebug.Controls.Add(this.tbLogDebug);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebug.Size = new System.Drawing.Size(696, 577);
            this.tabDebug.TabIndex = 3;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            this.tabDebug.Paint += new System.Windows.Forms.PaintEventHandler(this.tabDebug_Paint);
            // 
            // btClearLog
            // 
            this.btClearLog.Location = new System.Drawing.Point(613, 544);
            this.btClearLog.Name = "btClearLog";
            this.btClearLog.Size = new System.Drawing.Size(75, 23);
            this.btClearLog.TabIndex = 7;
            this.btClearLog.Text = "Clear";
            this.btClearLog.UseVisualStyleBackColor = true;
            this.btClearLog.Click += new System.EventHandler(this.btClearLog_Click);
            // 
            // btTest
            // 
            this.btTest.Enabled = false;
            this.btTest.Location = new System.Drawing.Point(613, 6);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(75, 23);
            this.btTest.TabIndex = 6;
            this.btTest.Text = "Test Sort";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Visible = false;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // tbLogDebug
            // 
            this.tbLogDebug.Location = new System.Drawing.Point(6, 6);
            this.tbLogDebug.MaxLength = 0;
            this.tbLogDebug.Multiline = true;
            this.tbLogDebug.Name = "tbLogDebug";
            this.tbLogDebug.ReadOnly = true;
            this.tbLogDebug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLogDebug.Size = new System.Drawing.Size(601, 563);
            this.tbLogDebug.TabIndex = 3;
            // 
            // tabReadMe
            // 
            this.tabReadMe.Controls.Add(this.wbReadme);
            this.tabReadMe.Location = new System.Drawing.Point(4, 22);
            this.tabReadMe.Name = "tabReadMe";
            this.tabReadMe.Padding = new System.Windows.Forms.Padding(3);
            this.tabReadMe.Size = new System.Drawing.Size(696, 577);
            this.tabReadMe.TabIndex = 4;
            this.tabReadMe.Text = "Readme";
            this.tabReadMe.UseVisualStyleBackColor = true;
            // 
            // wbReadme
            // 
            this.wbReadme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbReadme.Location = new System.Drawing.Point(3, 3);
            this.wbReadme.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbReadme.Name = "wbReadme";
            this.wbReadme.Size = new System.Drawing.Size(690, 571);
            this.wbReadme.TabIndex = 0;
            // 
            // ofdAddFiles
            // 
            this.ofdAddFiles.Multiselect = true;
            // 
            // sfdSaveImage
            // 
            this.sfdSaveImage.DefaultExt = "png";
            this.sfdSaveImage.FileName = "Game.png";
            this.sfdSaveImage.Filter = "png files|*.png";
            this.sfdSaveImage.RestoreDirectory = true;
            this.sfdSaveImage.ShowHelp = true;
            this.sfdSaveImage.Title = "Save file";
            // 
            // tmRefreshFolder
            // 
            this.tmRefreshFolder.Interval = 500;
            this.tmRefreshFolder.Tick += new System.EventHandler(this.tmRefreshFolder_Tick);
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBSVersionItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(704, 24);
            this.msMainMenu.TabIndex = 7;
            this.msMainMenu.Text = "config";
            // 
            // tsmiBSVersionItem
            // 
            this.tsmiBSVersionItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiBSv041,
            this.tsmiBSv100});
            this.tsmiBSVersionItem.Name = "tsmiBSVersionItem";
            this.tsmiBSVersionItem.Size = new System.Drawing.Size(118, 20);
            this.tsmiBSVersionItem.Text = "BleemSync version";
            // 
            // tsmiBSv041
            // 
            this.tsmiBSv041.Checked = true;
            this.tsmiBSv041.CheckOnClick = true;
            this.tsmiBSv041.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiBSv041.Name = "tsmiBSv041";
            this.tsmiBSv041.Size = new System.Drawing.Size(104, 22);
            this.tsmiBSv041.Text = "v0.4.1";
            this.tsmiBSv041.CheckedChanged += new System.EventHandler(this.tsmiBSv041_CheckedChanged);
            // 
            // tsmiBSv100
            // 
            this.tsmiBSv100.CheckOnClick = true;
            this.tsmiBSv100.Name = "tsmiBSv100";
            this.tsmiBSv100.Size = new System.Drawing.Size(104, 22);
            this.tsmiBSv100.Text = "v1.0.0";
            this.tsmiBSv100.CheckedChanged += new System.EventHandler(this.tsmiBSv100_CheckedChanged);
            // 
            // ofdLoadDatabaseFile
            // 
            this.ofdLoadDatabaseFile.FileName = "regional.db";
            this.ofdLoadDatabaseFile.Filter = "DB file|*.db";
            this.ofdLoadDatabaseFile.ShowHelp = true;
            // 
            // btLaunchPngquant
            // 
            this.btLaunchPngquant.Enabled = false;
            this.btLaunchPngquant.Image = global::pbPSCReAlpha.Properties.Resources.pictures;
            this.btLaunchPngquant.Location = new System.Drawing.Point(246, 7);
            this.btLaunchPngquant.Name = "btLaunchPngquant";
            this.btLaunchPngquant.Size = new System.Drawing.Size(130, 25);
            this.btLaunchPngquant.TabIndex = 12;
            this.btLaunchPngquant.Text = "Compress png files";
            this.btLaunchPngquant.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLaunchPngquant.UseVisualStyleBackColor = true;
            this.btLaunchPngquant.Click += new System.EventHandler(this.btLaunchPngquant_Click);
            // 
            // btLaunchBleemsync
            // 
            this.btLaunchBleemsync.Image = global::pbPSCReAlpha.Properties.Resources.inode_blockdevice;
            this.btLaunchBleemsync.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLaunchBleemsync.Location = new System.Drawing.Point(3, 522);
            this.btLaunchBleemsync.Name = "btLaunchBleemsync";
            this.btLaunchBleemsync.Size = new System.Drawing.Size(197, 48);
            this.btLaunchBleemsync.TabIndex = 10;
            this.btLaunchBleemsync.Text = "Recreate DataBase";
            this.btLaunchBleemsync.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLaunchBleemsync.UseVisualStyleBackColor = true;
            this.btLaunchBleemsync.Click += new System.EventHandler(this.btLaunchBleemsync_Click);
            // 
            // btM3uGenerate
            // 
            this.btM3uGenerate.Enabled = false;
            this.btM3uGenerate.Image = global::pbPSCReAlpha.Properties.Resources.edit_4;
            this.btM3uGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btM3uGenerate.Location = new System.Drawing.Point(220, 50);
            this.btM3uGenerate.Name = "btM3uGenerate";
            this.btM3uGenerate.Size = new System.Drawing.Size(115, 25);
            this.btM3uGenerate.TabIndex = 12;
            this.btM3uGenerate.Text = "Generate m3u file";
            this.btM3uGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btM3uGenerate.UseVisualStyleBackColor = true;
            this.btM3uGenerate.Visible = false;
            this.btM3uGenerate.Click += new System.EventHandler(this.btM3uGenerate_Click);
            // 
            // btPbpRename
            // 
            this.btPbpRename.Enabled = false;
            this.btPbpRename.Image = global::pbPSCReAlpha.Properties.Resources.edit_rename;
            this.btPbpRename.Location = new System.Drawing.Point(178, 19);
            this.btPbpRename.Name = "btPbpRename";
            this.btPbpRename.Size = new System.Drawing.Size(82, 25);
            this.btPbpRename.TabIndex = 13;
            this.btPbpRename.Text = "pbp file(s)";
            this.btPbpRename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPbpRename.UseVisualStyleBackColor = true;
            this.btPbpRename.Click += new System.EventHandler(this.btPbpRename_Click);
            // 
            // btSbiRename
            // 
            this.btSbiRename.Enabled = false;
            this.btSbiRename.Image = global::pbPSCReAlpha.Properties.Resources.edit_rename;
            this.btSbiRename.Location = new System.Drawing.Point(354, 19);
            this.btSbiRename.Name = "btSbiRename";
            this.btSbiRename.Size = new System.Drawing.Size(82, 25);
            this.btSbiRename.TabIndex = 12;
            this.btSbiRename.Text = "sbi file(s)";
            this.btSbiRename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btSbiRename.UseVisualStyleBackColor = true;
            this.btSbiRename.Click += new System.EventHandler(this.btSbiRename_Click);
            // 
            // btPngRename
            // 
            this.btPngRename.Enabled = false;
            this.btPngRename.Image = global::pbPSCReAlpha.Properties.Resources.edit_rename;
            this.btPngRename.Location = new System.Drawing.Point(266, 19);
            this.btPngRename.Name = "btPngRename";
            this.btPngRename.Size = new System.Drawing.Size(82, 25);
            this.btPngRename.TabIndex = 11;
            this.btPngRename.Text = "png file";
            this.btPngRename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btPngRename.UseVisualStyleBackColor = true;
            this.btPngRename.Click += new System.EventHandler(this.btPngRename_Click);
            // 
            // btBinRename
            // 
            this.btBinRename.Enabled = false;
            this.btBinRename.Image = global::pbPSCReAlpha.Properties.Resources.edit_rename;
            this.btBinRename.Location = new System.Drawing.Point(4, 19);
            this.btBinRename.Name = "btBinRename";
            this.btBinRename.Size = new System.Drawing.Size(82, 25);
            this.btBinRename.TabIndex = 9;
            this.btBinRename.Text = "bin file(s)";
            this.btBinRename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBinRename.UseVisualStyleBackColor = true;
            this.btBinRename.Click += new System.EventHandler(this.btBinRename_Click);
            // 
            // btCueRename
            // 
            this.btCueRename.Enabled = false;
            this.btCueRename.Image = global::pbPSCReAlpha.Properties.Resources.edit_rename;
            this.btCueRename.Location = new System.Drawing.Point(90, 19);
            this.btCueRename.Name = "btCueRename";
            this.btCueRename.Size = new System.Drawing.Size(82, 25);
            this.btCueRename.TabIndex = 10;
            this.btCueRename.Text = "cue file(s)";
            this.btCueRename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCueRename.UseVisualStyleBackColor = true;
            this.btCueRename.Click += new System.EventHandler(this.btCueRename_Click);
            // 
            // btOpenFolder
            // 
            this.btOpenFolder.Enabled = false;
            this.btOpenFolder.Image = global::pbPSCReAlpha.Properties.Resources.folder;
            this.btOpenFolder.Location = new System.Drawing.Point(363, 50);
            this.btOpenFolder.Name = "btOpenFolder";
            this.btOpenFolder.Size = new System.Drawing.Size(115, 25);
            this.btOpenFolder.TabIndex = 8;
            this.btOpenFolder.Text = "Open folder";
            this.btOpenFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btOpenFolder.UseVisualStyleBackColor = true;
            this.btOpenFolder.Visible = false;
            this.btOpenFolder.Click += new System.EventHandler(this.btOpenFolder_Click);
            // 
            // btRefreshFolderOnly
            // 
            this.btRefreshFolderOnly.Enabled = false;
            this.btRefreshFolderOnly.Image = global::pbPSCReAlpha.Properties.Resources.view_refresh_6;
            this.btRefreshFolderOnly.Location = new System.Drawing.Point(363, 19);
            this.btRefreshFolderOnly.Name = "btRefreshFolderOnly";
            this.btRefreshFolderOnly.Size = new System.Drawing.Size(115, 25);
            this.btRefreshFolderOnly.TabIndex = 7;
            this.btRefreshFolderOnly.Text = "Refresh folder";
            this.btRefreshFolderOnly.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefreshFolderOnly.UseVisualStyleBackColor = true;
            this.btRefreshFolderOnly.Visible = false;
            this.btRefreshFolderOnly.Click += new System.EventHandler(this.btRefreshFolderOnly_Click);
            // 
            // btAddFiles
            // 
            this.btAddFiles.Enabled = false;
            this.btAddFiles.Image = global::pbPSCReAlpha.Properties.Resources.brick_add;
            this.btAddFiles.Location = new System.Drawing.Point(104, 19);
            this.btAddFiles.Name = "btAddFiles";
            this.btAddFiles.Size = new System.Drawing.Size(115, 25);
            this.btAddFiles.TabIndex = 6;
            this.btAddFiles.Text = "Add files";
            this.btAddFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAddFiles.UseVisualStyleBackColor = true;
            this.btAddFiles.Visible = false;
            this.btAddFiles.Click += new System.EventHandler(this.btAddFiles_Click);
            // 
            // btEditCue
            // 
            this.btEditCue.Enabled = false;
            this.btEditCue.Image = global::pbPSCReAlpha.Properties.Resources.accessories_text_editor_3;
            this.btEditCue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEditCue.Location = new System.Drawing.Point(104, 50);
            this.btEditCue.Name = "btEditCue";
            this.btEditCue.Size = new System.Drawing.Size(115, 25);
            this.btEditCue.TabIndex = 3;
            this.btEditCue.Text = "Edit cue file(s)";
            this.btEditCue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEditCue.UseVisualStyleBackColor = true;
            this.btEditCue.Visible = false;
            this.btEditCue.Click += new System.EventHandler(this.btEditCue_Click);
            // 
            // btAddPcsxCfg
            // 
            this.btAddPcsxCfg.Enabled = false;
            this.btAddPcsxCfg.Image = global::pbPSCReAlpha.Properties.Resources.cog_add;
            this.btAddPcsxCfg.Location = new System.Drawing.Point(220, 19);
            this.btAddPcsxCfg.Name = "btAddPcsxCfg";
            this.btAddPcsxCfg.Size = new System.Drawing.Size(115, 25);
            this.btAddPcsxCfg.TabIndex = 2;
            this.btAddPcsxCfg.Text = "Add pcsx.cfg";
            this.btAddPcsxCfg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAddPcsxCfg.UseVisualStyleBackColor = true;
            this.btAddPcsxCfg.Visible = false;
            this.btAddPcsxCfg.Click += new System.EventHandler(this.btAddPcsxCfg_Click);
            // 
            // btEditGameIni
            // 
            this.btEditGameIni.Image = global::pbPSCReAlpha.Properties.Resources.edit_3;
            this.btEditGameIni.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEditGameIni.Location = new System.Drawing.Point(6, 19);
            this.btEditGameIni.Name = "btEditGameIni";
            this.btEditGameIni.Size = new System.Drawing.Size(97, 56);
            this.btEditGameIni.TabIndex = 0;
            this.btEditGameIni.Text = "Edit Game.ini + picture";
            this.btEditGameIni.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEditGameIni.UseVisualStyleBackColor = true;
            this.btEditGameIni.Click += new System.EventHandler(this.btEditGameIni_Click);
            // 
            // btNewFolder
            // 
            this.btNewFolder.Enabled = false;
            this.btNewFolder.Image = global::pbPSCReAlpha.Properties.Resources.folder_new_7;
            this.btNewFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btNewFolder.Location = new System.Drawing.Point(165, 7);
            this.btNewFolder.Name = "btNewFolder";
            this.btNewFolder.Size = new System.Drawing.Size(75, 25);
            this.btNewFolder.TabIndex = 8;
            this.btNewFolder.Text = "New";
            this.btNewFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNewFolder.UseVisualStyleBackColor = true;
            this.btNewFolder.Click += new System.EventHandler(this.btNewFolder_Click);
            // 
            // btReSort
            // 
            this.btReSort.Enabled = false;
            this.btReSort.Image = global::pbPSCReAlpha.Properties.Resources.edit_sort_az;
            this.btReSort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReSort.Location = new System.Drawing.Point(84, 7);
            this.btReSort.Name = "btReSort";
            this.btReSort.Size = new System.Drawing.Size(75, 25);
            this.btReSort.TabIndex = 7;
            this.btReSort.Text = "Sort";
            this.btReSort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btReSort.UseVisualStyleBackColor = true;
            this.btReSort.Click += new System.EventHandler(this.btReSort_Click);
            // 
            // btCrowseGamesFolder
            // 
            this.btCrowseGamesFolder.Image = global::pbPSCReAlpha.Properties.Resources.folder;
            this.btCrowseGamesFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCrowseGamesFolder.Location = new System.Drawing.Point(613, 7);
            this.btCrowseGamesFolder.Name = "btCrowseGamesFolder";
            this.btCrowseGamesFolder.Size = new System.Drawing.Size(75, 25);
            this.btCrowseGamesFolder.TabIndex = 6;
            this.btCrowseGamesFolder.Text = "Browse";
            this.btCrowseGamesFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCrowseGamesFolder.UseVisualStyleBackColor = true;
            this.btCrowseGamesFolder.Click += new System.EventHandler(this.btCrowseGamesFolder_Click);
            // 
            // pbExploreImage
            // 
            this.pbExploreImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbExploreImage.Location = new System.Drawing.Point(6, 19);
            this.pbExploreImage.Name = "pbExploreImage";
            this.pbExploreImage.Size = new System.Drawing.Size(150, 150);
            this.pbExploreImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbExploreImage.TabIndex = 3;
            this.pbExploreImage.TabStop = false;
            this.pbExploreImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbExploreImage_DragDrop);
            this.pbExploreImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbExploreImage_DragEnter);
            // 
            // btRefresh
            // 
            this.btRefresh.Image = global::pbPSCReAlpha.Properties.Resources.view_refresh_6;
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRefresh.Location = new System.Drawing.Point(3, 7);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 25);
            this.btRefresh.TabIndex = 0;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btReadBS100Database
            // 
            this.btReadBS100Database.Image = global::pbPSCReAlpha.Properties.Resources.arrow_right_3;
            this.btReadBS100Database.Location = new System.Drawing.Point(341, 142);
            this.btReadBS100Database.Name = "btReadBS100Database";
            this.btReadBS100Database.Size = new System.Drawing.Size(333, 117);
            this.btReadBS100Database.TabIndex = 3;
            this.btReadBS100Database.Text = "Read a BS1.0.0 database";
            this.btReadBS100Database.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btReadBS100Database.UseVisualStyleBackColor = true;
            this.btReadBS100Database.Click += new System.EventHandler(this.btReadBS100Database_Click);
            // 
            // btReadBS041Database
            // 
            this.btReadBS041Database.Image = global::pbPSCReAlpha.Properties.Resources.arrow_right;
            this.btReadBS041Database.Location = new System.Drawing.Point(6, 142);
            this.btReadBS041Database.Name = "btReadBS041Database";
            this.btReadBS041Database.Size = new System.Drawing.Size(333, 117);
            this.btReadBS041Database.TabIndex = 2;
            this.btReadBS041Database.Text = "Read a BS0.4.1 database";
            this.btReadBS041Database.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btReadBS041Database.UseVisualStyleBackColor = true;
            this.btReadBS041Database.Click += new System.EventHandler(this.btReadBS041Database_Click);
            // 
            // btUpgradeFolders
            // 
            this.btUpgradeFolders.Image = global::pbPSCReAlpha.Properties.Resources.arrow_up_double_3;
            this.btUpgradeFolders.Location = new System.Drawing.Point(341, 19);
            this.btUpgradeFolders.Name = "btUpgradeFolders";
            this.btUpgradeFolders.Size = new System.Drawing.Size(333, 117);
            this.btUpgradeFolders.TabIndex = 1;
            this.btUpgradeFolders.Text = "Upgrade (BS1.0.0 compatible folders)";
            this.btUpgradeFolders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btUpgradeFolders.UseVisualStyleBackColor = true;
            this.btUpgradeFolders.Click += new System.EventHandler(this.btUpgradeFolders_Click);
            // 
            // btDowngradeFolders
            // 
            this.btDowngradeFolders.Image = global::pbPSCReAlpha.Properties.Resources.arrow_down_double;
            this.btDowngradeFolders.Location = new System.Drawing.Point(6, 19);
            this.btDowngradeFolders.Name = "btDowngradeFolders";
            this.btDowngradeFolders.Size = new System.Drawing.Size(333, 117);
            this.btDowngradeFolders.TabIndex = 0;
            this.btDowngradeFolders.Text = "Downgrade (BS0.4.1 compatible folders)";
            this.btDowngradeFolders.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.btDowngradeFolders.UseVisualStyleBackColor = true;
            this.btDowngradeFolders.Click += new System.EventHandler(this.btDowngradeFolders_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 627);
            this.Controls.Add(this.tabControlAll);
            this.Controls.Add(this.msMainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "pbPSCReAlpha 0.xx";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControlAll.ResumeLayout(false);
            this.tabExplorer.ResumeLayout(false);
            this.tabExplorer.PerformLayout();
            this.gbExploreEdit.ResumeLayout(false);
            this.gbAutoRename.ResumeLayout(false);
            this.gbExploreDetails.ResumeLayout(false);
            this.gbExploreDetails.PerformLayout();
            this.tabTransform.ResumeLayout(false);
            this.gbTransform.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tabConfig.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            this.tabReadMe.ResumeLayout(false);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExploreImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdGamesFolder;
        private System.Windows.Forms.TabControl tabControlAll;
        private System.Windows.Forms.TabPage tabExplorer;
        private System.Windows.Forms.ListBox lbGames;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.GroupBox gbExploreDetails;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pbExploreImage;
        private System.Windows.Forms.Label lbExploreAlphaTitle;
        private System.Windows.Forms.Label lbExploreYear;
        private System.Windows.Forms.Label lbExplorePlayers;
        private System.Windows.Forms.Label lbExplorePublisher;
        private System.Windows.Forms.Label lbExploreDiscs;
        private System.Windows.Forms.Label lbExploreTitle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.ImageList ilFlags;
        private System.Windows.Forms.TextBox tbErrString;
        private System.Windows.Forms.Button btCrowseGamesFolder;
        private System.Windows.Forms.TextBox tbFolderPath;
        private System.Windows.Forms.Button btReSort;
        private System.Windows.Forms.Button btNewFolder;
        private System.Windows.Forms.GroupBox gbExploreEdit;
        private System.Windows.Forms.Button btLaunchBleemsync;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.TextBox tbLogDebug;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.Button btClearLog;
        private System.Windows.Forms.Button btEditGameIni;
        private System.Windows.Forms.Button btEditCue;
        private System.Windows.Forms.Button btAddPcsxCfg;
        private System.Windows.Forms.Button btAddFiles;
        private System.Windows.Forms.OpenFileDialog ofdAddFiles;
        private System.Windows.Forms.SaveFileDialog sfdSaveImage;
        private System.Windows.Forms.Button btRefreshFolderOnly;
        private System.Windows.Forms.TabPage tabReadMe;
        private System.Windows.Forms.WebBrowser wbReadme;
        private System.Windows.Forms.Button btOpenFolder;
        private System.Windows.Forms.Label lbFreeSpace;
        private System.Windows.Forms.Timer tmRefreshFolder;
        private System.Windows.Forms.Button btBinRename;
        private System.Windows.Forms.GroupBox gbAutoRename;
        private System.Windows.Forms.Button btPngRename;
        private System.Windows.Forms.Button btCueRename;
        private System.Windows.Forms.Label lbFolderSizeLabel;
        private System.Windows.Forms.Label lbFolderSize;
        private System.Windows.Forms.Button btSbiRename;
        private System.Windows.Forms.Button btLaunchPngquant;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiBSVersionItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiBSv041;
        private System.Windows.Forms.ToolStripMenuItem tsmiBSv100;
        private System.Windows.Forms.TabPage tabTransform;
        private System.Windows.Forms.GroupBox gbTransform;
        private System.Windows.Forms.Button btUpgradeFolders;
        private System.Windows.Forms.Button btDowngradeFolders;
        private System.Windows.Forms.Button btReadBS041Database;
        private System.Windows.Forms.Button btReadBS100Database;
        private System.Windows.Forms.OpenFileDialog ofdLoadDatabaseFile;
        private System.Windows.Forms.Button btPbpRename;
        private System.Windows.Forms.TabPage tabConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btValidateCfg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSimultaneousCopiedFiles;
        private System.Windows.Forms.Label lbCurrentSimultaneousCopiedFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btCheckBin;
        private System.Windows.Forms.Button btCheckMemCard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btIniFileCopy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btM3uGenerate;
    }
}

