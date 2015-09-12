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

	WhiteDestructionBeam,
    //SYSTEM 
	NoSkill //to check if there's a skill pre-requisite

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
	public int GuardScaling = 0;
	public muhSkills PrerequisiteSkill = muhSkills.NoSkill;
	public float TroopSizeBuffMultiplier = 0;

	public static Skill FromListOfSkills (muhSkills skilleados) {
			Skill _skill = new Skill();
	switch (skilleados)
		{
		case muhSkills.AccurateShots: //skill that deals damage in an area, you can select the width of the area. also reduces enemy energy and cancels preparation.
		_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 25,
				DamageScaling = 5, //5 for 1 tile, 5/9 for a 3x3 area, etc..
				CancelsPreparation = true,
				ReducesEnergy = true,
				SkillMinRange = 2,
				SkillMaxRange = 7

		
			};
			break;
		case muhSkills.AdvanceTime: //advance time on the clock
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
		case muhSkills.AimAndShoot: //take an extra turn to charge, then deal 1.5f damage penetrating with huge range time to sniperados
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 36,
				DamageScaling = 1.5f,
				Penetrating = true,
				SkillMaxRange = 12,
				RequiresPreparation = true

				
			};
			break;
		case muhSkills.AllGuard: //guard-devotion around the caster. receives damage based on %. es. 80% guard means you take 80% of targets received dmg. 
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				SkillMaxRange = 2,
				PrerequisiteSkill = muhSkills.AllyGuard,
				GuardScaling = 10


				
				
			};
			break;
		case muhSkills.AllyGuard: //single target guard
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				GuardScaling = 20

				
				
			};
			break;
		case muhSkills.AllyGuardPlus:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				PrerequisiteSkill = muhSkills.AllyGuard,
				GuardScaling = 30
				
				
			};
			break;
		case muhSkills.AnkleSnare: //if an unit stops in the position, stop it from moving. forever.
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20
				
				
				
			};
			break;
		case muhSkills.Assassinate: //1hko the enemy if your energy % is higher than his hp % and some other little modifications
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 20,
				SkillMaxRange=1
				
				
				
			};
			break;
		case muhSkills.Bait: //basically provoke increase atk drop def to the enemy
			_skill = new Skill() {
				EnergyCost = 0,
				SkillRecoveryTime = 10
				
				
				
			};
			break;
		case muhSkills.BattlegroundPreparation: //increases the strenght of your attacks by 4% global if its too broken ill put it as aura
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 5,
				BattleEffect = 4
				
				
				
			};
			break;
		case muhSkills.BattleRatingDown: //makes the enemy look bad and lowers battle gauge
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
		case muhSkills.BattleStrategy: //buffs people. number of buffs based on people in the unit, buff strenght based on int.
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				TroopSizeBuffMultiplier = 1.5f
				
				
				
			};
			break;
		case muhSkills.BattleStrategy2:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				PrerequisiteSkill = muhSkills.BattleStrategy,
				TroopSizeBuffMultiplier = 2
				
				
				
			};
			break;
		case muhSkills.BattleStrategy3:
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				PrerequisiteSkill = muhSkills.BattleStrategy2,
				TroopSizeBuffMultiplier = 2.5f
				
				
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
		case muhSkills.CarefulAttack: //normal attack but you cant counter attack
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 10,
				DamageScaling = 1,
				CanCounter = false
				
			};
			break;
		case muhSkills.Carry: //maybe change to passive? can carry other people around
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 10
				
				
				
			};
			break;
		case muhSkills.CavalryCharge: //normal cavalry atk
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 1
				
				
			};
			break;
		case muhSkills.Charge:   //increase attack idk if i want to keep this
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
		case muhSkills.ChinkChinkShuriken: //a shuriken with penetration
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 10,
				DamageScaling = 0.9f,
				Penetrating = true,
				CancelsPreparation = true,
				SkillMaxRange = 3
				
				
			};
			break;
		case muhSkills.CleanUp: //finisher
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 30,
				DamageScaling = 1//TAKE CARE NEEDS TO DO EXTRA DAMAGE BASED ON THE DIFFERENCE in unit %
				
				
				
			};
			break;
		case muhSkills.ConvertAction: //gives 1 energy to someone else
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15
				
				
				
			};
			break;
		case muhSkills.ConvertAction2: //2 energy
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 15,
				PrerequisiteSkill = muhSkills.ConvertAction
				
				
			};
			break;
		case muhSkills.CounterRange: //you can activate it when atked, cavalry can counter attack rangeds by rushing to them
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
		case muhSkills.CrossbowAttackPlus: //why did i even add this you aint gonna attack with tacticians
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
//		case muhSkills.EnchantWeapon: // deals bonus magic damage based on casters int
//			_skill = new Skill() {
//				EnergyCost = 1,
//				SkillRecoveryTime = 20
//				
//				
//				
//			};
//			break;
		case muhSkills.FellowTroopsRevenge: //deal physical damage based on people ded in your unit
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
		case muhSkills.FollowThrough: //if you are winning in the battle gauge deal x3 as much damage
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
		case muhSkills.FrostDiver: //skill the freezes the target. frozen targets are basically out of the game 
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 25,
				DamageScaling = 0.3f,
				isPhysical = false,
				Freezes = true
				
			};
			break;
		case muhSkills.FullPowerCharge: //meh
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
		case muhSkills.GambleCharge: //probably not gonna add this garbage
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
		case muhSkills.GuardBreak: //an attack that ignores part of targets defence, added to the calculate damage
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 0.8f,
				PiercesDefence = true,

				
				
			};
			break;
		case muhSkills.GuardCancel: //an spell that removes devotion
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 10,
				CancelsGuard = true,
				
				
			};
			break;
		case muhSkills.HalveEnergy: //anti fun burden of knowledge
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 10,
				HalvesEnergy = true,
				
				
			};
			break;
		case muhSkills.HealingMist: //global shitty healing
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 30,
				GlobalPlayer = true,

				
			};
			break;
		case muhSkills.Icewall: //prevents people from passing and maybe prevent projectiles to hit 1 cell after it?
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
		case muhSkills.LightAttack: //keep if i want to add capturing mechanics
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 20,
				DamageScaling = 0.2f, //meh capture niggas
				
				
			};
			break;
		case muhSkills.Lightning: //aoe damage all around caster dealing tons of damage probably only for 1 char
			_skill = new Skill() {
				EnergyCost = 2,
				DepleteEnergy = true,
				SkillRecoveryTime = 10,
				RequiresPreparation = true,
				isPhysical = false,
				DamageScaling = 5,
				SkillMaxRange = 3,
				CanCounter = false
				
				
			};
			break;
		case muhSkills.Loot: //deals damage and gives you money after the end of the battle if you win
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 15,
				DamageScaling = 0.8f,
				//ADD GOLD GAINS
				
				
			};
			break;
		case muhSkills.MagicGuard: //le ague de le gens banshee veil pretty much added in the hp setters for troopscripteados
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
		case muhSkills.Maim: //gooble gobble 
			_skill = new Skill() { 
				EnergyCost = 2,
				SkillRecoveryTime = 15,
				DamageScaling = 1.1f,
				//reduce movement to target
				
				
			};
			break;
		case muhSkills.Meditate: //heal 1 energy to self
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
		case muhSkills.MikoDance: //heal target but its kinda shit
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
		case muhSkills.MikoStorm: //global % true damage
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
		case muhSkills.MonkCharge: //attacks and removes buffs to target.
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
		case muhSkills.MuhFlags: //increases battle rating added to battle rating in newfightscript
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
		case muhSkills.OnRush:  //reduces energy and deals dmg
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 20,
				DamageScaling = 1.3f,
				ReducesEnergy = true,
				
				
			};
			break;
		case muhSkills.Overtime: //increases turns left b4 battle ends
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
		case muhSkills.PenetrationShoot: //ignores guard
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

		case muhSkills.Phalanx: //increase defence by 50%? reduced movement and cant enter tiles like forests, deserts, etc..
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				//zzz
				
				
			};
			break;
		case muhSkills.Poison: //after X turns 1hko target. if target moves, attacks,  counter attacks, etc. reduces amount of turns. maybe scale with int but idk
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 30,
				DamageScaling = 0.6f,
				AppliesPoison = true,
				
			};
			break;
		case muhSkills.QuickAttack: //low reco time
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 5,
				DamageScaling = 1,
				
				
			};
			break;
		case muhSkills.RearGuardCharge: //bonus dmg to ranged units
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
		case muhSkills.Sharpshoot: //added in the game manager class
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 25,
				DamageScaling = 1.4f, //add that if target hit, hit behind
				SkillMaxRange = 5,
				SkillMinRange = 2
				
				
			};
			break;
		case muhSkills.Shikigami: //magic spell area idk what the puk is a shikigami google returns weebshit
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
		case muhSkills.ShoutingCharge: //add battle rating based on damage
			_skill = new Skill() {
				EnergyCost = 2,
				SkillRecoveryTime = 23,
				DamageScaling = 1.2f,

				
				
			};
			break;
		case muhSkills.Shuriken: //normal ninja skill, cancels preparation
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
		case muhSkills.SideAttack: //prevents counter attack?
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
		case muhSkills.StormGust: //frost diver aoe
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
		case muhSkills.SummonTrash: //spawn a monster that attacks anyone, based on summoner int
			_skill = new Skill() {
				EnergyCost = 1,
				DepleteEnergy = true,
				SkillRecoveryTime = 10,

				SkillMaxRange = 2
				
			};
			break;
		case muhSkills.SweepingFire: //damage in a line of 3 cells
			_skill = new Skill() {
				EnergyCost = 1,
				SkillRecoveryTime = 20,
				DamageScaling = 0.9f,
				Penetrating = true,
				SkillMaxRange = 5,
				SkillMinRange = 1
				
			};
			break;
		case muhSkills.TenshiDivineTrash: //self heal
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
		case muhSkills.Volley: //meh dmg huge area
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
		case muhSkills.WhiteDestructionBeam: //damage in a line till the end of the map
			_skill = new Skill() {
				EnergyCost = 3,
				DepleteEnergy = true,
				SkillRecoveryTime = 30,
				DamageScaling = 2,
				Penetrating = true 
				
				
			};
			break;

		} 
		return _skill;
	}


}
