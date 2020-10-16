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

            pictureBoxMain.Invalidate();
        }

        void ImageFrameChanged(object obj, EventArgs e)
        {
            pictureBoxMain.Invalidate();
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            uniwinc = new UniWinCSharp();

            uniwinc.AttachMyWindow();
        }

        //private void buttonCheck_Click(object sender, EventArgs e)
        //{
        //    var pos = uniwinc.GetWindowPosition();
        //    var size = uniwinc.GetWindowSize();
        //    var hwnd = uniwinc.GetWindowHandle();
        //    var pid = uniwinc.GetMyProcessId();
        //    var myPid = System.Diagnostics.Process.GetCurrentProcess().Id;
        //    var clientSize = this.ClientSize;

        //    string message = String.Format(
        //        "Pos. {0}, {1}\r\nSize {2}, {3}\r\nClient {4}, {5}\r\nhWnd {6:X} / {7:X}\r\nPID {8} / {9}",
        //        pos.x, pos.y, size.x, size.y, clientSize.Width, clientSize.Height,
        //        hwnd.ToInt32(), this.Handle.ToInt32(), pid, myPid);


        //    Console.WriteLine(message);
        //    textBoxMessage.Text = message;
        //}

        private void checkBoxTransparent_CheckedChanged(object sender, EventArgs e)
        {
            toolStripButtonTransparent.Checked = !toolStripButtonTransparent.Checked;
            uniwinc.EnableTransparent(toolStripButtonTransparent.Checked);
        }

        private void checkBoxTopmost_CheckedChanged(object sender, EventArgs e)
        {
            toolStripButtonTopmost.Checked = !toolStripButtonTopmost.Checked;
            uniwinc.EnableTopmost(toolStripButtonTopmost.Checked);
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

                    Console.WriteLine(file);
                }

                Console.WriteLine(targetFiles.Count);

                // 先頭を選択して読み込み
                targetFileIndex = 0;
                LoadImage();
            }
        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(currentBitmap);
        }
    }
}
