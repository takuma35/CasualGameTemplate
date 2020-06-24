using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HomePopupPresenter : PopupBase
{
    // data
    public override string Name => "HomePopup";

    public class Arg : Argument
    {
        // argument property.

        public UnityAction OnCancelButtonAction;

        public UnityAction OnOkButtonAction;

        public Arg() { }
    }

    Arg argument;

    public override void Open(Argument arg)
    {
        base.Open(arg);
        // キャストしてから使う
        argument = (Arg)arg;
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
