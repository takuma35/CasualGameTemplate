using UnityEngine;
using System.Linq;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// サウンド管理クラス.
/// </summary>
public class SoundManager : SingletonMonobehaver<SoundManager> {

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

		// 設定画面にて設定したボリュームでSoundをスタート.
//		this.BgmMuteFlg.Value = PlayerPrefs.GetInt (MblPlayerPrefsConstants.BgmMuteFlg, 1) == 1;
//		this.SeMuteFlg.Value = PlayerPrefs.GetInt (MblPlayerPrefsConstants.SeMuteFlg, 1) == 1;

		// BGMのFlgが変更されたら音量を変更するSubscribe.
		//this.BgmMuteFlg.Subscribe (value => {
		//	bgmVolume.Value = value ? BgmMasterVolume : 0.0f;
		//});
		// BGMのFlgが変更されたら音量を変更するSubscribe.
		//this.SeMuteFlg.Subscribe (value => {
		//	seVolume.Value = value ? SeMasterVolume : 0.0f;
		//});

		// bgm音量のsubscribeを作成.
		this.bgmVolume.Where (_ => bgmAudioSource != null)
			.Subscribe (v => {
				bgmAudioSource.volume = v;
			});
		// se音量のsubscribeを作成.
		this.seVolume.Where (_ => seAudioSource != null)
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
		if (this.currentBgmDefine != null && type == this.currentBgmDefine.type) {
			return;
		}

		// すでにかかっていたら曲を止める.
		if (this.bgmAudioSource.isPlaying) {
			this.StopBgm ();
		}

		// typeから定義を取得.
		this.currentBgmDefine = this.bgmDefineList.bgmDefineList.FirstOrDefault (x => x.type == type);
        // クリップ取得.
        this.bgmAudioSource.clip = Resources.Load<AudioClip> (string.Format ("BGM/{0}", currentBgmDefine.clipName));
		// 定義の取得ができなかったら、ループ再生をしない.
		if (this.currentBgmDefine == null) {
			return;
		}
		// ループ時間を算出.
		this.loopTime = ((float)this.currentBgmDefine.loopSampleValue / (float)this.currentBgmDefine.samplingRate);
		this.endTime = ((float)this.currentBgmDefine.endSampleValue / (float)this.currentBgmDefine.samplingRate);

		// 再生中のBGMを監視し、ループ位置までいったらループする.
		this.bgmAudioSource.UpdateAsObservable ()
			.Where (_ => this.bgmAudioSource.isPlaying)
			.Subscribe (_ => {
				if (this.bgmAudioSource.time >= this.endTime) {
					this.bgmAudioSource.time = this.loopTime;
				}
			});

		// 再生.
		this.bgmAudioSource.Play ();
	}


	/// <summary>
	/// SE再生.
	/// </summary>
	/// <param name="type">Type.</param>
	public void Play (SeType.eSeType type) {
		// typeから定義を取得.
		SeDefineList.SeDefine se = this.seDefineList.seDefineList.FirstOrDefault (x => x.type == type);
		if (se == null) {
			Debug.LogError ("SEがありません");
			return;
		}
        // 連続再生できるように、OneShotを使用する.
        this.seAudioSource.PlayOneShot (Resources.Load<AudioClip> (string.Format ("SE/{0}", se.clipName)));
	}

	/// <summary>
	/// bgmの再生を完全に止める.
	/// </summary>
	public void StopBgm () {
		currentBgmDefine = null;
		this.bgmAudioSource.Stop ();
	}

	/// <summary>
	/// bgmの再生を一時停止させる.
	/// </summary>
	public void PauseBgm () {
		this.bgmAudioSource.Pause ();
	}

	/// <summary>
	/// bgmの一時停止を解除する.
	/// </summary>
	public void ResumeBgm () {
		this.bgmAudioSource.UnPause ();
	}

	/// <summary>
	/// Seの再生を完全に止める.
	/// </summary>
	public void StopSe () {
		this.seAudioSource.Stop ();
	}

	/// <summary>
	/// Seの再生中か.
	/// </summary>
	public bool IsPlayingSe () {
		return this.seAudioSource.isPlaying;
	}
}
