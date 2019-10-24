namespace pbPSCReAlpha
{
    partial class Form12
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form12));
            this.tbContent = new System.Windows.Forms.TextBox();
            this.btBack = new System.Windows.Forms.Button();
            this.cbLaunchScriptChoice = new System.Windows.Forms.ComboBox();
            this.gbRetroarch = new System.Windows.Forms.GroupBox();
            this.cbCores_RA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btReplaceCore_RA = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFiles_RA = new System.Windows.Forms.ComboBox();
            this.btReplaceFileName_RA = new System.Windows.Forms.Button();
            this.gbDrastic = new System.Windows.Forms.GroupBox();
            this.btReplaceFileName_DS = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFiles_DS = new System.Windows.Forms.ComboBox();
            this.gbFolder = new System.Windows.Forms.GroupBox();
            this.btReplaceFolderIndex_Folder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudFolderIndex = new System.Windows.Forms.NumericUpDown();
            this.btReport = new System.Windows.Forms.Button();
            this.gbRetroarch.SuspendLayout();
            this.gbDrastic.SuspendLayout();
            this.gbFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFolderIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // tbContent
            // 
            this.tbContent.Enabled = false;
            this.tbContent.Location = new System.Drawing.Point(12, 39);
            this.tbContent.Multiline = true;
            this.tbContent.Name = "tbContent";
            this.tbContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbContent.Size = new System.Drawing.Size(940, 247);
            this.tbContent.TabIndex = 0;
            // 
            // btBack
            // 
            this.btBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btBack.Location = new System.Drawing.Point(877, 336);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 4;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // cbLaunchScriptChoice
            // 
            this.cbLaunchScriptChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLaunchScriptChoice.FormattingEnabled = true;
            this.cbLaunchScriptChoice.Location = new System.Drawing.Point(12, 12);
            this.cbLaunchScriptChoice.Name = "cbLaunchScriptChoice";
            this.cbLaunchScriptChoice.Size = new System.Drawing.Size(317, 21);
            this.cbLaunchScriptChoice.TabIndex = 5;
            this.cbLaunchScriptChoice.SelectedIndexChanged += new System.EventHandler(this.cbLaunchScriptChoice_SelectedIndexChanged);
            // 
            // gbRetroarch
            // 
            this.gbRetroarch.Controls.Add(this.btReplaceFileName_RA);
            this.gbRetroarch.Controls.Add(this.cbFiles_RA);
            this.gbRetroarch.Controls.Add(this.label2);
            this.gbRetroarch.Controls.Add(this.btReplaceCore_RA);
            this.gbRetroarch.Controls.Add(this.label1);
            this.gbRetroarch.Controls.Add(this.cbCores_RA);
            this.gbRetroarch.Enabled = false;
            this.gbRetroarch.Location = new System.Drawing.Point(12, 292);
            this.gbRetroarch.Name = "gbRetroarch";
            this.gbRetroarch.Size = new System.Drawing.Size(761, 67);
            this.gbRetroarch.TabIndex = 6;
            this.gbRetroarch.TabStop = false;
            this.gbRetroarch.Text = "Replace";
            this.gbRetroarch.Visible = false;
            // 
            // cbCores_RA
            // 
            this.cbCores_RA.FormattingEnabled = true;
            this.cbCores_RA.Location = new System.Drawing.Point(6, 30);
            this.cbCores_RA.Name = "cbCores_RA";
            this.cbCores_RA.Size = new System.Drawing.Size(311, 21);
            this.cbCores_RA.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = " XXXXXYYYYY =";
            // 
            // btReplaceCore_RA
            // 
            this.btReplaceCore_RA.Image = global::pbPSCReAlpha.Properties.Resources.arrow_right_4;
            this.btReplaceCore_RA.Location = new System.Drawing.Point(323, 28);
            this.btReplaceCore_RA.Name = "btReplaceCore_RA";
            this.btReplaceCore_RA.Size = new System.Drawing.Size(31, 23);
            this.btReplaceCore_RA.TabIndex = 2;
            this.btReplaceCore_RA.UseVisualStyleBackColor = true;
            this.btReplaceCore_RA.Click += new System.EventHandler(this.btReplaceCore_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "YYYYYXXXXX =";
            // 
            // cbFiles_RA
            // 
            this.cbFiles_RA.FormattingEnabled = true;
            this.cbFiles_RA.Location = new System.Drawing.Point(398, 30);
            this.cbFiles_RA.Name = "cbFiles_RA";
            this.cbFiles_RA.Size = new System.Drawing.Size(311, 21);
            this.cbFiles_RA.TabIndex = 4;
            // 
            // btReplaceFileName_RA
            // 
            this.btReplaceFileName_RA.Image = global::pbPSCReAlpha.Properties.Resources.arrow_right_4;
            this.btReplaceFileName_RA.Location = new System.Drawing.Point(715, 28);
            this.btReplaceFileName_RA.Name = "btReplaceFileName_RA";
            this.btReplaceFileName_RA.Size = new System.Drawing.Size(31, 23);
            this.btReplaceFileName_RA.TabIndex = 5;
            this.btReplaceFileName_RA.UseVisualStyleBackColor = true;
            this.btReplaceFileName_RA.Click += new System.EventHandler(this.btReplaceFileName_RA_Click);
            // 
            // gbDrastic
            // 
            this.gbDrastic.Controls.Add(this.btReplaceFileName_DS);
            this.gbDrastic.Controls.Add(this.label4);
            this.gbDrastic.Controls.Add(this.cbFiles_DS);
            this.gbDrastic.Enabled = false;
            this.gbDrastic.Location = new System.Drawing.Point(12, 438);
            this.gbDrastic.Name = "gbDrastic";
            this.gbDrastic.Size = new System.Drawing.Size(761, 67);
            this.gbDrastic.TabIndex = 7;
            this.gbDrastic.TabStop = false;
            this.gbDrastic.Text = "Replace";
            this.gbDrastic.Visible = false;
            // 
            // btReplaceFileName_DS
            // 
            this.btReplaceFileName_DS.Image = global::pbPSCReAlpha.Properties.Resources.arrow_right_4;
            this.btReplaceFileName_DS.Location = new System.Drawing.Point(323, 28);
            this.btReplaceFileName_DS.Name = "btReplaceFileName_DS";
            this.btReplaceFileName_DS.Size = new System.Drawing.Size(31, 23);
            this.btReplaceFileName_DS.TabIndex = 2;
            this.btReplaceFileName_DS.UseVisualStyleBackColor = true;
            this.btReplaceFileName_DS.Click += new System.EventHandler(this.btReplaceFileName_DS_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = " XXXXXYYYYY =";
            // 
            // cbFiles_DS
            // 
            this.cbFiles_DS.FormattingEnabled = true;
            this.cbFiles_DS.Location = new System.Drawing.Point(6, 30);
            this.cbFiles_DS.Name = "cbFiles_DS";
            this.cbFiles_DS.Size = new System.Drawing.Size(311, 21);
            this.cbFiles_DS.TabIndex = 0;
            // 
            // gbFolder
            // 
            this.gbFolder.Controls.Add(this.nudFolderIndex);
            this.gbFolder.Controls.Add(this.btReplaceFolderIndex_Folder);
            this.gbFolder.Controls.Add(this.label3);
            this.gbFolder.Enabled = false;
            this.gbFolder.Location = new System.Drawing.Point(12, 365);
            this.gbFolder.Name = "gbFolder";
            this.gbFolder.Size = new System.Drawing.Size(761, 67);
            this.gbFolder.TabIndex = 8;
            this.gbFolder.TabStop = false;
            this.gbFolder.Text = "Replace";
            this.gbFolder.Visible = false;
            // 
            // btReplaceFolderIndex_Folder
            // 
            this.btReplaceFolderIndex_Folder.Image = global::pbPSCReAlpha.Properties.Resources.arrow_right_4;
            this.btReplaceFolderIndex_Folder.Location = new System.Drawing.Point(323, 28);
            this.btReplaceFolderIndex_Folder.Name = "btReplaceFolderIndex_Folder";
            this.btReplaceFolderIndex_Folder.Size = new System.Drawing.Size(31, 23);
            this.btReplaceFolderIndex_Folder.TabIndex = 2;
            this.btReplaceFolderIndex_Folder.UseVisualStyleBackColor = true;
            this.btReplaceFolderIndex_Folder.Click += new System.EventHandler(this.btReplaceFolderIndex_Folder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = " XXXXXYYYYY =";
            // 
            // nudFolderIndex
            // 
            this.nudFolderIndex.Location = new System.Drawing.Point(6, 32);
            this.nudFolderIndex.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudFolderIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudFolderIndex.Name = "nudFolderIndex";
            this.nudFolderIndex.Size = new System.Drawing.Size(311, 20);
            this.nudFolderIndex.TabIndex = 3;
            this.nudFolderIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btReport
            // 
            this.btReport.Location = new System.Drawing.Point(877, 303);
            this.btReport.Name = "btReport";
            this.btReport.Size = new System.Drawing.Size(75, 23);
            this.btReport.TabIndex = 9;
            this.btReport.Text = "Complete";
            this.btReport.UseVisualStyleBackColor = true;
            this.btReport.Click += new System.EventHandler(this.btReport_Click);
            // 
            // Form12
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btBack;
            this.ClientSize = new System.Drawing.Size(964, 511);
            this.Controls.Add(this.btReport);
            this.Controls.Add(this.gbDrastic);
            this.Controls.Add(this.gbFolder);
            this.Controls.Add(this.gbRetroarch);
            this.Controls.Add(this.cbLaunchScriptChoice);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.tbContent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form12";
            this.Text = "Template launch.sh";
            this.gbRetroarch.ResumeLayout(false);
            this.gbRetroarch.PerformLayout();
            this.gbDrastic.ResumeLayout(false);
            this.gbDrastic.PerformLayout();
            this.gbFolder.ResumeLayout(false);
            this.gbFolder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFolderIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.ComboBox cbLaunchScriptChoice;
        private System.Windows.Forms.GroupBox gbRetroarch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCores_RA;
        private System.Windows.Forms.Button btReplaceCore_RA;
        private System.Windows.Forms.Button btReplaceFileName_RA;
        private System.Windows.Forms.ComboBox cbFiles_RA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbDrastic;
        private System.Windows.Forms.Button btReplaceFileName_DS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFiles_DS;
        private System.Windows.Forms.GroupBox gbFolder;
        private System.Windows.Forms.NumericUpDown nudFolderIndex;
        private System.Windows.Forms.Button btReplaceFolderIndex_Folder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btReport;
    }
}