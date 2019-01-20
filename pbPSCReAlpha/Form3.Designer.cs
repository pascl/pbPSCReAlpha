namespace pbPSCReAlpha
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSaveAs = new System.Windows.Forms.Button();
            this.btLoad = new System.Windows.Forms.Button();
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.ofdGeneLoadImage = new System.Windows.Forms.OpenFileDialog();
            this.sfdGeneSaveImage = new System.Windows.Forms.SaveFileDialog();
            this.btBack = new System.Windows.Forms.Button();
            this.btCompress = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.lbCurrentPngFile = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbCurrentPngFile);
            this.groupBox1.Controls.Add(this.btSave);
            this.groupBox1.Controls.Add(this.btSaveAs);
            this.groupBox1.Controls.Add(this.btLoad);
            this.groupBox1.Controls.Add(this.pbCover);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(245, 195);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Picture Edit";
            // 
            // btSaveAs
            // 
            this.btSaveAs.Location = new System.Drawing.Point(162, 77);
            this.btSaveAs.Name = "btSaveAs";
            this.btSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btSaveAs.TabIndex = 28;
            this.btSaveAs.Text = "Save as...";
            this.btSaveAs.UseVisualStyleBackColor = true;
            this.btSaveAs.Click += new System.EventHandler(this.btSaveAs_Click);
            // 
            // btLoad
            // 
            this.btLoad.Location = new System.Drawing.Point(162, 19);
            this.btLoad.Name = "btLoad";
            this.btLoad.Size = new System.Drawing.Size(75, 23);
            this.btLoad.TabIndex = 27;
            this.btLoad.Text = "Load...";
            this.btLoad.UseVisualStyleBackColor = true;
            this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
            // 
            // pbCover
            // 
            this.pbCover.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCover.Location = new System.Drawing.Point(6, 19);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(150, 150);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCover.TabIndex = 26;
            this.pbCover.TabStop = false;
            this.pbCover.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbCover_DragDrop);
            this.pbCover.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbCover_DragEnter);
            // 
            // ofdGeneLoadImage
            // 
            this.ofdGeneLoadImage.DefaultExt = "png";
            this.ofdGeneLoadImage.FileName = "Game.png";
            this.ofdGeneLoadImage.Filter = "image files|*.png;*.jpg;*.jpeg;*.bmp";
            this.ofdGeneLoadImage.RestoreDirectory = true;
            this.ofdGeneLoadImage.ShowHelp = true;
            this.ofdGeneLoadImage.Title = "Load file";
            // 
            // sfdGeneSaveImage
            // 
            this.sfdGeneSaveImage.DefaultExt = "png";
            this.sfdGeneSaveImage.FileName = "Game.png";
            this.sfdGeneSaveImage.Filter = "png files|*.png";
            this.sfdGeneSaveImage.RestoreDirectory = true;
            this.sfdGeneSaveImage.ShowHelp = true;
            this.sfdGeneSaveImage.Title = "Save file";
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(173, 232);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 28;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // btCompress
            // 
            this.btCompress.Location = new System.Drawing.Point(3, 203);
            this.btCompress.Name = "btCompress";
            this.btCompress.Size = new System.Drawing.Size(245, 23);
            this.btCompress.TabIndex = 29;
            this.btCompress.Text = "Compress PNG in all folders";
            this.btCompress.UseVisualStyleBackColor = true;
            this.btCompress.Click += new System.EventHandler(this.btCompress_Click);
            // 
            // btSave
            // 
            this.btSave.Enabled = false;
            this.btSave.Location = new System.Drawing.Point(162, 48);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 29;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lbCurrentPngFile
            // 
            this.lbCurrentPngFile.AutoSize = true;
            this.lbCurrentPngFile.Location = new System.Drawing.Point(6, 179);
            this.lbCurrentPngFile.Name = "lbCurrentPngFile";
            this.lbCurrentPngFile.Size = new System.Drawing.Size(16, 13);
            this.lbCurrentPngFile.TabIndex = 36;
            this.lbCurrentPngFile.Text = "---";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 267);
            this.Controls.Add(this.btCompress);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.Text = "Image Helper";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCover;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btSaveAs;
        private System.Windows.Forms.Button btLoad;
        private System.Windows.Forms.OpenFileDialog ofdGeneLoadImage;
        private System.Windows.Forms.SaveFileDialog sfdGeneSaveImage;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btCompress;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Label lbCurrentPngFile;
    }
}