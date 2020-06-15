using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// popupテンプレートそのままコピって名前を変えると吉
/// </summary>
public class PopupTemplate : PopupBase
{
    // data
    public override string Name => "PopupTemplate";

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
}
