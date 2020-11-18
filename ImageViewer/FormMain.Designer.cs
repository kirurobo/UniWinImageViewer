namespace UniWinImageViewer
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.invisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowNoFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowFitsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowFitsHalfImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowFitsTwiceImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slideshowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prevImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.intervalTimeToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.intervalRandomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.disableJumpForAnimationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.resetWindowPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.timerMotion = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.contextMenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.Black;
            this.pictureBoxMain.BackgroundImage = global::UniWinImageViewer.Properties.Resources.BackGround;
            this.pictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMain.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(384, 361);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMain.TabIndex = 4;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMain_Paint);
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            // 
            // contextMenuStripMain
            // 
            this.contextMenuStripMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator3,
            this.invisibleToolStripMenuItem,
            this.topmostToolStripMenuItem,
            this.windowSizeToolStripMenuItem,
            this.slideshowToolStripMenuItem,
            this.motionToolStripMenuItem,
            this.toolStripSeparator2,
            this.helpToolStripMenuItem,
            this.toolStripSeparator5,
            this.exitToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(225, 220);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.openToolStripMenuItem.Text = "開く (&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // invisibleToolStripMenuItem
            // 
            this.invisibleToolStripMenuItem.Name = "invisibleToolStripMenuItem";
            this.invisibleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.invisibleToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.invisibleToolStripMenuItem.Text = "透明化 (&I)";
            this.invisibleToolStripMenuItem.Click += new System.EventHandler(this.checkBoxTransparent_CheckedChanged);
            // 
            // topmostToolStripMenuItem
            // 
            this.topmostToolStripMenuItem.Name = "topmostToolStripMenuItem";
            this.topmostToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.topmostToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.topmostToolStripMenuItem.Text = "常に最前面 (&T)";
            this.topmostToolStripMenuItem.Click += new System.EventHandler(this.checkBoxTopmost_CheckedChanged);
            // 
            // windowSizeToolStripMenuItem
            // 
            this.windowSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowNoFitToolStripMenuItem,
            this.windowFitsImageToolStripMenuItem,
            this.windowFitsHalfImageToolStripMenuItem,
            this.windowFitsTwiceImageToolStripMenuItem});
            this.windowSizeToolStripMenuItem.Name = "windowSizeToolStripMenuItem";
            this.windowSizeToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.windowSizeToolStripMenuItem.Text = "ウィンドウサイズ (&W)";
            // 
            // windowNoFitToolStripMenuItem
            // 
            this.windowNoFitToolStripMenuItem.Name = "windowNoFitToolStripMenuItem";
            this.windowNoFitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D9)));
            this.windowNoFitToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.windowNoFitToolStripMenuItem.Text = "画像へのフィットなし (&9)";
            this.windowNoFitToolStripMenuItem.Click += new System.EventHandler(this.windowNoFitToolStripMenuItem_Click);
            // 
            // windowFitsImageToolStripMenuItem
            // 
            this.windowFitsImageToolStripMenuItem.Name = "windowFitsImageToolStripMenuItem";
            this.windowFitsImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.windowFitsImageToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.windowFitsImageToolStripMenuItem.Text = "画像サイズにフィット (&0)";
            this.windowFitsImageToolStripMenuItem.Click += new System.EventHandler(this.windowFitsImageToolStripMenuItem_Click);
            // 
            // windowFitsHalfImageToolStripMenuItem
            // 
            this.windowFitsHalfImageToolStripMenuItem.Name = "windowFitsHalfImageToolStripMenuItem";
            this.windowFitsHalfImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.windowFitsHalfImageToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.windowFitsHalfImageToolStripMenuItem.Text = "画像の半分にフィット (&-)";
            this.windowFitsHalfImageToolStripMenuItem.Click += new System.EventHandler(this.windowFitsHalfImageToolStripMenuItem_Click);
            // 
            // windowFitsTwiceImageToolStripMenuItem
            // 
            this.windowFitsTwiceImageToolStripMenuItem.Name = "windowFitsTwiceImageToolStripMenuItem";
            this.windowFitsTwiceImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.windowFitsTwiceImageToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.windowFitsTwiceImageToolStripMenuItem.Text = "画像の倍にフィット (&+)";
            this.windowFitsTwiceImageToolStripMenuItem.Click += new System.EventHandler(this.windowFitsTwiceImageToolStripMenuItem_Click);
            // 
            // slideshowToolStripMenuItem
            // 
            this.slideshowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextImageToolStripMenuItem,
            this.prevImageToolStripMenuItem,
            this.toolStripSeparator1,
            this.intervalTimeToolStripComboBox,
            this.intervalRandomizeToolStripMenuItem});
            this.slideshowToolStripMenuItem.Name = "slideshowToolStripMenuItem";
            this.slideshowToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.slideshowToolStripMenuItem.Text = "スライドショー (&S)";
            // 
            // nextImageToolStripMenuItem
            // 
            this.nextImageToolStripMenuItem.Name = "nextImageToolStripMenuItem";
            this.nextImageToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.nextImageToolStripMenuItem.Text = "次の画像 (&N) ";
            this.nextImageToolStripMenuItem.Click += new System.EventHandler(this.nextImageToolStripMenuItem_Click);
            // 
            // prevImageToolStripMenuItem
            // 
            this.prevImageToolStripMenuItem.Name = "prevImageToolStripMenuItem";
            this.prevImageToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.prevImageToolStripMenuItem.Text = "前の画像 (&P) ";
            this.prevImageToolStripMenuItem.Click += new System.EventHandler(this.prevImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // intervalTimeToolStripComboBox
            // 
            this.intervalTimeToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.intervalTimeToolStripComboBox.DropDownWidth = 160;
            this.intervalTimeToolStripComboBox.Name = "intervalTimeToolStripComboBox";
            this.intervalTimeToolStripComboBox.Size = new System.Drawing.Size(160, 23);
            this.intervalTimeToolStripComboBox.ToolTipText = "スライドショーの切替時間";
            this.intervalTimeToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.intervalTimeTtoolStripComboBox_SelectedIndexChanged);
            // 
            // intervalRandomizeToolStripMenuItem
            // 
            this.intervalRandomizeToolStripMenuItem.Name = "intervalRandomizeToolStripMenuItem";
            this.intervalRandomizeToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.intervalRandomizeToolStripMenuItem.Text = "時間にランダム性 (&R)";
            this.intervalRandomizeToolStripMenuItem.ToolTipText = "指定時間内でランダム性を与えます";
            this.intervalRandomizeToolStripMenuItem.Click += new System.EventHandler(this.intervalRandomizeToolStripMenuItem_Click);
            // 
            // motionToolStripMenuItem
            // 
            this.motionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jumpToolStripComboBox,
            this.disableJumpForAnimationToolStripMenuItem,
            this.toolStripSeparator4,
            this.resetWindowPositionToolStripMenuItem});
            this.motionToolStripMenuItem.Name = "motionToolStripMenuItem";
            this.motionToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.motionToolStripMenuItem.Text = "動き (&M)";
            // 
            // jumpToolStripComboBox
            // 
            this.jumpToolStripComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jumpToolStripComboBox.Name = "jumpToolStripComboBox";
            this.jumpToolStripComboBox.Size = new System.Drawing.Size(160, 23);
            this.jumpToolStripComboBox.SelectedIndexChanged += new System.EventHandler(this.jumpToolStripComboBox_SelectedIndexChanged);
            // 
            // disableJumpForAnimationToolStripMenuItem
            // 
            this.disableJumpForAnimationToolStripMenuItem.Name = "disableJumpForAnimationToolStripMenuItem";
            this.disableJumpForAnimationToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.disableJumpForAnimationToolStripMenuItem.Text = "アニメーションGIFでは無効 (&A)";
            this.disableJumpForAnimationToolStripMenuItem.Click += new System.EventHandler(this.disableJumpForAnimationToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(258, 6);
            // 
            // resetWindowPositionToolStripMenuItem
            // 
            this.resetWindowPositionToolStripMenuItem.Name = "resetWindowPositionToolStripMenuItem";
            this.resetWindowPositionToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemPeriod)));
            this.resetWindowPositionToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.resetWindowPositionToolStripMenuItem.Text = "原点付近に移動 (&.)";
            this.resetWindowPositionToolStripMenuItem.Click += new System.EventHandler(this.resetWindowPositionToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemQuestion)));
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.helpToolStripMenuItem.Text = "情報 (&H)";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(221, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.exitToolStripMenuItem.Text = "終了 (&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.CheckFileExists = false;
            this.openFileDialogImage.CheckPathExists = false;
            this.openFileDialogImage.Filter = "画像 (*.jpg,*.gif,*.png,*.bmp,*.tiff)|*.jpg;*.jpeg;*.gif;*.png;*.bmp;*.exif;*.tiff|" +
    "全てのファイル|*.*";
            this.openFileDialogImage.Multiselect = true;
            this.openFileDialogImage.RestoreDirectory = true;
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // timerMotion
            // 
            this.timerMotion.Interval = 20;
            this.timerMotion.Tick += new System.EventHandler(this.timerMotion_Tick);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.ContextMenuStrip = this.contextMenuStripMain;
            this.Controls.Add(this.pictureBoxMain);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Image Viewer";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.Deactivate += new System.EventHandler(this.FormMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.contextMenuStripMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMain;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem invisibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topmostToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowNoFitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowFitsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowFitsHalfImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowFitsTwiceImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slideshowToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox intervalTimeToolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem motionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableJumpForAnimationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem intervalRandomizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prevImageToolStripMenuItem;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem resetWindowPositionToolStripMenuItem;
        private System.Windows.Forms.Timer timerMotion;
        private System.Windows.Forms.ToolStripComboBox jumpToolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}

