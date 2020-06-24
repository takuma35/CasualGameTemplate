using UnityEngine;
using UnityEngine.UI;

public class PopupManager : SingletonMonoBehaviour<PopupManager>
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

    public void Open (PopupArg arg)
    {
        // barrier
        barrier.raycastTarget = true;

        var popupName = string.Format("Popup/{0}", arg.Name);
        // object create
        var popupGameObject = Instantiate(Resources.Load<GameObject>(popupName), popupParentTransform);
        popupGameObject.transform.localPosition = new Vector3(0, 0, 0);

        var popup = popupGameObject.GetComponent<PopupBase>();
        popup.Open(arg);
    }

    public void Close(PopupBase popup)
    {
        popup.Close();
        Destroy(popup.gameObject);

        // barrier
        barrier.raycastTarget = false;
    }
}
