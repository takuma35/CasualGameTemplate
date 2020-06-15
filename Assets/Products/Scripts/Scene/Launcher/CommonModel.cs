using UniRx;
using UnityEngine;

public static class CommonModel
{
    // gamecoin
    public static IntReactiveProperty GameCoin;

    static CommonModel()
    {
        GameCoin = new IntReactiveProperty(PlayerPrefs.GetInt("gamecoin")); 
    }

    public static void SaveGameCoin()
    {
        PlayerPrefs.SetInt("gamecoin", GameCoin.Value);
        PlayerPrefs.Save();
    }
}
