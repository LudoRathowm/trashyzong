using UnityEngine;
using System.Collections;

public class NewFightScript : MonoBehaviour {


	public static void ActualFightingScript (TroopScript Attacker, TroopScript Defender, Tile muhTerrain, float SkillModifier){
		float AttackerBattlefieldEffect = 1; //still to impement
		float DefenderBattlefieldEffect = 1; //still to impement
		int PeoplePerLine = muhTerrain.frontLiners;
		int AttackerBaseAttack = Attacker.GetClass().GetAttack();
		int AttackerCaptainAttack = Attacker.GetChief().GetAttack();
		int AttackerBaseDefense = Attacker.GetClass().GetDefense();
		int AttackerCaptainDefense = Attacker.GetChief().GetDefense();
		int AttackerAttackBuffModifier =  0; //still need to implement buffs ALSO NEED TO DIFFERENCIATE BETWEEN ATTACK AND COUNTER ATTACK REMEMBER
		int AttackerDefenseBuffModifier = 0; //still need to implement buffs
		int AttackerTroopSize = Attacker.GetNumber();
		float AttackerWeaponModifier = Attacker.GetWeapon().AttackModifier; //there is no weapon with atk modifiers for now;
		int AttackerFlatWeapon = Attacker.GetWeapon().Attack;
		bool AttackerFlatWeaponPhysical = Attacker.GetWeapon().physical;
		float AttackerSkillModifier = SkillModifier;
		float AttackerCaptainAbility = Attacker.GetChief().GetMuhReturns();
		bool AttackerisPhysical = Attacker.GetClass().GetIfItsPhysical();
		int AttackerBaseInt = Attacker.GetClass().GetIntelligence();
		int AttackerCaptainIntelligence = Attacker.GetChief().GetIntelligence();
		float AttackerMatkBuffModifier = 0; //stillneedtoimplementbuffs
		float AttackerMdefBuffModifier = 0; //^
		int AttackerMaxRange = Attacker.GetMaxRange();
		int AttackerMinRange = Attacker.GetMinRange();
		int DefenderBaseAttack = Defender.GetClass().GetAttack();
		int DefenderCaptainAttack = Defender.GetChief().GetAttack();
		int DefenderBaseDefense = Defender.GetClass().GetDefense();
		int DefenderCaptainDefense = Defender.GetChief().GetDefense();
		int DefenderAttackBuffModifier =  0; //still need to implement buffs
		int DefenderDefenseBuffModifier = 0; //still need to implement buffs
		int DefenderTroopSize = Defender.GetNumber();
		float DefenderWeaponModifier = Defender.GetWeapon().AttackModifier; //there is no weapon with atk modifiers for now;
		int DefenderFlatWeapon = Defender.GetWeapon().Attack;
		bool DefenderFlatWeaponPhysical = Defender.GetWeapon().physical;

		float DefenderCaptainAbility = Defender.GetChief().GetMuhReturns();
		bool DefenderisPhysical = Defender.GetClass().GetIfItsPhysical();
		int DefenderBaseInt = Defender.GetClass().GetIntelligence();
		int DefenderCaptainIntelligence = Defender.GetChief().GetIntelligence();
		int DefenderCounterAttackFromSkill = Defender.GetChief().GetCounterAttack();
		int DefenderCounterAttackFromEquip = Defender.GetWeapon().CounterAttackValue + Defender.GetArmor().CounterAttackValue;
		float DefenderMatkBuffModifier = 0; //stillneedtoimplementbuffs
		float DefenderMdefBuffModifier = 0; //^
		int DefenderMaxRange = Defender.GetMaxRange();
		int DefenderMinRange = Defender.GetMinRange();


		int DamageOnDefenders = FinalDamage(AttackerBaseAttack,AttackerCaptainAttack,AttackerAttackBuffModifier,DefenderBaseDefense,DefenderCaptainDefense,DefenderDefenseBuffModifier,AttackerTroopSize, AttackerWeaponModifier,AttackerFlatWeapon,AttackerFlatWeaponPhysical, AttackerSkillModifier,
		                                    AttackerBattlefieldEffect,PeoplePerLine,AttackerCaptainAbility,AttackerisPhysical,AttackerBaseInt, DefenderCaptainIntelligence, AttackerCaptainIntelligence, AttackerMatkBuffModifier, DefenderMdefBuffModifier);

		float CounterScaling = CounterAttackDamage(DefenderCounterAttackFromSkill,DefenderCounterAttackFromEquip);
		int DamageOnAttackers = FinalDamage(DefenderBaseAttack,DefenderCaptainAttack,DefenderAttackBuffModifier, AttackerBaseDefense, AttackerCaptainDefense, AttackerDefenseBuffModifier, DefenderTroopSize,DefenderWeaponModifier, DefenderFlatWeapon,DefenderFlatWeaponPhysical,CounterScaling,
		                                          DefenderBattlefieldEffect,PeoplePerLine,DefenderCaptainAbility,DefenderisPhysical, DefenderBaseInt, AttackerCaptainIntelligence, DefenderCaptainIntelligence, DefenderMatkBuffModifier, AttackerMdefBuffModifier);
	

	
		//deal with this
		Defender.SetNumber(Defender.GetNumber()-DamageOnDefenders);
		if (AttackerMaxRange<=DefenderMaxRange && AttackerMinRange>=DefenderMinRange)
		Attacker.SetNumber(Attacker.GetNumber()-DamageOnAttackers);
		Debug.Log("dmg:" +DamageOnDefenders);
		Debug.Log("counter:" +DamageOnAttackers);

	}


	 //atkbuffmodifier needs a method. first you need to check your ATKONLY COUNTERONLY buffs and then decide the final modifier
	    static int FinalDamage (int BaseAttack, int CptAttack, int AtkBuffModifier, int BaseDefense, int CptDefense, int DefBuffModifier,
	                        int TroopSize, float WeaponModifier, int FlatWeapon, bool FlatWeaponPhysical, float SkillModifier, float BattlefieldEffect, 
	                        int PeoplePerLine, float CptAbility, bool isPhysical, int BaseIntAtk, int IntCptDef, int IntCpt,float MatkBuffModifier,float MdefBuffModifier){
		int AdjustedTroopSize = CalculateAdjustedTroopSize (TroopSize,PeoplePerLine,CptAbility);
		int TroopDamage = 0;
		Debug.Log("is physical:" +isPhysical);
		if (isPhysical)
		TroopDamage = Mathf.RoundToInt	((AdjustedTroopSize*((float)CalculateAttack(BaseAttack,CptAttack,AtkBuffModifier)-(float)CalculateDefense(BaseDefense,CptDefense,DefBuffModifier))/10));
		else if (!isPhysical)
			TroopDamage = Mathf.RoundToInt((AdjustedTroopSize*(((float)CalculateMagicAttack(BaseIntAtk,IntCpt,MatkBuffModifier)-(float)CalculateMagicDefense(IntCptDef,MdefBuffModifier))/10)));
		Debug.Log("troop dmg"+TroopDamage);
		if (TroopDamage> TroopSize)
			TroopDamage = TroopSize;

		int FlatWeaponValue = 0;
		FlatWeaponValue = FlatWeapon*((isPhysical&&FlatWeaponPhysical||!isPhysical&&!FlatWeaponPhysical)?1:0);
		Debug.Log("weap:" +WeaponModifier);
		int Final = Mathf.RoundToInt(((TroopDamage*WeaponModifier+FlatWeaponValue)*SkillModifier)*BattlefieldEffect);

		return Final;
	}


	static float CounterAttackDamage ( int SkillBonus, int EquipBonus){
		return ((float)(30+SkillBonus+EquipBonus)/100);
	}



	static int CalculateAttack (int BaseAttack, int CptAttack, float BuffModifier){
		int value = Mathf.RoundToInt(BaseAttack+CptAttack*(1+BuffModifier)*10);
		Debug.Log("atk"+value);
		return value;
	}
	static int CalculateDefense (int BaseDefense, int CptDefense, float BuffModifier){
		int value = Mathf.RoundToInt(BaseDefense+CptDefense*(1+BuffModifier)*08f);
		Debug.Log("def"+value);
		return value;
	}
	static int CalculateMagicAttack (int BaseIntelligence, int CptIntelligence, float BuffModifier){
		return Mathf.RoundToInt(BaseIntelligence+CptIntelligence*(1+BuffModifier)*10);
	}
	static int CalculateMagicDefense(int CptIntelligence,float BuffModifier){
		return Mathf.RoundToInt(CptIntelligence*(1+BuffModifier)*7f);
	}


	static int CalculateAdjustedTroopSize (int TroopSize, int PeoplePerLine, float CptAbility){
		float terrainPower = PeoplePerLine*0.005f;
		float muhPower = 0.80f + CptAbility + terrainPower;

		int Total = Mathf.RoundToInt(Mathf.Pow(TroopSize,muhPower));
		Debug.Log("cpt pwr: "+CptAbility+" trnpwr: "+ terrainPower+ " total: "+Total);
		return Total;
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
		WeaponType atkwpn = Attacker.GetWeapon().weapType;
		WeaponType defwpn = Defender.GetWeapon().weapType;
		if ((atkwpn == WeaponType.Spear && defwpn == WeaponType.Sword) ||
		    (atkwpn == WeaponType.Sword && defwpn == WeaponType.Axe) ||
		    (atkwpn == WeaponType.Axe && defwpn == WeaponType.Spear))
			bonusattack = true;
		return bonusattack;
	}
	
	static	bool EquipTriangleOffensive (TroopScript Attacker, TroopScript Defender){
		bool bonusattack = false;
		WeaponType atkwpn = Attacker.GetWeapon().weapType;
		ArmorType defarmr = Defender.GetArmor().armrType;
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
		WeaponType atkwpn = Attacker.GetWeapon().weapType;
		ArmorType defarmr = Defender.GetArmor().armrType;
		if ((atkwpn == WeaponType.Sword && defarmr == ArmorType.Light)||
		    (atkwpn == WeaponType.Sword && defarmr == ArmorType.Heavy)||
		    (atkwpn == WeaponType.Axe && defarmr == ArmorType.Heavy)||
		    (atkwpn == WeaponType.Spear && defarmr == ArmorType.Heavy)||
		    (atkwpn == WeaponType.Mace && defarmr == ArmorType.NoArmor))
			bonusdefence = true;
		return bonusdefence;
	}
	
	static	bool isThisMelee (TroopScript player){
		int range = player.GetMaxRange();
		bool ranged = true;
		if (range>1)
			ranged = false;
		else if (range==1)
			ranged = true;
		return ranged;
	}




}
