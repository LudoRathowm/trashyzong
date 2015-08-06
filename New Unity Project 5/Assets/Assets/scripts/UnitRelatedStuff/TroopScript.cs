using UnityEngine;
using System.Collections;

public enum NumberOfHands {
	OneHanded,
	TwoHanded
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











	public void SetHands (NumberOfHands hands){
		HandsUsedByTheWeapon = hands;
	}

	public NumberOfHands GetHands (){
		return HandsUsedByTheWeapon;
	}

	public void SetWeapon (WeaponType weapon){
		TypeOfWeapon = weapon;
	}

	public WeaponType GetWeapon (){
		return TypeOfWeapon;
	}
	public void SetArmor (ArmorType armor){
		TypeOfArmor = armor;
	}
	public ArmorType GetArmor(){
		return TypeOfArmor;
	}

}
