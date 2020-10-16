﻿namespace TestLibUniWinC
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
            this.textBoxMessage = new System.Windows.Forms.TextBox();
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
            this.enableSllideShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalTimeTtoolStripComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.motionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.intervalRandomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.次の画像NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.前の画像PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.contextMenuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.BackColor = System.Drawing.Color.Black;
            this.textBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMessage.Enabled = false;
            this.textBoxMessage.ForeColor = System.Drawing.Color.White;
            this.textBoxMessage.Location = new System.Drawing.Point(0, 0);
            this.textBoxMessage.Multiline = true;
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(384, 361);
            this.textBoxMessage.TabIndex = 1;
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.BackColor = System.Drawing.Color.Black;
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
            this.contextMenuStripMain.Size = new System.Drawing.Size(188, 170);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openToolStripMenuItem.Text = "開く (&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
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
            this.invisibleToolStripMenuItem.Click += new System.EventHandler(this.checkBoxTransparent_CheckedChanged);
            // 
            // topmostToolStripMenuItem
            // 
            this.topmostToolStripMenuItem.Name = "topmostToolStripMenuItem";
            this.topmostToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.topmostToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
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
            this.windowSizeToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.windowSizeToolStripMenuItem.Text = "ウィンドウサイズ (&W)";
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
            // slideshowToolStripMenuItem
            // 
            this.slideshowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.次の画像NToolStripMenuItem,
            this.前の画像PToolStripMenuItem,
            this.toolStripSeparator1,
            this.enableSllideShowToolStripMenuItem,
            this.intervalTimeTtoolStripComboBox,
            this.intervalRandomizeToolStripMenuItem});
            this.slideshowToolStripMenuItem.Name = "slideshowToolStripMenuItem";
            this.slideshowToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.slideshowToolStripMenuItem.Text = "スライドショー (&S)";
            // 
            // enableSllideShowToolStripMenuItem
            // 
            this.enableSllideShowToolStripMenuItem.Name = "enableSllideShowToolStripMenuItem";
            this.enableSllideShowToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.enableSllideShowToolStripMenuItem.Text = "一定時間で切替 (&0)";
            // 
            // intervalTimeTtoolStripComboBox
            // 
            this.intervalTimeTtoolStripComboBox.Items.AddRange(new object[] {
            "5 秒",
            "10 秒",
            "30 秒",
            "60 秒"});
            this.intervalTimeTtoolStripComboBox.Name = "intervalTimeTtoolStripComboBox";
            this.intervalTimeTtoolStripComboBox.Size = new System.Drawing.Size(121, 23);
            // 
            // motionToolStripMenuItem
            // 
            this.motionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jumpToolStripMenuItem,
            this.swingToolStripMenuItem});
            this.motionToolStripMenuItem.Name = "motionToolStripMenuItem";
            this.motionToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.motionToolStripMenuItem.Text = "動き (&M)";
            // 
            // jumpToolStripMenuItem
            // 
            this.jumpToolStripMenuItem.Name = "jumpToolStripMenuItem";
            this.jumpToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.jumpToolStripMenuItem.Text = "ジャンプ";
            // 
            // swingToolStripMenuItem
            // 
            this.swingToolStripMenuItem.Name = "swingToolStripMenuItem";
            this.swingToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.swingToolStripMenuItem.Text = "ゆれ";
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
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.Filter = "画像 (*.jpg,*.gif,*.png)|*.jpg;*.jpeg;*.jfif;*.gif;*.png|全てのファイル|*.*";
            this.openFileDialogImage.Multiselect = true;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // intervalRandomizeToolStripMenuItem
            // 
            this.intervalRandomizeToolStripMenuItem.Name = "intervalRandomizeToolStripMenuItem";
            this.intervalRandomizeToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.intervalRandomizeToolStripMenuItem.Text = "時間にゆらぎ (&R)";
            this.intervalRandomizeToolStripMenuItem.ToolTipText = "指定時間内でランダム性を与えます";
            // 
            // 次の画像NToolStripMenuItem
            // 
            this.次の画像NToolStripMenuItem.Name = "次の画像NToolStripMenuItem";
            this.次の画像NToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.次の画像NToolStripMenuItem.Text = "次の画像 (&N) ";
            // 
            // 前の画像PToolStripMenuItem
            // 
            this.前の画像PToolStripMenuItem.Name = "前の画像PToolStripMenuItem";
            this.前の画像PToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.前の画像PToolStripMenuItem.Text = "前の画像 (&P)";
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
            this.Controls.Add(this.textBoxMessage);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FormMain";
            this.Text = "Image Viewer";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.contextMenuStripMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxMessage;
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
        private System.Windows.Forms.ToolStripMenuItem 次の画像NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 前の画像PToolStripMenuItem;
    }
}

