using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestLibUniWinC
{
    public partial class FormMain : Form
    {
        UniWinCSharp uniwinc;

        // 開くファイルのリスト
        List<string> targetFiles = new List<string>();

        string[] targetFileTypes = {
            ".jpg", ".jpeg", ".png", ".gif"
        };

        // リストの内何番目を表示するか
        int targetFileIndex = 0;

        // 裏で読み込むため2枚ビットマップを用意
        Bitmap[] bitmaps = new Bitmap[2];

        int bitmapIndex = 0;

        /// <summary>
        /// これが0でなければ、画像サイズにこれを書けたサイズにウィンドウサイズを自動調整
        /// </summary>
        float fitScale = 0.0f;

        bool isDragging = false;
        Point dragStartedCursorLocation;


        Bitmap currentBitmap
        {
            get { return bitmaps[bitmapIndex];  }
        }


        public FormMain()
        {
            InitializeComponent();
        }

        void ForwardImage(int step)
        {
            int count = targetFiles.Count;
            if (count < 1)
            {
                // ファイル指定が無かった場合
                targetFileIndex = 0;
                return;
            }

            int nextIndex = targetFileIndex += step;
            if (nextIndex >= targetFiles.Count)
            {
                nextIndex = 0;
            }
            if (nextIndex < 0)
            {
                nextIndex = targetFiles.Count - 1;
            }

            targetFileIndex = nextIndex;

            LoadImage();
        }

        /// <summary>
        /// ドロップまたは開くでファイルが指定されたときの処理
        /// </summary>
        /// <param name="files"></param>
        void OpenFiles(string[] files)
        {
            if (files.Count() > 0)
            {
                targetFiles.Clear();

                foreach (var file in files)
                {
                    if (Directory.Exists(file))
                    {
                        var pathes = Directory.GetFiles(file);
                        foreach (var path in pathes)
                        {
                            if (File.Exists(path))
                            {
                                var ext = Path.GetExtension(path).ToLower();
                                if (targetFiles.Contains(ext))
                                {
                                    targetFiles.Add(path);
                                }
                            }
                        }
                    }
                    else if (File.Exists(file))
                    {
                        targetFiles.Add(file);
                    }
                }

                // 読み込まれたファイルがあれば、先頭を開く
                if (targetFiles.Count > 0)
                {
                    targetFileIndex = 0;
                    LoadImage();
                }
            }
        }

        void LoadImage()
        {
            // ファイル指定がなければ終了
            if (targetFiles.Count < 1) return;

            var path = targetFiles[targetFileIndex];
            Console.WriteLine("Loading " + path);

            int backIndex = bitmapIndex > 0 ? 0 : 1;

            var bitmap = new Bitmap(path);
            bitmaps[backIndex] = bitmap;

            var ext = Path.GetExtension(path).ToLower();
            if (ext == ".gif") ImageAnimator.Animate(bitmap, new EventHandler(ImageFrameChanged));

            bitmapIndex = backIndex;
            pictureBoxMain.Image = currentBitmap;

            // ウィンドウサイズ調整
            FitWindowSize();

            pictureBoxMain.Invalidate();
        }

        void ImageFrameChanged(object obj, EventArgs e)
        {
            pictureBoxMain.Invalidate();
        }


        void FitWindowSize()
        {
            // 0ならサイズ調整無し
            if (fitScale <= 0) return;

            int width = (int)(currentBitmap.Width * fitScale);
            int height = (int)(currentBitmap.Height* fitScale);

            this.ClientSize = new Size(width, height);

        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            uniwinc = new UniWinCSharp();

            uniwinc.AttachMyWindow();
        }

        private void checkBoxTransparent_CheckedChanged(object sender, EventArgs e)
        {
            invisibleToolStripMenuItem.Checked = !invisibleToolStripMenuItem.Checked;
            uniwinc.EnableTransparent(invisibleToolStripMenuItem.Checked);
        }

        private void checkBoxTopmost_CheckedChanged(object sender, EventArgs e)
        {
            topmostToolStripMenuItem.Checked = !topmostToolStripMenuItem.Checked;
            uniwinc.EnableTopmost(topmostToolStripMenuItem.Checked);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
        }

        // ドラッグがウィンドウに入ってきたときの処理
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        // ドロップされたときの処理
        private void FormMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            OpenFiles(files);
        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(currentBitmap);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogImage.ShowDialog(this) == DialogResult.OK) {
                OpenFiles(openFileDialogImage.FileNames);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragStartedCursorLocation = e.Location;
                isDragging = true;
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                if (e.Button != MouseButtons.Left)
                {
                    isDragging = false;
                }
                else
                {
                    this.Left += (e.Location.X - dragStartedCursorLocation.X);
                    this.Top += (e.Location.Y - dragStartedCursorLocation.Y);

                }
            }
        }

        private void FormMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.None)
            {
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Space)
                {
                    ForwardImage(1);
                    e.Handled = true;
                }
                else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Back)
                {
                    ForwardImage(-1);
                    e.Handled = true;
                }
            }
        }
    }
}
