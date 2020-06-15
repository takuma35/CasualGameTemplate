﻿public class HomePresenter : SceneBase
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
        SceneCustomManager.Instance.ChangeScene(eScene.InGameScene);
    }

    public void OnOpenPopup()
    {
        PopupManager.Instance.Open(new HomePopupPresenter(), new HomePopupPresenter.Arg());
    }
}
