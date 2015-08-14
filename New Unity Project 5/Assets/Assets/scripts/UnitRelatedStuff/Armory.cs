using UnityEngine;
using System.Collections;

public enum ArmoryName{
	TestPlateArmor,
	TestChainMail,
	TestBrigandine,
	TestGambeson,
	TestConfortableClothes
}



public class Armory : Equipment {


	public static Armory FromName (ArmoryName name){
			Armory ret = new Armory();
			switch(name){
		case ArmoryName.TestPlateArmor:
				ret = new Armory(){
				NameOfTheEquip = ArmoryName.TestPlateArmor.ToString(),

					Attack = 0, 
					Defence = 10,
					minRange = 0,
					maxRange = 1,
					speedModifier = 0.6f,
					movModifier = 0.6f,
					handsUsed = NumberOfHands.NotAWeapon,
					weapType = WeaponType.NotAWeapon,
					armrType = ArmorType.Heavy
				};
				break;
		case ArmoryName.TestChainMail:
			ret = new Armory(){
				NameOfTheEquip = ArmoryName.TestChainMail.ToString(),

				Attack = 0, 
				Defence = 7,
				minRange = 0,
				maxRange = 1,
				speedModifier = 0.9f,
				movModifier = 0.95f,
				handsUsed = NumberOfHands.NotAWeapon,
				weapType = WeaponType.NotAWeapon,
				armrType = ArmorType.Heavy
			};
			break;
		case ArmoryName.TestBrigandine:
			ret = new Armory(){
				NameOfTheEquip = ArmoryName.TestBrigandine.ToString(),

				Attack = 0, 
				Defence = 6,
				minRange = 0,
				maxRange = 1,
				speedModifier = 0.9f,
				movModifier = 0.99f,
				handsUsed = NumberOfHands.NotAWeapon,
				weapType = WeaponType.NotAWeapon,
				armrType = ArmorType.Light
			};
			break;
		case ArmoryName.TestGambeson:
			ret = new Armory(){
				NameOfTheEquip = ArmoryName.TestGambeson.ToString(),

				Attack = 0, 
				Defence = 10,
				minRange = 0,
				maxRange = 1,
				speedModifier = 1f,
				movModifier = 1f,
				handsUsed = NumberOfHands.NotAWeapon,
				weapType = WeaponType.NotAWeapon,
				armrType = ArmorType.Light
			};
			break;
		case ArmoryName.TestConfortableClothes:
			ret = new Armory(){
				NameOfTheEquip = ArmoryName.TestConfortableClothes.ToString(),

				Attack = 0, 
				Defence = 2,
				minRange = 0,
				maxRange = 1,
				speedModifier = 1,
				movModifier = 1,
				handsUsed = NumberOfHands.NotAWeapon,
				weapType = WeaponType.NotAWeapon,
				armrType = ArmorType.NoArmor
			};
			break;
			}
			return ret;
		}
		
	}
