using UnityEngine;
using System.Collections;

//public enum WeaponryHandsUsed {
//	One,
//	Two
//}

public enum WeaponryName{
	TestSword,
	TestAxe,
	TestHammer,
	TestPike,
	TestBow,
	TestCrossbow
}




public class Weaponry : Equipment {
	//public WeaponryHandsUsed handsUsed;

	public static Weaponry FromName (WeaponryName name){
		Weaponry ret = new Weaponry();
		switch(name){
		case WeaponryName.TestSword:
			ret = new Weaponry(){
				NameOfTheEquip = WeaponryName.TestSword.ToString(),
				Attack = 10, 
				Defence = 0,
				minRange = 0,
				maxRange = 1,
				speedModifier = 0.8f,
				movModifier = 0.8f,
				handsUsed = NumberOfHands.OneHanded,
				weapType = WeaponType.Sword,
				armrType = ArmorType.NotAnArmor		
					};
			break;
		case WeaponryName.TestAxe:
			ret = new Weaponry(){
				NameOfTheEquip = WeaponryName.TestAxe.ToString(),

				Attack = 12, 
				Defence = 1,
				minRange = 0,
				maxRange = 1,
				speedModifier = 0.6f,
				movModifier = 0.6f,
				handsUsed = NumberOfHands.OneHanded,
				weapType = WeaponType.Axe,
				armrType = ArmorType.NotAnArmor		
			};
			break;
		case WeaponryName.TestHammer:
			ret = new Weaponry(){
				NameOfTheEquip = WeaponryName.TestHammer.ToString(),

				Attack = 8, 
				Defence = 0,
				minRange = 0,
				maxRange = 1,
				speedModifier = 0.7f,
				movModifier = 0.7f,
				handsUsed = NumberOfHands.TwoHanded,
				weapType = WeaponType.Mace,
				armrType = ArmorType.NotAnArmor		
			};
			break;
		case WeaponryName.TestPike:
			ret = new Weaponry(){
				NameOfTheEquip = WeaponryName.TestPike.ToString(),

				Attack = 11, 
				Defence = 0,
				minRange = 0,
				maxRange = 1,
				speedModifier = 0.9f,
				movModifier = 0.7f,
				handsUsed = NumberOfHands.OneHanded,
				weapType = WeaponType.Spear,
				armrType = ArmorType.NotAnArmor		
							
			};
			break;
		case WeaponryName.TestBow:
			ret = new Weaponry(){
				NameOfTheEquip = WeaponryName.TestBow.ToString(),

				Attack = 5, 
				Defence = 0,
				minRange = 2,
				maxRange = 6,
				speedModifier = 0.3f,
				movModifier = 0.65f,
				handsUsed = NumberOfHands.Bow,
				weapType = WeaponType.Bow,
				armrType = ArmorType.NotAnArmor		

			};
			break;
		case WeaponryName.TestCrossbow:
			ret = new Weaponry(){
				NameOfTheEquip = WeaponryName.TestCrossbow.ToString(),

				Attack = 8, 
				Defence = 0,
				minRange = 0,
				maxRange = 4,
				speedModifier = 0.2f,
				movModifier = 0.71f,
				handsUsed = NumberOfHands.Bow,
				weapType = WeaponType.Crossbow,
				armrType = ArmorType.NotAnArmor		
				
			};

			break;
		}
		return ret;
	}

}