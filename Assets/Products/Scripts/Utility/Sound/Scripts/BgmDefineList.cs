using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// イントロ付きBGMの定義Class.
/// </summary>
public class BgmDefineList : ScriptableObject {

	public List<BgmDefine> bgmDefineList = new List<BgmDefine> ();

	[System.Serializable]
	public class BgmDefine {
		/// <summary>楽曲Type.</summary>
		public BgmType.eBgmType type;
		/// <summary>定義のClip名.</summary>
		public string clipName;
		/// <summary>サンプリングレート.</summary>
		public int samplingRate;
		/// <summary>ループ開始位置.</summary>
		public int loopSampleValue;
		/// <summary>BGM終了位置.</summary>
		public int endSampleValue;
	}
}

public class BgmType {
	public enum eBgmType {
        TITLE,
        HOME,
        INGAME,
        RESULT,
	}
}
