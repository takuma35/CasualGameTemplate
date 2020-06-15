public class TitlePresenter : SceneBase
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
