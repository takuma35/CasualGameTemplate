using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SEの定義.
/// </summary>
public class SeDefineList : ScriptableObject {

	public List<SeDefine> seDefineList = new List<SeDefine> ();

	[System.Serializable]
	public class SeDefine {
		/// <summary>楽曲Type.</summary>
		public SeType.eSeType type;
		/// <summary>定義のClip名.</summary>
		public string clipName;
	}
}

public class SeType {
	public enum eSeType {
        GAME_START,
        GAME_END,
        OK,
        NG,
        WIN,
        LOSE,
	}
}