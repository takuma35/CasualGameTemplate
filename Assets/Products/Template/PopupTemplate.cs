using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// popupテンプレートそのままコピって名前を変えると吉
/// </summary>
public class PopupTemplate : PopupBase
{
    // data
    public class Arg : PopupArg
    {
        // argument property.
        public override string Name => "PopupTemplate";

        public UnityAction OnCancelButtonAction;

        public UnityAction OnOkButtonAction;

        public Arg() { }
    }

    public override void Open(PopupArg arg)
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
