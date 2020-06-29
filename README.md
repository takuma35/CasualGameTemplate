# CasualGameTemplate
カジュアルにゲーム作りたい時に利用するプロジェクト

個人的に面倒だなと思っていることをとりあえず用意したもの

コードの整理は今後行っていく


# 構成
## 初期シーン構成
・Launcher
・Title
・Home
・InGame
・Result

## 初期コンポーネント
・SceneCustomManager
・PopupManager
・SoundManager
・AdsManager

## テンプレート
・TemplateScene
・PopupTemplate

# 使い方
## シーン編([SceneCustomManager](./Assets/Products/Scripts/Utility/Scene/SceneCustomManager.cs))
### シーン遷移
SceneCustomManager の ChangeScene メソッドを呼び、引数に eScene をとる
例：タイトルシーンへの遷移コード
```
SceneCustomManager.Instance.ChangeScene(eScene.TitleScene);
```

### シーン追加
TemplateScene.unity をコピーしてリネームする
TemplateScene.cs をコピーしてリネームする
eScene に定義を追加
BuildSettings に eScene と同じ順番で追加する

### シーン説明
シーンに入る時に OnEnter が呼ばれる
シーンを出るときに OnLeave が呼ばれる

## ポップアップ編([PopupManager](./Assets/Products/Scripts/Utility/Popup/PopupManager.cs))
### ポップアップの開き方
PopupManager の Open メソッドを呼び、引数に 渡したい値(Arg class) をとる
例：homePopupの開き方
```
PopupManager.Instance.Open(new HomePopupPresenter.Arg());
```
[PopupBaseを継承したコードの例](./Assets/Products/Scripts/Scene/Home/HomePopupPresenter.cs)

### ポップアップの追加
PopupTemplate.prefab をコピーして、リネームする
PopupTemplate.cs をコピーしてリネームする

### ポップアップの説明
Arg に自由に渡せる値を記述できる

## サウンド編([SoundManager](./Assets/Products/Scripts/Utility/Sound/Scripts/SoundManager.cs))
### BGMの再生の仕方
例：ホームに設定したBGMを流す
```
SoundManager.Instance.Play(BgmType.eBgmType.HOME);
```
### BGMの登録の仕方
BgmDefineList.asset に Type と ClipName を入力する
Type に入れたいものがない場合は、[BgmDefineList.cs](./Assets/Products/Scripts/Utility/Sound/Scripts/BgmDefineList.cs) に追加する

### SEの再生の仕方
例：OKに設定したSEを流す
```
SoundManager.Instance.Play(SeType.eSeType.OK);
```

### SEの登録の仕方
SeDefineList.asset に Type と ClipName を入力する
Type に入れたいものがない場合は、[SeDefineList.cs](./Assets/Products/Scripts/Utility/Sound/Scripts/SeDefineList.cs) に追加する

### Clipの配置場所
`Resources/BGM/`
`Resources/SE/`

# Libraries
UniRx : https://github.com/neuecc/UniRx
