# EasyObjectController

## インストール方法
1. Unityのパッケージマネージャーを開きます。  
2. ステータスバーの✙ボタンをクリックします。  
3. パッケージを加えるためのオプションが表示されます。  
4. ドロップダウンから「Add package from git URL」を選択します。  
5. テキストフィールドに以下のURLを入力して、Addをクリックします。  
`https://github.com/HayashidaRyunosuke/EasyObjectController.git`  
  
## 使い方
1. Easy〇〇Controller.csを使用したいオブジェクトへアタッチします。  
2. インスペクターで開始時の値と終了時の値を指定します。
3. スクリプト内の`Play()`メソッドを叩くか`SetProgress()`メソッドで`progress`の値を指定することで動作します。  
(Edit中でもインスペクターからProgressバーをスライドさせることでテストが可能です)

## ProgressController.cs
Easy〇〇Controller.csらはProgressController.csを継承して作られています  
### ProgressController.csの機能
フィールド  
`float progress` => 現在の進捗度  
`float playDuration` => `Play()`メソッドを叩いた際に`progress`の値が0から1まで変化するまでの時間  
`float playDelay` => `Play()`メソッドを叩いてから実行するまでの遅延時間  
`bool playOnAwake` => `true`の場合`Awake()`のタイミングで実行される  
`bool isPlaying` => `Play()`メソッドが実行中か  
`UnityEvent onPlayBegun` => `Play()`メソッドが実行された時のイベントハンドラ  
`UnityEvent onPlayEnded` => `Play()`メソッドが終了した時のイベントハンドラ  
  
メソッド  
`Init()` => 初期化処理、progressの値が0になる  
`Play()` => 実行すると`progress`の値が0から1まで指定した時間で変化する  
`Reverse()` => 実行すると`progress`の値が1から0まで指定した時間で変化する   
`UpdateProgress()` => `progress`の値が変化したときに実行される、主に継承先で使用する
