using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UniWinImageViewer
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// 設定ファイルのパス
        /// 実行ファイルと同じディレクトリの config.json とする
        /// </summary>
        static readonly string SettingsPath = Path.Combine(
            Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName,
            "config.json"
            );

        /// <summary>
        /// 起動時または読込失敗した際のデフォルト画像
        /// </summary>
        static readonly string DefaultImage = Path.Combine(
            Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName,
            "default.png"
            );


        UniWinCSharp m_uniwin;

        Settings m_settings = new Settings();
        
        
        // 開くファイルのリスト
        List<string> m_targetFiles = new List<string>();

        string[] m_targetFileTypes = {
            ".jpg", ".jpeg", ".png", ".gif"
        };

        // リストの内何番目を表示するか
        int m_targetFileIndex = 0;

        // 裏で読み込むため2枚ビットマップを用意
        Bitmap[] m_bitmaps = new Bitmap[2];

        int m_bitmapIndex = 0;

        /// <summary>
        /// これが0でなければ、画像サイズにこれを書けたサイズにウィンドウサイズを自動調整
        /// </summary>
        float m_fitScale = 0.0f;

        bool m_isDragging = false;
        Point m_dragStartedCursorLocation;

        byte m_alphaThreshold = 0x19;

        Bitmap currentBitmap
        {
            get { return m_bitmaps[m_bitmapIndex];  }
        }


        public FormMain()
        {
            InitializeComponent();

            m_settings.Load(SettingsPath);
        }

        void ForwardImage(int step)
        {
            int count = m_targetFiles.Count;
            if (count < 1)
            {
                // ファイル指定が無かった場合
                m_targetFileIndex = 0;
                return;
            }

            int nextIndex = m_targetFileIndex += step;
            if (nextIndex >= m_targetFiles.Count)
            {
                nextIndex = 0;
            }
            if (nextIndex < 0)
            {
                nextIndex = m_targetFiles.Count - 1;
            }

            m_targetFileIndex = nextIndex;

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
                m_targetFiles.Clear();

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
                                if (m_targetFiles.Contains(ext))
                                {
                                    m_targetFiles.Add(path);
                                }
                            }
                        }
                    }
                    else if (File.Exists(file))
                    {
                        m_targetFiles.Add(file);
                    }
                }

                // 読み込まれたファイルがあれば、先頭を開く
                if (m_targetFiles.Count > 0)
                {
                    m_targetFileIndex = 0;
                    LoadImage();
                }
            }
        }

        void LoadImage()
        {
            // ファイル指定がなければ終了
            if (m_targetFiles.Count < 1) return;

            var path = m_targetFiles[m_targetFileIndex];
            Console.WriteLine("Loading " + path);

            int backIndex = m_bitmapIndex > 0 ? 0 : 1;

            Bitmap bitmap = null;
            try
            {
                bitmap = new Bitmap(path);

                var ext = Path.GetExtension(path).ToLower();
                if (ext == ".gif" && ImageAnimator.CanAnimate(bitmap))
                {
                    ImageAnimator.Animate(bitmap, new EventHandler(ImageFrameChanged));
                }
            } catch
            {
                Debug.WriteLine("Error on load: " + path);

                bitmap = new Bitmap(DefaultImage);
            }

            m_bitmaps[backIndex] = bitmap;
            m_bitmapIndex = backIndex;
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
            if (m_fitScale <= 0) return;

            int width = (int)(currentBitmap.Width * m_fitScale);
            int height = (int)(currentBitmap.Height* m_fitScale);

            this.ClientSize = new Size(width, height);

        }

        void UpdateUI()
        {
            // ウィンドウ状態
            invisibleToolStripMenuItem.Checked = m_uniwin.IsTransparent;
            topmostToolStripMenuItem.Checked = m_uniwin.IsTopmost;

            // 画像サイズへのフィット
            windowNoFitToolStripMenuItem.Checked = (m_fitScale == 0f);
            windowFitsImageToolStripMenuItem.Checked = (m_fitScale == 1.0f);
            windowFitsHalfImageToolStripMenuItem.Checked = (m_fitScale == 0.5f);
            windowFitsTwiceImageToolStripMenuItem.Checked = (m_fitScale == 2.0f);

        }

        /// <summary>
        /// クリックスルーすべきか判断して更新
        /// </summary>
        void UpdateClickThrough()
        {
            if (m_uniwin.IsTransparent && !m_isDragging)
            {
                Point curPos = Cursor.Position;
                Point location = pictureBoxMain.PointToClient(curPos);

                // SizeMode.Zoom 専用
                bool through;

                int pw = pictureBoxMain.Width;
                int ph = pictureBoxMain.Height;

                if (location.X < 0 || location.Y < 0 || location.X >= pw || location.Y >= ph)
                {
                    // pictureBoxの範囲外ならば、クリックスルーはしない
                    through = false;
                }
                else
                {
                    int iw = currentBitmap.Width;
                    int ih = currentBitmap.Height;

                    double imageAspect = (double)iw / (double)ih;
                    double pictureBoxAspect = (double)pw / (double)ph;

                    int x, y;

                    if (imageAspect > pictureBoxAspect)
                    {
                        // 画像の横幅が長い場合、Xは目いっぱい
                        x = location.X * iw / pw;
                        y = ((location.Y - ph / 2) * iw / pw) + iw / 2;
                    }
                    else
                    {
                        // 画像の高さが高い場合、Yは目いっぱい
                        x = ((location.X - pw / 2) * iw / pw) + iw / 2;
                        y = location.Y * iw / ph;
                    }


                    if (x < 0 || y < 0 || x >= iw || y >= ih) {
                        // 画像の範囲外ならばクリックスルー
                        through = true;
                    }
                    else
                    {
                        // 指定ピクセルの色のアルファを基に判断
                        var color = currentBitmap.GetPixel(x, y);
                        through = (color.A < m_alphaThreshold);
                    }
                }
                m_uniwin.EnableClickThrough(through);
            }
        }


        #region 設定保存関連

        /// <summary>
        /// 設定を反映
        /// </summary>
        private void ApplySettings()
        {
            m_uniwin.EnableTransparent(m_settings.IsTransparent);    // 透過状態
            m_uniwin.EnableTopmost(m_settings.IsTompost);            // 最前面
        }

        /// <summary>
        /// 設定を保存
        /// </summary>
        private void SaveSettings()
        {
            m_settings.IsTransparent = m_uniwin.IsTransparent;
            m_settings.IsTompost= m_uniwin.IsTopmost;

            m_settings.Save(SettingsPath);
        }

        #endregion
        

        #region UI要素のイベントハンドラ


        private void Form1_Shown(object sender, EventArgs e)
        {
            // ウィンドウ制御クラス
            m_uniwin = new UniWinCSharp();
            m_uniwin.AttachMyWindow();

            // 読み込まれた設定を適用
            ApplySettings();

            // UIの情報を更新
            UpdateUI();

            // デフォルト画像の読込
            string[] files = { DefaultImage };
            OpenFiles(files);

            // クリックスルー判定を開始
            timerMain.Start();
        }

        private void checkBoxTransparent_CheckedChanged(object sender, EventArgs e)
        {
            invisibleToolStripMenuItem.Checked = !invisibleToolStripMenuItem.Checked;
            m_uniwin.EnableTransparent(invisibleToolStripMenuItem.Checked);
        }

        private void checkBoxTopmost_CheckedChanged(object sender, EventArgs e)
        {
            topmostToolStripMenuItem.Checked = !topmostToolStripMenuItem.Checked;
            m_uniwin.EnableTopmost(topmostToolStripMenuItem.Checked);
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
                string[] files = openFileDialogImage.FileNames;
                OpenFiles(files);
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
                m_dragStartedCursorLocation = e.Location;
                m_isDragging = true;

                //if (m_uniwin != null) m_uniwin.EnableClickThrough(true);
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_isDragging = false;
            }
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_isDragging)
            {
                if (e.Button != MouseButtons.Left)
                {
                    m_isDragging = false;
                }
                else
                {
                    this.Left += (e.Location.X - m_dragStartedCursorLocation.X);
                    this.Top += (e.Location.Y - m_dragStartedCursorLocation.Y);

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

        private void windowNoFitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_fitScale = 0;
            windowNoFitToolStripMenuItem.Checked = true;
            windowFitsImageToolStripMenuItem.Checked = false;
            windowFitsHalfImageToolStripMenuItem.Checked = false;
            windowFitsTwiceImageToolStripMenuItem.Checked = false;

            FitWindowSize();
        }

        private void windowFitsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_fitScale = 1.0f;
            windowNoFitToolStripMenuItem.Checked = false;
            windowFitsImageToolStripMenuItem.Checked = true;
            windowFitsHalfImageToolStripMenuItem.Checked = false;
            windowFitsTwiceImageToolStripMenuItem.Checked = false;

            FitWindowSize();
        }

        private void windowFitsHalfImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_fitScale = 0.5f;
            windowNoFitToolStripMenuItem.Checked = false;
            windowFitsImageToolStripMenuItem.Checked = false;
            windowFitsHalfImageToolStripMenuItem.Checked = true;
            windowFitsTwiceImageToolStripMenuItem.Checked = false;

            FitWindowSize();
        }

        private void windowFitsTwiceImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_fitScale = 2.0f;
            windowNoFitToolStripMenuItem.Checked = false;
            windowFitsImageToolStripMenuItem.Checked = false;
            windowFitsHalfImageToolStripMenuItem.Checked = false;
            windowFitsTwiceImageToolStripMenuItem.Checked = true;

            FitWindowSize();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 設定を保存
            SaveSettings();
        }

        private void nextImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForwardImage(1);
        }

        private void prevImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForwardImage(-1);
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            UpdateClickThrough();
        }

        #endregion

        private void FormMain_Activated(object sender, EventArgs e)
        {
            // フォーカスが当たった直後はクリックスルーを強制解除
            if (m_uniwin != null) m_uniwin.EnableClickThrough(false);
        }
    }
}
