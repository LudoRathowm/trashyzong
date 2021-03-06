using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class NewFightScript {


	public static void MeleeFightingScript (TroopScript Attacker, TroopScript Defender, Skill SkillUsed){
		int AttackerBattlefieldEffect = 1; //still to impement
		int DefenderBattlefieldEffect = 1; //still to impement
		int DamageOnAtk = 0;
		int DamageOnDef = 0;
		TroopScript DefenderGuarder = Defender.GuardedBy;
		float 	DefenderGuardPercent = (float)Defender.GuardedByPercent/100;
		if (SkillUsed.CancelsPreparation == true && Defender.isMagicGuarded == false){
			Defender.CancelPreparation();
			Defender.FlushPreparationTarget();
		}
		if (SkillUsed.ReducesEnergy == true && Defender.isMagicGuarded == false){
			Defender.SetEnergy(Defender.GetEnergy()-1);
			if (Defender.GetEnergy() <0)
				Defender.SetEnergy(0);
		}
		if (SkillUsed.RemoveBuffs == true && Defender.isMagicGuarded == false)Defender.RemoveAllbuffs();
		if (SkillUsed.AppliesPoison == true && Defender.Poisoned == 0) Defender.Poisoned = 1;
		if (SkillUsed.Freezes == true && !Defender.Frozen) Defender.Frozen = true; 
		if (SkillUsed.Penetrating == true || DefenderGuarder == null){
		DamageOnDef = CalculateDamage(Attacker,Defender,SkillUsed,AttackerBattlefieldEffect);
			Debug.Log("Damage on "+Defender.GetChief().GetName()+":"+DamageOnDef);
			Defender.SetNumber(Defender.GetNumber()-DamageOnDef);
			if (Defender.GetNumber()<0) Defender.SetNumber(0);
		if (CanCounter(Attacker,Defender,SkillUsed)){

		float CounterScaling = CounterAttackDamage(Defender.GetChief().GetCounterAttack(),Defender.GetArmor().CounterAttackValue+Defender.GetWeapon().CounterAttackValue);
			DamageOnAtk = CalculateCounterDamage(Defender,Attacker,CounterScaling,DefenderBattlefieldEffect);     
			Attacker.SetNumber(Attacker.GetNumber()-DamageOnAtk);
				if (Attacker.GetNumber()<0) Attacker.SetNumber(0);}}


		else if (SkillUsed.Penetrating == false && DefenderGuarder != null){			

		
			DamageOnDef = CalculateDamage(Attacker,Defender,SkillUsed,AttackerBattlefieldEffect);
			if (SkillUsed.AffectRating) RatingFromDamage(Attacker,DamageOnDef);
			if (DefenderGuarder){
				if (DefenderGuarder.GetNumber()<= 0){
					Defender.GuardedBy = null;
					Defender.GuardedByPercent = 0;
					DamageOnDef = CalculateDamage(Attacker,Defender,SkillUsed,AttackerBattlefieldEffect);
					Debug.Log("Damage on "+Defender.GetChief().GetName()+":"+DamageOnDef);
					Defender.SetNumber(Defender.GetNumber()-DamageOnDef);
					if (Defender.GetNumber()<0) Defender.SetNumber(0);
					if (CanCounter(Attacker,Defender,SkillUsed)){
						
						float CounterScaling = CounterAttackDamage(Defender.GetChief().GetCounterAttack(),Defender.GetArmor().CounterAttackValue+Defender.GetWeapon().CounterAttackValue);
						DamageOnAtk = CalculateCounterDamage(Defender,Attacker,CounterScaling,DefenderBattlefieldEffect);     
						Attacker.SetNumber(Attacker.GetNumber()-DamageOnAtk);
						if (Attacker.GetNumber()<0) Attacker.SetNumber(0);}
				}else{
				DefenderGuarder.SetNumber(DefenderGuarder.GetNumber()-Mathf.RoundToInt(DamageOnDef*DefenderGuardPercent));
				if (DefenderGuarder.GetNumber()<0) DefenderGuarder.SetNumber(0);
				Defender.SetNumber(Defender.GetNumber()-Mathf.RoundToInt(DamageOnDef*(1-DefenderGuardPercent)));
				if (Defender.GetNumber()<0) Defender.SetNumber(0);
				if (CanCounter(Attacker,DefenderGuarder,SkillUsed)){
					float CounterScaling = CounterAttackDamage(DefenderGuarder.GetChief().GetCounterAttack(),DefenderGuarder.GetArmor().CounterAttackValue+DefenderGuarder.GetWeapon().CounterAttackValue);
					DamageOnAtk = CalculateCounterDamage(DefenderGuarder,Attacker,CounterScaling,DefenderBattlefieldEffect);
					Attacker.SetNumber(Attacker.GetNumber()-DamageOnAtk);
					if (Attacker.GetNumber()<0) Attacker.SetNumber(0);
			}
				}}
		}
	}

	public static void HealingTarget (TroopScript Healer, TroopScript Healed, float SkillModifier){
		int PeoplePerLine = ReturnPeoplePerLine(Healer);
		int TroopSize = CalculateAdjustedTroopSize(Healer.GetNumber(),PeoplePerLine,Healer.GetChief().GetMuhReturns());
		int Healing = HealAmount(TroopSize,Healer.GetChief().GetIntelligence(),SkillModifier,Healer.GetDirectMatkBuff()); //NEED BUFF MODIFIERS FUGG
		Healed.SetNumber(Healed.GetNumber()+Healing);
		if (Healed.GetNumber()>Healed.GetmaxNumber())
			Healed.SetNumber(Healed.GetmaxNumber());
	}
	static void RatingFromDamage (TroopScript Caster, int Damage){
		int value = Mathf.RoundToInt( (Damage / (float)Caster.GetNumber())*5);
		GameManager.instance.SetAdvantage (Caster,value);
	}
	public static void MonkSelfHeal (TroopScript Monk, float SkillModifier){
		int TroopSize = CalculateAdjustedTroopSize(Monk.GetNumber(),ReturnPeoplePerLine(Monk),Monk.GetChief().GetMuhReturns());
		int Heal = HealAmount (TroopSize,Monk.GetChief().GetIntelligence(),SkillModifier,0); //MUH BUFFEADOS
		Monk.SetNumber(Monk.GetNumber()+Heal);
		if (Monk.GetNumber()>Monk.GetmaxNumber())
		Monk.SetNumber(Monk.GetmaxNumber());
	}
public	static float DamageScalingCleanUp (TroopScript Caster, TroopScript Target){
		float value;
		float HpDifferences = ((float)Caster.GetNumber()/(float)Caster.GetmaxNumber())/((float)Caster.GetNumber()/(float)Caster.GetmaxNumber());
		value = -1f+Mathf.Pow(1.5f,HpDifferences);
		return value;
	}

	public static float DamageScalingRevenge (TroopScript Caster){
		float value;
		float hpPercent = (float)Caster.GetNumber()/(float)Caster.GetmaxNumber();
		value = 0.7f*(1/hpPercent); //need to change this

		return value;
	}




	public static void Assassinate (TroopScript Assassin, TroopScript Victim){
		int AssassinChance = Mathf.RoundToInt(((float)Assassin.GetEnergy()/(float)Assassin.GetMaxEnergy())*900+((float)Assassin.GetNumber()/(float)Assassin.GetmaxNumber())*100);
		int VictimChance = Mathf.RoundToInt(((float)Victim.GetEnergy()/(float)Victim.GetMaxEnergy())*100+((float)Victim.GetNumber()/(float)Victim.GetmaxNumber())*900);
		if (AssassinChance>VictimChance && Victim.boss == false)
			Victim.SetNumber(0);
	}

	public static void MikoStorm (TroopScript Caster,List<TroopScript> listofPlayers,int MikoScaling){

		for (int i = 0;i<listofPlayers.Count;i++)
			if (listofPlayers[i].Faction != Caster.Faction)
				listofPlayers[i].SetNumber(listofPlayers[i].GetNumber()-Mathf.RoundToInt(((float)listofPlayers[i].GetmaxNumber()/100)*MikoScaling));
			}


	static int CalculateDamage (TroopScript Attacker, TroopScript Defender, Skill Skillused, int BattlefieldEffect){
		TroopScript thisGuysTerrain;
		int TroopDamage = 0;
		if (Skillused.SkillMaxRange > 1)
			thisGuysTerrain = Attacker;
		else thisGuysTerrain = Defender;
		int	AdjustedTroopSize= CalculateAdjustedTroopSize ( Attacker.GetNumber(),ReturnPeoplePerLine(thisGuysTerrain),Attacker.GetChief().GetMuhReturns());
		bool isPhysical = Skillused.isPhysical;
		if (isPhysical && Skillused.PiercesDefence == false)
		TroopDamage = Mathf.RoundToInt	((AdjustedTroopSize*((float)CalculateAttack(Attacker.GetClass().GetAttack(),Attacker.GetChief().GetAttack(),Attacker.GetDirectAttackBuff())-(float)CalculateDefense(Defender.GetClass().GetDefense(),Defender.GetChief().GetDefense(),Defender.GetDefenseBuff(),Defender.GetPhalanx()))/15));
		else if (isPhysical && Skillused.PiercesDefence == true)
			TroopDamage = Mathf.RoundToInt	((AdjustedTroopSize*((float)CalculateAttack(Attacker.GetClass().GetAttack(),Attacker.GetChief().GetAttack(),Attacker.GetDirectAttackBuff())-(float)CalculatePiercedDefense(Defender.GetClass().GetDefense(),Defender.GetChief().GetDefense(),Defender.GetDefenseBuff())/15)));
		else if (!isPhysical)
		TroopDamage = Mathf.RoundToInt((AdjustedTroopSize*(((float)CalculateMagicAttack(Attacker.GetClass().GetIntelligence(),Attacker.GetChief().GetIntelligence(),Attacker.GetDirectMatkBuff())-(float)CalculateMagicDefense(Defender.GetChief().GetIntelligence(),Defender.GetMdefBuff()))/15)));
		if (TroopDamage>Attacker.GetNumber())
			TroopDamage = Attacker.GetNumber();
		int flatWeaponValue = Attacker.GetWeapon().Attack*((isPhysical&&Attacker.GetWeapon().physical||!Attacker.GetWeapon().physical&&!isPhysical)?1:0);
		int Final = Mathf.RoundToInt(((TroopDamage*Attacker.GetWeapon().AttackModifier+flatWeaponValue)*Skillused.DamageScaling)*BattlefieldEffect);
		return Final;
	}

	static int CalculateCounterDamage (TroopScript Attacker, TroopScript Defender, float CounterAtkScale,  int BattlefieldEffect){

		int	AdjustedTroopSize= CalculateAdjustedTroopSize ( Attacker.GetNumber(),ReturnPeoplePerLine(Attacker),Attacker.GetChief().GetMuhReturns());
		int TroopDamage = 0;
		if (Attacker.GetClass().GetIfItsPhysical())
			TroopDamage = Mathf.RoundToInt	((AdjustedTroopSize*((float)CalculateAttack(Attacker.GetClass().GetAttack(),Attacker.GetChief().GetAttack(),Attacker.GetCounterAttackBuff())-(float)CalculateDefense(Defender.GetClass().GetDefense(),Defender.GetChief().GetDefense(),Defender.GetDefenseBuff(),Defender.GetPhalanx()))/15));
		else 
			TroopDamage = Mathf.RoundToInt((AdjustedTroopSize*(((float)CalculateMagicAttack(Attacker.GetClass().GetIntelligence(),Attacker.GetChief().GetIntelligence(),Attacker.GetCounterMatkBuff())-(float)CalculateMagicDefense(Defender.GetChief().GetIntelligence(),Defender.GetMdefBuff()))/15)));
		if (TroopDamage>Attacker.GetNumber())
			TroopDamage = Attacker.GetNumber();
		int flatWeaponValue = Attacker.GetWeapon().Attack*((Attacker.GetClass().GetIfItsPhysical()&&Attacker.GetWeapon().physical||!Attacker.GetWeapon().physical&&!Attacker.GetClass().GetIfItsPhysical())?1:0);
		int Final = Mathf.RoundToInt(((TroopDamage*Attacker.GetWeapon().AttackModifier+flatWeaponValue)*CounterAtkScale)*BattlefieldEffect);
		return Final;
	}

	public static void SummonYogurtOntoPlayer (TroopScript Player, TroopScript Summoner){
		int PlayerValue = TroopValue(Player);
		int SummonerValue = TroopValue(Summoner);
		if (PlayerValue>SummonerValue+2)
			Player.SetOgreSummonInto(Summoner);
		else if (PlayerValue>SummonerValue -2 && SummonerValue+2>PlayerValue)
					Player.SetNumber(0);
		else if (PlayerValue<= SummonerValue-2){
			Player.Faction = Summoner.Faction;
			Player.SetOgreSummonInto(Summoner);
		}

	}
	static int TroopValue (TroopScript playerados){
		int value = playerados.GetChief().GetAttack()+playerados.GetChief().GetDefense()+playerados.GetChief().GetIntelligence()+playerados.GetChief().GetSpeed();
		return value;
	}



//	 //atkbuffmodifier needs a method. first you need to check your ATKONLY COUNTERONLY buffs and then decide the final modifier
//	    static int FinalDamage (int BaseAttack, int CptAttack, int AtkBuffModifier, int BaseDefense, int CptDefense, int DefBuffModifier,
//	                        int TroopSize, float WeaponModifier, int FlatWeapon, bool FlatWeaponPhysical, float SkillModifier, float BattlefieldEffect, 
//	                        int PeoplePerLine, float CptAbility, bool isPhysical, int BaseIntAtk, int IntCptDef, int IntCpt,float MatkBuffModifier,float MdefBuffModifier){
//		int AdjustedTroopSize = CalculateAdjustedTroopSize (TroopSize,PeoplePerLine,CptAbility);
//		int TroopDamage = 0;
//		Debug.Log("is physical:" +isPhysical);
//		if (isPhysical)
//		TroopDamage = Mathf.RoundToInt	((AdjustedTroopSize*((float)CalculateAttack(BaseAttack,CptAttack,AtkBuffModifier)-(float)CalculateDefense(BaseDefense,CptDefense,DefBuffModifier))/15));
//		else if (!isPhysical)
//			TroopDamage = Mathf.RoundToInt((AdjustedTroopSize*(((float)CalculateMagicAttack(BaseIntAtk,IntCpt,MatkBuffModifier)-(float)CalculateMagicDefense(IntCptDef,MdefBuffModifier))/15)));
//		Debug.Log("troop dmg"+TroopDamage);
//		if (TroopDamage> TroopSize)
//			TroopDamage = TroopSize;
//
//		int FlatWeaponValue = 0;
//		FlatWeaponValue = FlatWeapon*((isPhysical&&FlatWeaponPhysical||!isPhysical&&!FlatWeaponPhysical)?1:0);
//		Debug.Log("weap:" +WeaponModifier);
//		int Final = Mathf.RoundToInt(((TroopDamage*WeaponModifier+FlatWeaponValue)*SkillModifier)*BattlefieldEffect);
//
//		return Final;
//	}

	public static float CalculateMaimRatio (TroopScript Caster, TroopScript Target){
		int cpeople = CalculateAdjustedTroopSize(Caster.GetNumber(),ReturnPeoplePerLine(Caster),Caster.GetChief().GetMuhReturns());
		int tpeople = CalculateAdjustedTroopSize(Target.GetNumber(),ReturnPeoplePerLine(Target),Target.GetChief().GetMuhReturns());
		float ratio = (tpeople/cpeople)*0.75f;
		return ratio;
	}

	static float CounterAttackDamage ( int SkillBonus, int EquipBonus){
		return ((float)(30+SkillBonus+EquipBonus)/100);
	}



	static int CalculateAttack (int BaseAttack, int CptAttack, float BuffModifier){
		int value = Mathf.RoundToInt(BaseAttack+CptAttack*(1+BuffModifier)*10);
		// Debug.Log("atk"+value);
		return value;
	}
	static int CalculateDefense (int BaseDefense, int CptDefense, float BuffModifier){
		int value = Mathf.RoundToInt(BaseDefense+CptDefense*(1+BuffModifier)*08f);
//		Debug.Log("def"+value);
		return value;
	}
	static int CalculateDefense (int BaseDefense, int CptDefense, float BuffModifier, bool Phalanxing){
		int multiply = 1;
		if (Phalanxing)
			multiply = 3;
		int value = Mathf.RoundToInt(multiply*BaseDefense+CptDefense*(1+BuffModifier)*08f);
//		Debug.Log("def"+value);
		return value;
	}
	static int CalculatePiercedDefense (int BaseDefense, int CptDefense,float BuffModifier){
		int value = Mathf.RoundToInt(BaseDefense+CptDefense*(BuffModifier)*8f);
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
	//	Debug.Log("cpt pwr: "+CptAbility+" trnpwr: "+ terrainPower+ " total: "+Total);
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
	
//	static	bool isThisMelee (TroopScript player){
//		int range = player.GetMaxRange();
//		bool ranged = true;
//		if (range>1)
//			ranged = false;
//		else if (range==1)
//			ranged = true;
//		return ranged;
//	}

	static int HealAmount (int AdjustedTroopSize, int Intelligence, float SkillModifier, float buffmodifier){
		int Heal = Mathf.RoundToInt(AdjustedTroopSize * ((float)Intelligence * 3)/15* SkillModifier * (1 + buffmodifier));
		return Heal;
	}



	static int ReturnPeoplePerLine (TroopScript Unit){
		int x = Mathf.RoundToInt(Unit.gridPosition.x);
		int y = Mathf.RoundToInt(Unit.gridPosition.y);
		Tile _terrain = GameManager.instance.map[x][y];
		int PeoplePerLine = _terrain.frontLiners;
		return PeoplePerLine;
	}

		static bool CanCounter(TroopScript Attacker, TroopScript Defender, Skill SkillUsedToAttack){
			bool ret = false;
		bool SkillAllows = SkillUsedToAttack.CanCounter;
		Vector2 AttackerPosition = Attacker.gridPosition;
		Vector2 DefenderPosition = Defender.gridPosition;
		int max = Defender.GetCounterMaxRange();
		int min = Defender.GetCounterMinRange();
		float value = Mathf.Abs(AttackerPosition.x-DefenderPosition.x)+Mathf.Abs(AttackerPosition.y-DefenderPosition.y);
		if (value > min && value < max && SkillAllows)
			ret = true;
			//yadda yadda check distance and skills
			return ret;
		}
	static float BuffValue (TroopScript BuffCaster){ //5% buff for point of int
		return BuffCaster.GetChief().GetIntelligence()*0.05f;
	}
	static int CountAndSetNumberOfPeopleYouCanBuff (TroopScript BuffCaster, TroopScript Target, Skill BuffSkill){
		float multiply = BuffSkill.TroopSizeBuffMultiplier;
		int people = BuffCaster.GetNumber();
		int buffedpeople = Target.GetNumber();
		int total = Mathf.RoundToInt(((float)people*multiply/(float)buffedpeople)+multiply);
		return total; //for the list of buffs
	}

	public static void MainBuffMethod (TroopScript Buffer, TroopScript Target, Skill _buffSkill, TypeOfBuff[] _dabuffsecsdee){

		for (int i = 0;i<_dabuffsecsdee.Length;i++)
			//logic to pick the target buff goes on _dabuffsecsdee
				ApplyBuffOnTarget(Buffer,Target,_dabuffsecsdee[i]);
			
		}
	public static TypeOfBuff[] CreateBuffList (TroopScript Buffer, TroopScript Target,Skill Buffskill){
		int value = CountAndSetNumberOfPeopleYouCanBuff(Buffer,Target,Buffskill);
		TypeOfBuff[] BuffsImmaCast = new TypeOfBuff[value];
		//add all the buffs to the list because i really cant this should go in the AI Troop and UserTroop script in the future
		return BuffsImmaCast;
	}


	 static void ApplyBuffOnTarget (TroopScript Buffer, TroopScript Buffed , TypeOfBuff bufftype){

			float strenght = BuffValue(Buffer);

		if (bufftype == TypeOfBuff.AttackCounter)
			Buffed.SetCounterAttackBuff(strenght);
		else if (bufftype == TypeOfBuff.AttackDirect)
			Buffed.SetDirectAttackBuff(strenght);
		else if (bufftype == TypeOfBuff.AttackTotal)
			Buffed.SetTotalAttackBuff(strenght*0.7f);
		else if (bufftype == TypeOfBuff.MatkCounter)
			Buffed.SetCounterMatkBuff(strenght);
		else if (bufftype == TypeOfBuff.MatkDirect)
			Buffed.SetDirectMatkBuff(strenght);
		else if (bufftype == TypeOfBuff.MatkTotal)
			Buffed.SetTotalMatkBuff(strenght*0.7f);
		else if (bufftype == TypeOfBuff.Defense)
			Buffed.SetDefenseBuff(strenght);
		else if (bufftype == TypeOfBuff.Mdef)
			Buffed.SetMdefBuff(strenght);
		else if (bufftype == TypeOfBuff.Speed)
			Buffed.SetSpeedBuff(strenght);
	}

//	public static void AccurateShotsTargeting (TroopScript Caster, int range){
////		Color highlightColor = new Color(GameManager.ColorAdapter(0),GameManager.ColorAdapter(255),GameManager.ColorAdapter(0),1);
////		Color SHIThighlightColor  = new Color(GameManager.ColorAdapter(153),GameManager.ColorAdapter(153),GameManager.ColorAdapter(0),1);
//		List<TroopScript> PeopleToAttack = new List<TroopScript>();
//
//
//
//	Vector2 mousePosition = GameManager.instance.MousePosition;
//	List<Tile> Targetcells = GameManager.instance.AccurateShotsHighlights(Caster.gridPosition,mousePosition,2,Skill.FromListOfSkills);
//	int cells = Targetcells.Count;
//	float TotalDamage = (float)5/cells;
//
//		for (int i = 0; i<cells;i++){
//			for (int j = 0; j<GameManager.instance.players.Count;j++){
//				if (Targetcells[i].gridPosition == GameManager.instance.players[j].gridPosition && GameManager.instance.players[j].Faction != Caster.Faction)
//						if (!PeopleToAttack.Contains(GameManager.instance.players[j]))
//						PeopleToAttack.Add(GameManager.instance.players[j]);
//			}
//		}
//
//		Debug.Log(PeopleToAttack.Count);
//		//only if some shit happens and it stops being triggered per frame idk ill see what i can do
//		AccurateShotAction(Caster,PeopleToAttack,TotalDamage);
//
//
//	}

	public static void AccurateShotAction (TroopScript Caster, List<TroopScript> Targets, float _skillDamage){
		int AttackerBattlefieldEffect = 1; //still to impement

		
		for (int i = 0;i<Targets.Count;i++){
			int kills = CalculateAccurateShotDamage(Caster,Targets[i],_skillDamage,AttackerBattlefieldEffect);
			Targets[i].SetNumber(Targets[i].GetNumber()-kills);
			if (Targets[i].GetNumber()<0) Targets[i].SetNumber(0);
			if (Targets[i].GetPreparation()!=null) Targets[i].CancelPreparation();
			if (Targets[i].GetEnergy()>0)Targets[i].SetEnergy(Targets[i].GetEnergy()-1);
		}

	
	}
	static int CalculateAccurateShotDamage (TroopScript Attacker, TroopScript Defender, float _skillDamage, int BattlefieldEffect){
		int AdjustedTroopSize = CalculateAdjustedTroopSize (Attacker.GetNumber(),ReturnPeoplePerLine(Attacker), Attacker.GetChief().GetMuhReturns());
		int TroopDamage = Mathf.RoundToInt	((AdjustedTroopSize*((float)CalculateAttack(Attacker.GetClass().GetAttack(),Attacker.GetChief().GetAttack(),Attacker.GetDirectAttackBuff())-(float)CalculateDefense(Defender.GetClass().GetDefense(),Defender.GetChief().GetDefense(),Defender.GetDefenseBuff()))/15));
		int flatWeaponValue = Attacker.GetWeapon().Attack;
		int Final = Mathf.RoundToInt(((TroopDamage*Attacker.GetWeapon().AttackModifier+flatWeaponValue)*_skillDamage)*BattlefieldEffect);
		return Final;
	}


	public static void AdvanceTime (){
		GameManager.instance.CurrentTime +=2;
	}
	public static void AdvanceTime2(){
		GameManager.instance.CurrentTime +=4;
	}

	static int CalculateGuardPercent (TroopScript Caster, TroopScript Target, Skill SkillUsedToGuard){
		int intelligence = Mathf.RoundToInt(((float)Caster.GetChief().GetIntelligence()+(float)Target.GetChief().GetIntelligence())/2); //if the one you have to guard is a retard guarding is harder
		int GuardScaling = SkillUsedToGuard.GuardScaling;
		return Mathf.RoundToInt(intelligence*GuardScaling);
	}

	public static void AllyGuard (TroopScript Caster, TroopScript Target, Skill SkillUsedToGuard) {
		Target.GuardedBy = Caster;
		Target.GuardedByPercent = CalculateGuardPercent(Caster,Target,SkillUsedToGuard); 
	}


	public static void AnkleSnare (TroopScript Caster){
		GameManager.instance.highlightTilesAt(Caster.gridPosition,Color.cyan,1,false);
	//this shit is all in the game manager script
}

	public static void BattleRating (TroopScript Caster, Skill SkillUsed){
		float BattleRatingChange = SkillUsed.BattleEffect;
		//need to change battle rating but there is none for now oop
	}

	public static void CarryPickUp (TroopScript Caster){
		GameManager.instance.highlightTilesAt(Caster.gridPosition,Color.cyan,1,false);
	   //this goes into the game manager thing i think zz
	//	TroopScript Target; need an actual troopscript to prevent errors
	//	Caster.CarryingThisNigga = Target;
		//stuff to remove target from lists, disable acting from Caster.
		}
	public static void CarryDropDown (TroopScript Caster){
		//game manager stuff to decide position
		//instantiate blabla with CarryingThisNigga value
		Caster.CarryingThisNigga = null;
	}

	public static void FinisherDamageScaling (TroopScript Caster, TroopScript Target){
		float CasterHpPercent = (float)Caster.GetNumber()/Caster.GetmaxNumber();
		float TargetHpPercent = (float)Target.GetNumber()/Target.GetmaxNumber();
		float SkillScaling = .5f*(CasterHpPercent/TargetHpPercent);
	}

	public static void ConvertAction (TroopScript Caster,TroopScript Target, Skill SkillUsed){
		int Value = SkillUsed.EnergyCost;
		if (Caster.GetEnergy()>=Value){
			Caster.SetEnergy(Caster.GetEnergy()-Value);
			Target.SetEnergy(Target.GetEnergy()+Value);
		if (Target.GetEnergy() > Target.GetMaxEnergy())
				Target.SetEnergy(Target.GetMaxEnergy());}
	}
	public static void PoisonStuff (TroopScript Caster, TroopScript Target, Skill SkillUsed){
		if (SkillUsed.RemovesPoison)
			Target.Poisoned = 0;
		else if (SkillUsed.AppliesPoison)
			Target.Poisoned = Caster.GetChief().GetIntelligence();
	}

//	public static void FellowTroopRevenge (TroopScript Caster, TroopScript Target){
//		int Losses = Caster.GetmaxNumber()-Caster.GetNumber();
//		float Scaling = .25f*(float)Losses/((float)Caster.GetmaxNumber()/10);
//		Skill FellowTroopRevenge = Skill.FromListOfSkills(muhSkills.FellowTroopsRevenge);
//		FellowTroopRevenge.DamageScaling = Scaling;
//
//		MeleeFightingScript(Caster,Target,FellowTroopRevenge);
//	}
	public static void FrostDiver (TroopScript Caster, TroopScript Target){
		if (Target.GetChief().GetIntelligence()<Caster.GetChief().GetIntelligence())
			Target.Frozen = true;
		MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.FrostDiver));

	}
	public static void IceWall (){
		//the targeting script is in game manager
		//instantiate 3 cells like the ogre thingy
	}

	public static void KnightCharge(TroopScript Caster,TroopScript Target){
		float DamageScaling = 1.5f;
		if (Caster.GetNumber()<Target.GetNumber())
			DamageScaling = 3;
		Skill KnightCharge = Skill.FromListOfSkills(muhSkills.KnightCharge);
		KnightCharge.DamageScaling = DamageScaling;
		MeleeFightingScript(Caster,Target,KnightCharge);
	}

	public static void Lightning (TroopScript Caster){
		Vector2 originPosition = Caster.gridPosition;
		List <TroopScript> Targets = GameManager.instance.Lightning(originPosition);
		for (int i=0;i<Targets.Count;i++)
			MeleeFightingScript(Caster,Targets[i],Skill.FromListOfSkills(muhSkills.Lightning));

	}

	public static void GuardCancel (TroopScript Caster, TroopScript Target){
		Target.GuardedBy = null;
		Target.GuardedByPercent = 0;
	}

	public static void MagicGuard (TroopScript Caster,TroopScript Target){
		Target.isMagicGuarded = true;
	}

//	public static void Maim (TroopScript Target){        convert into a status?
//		Target.SetBaseMovement(Target.SetBaseMovement-2);
//	}
	public static void MonkCharge (TroopScript Caster, TroopScript Target, Skill SkillUsed){
		Target.RemoveAllbuffs();
		MeleeFightingScript(Caster,Target,SkillUsed);
	}

	public static void Phalanx (TroopScript Caster){
		bool phal = Caster.GetPhalanx();
		if (phal) Caster.SetPhalanx(false);
		else if (!phal) Caster.SetPhalanx(true);
	}

	public static void RearGuardCharge (TroopScript Caster, TroopScript Target){
		float DamageScaling = 1.5f;
		if (Target.GetCounterMaxRange()>Caster.GetCounterMinRange())
			DamageScaling = 3;
		Skill RearGuard = Skill.FromListOfSkills(muhSkills.RearGuardCharge);
		RearGuard.DamageScaling = DamageScaling;
		MeleeFightingScript(Caster,Target,RearGuard);
	}

	public static void SharpShoot (TroopScript Caster){
		List<Tile> myList = new List<Tile>();
	}

	public static void ShoutingCharge (TroopScript Caster, TroopScript Target){
		int Damage = CalculateDamage(Caster,Target, Skill.FromListOfSkills(muhSkills.ShoutingCharge),1);
		int BattleRating = Mathf.RoundToInt((float)Damage/100);
		//add battle rating zz
		MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.ShoutingCharge));
	}

    public static void Shuriken (TroopScript Caster, TroopScript Target, Skill SkillUsed){
		if (Target.GetPreparation()!=null)
			Target.CancelPreparation();
		}



}