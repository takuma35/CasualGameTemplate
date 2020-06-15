using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonMonobehaver<T> : MonoBehaviour where T :MonoBehaviour {

    private static T instance;
    public static T Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<T>();
                if (instance == null) {
                    Debug.LogError("アタッチしているGameObjectはありません");
                }
            }

            return instance;
        }
    }

    protected virtual void Awake () {
        if (this != Instance) {
            Destroy(this.gameObject);
            return;
        }
    }
}
