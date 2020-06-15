using UnityEngine;

/// <summary>
/// シーン抽象Class
/// </summary>
public abstract class SceneBase : MonoBehaviour {

    /// <summary>
    /// Awake this instance.
    /// </summary>
    protected void Awake () {
        SceneCustomManager.Instance.SetSceneBase (this);
    }

    /// <summary>
    /// シーンに入った時に呼ばれる関数
    /// </summary>
    public virtual void OnEnter () {
        
    }

    /// <summary>
    /// シーンを離れる時に呼ばれる関数
    /// </summary>
    public virtual void OnLeave () {

    }
}
