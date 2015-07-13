using UnityEngine;
using System.Collections;


	public enum TypeOfWeapon {
		Spear,
		Sword,
		Hammer
	}
	
	public enum WeaponKeyy {
		//Spear
		LongSpear,
		ShortSpear,
		SpearySpear,
		//Sword
		LongSword,
		ShortSword,
		EdgySword,
		//hammer
		HeavyHammer,
		ToyHammer,
		ActuallyNotAnHammer
}

public class WeaponTestData : EquipmentClass {
	public TypeOfWeapon type;
	
	public static WeaponTestData FromKey (WeaponKeyy key) {
		WeaponTestData ret = new WeaponTestData();
		switch(key) {

		case WeaponKeyy.ActuallyNotAnHammer:
			ret = new WeaponTestData() {
				type = TypeOfWeapon.Hammer,
				EquipName = "Physician Hammer",
				hitmodifier = 0.2f,
				 dodgemodifier = 0.0f,
				 movementmodifier = 0,
				 attackrangemodifier = 0,
				damagereduction = 0,
				attack = 5,
				 attackrng = 2

			};			
			break;
		case WeaponKeyy.HeavyHammer:
			ret = new WeaponTestData() {
				type = TypeOfWeapon.Hammer,
				EquipName = "Geologyst Hammer",
				hitmodifier = 0.5f,
				dodgemodifier = 0.2f,
				movementmodifier = 0,
				attackrangemodifier = 0,
				damagereduction = 0,
				attack = 10,
				attackrng = 1
				
			};			
			break;
		case WeaponKeyy.ToyHammer:
			ret = new WeaponTestData() {
				type = TypeOfWeapon.Hammer,
				EquipName = "MC Hammer",
				hitmodifier = 0.1f,
				dodgemodifier = 0.0f,
				movementmodifier = 0,
				attackrangemodifier = 0,
				damagereduction = 0,
				attack = 1,
				attackrng = 0
				
			};			
			break;
		}
		return ret;
	}
}
