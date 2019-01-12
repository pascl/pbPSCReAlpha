namespace pbPSCReAlpha
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btLink = new System.Windows.Forms.Button();
            this.btGeneSearch = new System.Windows.Forms.Button();
            this.tbGeneSearchText = new System.Windows.Forms.TextBox();
            this.lbGeneBigData = new System.Windows.Forms.ListBox();
            this.tbHiddenLink = new System.Windows.Forms.TextBox();
            this.btBack = new System.Windows.Forms.Button();
            this.sfdGeneSaveIni = new System.Windows.Forms.SaveFileDialog();
            this.ofdGeneLoadIni = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuGeneYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuGenePlayers)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btGeneCopyTitle);
            this.groupBox1.Controls.Add(this.btLoadIni);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btGenerateIni);
            this.groupBox1.Controls.Add(this.nuGeneYear);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nuGenePlayers);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbGenePublisher);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbGeneAlphaTitle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbGeneDiscs);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbGeneTitle);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Game.ini";
            // 
            // btGeneCopyTitle
            // 
            this.btGeneCopyTitle.Location = new System.Drawing.Point(329, 71);
            this.btGeneCopyTitle.Name = "btGeneCopyTitle";
            this.btGeneCopyTitle.Size = new System.Drawing.Size(26, 20);
            this.btGeneCopyTitle.TabIndex = 33;
            this.btGeneCopyTitle.Text = "<-";
            this.btGeneCopyTitle.UseVisualStyleBackColor = true;
            // 
            // btLoadIni
            // 
            this.btLoadIni.Location = new System.Drawing.Point(157, 175);
            this.btLoadIni.Name = "btLoadIni";
            this.btLoadIni.Size = new System.Drawing.Size(87, 23);
            this.btLoadIni.TabIndex = 32;
            this.btLoadIni.Text = "Load...";
            this.btLoadIni.UseVisualStyleBackColor = true;
            this.btLoadIni.Click += new System.EventHandler(this.btLoadIni_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(104, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "(x)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkRed;
            this.label7.Location = new System.Drawing.Point(104, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "(x)";
            // 
            // btGenerateIni
            // 
            this.btGenerateIni.Location = new System.Drawing.Point(268, 175);
            this.btGenerateIni.Name = "btGenerateIni";
            this.btGenerateIni.Size = new System.Drawing.Size(87, 23);
            this.btGenerateIni.TabIndex = 29;
            this.btGenerateIni.Text = "Save...";
            this.btGenerateIni.UseVisualStyleBackColor = true;
            this.btGenerateIni.Click += new System.EventHandler(this.btGenerateIni_Click);
            // 
            // nuGeneYear
            // 
            this.nuGeneYear.Location = new System.Drawing.Point(157, 149);
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
            this.nuGeneYear.Size = new System.Drawing.Size(198, 20);
            this.nuGeneYear.TabIndex = 28;
            this.nuGeneYear.Value = new decimal(new int[] {
            1994,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Year";
            // 
            // nuGenePlayers
            // 
            this.nuGenePlayers.Location = new System.Drawing.Point(157, 123);
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
            this.nuGenePlayers.Size = new System.Drawing.Size(198, 20);
            this.nuGenePlayers.TabIndex = 26;
            this.nuGenePlayers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Players";
            // 
            // tbGenePublisher
            // 
            this.tbGenePublisher.Location = new System.Drawing.Point(157, 97);
            this.tbGenePublisher.Name = "tbGenePublisher";
            this.tbGenePublisher.Size = new System.Drawing.Size(198, 20);
            this.tbGenePublisher.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Publisher";
            // 
            // tbGeneAlphaTitle
            // 
            this.tbGeneAlphaTitle.Location = new System.Drawing.Point(157, 71);
            this.tbGeneAlphaTitle.Name = "tbGeneAlphaTitle";
            this.tbGeneAlphaTitle.Size = new System.Drawing.Size(172, 20);
            this.tbGeneAlphaTitle.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "AlphaTitle";
            // 
            // tbGeneDiscs
            // 
            this.tbGeneDiscs.Location = new System.Drawing.Point(157, 45);
            this.tbGeneDiscs.Name = "tbGeneDiscs";
            this.tbGeneDiscs.Size = new System.Drawing.Size(198, 20);
            this.tbGeneDiscs.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Discs";
            // 
            // tbGeneTitle
            // 
            this.tbGeneTitle.Location = new System.Drawing.Point(157, 19);
            this.tbGeneTitle.Name = "tbGeneTitle";
            this.tbGeneTitle.Size = new System.Drawing.Size(198, 20);
            this.tbGeneTitle.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Title";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btLink);
            this.groupBox2.Controls.Add(this.btGeneSearch);
            this.groupBox2.Controls.Add(this.tbGeneSearchText);
            this.groupBox2.Controls.Add(this.lbGeneBigData);
            this.groupBox2.Location = new System.Drawing.Point(1, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 206);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search";
            // 
            // btLink
            // 
            this.btLink.Enabled = false;
            this.btLink.Location = new System.Drawing.Point(229, 43);
            this.btLink.Name = "btLink";
            this.btLink.Size = new System.Drawing.Size(169, 23);
            this.btLink.TabIndex = 29;
            this.btLink.Text = "Go to PSXdatacenter";
            this.btLink.UseVisualStyleBackColor = true;
            this.btLink.Click += new System.EventHandler(this.btLink_Click);
            // 
            // btGeneSearch
            // 
            this.btGeneSearch.Location = new System.Drawing.Point(229, 14);
            this.btGeneSearch.Name = "btGeneSearch";
            this.btGeneSearch.Size = new System.Drawing.Size(169, 23);
            this.btGeneSearch.TabIndex = 27;
            this.btGeneSearch.Text = "Search...";
            this.btGeneSearch.UseVisualStyleBackColor = true;
            this.btGeneSearch.Click += new System.EventHandler(this.btGeneSearch_Click);
            // 
            // tbGeneSearchText
            // 
            this.tbGeneSearchText.Location = new System.Drawing.Point(6, 16);
            this.tbGeneSearchText.Name = "tbGeneSearchText";
            this.tbGeneSearchText.Size = new System.Drawing.Size(217, 20);
            this.tbGeneSearchText.TabIndex = 26;
            // 
            // lbGeneBigData
            // 
            this.lbGeneBigData.FormattingEnabled = true;
            this.lbGeneBigData.Location = new System.Drawing.Point(6, 79);
            this.lbGeneBigData.Name = "lbGeneBigData";
            this.lbGeneBigData.ScrollAlwaysVisible = true;
            this.lbGeneBigData.Size = new System.Drawing.Size(392, 121);
            this.lbGeneBigData.TabIndex = 25;
            this.lbGeneBigData.SelectedIndexChanged += new System.EventHandler(this.lbGeneBigData_SelectedIndexChanged);
            // 
            // tbHiddenLink
            // 
            this.tbHiddenLink.Enabled = false;
            this.tbHiddenLink.Location = new System.Drawing.Point(7, 426);
            this.tbHiddenLink.Name = "tbHiddenLink";
            this.tbHiddenLink.Size = new System.Drawing.Size(97, 20);
            this.tbHiddenLink.TabIndex = 28;
            this.tbHiddenLink.Visible = false;
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(330, 426);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 2;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 452);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.tbHiddenLink);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.Text = "Game.ini Helper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nuGeneYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuGenePlayers)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btGeneCopyTitle;
        private System.Windows.Forms.Button btLoadIni;
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btLink;
        private System.Windows.Forms.TextBox tbHiddenLink;
        private System.Windows.Forms.Button btGeneSearch;
        private System.Windows.Forms.TextBox tbGeneSearchText;
        private System.Windows.Forms.ListBox lbGeneBigData;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.SaveFileDialog sfdGeneSaveIni;
        private System.Windows.Forms.OpenFileDialog ofdGeneLoadIni;
    }
}