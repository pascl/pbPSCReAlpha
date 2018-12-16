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
            this.SuspendLayout();
            // 
            // tbFolderPath
            // 
            this.tbFolderPath.Location = new System.Drawing.Point(12, 12);
            this.tbFolderPath.Name = "tbFolderPath";
            this.tbFolderPath.Size = new System.Drawing.Size(160, 20);
            this.tbFolderPath.TabIndex = 0;
            this.tbFolderPath.Text = "F:\\Games";
            // 
            // btCrowseGamesFolder
            // 
            this.btCrowseGamesFolder.Location = new System.Drawing.Point(178, 10);
            this.btCrowseGamesFolder.Name = "btCrowseGamesFolder";
            this.btCrowseGamesFolder.Size = new System.Drawing.Size(75, 23);
            this.btCrowseGamesFolder.TabIndex = 1;
            this.btCrowseGamesFolder.Text = "Browse...";
            this.btCrowseGamesFolder.UseVisualStyleBackColor = true;
            this.btCrowseGamesFolder.Click += new System.EventHandler(this.btCrowseGamesFolder_Click);
            // 
            // btGo
            // 
            this.btGo.Location = new System.Drawing.Point(178, 74);
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
            this.cbStartAt21.Checked = true;
            this.cbStartAt21.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStartAt21.Location = new System.Drawing.Point(12, 38);
            this.cbStartAt21.Name = "cbStartAt21";
            this.cbStartAt21.Size = new System.Drawing.Size(241, 17);
            this.cbStartAt21.TabIndex = 3;
            this.cbStartAt21.Text = "Check to begin alphabetic order at 21st game";
            this.cbStartAt21.UseVisualStyleBackColor = true;
            // 
            // tbLog
            // 
            this.tbLog.Location = new System.Drawing.Point(12, 103);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(241, 185);
            this.tbLog.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 300);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.cbStartAt21);
            this.Controls.Add(this.btGo);
            this.Controls.Add(this.btCrowseGamesFolder);
            this.Controls.Add(this.tbFolderPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog fbdGamesFolder;
        private System.Windows.Forms.TextBox tbFolderPath;
        private System.Windows.Forms.Button btCrowseGamesFolder;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.CheckBox cbStartAt21;
        private System.Windows.Forms.TextBox tbLog;
    }
}

