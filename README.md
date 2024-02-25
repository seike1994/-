作成者用のJRA自動投票ソフトです。
JvDataを取得するための構造体コード、Pythonファイル、Javaファイルが必要であり、公開しているコードのみでは動作することができません。
主な仕様につきましては、お送りしましたポートフォリオPDFと併せてご確認くださいませ。

コード説明
・Class_DB_ModelUpdate
データベースのデータ成形、前処理、モデル構築を行います。

・Class_IPAT
IPAT投票、入出金管理を行います。

・Class_Jv_Link
JV-Linkを介して競馬データを取得します。

・Class_LogForm
システムイベントのログを表示します。

・Class_MainForm
トップ画面です。
自動運転の開始や他ページへの遷移をします。

・Class_ModelCheck
単体レースの勝率予測を行います。
モデルの動作チェックの役目をしています。

・Class_TohyoSetting
投票設定画面です。
馬券種やSNS連携等、自動運転中の設定を行います。

・Class_TotalResult
投票結果、収支表を表示します。

・Class_UserSetting
ユーザー設定を行います。
必要なデータベース設定やSNSのトークン入力を行います。

・Mj_ChangeKaisaiCode
競馬場のコードや投票コード等への変換関数をまとめています。

・Mj_DgvArrangement
複数あるDataGridViewのデータ管理を行います。

・Mj_ExecuteLogic
ロジックに沿った投票の実施を行います。

・Mj_PublicVariables
フォーム間の変数共有をします。ユーザーが設定した内容を保存します。

・Mj_PythonModule
Pythonファイルの実行を行います。

・Mj_Result
投票結果の出力を行います。

・Mj_SNS
SNS連携(XやBookers等)を行います。

・Mj_SelectRaces.vb
自動運転中のレース判別、設定した時間にロジックを実行します。

・Mj_SettingTimers
自動運転の開始、停止のタイマー設定です。
