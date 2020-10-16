namespace TestLibUniWinC
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
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTransparent = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTopmost = new System.Windows.Forms.ToolStripButton();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.contextMenuStripMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slideshowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowNoFitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowFitsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowFitsHalfImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowFitsTwiceImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.自動めくりなし0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxSlideInterval = new System.Windows.Forms.ToolStripComboBox();
            this.motionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ジャンプToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ゆれToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.invisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topmostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.contextMenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BackColor = System.Drawing.Color.Black;
            this.textBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMessage.ForeColor = System.Drawing.Color.White;
            this.textBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(384, 361);
            this.textBoxMessage.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonTransparent,
            this.toolStripButtonTopmost});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(384, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonOpen.Text = "Open (&O)";
            // 
            // toolStripButtonTransparent
            // 
            this.toolStripButtonTransparent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTransparent.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTransparent.Image")));
            this.toolStripButtonTransparent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTransparent.Name = "toolStripButtonTransparent";
            this.toolStripButtonTransparent.Size = new System.Drawing.Size(83, 22);
            this.toolStripButtonTransparent.Text = "Borderless (&B)";
            this.toolStripButtonTransparent.Click += new System.EventHandler(this.checkBoxTransparent_CheckedChanged);
            // 
            // toolStripButtonTopmost
            // 
            this.toolStripButtonTopmost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTopmost.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTopmost.Image")));
            this.toolStripButtonTopmost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTopmost.Name = "toolStripButtonTopmost";
            this.toolStripButtonTopmost.Size = new System.Drawing.Size(73, 22);
            this.toolStripButtonTopmost.Text = "Topmost (&T)";
            this.toolStripButtonTopmost.Click += new System.EventHandler(this.checkBoxTopmost_CheckedChanged);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.Black;
            this.pictureBoxMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxMain.Location = new System.Drawing.Point(0, 25);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(384, 336);
            this.pictureBoxMain.TabIndex = 4;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMain_Paint);
            // 
            // contextMenuStripMain
            // 
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
            this.contextMenuStripMain.Size = new System.Drawing.Size(188, 192);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openToolStripMenuItem.Text = "開く (&O)";
            // 
            // windowSizeToolStripMenuItem
            // 
            this.windowSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowNoFitToolStripMenuItem,
            this.windowFitsImageToolStripMenuItem,
            this.windowFitsHalfImageToolStripMenuItem,
            this.windowFitsTwiceImageToolStripMenuItem});
            this.windowSizeToolStripMenuItem.Name = "windowSizeToolStripMenuItem";
            this.windowSizeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.windowSizeToolStripMenuItem.Text = "ウィンドウサイズ (&W)";
            // 
            // slideshowToolStripMenuItem
            // 
            this.slideshowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自動めくりなし0ToolStripMenuItem,
            this.toolStripComboBoxSlideInterval});
            this.slideshowToolStripMenuItem.Name = "slideshowToolStripMenuItem";
            this.slideshowToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.slideshowToolStripMenuItem.Text = "スライドショー設定 (&S)";
            // 
            // windowNoFitToolStripMenuItem
            // 
            this.windowNoFitToolStripMenuItem.Name = "windowNoFitToolStripMenuItem";
            this.windowNoFitToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.windowNoFitToolStripMenuItem.Text = "画像へのフィットなし (&0)";
            // 
            // windowFitsImageToolStripMenuItem
            // 
            this.windowFitsImageToolStripMenuItem.Name = "windowFitsImageToolStripMenuItem";
            this.windowFitsImageToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.windowFitsImageToolStripMenuItem.Text = "画像サイズにフィット (&1)";
            // 
            // windowFitsHalfImageToolStripMenuItem
            // 
            this.windowFitsHalfImageToolStripMenuItem.Name = "windowFitsHalfImageToolStripMenuItem";
            this.windowFitsHalfImageToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.windowFitsHalfImageToolStripMenuItem.Text = "画像の半分にフィット (&2)";
            // 
            // windowFitsTwiceImageToolStripMenuItem
            // 
            this.windowFitsTwiceImageToolStripMenuItem.Name = "windowFitsTwiceImageToolStripMenuItem";
            this.windowFitsTwiceImageToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.windowFitsTwiceImageToolStripMenuItem.Text = "画像の倍にフィット (&3)";
            // 
            // 自動めくりなし0ToolStripMenuItem
            // 
            this.自動めくりなし0ToolStripMenuItem.Name = "自動めくりなし0ToolStripMenuItem";
            this.自動めくりなし0ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.自動めくりなし0ToolStripMenuItem.Text = "自動めくりなし (&0)";
            // 
            // toolStripComboBoxSlideInterval
            // 
            this.toolStripComboBoxSlideInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxSlideInterval.Items.AddRange(new object[] {
            "自動めくりなし",
            "5秒",
            "10秒",
            "30秒",
            "ランダム"});
            this.toolStripComboBoxSlideInterval.Name = "toolStripComboBoxSlideInterval";
            this.toolStripComboBoxSlideInterval.Size = new System.Drawing.Size(121, 23);
            // 
            // motionToolStripMenuItem
            // 
            this.motionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ジャンプToolStripMenuItem,
            this.ゆれToolStripMenuItem});
            this.motionToolStripMenuItem.Name = "motionToolStripMenuItem";
            this.motionToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.motionToolStripMenuItem.Text = "動き (&M)";
            // 
            // ジャンプToolStripMenuItem
            // 
            this.ジャンプToolStripMenuItem.Name = "ジャンプToolStripMenuItem";
            this.ジャンプToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ジャンプToolStripMenuItem.Text = "ジャンプ";
            // 
            // ゆれToolStripMenuItem
            // 
            this.ゆれToolStripMenuItem.Name = "ゆれToolStripMenuItem";
            this.ゆれToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ゆれToolStripMenuItem.Text = "ゆれ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(184, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exitToolStripMenuItem.Text = "終了 (&X)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(184, 6);
            // 
            // invisibleToolStripMenuItem
            // 
            this.invisibleToolStripMenuItem.Name = "invisibleToolStripMenuItem";
            this.invisibleToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.invisibleToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.invisibleToolStripMenuItem.Text = "透明化 (&I)";
            // 
            // topmostToolStripMenuItem
            // 
            this.topmostToolStripMenuItem.Name = "topmostToolStripMenuItem";
            this.topmostToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.topmostToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.topmostToolStripMenuItem.Text = "常に最前面 (&T)";
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.pictureBoxMain);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.textBoxMessage);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormMain";
            this.Text = "Image Viewer";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.contextMenuStripMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonTransparent;
        private System.Windows.Forms.ToolStripButton toolStripButtonTopmost;
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
        private System.Windows.Forms.ToolStripMenuItem 自動めくりなし0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxSlideInterval;
        private System.Windows.Forms.ToolStripMenuItem motionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ジャンプToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ゆれToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

