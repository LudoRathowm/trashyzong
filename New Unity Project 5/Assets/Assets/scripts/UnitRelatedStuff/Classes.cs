using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum muhClasses{
	Warrior,
	FootSoldier,
	Tactician,
	Archer,
	Ninja,
	Miko,
	Monk,
	Diviner,
	Musketeer,
	Cannon,
	Knight,
	Mage,
	Cavalry,
	Animal

}

public class Classes  {
	int Attack;
	int Defense;
	int Intelligence;
	int Speed; //A = 30, B = 20, C = 10
	int HealCost; 
	float MaxTroopRatio;
	int RecruitCost;
	int LayoffSaving;
	bool isPhysical;
static	List<Skill> ClassSkills = new List<Skill>();
static	List<Skill> ClassAdvancedSkills = new List<Skill>();

	public static Classes fromList (muhClasses _class){

		Classes meinClass = new Classes();
		switch (_class){
		case muhClasses.Animal:
			meinClass = new Classes(){
				Attack = 38,
				Defense = 0,
				Intelligence = 1,
				Speed = 20,
				HealCost = 4,
				MaxTroopRatio = 1,
				RecruitCost = 72,
				LayoffSaving = 4,
				isPhysical = true
			};
			//no skills, they can't attack, they can only be slaughtered. Animals have no god.
			break;
		case muhClasses.Archer:
			meinClass = new Classes(){
				Attack = 40,
				Defense = 15,
				Intelligence = 30,
				Speed = 20,
				HealCost = 4,
				MaxTroopRatio = 1.5f,
				RecruitCost = 36,
				LayoffSaving = 3,
				isPhysical = true,

			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.AccurateShots));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.AccurateShots));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.BowAttack));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.StrongBowAttack));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.SweepingFire));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Volley));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Sharpshoot));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.BowAttackPlus));

				break;
		case muhClasses.Cannon:
			meinClass = new Classes(){
				Attack = 110,
				Defense = 0,
				Intelligence = 20,
				Speed = 10,
				HealCost = 4,
				MaxTroopRatio = 1,
				RecruitCost = 120,
				LayoffSaving = 4,
				isPhysical = true,
			
			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.CannonNormalAttack));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.CannonStrongAttack));
				break;
		case muhClasses.Cavalry:
			meinClass = new Classes(){
				Attack = 80,
				Defense = 35,
				Intelligence = 10,
				Speed = 30,
				HealCost = 1,
				MaxTroopRatio = 1,
				RecruitCost = 56,
				LayoffSaving = 3,
				isPhysical = true,
				                                  

				
			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.MuhFlags));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.CounterRange));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.Carry));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.CavalryCharge));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.MuhFlags2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.CavalryCharge2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.OnRush));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.FollowThrough));
				break;
		case muhClasses.Diviner:
			meinClass = new Classes(){
				Attack = 35,
				Defense = 10,
				Intelligence = 40,
				Speed = 20,
				HealCost = 4,
				MaxTroopRatio = 0.7f,
				RecruitCost = 60,
				LayoffSaving = 4,
				isPhysical = false,

			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.MagicGuard));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.Shikigami));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Shikigami2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.MagicGuardAround));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.SummonTrash));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Lightning));
			break;
		case muhClasses.FootSoldier:
			meinClass = new Classes(){
				Attack = 45,
				Defense = 20,
				Intelligence = 20,
				Speed = 20,
				HealCost = 1,
				MaxTroopRatio = 1.5f,
				RecruitCost = 24,
				LayoffSaving = 2,
				isPhysical = true,
					};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.AllyGuard));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.FootSoldierAttack));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.StrongFootAttack));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.AllyGuardPlus));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.AllGuard));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Phalanx));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.FootSoldierAttack2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Loot));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.StrongFootAttack2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.FellowTroopsRevenge));

				break;
		case muhClasses.Knight:
			meinClass = new Classes(){
				Attack = 60,
				Defense = 30,
				Intelligence = 20,
				Speed = 30,
				HealCost = 1,
				MaxTroopRatio = 1,
				RecruitCost = 56,
				LayoffSaving = 3,
				isPhysical = true,

			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.KnightAttack));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.KnightCharge));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.KnightAttack2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.CleanUp));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Maim));
				break;
		case muhClasses.Mage:
			meinClass = new Classes(){
				Attack = 35,
				Defense = 10,
				Intelligence = 45,
				Speed = 10,
				HealCost = 4,
				MaxTroopRatio = 1,
				RecruitCost = 72,
				LayoffSaving = 4,
				isPhysical = false,
		

			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.FrostDiver));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.FireBlast));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Icewall));
	//		ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.EnchantWeapon));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.WhiteDestructionBeam));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.StormGust));
				break;
		case muhClasses.Miko:
			meinClass = new Classes(){
				Attack = 35,
				Defense = 10,
				Intelligence = 10,
				Speed = 10,
				HealCost = 4,
				MaxTroopRatio = 0.7f,
				RecruitCost = 72,
				LayoffSaving = 4,
				isPhysical = true,
		
			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.BowAttackMiko));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.MikoDance));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.HealingMist));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.MikoDancePlus));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.MikoDanceQuick));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.MikoStorm2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.MikoStorm));

				break;
		case muhClasses.Monk:
			meinClass = new Classes(){
				Attack = 50,
				Defense = 30,
				Intelligence = 20,
				Speed = 10,
				HealCost = 4,
				MaxTroopRatio = 1f,
				RecruitCost = 36,
				LayoffSaving = 3,
				isPhysical = true,
			
			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.GuardCancel));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.MonkCharge));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.TenshiDivineTrash));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.Meditate));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.Depoison));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.TenshiDivineTrash2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Meditate2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.ConvertAction));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.ConvertAction2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.MonkChargePlus));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Overtime));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Overtime2));
				break;
		case muhClasses.Musketeer:
			meinClass = new Classes(){
				Attack = 130,
				Defense = 0,
				Intelligence = 10,
				Speed = 30,
				HealCost = 4,
				MaxTroopRatio = 0.7f,
				RecruitCost = 120,
				LayoffSaving = 4,
				isPhysical = true,
		
			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.Bait));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.Shoot));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.PenetrationShoot));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.AimAndShoot));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.PenetrationShoot2));

				break;
		case muhClasses.Ninja:
			meinClass = new Classes(){
				Attack = 38,
				Defense = 15,
				Intelligence = 20,
				Speed = 40,
				HealCost = 4,
				MaxTroopRatio = 0.7f,
				RecruitCost = 60,
				LayoffSaving = 4,
				isPhysical = true,
			

			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.Shuriken));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.Poison));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.AnkleSnare));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.BattlegroundPreparation));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.HalveEnergy));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Shuriken2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.ChinkChinkShuriken));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.SonicShuriken));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.Assassinate));
				break;
		case muhClasses.Tactician:
			meinClass = new Classes(){
				Attack = 38,
				Defense = 10,
				Intelligence = 20,
				Speed = 10,
				HealCost = 4,
				MaxTroopRatio = 1,
				RecruitCost = 48,
				LayoffSaving = 4,
				isPhysical = true,

							};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.BattleStrategy));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.CrossbowAttack));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.RemoveBuffs));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.BattleStrategy2))		;
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.BattleStrategy3))		;
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.CrossbowAttackPlus))	;
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.RemoveBuffsAround))	;
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.RemoveBuffsRanged))	;
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.AdvanceTime))			;
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.AdvanceTime2))			;
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.BattleRatingDown))			;
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.BattleRatingDown2))		;
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.AccurateShots))			;
				break;
		case muhClasses.Warrior:
			meinClass = new Classes(){
				Attack = 60,
				Defense = 30,
				Intelligence = 20,
				Speed = 20,
				HealCost = 4,
				MaxTroopRatio = 1,
				RecruitCost = 48,
				LayoffSaving = 4,
				isPhysical = true,


				//add a method to upgrade skills, add a list of skills they can learn, add the loop in troop to add the class skills
				
			};
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.Charge));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.WarriorAttack));
			ClassSkills.Add(Skill.FromListOfSkills(muhSkills.FullPowerCharge));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.WarriorAttack2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.GuardBreak));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.ShoutingCharge));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.SideAttack));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.CarefulAttack));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.QuickAttack));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.LightAttack));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.FullPowerCharge2));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.GambleCharge));
			ClassAdvancedSkills.Add(Skill.FromListOfSkills(muhSkills.GambleChargeLove));

				break;
		}
		return meinClass;
	}

	//########################
	//    GETTERS
	//########################

	public int GetAttack (){
		return Attack;
	}
	public int GetDefense(){
		return Defense;
	}
	public int GetIntelligence(){
		return Intelligence;
	}
	public int GetSpeed(){
		return Speed;
	} 
	public int GetHealCost(){
		return HealCost;
	}
	public float GetMaxTroopRatio(){
		return MaxTroopRatio;
	}
	public int GetRecruitCost(){
		return RecruitCost;
	}
	public int GetLayoffSaving(){
		return LayoffSaving;
	}
	public bool GetIfItsPhysical(){
		return isPhysical;
	}

	public Skill GetBaseClassSkills(int i){
		return ClassSkills[i];
	}

	public int GetCountBaseClassSkills(){
		return ClassSkills.Count;
	}

	//#######################
	//      SETTERS
	//#######################

	public void SetAttack(int atk){
		Attack = atk;
	}
	
	public void SetDefense(int def){
		Defense = def;
	}
	
	public void SetIntelligence(int inte){
		Intelligence = inte;
	}
	
	public void SetSpeed (int spd){
		Speed = spd;
	}

	public void SetHealCost (int healcost){
		HealCost = healcost;
	}

	public void SetMaxTroopRatio (float troopratio){
		MaxTroopRatio = troopratio;
	}

	public void SetRecruitCost (int recruitcost){
		RecruitCost = recruitcost;
	}

	public void SetLayoffsaving (int saving){
		LayoffSaving = saving;
	}

	public void SetIfItsPhysical (bool isit){
		isPhysical = isit;
	}
}
