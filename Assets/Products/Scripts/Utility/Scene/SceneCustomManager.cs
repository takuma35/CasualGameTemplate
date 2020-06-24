using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// 案件用シーンマネージャー.
/// </summary>
public class SceneCustomManager : SingletonMonoBehaviour<SceneCustomManager> {

    /// <summary>
    /// タッチ防御用.
    /// </summary>
    [SerializeField]
    private Image barriorImage;

    /// <summary>
    /// The scene base.
    /// </summary>
    private SceneBase sceneBase;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    protected override void Awake () {
        base.Awake ();
        DontDestroyOnLoad (this);
        SceneManager.activeSceneChanged += OnEnter;
    }

    /// <summary>
    /// シーン変更
    /// </summary>
    /// <param name="scene">Scene.</param>
    public void ChangeScene (eScene scene) {
        ShowBarrior (true);

        if(sceneBase != null) {
            // ステートを出る時に行う処理を投げる.
            OnLeave ();
        }

        SceneManager.LoadScene ((int)scene);
    }

    /// <summary>
    /// シーン入る時に呼ばれる
    /// </summary>
    /// <param name="prevScene">Previous scene.</param>
    /// <param name="nextScene">Next scene.</param>
    private void OnEnter (Scene prevScene, Scene nextScene) {
        if(sceneBase != null) {
            sceneBase.OnEnter ();
        }

        ShowBarrior (false);
    }

    /// <summary>
    /// シーンを離れる時に呼ばれる
    /// </summary>
    private void OnLeave () {
        sceneBase.OnLeave ();
    }

    /// <summary>
    /// バリアを効かせる
    /// </summary>
    /// <param name="flag">If set to <c>true</c> flag.</param>
    public void ShowBarrior (bool flag) {
        barriorImage.raycastTarget = flag;
    }

    /// <summary>
    /// Sets the scene base.
    /// </summary>
    /// <param name="_sceneBase">Scene base.</param>
    public void SetSceneBase (SceneBase _sceneBase) {
        sceneBase = _sceneBase;
    }
}
