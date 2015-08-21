using UnityEngine;
using System.Collections;

public class TroopBuildingStuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	Chief Leader;
	
	
	int baseAttack;
	int baseDefence;
	int baseHitPoints;
	int baseSpeed;
	int People;
	int WoundedPeople;
	int baseMovement = 10;
	int baseAttackRange = 0;
	
	
	Weaponry WeaponAdopted;
	Armory ArmorAdopted;







	static void SetTroopBaseStatistics (TroopScript troop,int baseAtk, int baseDef, int baseHitPoints, int baseSpeed, int People, int baseMovement, int BaseRange){
		troop.SetBaseAttack(baseAtk);
		troop.SetBaseDefence(baseDef);
		troop.SetBaseHitpoints(baseHitPoints);
		troop.SetBaseSpeed (baseSpeed);
		troop.SetNumber(People);
		troop.SetBaseMovement(baseMovement);
		troop.SetBaseRange(BaseRange);
	}


	static int TroopEquippingCost (int numberofPeople, int costofEquipment, int costmodifier){
		return numberofPeople*costofEquipment*costmodifier;
	}

	static int TroopRecruitingCost (int numberofPeople, int costOfPeople, int costModifier){
		return numberofPeople*costOfPeople*costModifier;
	}












}
