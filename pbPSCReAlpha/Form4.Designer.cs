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
            this.btBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scCueSplitter)).BeginInit();
            this.scCueSplitter.Panel1.SuspendLayout();
            this.scCueSplitter.Panel2.SuspendLayout();
            this.scCueSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpCueFiles
            // 
            this.flpCueFiles.AutoScroll = true;
            this.flpCueFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpCueFiles.Location = new System.Drawing.Point(0, 0);
            this.flpCueFiles.Name = "flpCueFiles";
            this.flpCueFiles.Size = new System.Drawing.Size(409, 521);
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
            this.scCueSplitter.Panel1.Controls.Add(this.flpCueFiles);
            // 
            // scCueSplitter.Panel2
            // 
            this.scCueSplitter.Panel2.Controls.Add(this.btBack);
            this.scCueSplitter.Size = new System.Drawing.Size(409, 561);
            this.scCueSplitter.SplitterDistance = 521;
            this.scCueSplitter.TabIndex = 1;
            // 
            // btBack
            // 
            this.btBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btBack.Location = new System.Drawing.Point(331, 10);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 0;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 561);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpCueFiles;
        private System.Windows.Forms.SplitContainer scCueSplitter;
        private System.Windows.Forms.Button btBack;
    }
}