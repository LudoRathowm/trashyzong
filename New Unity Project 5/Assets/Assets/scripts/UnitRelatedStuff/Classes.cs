using UnityEngine;
using System.Collections;

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
				isPhysical = true
			};
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
				isPhysical = true
			};
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
				isPhysical = true
			};
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
				isPhysical = false
			};
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
				isPhysical = true
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
				isPhysical = true
			};
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
				isPhysical = false
			};
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
				isPhysical = true
			};
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
				isPhysical = true
			};
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
				isPhysical = true
			};
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
				isPhysical = true
			};
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
				isPhysical = true
			};
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
				isPhysical = true
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
