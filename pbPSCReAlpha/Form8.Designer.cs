using System.Windows.Forms;

namespace pbPSCReAlpha
{
    partial class Form8
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form8));
            this.ofdLoadMem = new System.Windows.Forms.OpenFileDialog();
            this.btBack = new System.Windows.Forms.Button();
            this.tbMcdFile = new System.Windows.Forms.TextBox();
            this.btBrowseMcd = new System.Windows.Forms.Button();
            this.lvCardListLeft = new System.Windows.Forms.ListView();
            this.columnHeaderLeft1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLeft2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLeft3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconListLeft = new System.Windows.Forms.ImageList(this.components);
            this.lvCardListRight = new System.Windows.Forms.ListView();
            this.columnHeaderRight1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRight2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRight3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iconListRight = new System.Windows.Forms.ImageList(this.components);
            this.cbMemcards = new System.Windows.Forms.ComboBox();
            this.btSaveasLeft = new System.Windows.Forms.Button();
            this.btSaveLeft = new System.Windows.Forms.Button();
            this.gbLeft = new System.Windows.Forms.GroupBox();
            this.lbLeftMemCardFile = new System.Windows.Forms.Label();
            this.gbRight = new System.Windows.Forms.GroupBox();
            this.lbRightMemCardFile = new System.Windows.Forms.Label();
            this.btSaveasRight = new System.Windows.Forms.Button();
            this.btSaveRight = new System.Windows.Forms.Button();
            this.sfdSaveMem = new System.Windows.Forms.SaveFileDialog();
            this.lklbMemCardRex = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSelectCombobox = new System.Windows.Forms.RadioButton();
            this.rbSelectFile = new System.Windows.Forms.RadioButton();
            this.btOpenFileRight = new System.Windows.Forms.Button();
            this.btOpenFileLeft = new System.Windows.Forms.Button();
            this.btRightToLeft = new System.Windows.Forms.Button();
            this.btLeftToRight = new System.Windows.Forms.Button();
            this.gbLeft.SuspendLayout();
            this.gbRight.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdLoadMem
            // 
            this.ofdLoadMem.DefaultExt = "mcd";
            this.ofdLoadMem.FileName = "card1.mcd";
            this.ofdLoadMem.Filter = "mcd files|*.mcd";
            this.ofdLoadMem.ShowHelp = true;
            // 
            // btBack
            // 
            this.btBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btBack.Location = new System.Drawing.Point(986, 439);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 5;
            this.btBack.Text = "Back";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.btBack_Click);
            // 
            // tbMcdFile
            // 
            this.tbMcdFile.AllowDrop = true;
            this.tbMcdFile.Location = new System.Drawing.Point(29, 14);
            this.tbMcdFile.Name = "tbMcdFile";
            this.tbMcdFile.Size = new System.Drawing.Size(279, 20);
            this.tbMcdFile.TabIndex = 7;
            this.tbMcdFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbMcdFile_DragDrop);
            this.tbMcdFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbMcdFile_DragEnter);
            this.tbMcdFile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMcdFile_KeyDown);
            // 
            // btBrowseMcd
            // 
            this.btBrowseMcd.Location = new System.Drawing.Point(314, 12);
            this.btBrowseMcd.Name = "btBrowseMcd";
            this.btBrowseMcd.Size = new System.Drawing.Size(75, 23);
            this.btBrowseMcd.TabIndex = 6;
            this.btBrowseMcd.Text = "Browse...";
            this.btBrowseMcd.UseVisualStyleBackColor = true;
            this.btBrowseMcd.Click += new System.EventHandler(this.btBrowseMcd_Click);
            // 
            // lvCardListLeft
            // 
            this.lvCardListLeft.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLeft1,
            this.columnHeaderLeft2,
            this.columnHeaderLeft3});
            this.lvCardListLeft.FullRowSelect = true;
            this.lvCardListLeft.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCardListLeft.HideSelection = false;
            this.lvCardListLeft.Location = new System.Drawing.Point(3, 19);
            this.lvCardListLeft.MultiSelect = false;
            this.lvCardListLeft.Name = "lvCardListLeft";
            this.lvCardListLeft.Size = new System.Drawing.Size(492, 286);
            this.lvCardListLeft.SmallImageList = this.iconListLeft;
            this.lvCardListLeft.TabIndex = 10;
            this.lvCardListLeft.UseCompatibleStateImageBehavior = false;
            this.lvCardListLeft.View = System.Windows.Forms.View.Details;
            this.lvCardListLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvCardListLeft_KeyDown);
            // 
            // columnHeaderLeft1
            // 
            this.columnHeaderLeft1.Text = "Icon, region and title";
            this.columnHeaderLeft1.Width = 315;
            // 
            // columnHeaderLeft2
            // 
            this.columnHeaderLeft2.Text = "Product code";
            this.columnHeaderLeft2.Width = 87;
            // 
            // columnHeaderLeft3
            // 
            this.columnHeaderLeft3.Text = "Identifier";
            this.columnHeaderLeft3.Width = 84;
            // 
            // iconListLeft
            // 
            this.iconListLeft.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconListLeft.ImageSize = new System.Drawing.Size(48, 16);
            this.iconListLeft.TransparentColor = System.Drawing.Color.Magenta;
            // 
            // lvCardListRight
            // 
            this.lvCardListRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderRight1,
            this.columnHeaderRight2,
            this.columnHeaderRight3});
            this.lvCardListRight.FullRowSelect = true;
            this.lvCardListRight.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvCardListRight.HideSelection = false;
            this.lvCardListRight.Location = new System.Drawing.Point(6, 15);
            this.lvCardListRight.MultiSelect = false;
            this.lvCardListRight.Name = "lvCardListRight";
            this.lvCardListRight.Size = new System.Drawing.Size(492, 286);
            this.lvCardListRight.SmallImageList = this.iconListRight;
            this.lvCardListRight.TabIndex = 11;
            this.lvCardListRight.UseCompatibleStateImageBehavior = false;
            this.lvCardListRight.View = System.Windows.Forms.View.Details;
            this.lvCardListRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvCardListRight_KeyDown);
            // 
            // columnHeaderRight1
            // 
            this.columnHeaderRight1.Text = "Icon, region and title";
            this.columnHeaderRight1.Width = 315;
            // 
            // columnHeaderRight2
            // 
            this.columnHeaderRight2.Text = "Product code";
            this.columnHeaderRight2.Width = 87;
            // 
            // columnHeaderRight3
            // 
            this.columnHeaderRight3.Text = "Identifier";
            this.columnHeaderRight3.Width = 84;
            // 
            // iconListRight
            // 
            this.iconListRight.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.iconListRight.ImageSize = new System.Drawing.Size(48, 16);
            this.iconListRight.TransparentColor = System.Drawing.Color.Magenta;
            // 
            // cbMemcards
            // 
            this.cbMemcards.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMemcards.FormattingEnabled = true;
            this.cbMemcards.Location = new System.Drawing.Point(29, 40);
            this.cbMemcards.Name = "cbMemcards";
            this.cbMemcards.Size = new System.Drawing.Size(360, 21);
            this.cbMemcards.TabIndex = 12;
            // 
            // btSaveasLeft
            // 
            this.btSaveasLeft.Location = new System.Drawing.Point(3, 327);
            this.btSaveasLeft.Name = "btSaveasLeft";
            this.btSaveasLeft.Size = new System.Drawing.Size(75, 23);
            this.btSaveasLeft.TabIndex = 18;
            this.btSaveasLeft.Text = "Save as...";
            this.btSaveasLeft.UseVisualStyleBackColor = true;
            this.btSaveasLeft.Click += new System.EventHandler(this.btSaveasLeft_Click);
            // 
            // btSaveLeft
            // 
            this.btSaveLeft.Location = new System.Drawing.Point(84, 327);
            this.btSaveLeft.Name = "btSaveLeft";
            this.btSaveLeft.Size = new System.Drawing.Size(75, 23);
            this.btSaveLeft.TabIndex = 19;
            this.btSaveLeft.Text = "Save";
            this.btSaveLeft.UseVisualStyleBackColor = true;
            this.btSaveLeft.Click += new System.EventHandler(this.btSaveLeft_Click);
            // 
            // gbLeft
            // 
            this.gbLeft.Controls.Add(this.lbLeftMemCardFile);
            this.gbLeft.Controls.Add(this.btSaveasLeft);
            this.gbLeft.Controls.Add(this.lvCardListLeft);
            this.gbLeft.Controls.Add(this.btSaveLeft);
            this.gbLeft.Location = new System.Drawing.Point(3, 78);
            this.gbLeft.Name = "gbLeft";
            this.gbLeft.Size = new System.Drawing.Size(501, 355);
            this.gbLeft.TabIndex = 20;
            this.gbLeft.TabStop = false;
            this.gbLeft.Text = "Left Memcard";
            // 
            // lbLeftMemCardFile
            // 
            this.lbLeftMemCardFile.AutoSize = true;
            this.lbLeftMemCardFile.Location = new System.Drawing.Point(6, 311);
            this.lbLeftMemCardFile.Name = "lbLeftMemCardFile";
            this.lbLeftMemCardFile.Size = new System.Drawing.Size(10, 13);
            this.lbLeftMemCardFile.TabIndex = 20;
            this.lbLeftMemCardFile.Text = "-";
            // 
            // gbRight
            // 
            this.gbRight.Controls.Add(this.lbRightMemCardFile);
            this.gbRight.Controls.Add(this.btSaveasRight);
            this.gbRight.Controls.Add(this.btSaveRight);
            this.gbRight.Controls.Add(this.lvCardListRight);
            this.gbRight.Location = new System.Drawing.Point(560, 78);
            this.gbRight.Name = "gbRight";
            this.gbRight.Size = new System.Drawing.Size(501, 355);
            this.gbRight.TabIndex = 21;
            this.gbRight.TabStop = false;
            this.gbRight.Text = "Right Memcard";
            // 
            // lbRightMemCardFile
            // 
            this.lbRightMemCardFile.AutoSize = true;
            this.lbRightMemCardFile.Location = new System.Drawing.Point(6, 311);
            this.lbRightMemCardFile.Name = "lbRightMemCardFile";
            this.lbRightMemCardFile.Size = new System.Drawing.Size(10, 13);
            this.lbRightMemCardFile.TabIndex = 20;
            this.lbRightMemCardFile.Text = "-";
            // 
            // btSaveasRight
            // 
            this.btSaveasRight.Location = new System.Drawing.Point(3, 327);
            this.btSaveasRight.Name = "btSaveasRight";
            this.btSaveasRight.Size = new System.Drawing.Size(75, 23);
            this.btSaveasRight.TabIndex = 18;
            this.btSaveasRight.Text = "Save as...";
            this.btSaveasRight.UseVisualStyleBackColor = true;
            this.btSaveasRight.Click += new System.EventHandler(this.btSaveasRight_Click);
            // 
            // btSaveRight
            // 
            this.btSaveRight.Location = new System.Drawing.Point(84, 327);
            this.btSaveRight.Name = "btSaveRight";
            this.btSaveRight.Size = new System.Drawing.Size(75, 23);
            this.btSaveRight.TabIndex = 19;
            this.btSaveRight.Text = "Save";
            this.btSaveRight.UseVisualStyleBackColor = true;
            this.btSaveRight.Click += new System.EventHandler(this.btSaveRight_Click);
            // 
            // sfdSaveMem
            // 
            this.sfdSaveMem.DefaultExt = "mcd";
            this.sfdSaveMem.FileName = "card1.mcd";
            this.sfdSaveMem.Filter = "mcd files|*.mcd";
            this.sfdSaveMem.ShowHelp = true;
            // 
            // lklbMemCardRex
            // 
            this.lklbMemCardRex.AutoSize = true;
            this.lklbMemCardRex.Location = new System.Drawing.Point(68, 444);
            this.lklbMemCardRex.Name = "lklbMemCardRex";
            this.lklbMemCardRex.Size = new System.Drawing.Size(71, 13);
            this.lklbMemCardRex.TabIndex = 22;
            this.lklbMemCardRex.TabStop = true;
            this.lklbMemCardRex.Text = "MemCardRex";
            this.lklbMemCardRex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklbMemCardRex_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "For more, try ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btOpenFileRight);
            this.groupBox1.Controls.Add(this.btOpenFileLeft);
            this.groupBox1.Controls.Add(this.rbSelectCombobox);
            this.groupBox1.Controls.Add(this.rbSelectFile);
            this.groupBox1.Controls.Add(this.tbMcdFile);
            this.groupBox1.Controls.Add(this.cbMemcards);
            this.groupBox1.Controls.Add(this.btBrowseMcd);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1058, 69);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load File";
            // 
            // rbSelectCombobox
            // 
            this.rbSelectCombobox.AutoSize = true;
            this.rbSelectCombobox.Location = new System.Drawing.Point(9, 43);
            this.rbSelectCombobox.Name = "rbSelectCombobox";
            this.rbSelectCombobox.Size = new System.Drawing.Size(14, 13);
            this.rbSelectCombobox.TabIndex = 1;
            this.rbSelectCombobox.TabStop = true;
            this.rbSelectCombobox.UseVisualStyleBackColor = true;
            this.rbSelectCombobox.CheckedChanged += new System.EventHandler(this.rbManager_CheckedChanged);
            // 
            // rbSelectFile
            // 
            this.rbSelectFile.AutoSize = true;
            this.rbSelectFile.Location = new System.Drawing.Point(9, 17);
            this.rbSelectFile.Name = "rbSelectFile";
            this.rbSelectFile.Size = new System.Drawing.Size(14, 13);
            this.rbSelectFile.TabIndex = 0;
            this.rbSelectFile.TabStop = true;
            this.rbSelectFile.UseVisualStyleBackColor = true;
            this.rbSelectFile.CheckedChanged += new System.EventHandler(this.rbManager_CheckedChanged);
            // 
            // btOpenFileRight
            // 
            this.btOpenFileRight.Image = global::pbPSCReAlpha.Properties.Resources.draw_arrow_forward;
            this.btOpenFileRight.Location = new System.Drawing.Point(557, 11);
            this.btOpenFileRight.Name = "btOpenFileRight";
            this.btOpenFileRight.Size = new System.Drawing.Size(75, 49);
            this.btOpenFileRight.TabIndex = 17;
            this.btOpenFileRight.Text = "Open";
            this.btOpenFileRight.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btOpenFileRight.UseVisualStyleBackColor = true;
            this.btOpenFileRight.Click += new System.EventHandler(this.btOpenFileRight_Click);
            // 
            // btOpenFileLeft
            // 
            this.btOpenFileLeft.Image = global::pbPSCReAlpha.Properties.Resources.draw_arrow_back;
            this.btOpenFileLeft.Location = new System.Drawing.Point(426, 11);
            this.btOpenFileLeft.Name = "btOpenFileLeft";
            this.btOpenFileLeft.Size = new System.Drawing.Size(75, 49);
            this.btOpenFileLeft.TabIndex = 16;
            this.btOpenFileLeft.Text = "Open";
            this.btOpenFileLeft.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btOpenFileLeft.UseVisualStyleBackColor = true;
            this.btOpenFileLeft.Click += new System.EventHandler(this.btOpenFileLeft_Click);
            // 
            // btRightToLeft
            // 
            this.btRightToLeft.Image = global::pbPSCReAlpha.Properties.Resources.arrow_left_4;
            this.btRightToLeft.Location = new System.Drawing.Point(510, 246);
            this.btRightToLeft.Name = "btRightToLeft";
            this.btRightToLeft.Size = new System.Drawing.Size(44, 78);
            this.btRightToLeft.TabIndex = 17;
            this.btRightToLeft.UseVisualStyleBackColor = true;
            this.btRightToLeft.Click += new System.EventHandler(this.btRightToLeft_Click);
            // 
            // btLeftToRight
            // 
            this.btLeftToRight.Image = global::pbPSCReAlpha.Properties.Resources.arrow_right_4;
            this.btLeftToRight.Location = new System.Drawing.Point(510, 102);
            this.btLeftToRight.Name = "btLeftToRight";
            this.btLeftToRight.Size = new System.Drawing.Size(44, 78);
            this.btLeftToRight.TabIndex = 16;
            this.btLeftToRight.UseVisualStyleBackColor = true;
            this.btLeftToRight.Click += new System.EventHandler(this.btLeftToRight_Click);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btBack;
            this.ClientSize = new System.Drawing.Size(1064, 462);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lklbMemCardRex);
            this.Controls.Add(this.gbRight);
            this.Controls.Add(this.gbLeft);
            this.Controls.Add(this.btRightToLeft);
            this.Controls.Add(this.btLeftToRight);
            this.Controls.Add(this.btBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form8";
            this.Text = "MemCard Manager";
            this.gbLeft.ResumeLayout(false);
            this.gbLeft.PerformLayout();
            this.gbRight.ResumeLayout(false);
            this.gbRight.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdLoadMem;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.TextBox tbMcdFile;
        private System.Windows.Forms.Button btBrowseMcd;
        private System.Windows.Forms.ListView lvCardListLeft;
        private System.Windows.Forms.ColumnHeader columnHeaderLeft1;
        private System.Windows.Forms.ColumnHeader columnHeaderLeft2;
        private System.Windows.Forms.ColumnHeader columnHeaderLeft3;
        private ImageList iconListLeft;
        private ListView lvCardListRight;
        private ColumnHeader columnHeaderRight1;
        private ColumnHeader columnHeaderRight2;
        private ColumnHeader columnHeaderRight3;
        private ImageList iconListRight;
        private ComboBox cbMemcards;
        private Button btLeftToRight;
        private Button btRightToLeft;
        private Button btSaveasLeft;
        private Button btSaveLeft;
        private GroupBox gbLeft;
        private Label lbLeftMemCardFile;
        private GroupBox gbRight;
        private Label lbRightMemCardFile;
        private Button btSaveasRight;
        private Button btSaveRight;
        private SaveFileDialog sfdSaveMem;
        private LinkLabel lklbMemCardRex;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton rbSelectCombobox;
        private RadioButton rbSelectFile;
        private Button btOpenFileLeft;
        private Button btOpenFileRight;
    }
}