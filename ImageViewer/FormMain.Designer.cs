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
            this.enableSllideShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalTimeTtoolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.intervalRandomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
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
            this.exitToolStripMenuItem});
            this.contextMenuStripMain.Name = "contextMenuStripMain";
            this.contextMenuStripMain.Size = new System.Drawing.Size(255, 240);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.openToolStripMenuItem.Text = "開く (&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(251, 6);
            // 
            // invisibleToolStripMenuItem
            // 
            this.invisibleToolStripMenuItem.Name = "invisibleToolStripMenuItem";
            this.invisibleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.invisibleToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.invisibleToolStripMenuItem.Text = "透明化 (&I)";
            this.invisibleToolStripMenuItem.Click += new System.EventHandler(this.checkBoxTransparent_CheckedChanged);
            // 
            // topmostToolStripMenuItem
            // 
            this.topmostToolStripMenuItem.Name = "topmostToolStripMenuItem";
            this.topmostToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.topmostToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
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
            this.windowSizeToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.windowSizeToolStripMenuItem.Text = "ウィンドウサイズ (&W)";
            // 
            // windowNoFitToolStripMenuItem
            // 
            this.windowNoFitToolStripMenuItem.Name = "windowNoFitToolStripMenuItem";
            this.windowNoFitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D9)));
            this.windowNoFitToolStripMenuItem.Size = new System.Drawing.Size(422, 34);
            this.windowNoFitToolStripMenuItem.Text = "画像へのフィットなし (&9)";
            this.windowNoFitToolStripMenuItem.Click += new System.EventHandler(this.windowNoFitToolStripMenuItem_Click);
            // 
            // windowFitsImageToolStripMenuItem
            // 
            this.windowFitsImageToolStripMenuItem.Name = "windowFitsImageToolStripMenuItem";
            this.windowFitsImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D0)));
            this.windowFitsImageToolStripMenuItem.Size = new System.Drawing.Size(422, 34);
            this.windowFitsImageToolStripMenuItem.Text = "画像サイズにフィット (&0)";
            this.windowFitsImageToolStripMenuItem.Click += new System.EventHandler(this.windowFitsImageToolStripMenuItem_Click);
            // 
            // windowFitsHalfImageToolStripMenuItem
            // 
            this.windowFitsHalfImageToolStripMenuItem.Name = "windowFitsHalfImageToolStripMenuItem";
            this.windowFitsHalfImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.windowFitsHalfImageToolStripMenuItem.Size = new System.Drawing.Size(422, 34);
            this.windowFitsHalfImageToolStripMenuItem.Text = "画像の半分にフィット (&-)";
            this.windowFitsHalfImageToolStripMenuItem.Click += new System.EventHandler(this.windowFitsHalfImageToolStripMenuItem_Click);
            // 
            // windowFitsTwiceImageToolStripMenuItem
            // 
            this.windowFitsTwiceImageToolStripMenuItem.Name = "windowFitsTwiceImageToolStripMenuItem";
            this.windowFitsTwiceImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemplus)));
            this.windowFitsTwiceImageToolStripMenuItem.Size = new System.Drawing.Size(422, 34);
            this.windowFitsTwiceImageToolStripMenuItem.Text = "画像の倍にフィット (&+)";
            this.windowFitsTwiceImageToolStripMenuItem.Click += new System.EventHandler(this.windowFitsTwiceImageToolStripMenuItem_Click);
            // 
            // slideshowToolStripMenuItem
            // 
            this.slideshowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nextImageToolStripMenuItem,
            this.prevImageToolStripMenuItem,
            this.toolStripSeparator1,
            this.enableSllideShowToolStripMenuItem,
            this.intervalTimeTtoolStripComboBox,
            this.intervalRandomizeToolStripMenuItem});
            this.slideshowToolStripMenuItem.Name = "slideshowToolStripMenuItem";
            this.slideshowToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.slideshowToolStripMenuItem.Text = "スライドショー (&S)";
            // 
            // nextImageToolStripMenuItem
            // 
            this.nextImageToolStripMenuItem.Name = "nextImageToolStripMenuItem";
            this.nextImageToolStripMenuItem.Size = new System.Drawing.Size(261, 34);
            this.nextImageToolStripMenuItem.Text = "次の画像 (&N) ";
            this.nextImageToolStripMenuItem.Click += new System.EventHandler(this.nextImageToolStripMenuItem_Click);
            // 
            // prevImageToolStripMenuItem
            // 
            this.prevImageToolStripMenuItem.Name = "prevImageToolStripMenuItem";
            this.prevImageToolStripMenuItem.Size = new System.Drawing.Size(261, 34);
            this.prevImageToolStripMenuItem.Text = "前の画像 (&P)";
            this.prevImageToolStripMenuItem.Click += new System.EventHandler(this.prevImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(258, 6);
            // 
            // enableSllideShowToolStripMenuItem
            // 
            this.enableSllideShowToolStripMenuItem.Name = "enableSllideShowToolStripMenuItem";
            this.enableSllideShowToolStripMenuItem.Size = new System.Drawing.Size(261, 34);
            this.enableSllideShowToolStripMenuItem.Text = "一定時間で切替 (&0)";
            this.enableSllideShowToolStripMenuItem.Click += new System.EventHandler(this.enableSllideShowToolStripMenuItem_Click);
            // 
            // intervalTimeTtoolStripComboBox
            // 
            this.intervalTimeTtoolStripComboBox.Items.AddRange(new object[] {
            "5 秒",
            "10 秒",
            "30 秒",
            "60 秒"});
            this.intervalTimeTtoolStripComboBox.Name = "intervalTimeTtoolStripComboBox";
            this.intervalTimeTtoolStripComboBox.Size = new System.Drawing.Size(121, 33);
            this.intervalTimeTtoolStripComboBox.TextChanged += new System.EventHandler(this.intervalTimeTtoolStripComboBox_TextChanged);
            // 
            // intervalRandomizeToolStripMenuItem
            // 
            this.intervalRandomizeToolStripMenuItem.Name = "intervalRandomizeToolStripMenuItem";
            this.intervalRandomizeToolStripMenuItem.Size = new System.Drawing.Size(261, 34);
            this.intervalRandomizeToolStripMenuItem.Text = "時間にゆらぎ (&R)";
            this.intervalRandomizeToolStripMenuItem.ToolTipText = "指定時間内でランダム性を与えます";
            // 
            // motionToolStripMenuItem
            // 
            this.motionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jumpToolStripMenuItem,
            this.swingToolStripMenuItem});
            this.motionToolStripMenuItem.Name = "motionToolStripMenuItem";
            this.motionToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.motionToolStripMenuItem.Text = "動き (&M)";
            // 
            // jumpToolStripMenuItem
            // 
            this.jumpToolStripMenuItem.Name = "jumpToolStripMenuItem";
            this.jumpToolStripMenuItem.Size = new System.Drawing.Size(168, 34);
            this.jumpToolStripMenuItem.Text = "ジャンプ";
            // 
            // swingToolStripMenuItem
            // 
            this.swingToolStripMenuItem.Name = "swingToolStripMenuItem";
            this.swingToolStripMenuItem.Size = new System.Drawing.Size(168, 34);
            this.swingToolStripMenuItem.Text = "ゆれ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(251, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(254, 32);
            this.exitToolStripMenuItem.Text = "終了 (&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.CheckFileExists = false;
            this.openFileDialogImage.CheckPathExists = false;
            this.openFileDialogImage.Filter = "画像 (*.jpg,*.gif,*.png)|*.jpg;*.jpeg;*.jfif;*.gif;*.png|全てのファイル|*.*";
            this.openFileDialogImage.Multiselect = true;
            this.openFileDialogImage.RestoreDirectory = true;
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.ContextMenuStrip = this.contextMenuStripMain;
            this.Controls.Add(this.pictureBoxMain);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Image Viewer";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
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
        private System.Windows.Forms.ToolStripMenuItem enableSllideShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox intervalTimeTtoolStripComboBox;
        private System.Windows.Forms.ToolStripMenuItem motionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swingToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem intervalRandomizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nextImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prevImageToolStripMenuItem;
        private System.Windows.Forms.Timer timerMain;
    }
}

