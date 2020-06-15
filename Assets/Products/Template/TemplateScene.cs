using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// シーン追加の際には、eSceneに追加とBuildSettingsに追加する
/// eSceneとBuildSettingsの順番は同じにする
/// </summary>
public class TemplateScene : SceneBase
{
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnLeave()
    {
        base.OnLeave();
    }
}
