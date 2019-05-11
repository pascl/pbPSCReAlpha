namespace pbPSCReAlpha
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.ofdLoadBin = new System.Windows.Forms.OpenFileDialog();
            this.btBrowseBin = new System.Windows.Forms.Button();
            this.tbBinFile = new System.Windows.Forms.TextBox();
            this.btBinFindSerial = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.gbBinFiles = new System.Windows.Forms.GroupBox();
            this.lbGameFound = new System.Windows.Forms.Label();
            this.lbResultBinFindSerial = new System.Windows.Forms.Label();
            this.tbSerialFound = new System.Windows.Forms.TextBox();
            this.lbGameInfoFound = new System.Windows.Forms.Label();
            this.gbBinFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdLoadBin
            // 
            this.ofdLoadBin.DefaultExt = "bin";
            this.ofdLoadBin.Filter = "bin files|*.bin";
            // 
            // btBrowseBin
            // 
            this.btBrowseBin.Location = new System.Drawing.Point(248, 17);
            this.btBrowseBin.Name = "btBrowseBin";
            this.btBrowseBin.Size = new System.Drawing.Size(75, 23);
            this.btBrowseBin.TabIndex = 0;
            this.btBrowseBin.Text = "Browse...";
            this.btBrowseBin.UseVisualStyleBackColor = true;
            this.btBrowseBin.Click += new System.EventHandler(this.btBrowseBin_Click);
            // 
            // tbBinFile
            // 
            this.tbBinFile.AllowDrop = true;
            this.tbBinFile.Location = new System.Drawing.Point(6, 19);
            this.tbBinFile.Name = "tbBinFile";
            this.tbBinFile.Size = new System.Drawing.Size(236, 20);
            this.tbBinFile.TabIndex = 1;
            this.tbBinFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbBinFile_DragDrop);
            this.tbBinFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbBinFile_DragEnter);
            this.tbBinFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBinFile_KeyDown);
            // 
            // btBinFindSerial
            // 
            this.btBinFindSerial.Location = new System.Drawing.Point(6, 45);
            this.btBinFindSerial.Name = "btBinFindSerial";
            this.btBinFindSerial.Size = new System.Drawing.Size(75, 23);
            this.btBinFindSerial.TabIndex = 3;
            this.btBinFindSerial.Text = "Find Serial";
            this.btBinFindSerial.UseVisualStyleBackColor = true;
            this.btBinFindSerial.Click += new System.EventHandler(this.btBinFindSerial_Click);
            // 
            // btBack
            // 
            this.btBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btBack.Location = new System.Drawing.Point(260, 117);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 4;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // gbBinFiles
            // 
            this.gbBinFiles.Controls.Add(this.lbGameFound);
            this.gbBinFiles.Controls.Add(this.lbResultBinFindSerial);
            this.gbBinFiles.Controls.Add(this.tbSerialFound);
            this.gbBinFiles.Controls.Add(this.tbBinFile);
            this.gbBinFiles.Controls.Add(this.btBrowseBin);
            this.gbBinFiles.Controls.Add(this.btBinFindSerial);
            this.gbBinFiles.Location = new System.Drawing.Point(12, 12);
            this.gbBinFiles.Name = "gbBinFiles";
            this.gbBinFiles.Size = new System.Drawing.Size(329, 99);
            this.gbBinFiles.TabIndex = 5;
            this.gbBinFiles.TabStop = false;
            this.gbBinFiles.Text = "Select a bin file";
            // 
            // lbGameFound
            // 
            this.lbGameFound.AutoSize = true;
            this.lbGameFound.Location = new System.Drawing.Point(87, 74);
            this.lbGameFound.Name = "lbGameFound";
            this.lbGameFound.Size = new System.Drawing.Size(13, 13);
            this.lbGameFound.TabIndex = 7;
            this.lbGameFound.Text = "--";
            // 
            // lbResultBinFindSerial
            // 
            this.lbResultBinFindSerial.AutoSize = true;
            this.lbResultBinFindSerial.Location = new System.Drawing.Point(87, 50);
            this.lbResultBinFindSerial.Name = "lbResultBinFindSerial";
            this.lbResultBinFindSerial.Size = new System.Drawing.Size(0, 13);
            this.lbResultBinFindSerial.TabIndex = 5;
            // 
            // tbSerialFound
            // 
            this.tbSerialFound.Location = new System.Drawing.Point(6, 71);
            this.tbSerialFound.Name = "tbSerialFound";
            this.tbSerialFound.ReadOnly = true;
            this.tbSerialFound.Size = new System.Drawing.Size(75, 20);
            this.tbSerialFound.TabIndex = 4;
            // 
            // lbGameInfoFound
            // 
            this.lbGameInfoFound.AutoSize = true;
            this.lbGameInfoFound.Location = new System.Drawing.Point(15, 122);
            this.lbGameInfoFound.Name = "lbGameInfoFound";
            this.lbGameInfoFound.Size = new System.Drawing.Size(0, 13);
            this.lbGameInfoFound.TabIndex = 8;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btBack;
            this.ClientSize = new System.Drawing.Size(351, 145);
            this.Controls.Add(this.lbGameInfoFound);
            this.Controls.Add(this.gbBinFiles);
            this.Controls.Add(this.btBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form7";
            this.Text = "Find Serial from Bin";
            this.gbBinFiles.ResumeLayout(false);
            this.gbBinFiles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdLoadBin;
        private System.Windows.Forms.Button btBrowseBin;
        private System.Windows.Forms.TextBox tbBinFile;
        private System.Windows.Forms.Button btBinFindSerial;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.GroupBox gbBinFiles;
        private System.Windows.Forms.Label lbResultBinFindSerial;
        private System.Windows.Forms.TextBox tbSerialFound;
        private System.Windows.Forms.Label lbGameFound;
        private System.Windows.Forms.Label lbGameInfoFound;
    }
}