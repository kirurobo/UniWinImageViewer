using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static UniWinImageViewer.UniWinCSharp;

namespace UniWinImageViewer
{
    /// <summary>
    /// 画像ビューア
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// 値としてfloatを保持するコンボボックスの選択肢
        /// </summary>
        class FloatItem
        {
            public float Value;
            public string Text;

            public FloatItem(float value, string text)
            {
                this.Value = value;
                this.Text = text;
            }

            public override string ToString()
            {
                return this.Text;
            }
        }

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
        JumpController m_jumper;

        Settings m_settings = new Settings();

        WebClient m_webClient = new WebClient();

        Random m_random = new Random();

        // 開くファイルのリスト
        List<string> m_targetFiles = new List<string>();

        string[] m_targetExtensions = {
            ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".exif"
        };

        // リストの内何番目を表示するか
        int m_targetFileIndex = 0;

        // 裏で読み込むため2枚ビットマップを用意
        Bitmap[] m_bitmaps = new Bitmap[2];

        int m_bitmapIndex = 0;

        /// <summary>
        /// これが0でなければ、画像サイズにこれを書けたサイズにウィンドウサイズを自動調整
        /// </summary>
        float m_fitScale = 1.0f;

        /// <summary>
        /// スライドショー間隔 [s]
        /// </summary>
        float m_slideShowInterval = 0.0f;
        Stopwatch m_stopwatch = new Stopwatch();
        long m_nextImageTime = 0;   // 次の画像に移る時刻

        /// <summary>
        /// スライドショー間隔にゆらぎをあたえるか
        /// </summary>
        bool m_hasIntervalFlactuation = false;

        /// <summary>
        /// ジャンプ頻度。0ならジャンプなし
        /// </summary>
        float m_jumpFrequency = 0f;

        /// <summary>
        /// アニメーションGIFではジャンプをしない
        /// </summary>
        bool m_isJumpDisabledForAnim = false;

        /// <summary>
        /// アニメーション画像を表示中ならtrueとなる
        /// </summary>
        bool m_isAnimation = false;

        bool m_isTransparent = false;
        bool m_isTopmost = false;
        bool m_isDragging = false;
        bool m_isOpaque = false;    // [Shift]を押している間trueになり、一時的に透過を抑制する
        Point m_dragStartedCursorLocation;
        byte m_alphaThreshold = 0x19;

        Image m_originalBackgroundImage = null;

        Bitmap currentBitmap
        {
            get { return m_bitmaps[m_bitmapIndex];  }
        }

        /// <summary>
        /// 起動直後の初期化処理
        /// </summary>
        void Initialize()
        {
            // コンテキストメニュー文字列の修正
            InitializeContextMenuItems();

            // コンボボックスの選択肢を作成
            InitializeIntervalCombobox();

            // 背景画像（市松）を保存
            m_originalBackgroundImage = pictureBoxMain.BackgroundImage;

            // 設定をJSONファイルから読み込み
            m_settings.Load(SettingsPath);

            // 起動時からの経過時間測定を開始
            m_stopwatch.Start();

            // マウスホイールイベントハンドラを用意
            MouseWheel += FormMain_MouseWheel;

        }

        /// <summary>
        /// コンテキストメニューのショートカットキー表示を更新
        ///   標準ではいまいちなもの、設定できていない分について付け足し
        /// </summary>
        void InitializeContextMenuItems()
        {
            helpToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+?";
            exitToolStripMenuItem.ShortcutKeyDisplayString = "Esc";
            nextImageToolStripMenuItem.ShortcutKeyDisplayString = "Space / →";
            prevImageToolStripMenuItem.ShortcutKeyDisplayString = "BS / ←";
            resetWindowPositionToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+.";
            windowFitsHalfImageToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+[-]";
            windowFitsTwiceImageToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+[+]";
        }

        /// <summary>
        /// コンボボックスの選択肢初期化
        /// </summary>
        void InitializeIntervalCombobox()
        {
            ComboBox.ObjectCollection items;

            // スライドショー間隔の選択肢
            items = intervalTimeToolStripComboBox.Items;
            items.Add(new FloatItem(0f,  "自動切替なし"));
            items.Add(new FloatItem(5f,  " 5 秒で次画像"));
            items.Add(new FloatItem(10f, "10 秒で次画像"));
            items.Add(new FloatItem(30f, "30 秒で次画像"));
            items.Add(new FloatItem(60f, "60 秒で次画像"));

            // ジャンプ頻度の選択肢
            items = jumpToolStripComboBox.Items;
            items.Add(new FloatItem( 0f, "ぴょんぴょんしない"));
            items.Add(new FloatItem(60f, "稀にぴょんぴょん"));
            items.Add(new FloatItem(30f, "時折ぴょんぴょん"));
            items.Add(new FloatItem(10f, "割合ぴょんぴょん"));
            items.Add(new FloatItem( 5f, "結構ぴょんぴょん"));
            items.Add(new FloatItem( 2f, "頻繁ぴょんぴょん"));
        }

        /// <summary>
        /// ウィンドウが開かれた際に実行する初期化処理
        /// </summary>
        void Start()
        {
            // ウィンドウ制御クラス準備
            m_uniwin = new UniWinCSharp();
            m_uniwin.AttachMyWindow();

            // ジャンプ制御クラス準備
            m_jumper = new JumpController(m_uniwin);

            // 読み込まれた設定を適用
            ApplySettings();

            // UIの情報を更新
            UpdateUI();

            // 初期画像を開く
            string[] files = { DefaultImage };  // デフォルト画像のパス
            // コマンドライン引数で渡されたものがあればファイルとみなす
            var args = System.Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                files = new string[args.Length - 1];
                for (int i = 1; i < args.Length; i++)
                {
                    files[i - 1] = args[i];
                }
            }
            OpenFiles(files);

            // クリックスルー判定ループを開始
            timerMain.Start();

            // 動きのループを開始
            timerMotion.Start();
        }

        void ForwardImage(int step)
        {
            if (m_targetFiles.Count <= 1)
            {
                // ファイル指定が無かった場合か、1つしかなかった場合は再読み込みしない
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
                                if (m_targetExtensions.Contains(ext))
                                {
                                    m_targetFiles.Add(path);
                                }
                            }
                        }
                    }
                    else if (File.Exists(file))
                    {
                        var ext = Path.GetExtension(file).ToLower();
                        if (m_targetExtensions.Contains(ext)) {
                            m_targetFiles.Add(file);
                        }
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

        /// <summary>
        /// URLが指定された時の処理
        /// </summary>
        /// <param name="url"></param>
        void OpenUrl(string url)
        {
            m_targetFiles.Clear();
            m_targetFiles.Add(url);
            m_targetFileIndex = 0;
            LoadImage();
        }

        /// <summary>
        /// 現在対象となっている画像を開く
        /// </summary>
        void LoadImage()
        {
            // ファイル指定がなければ終了
            if (m_targetFiles.Count < 1) return;

            var path = m_targetFiles[m_targetFileIndex];
            //Debug.WriteLine("Loading " + path);

            int backIndex = m_bitmapIndex > 0 ? 0 : 1;
            int foreIndex = m_bitmapIndex;

            bool isUrl = false;
            if (path.StartsWith("https://") || path.StartsWith("http://"))
            {
                // URLと判別
                isUrl = true;
            }

            // アニメーションであるかのフラグは一旦クリア
            m_isAnimation = false;

            Stream stream = null;
            Bitmap bitmap = null;
            try
            {
                if (isUrl)
                {
                    stream = m_webClient.OpenRead(path);
                    bitmap = new Bitmap(stream);
                }
                else
                {
                    bitmap = new Bitmap(path);
                }

                if (ImageAnimator.CanAnimate(bitmap))
                {
                    ImageAnimator.Animate(bitmap, new EventHandler(ImageFrameChanged));
                    m_isAnimation = true;
                }
            }
            catch
            {
                Debug.WriteLine("Error on load: " + path);
                bitmap = new Bitmap(DefaultImage);

                // 読込に失敗したら、そのパスはリストから消去
                m_targetFiles.RemoveAt(m_targetFileIndex);
                
                // スライショーでは次の画像が出るように、インデックスを1つ戻す。
                //  ただし、前の画像に戻すをされると2つ前となってしまう。そこは妥協
                m_targetFileIndex--;
                if (m_targetFileIndex < 0)
                {
                    m_targetFileIndex = 0;
                }
            }
            finally
            {
                if (stream != null) stream.Close();
            }

            m_bitmaps[backIndex] = bitmap;
            m_bitmapIndex = backIndex;
            
            pictureBoxMain.Image = currentBitmap;

            // 前の画像リソースはクリア
            if (m_bitmaps[foreIndex] != null)
            {
                m_bitmaps[foreIndex].Dispose();
                m_bitmaps[foreIndex] = null;
            }

            // ウィンドウサイズ調整
            FitWindowSize();

            pictureBoxMain.Invalidate();

            // アニメーションか否かでモーションを再生したり停止したり
            m_jumper.IsSuppressed = (m_isAnimation && m_isJumpDisabledForAnim);

            // スライドショーリセット
            RestartSlideShow();
        }

        void ImageFrameChanged(object obj, EventArgs e)
        {
            pictureBoxMain.Invalidate();
        }

        void StartMotion()
        {
            if (m_jumpFrequency > 0f)
            {
                SetJumpFrequency();
                m_jumper.Start();
            }
        }

        void StopMotion()
        {
            m_jumper.Stop();
        }

        void SetJumpFrequency()
        {
            m_jumper.minWait = (int)(m_jumpFrequency * 200f);   // 最大の2割を最低とする
            m_jumper.maxWait = (int)(m_jumpFrequency * 1000f);
        }

        /// <summary>
        /// ウィンドウサイズを画像の何倍かに合わせる
        /// </summary>
        void FitWindowSize()
        {
            // 0ならサイズ調整なし
            if (m_fitScale <= 0) return;

            // 最大化されているときは調整なし
            if (m_uniwin.IsMaximized) return;

            int width = (int)(currentBitmap.Width * m_fitScale);
            int height = (int)(currentBitmap.Height* m_fitScale);

            //this.ClientSize = new Size(width, height);        // Formの機能でサイズ変更する場合

            m_uniwin.SetWindowSize(new UniWinCSharp.Vector2(width, height));
        }

        /// <summary>
        /// 指定スケールで現在のウィンドウサイズを変更
        /// </summary>
        /// <param name="scale"></param>
        void ScaleWindowSize(float scale)
        {
            var size = m_uniwin.GetWindowSize();
            size.x *= scale;
            size.y *= scale;
            m_uniwin.SetWindowSize(size);
        }

        /// <summary>
        /// ウィンドウ透過を設定／解除
        /// </summary>
        /// <param name="isTransparent"></param>
        void SetTransparent(bool isTransparent)
        {
            // 一時透過解除中は透過なしとして扱う
            bool enabled = (isTransparent && !m_isOpaque);

            if (enabled)
            {
                pictureBoxMain.BackgroundImage = null;
            }
            else
            {
                pictureBoxMain.BackgroundImage = m_originalBackgroundImage;
            }

            // 状態が変化していれば、適用
            if (m_uniwin.IsTransparent != enabled)
            {
                m_uniwin.EnableTransparent(enabled);
            }
        }

        /// <summary>
        /// 毎フレームの処理
        /// </summary>
        void UpdateFrame()
        {
            // クリックスルー更新
            UpdateClickThrough();

            if (!m_jumper.IsMoving)
            {
                // 運動中でなければスライドショーめくり処理
                UpdateSlideShow();
            }

        }

        /// <summary>
        /// 経過時間をみてスライドショーを更新
        /// </summary>
        void UpdateSlideShow()
        {
            long now = m_stopwatch.ElapsedMilliseconds;

            if (m_slideShowInterval > 0 && m_nextImageTime <= now)
            {
                ForwardImage(1);
                m_nextImageTime = now + (int)(m_slideShowInterval * 1000);
            }
        }

        /// <summary>
        /// コンテキストメニューの表示を更新
        /// </summary>
        void UpdateUI()
        {
            // ウィンドウ状態
            invisibleToolStripMenuItem.Checked = m_isTransparent;
            topmostToolStripMenuItem.Checked = m_isTopmost;

            // 画像サイズへのフィット
            windowNoFitToolStripMenuItem.Checked = (m_fitScale == 0f);
            windowFitsImageToolStripMenuItem.Checked = (m_fitScale == 1.0f);
            windowFitsHalfImageToolStripMenuItem.Checked = (m_fitScale == 0.5f);
            windowFitsTwiceImageToolStripMenuItem.Checked = (m_fitScale == 2.0f);

            // スライドショー間隔
            bool wasSelected = false;
            foreach(FloatItem item in intervalTimeToolStripComboBox.Items)
            {
                // 誤差 0.1 以内なら同じとみなす
                if (Math.Abs(item.Value - m_slideShowInterval) < 0.1)
                {
                    intervalTimeToolStripComboBox.SelectedItem = item;
                    m_slideShowInterval = item.Value;
                    wasSelected = true;
                    break;
                }
            }
            if (!wasSelected)
            {
                intervalTimeToolStripComboBox.SelectedIndex = 0;
                m_slideShowInterval = 0f;
            }
            intervalRandomizeToolStripMenuItem.Checked = m_hasIntervalFlactuation;

            // ジャンプ頻度
            wasSelected = false;
            foreach (FloatItem item in jumpToolStripComboBox.Items)
            {
                // 誤差 0.1 以内なら同じとみなす
                if (Math.Abs(item.Value - m_jumpFrequency) < 0.1)
                {
                    jumpToolStripComboBox.SelectedItem = item;
                    m_jumpFrequency = item.Value;
                    wasSelected = true;
                    break;
                }
            }
            if (!wasSelected)
            {
                jumpToolStripComboBox.SelectedIndex = 0;
                m_jumpFrequency = 0f;
            }
            disableJumpForAnimationToolStripMenuItem.Checked = m_isJumpDisabledForAnim;
        }

        /// <summary>
        /// カーソル座標により、クリックスルーすべきか判断して更新
        /// </summary>
        void UpdateClickThrough()
        {
            bool through = false;

            if (m_uniwin.IsTransparent && !m_isDragging)
            {
                Point curPos = Cursor.Position;
                Point location = pictureBoxMain.PointToClient(curPos);

                int pw = pictureBoxMain.Width;
                int ph = pictureBoxMain.Height;

                if (location.X < 0 || location.Y < 0 || location.X >= pw || location.Y >= ph)
                {
                    // pictureBoxの範囲外ならば、クリックスルーはしない
                    through = false;
                }
                else
                {
                    // SizeMode.Zoom 専用で、画像のマウスカーソル座標を画像座標に換算

                    int iw = currentBitmap.Width;
                    int ih = currentBitmap.Height;

                    double imageAspect = (double)iw / (double)ih;
                    double pictureBoxAspect = (double)pw / (double)ph;

                    int x, y;

                    if (imageAspect > pictureBoxAspect)
                    {
                        // 画像の横幅が長い場合、Xは目いっぱい
                        x = location.X * iw / pw;
                        y = ((location.Y - ph / 2) * iw / pw) + ih / 2;     // y なのに * iw / pw となっていることに注意。Zoomなのでこうする。
                    }
                    else
                    {
                        // 画像の高さが高い場合、Yは目いっぱい
                        x = ((location.X - pw / 2) * ih / ph) + iw / 2;     // x なのに * ih / ph となっていることに注意。Zoomなのでこうする。
                        y = location.Y * ih / ph;
                    }


                    if (x < 0 || y < 0 || x >= iw || y >= ih)
                    {
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

            }

            // さっきまでと異なっていれば適用
            if (m_uniwin.IsClickThrough != through)
            {
                m_uniwin.EnableClickThrough(through);
            }
        }

        /// <summary>
        /// スライドショー間隔が変更された時の処理
        /// </summary>
        void UpdateSlideShowInterval()
        {
            FloatItem item = (FloatItem)intervalTimeToolStripComboBox.SelectedItem;
            float interval = item.Value;

            // 時間に変更があれば、スライドショー開始
            if (interval != m_slideShowInterval)
            {
                m_slideShowInterval = interval;
                RestartSlideShow();
            }
        }

        /// <summary>
        /// ジャンプ頻度が変更された時の処理
        /// </summary>
        void UpdateJUmpInterval()
        {
            FloatItem item = (FloatItem)jumpToolStripComboBox.SelectedItem;
            m_jumpFrequency = item.Value;

            // ジャンプ頻度を適用
            if (m_jumpFrequency > 0)
            {
                SetJumpFrequency();
            }
        }

        /// <summary>
        /// スライドショー開始（実行中なら時間をリセット）
        /// </summary>
        void RestartSlideShow()
        {
            int delta;
            if (m_hasIntervalFlactuation)
            {
                // 指定秒数の 10% ～ 100% のランダムとする
                delta = (int)(m_slideShowInterval * m_random.Next(100, 1000));
            }
            else
            {
                delta = (int)(m_slideShowInterval * 1000f);
            }
            m_nextImageTime = m_stopwatch.ElapsedMilliseconds + delta;
        }

        #region 設定保存関連

        /// <summary>
        /// 設定を反映
        /// </summary>
        private void ApplySettings()
        {
            m_isTransparent = m_settings.IsTransparent;             // 透過状態
            m_isTopmost = m_settings.IsTompost;                     // 最前面
            SetTransparent(m_isTransparent);
            m_uniwin.EnableTopmost(m_isTopmost);

            m_fitScale = m_settings.WindowFitScale;                 // ウィンドウサイズを画像に合わせる倍率
            if (float.IsNaN(m_fitScale)) m_fitScale = 1.0f;         // 倍率が正しくなければ1に戻す
            m_slideShowInterval = m_settings.SlideShowInterval;     // スライドショー間隔
            m_hasIntervalFlactuation = m_settings.HasIntervalFluctuation;   // 間隔ゆらぎあり

            m_jumpFrequency = m_settings.JumpFrequency;                     // ジャンプ頻度
            m_isJumpDisabledForAnim = m_settings.IsJumpDisabledInAmination; // アニメーション画像ではジャンプを抑制するか
            StartMotion();
        }

        /// <summary>
        /// 設定を保存
        /// </summary>
        private void SaveSettings()
        {
            m_settings.IsTransparent = m_isTransparent;
            m_settings.IsTompost= m_isTopmost;
            m_settings.WindowFitScale = m_fitScale;
            m_settings.SlideShowInterval = m_slideShowInterval;
            m_settings.HasIntervalFluctuation = m_hasIntervalFlactuation;
            m_settings.JumpFrequency = m_jumpFrequency;
            m_settings.IsJumpDisabledInAmination = m_isJumpDisabledForAnim;

            m_settings.Save(SettingsPath);
        }

        #endregion


        #region UI要素のイベントハンドラ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            Initialize();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Start();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 設定を保存
            SaveSettings();
        }

        private void checkBoxTransparent_CheckedChanged(object sender, EventArgs e)
        {
            m_isTransparent = invisibleToolStripMenuItem.Checked = !invisibleToolStripMenuItem.Checked;
            SetTransparent(m_isTransparent);
        }

        private void checkBoxTopmost_CheckedChanged(object sender, EventArgs e)
        {
            m_isTopmost = topmostToolStripMenuItem.Checked = !topmostToolStripMenuItem.Checked;
            m_uniwin.EnableTopmost(m_isTopmost);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
        }

        // ドラッグがウィンドウに入ってきたときの処理
        private void FormMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)
                || e.Data.GetDataPresent("UniformResourceLocator")
                || e.Data.GetDataPresent("UniformResourceLocatorW"))
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
            if (e.Data.GetDataPresent("UniformResourceLocator") || e.Data.GetDataPresent("UniformResourceLocatorW"))
            {
                // URLがドロップされた場合
                string url = e.Data.GetData(DataFormats.Text).ToString();
                OpenUrl(url);
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ファイルまたはフォルダがドロップされた場合
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                OpenFiles(files);
            }
        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames(currentBitmap);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialogImage.ShowDialog() == DialogResult.OK) {
                string[] files = openFileDialogImage.FileNames;
                OpenFiles(files);
            }
            openFileDialogImage.Dispose();
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

                StopMotion();
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_isDragging = false;

                StartMotion();
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
                    //// Form の機能でのウィンドウ移動
                    //this.Left += (e.Location.X - m_dragStartedCursorLocation.X);
                    //this.Top += (e.Location.Y - m_dragStartedCursorLocation.Y);
                    
                    var pos = m_uniwin.GetWindowPosition();
                    pos.x += (e.Location.X - m_dragStartedCursorLocation.X);
                    pos.y -= (e.Location.Y - m_dragStartedCursorLocation.Y);    // Windowsの座標系とは逆
                    m_uniwin.SetWindowPosition(pos);
                }
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            // [Shift]キーで一時的に透過解除
            if (e.KeyCode == Keys.ShiftKey)
            {
                m_isOpaque = true;
                SetTransparent(false);

                StopMotion();
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
                else if (e.KeyCode == Keys.Escape)
                {
                    // [ESC] で終了
                    Close();
                    e.Handled = true;
                }
            }

            if (e.KeyCode == Keys.ShiftKey)
            {
                m_isOpaque = false;
                SetTransparent(m_isTransparent);

                StartMotion();
            }
        }

        /// <summary>
        /// マウスホイール操作時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None)
            {
                float scale = (float)Math.Pow(10.0, e.Delta * 0.0005);

                // 今のマウス座標が中心となって拡大縮小するよう、位置を調整
                var pos = m_uniwin.GetWindowPosition();
                float sx = e.X * (1f - scale);
                float sy = (Height - e.Y) * (1f - scale);
                pos.x += sx;
                pos.y += sy;
                m_uniwin.SetWindowPosition(pos);

                // ウィンドウを拡大縮小
                if (m_fitScale != 0)
                {
                    // 画像サイズにフィットする場合
                    m_fitScale *= scale;
                    FitWindowSize();
                }
                else
                {
                    // 画像サイズへのフィット無しの場合は、現在のウィンドウサイズを基準に変更
                    ScaleWindowSize(scale);
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
            UpdateFrame();
        }

        private void timerMotion_Tick(object sender, EventArgs e)
        {
            // 運動がある場合の更新
            m_jumper.Update();
        }

        private void FormMain_Activated(object sender, EventArgs e)
        {
            // [Shift]キーが押されていなければ一時透過解除をやめる
            if (m_isOpaque && (Control.ModifierKeys & Keys.Shift) != Keys.Shift)
            {
                m_isOpaque = false;
                SetTransparent(m_isTransparent);
            }


            // フォーカスが当たった直後はクリックスルーを強制解除
            if (m_uniwin != null) m_uniwin.EnableClickThrough(false);
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            // フォーカスを失ったら、一時透過解除
            if (m_isOpaque)
            {
                m_isOpaque = false;
                SetTransparent(m_isTransparent);
            }
        }

        private void intervalTimeTtoolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSlideShowInterval();
        }

        private void jumpToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateJUmpInterval();
            if (m_jumpFrequency > 0)
            {
                StartMotion();
            }
            else
            {
                StopMotion();
            }
        }

        private void intervalRandomizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            intervalRandomizeToolStripMenuItem.Checked = !intervalRandomizeToolStripMenuItem.Checked;
            m_hasIntervalFlactuation = intervalRandomizeToolStripMenuItem.Checked;
            RestartSlideShow();
        }

        private void resetWindowPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 原点（プライマリモニタの左下）付近にウィンドウを強制移動
            m_uniwin.SetWindowPosition(new Vector2(60, 60));
        }

        private void disableJumpForAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            disableJumpForAnimationToolStripMenuItem.Checked = !disableJumpForAnimationToolStripMenuItem.Checked;
            m_isJumpDisabledForAnim = disableJumpForAnimationToolStripMenuItem.Checked;

            m_jumper.IsSuppressed = (m_isJumpDisabledForAnim && m_isAnimation);
        }

        #endregion

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var help = new AboutBoxHelp();
            help.ShowDialog(this);
        }
    }
}
