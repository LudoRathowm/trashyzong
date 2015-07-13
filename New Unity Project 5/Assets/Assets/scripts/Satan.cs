using UnityEngine;
using System.Collections;

public class Satan : MonoBehaviour {

//this class is just to contain a bunch of methods because i hate methods and i hate satan

static	int AntiRNJesus(){ //it's actually still rnjesus
		int MyRandom = 0;
		for (int i=0; i<2;i++){
			MyRandom += Random.Range(0,100);
		}

		MyRandom = MyRandom/2;
		return MyRandom;
	}

static int CalculateUnitEffectiveness (int LeaderAbility, int NumberOfPeople, TileType TypeOfTerrain){
		int TotalEffectiveness;
		float TileModifier = ReturnTileModifier(TypeOfTerrain);
		TotalEffectiveness = Mathf.FloorToInt( LeaderAbility/NumberOfPeople*TileModifier); //random formula to fix
		return TotalEffectiveness;
	}

static float ReturnTileModifier (TileType TypeOfTerrain){
		float ModifierValue = 0 ;
		switch (TypeOfTerrain)	{

		case TileType.Street:
				//suckdicks
				ModifierValue = 1;
				break;
		case TileType.Grass:
			ModifierValue = 0.7f;
			break;

		}
		return ModifierValue;
	}

	public static bool SuccessCalculator(int SuccessChance){
		int DiceRoll = 0;
		DiceRoll = Satan.AntiRNJesus();
		if (SuccessChance >= DiceRoll)
			return true;
		else return false;
	}

  







}
