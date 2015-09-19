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
	Animal,
	Ice,
	Yogurt

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
static	List<muhSkills> ClassSkills = new List<muhSkills>();
static	List<muhSkills> ClassAdvancedSkills = new List<muhSkills>();

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
			//ClassSkills.Add(muhSkills.AccurateShots);
			ClassSkills.Add(muhSkills.AccurateShots);
			ClassSkills.Add(muhSkills.BowAttack);
			ClassSkills.Add(muhSkills.StrongBowAttack);
			ClassAdvancedSkills.Add(muhSkills.SweepingFire);
			ClassAdvancedSkills.Add(muhSkills.Volley);
			ClassAdvancedSkills.Add(muhSkills.Sharpshoot);
			ClassAdvancedSkills.Add(muhSkills.BowAttackPlus);

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
			ClassSkills.Add(muhSkills.CannonNormalAttack);
			ClassSkills.Add(muhSkills.CannonStrongAttack);
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
			ClassSkills.Add(muhSkills.MuhFlags);
			ClassSkills.Add(muhSkills.CounterRange);
			ClassSkills.Add(muhSkills.Carry);
			ClassSkills.Add(muhSkills.CavalryCharge);
			ClassAdvancedSkills.Add(muhSkills.MuhFlags2);
			ClassAdvancedSkills.Add(muhSkills.CavalryCharge2);
			ClassAdvancedSkills.Add(muhSkills.OnRush);
			ClassAdvancedSkills.Add(muhSkills.FollowThrough);
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
			ClassSkills.Add(muhSkills.MagicGuard);
			ClassSkills.Add(muhSkills.Shikigami);
			ClassAdvancedSkills.Add(muhSkills.Shikigami2);
			ClassAdvancedSkills.Add(muhSkills.MagicGuardAround);
			ClassAdvancedSkills.Add(muhSkills.SummonTrash);
			ClassAdvancedSkills.Add(muhSkills.Lightning);
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
			ClassSkills.Add(muhSkills.AllyGuard);
			ClassSkills.Add(muhSkills.FootSoldierAttack);
			ClassSkills.Add(muhSkills.StrongFootAttack);
			ClassAdvancedSkills.Add(muhSkills.AllyGuardPlus);
			ClassAdvancedSkills.Add(muhSkills.AllGuard);
			ClassAdvancedSkills.Add(muhSkills.Phalanx);
			ClassAdvancedSkills.Add(muhSkills.FootSoldierAttack2);
			ClassAdvancedSkills.Add(muhSkills.Loot);
			ClassAdvancedSkills.Add(muhSkills.StrongFootAttack2);
			ClassAdvancedSkills.Add(muhSkills.FellowTroopsRevenge);

				break;
		case muhClasses.Ice:
			meinClass = new Classes(){
				Attack = 0,
				Defense = 40,
				Intelligence = 20,
				Speed = 0,
				HealCost = 0,
				MaxTroopRatio = 999,
				RecruitCost = 0,
				LayoffSaving = 0,
				isPhysical = true,
			};			
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
			ClassSkills.Add(muhSkills.KnightAttack);
			ClassSkills.Add(muhSkills.KnightCharge);
			ClassAdvancedSkills.Add(muhSkills.KnightAttack2);
			ClassAdvancedSkills.Add(muhSkills.CleanUp);
			ClassAdvancedSkills.Add(muhSkills.Maim);
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
			ClassSkills.Add(muhSkills.FrostDiver);
			ClassSkills.Add(muhSkills.FireBlast);
			ClassAdvancedSkills.Add(muhSkills.Icewall);
	//		ClassAdvancedSkills.Add(muhSkills.EnchantWeapon);
			ClassAdvancedSkills.Add(muhSkills.WhiteDestructionBeam);
			ClassAdvancedSkills.Add(muhSkills.StormGust);
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
			ClassSkills.Add(muhSkills.BowAttackMiko);
			ClassSkills.Add(muhSkills.MikoDance);
			ClassAdvancedSkills.Add(muhSkills.HealingMist);
			ClassAdvancedSkills.Add(muhSkills.MikoDancePlus);
			ClassAdvancedSkills.Add(muhSkills.MikoDanceQuick);
			ClassAdvancedSkills.Add(muhSkills.MikoStorm2);
			ClassAdvancedSkills.Add(muhSkills.MikoStorm);

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
			ClassSkills.Add(muhSkills.GuardCancel);
			ClassSkills.Add(muhSkills.MonkCharge);
			ClassSkills.Add(muhSkills.TenshiDivineTrash);
			ClassSkills.Add(muhSkills.Meditate);
			ClassSkills.Add(muhSkills.Depoison);
			ClassAdvancedSkills.Add(muhSkills.TenshiDivineTrash2);
			ClassAdvancedSkills.Add(muhSkills.Meditate2);
			ClassAdvancedSkills.Add(muhSkills.ConvertAction);
			ClassAdvancedSkills.Add(muhSkills.ConvertAction2);
			ClassAdvancedSkills.Add(muhSkills.MonkChargePlus);
			ClassAdvancedSkills.Add(muhSkills.Overtime);
			ClassAdvancedSkills.Add(muhSkills.Overtime2);
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
			ClassSkills.Add(muhSkills.Bait);
			ClassSkills.Add(muhSkills.Shoot);
			ClassSkills.Add(muhSkills.PenetrationShoot);
			ClassAdvancedSkills.Add(muhSkills.AimAndShoot);
			ClassAdvancedSkills.Add(muhSkills.PenetrationShoot2);

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
			ClassSkills.Add(muhSkills.Shuriken);
			ClassSkills.Add(muhSkills.Poison);
			ClassSkills.Add(muhSkills.AnkleSnare);
			ClassAdvancedSkills.Add(muhSkills.BattlegroundPreparation);
			ClassAdvancedSkills.Add(muhSkills.HalveEnergy);
			ClassAdvancedSkills.Add(muhSkills.Shuriken2);
			ClassAdvancedSkills.Add(muhSkills.ChinkChinkShuriken);
			ClassAdvancedSkills.Add(muhSkills.SonicShuriken);
			ClassAdvancedSkills.Add(muhSkills.Assassinate);
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
			ClassSkills.Add(muhSkills.BattleStrategy);
			ClassSkills.Add(muhSkills.CrossbowAttack);
			ClassSkills.Add(muhSkills.RemoveBuffs);
			ClassAdvancedSkills.Add(muhSkills.BattleStrategy2)		;
			ClassAdvancedSkills.Add(muhSkills.BattleStrategy3)	;
			ClassAdvancedSkills.Add(muhSkills.CrossbowAttackPlus)	;
			ClassAdvancedSkills.Add(muhSkills.RemoveBuffsAround)	;
			ClassAdvancedSkills.Add(muhSkills.RemoveBuffsRanged)	;
			ClassAdvancedSkills.Add(muhSkills.AdvanceTime)			;
			ClassAdvancedSkills.Add(muhSkills.AdvanceTime2)			;
			ClassAdvancedSkills.Add(muhSkills.BattleRatingDown)			;
			ClassAdvancedSkills.Add(muhSkills.BattleRatingDown2)	;
			ClassAdvancedSkills.Add(muhSkills.AccurateShots)	;
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
			ClassSkills.Add(muhSkills.Charge);
			ClassSkills.Add(muhSkills.WarriorAttack);
			ClassSkills.Add(muhSkills.FullPowerCharge);
			ClassAdvancedSkills.Add(muhSkills.WarriorAttack2);
			ClassAdvancedSkills.Add(muhSkills.GuardBreak);
			ClassAdvancedSkills.Add(muhSkills.ShoutingCharge);
			ClassAdvancedSkills.Add(muhSkills.SideAttack);
			ClassAdvancedSkills.Add(muhSkills.CarefulAttack);
			ClassAdvancedSkills.Add(muhSkills.QuickAttack);
			ClassAdvancedSkills.Add(muhSkills.LightAttack);
			ClassAdvancedSkills.Add(muhSkills.FullPowerCharge2);
			ClassAdvancedSkills.Add(muhSkills.GambleCharge);
			ClassAdvancedSkills.Add(muhSkills.GambleChargeLove);

				break;
		case muhClasses.Yogurt:
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

	public List<muhSkills> GetBaseClassSkills(){
		return ClassSkills;
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
