using UnityEngine;

public abstract class PopupBase : MonoBehaviour
{
    public virtual void Open(PopupArg arg) {}

    public virtual void Close() {}
}

public abstract class PopupArg
{
    public abstract string Name { get; }
}
