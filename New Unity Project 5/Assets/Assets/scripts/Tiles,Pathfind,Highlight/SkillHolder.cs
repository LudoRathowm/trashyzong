using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillHolder : MonoBehaviour {
	public static SkillHolder instance;

	public Button.ButtonClickedEvent AccurateShots;
	public Button.ButtonClickedEvent AdvanceTime;
//	public Button.ButtonClickedEvent AdvanceTime2;
//	Charge,
//	WarriorAttack,
//	WarriorAttack2,
//	GuardBreak,
//	ShoutingCharge,
//	SideAttack,
//	CarefulAttack, //cant counter
//	QuickAttack, //low recovery time
//	LightAttack,
//	FullPowerCharge,
//	FullPowerCharge2,
//	GambleCharge,
//	GambleChargeLove,
//	//FOOT SOLDIER
//	AllyGuard,
//	AllyGuardPlus,
//	AllGuard,
//	Phalanx,
//	FootSoldierAttack,
//	FootSoldierAttack2,
//	StrongFootAttack,
//	StrongFootAttack2,
//	Loot,
//	FellowTroopsRevenge,
//	//MUSKETEER
//	Bait,
//	Shoot,
//	AimAndShoot,
//	PenetrationShoot,
//	PenetrationShoot2,
//	//MONK
//	TenshiDivineTrash,
//	TenshiDivineTrash2,
//	Meditate,
//	Meditate2, 
//	ConvertAction,
//	ConvertAction2,
//	MonkCharge,
//	MonkChargePlus,
//	GuardCancel,
//	Overtime,
//	Overtime2,
//	Depoison,
//	//KNIGHT
//	KnightAttack,
//	KnightAttack2,
//	KnightCharge,
//	CleanUp,
//	Maim,
//	//ARCHER
//	BowAttack,
//	BowAttackPlus,
//	SweepingFire,
//	StrongBowAttack,
//	Volley,
//	Sharpshoot,
//	//NINJA
//	BattlegroundPreparation,
//	AnkleSnare,
//	Poison, //no damage but kills an unit of energy == 0;
//	HalveEnergy,
//	Shuriken,
//	Shuriken2,
//	ChinkChinkShuriken,
//	SonicShuriken,
//	Assassinate, //hp and energy based all energy
//	//CAVALRY
//	Carry,
//	CounterRange,
//	MuhFlags, //battle rating up
//	MuhFlags2,
//	CavalryCharge,
//	CavalryCharge2,
//	OnRush,
//	RearGuardCharge,
//	FollowThrough,
//	//CANNON
//	CannonNormalAttack,
//	CannonStrongAttack,
//	//TACTICIAN
//	BattleStrategy,
//	BattleStrategy2,
//	BattleStrategy3,
//	CrossbowAttack,
//	CrossbowAttackPlus,
//	RemoveBuffs,
//	RemoveBuffsAround,
//	RemoveBuffsRanged,
//	AdvanceTime,
//	AdvanceTime2,
//	BattleRatingDown,
//	BattleRatingDown2,
//	AccurateShots,
//	//DIVINIER
//	MagicGuard,
//	MagicGuardAround,
//	SummonTrash,
//	Shikigami,
//	Shikigami2,
//	Lightning,
//	//MIKO
//	MikoDance,
//	MikoDancePlus,
//	HealingMist,
//	MikoDanceQuick,
//	BowAttackMiko,
//	MikoStorm,
//	MikoStorm2,
//	//MAGE
//	FrostDiver,
//	FireBlast,
//	Icewall,
//	StormGust,
//


	void Awake() {
		instance = this;
	}
}
