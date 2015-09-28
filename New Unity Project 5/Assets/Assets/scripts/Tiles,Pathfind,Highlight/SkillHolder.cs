using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillHolder : MonoBehaviour {
	public static SkillHolder instance;

	public Button.ButtonClickedEvent AccurateShots;
	public Button.ButtonClickedEvent AdvanceTime;
	public Button.ButtonClickedEvent AdvanceTime2;
	public Button.ButtonClickedEvent AimAndShoot;


	void Awake() {
		instance = this;
	}
}
