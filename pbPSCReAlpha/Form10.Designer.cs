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
            this.pbCurrentFolder = new System.Windows.Forms.PictureBox();
            this.btNewFolder = new System.Windows.Forms.Button();
            this.btGenerate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentFolder)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBack
            // 
            this.btBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btBack.Location = new System.Drawing.Point(713, 415);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 8;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // lbGameList
            // 
            this.lbGameList.FormattingEnabled = true;
            this.lbGameList.Location = new System.Drawing.Point(295, 51);
            this.lbGameList.Name = "lbGameList";
            this.lbGameList.ScrollAlwaysVisible = true;
            this.lbGameList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbGameList.Size = new System.Drawing.Size(150, 394);
            this.lbGameList.TabIndex = 9;
            // 
            // tvFolders
            // 
            this.tvFolders.Location = new System.Drawing.Point(7, 12);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.Size = new System.Drawing.Size(150, 216);
            this.tvFolders.TabIndex = 10;
            this.tvFolders.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvFolders_BeforeSelect);
            this.tvFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterSelect);
            // 
            // btAddTo
            // 
            this.btAddTo.Location = new System.Drawing.Point(451, 62);
            this.btAddTo.Name = "btAddTo";
            this.btAddTo.Size = new System.Drawing.Size(75, 23);
            this.btAddTo.TabIndex = 11;
            this.btAddTo.Text = ">>";
            this.btAddTo.UseVisualStyleBackColor = true;
            this.btAddTo.Click += new System.EventHandler(this.btAddTo_Click);
            // 
            // lbCurrentGames
            // 
            this.lbCurrentGames.FormattingEnabled = true;
            this.lbCurrentGames.Location = new System.Drawing.Point(532, 51);
            this.lbCurrentGames.Name = "lbCurrentGames";
            this.lbCurrentGames.ScrollAlwaysVisible = true;
            this.lbCurrentGames.Size = new System.Drawing.Size(175, 394);
            this.lbCurrentGames.TabIndex = 12;
            // 
            // tbCurrentFolder
            // 
            this.tbCurrentFolder.Location = new System.Drawing.Point(9, 19);
            this.tbCurrentFolder.Name = "tbCurrentFolder";
            this.tbCurrentFolder.Size = new System.Drawing.Size(135, 20);
            this.tbCurrentFolder.TabIndex = 13;
            this.tbCurrentFolder.Leave += new System.EventHandler(this.tbCurrentFolder_Leave);
            // 
            // pbCurrentFolder
            // 
            this.pbCurrentFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCurrentFolder.Location = new System.Drawing.Point(9, 41);
            this.pbCurrentFolder.Name = "pbCurrentFolder";
            this.pbCurrentFolder.Size = new System.Drawing.Size(135, 135);
            this.pbCurrentFolder.TabIndex = 14;
            this.pbCurrentFolder.TabStop = false;
            // 
            // btNewFolder
            // 
            this.btNewFolder.Location = new System.Drawing.Point(7, 234);
            this.btNewFolder.Name = "btNewFolder";
            this.btNewFolder.Size = new System.Drawing.Size(150, 23);
            this.btNewFolder.TabIndex = 15;
            this.btNewFolder.Text = "New folder";
            this.btNewFolder.UseVisualStyleBackColor = true;
            this.btNewFolder.Click += new System.EventHandler(this.btNewFolder_Click);
            // 
            // btGenerate
            // 
            this.btGenerate.Location = new System.Drawing.Point(713, 386);
            this.btGenerate.Name = "btGenerate";
            this.btGenerate.Size = new System.Drawing.Size(75, 23);
            this.btGenerate.TabIndex = 16;
            this.btGenerate.Text = "Generate";
            this.btGenerate.UseVisualStyleBackColor = true;
            this.btGenerate.Click += new System.EventHandler(this.btGenerate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCurrentFolder);
            this.groupBox1.Controls.Add(this.pbCurrentFolder);
            this.groupBox1.Location = new System.Drawing.Point(7, 263);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 178);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Folder";
            // 
            // Form10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btBack;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btGenerate);
            this.Controls.Add(this.btNewFolder);
            this.Controls.Add(this.lbCurrentGames);
            this.Controls.Add(this.btAddTo);
            this.Controls.Add(this.tvFolders);
            this.Controls.Add(this.lbGameList);
            this.Controls.Add(this.btBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form10";
            this.Text = "Folder Manager";
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentFolder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
    }
}