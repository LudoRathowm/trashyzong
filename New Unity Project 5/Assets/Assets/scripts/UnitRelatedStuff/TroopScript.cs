using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum NumberOfHands {
	OneHanded,
	TwoHanded,
	Bow
}

public enum WeaponType {
	Spear,
	Sword,
	Mace,
	Axe,
	Bow
}

public enum ArmorType {
	Light,
	Heavy,
	NoArmor
}



public class TroopScript : MonoBehaviour {

	string CaptainName;
	string CaptainSurname;

	int Attack;
	int Defence;
	int HitPoints;
	int Speed;
	int NumberOfSoldiers;
	int NumberOfWounded;
	int baseMovement = 5;
	int AttackRange = 1;

	NumberOfHands HandsUsedByTheWeapon; //these are to become private later on
	WeaponType TypeOfWeapon;
	ArmorType TypeOfArmor;


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
				return HandsUsedByTheWeapon;
			}

	public WeaponType GetWeapon (){
				return TypeOfWeapon;
			}

	public ArmorType GetArmor(){
				return TypeOfArmor;
			}

	public int GetSpeed(){
				return Speed;
			}

	public int GetAttack(){
		return Attack;
	}

	public int GetDefence(){
		return Defence;
	}

	public int GetHitpoints(){
		return HitPoints;
	}

	public int GetNumber(){
		return NumberOfSoldiers;
	}

	public int GetWounded(){
		return NumberOfWounded;
	}

	public string GetName(){
		return CaptainName;
	}

	public string GetSurname(){
		return CaptainSurname;
	}

	public int GetMovement(){
		return baseMovement;
	}
	public int GetRange(){
		return AttackRange;
	}

		    //======================================
		    //             SETTERS
		    //======================================

	public void SetHands (NumberOfHands hands){
			HandsUsedByTheWeapon = hands;
		}

	public void SetWeapon (WeaponType weapon){
			TypeOfWeapon = weapon;
		}

	public void SetArmor (ArmorType armor){
			TypeOfArmor = armor;
		}

	public void SetSpeed(int spd){
			Speed = spd;
		}

	public void SetAttack (int atk)	{
		Attack = atk;
	}

	public void SetDefence (int def){
		Defence = def;
	}

	public void SetHitpoints (int hp){
		HitPoints = hp;
	}

	public void SetNumber(int nmbr){
		NumberOfSoldiers = nmbr;
	}

	public void SetWounded (int wndd){
		NumberOfWounded = wndd;
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

	public void SetRange (int range){
		AttackRange = range;
	}



	//movement animation
	public List<Vector3> positionQueue = new List<Vector3>();	
	//
	
	void Awake () {
		moveDestination = transform.position;
	}
	
	
	// Update is called once per frame
	public virtual void Update () {		
		if (HitPoints <= 0) {
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