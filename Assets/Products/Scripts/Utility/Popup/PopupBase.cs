using UnityEngine;

public abstract class PopupBase : MonoBehaviour
{
    public abstract string Name { get; }

    public virtual void Open(Argument arg) {}

    public virtual void Close() {}
}

public abstract class Argument { }
