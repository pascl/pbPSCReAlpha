namespace pbPSCReAlpha
{
    partial class Form11
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form11));
            this.btBack = new System.Windows.Forms.Button();
            this.scMainSplit = new System.Windows.Forms.SplitContainer();
            this.scSplitterVertical = new System.Windows.Forms.SplitContainer();
            this.tbLaunchContent = new System.Windows.Forms.TextBox();
            this.btSave = new System.Windows.Forms.Button();
            this.scBinFiles = new System.Windows.Forms.SplitContainer();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.btClipboardCopy = new System.Windows.Forms.Button();
            this.btReload = new System.Windows.Forms.Button();
            this.btTemplate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scMainSplit)).BeginInit();
            this.scMainSplit.Panel1.SuspendLayout();
            this.scMainSplit.Panel2.SuspendLayout();
            this.scMainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSplitterVertical)).BeginInit();
            this.scSplitterVertical.Panel1.SuspendLayout();
            this.scSplitterVertical.Panel2.SuspendLayout();
            this.scSplitterVertical.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBinFiles)).BeginInit();
            this.scBinFiles.Panel1.SuspendLayout();
            this.scBinFiles.Panel2.SuspendLayout();
            this.scBinFiles.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBack
            // 
            this.btBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btBack.Location = new System.Drawing.Point(722, 3);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 3;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // scMainSplit
            // 
            this.scMainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMainSplit.Location = new System.Drawing.Point(0, 0);
            this.scMainSplit.Name = "scMainSplit";
            this.scMainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMainSplit.Panel1
            // 
            this.scMainSplit.Panel1.Controls.Add(this.scSplitterVertical);
            // 
            // scMainSplit.Panel2
            // 
            this.scMainSplit.Panel2.Controls.Add(this.btBack);
            this.scMainSplit.Panel2MinSize = 20;
            this.scMainSplit.Size = new System.Drawing.Size(800, 450);
            this.scMainSplit.SplitterDistance = 416;
            this.scMainSplit.TabIndex = 4;
            // 
            // scSplitterVertical
            // 
            this.scSplitterVertical.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSplitterVertical.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scSplitterVertical.Location = new System.Drawing.Point(0, 0);
            this.scSplitterVertical.Name = "scSplitterVertical";
            // 
            // scSplitterVertical.Panel1
            // 
            this.scSplitterVertical.Panel1.Controls.Add(this.scBinFiles);
            this.scSplitterVertical.Panel1MinSize = 100;
            // 
            // scSplitterVertical.Panel2
            // 
            this.scSplitterVertical.Panel2.Controls.Add(this.btTemplate);
            this.scSplitterVertical.Panel2.Controls.Add(this.btReload);
            this.scSplitterVertical.Panel2.Controls.Add(this.btSave);
            this.scSplitterVertical.Panel2.Controls.Add(this.tbLaunchContent);
            this.scSplitterVertical.Size = new System.Drawing.Size(800, 416);
            this.scSplitterVertical.SplitterDistance = 159;
            this.scSplitterVertical.TabIndex = 0;
            // 
            // tbLaunchContent
            // 
            this.tbLaunchContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbLaunchContent.Location = new System.Drawing.Point(0, 0);
            this.tbLaunchContent.Multiline = true;
            this.tbLaunchContent.Name = "tbLaunchContent";
            this.tbLaunchContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLaunchContent.Size = new System.Drawing.Size(637, 384);
            this.tbLaunchContent.TabIndex = 0;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(3, 390);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 1;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
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
            this.scBinFiles.Panel1.Controls.Add(this.lbFiles);
            // 
            // scBinFiles.Panel2
            // 
            this.scBinFiles.Panel2.Controls.Add(this.btClipboardCopy);
            this.scBinFiles.Size = new System.Drawing.Size(159, 416);
            this.scBinFiles.SplitterDistance = 383;
            this.scBinFiles.TabIndex = 2;
            // 
            // lbFiles
            // 
            this.lbFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(0, 0);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.ScrollAlwaysVisible = true;
            this.lbFiles.Size = new System.Drawing.Size(159, 383);
            this.lbFiles.TabIndex = 0;
            this.lbFiles.DoubleClick += new System.EventHandler(this.lbFiles_DoubleClick);
            // 
            // btClipboardCopy
            // 
            this.btClipboardCopy.Image = global::pbPSCReAlpha.Properties.Resources.file_clipboard;
            this.btClipboardCopy.Location = new System.Drawing.Point(3, 3);
            this.btClipboardCopy.Name = "btClipboardCopy";
            this.btClipboardCopy.Size = new System.Drawing.Size(154, 23);
            this.btClipboardCopy.TabIndex = 0;
            this.btClipboardCopy.Text = "Copy filename";
            this.btClipboardCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btClipboardCopy.UseVisualStyleBackColor = true;
            this.btClipboardCopy.Click += new System.EventHandler(this.btClipboardCopy_Click);
            // 
            // btReload
            // 
            this.btReload.Location = new System.Drawing.Point(84, 390);
            this.btReload.Name = "btReload";
            this.btReload.Size = new System.Drawing.Size(75, 23);
            this.btReload.TabIndex = 2;
            this.btReload.Text = "Reload";
            this.btReload.UseVisualStyleBackColor = true;
            this.btReload.Click += new System.EventHandler(this.btReload_Click);
            // 
            // btTemplate
            // 
            this.btTemplate.Location = new System.Drawing.Point(165, 390);
            this.btTemplate.Name = "btTemplate";
            this.btTemplate.Size = new System.Drawing.Size(75, 23);
            this.btTemplate.TabIndex = 3;
            this.btTemplate.Text = "Template";
            this.btTemplate.UseVisualStyleBackColor = true;
            this.btTemplate.Click += new System.EventHandler(this.btTemplate_Click);
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btBack;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scMainSplit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form11";
            this.Text = "launch.sh Editor";
            this.scMainSplit.Panel1.ResumeLayout(false);
            this.scMainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMainSplit)).EndInit();
            this.scMainSplit.ResumeLayout(false);
            this.scSplitterVertical.Panel1.ResumeLayout(false);
            this.scSplitterVertical.Panel2.ResumeLayout(false);
            this.scSplitterVertical.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSplitterVertical)).EndInit();
            this.scSplitterVertical.ResumeLayout(false);
            this.scBinFiles.Panel1.ResumeLayout(false);
            this.scBinFiles.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBinFiles)).EndInit();
            this.scBinFiles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.SplitContainer scMainSplit;
        private System.Windows.Forms.SplitContainer scSplitterVertical;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.TextBox tbLaunchContent;
        private System.Windows.Forms.SplitContainer scBinFiles;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.Button btClipboardCopy;
        private System.Windows.Forms.Button btReload;
        private System.Windows.Forms.Button btTemplate;
    }
}