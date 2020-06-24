using UnityEngine;
using System.Linq;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// サウンド管理クラス.
/// </summary>
public class SoundManager : SingletonMonoBehaviour<SoundManager> {

	/// <summary>BGM音量の規定値..</summary>
	public const float BgmMasterVolume = 1.0f;
	/// <summary>SE音量の規定値.</summary>
	public const float SeMasterVolume = 1.0f;

	/// <summary>BGM用のaudioSource.</summary>
	[SerializeField]
	private AudioSource bgmAudioSource;
	/// <summary>SE用のaudioSource.</summary>
	[SerializeField]
	private AudioSource seAudioSource;
	/// <summary>BGM定義リスト.</summary>
	[SerializeField]
	private BgmDefineList bgmDefineList;
	/// <summary>SE定義リスト.</summary>
	[SerializeField]
	private SeDefineList seDefineList;

	/// <summary>現在のBGM定義.</summary>
	private BgmDefineList.BgmDefine currentBgmDefine;

	/// <summary>bgmのON,OFFフラグ.</summary>
	public BoolReactiveProperty BgmMuteFlg= new BoolReactiveProperty();
	/// <summary>SeのON,OFFフラグ.</summary>
	public BoolReactiveProperty SeMuteFlg= new BoolReactiveProperty();

	/// <summary>bgmの音量.</summary>
	public FloatReactiveProperty bgmVolume = new FloatReactiveProperty ();
	/// <summary>seの音量.</summary>
	public FloatReactiveProperty seVolume = new FloatReactiveProperty ();

	/// <summary>ループ開始時間.</summary>
	private float loopTime;
	/// <summary>ループ終了時間.</summary>
	private float endTime;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    protected override void Awake () {
        base.Awake ();
        DontDestroyOnLoad (this);
    }

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start () {
		// bgm音量のsubscribeを作成.
		bgmVolume.Where (_ => bgmAudioSource != null)
			.Subscribe (v => {
				bgmAudioSource.volume = v;
			});
		// se音量のsubscribeを作成.
		seVolume.Where (_ => seAudioSource != null)
			.Subscribe (v => {
				seAudioSource.volume = v;
			});
	}

	/// <summary>
	/// BGM再生.
	/// </summary>
	/// <param name="type">Type.</param>
	public void Play (BgmType.eBgmType type) {
		// 同じ曲を再生しようとしていたら、何もしない.
		if (currentBgmDefine != null && type == currentBgmDefine.type) {
			return;
		}

		// すでにかかっていたら曲を止める.
		if (bgmAudioSource.isPlaying) {
			StopBgm ();
		}

		// typeから定義を取得.
		currentBgmDefine = bgmDefineList.bgmDefineList.FirstOrDefault (x => x.type == type);
        // クリップ取得.
        bgmAudioSource.clip = Resources.Load<AudioClip> (string.Format ("BGM/{0}", currentBgmDefine.clipName));
		// 定義の取得ができなかったら、ループ再生をしない.
		if (currentBgmDefine == null) {
			return;
		}
        // ループ時間を算出.
        loopTime = currentBgmDefine.loopSampleValue / currentBgmDefine.samplingRate;
        endTime = currentBgmDefine.endSampleValue / currentBgmDefine.samplingRate;

		// 再生中のBGMを監視し、ループ位置までいったらループする.
		bgmAudioSource.UpdateAsObservable ()
			.Where (_ => bgmAudioSource.isPlaying)
			.Subscribe (_ => {
				if (bgmAudioSource.time >= endTime) {
					bgmAudioSource.time = loopTime;
				}
			});

		// 再生.
		bgmAudioSource.Play ();
	}


	/// <summary>
	/// SE再生.
	/// </summary>
	/// <param name="type">Type.</param>
	public void Play (SeType.eSeType type) {
		// typeから定義を取得.
		SeDefineList.SeDefine se = seDefineList.seDefineList.FirstOrDefault (x => x.type == type);
		if (se == null) {
			Debug.LogError ("SEがありません");
			return;
		}
        // 連続再生できるように、OneShotを使用する.
        seAudioSource.PlayOneShot (Resources.Load<AudioClip> (string.Format ("SE/{0}", se.clipName)));
	}

	/// <summary>
	/// bgmの再生を完全に止める.
	/// </summary>
	public void StopBgm () {
		currentBgmDefine = null;
		bgmAudioSource.Stop ();
	}

	/// <summary>
	/// bgmの再生を一時停止させる.
	/// </summary>
	public void PauseBgm () {
		bgmAudioSource.Pause ();
	}

	/// <summary>
	/// bgmの一時停止を解除する.
	/// </summary>
	public void ResumeBgm () {
		bgmAudioSource.UnPause ();
	}

	/// <summary>
	/// Seの再生を完全に止める.
	/// </summary>
	public void StopSe () {
		seAudioSource.Stop ();
	}

	/// <summary>
	/// Seの再生中か.
	/// </summary>
	public bool IsPlayingSe () {
		return seAudioSource.isPlaying;
	}
}
