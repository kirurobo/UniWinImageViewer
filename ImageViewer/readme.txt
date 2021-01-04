# ぴょんぴょん画像ビューア

ウィンドウを透過して表示できる画像ビューアです。
ついでにぴょんぴょん動かす機能があります。



## 動作環境
- Windows 10
- .NET Framework 4.7.2
  - Windows 10 の更新ができていればおそらく対応しています

## インストール
- 圧縮されたファイルを適当なフォルダに展開してください。
- レジストリは使用しません。
  - 設定は同じフォルダに config.json として保存されます。
  - config.json だけ削除すると設定をリセットできます。


## アンインストール
- 展開したフォルダごと削除してください。



## 操作方法

### 起動
展開したフォルダの PyonPyonImageViewer を開いてください。

### メニュー
- 操作は右クリックのメニュー（コンテキストメニュー）から行います。

### 画像の開き方
- メニューの「ファイルを開く」か、ファイルやフォルダをドロップしてください。
- 複数ファイルやフォルダをドロップした場合、スライドショーとして
  一定時間で順番に切り替えたり、カーソルキー左右か[Space][BS]で切り替えできます。
  - （フォルダ内のさらにサブフォルダは検索しません。）

### ウィンドウ透過について
- （PC環境があっていれば）ウィンドウ枠を透過できます。
-  [Shift] キーを押している間は一時的に透過は無効となりサイズ調整などできます。

### ウィンドウを見失ったとき
- タスクバーから本アプリをアクティブにして [Ctrl]+[.] を押すと画面左下付近に移動します。
- あるいは [Ctrl]+[I] で透過をON/OFFできます。
- それでもだめならタスクバーのアイコンを右クリックして閉じてください。


## 開発者
@Kirurobo(https://twitter.com/kirurobo)


## 更新履歴
- 2021/01/04 v1.2.2	画面からはみ出した部分が再描画されるよう、移動時には再描画するようにした
- 2021/01/04 v1.2.1	画像に合わせたサイズ調整時、ウィンドウ左上位置を維持するようにした
- 2020/11/18 v1.2.0	設定変更時にすぐ保存するようにした。
- 2020/11/18 v1.1.1	最初にアニメーションGIFを開くと重いことに対応。
- 2020/11/13 v1.1.0	マウスホイールでの拡大縮小を追加。ESCで終了するようにした。


## ライセンス
MITライセンスに基づき、再配布や改造可能です。

----------------------------------------------------------------------------
MIT License

Copyright (c) 2020 Kirurobo

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

----------------------------------------------------------------------------
