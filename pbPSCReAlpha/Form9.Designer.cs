namespace pbPSCReAlpha
{
    partial class Form9
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9));
            this.btGenerateDB = new System.Windows.Forms.Button();
            this.rbDBCreationOneFile = new System.Windows.Forms.RadioButton();
            this.rbDBCreationSeveralFilesWithFirstEmpty = new System.Windows.Forms.RadioButton();
            this.rbDBCreationSeveralFiles = new System.Windows.Forms.RadioButton();
            this.nudMaxGamesPerFolder = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btBack = new System.Windows.Forms.Button();
            this.rbDBCreationSeveralFilesWithFirstNoSpecial = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGamesPerFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // btGenerateDB
            // 
            this.btGenerateDB.Image = global::pbPSCReAlpha.Properties.Resources.inode_blockdevice1;
            this.btGenerateDB.Location = new System.Drawing.Point(12, 156);
            this.btGenerateDB.Name = "btGenerateDB";
            this.btGenerateDB.Size = new System.Drawing.Size(445, 42);
            this.btGenerateDB.TabIndex = 0;
            this.btGenerateDB.Text = "Generate Database";
            this.btGenerateDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGenerateDB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btGenerateDB.UseVisualStyleBackColor = true;
            this.btGenerateDB.Click += new System.EventHandler(this.btGenerateDB_Click);
            // 
            // rbDBCreationOneFile
            // 
            this.rbDBCreationOneFile.AutoSize = true;
            this.rbDBCreationOneFile.Location = new System.Drawing.Point(12, 12);
            this.rbDBCreationOneFile.Name = "rbDBCreationOneFile";
            this.rbDBCreationOneFile.Size = new System.Drawing.Size(135, 17);
            this.rbDBCreationOneFile.TabIndex = 2;
            this.rbDBCreationOneFile.TabStop = true;
            this.rbDBCreationOneFile.Text = "Generate DB in one file";
            this.rbDBCreationOneFile.UseVisualStyleBackColor = true;
            this.rbDBCreationOneFile.CheckedChanged += new System.EventHandler(this.rbDBCreationOneFile_CheckedChanged);
            this.rbDBCreationOneFile.Click += new System.EventHandler(this.rbDBCreationOneFile_Click);
            // 
            // rbDBCreationSeveralFilesWithFirstEmpty
            // 
            this.rbDBCreationSeveralFilesWithFirstEmpty.AutoSize = true;
            this.rbDBCreationSeveralFilesWithFirstEmpty.Location = new System.Drawing.Point(12, 58);
            this.rbDBCreationSeveralFilesWithFirstEmpty.Name = "rbDBCreationSeveralFilesWithFirstEmpty";
            this.rbDBCreationSeveralFilesWithFirstEmpty.Size = new System.Drawing.Size(424, 17);
            this.rbDBCreationSeveralFilesWithFirstEmpty.TabIndex = 3;
            this.rbDBCreationSeveralFilesWithFirstEmpty.TabStop = true;
            this.rbDBCreationSeveralFilesWithFirstEmpty.Text = "Generate DB in several files with the first file empty (only stock games in Home " +
    "folder)";
            this.rbDBCreationSeveralFilesWithFirstEmpty.UseVisualStyleBackColor = true;
            this.rbDBCreationSeveralFilesWithFirstEmpty.CheckedChanged += new System.EventHandler(this.rbDBCreationSeveralFilesWithFirstEmpty_CheckedChanged);
            this.rbDBCreationSeveralFilesWithFirstEmpty.Click += new System.EventHandler(this.rbDBCreationSeveralFilesWithFirstEmpty_Click);
            // 
            // rbDBCreationSeveralFiles
            // 
            this.rbDBCreationSeveralFiles.AutoSize = true;
            this.rbDBCreationSeveralFiles.Location = new System.Drawing.Point(12, 35);
            this.rbDBCreationSeveralFiles.Name = "rbDBCreationSeveralFiles";
            this.rbDBCreationSeveralFiles.Size = new System.Drawing.Size(393, 17);
            this.rbDBCreationSeveralFiles.TabIndex = 4;
            this.rbDBCreationSeveralFiles.TabStop = true;
            this.rbDBCreationSeveralFiles.Text = "Generate DB in several files (1st page contains 20 games less than the others)";
            this.rbDBCreationSeveralFiles.UseVisualStyleBackColor = true;
            this.rbDBCreationSeveralFiles.CheckedChanged += new System.EventHandler(this.rbDBCreationSeveralFiles_CheckedChanged);
            this.rbDBCreationSeveralFiles.Click += new System.EventHandler(this.rbDBCreationSeveralFiles_Click);
            // 
            // nudMaxGamesPerFolder
            // 
            this.nudMaxGamesPerFolder.Location = new System.Drawing.Point(366, 116);
            this.nudMaxGamesPerFolder.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudMaxGamesPerFolder.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudMaxGamesPerFolder.Name = "nudMaxGamesPerFolder";
            this.nudMaxGamesPerFolder.Size = new System.Drawing.Size(91, 20);
            this.nudMaxGamesPerFolder.TabIndex = 5;
            this.nudMaxGamesPerFolder.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Maximum number of games per folder:";
            // 
            // btBack
            // 
            this.btBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btBack.Location = new System.Drawing.Point(382, 204);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 7;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // rbDBCreationSeveralFilesWithFirstNoSpecial
            // 
            this.rbDBCreationSeveralFilesWithFirstNoSpecial.AutoSize = true;
            this.rbDBCreationSeveralFilesWithFirstNoSpecial.Location = new System.Drawing.Point(12, 81);
            this.rbDBCreationSeveralFilesWithFirstNoSpecial.Name = "rbDBCreationSeveralFilesWithFirstNoSpecial";
            this.rbDBCreationSeveralFilesWithFirstNoSpecial.Size = new System.Drawing.Size(447, 17);
            this.rbDBCreationSeveralFilesWithFirstNoSpecial.TabIndex = 8;
            this.rbDBCreationSeveralFilesWithFirstNoSpecial.TabStop = true;
            this.rbDBCreationSeveralFilesWithFirstNoSpecial.Text = "Generate DB in several files (the 1st page, contains as many custom games as the " +
    "others)";
            this.rbDBCreationSeveralFilesWithFirstNoSpecial.UseVisualStyleBackColor = true;
            this.rbDBCreationSeveralFilesWithFirstNoSpecial.CheckedChanged += new System.EventHandler(this.rbDBCreationSeveralFilesWithFirstNoSpecial_CheckedChanged);
            this.rbDBCreationSeveralFilesWithFirstNoSpecial.Click += new System.EventHandler(this.rbDBCreationSeveralFilesWithFirstNoSpecial_Click);
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btBack;
            this.ClientSize = new System.Drawing.Size(460, 239);
            this.Controls.Add(this.rbDBCreationSeveralFilesWithFirstNoSpecial);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudMaxGamesPerFolder);
            this.Controls.Add(this.rbDBCreationSeveralFiles);
            this.Controls.Add(this.rbDBCreationSeveralFilesWithFirstEmpty);
            this.Controls.Add(this.rbDBCreationOneFile);
            this.Controls.Add(this.btGenerateDB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form9";
            this.Text = "Advanced Database Generation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form9_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGamesPerFolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btGenerateDB;
        private System.Windows.Forms.RadioButton rbDBCreationOneFile;
        private System.Windows.Forms.RadioButton rbDBCreationSeveralFilesWithFirstEmpty;
        private System.Windows.Forms.RadioButton rbDBCreationSeveralFiles;
        private System.Windows.Forms.NumericUpDown nudMaxGamesPerFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.RadioButton rbDBCreationSeveralFilesWithFirstNoSpecial;
    }
}