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
	public Button.ButtonClickedEvent AllGuard;
	public Button.ButtonClickedEvent AllyGuard;
	public Button.ButtonClickedEvent AllyGuardPlus;
	public Button.ButtonClickedEvent AnkleSnare;
	public Button.ButtonClickedEvent Assassinate;
	public Button.ButtonClickedEvent BattleGroundPreparation;
	public Button.ButtonClickedEvent BattleRatingDown;
	public Button.ButtonClickedEvent BattleRatingDown2;
	public Button.ButtonClickedEvent BattleStrategy;
	public Button.ButtonClickedEvent BowAttack;
	public Button.ButtonClickedEvent BowAttackMiko;
	public Button.ButtonClickedEvent BowAttackPlus;
	public Button.ButtonClickedEvent CannonAttack;
	public Button.ButtonClickedEvent CannonStrongAttack;
	public Button.ButtonClickedEvent CarefulAttack;
	public Button.ButtonClickedEvent Carry;
	public Button.ButtonClickedEvent Drop;
	
	void Awake() {
		instance = this;
	}
}
