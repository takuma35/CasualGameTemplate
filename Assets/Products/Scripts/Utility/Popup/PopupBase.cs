using UnityEngine;

public abstract class PopupBase : MonoBehaviour
{
    public abstract string Name { get; }

    public virtual void Open<T>(T arg) where T : class {}

    public virtual void Close() {}
}
