namespace pbPSCReAlpha
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.flpCueFiles = new System.Windows.Forms.FlowLayoutPanel();
            this.scCueSplitter = new System.Windows.Forms.SplitContainer();
            this.scBinCueFiles = new System.Windows.Forms.SplitContainer();
            this.scBinFiles = new System.Windows.Forms.SplitContainer();
            this.lbBinFiles = new System.Windows.Forms.ListBox();
            this.btClipboardCopy = new System.Windows.Forms.Button();
            this.btBack = new System.Windows.Forms.Button();
            this.scBinCueFiles = new System.Windows.Forms.SplitContainer();
            this.lbBinFiles = new System.Windows.Forms.ListBox();
            this.scBinFiles = new System.Windows.Forms.SplitContainer();
            this.btClipboardCopy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scCueSplitter)).BeginInit();
            this.scCueSplitter.Panel1.SuspendLayout();
            this.scCueSplitter.Panel2.SuspendLayout();
            this.scCueSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBinCueFiles)).BeginInit();
            this.scBinCueFiles.Panel1.SuspendLayout();
            this.scBinCueFiles.Panel2.SuspendLayout();
            this.scBinCueFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBinFiles)).BeginInit();
            this.scBinFiles.Panel1.SuspendLayout();
            this.scBinFiles.Panel2.SuspendLayout();
            this.scBinFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpCueFiles
            // 
            this.flpCueFiles.AutoScroll = true;
            this.flpCueFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCueFiles.Location = new System.Drawing.Point(0, 0);
            this.flpCueFiles.Name = "flpCueFiles";
            this.flpCueFiles.Size = new System.Drawing.Size(420, 514);
            this.flpCueFiles.TabIndex = 0;
            // 
            // scCueSplitter
            // 
            this.scCueSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scCueSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scCueSplitter.IsSplitterFixed = true;
            this.scCueSplitter.Location = new System.Drawing.Point(0, 0);
            this.scCueSplitter.Name = "scCueSplitter";
            this.scCueSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scCueSplitter.Panel1
            // 
            this.scCueSplitter.Panel1.Controls.Add(this.scBinCueFiles);
            // 
            // scCueSplitter.Panel2
            // 
            this.scCueSplitter.Panel2.Controls.Add(this.btBack);
            this.scCueSplitter.Size = new System.Drawing.Size(584, 547);
            this.scCueSplitter.SplitterDistance = 514;
            this.scCueSplitter.TabIndex = 1;
            // 
            // scBinCueFiles
            // 
            this.scBinCueFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scBinCueFiles.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scBinCueFiles.IsSplitterFixed = true;
            this.scBinCueFiles.Location = new System.Drawing.Point(0, 0);
            this.scBinCueFiles.Name = "scBinCueFiles";
            // 
            // scBinCueFiles.Panel1
            // 
            this.scBinCueFiles.Panel1.Controls.Add(this.scBinFiles);
            // 
            // scBinCueFiles.Panel2
            // 
            this.scBinCueFiles.Panel2.Controls.Add(this.flpCueFiles);
            this.scBinCueFiles.Size = new System.Drawing.Size(584, 514);
            this.scBinCueFiles.SplitterDistance = 160;
            this.scBinCueFiles.TabIndex = 1;
            // 
            // scBinFiles
            // 
            this.scBinFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scBinFiles.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scBinFiles.IsSplitterFixed = true;
            this.scBinFiles.Location = new System.Drawing.Point(0, 0);
            this.scBinFiles.Name = "scBinFiles";
            this.scBinFiles.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scBinFiles.Panel1
            // 
            this.scBinFiles.Panel1.Controls.Add(this.lbBinFiles);
            // 
            // scBinFiles.Panel2
            // 
            this.scBinFiles.Panel2.Controls.Add(this.btClipboardCopy);
            this.scBinFiles.Size = new System.Drawing.Size(160, 514);
            this.scBinFiles.SplitterDistance = 481;
            this.scBinFiles.TabIndex = 1;
            // 
            // lbBinFiles
            // 
            this.lbBinFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBinFiles.FormattingEnabled = true;
            this.lbBinFiles.Location = new System.Drawing.Point(0, 0);
            this.lbBinFiles.Name = "lbBinFiles";
            this.lbBinFiles.ScrollAlwaysVisible = true;
            this.lbBinFiles.Size = new System.Drawing.Size(160, 481);
            this.lbBinFiles.TabIndex = 0;
            this.lbBinFiles.DoubleClick += new System.EventHandler(this.lbBinFiles_DoubleClick);
            // 
            // btClipboardCopy
            // 
            this.btClipboardCopy.Image = global::pbPSCReAlpha.Properties.Resources.file_clipboard;
            this.btClipboardCopy.Location = new System.Drawing.Point(3, 3);
            this.btClipboardCopy.Name = "btClipboardCopy";
            this.btClipboardCopy.Size = new System.Drawing.Size(154, 23);
            this.btClipboardCopy.TabIndex = 0;
            this.btClipboardCopy.Text = "Copy bin filename";
            this.btClipboardCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btClipboardCopy.UseVisualStyleBackColor = true;
            this.btClipboardCopy.Click += new System.EventHandler(this.btClipboardCopy_Click);
            // 
            // btBack
            // 
            this.btBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btBack.Location = new System.Drawing.Point(506, 3);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 0;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // scBinCueFiles
            // 
            this.scBinCueFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scBinCueFiles.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scBinCueFiles.IsSplitterFixed = true;
            this.scBinCueFiles.Location = new System.Drawing.Point(0, 0);
            this.scBinCueFiles.Name = "scBinCueFiles";
            // 
            // scBinCueFiles.Panel1
            // 
            this.scBinCueFiles.Panel1.Controls.Add(this.scBinFiles);
            // 
            // scBinCueFiles.Panel2
            // 
            this.scBinCueFiles.Panel2.Controls.Add(this.flpCueFiles);
            this.scBinCueFiles.Size = new System.Drawing.Size(584, 514);
            this.scBinCueFiles.SplitterDistance = 160;
            this.scBinCueFiles.TabIndex = 1;
            // 
            // lbBinFiles
            // 
            this.lbBinFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbBinFiles.FormattingEnabled = true;
            this.lbBinFiles.Location = new System.Drawing.Point(0, 0);
            this.lbBinFiles.Name = "lbBinFiles";
            this.lbBinFiles.ScrollAlwaysVisible = true;
            this.lbBinFiles.Size = new System.Drawing.Size(160, 481);
            this.lbBinFiles.TabIndex = 0;
            // 
            // scBinFiles
            // 
            this.scBinFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scBinFiles.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scBinFiles.IsSplitterFixed = true;
            this.scBinFiles.Location = new System.Drawing.Point(0, 0);
            this.scBinFiles.Name = "scBinFiles";
            this.scBinFiles.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scBinFiles.Panel1
            // 
            this.scBinFiles.Panel1.Controls.Add(this.lbBinFiles);
            // 
            // scBinFiles.Panel2
            // 
            this.scBinFiles.Panel2.Controls.Add(this.btClipboardCopy);
            this.scBinFiles.Size = new System.Drawing.Size(160, 514);
            this.scBinFiles.SplitterDistance = 481;
            this.scBinFiles.TabIndex = 1;
            // 
            // btClipboardCopy
            // 
            this.btClipboardCopy.Image = global::pbPSCReAlpha.Properties.Resources.file_clipboard;
            this.btClipboardCopy.Location = new System.Drawing.Point(3, 3);
            this.btClipboardCopy.Name = "btClipboardCopy";
            this.btClipboardCopy.Size = new System.Drawing.Size(154, 23);
            this.btClipboardCopy.TabIndex = 0;
            this.btClipboardCopy.Text = "Copy bin filename";
            this.btClipboardCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btClipboardCopy.UseVisualStyleBackColor = true;
            this.btClipboardCopy.Click += new System.EventHandler(this.btClipboardCopy_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 547);
            this.Controls.Add(this.scCueSplitter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form4";
            this.Text = "cue file(s) Helper";
            this.scCueSplitter.Panel1.ResumeLayout(false);
            this.scCueSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scCueSplitter)).EndInit();
            this.scCueSplitter.ResumeLayout(false);
            this.scBinCueFiles.Panel1.ResumeLayout(false);
            this.scBinCueFiles.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBinCueFiles)).EndInit();
            this.scBinCueFiles.ResumeLayout(false);
            this.scBinFiles.Panel1.ResumeLayout(false);
            this.scBinFiles.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBinFiles)).EndInit();
            this.scBinFiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCueFiles;
        private System.Windows.Forms.SplitContainer scCueSplitter;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.SplitContainer scBinCueFiles;
        private System.Windows.Forms.ListBox lbBinFiles;
        private System.Windows.Forms.SplitContainer scBinFiles;
        private System.Windows.Forms.Button btClipboardCopy;
    }
}