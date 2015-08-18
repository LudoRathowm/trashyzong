using UnityEngine;
using System.Collections;



public enum ListOfAbilities {
	Popular, //easier to recruit for this nigga
	StrongLeadership, // less scaling
	SweepingFire, //ignores passive and active skills of the opponent when calculating damage + 1.5* dmg
	Phalanx //90% immunity to rangeados
}


public class Abilities : MonoBehaviour {
	public bool isActive;
	public int CostToLearn;
	public string AbilityName;
	public static Abilities fromList (ListOfAbilities _ability){
		Abilities ability = new Abilities();
		switch (_ability){
		case ListOfAbilities.StrongLeadership:
			ability = new Abilities(){
				isActive = false,
				CostToLearn = 10000,
				AbilityName = "Strong Leadership"
			};
			break;

		}
		return ability;
	}




	public static void sLeadership (){
		//do some stuff
	}
}
