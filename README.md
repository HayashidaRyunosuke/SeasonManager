# 使い方
現在の季節の取得
1. SeasonManagerをアタッチしたオブジェクトを1つシーン内に設置する  
2. SeasonManager.Instance.CURRENT_SEASONから現在の季節を取得する
季節のシュミレート
1. SeasonManagerのインスペクターのIsSimulateSeasonをチェック
2. 月日を入力できるのでシュミレートしたい日付を入力
季節の変わり目の設定
1. SeasonManagerのインスペクターのSetSeasonStartをチェック
2. それぞれの季節に月日を入力できるようになるので月日を入力する

# 備考
使用する際は、「Packages/manifest.json」ファイルに以下の内容を追記してください。
>"com.rinryu.season": "https://github.com/HayashidaRyunosuke/SeasonManager.git",
