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
            this.btGo = new System.Windows.Forms.Button();
            this.cbStartAt21 = new System.Windows.Forms.CheckBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btTest = new System.Windows.Forms.Button();
            this.tabControlAll = new System.Windows.Forms.TabControl();
            this.tabExplorer = new System.Windows.Forms.TabPage();
            this.btReSort = new System.Windows.Forms.Button();
            this.btCrowseGamesFolder = new System.Windows.Forms.Button();
            this.tbFolderPath = new System.Windows.Forms.TextBox();
            this.gbExploreDetails = new System.Windows.Forms.GroupBox();
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
            this.pbExploreImage = new System.Windows.Forms.PictureBox();
            this.tbLogExplorer = new System.Windows.Forms.TextBox();
            this.lbGames = new System.Windows.Forms.ListBox();
            this.btRefresh = new System.Windows.Forms.Button();
            this.tabResortAlphabetic = new System.Windows.Forms.TabPage();
            this.tabGeneIni = new System.Windows.Forms.TabPage();
            this.btLink = new System.Windows.Forms.Button();
            this.tbHiddenLink = new System.Windows.Forms.TextBox();
            this.btGeneSearch = new System.Windows.Forms.Button();
            this.tbGeneSearchText = new System.Windows.Forms.TextBox();
            this.lbGeneBigData = new System.Windows.Forms.ListBox();
            this.btGeneCopyTitle = new System.Windows.Forms.Button();
            this.btLoadIni = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btGenerateIni = new System.Windows.Forms.Button();
            this.nuGeneYear = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nuGenePlayers = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.tbGenePublisher = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGeneAlphaTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGeneDiscs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGeneTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sfdGeneSaveIni = new System.Windows.Forms.SaveFileDialog();
            this.ofdGeneLoadIni = new System.Windows.Forms.OpenFileDialog();
            this.tabControlAll.SuspendLayout();
            this.tabExplorer.SuspendLayout();
            this.gbExploreDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExploreImage)).BeginInit();
            this.tabResortAlphabetic.SuspendLayout();
            this.tabGeneIni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuGeneYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuGenePlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // btGo
            // 
            this.btGo.Location = new System.Drawing.Point(6, 29);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(75, 23);
            this.btGo.TabIndex = 2;
            this.btGo.Text = "Re-sort";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // cbStartAt21
            // 
            this.cbStartAt21.AutoSize = true;
            this.cbStartAt21.Location = new System.Drawing.Point(8, 6);
            this.cbStartAt21.Name = "cbStartAt21";
            this.cbStartAt21.Size = new System.Drawing.Size(241, 17);
            this.cbStartAt21.TabIndex = 3;
            this.cbStartAt21.Text = "Check to begin alphabetic order at 21st game";
            this.cbStartAt21.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(6, 87);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(241, 435);
            this.tbLog.TabIndex = 4;
            // 
            // btTest
            // 
            this.btTest.Enabled = false;
            this.btTest.Location = new System.Drawing.Point(6, 58);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(75, 23);
            this.btTest.TabIndex = 5;
            this.btTest.Text = "Test";
            this.btTest.UseVisualStyleBackColor = true;
            this.btTest.Visible = false;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // tabControlAll
            // 
            this.tabControlAll.Controls.Add(this.tabExplorer);
            this.tabControlAll.Controls.Add(this.tabResortAlphabetic);
            this.tabControlAll.Controls.Add(this.tabGeneIni);
            this.tabControlAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAll.Location = new System.Drawing.Point(0, 0);
            this.tabControlAll.Name = "tabControlAll";
            this.tabControlAll.SelectedIndex = 0;
            this.tabControlAll.Size = new System.Drawing.Size(700, 556);
            this.tabControlAll.TabIndex = 6;
            // 
            // tabExplorer
            // 
            this.tabExplorer.Controls.Add(this.btReSort);
            this.tabExplorer.Controls.Add(this.btCrowseGamesFolder);
            this.tabExplorer.Controls.Add(this.tbFolderPath);
            this.tabExplorer.Controls.Add(this.gbExploreDetails);
            this.tabExplorer.Controls.Add(this.tbLogExplorer);
            this.tabExplorer.Controls.Add(this.lbGames);
            this.tabExplorer.Controls.Add(this.btRefresh);
            this.tabExplorer.Location = new System.Drawing.Point(4, 22);
            this.tabExplorer.Name = "tabExplorer";
            this.tabExplorer.Padding = new System.Windows.Forms.Padding(3);
            this.tabExplorer.Size = new System.Drawing.Size(692, 530);
            this.tabExplorer.TabIndex = 2;
            this.tabExplorer.Text = "Explorer";
            this.tabExplorer.UseVisualStyleBackColor = true;
            // 
            // btReSort
            // 
            this.btReSort.Enabled = false;
            this.btReSort.Image = global::pbPSCReAlpha.Properties.Resources.edit_sort_az;
            this.btReSort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btReSort.Location = new System.Drawing.Point(89, 6);
            this.btReSort.Name = "btReSort";
            this.btReSort.Size = new System.Drawing.Size(75, 22);
            this.btReSort.TabIndex = 7;
            this.btReSort.Text = "Sort";
            this.btReSort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btReSort.UseVisualStyleBackColor = true;
            this.btReSort.Click += new System.EventHandler(this.btReSort_Click);
            // 
            // btCrowseGamesFolder
            // 
            this.btCrowseGamesFolder.Location = new System.Drawing.Point(609, 6);
            this.btCrowseGamesFolder.Name = "btCrowseGamesFolder";
            this.btCrowseGamesFolder.Size = new System.Drawing.Size(75, 23);
            this.btCrowseGamesFolder.TabIndex = 6;
            this.btCrowseGamesFolder.Text = "Browse...";
            this.btCrowseGamesFolder.UseVisualStyleBackColor = true;
            this.btCrowseGamesFolder.Click += new System.EventHandler(this.btCrowseGamesFolder_Click);
            // 
            // tbFolderPath
            // 
            this.tbFolderPath.Location = new System.Drawing.Point(443, 8);
            this.tbFolderPath.Name = "tbFolderPath";
            this.tbFolderPath.Size = new System.Drawing.Size(160, 20);
            this.tbFolderPath.TabIndex = 5;
            this.tbFolderPath.Text = "F:\\Games";
            // 
            // gbExploreDetails
            // 
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
            this.gbExploreDetails.Location = new System.Drawing.Point(172, 35);
            this.gbExploreDetails.Name = "gbExploreDetails";
            this.gbExploreDetails.Size = new System.Drawing.Size(512, 382);
            this.gbExploreDetails.TabIndex = 4;
            this.gbExploreDetails.TabStop = false;
            this.gbExploreDetails.Text = "Details";
            // 
            // tbErrString
            // 
            this.tbErrString.Location = new System.Drawing.Point(6, 278);
            this.tbErrString.Multiline = true;
            this.tbErrString.Name = "tbErrString";
            this.tbErrString.ReadOnly = true;
            this.tbErrString.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbErrString.Size = new System.Drawing.Size(500, 97);
            this.tbErrString.TabIndex = 17;
            // 
            // lvFiles
            // 
            this.lvFiles.FullRowSelect = true;
            this.lvFiles.GridLines = true;
            this.lvFiles.LargeImageList = this.ilFlags;
            this.lvFiles.Location = new System.Drawing.Point(6, 175);
            this.lvFiles.MultiSelect = false;
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(500, 97);
            this.lvFiles.SmallImageList = this.ilFlags;
            this.lvFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvFiles.StateImageList = this.ilFlags;
            this.lvFiles.TabIndex = 16;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.List;
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
            // pbExploreImage
            // 
            this.pbExploreImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbExploreImage.Location = new System.Drawing.Point(6, 19);
            this.pbExploreImage.Name = "pbExploreImage";
            this.pbExploreImage.Size = new System.Drawing.Size(150, 150);
            this.pbExploreImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbExploreImage.TabIndex = 3;
            this.pbExploreImage.TabStop = false;
            // 
            // tbLogExplorer
            // 
            this.tbLogExplorer.Location = new System.Drawing.Point(172, 423);
            this.tbLogExplorer.Multiline = true;
            this.tbLogExplorer.Name = "tbLogExplorer";
            this.tbLogExplorer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLogExplorer.Size = new System.Drawing.Size(512, 97);
            this.tbLogExplorer.TabIndex = 2;
            this.tbLogExplorer.Visible = false;
            // 
            // lbGames
            // 
            this.lbGames.FormattingEnabled = true;
            this.lbGames.Location = new System.Drawing.Point(8, 35);
            this.lbGames.Name = "lbGames";
            this.lbGames.ScrollAlwaysVisible = true;
            this.lbGames.Size = new System.Drawing.Size(158, 485);
            this.lbGames.TabIndex = 1;
            this.lbGames.SelectedIndexChanged += new System.EventHandler(this.lbGames_SelectedIndexChanged);
            // 
            // btRefresh
            // 
            this.btRefresh.Image = global::pbPSCReAlpha.Properties.Resources.view_refresh_6;
            this.btRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRefresh.Location = new System.Drawing.Point(8, 6);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 0;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // tabResortAlphabetic
            // 
            this.tabResortAlphabetic.Controls.Add(this.tbLog);
            this.tabResortAlphabetic.Controls.Add(this.btTest);
            this.tabResortAlphabetic.Controls.Add(this.btGo);
            this.tabResortAlphabetic.Controls.Add(this.cbStartAt21);
            this.tabResortAlphabetic.Location = new System.Drawing.Point(4, 22);
            this.tabResortAlphabetic.Name = "tabResortAlphabetic";
            this.tabResortAlphabetic.Padding = new System.Windows.Forms.Padding(3);
            this.tabResortAlphabetic.Size = new System.Drawing.Size(692, 530);
            this.tabResortAlphabetic.TabIndex = 0;
            this.tabResortAlphabetic.Text = "Re-sort Folders";
            this.tabResortAlphabetic.UseVisualStyleBackColor = true;
            // 
            // tabGeneIni
            // 
            this.tabGeneIni.Controls.Add(this.btLink);
            this.tabGeneIni.Controls.Add(this.tbHiddenLink);
            this.tabGeneIni.Controls.Add(this.btGeneSearch);
            this.tabGeneIni.Controls.Add(this.tbGeneSearchText);
            this.tabGeneIni.Controls.Add(this.lbGeneBigData);
            this.tabGeneIni.Controls.Add(this.btGeneCopyTitle);
            this.tabGeneIni.Controls.Add(this.btLoadIni);
            this.tabGeneIni.Controls.Add(this.label8);
            this.tabGeneIni.Controls.Add(this.label7);
            this.tabGeneIni.Controls.Add(this.btGenerateIni);
            this.tabGeneIni.Controls.Add(this.nuGeneYear);
            this.tabGeneIni.Controls.Add(this.label6);
            this.tabGeneIni.Controls.Add(this.nuGenePlayers);
            this.tabGeneIni.Controls.Add(this.label5);
            this.tabGeneIni.Controls.Add(this.tbGenePublisher);
            this.tabGeneIni.Controls.Add(this.label4);
            this.tabGeneIni.Controls.Add(this.tbGeneAlphaTitle);
            this.tabGeneIni.Controls.Add(this.label3);
            this.tabGeneIni.Controls.Add(this.tbGeneDiscs);
            this.tabGeneIni.Controls.Add(this.label2);
            this.tabGeneIni.Controls.Add(this.tbGeneTitle);
            this.tabGeneIni.Controls.Add(this.label1);
            this.tabGeneIni.Location = new System.Drawing.Point(4, 22);
            this.tabGeneIni.Name = "tabGeneIni";
            this.tabGeneIni.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneIni.Size = new System.Drawing.Size(692, 530);
            this.tabGeneIni.TabIndex = 1;
            this.tabGeneIni.Text = "Game.ini Generator";
            this.tabGeneIni.UseVisualStyleBackColor = true;
            // 
            // btLink
            // 
            this.btLink.Enabled = false;
            this.btLink.Location = new System.Drawing.Point(253, 499);
            this.btLink.Name = "btLink";
            this.btLink.Size = new System.Drawing.Size(128, 23);
            this.btLink.TabIndex = 24;
            this.btLink.Text = "Go to PSXdatacenter";
            this.btLink.UseVisualStyleBackColor = true;
            this.btLink.Click += new System.EventHandler(this.btLink_Click);
            // 
            // tbHiddenLink
            // 
            this.tbHiddenLink.Enabled = false;
            this.tbHiddenLink.Location = new System.Drawing.Point(56, 349);
            this.tbHiddenLink.Name = "tbHiddenLink";
            this.tbHiddenLink.Size = new System.Drawing.Size(97, 20);
            this.tbHiddenLink.TabIndex = 21;
            this.tbHiddenLink.Visible = false;
            // 
            // btGeneSearch
            // 
            this.btGeneSearch.Location = new System.Drawing.Point(172, 375);
            this.btGeneSearch.Name = "btGeneSearch";
            this.btGeneSearch.Size = new System.Drawing.Size(75, 20);
            this.btGeneSearch.TabIndex = 19;
            this.btGeneSearch.Text = "Search...";
            this.btGeneSearch.UseVisualStyleBackColor = true;
            this.btGeneSearch.Click += new System.EventHandler(this.btGeneSearch_Click);
            // 
            // tbGeneSearchText
            // 
            this.tbGeneSearchText.Location = new System.Drawing.Point(8, 375);
            this.tbGeneSearchText.Name = "tbGeneSearchText";
            this.tbGeneSearchText.Size = new System.Drawing.Size(145, 20);
            this.tbGeneSearchText.TabIndex = 18;
            // 
            // lbGeneBigData
            // 
            this.lbGeneBigData.FormattingEnabled = true;
            this.lbGeneBigData.Location = new System.Drawing.Point(8, 401);
            this.lbGeneBigData.Name = "lbGeneBigData";
            this.lbGeneBigData.ScrollAlwaysVisible = true;
            this.lbGeneBigData.Size = new System.Drawing.Size(239, 121);
            this.lbGeneBigData.TabIndex = 17;
            this.lbGeneBigData.SelectedIndexChanged += new System.EventHandler(this.lbGeneBigData_SelectedIndexChanged);
            // 
            // btGeneCopyTitle
            // 
            this.btGeneCopyTitle.Location = new System.Drawing.Point(221, 58);
            this.btGeneCopyTitle.Name = "btGeneCopyTitle";
            this.btGeneCopyTitle.Size = new System.Drawing.Size(26, 20);
            this.btGeneCopyTitle.TabIndex = 16;
            this.btGeneCopyTitle.Text = "<-";
            this.btGeneCopyTitle.UseVisualStyleBackColor = true;
            this.btGeneCopyTitle.Click += new System.EventHandler(this.btGeneCopyTitle_Click);
            // 
            // btLoadIni
            // 
            this.btLoadIni.Location = new System.Drawing.Point(81, 162);
            this.btLoadIni.Name = "btLoadIni";
            this.btLoadIni.Size = new System.Drawing.Size(75, 23);
            this.btLoadIni.TabIndex = 15;
            this.btLoadIni.Text = "Load...";
            this.btLoadIni.UseVisualStyleBackColor = true;
            this.btLoadIni.Click += new System.EventHandler(this.btLoadIni_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(54, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "(x)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(54, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "(x)";
            // 
            // btGenerateIni
            // 
            this.btGenerateIni.Location = new System.Drawing.Point(172, 162);
            this.btGenerateIni.Name = "btGenerateIni";
            this.btGenerateIni.Size = new System.Drawing.Size(75, 23);
            this.btGenerateIni.TabIndex = 12;
            this.btGenerateIni.Text = "Save...";
            this.btGenerateIni.UseVisualStyleBackColor = true;
            this.btGenerateIni.Click += new System.EventHandler(this.btGenerateIni_Click);
            // 
            // nuGeneYear
            // 
            this.nuGeneYear.Location = new System.Drawing.Point(81, 136);
            this.nuGeneYear.Maximum = new decimal(new int[] {
            2007,
            0,
            0,
            0});
            this.nuGeneYear.Minimum = new decimal(new int[] {
            1994,
            0,
            0,
            0});
            this.nuGeneYear.Name = "nuGeneYear";
            this.nuGeneYear.Size = new System.Drawing.Size(166, 20);
            this.nuGeneYear.TabIndex = 11;
            this.nuGeneYear.Value = new decimal(new int[] {
            1994,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Year";
            // 
            // nuGenePlayers
            // 
            this.nuGenePlayers.Location = new System.Drawing.Point(81, 110);
            this.nuGenePlayers.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nuGenePlayers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nuGenePlayers.Name = "nuGenePlayers";
            this.nuGenePlayers.Size = new System.Drawing.Size(166, 20);
            this.nuGenePlayers.TabIndex = 9;
            this.nuGenePlayers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Players";
            // 
            // tbGenePublisher
            // 
            this.tbGenePublisher.Location = new System.Drawing.Point(81, 84);
            this.tbGenePublisher.Name = "tbGenePublisher";
            this.tbGenePublisher.Size = new System.Drawing.Size(166, 20);
            this.tbGenePublisher.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Publisher";
            // 
            // tbGeneAlphaTitle
            // 
            this.tbGeneAlphaTitle.Location = new System.Drawing.Point(81, 58);
            this.tbGeneAlphaTitle.Name = "tbGeneAlphaTitle";
            this.tbGeneAlphaTitle.Size = new System.Drawing.Size(140, 20);
            this.tbGeneAlphaTitle.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "AlphaTitle";
            // 
            // tbGeneDiscs
            // 
            this.tbGeneDiscs.Location = new System.Drawing.Point(81, 32);
            this.tbGeneDiscs.Name = "tbGeneDiscs";
            this.tbGeneDiscs.Size = new System.Drawing.Size(166, 20);
            this.tbGeneDiscs.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Discs";
            // 
            // tbGeneTitle
            // 
            this.tbGeneTitle.Location = new System.Drawing.Point(81, 6);
            this.tbGeneTitle.Name = "tbGeneTitle";
            this.tbGeneTitle.Size = new System.Drawing.Size(166, 20);
            this.tbGeneTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // sfdGeneSaveIni
            // 
            this.sfdGeneSaveIni.DefaultExt = "ini";
            this.sfdGeneSaveIni.FileName = "Game.ini";
            this.sfdGeneSaveIni.Filter = "ini files|*.ini";
            this.sfdGeneSaveIni.RestoreDirectory = true;
            this.sfdGeneSaveIni.ShowHelp = true;
            this.sfdGeneSaveIni.Title = "Save file";
            // 
            // ofdGeneLoadIni
            // 
            this.ofdGeneLoadIni.DefaultExt = "ini";
            this.ofdGeneLoadIni.FileName = "Game.ini";
            this.ofdGeneLoadIni.Filter = "ini files|*.ini";
            this.ofdGeneLoadIni.RestoreDirectory = true;
            this.ofdGeneLoadIni.ShowHelp = true;
            this.ofdGeneLoadIni.Title = "Load file";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 556);
            this.Controls.Add(this.tabControlAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "pbPSCReAlpha 0.41";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControlAll.ResumeLayout(false);
            this.tabExplorer.ResumeLayout(false);
            this.tabExplorer.PerformLayout();
            this.gbExploreDetails.ResumeLayout(false);
            this.gbExploreDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExploreImage)).EndInit();
            this.tabResortAlphabetic.ResumeLayout(false);
            this.tabResortAlphabetic.PerformLayout();
            this.tabGeneIni.ResumeLayout(false);
            this.tabGeneIni.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuGeneYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuGenePlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdGamesFolder;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.CheckBox cbStartAt21;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.TabControl tabControlAll;
        private System.Windows.Forms.TabPage tabResortAlphabetic;
        private System.Windows.Forms.TabPage tabGeneIni;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btGenerateIni;
        private System.Windows.Forms.NumericUpDown nuGeneYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nuGenePlayers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbGenePublisher;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbGeneAlphaTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbGeneDiscs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGeneTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btLoadIni;
        private System.Windows.Forms.SaveFileDialog sfdGeneSaveIni;
        private System.Windows.Forms.OpenFileDialog ofdGeneLoadIni;
        private System.Windows.Forms.Button btGeneCopyTitle;
        private System.Windows.Forms.Button btGeneSearch;
        private System.Windows.Forms.TextBox tbGeneSearchText;
        private System.Windows.Forms.ListBox lbGeneBigData;
        private System.Windows.Forms.TextBox tbHiddenLink;
        private System.Windows.Forms.Button btLink;
        private System.Windows.Forms.TabPage tabExplorer;
        private System.Windows.Forms.ListBox lbGames;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.TextBox tbLogExplorer;
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
    }
}

