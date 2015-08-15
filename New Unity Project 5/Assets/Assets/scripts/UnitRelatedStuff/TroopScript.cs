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

	string CaptainName;
	string CaptainSurname;

	int baseAttack;
	int baseDefence;
	int baseHitPoints;
	int baseSpeed;
	int People;
	int WoundedPeople;
	int baseMovement = 10;
	int baseAttackRange = 1;


	Weaponry WeaponAdopted;
	Armory ArmorAdopted;

	string WeaponName;
	string ArmorName;

	//stuff to make it work, not related to rpg parts
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







			//======================================
			//              GETTERS
			//======================================



	public NumberOfHands GetHands (){

				return WeaponAdopted.handsUsed;
			}

	public WeaponType GetWeapon (){
				return WeaponAdopted.weapType;
			}

	public ArmorType GetArmor(){
				return ArmorAdopted.armrType;
			}

	public int GetSpeed(){
				return Mathf.RoundToInt(baseSpeed*WeaponAdopted.speedModifier*ArmorAdopted.speedModifier);
			}

	public int GetAttack(){
		return baseAttack+WeaponAdopted.Attack+ArmorAdopted.Attack;
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

	public string GetName(){
		return CaptainName;
	}

	public string GetSurname(){
		return CaptainSurname;
	}

	public int GetMovement(){
		return Mathf.RoundToInt(baseMovement*WeaponAdopted.speedModifier*ArmorAdopted.speedModifier);
	}
	public int GetMaxRange(){
		return baseAttackRange+WeaponAdopted.maxRange;
	}
	public int GetMinRange(){
		return baseAttackRange+WeaponAdopted.minRange;
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

	public void SetName (string name){
		CaptainName = name;
	}

	public void SetSurname(string srname){
		CaptainSurname = srname;
	}

	public void SetMovement(int Mov){
		baseMovement = Mov;
	}

	public void SetBaseRange (int range){
		baseAttackRange = range;
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
	
	public virtual void TurnOnGUI () {
		
	}
	
	/*	public void OnGUI() {
		//display HP just to check shit
		Vector3 location = Camera.main.WorldToScreenPoint(transform.position) + Vector3.up * 35;
		GUI.TextArea(new Rect(location.x, Screen.height - location.y, 30, 35), "hp:" + HP.ToString());
	}*/


}