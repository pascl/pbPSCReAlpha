namespace pbPSCReAlpha
{
    partial class Form10
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form10));
            this.btBack = new System.Windows.Forms.Button();
            this.lbGameList = new System.Windows.Forms.ListBox();
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.btAddTo = new System.Windows.Forms.Button();
            this.lbCurrentGames = new System.Windows.Forms.ListBox();
            this.tbCurrentFolder = new System.Windows.Forms.TextBox();
            this.gbSelectedFolder = new System.Windows.Forms.GroupBox();
            this.cbKeepRatioWhenBrowsing = new System.Windows.Forms.CheckBox();
            this.btRemoveSelectedGame = new System.Windows.Forms.Button();
            this.btBrowseImage = new System.Windows.Forms.Button();
            this.pbCurrentFolder = new System.Windows.Forms.PictureBox();
            this.gbFolders = new System.Windows.Forms.GroupBox();
            this.btClearFolders = new System.Windows.Forms.Button();
            this.btRemoveFolder = new System.Windows.Forms.Button();
            this.btNewFolder = new System.Windows.Forms.Button();
            this.gbGameList = new System.Windows.Forms.GroupBox();
            this.cbLauncherGenerate = new System.Windows.Forms.CheckBox();
            this.cbFolderAtFirstBoot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdBrowsePicture = new System.Windows.Forms.OpenFileDialog();
            this.btGenerate = new System.Windows.Forms.Button();
            this.gbSelectedFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentFolder)).BeginInit();
            this.gbFolders.SuspendLayout();
            this.gbGameList.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBack
            // 
            this.btBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btBack.Location = new System.Drawing.Point(693, 415);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(120, 23);
            this.btBack.TabIndex = 8;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // lbGameList
            // 
            this.lbGameList.FormattingEnabled = true;
            this.lbGameList.Location = new System.Drawing.Point(6, 15);
            this.lbGameList.Name = "lbGameList";
            this.lbGameList.ScrollAlwaysVisible = true;
            this.lbGameList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbGameList.Size = new System.Drawing.Size(188, 316);
            this.lbGameList.TabIndex = 9;
            // 
            // tvFolders
            // 
            this.tvFolders.FullRowSelect = true;
            this.tvFolders.Location = new System.Drawing.Point(6, 19);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.Size = new System.Drawing.Size(150, 320);
            this.tvFolders.TabIndex = 10;
            this.tvFolders.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFolders_BeforeSelect);
            this.tvFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterSelect);
            this.tvFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvFolders_KeyDown);
            // 
            // btAddTo
            // 
            this.btAddTo.Image = global::pbPSCReAlpha.Properties.Resources.arrow_left_double;
            this.btAddTo.Location = new System.Drawing.Point(532, 27);
            this.btAddTo.Name = "btAddTo";
            this.btAddTo.Size = new System.Drawing.Size(75, 56);
            this.btAddTo.TabIndex = 11;
            this.btAddTo.UseVisualStyleBackColor = true;
            this.btAddTo.Click += new System.EventHandler(this.btAddTo_Click);
            // 
            // lbCurrentGames
            // 
            this.lbCurrentGames.FormattingEnabled = true;
            this.lbCurrentGames.Location = new System.Drawing.Point(150, 16);
            this.lbCurrentGames.Name = "lbCurrentGames";
            this.lbCurrentGames.ScrollAlwaysVisible = true;
            this.lbCurrentGames.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbCurrentGames.Size = new System.Drawing.Size(188, 381);
            this.lbCurrentGames.TabIndex = 12;
            this.lbCurrentGames.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbCurrentGames_KeyDown);
            // 
            // tbCurrentFolder
            // 
            this.tbCurrentFolder.Location = new System.Drawing.Point(9, 15);
            this.tbCurrentFolder.Name = "tbCurrentFolder";
            this.tbCurrentFolder.Size = new System.Drawing.Size(135, 20);
            this.tbCurrentFolder.TabIndex = 13;
            this.tbCurrentFolder.Leave += new System.EventHandler(this.tbCurrentFolder_Leave);
            // 
            // gbSelectedFolder
            // 
            this.gbSelectedFolder.Controls.Add(this.cbKeepRatioWhenBrowsing);
            this.gbSelectedFolder.Controls.Add(this.btRemoveSelectedGame);
            this.gbSelectedFolder.Controls.Add(this.btBrowseImage);
            this.gbSelectedFolder.Controls.Add(this.tbCurrentFolder);
            this.gbSelectedFolder.Controls.Add(this.pbCurrentFolder);
            this.gbSelectedFolder.Controls.Add(this.lbCurrentGames);
            this.gbSelectedFolder.Enabled = false;
            this.gbSelectedFolder.Location = new System.Drawing.Point(182, 12);
            this.gbSelectedFolder.Name = "gbSelectedFolder";
            this.gbSelectedFolder.Size = new System.Drawing.Size(344, 433);
            this.gbSelectedFolder.TabIndex = 17;
            this.gbSelectedFolder.TabStop = false;
            this.gbSelectedFolder.Text = "Selected Folder";
            // 
            // cbKeepRatioWhenBrowsing
            // 
            this.cbKeepRatioWhenBrowsing.AutoSize = true;
            this.cbKeepRatioWhenBrowsing.Checked = true;
            this.cbKeepRatioWhenBrowsing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepRatioWhenBrowsing.Location = new System.Drawing.Point(9, 211);
            this.cbKeepRatioWhenBrowsing.Name = "cbKeepRatioWhenBrowsing";
            this.cbKeepRatioWhenBrowsing.Size = new System.Drawing.Size(109, 17);
            this.cbKeepRatioWhenBrowsing.TabIndex = 17;
            this.cbKeepRatioWhenBrowsing.Text = "Keep aspect ratio";
            this.cbKeepRatioWhenBrowsing.UseVisualStyleBackColor = true;
            // 
            // btRemoveSelectedGame
            // 
            this.btRemoveSelectedGame.Image = global::pbPSCReAlpha.Properties.Resources.edit_delete_6;
            this.btRemoveSelectedGame.Location = new System.Drawing.Point(150, 403);
            this.btRemoveSelectedGame.Name = "btRemoveSelectedGame";
            this.btRemoveSelectedGame.Size = new System.Drawing.Size(188, 23);
            this.btRemoveSelectedGame.TabIndex = 16;
            this.btRemoveSelectedGame.Text = "Remove selected game(s)";
            this.btRemoveSelectedGame.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRemoveSelectedGame.UseVisualStyleBackColor = true;
            this.btRemoveSelectedGame.Click += new System.EventHandler(this.btRemoveSelectedGame_Click);
            // 
            // btBrowseImage
            // 
            this.btBrowseImage.Image = global::pbPSCReAlpha.Properties.Resources.folder_image;
            this.btBrowseImage.Location = new System.Drawing.Point(9, 182);
            this.btBrowseImage.Name = "btBrowseImage";
            this.btBrowseImage.Size = new System.Drawing.Size(135, 23);
            this.btBrowseImage.TabIndex = 15;
            this.btBrowseImage.Text = "Browse picture...";
            this.btBrowseImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btBrowseImage.UseVisualStyleBackColor = true;
            this.btBrowseImage.Click += new System.EventHandler(this.btBrowseImage_Click);
            // 
            // pbCurrentFolder
            // 
            this.pbCurrentFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCurrentFolder.Location = new System.Drawing.Point(9, 41);
            this.pbCurrentFolder.Name = "pbCurrentFolder";
            this.pbCurrentFolder.Size = new System.Drawing.Size(135, 135);
            this.pbCurrentFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCurrentFolder.TabIndex = 14;
            this.pbCurrentFolder.TabStop = false;
            this.pbCurrentFolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbCurrentFolder_DragDrop);
            this.pbCurrentFolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbCurrentFolder_DragEnter);
            // 
            // gbFolders
            // 
            this.gbFolders.Controls.Add(this.btClearFolders);
            this.gbFolders.Controls.Add(this.btRemoveFolder);
            this.gbFolders.Controls.Add(this.tvFolders);
            this.gbFolders.Controls.Add(this.btNewFolder);
            this.gbFolders.Location = new System.Drawing.Point(12, 12);
            this.gbFolders.Name = "gbFolders";
            this.gbFolders.Size = new System.Drawing.Size(164, 433);
            this.gbFolders.TabIndex = 18;
            this.gbFolders.TabStop = false;
            this.gbFolders.Text = "Folder List";
            // 
            // btClearFolders
            // 
            this.btClearFolders.Image = global::pbPSCReAlpha.Properties.Resources.edit_clear_3;
            this.btClearFolders.Location = new System.Drawing.Point(6, 403);
            this.btClearFolders.Name = "btClearFolders";
            this.btClearFolders.Size = new System.Drawing.Size(150, 23);
            this.btClearFolders.TabIndex = 17;
            this.btClearFolders.Text = "Clear All";
            this.btClearFolders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btClearFolders.UseVisualStyleBackColor = true;
            this.btClearFolders.Click += new System.EventHandler(this.btClearFolders_Click);
            // 
            // btRemoveFolder
            // 
            this.btRemoveFolder.Image = global::pbPSCReAlpha.Properties.Resources.edit_delete_6;
            this.btRemoveFolder.Location = new System.Drawing.Point(6, 374);
            this.btRemoveFolder.Name = "btRemoveFolder";
            this.btRemoveFolder.Size = new System.Drawing.Size(150, 23);
            this.btRemoveFolder.TabIndex = 16;
            this.btRemoveFolder.Text = "Remove folder";
            this.btRemoveFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btRemoveFolder.UseVisualStyleBackColor = true;
            this.btRemoveFolder.Click += new System.EventHandler(this.btRemoveFolder_Click);
            // 
            // btNewFolder
            // 
            this.btNewFolder.Image = global::pbPSCReAlpha.Properties.Resources.list_add;
            this.btNewFolder.Location = new System.Drawing.Point(6, 345);
            this.btNewFolder.Name = "btNewFolder";
            this.btNewFolder.Size = new System.Drawing.Size(150, 23);
            this.btNewFolder.TabIndex = 15;
            this.btNewFolder.Text = "New folder";
            this.btNewFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btNewFolder.UseVisualStyleBackColor = true;
            this.btNewFolder.Click += new System.EventHandler(this.btNewFolder_Click);
            // 
            // gbGameList
            // 
            this.gbGameList.Controls.Add(this.lbGameList);
            this.gbGameList.Location = new System.Drawing.Point(613, 12);
            this.gbGameList.Name = "gbGameList";
            this.gbGameList.Size = new System.Drawing.Size(200, 339);
            this.gbGameList.TabIndex = 19;
            this.gbGameList.TabStop = false;
            this.gbGameList.Text = "All games";
            // 
            // cbLauncherGenerate
            // 
            this.cbLauncherGenerate.AutoSize = true;
            this.cbLauncherGenerate.Checked = true;
            this.cbLauncherGenerate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLauncherGenerate.Location = new System.Drawing.Point(532, 390);
            this.cbLauncherGenerate.Name = "cbLauncherGenerate";
            this.cbLauncherGenerate.Size = new System.Drawing.Size(155, 17);
            this.cbLauncherGenerate.TabIndex = 20;
            this.cbLauncherGenerate.Text = "Create launchers for folders";
            this.cbLauncherGenerate.UseVisualStyleBackColor = true;
            // 
            // cbFolderAtFirstBoot
            // 
            this.cbFolderAtFirstBoot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFolderAtFirstBoot.FormattingEnabled = true;
            this.cbFolderAtFirstBoot.Location = new System.Drawing.Point(693, 359);
            this.cbFolderAtFirstBoot.Name = "cbFolderAtFirstBoot";
            this.cbFolderAtFirstBoot.Size = new System.Drawing.Size(120, 21);
            this.cbFolderAtFirstBoot.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(532, 362);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Choose a folder for first boot:";
            // 
            // ofdBrowsePicture
            // 
            this.ofdBrowsePicture.DefaultExt = "png";
            this.ofdBrowsePicture.FileName = "Game.png";
            this.ofdBrowsePicture.Filter = "image files|*.png;*.jpg;*.jpeg;*.bmp";
            this.ofdBrowsePicture.RestoreDirectory = true;
            this.ofdBrowsePicture.ShowHelp = true;
            this.ofdBrowsePicture.Title = "Load file";
            // 
            // btGenerate
            // 
            this.btGenerate.Image = global::pbPSCReAlpha.Properties.Resources.inode_blockdevice1;
            this.btGenerate.Location = new System.Drawing.Point(693, 386);
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Size = new System.Drawing.Size(120, 23);
            this.btGenerate.TabIndex = 16;
            this.btGenerate.Text = "Generate";
            this.btGenerate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btGenerate.UseVisualStyleBackColor = true;
            this.btGenerate.Click += new System.EventHandler(this.btGenerate_Click);
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btBack;
            this.ClientSize = new System.Drawing.Size(821, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFolderAtFirstBoot);
            this.Controls.Add(this.cbLauncherGenerate);
            this.Controls.Add(this.gbGameList);
            this.Controls.Add(this.gbFolders);
            this.Controls.Add(this.gbSelectedFolder);
            this.Controls.Add(this.btGenerate);
            this.Controls.Add(this.btAddTo);
            this.Controls.Add(this.btBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form10";
            this.Text = "Folder Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form10_FormClosing);
            this.gbSelectedFolder.ResumeLayout(false);
            this.gbSelectedFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentFolder)).EndInit();
            this.gbFolders.ResumeLayout(false);
            this.gbGameList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.ListBox lbGameList;
        private System.Windows.Forms.TreeView tvFolders;
        private System.Windows.Forms.Button btAddTo;
        private System.Windows.Forms.ListBox lbCurrentGames;
        private System.Windows.Forms.TextBox tbCurrentFolder;
        private System.Windows.Forms.PictureBox pbCurrentFolder;
        private System.Windows.Forms.Button btNewFolder;
        private System.Windows.Forms.Button btGenerate;
        private System.Windows.Forms.GroupBox gbSelectedFolder;
        private System.Windows.Forms.Button btRemoveSelectedGame;
        private System.Windows.Forms.Button btBrowseImage;
        private System.Windows.Forms.GroupBox gbFolders;
        private System.Windows.Forms.Button btRemoveFolder;
        private System.Windows.Forms.GroupBox gbGameList;
        private System.Windows.Forms.Button btClearFolders;
        private System.Windows.Forms.CheckBox cbLauncherGenerate;
        private System.Windows.Forms.ComboBox cbFolderAtFirstBoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog ofdBrowsePicture;
        private System.Windows.Forms.CheckBox cbKeepRatioWhenBrowsing;
    }
}