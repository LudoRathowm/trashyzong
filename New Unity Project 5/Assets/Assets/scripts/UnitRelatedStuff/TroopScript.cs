using UnityEngine;
using System.Collections;

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

	NumberOfHands HandsUsedByTheWeapon; //these are to become private later on
	WeaponType TypeOfWeapon;
	ArmorType TypeOfArmor;

	//the constructor

	public TroopScript (string CptName, string CptSurname, int Atk, int Def, int HP, int spd, int Soldiers, int Wounded, NumberOfHands hands, WeaponType weap, ArmorType armor){
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

}