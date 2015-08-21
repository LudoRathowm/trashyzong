using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum NumberOfHands {
	OneHanded,
	TwoHanded,
	Bow, //means ranged not bow
	NotAWeapon
}

public enum WeaponType {
	Spear,
	Sword,
	Mace,
	Axe,
	Bow,
	Crossbow,
	NotAWeapon
}

public enum ArmorType {
	Light,
	Heavy,
	NoArmor,
	NotAnArmor
}



public class TroopScript : MonoBehaviour {

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

	//just for the debug
	string WeaponName;
	string ArmorName;
	string LeaderName; 

	//stuff to make it work, not related to rpg parts
	bool chargedWeapon = false; //for crossbows
	bool isPhalanxing = false; //for AI and pathfinding
	public int actionPoints = 2;
	public Vector2 gridPosition = Vector2.zero;
	
	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;
	
	public bool moving = false;
	public bool attacking = false;

   








	//the constructor

/*	public TroopScript (string CptName, string CptSurname, int Atk, int Def, int HP, int spd, int Soldiers, int Wounded, NumberOfHands hands, WeaponType weap, ArmorType armor){
		CaptainName = CptName;
		CaptainSurname = CptSurname;
		Attack = Atk;
		Defence = Def;
		HitPoints = HP;
		Speed = spd;
		NumberOfSoldiers = Soldiers;
		NumberOfWounded = Wounded;
		HandsUsedByTheWeapon = hands;
		TypeOfWeapon = weap;
		TypeOfArmor = armor;
	}
*/




	public int ReturnNumberOfPeopleToAttack (){

		int attackers = Mathf.RoundToInt(People+WoundedPeople*0.7f);
		float muhPower = 0.94f + Leader.GetMuhReturns();
		int Total = Mathf.RoundToInt(Mathf.Pow(attackers,muhPower));
		return Total;
	}


			//======================================
			//              GETTERS
			//======================================



	public NumberOfHands GetHands (){

				return WeaponAdopted.handsUsed;
			}

	public Weaponry GetWeapon (){
				return WeaponAdopted;
			}

	public Armory GetArmor(){
				return ArmorAdopted;
			}

	public int GetSpeed(){
				return Mathf.RoundToInt(baseSpeed*WeaponAdopted.speedModifier*ArmorAdopted.speedModifier);
			}

	public int GetAttack(){
		int attack = 0;
		if (WeaponAdopted.weapType != WeaponType.Crossbow)
		attack = baseAttack+WeaponAdopted.Attack+ArmorAdopted.Attack;
		else if (WeaponAdopted.weapType == WeaponType.Crossbow)
		attack = WeaponAdopted.Attack+ArmorAdopted.Attack;
		return attack;
	}

	public int GetDefence(){
		return baseDefence+WeaponAdopted.Defence+ArmorAdopted.Defence;
	}

	public int GetHitpoints(){
		return baseHitPoints+ArmorAdopted.HPModifier;
	}

	public int GetNumber(){
		return People;
	}

	public int GetWounded(){
		return WoundedPeople;
	}

	public Chief GetChief(){
		return Leader;
	}

	public string GetName(){
		return Leader.GetName();
	}

	public string GetSurname(){
		return Leader.GetSurname();
	}
	public int GetBaseMovement (){
		return baseMovement;
	}
	public int GetMovement(){
		return Mathf.RoundToInt(baseMovement*WeaponAdopted.movModifier*ArmorAdopted.movModifier);
	}
	public int GetMaxRange(){
		return baseAttackRange+WeaponAdopted.maxRange;
	}
	public int GetMinRange(){
		return baseAttackRange+WeaponAdopted.minRange;
	}

	public bool GetCharge(){
		return chargedWeapon;
	}

	public bool GetPhalanx(){
		return isPhalanxing;
	}


		    //======================================
		    //             SETTERS
		    //======================================

	public void SetWeapon (Weaponry weapon){
		WeaponAdopted = weapon;
		}

	public void SetArmor (Armory armor){
			ArmorAdopted = armor;
		}

	public void SetBaseSpeed(int spd){
			baseSpeed = spd;
		}

	public void SetBaseAttack (int atk)	{
		baseAttack = atk;
	}

	public void SetBaseDefence (int def){
		baseDefence = def;
	}

	public void SetBaseHitpoints (int hp){
		baseHitPoints = hp;
	}

	public void SetNumber (int people){
		People = people;
	}

	public void SetWounded (int wounded){
		WoundedPeople = wounded;
	}

	public void SetChief (Chief leader){
		Leader = leader;
	}

	public void SetName (string name){
		Leader.SetName(name);
	}

	public void SetSurname(string srname){
		Leader.SetSurname(srname);
	}

	public void SetBaseMovement(int Mov){
		baseMovement = Mov;
	}

	public void SetBaseRange (int range){
		baseAttackRange = range;
	}

	public void SetCharge (bool charge){
		chargedWeapon = charge;
	}

	public void SetPhalanx (bool phalanx){
		isPhalanxing = phalanx;
	}


	//movement animation
	public List<Vector3> positionQueue = new List<Vector3>();	
	//
	
	void Awake () {
		moveDestination = transform.position;

	}
	
	
	// Update is called once per frame
	public virtual void Update () {		
		WeaponName = WeaponAdopted.NameOfTheEquip;
		ArmorName = ArmorAdopted.NameOfTheEquip;
		LeaderName = Leader.GetName();
		if (GetNumber()+GetWounded() <= 0) {
			transform.rotation = Quaternion.Euler(new Vector3(90,0,0)); //yer ded nigga
			transform.GetComponent<Renderer>().material.color = Color.red; // and bleeding
		}
	}
	
	public virtual void TurnUpdate () {
		if (actionPoints <= 0) {
			actionPoints = 2; //cbf doing atk points, move point,etc.. will change l8r
			moving = false;
			attacking = false;			
			GameManager.instance.nextTurn();
		}
	}
	
//	public virtual void TurnOnGUI () {
//	}
//
//
//	public void OnGUI() {
//		if (TurnOnGUI)
//		//display HP just to check shit
//		Vector3 location = Camera.main.WorldToScreenPoint(transform.position) + Vector3.up * 35;
//		GUI.TextArea(new Rect(location.x, Screen.height - location.y, 100, 40), "hp:" + People.ToString());
//	}


}