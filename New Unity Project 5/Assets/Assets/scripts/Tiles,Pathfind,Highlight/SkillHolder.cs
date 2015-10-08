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
	public Button.ButtonClickedEvent CavalryCharge;
	public Button.ButtonClickedEvent CavalryCharge2;
	public Button.ButtonClickedEvent ChinkChinkShuriken;
	public Button.ButtonClickedEvent CleanUp;
	public Button.ButtonClickedEvent ConvertAction;
	public Button.ButtonClickedEvent ConvertAction2;
	public Button.ButtonClickedEvent CrossbowAttack;
	public Button.ButtonClickedEvent CrossbowAttackPlus;
	public Button.ButtonClickedEvent Depoison;
	public Button.ButtonClickedEvent FellowTroopRevenge;
	public Button.ButtonClickedEvent FireBlast;
	public Button.ButtonClickedEvent FollowThrough;
	public Button.ButtonClickedEvent FootSoldierAttack;
	public Button.ButtonClickedEvent FootSoldierAttack2;
	public Button.ButtonClickedEvent FrostDiver;
	public Button.ButtonClickedEvent FullPowerCharge;
	public Button.ButtonClickedEvent FullPowerCharge2;
	public Button.ButtonClickedEvent GuardBreak;
	public Button.ButtonClickedEvent GuardCancel;
	public Button.ButtonClickedEvent HalveEnergy;
	public Button.ButtonClickedEvent HealingMist;
	public Button.ButtonClickedEvent IceWall;
	public Button.ButtonClickedEvent KnightAttack;
	public Button.ButtonClickedEvent KnightAttack2;
	public Button.ButtonClickedEvent KnightCharge;
	public Button.ButtonClickedEvent LightAttack;
	public Button.ButtonClickedEvent Lightning;
	void Awake() {
		instance = this;
	}
}
