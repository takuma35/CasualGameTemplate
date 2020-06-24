using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HomePopupPresenter : PopupBase
{
    public class Arg : PopupArg
    {
        // argument property.
        public override string Name => "HomePopup";

        public UnityAction OnCancelButtonAction;

        public UnityAction OnOkButtonAction;

        public Arg() { }
    }

    Arg argument;

    public override void Open(PopupArg arg)
    {
        base.Open(arg);
        // キャストしてから使う
        argument = arg as Arg;
        argument.OnCancelButtonAction();
    }

    public override void Close()
    {
        base.Close();
    }

    public void OnCancelButton()
    {
        // cancel
        PopupManager.Instance.Close(this);
    }

    public void OnOkButton()
    {
        // ok
        PopupManager.Instance.Close(this);
    }

    public void OnAdsMovieButton()
    {
        // ex
        AdsManager.Instance.ShowRewardedAd(
            GainGameCoin,
            GainGameCoin,
            GainGameCoin
        );
    }

    public void GainGameCoin()
    {
        CommonModel.GameCoin.Value++;
    }
}
