using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HomePopupPresenter : PopupBase
{
    // data
    public override string Name => "HomePopup";

    public class Arg
    {
        // argument property.

        public UnityAction OnCancelButtonAction;

        public UnityAction OnOkButtonAction;

        public Arg() { }
    }

    public override void Open<Arg>(Arg arg)
    {
        base.Open(arg);
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
