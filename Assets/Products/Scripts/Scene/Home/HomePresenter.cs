using UnityEngine;
using UniRx;

public class HomePresenter : SceneBase
{
    public override void OnEnter()
    {
        base.OnEnter();
        CommonModel.GameCoin.Subscribe(x =>
        {
            Debug.LogFormat("GameCoin:{0}", x);
        });
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
