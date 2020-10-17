using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UniWinImageViewer.UniWinCSharp;

namespace UniWinImageViewer
{
    /// <summary>
    /// ウィンドウの動きをコントロールするクラス
    /// </summary>
    class JumpController
    {
        UniWinCSharp uniwin;

        Stopwatch stopwatch = new Stopwatch();
        Random random = new Random();

        bool isActive = false;
        bool isMoving = false;

        /// <summary>
        /// 動作開始時点の時刻 [ms]
        /// </summary>
        long startedMilliSeconds = 0;

        /// <summary>
        /// 次の運動予定時刻 [ms]
        /// </summary>
        long nextJumpMilliSeconds = 0;

        /// <summary>
        /// 次のジャンプまでの最低待ち秒数
        /// </summary>
        public int minWait = 1000;

        /// <summary>
        /// 次のジャンプまでの最大待ち秒数
        /// </summary>
        public int maxWait = 10000;

        /// <summary>
        /// 重力加速度 [m/s^2]
        /// </summary>
        public double standardGravity = 9.80665;

        /// <summary>
        /// 何 [px] で 1 [m] に相当するかを決める係数 [px/m]
        /// </summary>
        public double pixelPerMeter = 500.0;

        Vector2 initialPosition;

        /// <summary>
        /// ジャンプ高さ [px]
        /// </summary>
        double height = 0.0;

        /// <summary>
        /// ジャンプ開始から終了までにかかる時間 [s]
        /// </summary>
        double duration = 0.0;

        /// <summary>
        /// 現在移動中なら true
        /// </summary>
        public bool IsMoving { get { return isMoving; } }

        /// <summary>
        /// アニメーションGIFで動きを抑制する場合、trueとする
        /// </summary>
        public bool IsSuppressed = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="uniwin">関連付けるUniWinCSharp</param>
        public JumpController(UniWinCSharp uniwin)
        {
            this.uniwin = uniwin;

            stopwatch.Start();
        }

        /// <summary>
        /// 開始時に呼ぶ処理
        /// </summary>
        public void Start()
        {
            isActive = true;
            isMoving = false;

            // 次回のジャンプを予定
            nextJumpMilliSeconds = stopwatch.ElapsedMilliseconds + random.Next(minWait, maxWait);
        }

        /// <summary>
        /// 毎フレームの更新処理
        /// </summary>
        public void Update()
        {
            if (!isActive) return;

            // ジャンプ中または抑制中でなければ、ランダムでジャンプ開始
            if (!isMoving && !IsSuppressed)
            {
                var ms = stopwatch.ElapsedMilliseconds;
                if (nextJumpMilliSeconds <= ms)
                {
                    // 次回のジャンプを予定
                    nextJumpMilliSeconds = ms + random.Next(minWait, maxWait);

                    // ジャンプ開始
                    var size = uniwin.GetWindowSize();
                    height = size.y * 0.1;              // ジャンプ高さを設定
                    pixelPerMeter = size.y * 1.0;

                    BeginJumping();
                }
            }

            UpdateJumping();
        }

        /// <summary>
        /// 動きを終了したいときに呼ぶ処理
        /// </summary>
        public void Stop()
        {
            // ジャンプ中なら停止
            EndJumping();

            isActive = false;
        }


        void BeginJumping()
        {
            isMoving = true;
            initialPosition = uniwin.GetWindowPosition();

            startedMilliSeconds = stopwatch.ElapsedMilliseconds;

            // H = height[px]/pixelPerMeter[px/m]
            // T = duration[s] として
            // H == 1/2 * g * (T/2)^2 となるため
            // T = sqrt( 8H / g )
            duration = Math.Sqrt((height / pixelPerMeter) * 8.0 / standardGravity);
        }

        void EndJumping()
        {
            isMoving = false;
        }

        void UpdateJumping()
        {
            // ジャンプ中でなければ何もしない
            if (!isMoving) return;

            // 終了時間以降ならばジャンプ終了とする
            double now = (stopwatch.ElapsedMilliseconds - startedMilliSeconds) / 1000.0;
            if (now >= duration)
            {
                uniwin.SetWindowPosition(initialPosition);
                EndJumping();

                if (random.Next(5) == 0)
                {
                    // 0.2 程度の確率で、ジャンプ後に反動っぽい小ジャンプ
                    height *= 0.5;
                    BeginJumping();
                }
                return;
            }

            // 頂点が t == 0 となるようにした経過時間 [s]
            double t = now - duration / 2.0;

            // 高さ[m]は y = H -1/2 * g * t^2
            double y = height - ((0.5 * standardGravity * t * t) * pixelPerMeter);

            Vector2 pos = initialPosition;
            pos.y += (float)y;
            uniwin.SetWindowPosition(pos);
        }
    }
}
