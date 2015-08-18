using UnityEngine;
using System.Collections;

public enum ListOfTraits {
	Coward,
	Fearless,
	NaturalBornLeader
}

public class Trait {
	public static Trait FromTraitList (ListOfTraits NameOfTrait){
		Trait trait = new Trait();
		switch (NameOfTrait){
		case ListOfTraits.Coward:
			trait = new Trait(){

			};
				break;
		}
		return trait;
	}



}
