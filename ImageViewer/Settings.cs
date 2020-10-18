using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace UniWinImageViewer
{
    /// <summary>
    /// JSON に設定を保存するためのクラス
    /// </summary>
    [DataContract]
    public class Settings
    {
        /// <summary>
        /// 透明か
        /// </summary>
        [DataMember]
        public bool IsTransparent { get; set; } = false;

        /// <summary>
        /// 最前面か
        /// </summary>
        [DataMember]
        public bool IsTompost { get; set; } = true;

        /// <summary>
        /// ウィンドウサイズを画像に合わせる際の係数。0なら合わせない
        /// </summary>
        [DataMember]
        public float WindowFitScale { get; set; } = 0;

        /// <summary>
        /// スライドショー間隔 [s]
        /// </summary>
        [DataMember]
        public float SlideShowInterval{ get; set; } = 0;

        /// <summary>
        /// スライドショー間隔をゆらがせるか
        /// </summary>
        [DataMember]
        public bool HasIntervalFluctuation { get; set; } = false;

        /// <summary>
        /// ジャンプ頻度 何秒以内に1回程度か
        /// </summary>
        [DataMember]
        public float JumpFrequency { get; set; } = 0;

        /// <summary>
        /// ジャンプを有効にしていてもアニメーションGIFなら無効とする
        /// </summary>
        [DataMember]
        public bool IsJumpDisabledInAmination { get; set; } = true;

        /// <summary>
        /// 最後に開いたファイル
        /// </summary>
        [DataMember]
        public string RecentFile { get; set; } = "";


        /// 記録時のエンコーディング
        private static Encoding DataEncoding = Encoding.UTF8;


        /// <summary>
        /// 初期値に戻す
        /// </summary>
        public void Clear()
        {
            Clone(new Settings());
        }

        /// <summary>
        /// 指定ファイルから読み込み
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path)
        {
            Clone(LoadFile(path));
        }

        /// <summary>
        /// 指定ファイルに保存
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            SaveFile(path, this);
        }

        /// <summary>
        /// 引数の値をthisに複製
        /// </summary>
        /// <param name="src"></param>
        private void Clone(Settings src)
        {
            this.IsTompost = src.IsTompost;
            this.IsTransparent = src.IsTransparent;
            this.RecentFile = src.RecentFile;
            this.WindowFitScale = src.WindowFitScale;
            this.SlideShowInterval = src.SlideShowInterval;
            this.HasIntervalFluctuation = src.HasIntervalFluctuation;
            this.JumpFrequency = src.JumpFrequency;
            this.IsJumpDisabledInAmination = src.IsJumpDisabledInAmination;
        }


        /// <summary>
        /// 設定を指定ファイルから読み込み
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Settings LoadFile(string path)
        {
            if (!File.Exists(path))
            {
                return new Settings();
            }

            using (var reader = new StreamReader(path, DataEncoding))
            {
                using (var stream = new MemoryStream(DataEncoding.GetBytes(reader.ReadToEnd())))
                {
                    var json = new DataContractJsonSerializer(typeof(Settings));
                    return (Settings)json.ReadObject(stream);
                }
            }
        }

        /// <summary>
        /// 設定を指定ファイルに保存
        /// </summary>
        /// <param name="path"></param>
        /// <param name="settings"></param>
        public static void SaveFile(string path, Settings settings)
        {
            using (var stream = new MemoryStream())
            {
                var json = new DataContractJsonSerializer(typeof(Settings));
                json.WriteObject(stream, settings);

                using (var writer= new StreamWriter(path, false, DataEncoding))
                {
                    byte[] buff = stream.ToArray();
                    writer.WriteLine(DataEncoding.GetString(buff, 0, buff.Length));
                }
            }
        }
    }

}
