using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPresenter : SceneBase
{
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnLeave()
    {
        base.OnLeave();
    }

    public void OnNextScene()
    {
        SceneCustomManager.Instance.ChangeScene(eScene.HomeScene);
    }
}
