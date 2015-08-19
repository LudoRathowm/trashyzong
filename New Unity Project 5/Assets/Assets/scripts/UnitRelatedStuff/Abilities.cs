using UnityEngine;
using System.Collections;



public enum ListOfAbilities {
	Popular, //easier to recruit for this nigga
	StrongLeadership, // less scaling
	SweepingFire, //ignores passive and active skills of the opponent when calculating damage + 1.5* dmg
	Phalanx //increase defence by 50%, -1 movement, can't walk on terrains with < 15 peeps, can't be used if no shield
}


public class Abilities  {
	public bool isActive;
	public int CostToLearn;
	public string AbilityName;
	public float muhReturns;
	public int EnergyCost;
	public static Abilities fromList (ListOfAbilities _ability){
		Abilities ability = new Abilities();
		switch (_ability){
		case ListOfAbilities.StrongLeadership:
			ability = new Abilities(){
				isActive = false,
				CostToLearn = 10000,
				AbilityName = "Strong Leadership",
				muhReturns = 0.01f,
				EnergyCost = 0
			};
			break;
		case ListOfAbilities.Phalanx:
			ability = new Abilities(){
				isActive = true,
				CostToLearn = 10000,
				AbilityName = "Phalanx",
				muhReturns = 0,
				EnergyCost = 30
			};
			break;
		}
		return ability;
	}




	public static void ActivatePhalanx (TroopScript troopThatUsesPhalanx){
		troopThatUsesPhalanx.GetArmor().Defence+=Mathf.RoundToInt(troopThatUsesPhalanx.GetArmor().Defence/2);
		troopThatUsesPhalanx.SetBaseMovement(troopThatUsesPhalanx.GetBaseMovement()-1);
		}
	public static void DeactivatePhalanx (TroopScript troopThatUsedPhalanx){
		troopThatUsedPhalanx.GetArmor().Defence-=Mathf.RoundToInt(troopThatUsedPhalanx.GetArmor().Defence/3);
		troopThatUsedPhalanx.SetBaseMovement(troopThatUsedPhalanx.GetBaseMovement()+1);

	}
}
