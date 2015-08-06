using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
public class FightScript : MonoBehaviour {
	public int peeps;
	public int perline;
	public int avgatk;
	public int defpeeps;

	public bool recalculateshit = false;
	public bool nothardcoded = false;

	
	public int a;
	public int b;
	public int c;
	public int d;
	public int e;
	public List<int> f = new List<int>();

	public int Attackers;
	public int Defenders;
	public int DeadAttackers;
	public int DeadDefenders;
	public int WoundedAttackers;
	public int WoundedDefenders;
	public TerrainWhereTheyFight muhTerrain;

	public WarriorClass AttackersClass;
	public WarriorClass DefendersClass;

	int attackerhp;
	int attackeratk;
	int attackerdef;
	int attackerspeed;
	int defenderhp;
	int defenderatk;
	int defenderdef;
	int defenderspeed;
	int frontliners;
	int attackerdamage;
	int defenderdamage;

	List<int> defenderdmg = new List<int>();
	List<int> attackerdmg = new List<int>();
	List<int> myList = new List<int>();

	int AttackLines;
	int AttackLeftOvers;
	int DefendLines;
	int DefendLeftOvers;


	
	public enum TerrainWhereTheyFight{
		Grassland,
		ThickForest,
		SaltDesert
	}

	public enum WarriorClass {
		Pikeman,
		Swordman,
		Hammerman
	}

	// Use this for initialization
	void Start () {
		Debug.Log ("Your 50 Swordmen attack 50 enemy Pikemen on: Grassland. The results are: your losses (killed, wounded) 14, 8 their losses 21,13");
		Debug.Log ("Your 50 Swordmen attack 5 enemy Pikemen on: Grassland. The results are: your losses (killed, wounded) 0, 3 their losses 5,0");
		Debug.Log ("Your 5 Swordmen attack 50 enemy Pikemen on: Grassland. The results are: your losses (killed, wounded) 5, 0 their losses 1,2");
		Debug.Log ("Your 50 Swordmen attack 50 enemy Pikemen on: ThickForest. The results are: your losses (killed, wounded) 6, 10 their losses 10,14");
	}

	void Update(){
		if (a>0&b>0&c>0&d>0)
		f=CalculateDamageOnDefendingLines(a,b,c,d,e);

		SetClasses();
		SetTerrain();
		if (nothardcoded){
			nothardcoded = false;
			Combat(peeps,perline,avgatk,defpeeps);
		}


		if (recalculateshit){
		ActualFighting();
			Triangle();
			ReceivedAttack();
			recalculateshit = false;
		}
	}

	int NumberOfLines (int numberOfpeople, int peoplePerLine){
		return numberOfpeople/peoplePerLine;
	}

	int LeftOvers (int numberOfpeople, int numberOfLines, int peoplePerLine){
		int peopleonline = numberOfLines*peoplePerLine;
		return (numberOfpeople-peopleonline);

	}

	/*List<int> GenerateLines (int NumberOfPeople, int NumberOfLines, int PeoplePerLine){
		int Leftovers = NumberOfPeople-(NumberOfLines*PeoplePerLine);
		for (int i=1;i<NumberOfLines+1;i++)
			Debug.Log("HERE NEEDS WORK");
	}*/

	//ZeroOrOne has value 0 if you are calculating to attack first, else has value 1.
	int GenerateDamage (int Lines, int peoplePerLine, int Leftovers, int AveragedAttack, int ZeroOrOne){
		int TotalAttack = 0;
		for (float i = 1;i<Lines+1;i++)
			TotalAttack+=Mathf.FloorToInt(AveragedAttack*peoplePerLine*(1/(i+ZeroOrOne)));
		if (Leftovers>0)
			TotalAttack+=(Mathf.FloorToInt(AveragedAttack*Leftovers*(1/((float)Lines+ZeroOrOne+1))));
		return TotalAttack;
	}

	/*WHAT I WANT: 
      1. You calculate the damage TOTAL
      2. You calculate the lines of the people
      3. You calculate the damage received per person
      4. frontline: 100%dmg, second line 50%, third line 33%, etc..

*/
	/*List<int> DamagePerLine (int Damage,int People, List<int> peopleOnTheLine){
		int DamagePerPerson = Damage/People;
		List<int> dmgperline = new List<int>();
		for (int i = 0;i<peopleOnTheLine.Count;i++)
			dmgperline.Add(DamagePerPerson*(1/(i+1)));
		return dmgperline;		
	}*/

	List<int> DedWoundedFine(List<int> DamageOnLines, List<int> Hp){
		List<int> HPStatus = new List<int>();
		//0 = fine, 1 = wounded, 2 = dead
		for (int i=0;i<Hp.Count;i++){
			int damagepercent = Mathf.FloorToInt(((float)DamageOnLines[i]/Hp[i])*100);
			if (damagepercent <34)
				HPStatus.Add (0);
			if (damagepercent>33&&damagepercent<67)
				HPStatus.Add(1);
			if (damagepercent>66)
				HPStatus.Add(2);
		}
		return HPStatus;
	}

	List<int> CalculateDamageOnDefendingLines (int Attackers, int Defenders, int PeoplePerLine, int AveragedAttack, int FirstOrSecond){
		int _AttackingLines = NumberOfLines(Attackers,PeoplePerLine);
		int _DefendingLines = NumberOfLines(Defenders,PeoplePerLine);
		int _AttackLeftOvers = LeftOvers(Attackers,_AttackingLines,PeoplePerLine);
		int _DefendLeftOvers = LeftOvers(Defenders,_DefendingLines,PeoplePerLine);
		int Damage = GenerateDamage(_AttackingLines,PeoplePerLine,_AttackLeftOvers,AveragedAttack,FirstOrSecond);
		int AdjustedDamage = Mathf.FloorToInt(Damage*((float)Attackers/(float)Defenders));
		Debug.Log(AdjustedDamage);
		List<int> DamageOnDefenders = new List<int>();
		for (int i = 0;i<_DefendingLines;i++)
			DamageOnDefenders.Add(Mathf.FloorToInt(AdjustedDamage/((float)i+1)));
		if (_DefendLeftOvers>0)
			DamageOnDefenders.Add(Mathf.FloorToInt(AdjustedDamage/((float)_DefendingLines)));
		return DamageOnDefenders;
	}

	void Combat (int NumberOfPeople, int PeoplePerLine, int averagedAttack, int PeopleBeingAttacked){
	int _NumberOfLines = NumberOfLines(NumberOfPeople,PeoplePerLine);
		int _LinesAttacked = NumberOfLines(PeopleBeingAttacked,PeoplePerLine);
		float Damage = GenerateDamage(_NumberOfLines,PeoplePerLine,LeftOvers(NumberOfPeople,_NumberOfLines,PeoplePerLine),averagedAttack,0);
		int GettingAttackedLeftovers = LeftOvers (PeopleBeingAttacked,_LinesAttacked,PeoplePerLine);
		Debug.Log ("number of lines: "+_NumberOfLines);
		Debug.Log ("total dmg: "+Damage);

		List<int> DmgperLineTEMP = new List<int>();
			for (int i=0;i<_NumberOfLines;i++){
				DmgperLineTEMP.Add( Mathf.FloorToInt(Damage/((float)i+1)));		
			Debug.Log("ACTUAL STUFF: "+DmgperLineTEMP[i]);
			}
		if (GettingAttackedLeftovers>0)
			DmgperLineTEMP.Add(Mathf.FloorToInt(Damage/((_NumberOfLines+1))));
			                   List <int> PostDamageLists = new List<int>();


	}


	/*
	 how this is going to work:
1. take in the averaged speed for attacker and attacked
2. once it's decided who strikes first, you take in terrain, etc.. to decide the entity of the attack (hit chance per attacker, weapon type, atk per atker,etc..)
3. you take in terrain,etc.. to decide the entity of the defender (dodge chance per defender, etc..)
4. you make those clash, considering the weapon/armor triangle
5. repeat for the defender with adjusted numbers
*/
	void ActualFighting (){
	AttackLines = Attackers/frontliners;
	AttackLeftOvers = Attackers-(AttackLines*frontliners);
	DefendLines = Defenders/frontliners;
	DefendLeftOvers = Defenders-(DefendLines*frontliners);

		bool atkrsatk = AttackerStrikesFirst(attackerspeed,defenderspeed);
		if (atkrsatk){

			for (float i = 1;i<AttackLines+1;i++)
					attackerdmg.Add(Mathf.FloorToInt(attackeratk*frontliners*(1/i)));
			if (AttackLeftOvers>0){
				attackerdmg.Add(Mathf.FloorToInt(attackeratk*AttackLeftOvers*(1/((float)AttackLines+1))));
			Debug.Log(AttackLeftOvers);
			}
			for (float k = 1; k < DefendLines+1;k++)
				defenderdmg.Add(Mathf.FloorToInt(defenderatk*frontliners*(1/k)));
			if (DefendLeftOvers>0)
				defenderdmg.Add(Mathf.FloorToInt(defenderatk*DefendLines*(1/((float)DefendLines+2))));
		}
		else {

			for (float w = 1;w<(DefendLines+1);w++){
				//this is correct. consider the triangle
				defenderdmg.Add(Mathf.FloorToInt(defenderatk*frontliners*(1/w)));
			//	Debug.Log ("defenderatk: "+defenderatk+", frontliners: "+frontliners+", w: "+w+",damage is: "+ defenderdmg[(int)w-1]);
			}

			if (DefendLeftOvers>0)
				defenderdmg.Add(Mathf.FloorToInt(defenderatk*DefendLeftOvers*(1/((float)DefendLines+1))));

			for (float z = 1;z < AttackLines+1;z++)
				attackerdmg.Add(Mathf.FloorToInt(attackeratk*frontliners*(1/z)));
			if (AttackLeftOvers>0)
				attackerdmg.Add(Mathf.FloorToInt(attackeratk*AttackLeftOvers*(1/((float)AttackLines+2))));

		}

		}

	void Triangle(){
		for (int i = 0; i<attackerdmg.Count;i++){
		if (AttackersClass == WarriorClass.Swordman && DefendersClass == WarriorClass.Pikeman)
			attackerdmg[i] += attackerdmg[i]/100*30;
	else	if (AttackersClass == WarriorClass.Pikeman && DefendersClass == WarriorClass.Hammerman)
			attackerdmg[i] += attackerdmg[i]/100*30;
	else	if (AttackersClass == WarriorClass.Hammerman && DefendersClass == WarriorClass.Swordman)
			attackerdmg[i] += attackerdmg[i]/100*30;}
		for (int w = 0;w<defenderdmg.Count;w++){
		if (DefendersClass == WarriorClass.Swordman && AttackersClass == WarriorClass.Pikeman)
			defenderdmg[w] += defenderdmg[w]/100*30;
	else	if (DefendersClass == WarriorClass.Pikeman && AttackersClass == WarriorClass.Hammerman)
			defenderdmg[w] += defenderdmg[w]/100*30;
	else	if (DefendersClass == WarriorClass.Hammerman && AttackersClass == WarriorClass.Swordman)
			defenderdmg[w] += defenderdmg[w]/100*30;
		}}
 
	void ReceivedAttack(){
		//defenderdmgreceivedtrashcan
		for (int i=1; i<(Attackers/frontliners)+1;i++){

		}







	
		/*
		int numberoflines = Attackers/frontliners;
		Debug.Log("number of lines "+numberoflines);
	int sdasd =	((defenderdamage/numberoflines)/(frontliners));
		for (int i=1;i<numberoflines+1;i++){
			int zongmaster = sdasd/((1+i)*2);
			Debug.Log("Line "+i +" damage per unit is: " + zongmaster);
		}
		//need to make it so that line 1: 50%, line 2: 33%, line3: 25%, etc..
		Debug.Log ("dmg per line "+sdasd);
		int peratkerreceived;
		int perdefenderreceived;
		peratkerreceived = defenderdamage/(Attackers*attackerdef);
		perdefenderreceived = attackerdamage/(Defenders*defenderdef);
		for (int i = 0;i < Attackers; i++){
			Debug.Log("peratk " + peratkerreceived);
			int walao = peratkerreceived*frontliners	;
			Debug.Log(walao);
		}
*/
	}


	bool AttackerStrikesFirst (int atkavgspeed, int defavgspeed ){

		return atkavgspeed> defavgspeed;
	}

	void SetClasses (){
		if (AttackersClass == WarriorClass.Pikeman){
			attackeratk = 10;
			attackerdef = 5;
			attackerspeed = 6;
			attackerhp = 50;
	}
		else if (AttackersClass == WarriorClass.Swordman){
			attackeratk = 13;
			attackerdef = 2;
			attackerspeed = 8;
			attackerhp = 30;
		}
		else if (AttackersClass == WarriorClass.Hammerman){
			attackeratk = 6;
			attackerdef = 10;
			attackerspeed = 4;
			attackerhp = 70;
		}
		if (DefendersClass == WarriorClass.Pikeman){
			defenderatk = 10;
			defenderdef = 5;
			defenderspeed = 6;
			defenderhp = 50;
		}
		else if (DefendersClass == WarriorClass.Swordman){
			defenderatk = 13;
			defenderdef = 2;
			defenderspeed = 8;
			defenderhp = 30;
		}
		else if (DefendersClass == WarriorClass.Hammerman){
			defenderatk = 6;
			defenderdef = 10;
			defenderspeed = 4;
			defenderhp = 70;
		}
	}
	 
	void SetTerrain (){
		if (muhTerrain == TerrainWhereTheyFight.Grassland)
			frontliners = 20;
		else if (muhTerrain == TerrainWhereTheyFight.ThickForest)
			frontliners = 5;
		else if (muhTerrain == TerrainWhereTheyFight.SaltDesert)
			frontliners = 30;
	}

	void EquipmentTriangle (TroopScript Attacker, TroopScript Defender){

		NumberOfHands atkhands = Attacker.GetHands();
		WeaponType atkwp = Attacker.GetWeapon();

		NumberOfHands defhands = Defender.GetHands();
		WeaponType defwp = Defender.GetWeapon();
		ArmorType defarmr = Defender.GetArmor();


		/*
		 Axe>Pole>Sword(estoc)>Axe
		 2H weapon > 1H weapon > Ranged > 2H weapon
		 Light Armor > Slashing Weapon > No Armor > Bludgeoning Weapons > Heavy Armor > Piercing Weapons > Light Armor
*/
	}


}
