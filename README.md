# **design_info_env**

## **動作の流れ**
1. 比較するオブジェクト(A, B)の選択
    - Aを選択。(Bも同様。)
    - オブジェクト一覧を表示する。
    - オブジェクトのプレビューを表示する
    - オブジェクトの情報を表示する
      - 高さ
      - 重さ
      - 面積
    - オブジェクトを決定する。
2. 比較画面へ移る
3. 高さ、面積を空間内に実寸大、又は実際の比率で表示する。
    - 重さは、「何個分か」で比較する。
    - 重さのパラメータを持っている場合、追加表示できる。
4. カメラ(Player)は、マウスの動きと連動する
    - スクリーンをドラッグした方向に進行する。

## 実装した機能
- オブジェクトのデータを持つクラスの定義
- オブジェクトの選択画面
  - データの表示
- マウスカーソル移動 -> 視点の移動
- NintendoSwitchのコントローラーによる視点の操作を実装
　- Android端末の設定画面からBluetooth接続を行う

## 扱うオブジェクト
|面積|高さ(cm)|重さ(g)|面積(㎡)|
|:---:|:---:|:---:|:---:|
|東京ドーム|6169|-|46755|
|東京タワー|33300|-|4470|
|東京スカイツリー|63400|-|31832|
|甲子園|-|-|38500|
|宮城県|-|-|7282240000|
|仙台市|-|-|786300000|
|宮城大学|-|-|35975|
|バチカン市国|-|-|440000|
|リンゴ|15|520|-|

## 作業備忘録
- ノーマルモードとVRモードの切り替え
    - マウスでの操作は難しいというかできない
    - まずはノーマルモードでモデルを選択して、モデルビューのときにVRモードへ切り替わる。
    - 参考 -> http://talesfromtherift.com/googlevr-cardboard-switch-between-normal-mode-and-vr-mode-at-run-time/
