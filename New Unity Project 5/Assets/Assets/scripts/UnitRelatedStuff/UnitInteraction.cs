using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;


public static class UnitInteraction {



	static int[] BattleResume (TroopScript troopOne, TroopScript troopTwo, int TroopOneWounded, int TroopTwoWounded, int TroopOneDed, int TroopTwoDed){
		int FinalOneWounded =0;
		int FinalOneDead = 0;
		int FinalTwoWounded = 0;
		int FinalTwoDead = 0;
		//0 troopone ded 1 troopone wound 2 trooptwo ded 3 trooptwo wound

		int onewounded = troopOne.GetWounded();
		int twowounded = troopTwo.GetWounded();
		int trooponewoundeddifference = onewounded-TroopOneWounded;
		if (trooponewoundeddifference<0){
			FinalOneWounded = trooponewoundeddifference*-1;
			FinalOneDead = TroopOneDed+onewounded;
		}
		else if (trooponewoundeddifference>=0){
			FinalOneWounded = trooponewoundeddifference;
			FinalOneDead = TroopOneDed+TroopOneWounded;
		}
		int trooptwowoundeddifference = twowounded-TroopTwoWounded;
		if (trooptwowoundeddifference<0){
			FinalTwoWounded = trooptwowoundeddifference*-1;
			FinalTwoDead = TroopTwoDed+twowounded;
		}
		else if (trooptwowoundeddifference>=0){
			FinalTwoWounded = trooptwowoundeddifference;
			FinalTwoDead = TroopTwoDed+TroopOneWounded;
		}

		int[] Resume = new int[4];
		Resume[0] = FinalOneDead;
		Resume[1] = FinalOneWounded;
		Resume[2] = FinalTwoDead;
		Resume[3] = FinalTwoWounded;
		return Resume;

	}


 public static	void InteractionMain(TroopScript TroopOne, TroopScript TroopTwo, Tile _Terrain){
		bool True = true;
		bool False = false;
		List<int> DamageOnTroopOne = new List<int>();
		List<int> DamageOnTroopTwo = new List<int>();
		int TroopOneRange = TroopOne.GetMaxRange();
		int TroopTwoRange = TroopTwo.GetMaxRange();
		if (TroopOneRange>TroopTwoRange){
			DamageOnTroopTwo = CalculateDamageOnDefendingLines(TroopOne,TroopTwo,_Terrain,True);
			for (int i = 0;i<DamageOnTroopTwo.Count;i++)
				DamageOnTroopTwo[i]*=(100+Triangle(TroopOne,TroopTwo))/100;
			int[] TroopTwoLosses = DeadAndWounded(DamageOnTroopTwo,TroopTwo,_Terrain);
			int [] results = BattleResume(TroopOne,TroopTwo,0, TroopTwoLosses[1],0,TroopTwoLosses[0]);
			TroopTwo.SetNumber(TroopTwo.GetNumber()-results[2]-TroopTwoLosses[1]);
			TroopTwo.SetWounded(results[3]);
			Debug.Log (TroopOne.GetName()+" shoots on "+TroopTwo.GetName()+", killing "+results[2]+" soldiers and wounding "+results[3]+" people.");

		}
		else {
		if (PlayerOneFirst(TroopOne,TroopTwo)){

			 DamageOnTroopTwo = CalculateDamageOnDefendingLines(TroopOne,TroopTwo,_Terrain,True);
			 DamageOnTroopOne = CalculateDamageOnDefendingLines(TroopTwo,TroopOne,_Terrain, False);
		}

		else if (!PlayerOneFirst(TroopOne,TroopTwo)){

			 DamageOnTroopOne = CalculateDamageOnDefendingLines(TroopTwo,TroopOne,_Terrain, True);
			 DamageOnTroopTwo = CalculateDamageOnDefendingLines(TroopOne,TroopTwo,_Terrain,False);

		}
		//calculate the weapon triangle
		for (int i = 0;i<DamageOnTroopOne.Count;i++)
			DamageOnTroopOne[i]*=(100+Triangle(TroopTwo,TroopOne))/100;
		for (int i = 0;i<DamageOnTroopTwo.Count;i++)
			DamageOnTroopTwo[i]*=(100+Triangle(TroopOne,TroopTwo))/100;


		//calculates who got killed and wounded during the exchange
		int[] TroopOneLosses = DeadAndWounded(DamageOnTroopOne,TroopOne,_Terrain);
		int[] TroopTwoLosses = DeadAndWounded(DamageOnTroopTwo,TroopTwo,_Terrain);

			int [] results = BattleResume (TroopOne,TroopTwo,TroopOneLosses[1],TroopTwoLosses[1],TroopOneLosses[0],TroopTwoLosses[0]);
			TroopOne.SetNumber(TroopOne.GetNumber()-results[0]-TroopOneLosses[1]);
			TroopOne.SetWounded(results[1]);
			TroopTwo.SetNumber(TroopTwo.GetNumber()-results[2]-TroopTwoLosses[1]);
			TroopTwo.SetWounded(results[3]);
			
			/* ##REDONE WITH THE BATTLE RESUME METHOD BUT BETTER
		//kills people off
		TroopOne.SetNumber(TroopOne.GetNumber()-TroopOneLosses[0]);
		TroopTwo.SetNumber(TroopTwo.GetNumber()-TroopTwoLosses[0]);

		//deals with wounded people
		DealWithWoundedPeople(TroopOne,TroopOneLosses[1]);
		DealWithWoundedPeople(TroopTwo,TroopTwoLosses[1]);*/
		Debug.Log (TroopOne.GetName()+" engages on "+TroopTwo.GetName()+". The result is that he loses "+ results[0]+" soldiers and wounds "+results[1]+", while "+TroopTwo.GetName()+" loses "+results[2]+" soldiers and wounds " + results[3]);
		}

	}


	//takes in the amount of people that got wounded and removes them from the wounded, putting them into the dead (ie. removing them period)
//	static void DealWithWoundedPeople (TroopScript Troop, int NumberOfWounded){ 
//		int WoundedDifference = Troop.GetWounded()-NumberOfWounded;
//	if (WoundedDifference<0)
//			Troop.SetWounded(WoundedDifference*-1);
//	else if (WoundedDifference>=0)
//			Troop.SetWounded(WoundedDifference);
//
//			Troop.SetNumber(Troop.GetNumber()-NumberOfWounded);
//	}



			              //0 ded 1 wounded
	static int[] DeadAndWounded (List<int> DamageOnTroop, TroopScript Troop, Tile _Terrain){
		int[] DedWounded = new int[2];
		int Number = Troop.GetNumber();
		int PeoplePerLine = _Terrain.frontLiners;
		int _NumberOfLines = NumberOfLines(Number,PeoplePerLine);
		int Leftovers = LeftOvers(Number,_NumberOfLines,PeoplePerLine);
		int [] _lines = new int[0] ;
		if (Leftovers>0)
			_lines = new int[_NumberOfLines+1];
		else if (Leftovers==0)
			_lines = new int[_NumberOfLines];
	
		for (int i=0;i<DamageOnTroop.Count;i++){
			_lines[i]= ReturnDedWounded(DamageOnTroop[i],Troop.GetHitpoints());
		}

		for (int i =0;i<_NumberOfLines;i++){
			if (_lines[i]==0)
				DedWounded[0]+=PeoplePerLine;
			if (_lines[i]==1)
				DedWounded[1]+=PeoplePerLine;
		}

		if (Leftovers>0){
			if (_lines[_lines.Length-1]==0)
				DedWounded[0]+=Leftovers;
			else if (_lines[_lines.Length-1]==1)
				DedWounded[1]+=Leftovers;
		}

		return DedWounded;
	}

	 static int ReturnDedWounded (int Damage, int HP){
		int percent =Mathf.FloorToInt( ((float)Damage/(float)HP)*100);
		int returnthis=0;
		if (percent>66)
			returnthis= 0;
		if (percent<67&&percent>33)
			returnthis= 1;
		if (percent<34)
			returnthis= 2;
		return returnthis;
	}

static	bool PlayerOneFirst (TroopScript TroopOne, TroopScript TroopTwo ){
		int TroopOneSPD = TroopOne.GetSpeed();
		int TroopTwoSPD = TroopTwo.GetSpeed();
		return TroopOneSPD>TroopTwoSPD;
	}

static	int NumberOfLines (int numberOfpeople, int peoplePerLine){
		return numberOfpeople/peoplePerLine;
	}
	
static	int LeftOvers (int numberOfpeople, int numberOfLines, int peoplePerLine){
		int peopleonline = numberOfLines*peoplePerLine;
		return (numberOfpeople-peopleonline);
		
	}

static	List<int> CalculateDamageOnDefendingLines (TroopScript Attacker, TroopScript Defender, Tile Terrain, bool isFirstAttack){
		int Attackers = Attacker.GetNumber();
		int FirstOrSecond = ((isFirstAttack)?0:1);
		int Defenders = Defender.GetNumber();
		int PeoplePerLine = Terrain.frontLiners;
		int Attack = Attacker.GetAttack();
		int Defence = Defender.GetDefence();
		int FinalAttack = Attack-Defence;
		if (FinalAttack<0)
			FinalAttack = 0;
		int _AttackingLines = NumberOfLines(Attackers,PeoplePerLine);
		int _DefendingLines = NumberOfLines(Defenders,PeoplePerLine);
		int _AttackLeftOvers = LeftOvers(Attackers,_AttackingLines,PeoplePerLine);
		int _DefendLeftOvers = LeftOvers(Defenders,_DefendingLines,PeoplePerLine);
		int Damage = GenerateDamage(_AttackingLines,PeoplePerLine,_AttackLeftOvers,FinalAttack,FirstOrSecond);
		int AdjustedDamage = Mathf.FloorToInt(Damage*((float)Attackers/(float)Defenders));
		List<int> DamageOnDefenders = new List<int>();
		for (int i = 0;i<_DefendingLines;i++)
			DamageOnDefenders.Add(Mathf.FloorToInt(AdjustedDamage/((float)i+1)));
		if (_DefendLeftOvers>0)
			DamageOnDefenders.Add(Mathf.FloorToInt(AdjustedDamage/((float)_DefendingLines)));
		return DamageOnDefenders;
	}

static	int GenerateDamage (int Lines, int peoplePerLine, int Leftovers, int AveragedAttack, int ZeroOrOne){
		int TotalAttack = 0;
		for (float i = 1;i<Lines+1;i++)
			TotalAttack+=Mathf.FloorToInt(AveragedAttack*peoplePerLine*(1/(i+ZeroOrOne)));
		if (Leftovers>0)
			TotalAttack+=(Mathf.FloorToInt(AveragedAttack*Leftovers*(1/((float)Lines+ZeroOrOne+1))));
		return TotalAttack;
	}

static	int Triangle (TroopScript Attacker, TroopScript Defender){ //not optimal but it's the most readable
		int DamageModifier= 0;
		
		if (HandsTriangle(Attacker,Defender))
			DamageModifier+=50;
		if (WeaponTriangle(Attacker,Defender))
			DamageModifier+=20;
		if (EquipTriangleOffensive(Attacker,Defender))
			DamageModifier+=25;
		if (EquipTriangleDefensive(Attacker,Defender))
			DamageModifier-=25;
		
		return DamageModifier;
	}
	
static	bool HandsTriangle (TroopScript Attacker, TroopScript Defender){
		bool bonusattack = false;
		NumberOfHands atkhands = Attacker.GetHands();
		NumberOfHands defhands = Defender.GetHands();
		
		if ((atkhands == NumberOfHands.OneHanded && defhands == NumberOfHands.Bow)||
		    (atkhands == NumberOfHands.TwoHanded && defhands == NumberOfHands.OneHanded)||
		    (atkhands == NumberOfHands.Bow && defhands == NumberOfHands.TwoHanded))
			bonusattack = true;
		/*
		 Axe>Pole>Sword(estoc)>Axe
		 2H weapon > 1H weapon > Ranged > 2H weapon
		 Light Armor > Slashing Weapon > No Armor > Bludgeoning Weapons > Heavy Armor > Piercing Weapons > Light Armor
*/	
		
		return bonusattack;
	}
	
static	bool WeaponTriangle (TroopScript Attacker, TroopScript Defender){
		bool bonusattack = false;
		WeaponType atkwpn = Attacker.GetWeapon();
		WeaponType defwpn = Defender.GetWeapon();
		if ((atkwpn == WeaponType.Spear && defwpn == WeaponType.Sword) ||
		    (atkwpn == WeaponType.Sword && defwpn == WeaponType.Axe) ||
		    (atkwpn == WeaponType.Axe && defwpn == WeaponType.Spear))
			bonusattack = true;
		return bonusattack;
	}
	
static	bool EquipTriangleOffensive (TroopScript Attacker, TroopScript Defender){
		bool bonusattack = false;
		WeaponType atkwpn = Attacker.GetWeapon();
		ArmorType defarmr = Defender.GetArmor();
		if ((atkwpn == WeaponType.Sword && defarmr == ArmorType.NoArmor)||
		    (atkwpn == WeaponType.Axe && defarmr == ArmorType.NoArmor)||
		    (atkwpn == WeaponType.Mace && defarmr == ArmorType.Heavy)||
		    (atkwpn == WeaponType.Spear && defarmr == ArmorType.Light)||
		    (atkwpn == WeaponType.Bow && defarmr == ArmorType.NoArmor))
			bonusattack = true;
		return bonusattack;
	}
	
static	bool EquipTriangleDefensive (TroopScript Attacker, TroopScript Defender){
		bool bonusdefence = false;
		WeaponType atkwpn = Attacker.GetWeapon();
		ArmorType defarmr = Defender.GetArmor();
		if ((atkwpn == WeaponType.Sword && defarmr == ArmorType.Light)||
		    (atkwpn == WeaponType.Sword && defarmr == ArmorType.Heavy)||
		    (atkwpn == WeaponType.Axe && defarmr == ArmorType.Heavy)||
		    (atkwpn == WeaponType.Spear && defarmr == ArmorType.Heavy)||
		    (atkwpn == WeaponType.Mace && defarmr == ArmorType.NoArmor))
			bonusdefence = true;
		return bonusdefence;
	}



}
