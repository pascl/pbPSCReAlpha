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
            this.fbdGamesFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.tbFolderPath = new System.Windows.Forms.TextBox();
            this.btCrowseGamesFolder = new System.Windows.Forms.Button();
            this.btGo = new System.Windows.Forms.Button();
            this.cbStartAt21 = new System.Windows.Forms.CheckBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btTest = new System.Windows.Forms.Button();
            this.tabControlAll = new System.Windows.Forms.TabControl();
            this.tabResortAlphabetic = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.lbGeneBigData = new System.Windows.Forms.ListBox();
            this.tbGeneSearchText = new System.Windows.Forms.TextBox();
            this.btGeneSearch = new System.Windows.Forms.Button();
            this.tabControlAll.SuspendLayout();
            this.tabResortAlphabetic.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuGeneYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuGenePlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFolderPath
            // 
            this.tbFolderPath.Location = new System.Drawing.Point(6, 6);
            this.tbFolderPath.Name = "tbFolderPath";
            this.tbFolderPath.Size = new System.Drawing.Size(160, 20);
            this.tbFolderPath.TabIndex = 0;
            this.tbFolderPath.Text = "F:\\Games";
            // 
            // btCrowseGamesFolder
            // 
            this.btCrowseGamesFolder.Location = new System.Drawing.Point(172, 6);
            this.btCrowseGamesFolder.Name = "btCrowseGamesFolder";
            this.btCrowseGamesFolder.Size = new System.Drawing.Size(75, 23);
            this.btCrowseGamesFolder.TabIndex = 1;
            this.btCrowseGamesFolder.Text = "Browse...";
            this.btCrowseGamesFolder.UseVisualStyleBackColor = true;
            this.btCrowseGamesFolder.Click += new System.EventHandler(this.btCrowseGamesFolder_Click);
            // 
            // btGo
            // 
            this.btGo.Location = new System.Drawing.Point(172, 58);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(75, 23);
            this.btGo.TabIndex = 2;
            this.btGo.Text = "Do it!";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // cbStartAt21
            // 
            this.cbStartAt21.AutoSize = true;
            this.cbStartAt21.Location = new System.Drawing.Point(6, 35);
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
            this.tbLog.Size = new System.Drawing.Size(241, 207);
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
            this.tabControlAll.Controls.Add(this.tabResortAlphabetic);
            this.tabControlAll.Controls.Add(this.tabPage2);
            this.tabControlAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAll.Location = new System.Drawing.Point(0, 0);
            this.tabControlAll.Name = "tabControlAll";
            this.tabControlAll.SelectedIndex = 0;
            this.tabControlAll.Size = new System.Drawing.Size(263, 328);
            this.tabControlAll.TabIndex = 6;
            // 
            // tabResortAlphabetic
            // 
            this.tabResortAlphabetic.Controls.Add(this.tbLog);
            this.tabResortAlphabetic.Controls.Add(this.btTest);
            this.tabResortAlphabetic.Controls.Add(this.btGo);
            this.tabResortAlphabetic.Controls.Add(this.cbStartAt21);
            this.tabResortAlphabetic.Controls.Add(this.btCrowseGamesFolder);
            this.tabResortAlphabetic.Controls.Add(this.tbFolderPath);
            this.tabResortAlphabetic.Location = new System.Drawing.Point(4, 22);
            this.tabResortAlphabetic.Name = "tabResortAlphabetic";
            this.tabResortAlphabetic.Padding = new System.Windows.Forms.Padding(3);
            this.tabResortAlphabetic.Size = new System.Drawing.Size(255, 302);
            this.tabResortAlphabetic.TabIndex = 0;
            this.tabResortAlphabetic.Text = "Re-sort Folders";
            this.tabResortAlphabetic.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btGeneSearch);
            this.tabPage2.Controls.Add(this.tbGeneSearchText);
            this.tabPage2.Controls.Add(this.lbGeneBigData);
            this.tabPage2.Controls.Add(this.btGeneCopyTitle);
            this.tabPage2.Controls.Add(this.btLoadIni);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.btGenerateIni);
            this.tabPage2.Controls.Add(this.nuGeneYear);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.nuGenePlayers);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbGenePublisher);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbGeneAlphaTitle);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbGeneDiscs);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.tbGeneTitle);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(255, 302);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Game.ini Generator";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.sfdGeneSaveIni.FileName = "Game.ini";
            this.sfdGeneSaveIni.Filter = "ini files|*.ini";
            this.sfdGeneSaveIni.ShowHelp = true;
            this.sfdGeneSaveIni.Title = "Save file";
            // 
            // ofdGeneLoadIni
            // 
            this.ofdGeneLoadIni.FileName = "Game.ini";
            this.ofdGeneLoadIni.Filter = "ini files|*.ini";
            this.ofdGeneLoadIni.ShowHelp = true;
            this.ofdGeneLoadIni.Title = "Load file";
            // 
            // lbGeneBigData
            // 
            this.lbGeneBigData.FormattingEnabled = true;
            this.lbGeneBigData.Location = new System.Drawing.Point(11, 230);
            this.lbGeneBigData.Name = "lbGeneBigData";
            this.lbGeneBigData.ScrollAlwaysVisible = true;
            this.lbGeneBigData.Size = new System.Drawing.Size(236, 69);
            this.lbGeneBigData.TabIndex = 17;
            this.lbGeneBigData.SelectedIndexChanged += new System.EventHandler(this.lbGeneBigData_SelectedIndexChanged);
            // 
            // tbGeneSearchText
            // 
            this.tbGeneSearchText.Location = new System.Drawing.Point(11, 204);
            this.tbGeneSearchText.Name = "tbGeneSearchText";
            this.tbGeneSearchText.Size = new System.Drawing.Size(145, 20);
            this.tbGeneSearchText.TabIndex = 18;
            // 
            // btGeneSearch
            // 
            this.btGeneSearch.Location = new System.Drawing.Point(172, 204);
            this.btGeneSearch.Name = "btGeneSearch";
            this.btGeneSearch.Size = new System.Drawing.Size(75, 20);
            this.btGeneSearch.TabIndex = 19;
            this.btGeneSearch.Text = "Search...";
            this.btGeneSearch.UseVisualStyleBackColor = true;
            this.btGeneSearch.Click += new System.EventHandler(this.btGeneSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 328);
            this.Controls.Add(this.tabControlAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "pbPSCReAlpha";
            this.tabControlAll.ResumeLayout(false);
            this.tabResortAlphabetic.ResumeLayout(false);
            this.tabResortAlphabetic.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuGeneYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuGenePlayers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdGamesFolder;
        private System.Windows.Forms.TextBox tbFolderPath;
        private System.Windows.Forms.Button btCrowseGamesFolder;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.CheckBox cbStartAt21;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.TabControl tabControlAll;
        private System.Windows.Forms.TabPage tabResortAlphabetic;
        private System.Windows.Forms.TabPage tabPage2;
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
    }
}

