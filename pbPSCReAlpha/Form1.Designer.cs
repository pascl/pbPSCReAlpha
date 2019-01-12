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
            this.btLaunchBleemsync = new System.Windows.Forms.Button();
            this.gbExploreEdit = new System.Windows.Forms.GroupBox();
            this.btRefreshFolderOnly = new System.Windows.Forms.Button();
            this.btAddFiles = new System.Windows.Forms.Button();
            this.btEditCue = new System.Windows.Forms.Button();
            this.btAddPcsxCfg = new System.Windows.Forms.Button();
            this.btEditPng = new System.Windows.Forms.Button();
            this.btEditGameIni = new System.Windows.Forms.Button();
            this.btNewFolder = new System.Windows.Forms.Button();
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
            this.lbGames = new System.Windows.Forms.ListBox();
            this.btRefresh = new System.Windows.Forms.Button();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.btClearLog = new System.Windows.Forms.Button();
            this.btTest = new System.Windows.Forms.Button();
            this.tbLogDebug = new System.Windows.Forms.TextBox();
            this.ofdAddFiles = new System.Windows.Forms.OpenFileDialog();
            this.sfdSaveImage = new System.Windows.Forms.SaveFileDialog();
            this.tabReadMe = new System.Windows.Forms.TabPage();
            this.wbReadme = new System.Windows.Forms.WebBrowser();
            this.tabControlAll.SuspendLayout();
            this.tabExplorer.SuspendLayout();
            this.gbExploreEdit.SuspendLayout();
            this.gbExploreDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExploreImage)).BeginInit();
            this.tabDebug.SuspendLayout();
            this.tabReadMe.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlAll
            // 
            this.tabControlAll.Controls.Add(this.tabExplorer);
            this.tabControlAll.Controls.Add(this.tabDebug);
            this.tabControlAll.Controls.Add(this.tabReadMe);
            this.tabControlAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAll.Location = new System.Drawing.Point(0, 0);
            this.tabControlAll.Name = "tabControlAll";
            this.tabControlAll.SelectedIndex = 0;
            this.tabControlAll.Size = new System.Drawing.Size(704, 601);
            this.tabControlAll.TabIndex = 6;
            this.tabControlAll.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControlAll_Selected);
            // 
            // tabExplorer
            // 
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
            this.tabExplorer.Size = new System.Drawing.Size(696, 575);
            this.tabExplorer.TabIndex = 2;
            this.tabExplorer.Text = "Explorer";
            this.tabExplorer.UseVisualStyleBackColor = true;
            // 
            // btLaunchBleemsync
            // 
            this.btLaunchBleemsync.Image = global::pbPSCReAlpha.Properties.Resources.bleem_logo48;
            this.btLaunchBleemsync.Location = new System.Drawing.Point(3, 515);
            this.btLaunchBleemsync.Name = "btLaunchBleemsync";
            this.btLaunchBleemsync.Size = new System.Drawing.Size(197, 55);
            this.btLaunchBleemsync.TabIndex = 10;
            this.btLaunchBleemsync.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btLaunchBleemsync.UseVisualStyleBackColor = true;
            this.btLaunchBleemsync.Click += new System.EventHandler(this.btLaunchBleemsync_Click);
            // 
            // gbExploreEdit
            // 
            this.gbExploreEdit.Controls.Add(this.btRefreshFolderOnly);
            this.gbExploreEdit.Controls.Add(this.btAddFiles);
            this.gbExploreEdit.Controls.Add(this.btEditCue);
            this.gbExploreEdit.Controls.Add(this.btAddPcsxCfg);
            this.gbExploreEdit.Controls.Add(this.btEditPng);
            this.gbExploreEdit.Controls.Add(this.btEditGameIni);
            this.gbExploreEdit.Location = new System.Drawing.Point(206, 415);
            this.gbExploreEdit.Name = "gbExploreEdit";
            this.gbExploreEdit.Size = new System.Drawing.Size(484, 155);
            this.gbExploreEdit.TabIndex = 9;
            this.gbExploreEdit.TabStop = false;
            this.gbExploreEdit.Text = "Edit";
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
            this.btAddFiles.Location = new System.Drawing.Point(127, 19);
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
            this.btEditCue.Location = new System.Drawing.Point(6, 81);
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
            this.btAddPcsxCfg.Location = new System.Drawing.Point(6, 112);
            this.btAddPcsxCfg.Name = "btAddPcsxCfg";
            this.btAddPcsxCfg.Size = new System.Drawing.Size(115, 25);
            this.btAddPcsxCfg.TabIndex = 2;
            this.btAddPcsxCfg.Text = "Add pcsx.cfg";
            this.btAddPcsxCfg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btAddPcsxCfg.UseVisualStyleBackColor = true;
            this.btAddPcsxCfg.Visible = false;
            this.btAddPcsxCfg.Click += new System.EventHandler(this.btAddPcsxCfg_Click);
            // 
            // btEditPng
            // 
            this.btEditPng.Image = global::pbPSCReAlpha.Properties.Resources.picture_edit;
            this.btEditPng.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEditPng.Location = new System.Drawing.Point(6, 50);
            this.btEditPng.Name = "btEditPng";
            this.btEditPng.Size = new System.Drawing.Size(115, 25);
            this.btEditPng.TabIndex = 1;
            this.btEditPng.Text = "Edit Image";
            this.btEditPng.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btEditPng.UseVisualStyleBackColor = true;
            this.btEditPng.Click += new System.EventHandler(this.btEditPng_Click);
            // 
            // btEditGameIni
            // 
            this.btEditGameIni.Image = global::pbPSCReAlpha.Properties.Resources.edit_3;
            this.btEditGameIni.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEditGameIni.Location = new System.Drawing.Point(6, 19);
            this.btEditGameIni.Name = "btEditGameIni";
            this.btEditGameIni.Size = new System.Drawing.Size(115, 25);
            this.btEditGameIni.TabIndex = 0;
            this.btEditGameIni.Text = "Edit Game.ini";
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
            // tbFolderPath
            // 
            this.tbFolderPath.Location = new System.Drawing.Point(447, 12);
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
            this.gbExploreDetails.Location = new System.Drawing.Point(206, 34);
            this.gbExploreDetails.Name = "gbExploreDetails";
            this.gbExploreDetails.Size = new System.Drawing.Size(484, 375);
            this.gbExploreDetails.TabIndex = 4;
            this.gbExploreDetails.TabStop = false;
            this.gbExploreDetails.Text = "Details";
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
            // lbGames
            // 
            this.lbGames.FormattingEnabled = true;
            this.lbGames.Location = new System.Drawing.Point(3, 34);
            this.lbGames.Name = "lbGames";
            this.lbGames.ScrollAlwaysVisible = true;
            this.lbGames.Size = new System.Drawing.Size(197, 472);
            this.lbGames.TabIndex = 1;
            this.lbGames.SelectedIndexChanged += new System.EventHandler(this.lbGames_SelectedIndexChanged);
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
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.btClearLog);
            this.tabDebug.Controls.Add(this.btTest);
            this.tabDebug.Controls.Add(this.tbLogDebug);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebug.Size = new System.Drawing.Size(696, 575);
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
            // tabReadMe
            // 
            this.tabReadMe.Controls.Add(this.wbReadme);
            this.tabReadMe.Location = new System.Drawing.Point(4, 22);
            this.tabReadMe.Name = "tabReadMe";
            this.tabReadMe.Padding = new System.Windows.Forms.Padding(3);
            this.tabReadMe.Size = new System.Drawing.Size(696, 575);
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
            this.wbReadme.Size = new System.Drawing.Size(690, 569);
            this.wbReadme.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 601);
            this.Controls.Add(this.tabControlAll);
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
            this.gbExploreDetails.ResumeLayout(false);
            this.gbExploreDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExploreImage)).EndInit();
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            this.tabReadMe.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btEditPng;
        private System.Windows.Forms.Button btEditGameIni;
        private System.Windows.Forms.Button btEditCue;
        private System.Windows.Forms.Button btAddPcsxCfg;
        private System.Windows.Forms.Button btAddFiles;
        private System.Windows.Forms.OpenFileDialog ofdAddFiles;
        private System.Windows.Forms.SaveFileDialog sfdSaveImage;
        private System.Windows.Forms.Button btRefreshFolderOnly;
        private System.Windows.Forms.TabPage tabReadMe;
        private System.Windows.Forms.WebBrowser wbReadme;
    }
}

