using UnityEngine;
using System.Collections;

public class NewFightScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}





	static int FinalPhysicalDamage (int BaseAttack, int CptAttack, int AtkBuffModifier, int BaseDefense, int CptDefense, int DefBuffModifier, int TroopSize, float WeaponModifier, int FlatWeapon, float SkillModifier, float BattlefieldEffect, int PeoplePerLine, float CptAbility){
		int AdjustedTroopSize = 0;
		int TroopDamage = (AdjustedTroopSize*(CalculateAttack(BaseAttack,CptAttack,AtkBuffModifier)-CalculateDefense(BaseDefense,CptDefense,DefBuffModifier)));
		if (TroopDamage> TroopSize)
			TroopDamage = TroopSize;
		int Final = Mathf.RoundToInt(((TroopDamage*WeaponModifier+FlatWeapon)*SkillModifier)*BattlefieldEffect);
		return Final;
	}





	static int CalculateAttack (int BaseAttack, int CptAttack, float BuffModifier){
		return Mathf.RoundToInt(BaseAttack+CptAttack*(1+BuffModifier)*10);
	}
	static int CalculateDefense (int BaseDefense, int CptDefense, float BuffModifier){
		return Mathf.RoundToInt(BaseDefense+CptDefense*(1+BuffModifier)*8);
	}
	static int CalculateMagicAttack (int BaseIntelligence, int CptIntelligence, float BuffModifier){
		return Mathf.RoundToInt(BaseIntelligence+CptIntelligence*(1+BuffModifier)*10);
	}
	static int CalculateMagicDefense(int CptIntelligence,int  BuffModifier){
		return Mathf.RoundToInt(CptIntelligence*(1+BuffModifier)*7);
	}


	int CalculateAdjustedTroopSize (int TroopSize, int PeoplePerLine, float CptAbility){
		int ReturnTroop = TroopSize/PeoplePerLine;
		return ReturnTroop;
	}









}
