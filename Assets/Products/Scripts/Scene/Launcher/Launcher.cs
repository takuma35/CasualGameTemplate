using System;
using UnityEngine;
using UniRx;

public class Launcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Initialize();

        Observable.Timer(TimeSpan.FromSeconds(1)).Subscribe(_ =>
        {
            SceneCustomManager.Instance.ChangeScene(eScene.TitleScene);
        }).AddTo(this);
    }

    void Initialize()
    {
        // game initialize
    }
}
