using UnityEngine;
using System.Collections;



public enum muhSkills{
	//WARRIOR
	Charge,
	WarriorAttack,
	WarriorAttack2,
	GuardBreak,
	ShoutingCharge,
	SideAttack,
	CarefulAttack, //cant counter
	QuickAttack, //low recovery time
	LightAttack,
	FullPowerCharge,
	FullPowerCharge2,
	GambleCharge,
	GambleChargeLove,
	//FOOT SOLDIER
	AllyGuard,
	AllyGuardPlus,
	AllGuard,
	Phalanx,
	FootSoldierAttack,
	FootSoldierAttack2,
	StrongFootAttack,
	StrongFootAttack2,
	Loot,
	FellowTroopsRevenge,
	//MUSKETEER
	Bait,
	Shoot,
	AimAndShoot,
	PenetrationShoot,
	PenetrationShoot2,
	//MONK
	TenshiDivineTrash,
	TenshiDivineTrash2,
	Meditate,
	Meditate2, 
	ConvertAction,
	ConvertAction2,
	MonkCharge,
	MonkChargePlus,
	GuardCancel,
	Overtime,
	Overtime2,
	Depoison,
	//KNIGHT
	KnightAttack,
	KnightAttack2,
	KnightCharge,
	CleanUp,
	Maim,
	//ARCHER
	BowAttack,
	BowAttackPlus,
	SweepingFire,
	StrongBowAttack,
	Volley,
	Sharpshoot,
	//NINJA
	BattlegroundPreparation,
	AnkleSnare,
	Poison, //no damage but kills an unit of energy == 0;
	HalveEnergy,
	Shuriken,
	Shuriken2,
	ChinkChinkShuriken,
	SonicShuriken,
	Assassinate, //hp and energy based all energy
	//CAVALRY
	Carry,
	CounterRange,
	MuhFlags, //battle rating up
	MuhFlags2,
	CavalryCharge,
	CavalryCharge2,
	OnRush,
	RearGuardCharge,
	FollowThrough,
	//CANNON
	CannonNormalAttack,
	CannonStrongAttack,
	//TACTICIAN
	BattleStrategy,
	BattleStrategy2,
	BattleStrategy3,
	CrossbowAttack,
	CrossbowAttackPlus,
	RemoveBuffs,
	RemoveBuffsAround,
	RemoveBuffsRanged,
	AdvanceTime,
	AdvanceTime2,
	BattleRatingDown,
	BattleRatingDown2,
	AccurateShots,
	//DIVINIER
	MagicGuard,
	MagicGuardAround,
	SummonTrash,
	Shikigami,
	Shikigami2,
	Lightning,
	//MIKO
	MikoDance,
	MikoDancePlus,
	HealingMist,
	MikoDanceQuick,
	BowAttackMiko,
	MikoStorm,
	MikoStorm2,
	//MAGE
	FrostDiver,
	FireBlast,
	Icewall,
	StormGust,
	EnchantWeapon,
	WhiteDestructionBeam

}


public class Skill {
	public int EnergyCost;
	public bool DepleteEnergy = false;
	public int SkillRecoveryTime;
	public int SkillMaxRange = 1;
	public int SkillMinRange = 0;
	public float DamageScaling = 0;
	public float FullHPPercentDamage = 0;
	public float HealScaling = 0;
	public bool Penetrating = false;
	public bool PiercesDefence = false;
	public bool RequiresPreparation = false;
	public bool CancelsPreparation = false;
	public bool ReducesEnergy = false;
	public 	bool CanCounter = true;
	public bool Freezes = false;
	public bool CancelsGuard = false;
	public bool HalvesEnergy = false;
	public bool GlobalPlayer = false;
	public bool GlobalEnemy = false;
	public bool isPhysical = true;
	public bool AppliesPoison = false;
	public bool RemovesPoison = false;
	public int BattleGaugeEffect = 0;
	public float BattleEffect = 0;
	public int BattleTurns = 0;
	public muhSkills PrerequisiteSkill;

	public static Skill FromListOfSkills (muhSkills skilleados) {
			Skill _skill = new Skill();
	switch (skilleados)
		{
		case muhSkills.AccurateShots:
		_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 25,
				DamageScaling = 5, //5 for 1 tile, 5/9 for a 3x3 area, etc..
				CancelsPreparation = true,
				ReducesEnergy = true,
				SkillMinRange = 2,
				SkillMaxRange = 5

		
			};
			break;
		case muhSkills.AdvanceTime:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 30

				
				
			};
			break;
		case muhSkills.AdvanceTime2:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 30,
				PrerequisiteSkill = muhSkills.AdvanceTime

				
				
			};
			break;
		case muhSkills.AimAndShoot:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 25,
				DamageScaling = 1.5f,
				Penetrating = true,
				SkillMaxRange = 4
				
			};
			break;
		case muhSkills.AllGuard:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 20,
				SkillMaxRange = 2,
				PrerequisiteSkill = muhSkills.AllGuard

				
				
			};
			break;
		case muhSkills.AllyGuard:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15

				
				
			};
			break;
		case muhSkills.AllyGuardPlus:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				PrerequisiteSkill = muhSkills.AllyGuard
				
				
			};
			break;
		case muhSkills.AnkleSnare:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20
				
				
				
			};
			break;
		case muhSkills.Assassinate:
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 20
				
				
				
			};
			break;
		case muhSkills.Bait:
			_skill = new Skill() {
				EnergyCost = 0, //that's right. FOR FREE
				SkillRecoveryTime = 10
				
				
				
			};
			break;
		case muhSkills.BattlegroundPreparation:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 5,
				BattleEffect = 4
				
				
				
			};
			break;
		case muhSkills.BattleRatingDown:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				BattleGaugeEffect = -5
				
				
			};
			break;
		case muhSkills.BattleRatingDown2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				BattleGaugeEffect = -10,
				PrerequisiteSkill = muhSkills.BattleRatingDown
				
			};
			break;
		case muhSkills.BattleStrategy:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15
				
				
				
			};
			break;
		case muhSkills.BattleStrategy2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				PrerequisiteSkill = muhSkills.BattleStrategy
				
				
				
			};
			break;
		case muhSkills.BattleStrategy3:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				PrerequisiteSkill = muhSkills.BattleStrategy2
				
				
				
			};
			break;
		case muhSkills.BowAttack:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 1,
				SkillMaxRange = 6,
				SkillMinRange = 2
				
				
			};
			break;
		case muhSkills.BowAttackMiko:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 0.8f,
				SkillMaxRange = 5,
				SkillMinRange = 2
				
				
			};
			break;
		case muhSkills.BowAttackPlus:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 10,
				DamageScaling = 1.1f,
				SkillMaxRange = 6,
				SkillMinRange = 2,
				PrerequisiteSkill = muhSkills.BowAttack
				
			};
			break;
		case muhSkills.CannonNormalAttack:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 30,
				DamageScaling = 1,
				SkillMaxRange = 3

				
			};
			break;
		case muhSkills.CannonStrongAttack:
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 30,
				DamageScaling = 2
				
				
			};
			break;
		case muhSkills.CarefulAttack:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 10,
				DamageScaling = .8f,
				CanCounter = false
				
			};
			break;
		case muhSkills.Carry:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 10
				
				
				
			};
			break;
		case muhSkills.CavalryCharge:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 1
				
				
			};
			break;
		case muhSkills.Charge:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 5
				
				
				
			};
			break;
		case muhSkills.CavalryCharge2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 1.1f,
				PrerequisiteSkill = muhSkills.CavalryCharge,
				
				
			};
			break;
		case muhSkills.ChinkChinkShuriken:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 10,
				DamageScaling = 0.9f,
				Penetrating = true,
				CancelsPreparation = true,
				SkillMaxRange = 3
				
				
			};
			break;
		case muhSkills.CleanUp:
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 30,
				DamageScaling = 1//TAKE CARE NEEDS TO DO EXTRA DAMAGE BASED ON THE DIFFERENCE in unit %
				
				
				
			};
			break;
		case muhSkills.ConvertAction: //1 energy
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15
				
				
				
			};
			break;
		case muhSkills.ConvertAction2: //2 energy
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 2,
				PrerequisiteSkill = muhSkills.ConvertAction
				
				
			};
			break;
		case muhSkills.CounterRange:
			_skill = new Skill() {

				
				
			};
			break;
		case muhSkills.CrossbowAttack:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 40,
				DamageScaling = 2,
				RequiresPreparation = true,
				SkillMaxRange= 3
				
				
			};
			break;
		case muhSkills.CrossbowAttackPlus: //why did i even add this
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 40,
				DamageScaling = 3,
				RequiresPreparation = true,
				SkillMaxRange = 3,
				PrerequisiteSkill = muhSkills.CrossbowAttack
				
				
			};
			break;
		case muhSkills.Depoison:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 10,
				RemovesPoison = true
				
				
			};
			break;
		case muhSkills.EnchantWeapon:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20
				
				
				
			};
			break;
		case muhSkills.FellowTroopsRevenge:
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 10,
				DamageScaling = 2, //need a proper formula for this
				
				
			};
			break;

		case muhSkills.FireBlast:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 30,
				DamageScaling = 1.2f,
				SkillMaxRange = 4,
				
			};
			break;
		case muhSkills.FollowThrough:
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 10,
				DamageScaling = 1f, // NEED A PROPER FORMULA, if battle rating scaling = 3
				
				
			};
			break;
		case muhSkills.FootSoldierAttack:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 1,
				
				
			};
			break;
		case muhSkills.FootSoldierAttack2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 1.1f,
				PrerequisiteSkill = muhSkills.FootSoldierAttack
				
			};
			break;
		case muhSkills.FrostDiver:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 25,
				DamageScaling = 0.3f,
				isPhysical = false,
				Freezes = true
				
			};
			break;
		case muhSkills.FullPowerCharge:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 15,
				DamageScaling = 2,
				
				
			};
			break;
		case muhSkills.FullPowerCharge2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 2.5f,
				PrerequisiteSkill = muhSkills.FullPowerCharge
				
			};
			break;
		case muhSkills.GambleCharge:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 30,
				DamageScaling = Random.Range ( 0.5f,2.5f), //oop
				
				
			};
			break;
		case muhSkills.GambleChargeLove:
			_skill = new Skill() {
				EnergyCost = 2,
				DepleteEnergy = true,
				SkillRecoveryTime = 10,
				DamageScaling = Random.Range ( 1f,3f),
				PrerequisiteSkill = muhSkills.GambleCharge
				
			};
			break;
		case muhSkills.GuardBreak:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 0.8f,
				PiercesDefence = true,

				
				
			};
			break;
		case muhSkills.GuardCancel:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 10,
				CancelsGuard = true,
				
				
			};
			break;
		case muhSkills.HalveEnergy:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 10,
				HalvesEnergy = true,
				
				
			};
			break;
		case muhSkills.HealingMist:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 30,
				GlobalPlayer = true,

				
			};
			break;
		case muhSkills.Icewall:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 10,
				SkillMaxRange = 4
				
				
				
			};
			break;
		case muhSkills.KnightAttack:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 1,
				
				
			};
			break;
		case muhSkills.KnightAttack2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 1.1f,
				PrerequisiteSkill = muhSkills.KnightAttack
				
			};
			break;
		case muhSkills.KnightCharge:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 15,
				DamageScaling = 1.5f, //need formula, if opponent more units, scaling 3
				
				
			};
			break;
		case muhSkills.LightAttack:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 20,
				DamageScaling = 0.2f, //meh capture niggas
				
				
			};
			break;
		case muhSkills.Lightning:
			_skill = new Skill() {
				EnergyCost = 2,
				DepleteEnergy = true,
				SkillRecoveryTime = 10,
				isPhysical = false,
				DamageScaling = 3,
				SkillMaxRange = 3
				
				
			};
			break;
		case muhSkills.Loot:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 0.8f,
				//ADD GOLD GAINS
				
				
			};
			break;
		case muhSkills.MagicGuard:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				//add 1 atk no dmg idk how2
				
				
			};
			break;
		case muhSkills.MagicGuardAround:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 30,
				SkillMaxRange = 2,
				PrerequisiteSkill = muhSkills.MagicGuard
				
				
			};
			break;
		case muhSkills.Maim:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 15,
				DamageScaling = 1.1f,
				//add less movement to opponent
				
				
			};
			break;
		case muhSkills.Meditate:
			_skill = new Skill() {
				EnergyCost = -1,
				SkillRecoveryTime = 20,
				
				
				
			};
			break;
		case muhSkills.Meditate2:
			_skill = new Skill() {
				EnergyCost = -1,
				SkillRecoveryTime = 10,
				PrerequisiteSkill = muhSkills.Meditate
				
				
			};
			break;
		case muhSkills.MikoDance:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				HealScaling = 1,
				SkillMaxRange = 2
				
			};
			break;
		case muhSkills.MikoDancePlus:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				HealScaling = 2,
				SkillMaxRange = 3,
				PrerequisiteSkill = muhSkills.MikoDance
				
			};
			break;
		case muhSkills.MikoDanceQuick:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 10,
				HealScaling = 2,				
				SkillMaxRange = 2,
				PrerequisiteSkill = muhSkills.MikoDancePlus
			};
			break;
		case muhSkills.MikoStorm:
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 10,
				FullHPPercentDamage = 10,
				GlobalEnemy = true,
				
				
			};
			break;
		case muhSkills.MikoStorm2:
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 10,
				FullHPPercentDamage = 20,
				GlobalEnemy = true,
				PrerequisiteSkill = muhSkills.MikoStorm
				
			};
			break;
		case muhSkills.MonkCharge:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 1,
				//add auto buff removal
				
				
			};
			break;
		case muhSkills.MonkChargePlus:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 1.2f,
				//add auto buff removal
				PrerequisiteSkill = muhSkills.MonkCharge
				
			};
			break;
		case muhSkills.MuhFlags:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 15,
				BattleEffect = 8,
				
				
			};
			break;
		case muhSkills.MuhFlags2:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 15,
				BattleEffect = 15,
				PrerequisiteSkill = muhSkills.MuhFlags
				
			};
			break;
		case muhSkills.OnRush:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 20,
				DamageScaling = 1.3f,
				ReducesEnergy = true,
				
				
			};
			break;
		case muhSkills.Overtime:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 30,
				BattleTurns = 4,
				
				
			};
			break;
		case muhSkills.Overtime2:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 30,
				BattleTurns = 6,
				PrerequisiteSkill = muhSkills.Overtime
				
			};
			break;
		case muhSkills.PenetrationShoot:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 0.5f,
				Penetrating = true,
				SkillMaxRange = 5,
				SkillMinRange = 2
				
				
			};
			break;
		case muhSkills.PenetrationShoot2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 0.7f,
				Penetrating = true,
				SkillMaxRange = 5,
				SkillMinRange = 2,
				PrerequisiteSkill = muhSkills.PenetrationShoot
				
			};
			break;
		case muhSkills.Phalanx:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				//zzz
				
				
			};
			break;
		case muhSkills.Poison:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 30,
				DamageScaling = 0.6f,
				AppliesPoison = true,
				
			};
			break;
		case muhSkills.QuickAttack:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 5,
				DamageScaling = 1,
				
				
			};
			break;
		case muhSkills.RearGuardCharge:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 20,
				DamageScaling = 1.5f, //3 if vs rangeds
				
				
			};
			break;
		case muhSkills.RemoveBuffs:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,

				
				
			};
			break;
		case muhSkills.RemoveBuffsAround:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 25,
				SkillMaxRange = 2,
				PrerequisiteSkill = muhSkills.RemoveBuffs
				
				
			};
			break;
		case muhSkills.RemoveBuffsRanged:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 20,
				SkillMaxRange = 4,
				PrerequisiteSkill = muhSkills.RemoveBuffs
				
				
			};
			break;
		case muhSkills.Sharpshoot:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 25,
				DamageScaling = 1.4f, //add that if target hit, hit behind
				SkillMaxRange = 5,
				SkillMinRange = 2
				
				
			};
			break;
		case muhSkills.Shikigami:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 25,
				DamageScaling = 2,
				isPhysical = false,
				RequiresPreparation = true,
				SkillMaxRange = 4,


				
			};
			break;
		case muhSkills.Shikigami2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 25,
				DamageScaling = 2.5f,
				isPhysical = false,
				RequiresPreparation = true,
				SkillMaxRange = 5,
				PrerequisiteSkill = muhSkills.Shikigami
				
			};
			break;
		case muhSkills.Shoot:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 1,
                SkillMaxRange = 4								
				
			};
			break;
		case muhSkills.ShoutingCharge:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 23,
				DamageScaling = 1.2f,
				//add battle rating based on damage
				
				
			};
			break;
		case muhSkills.Shuriken:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				CancelsPreparation = true,
				DamageScaling = 0.7f,
				SkillMaxRange = 3
				
			};
			break;
		case muhSkills.Shuriken2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				CancelsPreparation = true,
				DamageScaling = 1f,
				SkillMaxRange = 3,
				PrerequisiteSkill = muhSkills.Shuriken
				
			};
			break;
		case muhSkills.SideAttack:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 20,
				DamageScaling = 1.1f,
				CanCounter = false,
				
				
			};
			break;
		case muhSkills.SonicShuriken:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 1,
				DamageScaling = 1f,
				CancelsPreparation = true,
				SkillMaxRange = 3

				
			};
			break;
		case muhSkills.StormGust:
			_skill = new Skill() {
				EnergyCost = 3,
				SkillRecoveryTime = 30,
				DamageScaling = 2.5f,
				SkillMaxRange = 6,
				SkillMinRange = 2,
				RequiresPreparation = true,
				isPhysical= false,
				Freezes = true				
			};
			break;
		case muhSkills.StrongBowAttack:
			_skill = new Skill() {
				EnergyCost = 3,
				SkillRecoveryTime = 25,
				DamageScaling = 2.5f,
				SkillMaxRange = 6,
				SkillMinRange = 2
				
			};
			break;
		case muhSkills.StrongFootAttack:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 15,
				DamageScaling = 2,

				
				
				
			};
			break;
		case muhSkills.StrongFootAttack2:
			_skill = new Skill() {
				EnergyCost = 3,
				SkillRecoveryTime = 15,
				DamageScaling = 3,
				PrerequisiteSkill = muhSkills.StrongFootAttack
				
				
				
			};
			break;
		case muhSkills.SummonTrash:
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 10,
				//spawn a monster that attacks anyone, based on summoner stats
				SkillMaxRange = 2
				
			};
			break;
		case muhSkills.SweepingFire:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 0.9f,
				Penetrating = true,
				SkillMaxRange = 5,
				SkillMinRange = 1
				
			};
			break;
		case muhSkills.TenshiDivineTrash:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				HealScaling = 4,
				
				
				
			};
			break;
		case muhSkills.TenshiDivineTrash2:
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 20,
				HealScaling = 8,
				PrerequisiteSkill = muhSkills.TenshiDivineTrash
				
				
			};
			break;
		case muhSkills.Volley:
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 20,
				DamageScaling = 0.5f, //4x4 area 
				SkillMaxRange = 5,
				SkillMinRange = 2
				
				
			};
			break;
		case muhSkills.WarriorAttack:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 1,
				
				
			};
			break;
		case muhSkills.WarriorAttack2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 1.2f,
				PrerequisiteSkill = muhSkills.WarriorAttack
				
				
			};
			break;
		case muhSkills.WhiteDestructionBeam:
			_skill = new Skill() {
				EnergyCost = 3,
				DepleteEnergy = true,
				SkillRecoveryTime = 30,
				DamageScaling = 2,
				Penetrating = true //damage in a line till the end of the map

				
				
			};
			break;

		} 
		return _skill;
	}


}
