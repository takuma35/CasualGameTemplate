using UnityEngine;
using UnityEngine.UI;

public class PopupManager : SingletonMonobehaver<PopupManager>
{
    [SerializeField]
    Transform popupParentTransform;

    [SerializeField]
    Image barrier;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        // barrier
        barrier.raycastTarget = false;
    }

    public void Open<T> (PopupBase popup, T arg) where T : class
    {
        // barrier
        barrier.raycastTarget = true;

        var popupName = string.Format("Popup/{0}", popup.Name);
        // object create
        var popupTransform = Instantiate(Resources.Load<Transform>(popupName), popupParentTransform);
        popupTransform.localPosition = new Vector3(0, 0, 0);

        // arg
        popup.Open<T>(arg);
    }

    public void Close(PopupBase popup)
    {
        popup.Close();
        Destroy(popup.gameObject);

        // barrier
        barrier.raycastTarget = false;
    }
}
