using System;
using UnityEngine;
#if PROD
using UnityEngine.Advertisements;
#endif

/// <summary>
/// Ads管理マネージャー
/// </summary>
public class AdsManager : SingletonMonobehaver<AdsManager> {

    [SerializeField]
    private string appleId = "";
    [SerializeField]
    private string googleId = "";

    // 動画広告の各Action.
    private Action finishAction = null;
    private Action skipAction = null;
    private Action failedAction = null;

    /// <summary>
    /// 広告呼び出し
    /// </summary>
    /// <param name="_finishAction">Finish action.</param>
    /// <param name="_skipAction">Skip action.</param>
    /// <param name="_failedAction">Failed action.</param>
    public void ShowRewardedAd (Action _finishAction = null, Action _skipAction = null, Action _failedAction = null) {
#if PROD
        if(Advertisement.IsReady ("video")) {
            // 各Actionを詰める
            finishAction = _finishAction;
            skipAction = _skipAction;
            failedAction = _failedAction;

            // 広告動画を呼び出す
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show ("video", options);
        }
#else
        // 各Actionを詰める
        finishAction = _finishAction;
        skipAction = _skipAction;
        failedAction = _failedAction;
        HandleShowResult();
#endif
    }

#if PROD
    /// <summary>
    /// 広告結果イベント
    /// </summary>
    /// <param name="result">Result.</param>
    private void HandleShowResult (ShowResult result) {
        switch(result) {
            // 最後まで終了
            case ShowResult.Finished:
                Debug.Log ("The ad was successfully shown.");
                if (finishAction != null)
                {
                    finishAction();
                    finishAction = null;
                }
                break;
            // 途中スキップ
            case ShowResult.Skipped:
                Debug.Log ("The ad was skipped before reaching the end.");
                if (skipAction != null)
                {
                    skipAction();
                    skipAction = null;
                }
                break;
            // 表示失敗
            case ShowResult.Failed:
                Debug.LogError ("The ad failed to be shown.");
                if (failedAction != null)
                {
                    failedAction();
                    failedAction = null;
                }
                break;
        }
    }
#else
    /// <summary>
    /// 広告結果イベントDev(finished only)
    /// </summary>
    private void HandleShowResult()
    {
        if (finishAction != null)
        {
            finishAction();
            finishAction = null;
        }
    }
#endif
}
