using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class SkillMethods : MonoBehaviour {
	public static SkillMethods instance;
	void Awake (){
		instance = this;
	}

	public muhSkills SwitchThis;
	float AccurateShotsArea =2;
	float IceWallRotationvalue = 1;

	void Update (){
//		Debug.Log("CHANGE FRAME");
		SkillsThatRequireUpdate();

	}

	void SkillsThatRequireUpdate(){

		switch (SwitchThis){
		case muhSkills.AccurateShots:
			AccurateShots();
			break;
		case muhSkills.AimAndShoot:
			AimAndShootSet();
			break;
		case muhSkills.AllGuard:
			AllGuard ();
			break;
		case muhSkills.AllyGuard:
			AllyGuard ();
			break;
		case muhSkills.AllyGuardPlus:
			AllyGuardPlus ();
			break;
		case muhSkills.AnkleSnare:
			AnkleSnare();
			break;
		case muhSkills.Assassinate:
			Assassinate();
			break;
		case muhSkills.BowAttack:
			BowAttack();
			break;
		case muhSkills.BowAttackMiko:
			BowAttackMiko();
			break;
		case muhSkills.BowAttackPlus:
			BowAttackPlus();
			break;
		case muhSkills.CannonNormalAttack:
			CannonNormalAttack();
			break;
		case muhSkills.CannonStrongAttack:
			CannonStrongAttack();
			break;
		case muhSkills.CarefulAttack:
			CarefulAttack();
			break;
		case muhSkills.Carry:
			Carry();
			break;
		case muhSkills.Drop:
			Drop ();
			break;
		case muhSkills.CavalryCharge:
			CavalryCharge();
			break;
		case muhSkills.CavalryCharge2:
			CavalryCharge2();
			break;
		case muhSkills.ChinkChinkShuriken:
			ChinkChinkShuriken();
			break;
		case muhSkills.CleanUp:
			CleanUp();
			break;
		case muhSkills.ConvertAction:
			ConvertAction();
			break;
		case muhSkills.ConvertAction2:
			ConvertAction2();
			break;
		case muhSkills.CrossbowAttack:
			CrossbowAttack();
			break;
		case muhSkills.CrossbowAttackPlus:
			CrossbowAttackPlus();
			break;
		case muhSkills.Depoison:
			Depoison();
			break;
		case muhSkills.FellowTroopsRevenge:
			FellowsTroopRevenge();
			break;
		case muhSkills.FireBlast:
			FireBlast();
			break;
		case muhSkills.FollowThrough:
			FollowThrough();
			break;
		case muhSkills.FootSoldierAttack:
			FootSoldierAttack();
			break;
		case muhSkills.FootSoldierAttack2:
			FootSoldierAttack2();
			break;
		case muhSkills.FrostDiver:
			FrostDiver();
			break;
		case muhSkills.FullPowerCharge:
			FullPowerCharge();
			break;
		case muhSkills.FullPowerCharge2:
			FullPowerCharge2();
			break;
		case muhSkills.HalveEnergy:
			HalveEnergy();
			break;
		case muhSkills.HealingMist:
			HealingMist();
			break;
		case muhSkills.Icewall:
			IceWall();
			break;
		case muhSkills.KnightAttack:
			KnightAttack();
			break;
		case muhSkills.KnightAttack2:
			KnightAttack2();
			break;
		case muhSkills.KnightCharge:
			KnightCharge();
			break;
		case muhSkills.LightAttack:
			LightAttack();
			break;
		case muhSkills.Lightning:
			Lightning();
			break;
		case muhSkills.Loot:
			Loot ();
			break;
		case muhSkills.MagicGuard:
			MagicGuard();
			break;
		case muhSkills.MagicGuardAround:
			MagicGuardAround();
			break;
		case muhSkills.Maim:
			Maim();
			break;
		case muhSkills.MikoDance:
			MikoDance();
			break;
		case muhSkills.MikoDancePlus:
			MikoDancePlus();
			break;
		case muhSkills.MikoDanceQuick:
			MikoDanceQuick();
			break;
		case muhSkills.MonkCharge:
			MonkCharge();
			break;
		case muhSkills.MonkChargePlus:
			MonkCharge();
			break;
		case muhSkills.OnRush:
			OnRush();
			break;
		case muhSkills.PenetrationShoot:
			PenetrationShoot();
			break;
		case muhSkills.PenetrationShoot2:
			PenetrationShoot2();
			break;
		case muhSkills.Poison:
			Poison();
			break;
		case muhSkills.QuickAttack:
			QuickAttack();
			break;
		case muhSkills.RearGuardCharge:
			RearGuardCharge();
			break;
		case muhSkills.RemoveBuffs:
			RemoveBuffs();
			break;
		case muhSkills.RemoveBuffsAround:
			RemoveBuffsAround();
			break;
		case muhSkills.RemoveBuffsRanged:
			RemoveBuffsRanged();
			break;
		case muhSkills.Sharpshoot:
			Sharpshoot();
			break;
		case muhSkills.Shoot:
			Shoot();
			break;
		case muhSkills.ShoutingCharge:
			ShoutingCharge();
			break;
		case muhSkills.Shuriken:
			Shuriken();
			break;
		case muhSkills.Shuriken2:
			Shuriken2();
			break;
		case muhSkills.SonicShuriken:
			SonicShuriken();
			break;
		case muhSkills.StormGust:
			StormGust();
			break;
		case muhSkills.StrongBowAttack:
			StrongBowAttack();
			break;
		case muhSkills.StrongFootAttack:
			StrongFootAttack();
			break;
		case muhSkills.StrongFootAttack2:
			StrongFootAttack2();
			break;
		case muhSkills.SummonTrash:
			SummonTrashSet();
			break;
		case muhSkills.SweepingFire:
			SweepingFire();
			break;
		case muhSkills.NoSkill:
			break;
		default:
			break;
		
		}}







	public void AccurateShotsActivate(){ // i didn't add a !busy here because the button will go away if you do something else anyway
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AccurateShots).EnergyCost)
			SwitchThis = muhSkills.AccurateShots;
		else Debug.Log("NO ENERGY");
	}
	void AccurateShots(){
		muhSkills thisSkill = muhSkills.AccurateShots;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		Vector2 Origin = Caster.gridPosition;
		List<TroopScript> Targets = new List<TroopScript>();


	
		if (AccurateShotsArea > -1f && AccurateShotsArea < 5.1f)
			AccurateShotsArea +=Input.GetAxis("Mouse ScrollWheel");
		else if (AccurateShotsArea < 0)
			AccurateShotsArea =0;
		else if (AccurateShotsArea > 5)
			AccurateShotsArea = 5;

		int	mArea = Mathf.RoundToInt(AccurateShotsArea);
		if (mArea < 1)
			mArea = 0;
		else if (mArea > 3)
			mArea = 4;
		Caster.attacking = true;
		List<Tile>Targetcells = GameManager.instance.AccurateShotsHighlights(Origin,GameManager.instance.MousePosition,mArea,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(SwitchThis).SkillMaxRange);
			int cells = Targetcells.Count;
			for (int i = 0; i<cells;i++){
				for (int j = 0; j<GameManager.instance.players.Count;j++){
					//if (Targetcells[i].gridPosition == GameManager.instance.players[j].gridPosition && GameManager.instance.players[j].Faction !=GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].Faction)
					if (Targetcells[i].gridPosition == GameManager.instance.players[j].gridPosition)

						if (!Targets.Contains(GameManager.instance.players[j])){
							Targets.Add(GameManager.instance.players[j]);
				//	Debug.Log ("added "+GameManager.instance.players[j].GetChief().GetName()+" to the list of targets");
				}
				//Debug.Log("count zz:"+Targets.Count);
			}}
	if (Input.GetMouseButtonDown(0))
    
				if (Targets.Count > 0){
				//Debug.Log("count:"+Targets.Count);
				for (int k = 0;k<Targets.Count;k++){

					float TotalDamage = (float)5/cells;
					Skill damageados = Skill.FromListOfSkills(muhSkills.AccurateShots);
					damageados.DamageScaling = TotalDamage;
					NewFightScript.MeleeFightingScript(Caster,Targets[k],damageados);
					//Targets[i].SetNumber(Targets[i].GetNumber()-kills);
					//if (Targets[i].GetNumber()<0) Targets[i].SetNumber(0);
				//	Debug.Log(Targets[k].GetChief().GetName());
				//	Debug.Log("value of k: "+k);
		
					if (Targets[k].GetEnergy()>0)Targets[k].SetEnergy(Targets[k].GetEnergy()-1);
				}
				SwitchThis = muhSkills.NoSkill;

			//animations and shit go here
			Caster.actionPoints--;
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;

		}}
	public void AdvanceTime (){	
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AdvanceTime).EnergyCost)
		{
			GameManager.instance.CurrentTime +=2;
			TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
			muhSkills thisSkill = muhSkills.AdvanceTime;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.actionPoints--;
		}
		else Debug.Log("NO ENERGY");

		}
	public void AdvanceTime2 (){	
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AdvanceTime).EnergyCost)
		{
			GameManager.instance.CurrentTime +=4;
			TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
			muhSkills thisSkill = muhSkills.AdvanceTime2;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			Caster.actionPoints--;
			SwitchThis = muhSkills.NoSkill;}
		else Debug.Log("NO ENERGY");
		
	}

	public void AimAndShootActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AimAndShoot).EnergyCost)
			SwitchThis = muhSkills.AimAndShoot;
		else Debug.Log("NO ENERGY");
	}
	void AimAndShootSet(){
		muhSkills thisSkill = muhSkills.AimAndShoot;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.removeTileHighlights();
		Caster.moving = false;
		//Caster.attacking = true;
		TroopScript target = null;
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,0,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition) {
						target = p;
					}
				}
			}
			if (target){
				Caster.moving = false;
				Caster.attacking = false;
				Caster.SetPreparationTargetPlayer(target);
				Debug.Log(Caster.GetChief().GetName()+" started aiming at: "+target.GetChief().GetName());
				Caster.SetPreparation(thisSkill);
				Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
				SwitchThis = muhSkills.NoSkill;
				GameManager.instance.removeTileHighlights();
				if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
					Caster.SetEnergy(0);
				Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
				Caster.actionPoints--;
			}
		
		}
		}
	public void AimAndShootEffect (TroopScript Caster, TroopScript Target){
		NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.AimAndShoot));
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].SetPreparation(muhSkills.NoSkill);
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].SetPreparationTargetPlayer(null);
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].SetPreparationTargetTile(null);
		Caster.SkillRecoveryTime = Skill.FromListOfSkills(muhSkills.AimAndShoot).SkillRecoveryTime;

		//all the animations and shit 
	}
	public void AllGuardActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AllGuard).EnergyCost)
			SwitchThis = muhSkills.AllGuard;
		else Debug.Log("NO ENERGY");
	}
	void AllGuard (){
		muhSkills thisSkill = muhSkills.AllGuard;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.removeTileHighlights();
		List <TroopScript> Targets = new List<TroopScript>();
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.gray,0,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		if (Input.GetMouseButtonDown(0)){
			for (int i = 0; i < GameManager.instance.mapSize; i++) {
				for (int j = 0; j < GameManager.instance.mapSize; j++) {
					for (int k = 0;k<GameManager.instance.players.Count;k++)
					if (GameManager.instance.map[i][j].visual.transform.GetComponent<Renderer>().materials[0].color == Color.gray && GameManager.instance.map[i][j].gridPosition == GameManager.instance.players[k].gridPosition && GameManager.instance.players[k].Faction == Caster.Faction && GameManager.instance.players[k] != Caster)
							Targets.Add (GameManager.instance.players[k]);
				}
			}
			for (int i = 0;i<Targets.Count;i++)
				NewFightScript.AllyGuard(Caster,Targets[i],Skill.FromListOfSkills(thisSkill));

			//animations and shit go here
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}
				
				
		
	}
	public void AllyGuardActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AllyGuard).EnergyCost)
			SwitchThis = muhSkills.AllyGuard;
		else Debug.Log("NO ENERGY");
	} 
	void AllyGuard(){
		muhSkills thisSkill = muhSkills.AllyGuard;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.removeTileHighlights();
		TroopScript Target;
		GameManager.instance.highlightTilesAt(Caster.gridPosition,Color.cyan,1);
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction) {
						Target = p;
						NewFightScript.AllyGuard(Caster,Target,Skill.FromListOfSkills(thisSkill));

					
				
    		
			

			//animations and shit go here
			GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
	}}}}}
	public void AllyGuardPlusActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AllyGuard).EnergyCost)
			SwitchThis = muhSkills.AllyGuard;
		else Debug.Log("NO ENERGY");
	} 
	void AllyGuardPlus(){
		muhSkills thisSkill = muhSkills.AllyGuardPlus;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.removeTileHighlights();
		TroopScript Target;
		GameManager.instance.highlightTilesAt(Caster.gridPosition,Color.cyan,1);
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction) {
						Target = p;
						NewFightScript.AllyGuard(Caster,Target,Skill.FromListOfSkills(thisSkill));
							
			
		

				
		
		//animations and shit go here
		GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
		SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}}
	public void AnkleSnareActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AnkleSnare).EnergyCost)
			SwitchThis = muhSkills.AnkleSnare;
		else Debug.Log("NO ENERGY");

	}
	void AnkleSnare(){
		muhSkills thisSkill = muhSkills.AnkleSnare;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.removeTileHighlights();

		GameManager.instance.highlightTilesAt(Caster.gridPosition,Color.cyan,1);
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) {
				targetTile.Trappedby = Caster;
			
				
		
		
		
		//animations and shit go here
		GameManager.instance.removeTileHighlights();
				Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
				if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
					Caster.SetEnergy(0);
		SwitchThis = muhSkills.NoSkill;
				Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
				Caster.actionPoints--;
			}}}
	public void AssassinateActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Assassinate).EnergyCost)
			SwitchThis = muhSkills.Assassinate;
		else Debug.Log("NO ENERGY");

	}
	void Assassinate(){
		muhSkills thisSkill = muhSkills.Assassinate;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.removeTileHighlights();
		TroopScript Target;
		GameManager.instance.highlightTilesAt(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.Assassinate(Caster,Target);				
						
						
						
						
						
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}}
	public void BattleGroundPreparation (){
		muhSkills thisSkill = muhSkills.BattlegroundPreparation;

		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(thisSkill).EnergyCost){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		//Add stuff to increase the battle ratio for the faction
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}
		else Debug.Log("NOT ENOUGH ENERGY");
	}
	public void BattleRatingDown (){
		muhSkills thisSkill = muhSkills.BattleRatingDown;

		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(thisSkill).EnergyCost){
			TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
			//Add stuff to lower the battle ratio of the opponent 
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}
		else Debug.Log("NOT ENOUGH ENERGY");
	}
	public void BattleRatingDown2 (){
		muhSkills thisSkill = muhSkills.BattleRatingDown2;

		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(thisSkill).EnergyCost){
			TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
			//Add stuff to lower the battle ratio of the opponent 
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}
		else Debug.Log("NOT ENOUGH ENERGY");
	}
	public void BowAttackActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.BowAttack).EnergyCost)
			SwitchThis = muhSkills.BowAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	void BowAttack(){
		muhSkills thisSkill = muhSkills.BowAttack;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	//I KNOW THIS IS AWFUL CODE AND I SHOULD JUST MAKE ONE METHOD BUT DOES IT MAKE ANY DIFFERENCE 
	public void BowAttackMikoActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.BowAttackMiko).EnergyCost)
			SwitchThis = muhSkills.BowAttackMiko;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	void BowAttackMiko(){
		muhSkills thisSkill = muhSkills.BowAttackMiko;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void BowAttackPlusActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.BowAttackPlus).EnergyCost)
			SwitchThis = muhSkills.BowAttackPlus;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	void BowAttackPlus(){
		muhSkills thisSkill = muhSkills.BowAttackPlus;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void CannonNormalAttackActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CannonNormalAttack).EnergyCost)
			SwitchThis = muhSkills.CannonNormalAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void CannonNormalAttack(){
		muhSkills thisSkill = muhSkills.CannonNormalAttack;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void CannonStrongAttackActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CannonStrongAttack).EnergyCost)
			SwitchThis = muhSkills.CannonStrongAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void CannonStrongAttack(){
		muhSkills thisSkill = muhSkills.CannonStrongAttack;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void CarefulAttackActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CarefulAttack).EnergyCost)
			SwitchThis = muhSkills.CarefulAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void CarefulAttack(){
		muhSkills thisSkill = muhSkills.CarefulAttack;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target = null;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void CarryActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Carry).EnergyCost)
			SwitchThis = muhSkills.Carry;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void Carry(){
		muhSkills thisSkill = muhSkills.Carry;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.magenta,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction) {
						Target = p;
					//	GameManager.instance.players.Remove(Target);
					//	GameManager.instance.playerTurns.Remove(Target);
						Target.gameObject.SetActive(false);
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.CarryingThisNigga = Target;
						Caster.AddSkillToList(muhSkills.Drop);
						Caster.RemoveSkillToList(thisSkill);
						Target.gridPosition = new Vector2 (666,666); //SATAN HOLD MY CARRIED PLAYERS
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void DropActivate(){
		SwitchThis = muhSkills.Drop;

	}
	
	void Drop(){
		muhSkills thisSkill = muhSkills.Drop;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.magenta,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target = null;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction && p.GetMuhClass()==muhClasses.Cavalry) {
						Target =p;
						//	GameManager.instance.players.Remove(Target);
						//	GameManager.instance.playerTurns.Remove(Target);
						Target.CarryingThisNigga = Caster.CarryingThisNigga;
						Caster.CarryingThisNigga = null;
						Caster.AddSkillToList(muhSkills.Carry);
						Caster.RemoveSkillToList(thisSkill);
						//animations and shit go here

						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						GameManager.instance.removeTileHighlights();
						SwitchThis = muhSkills.NoSkill;
						Debug.Log ("Nig");
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}
					else if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction && p.GetMuhClass()!=muhClasses.Cavalry)
						Debug.Log("You can't pass the one you are carrying to "+p.GetChief().GetName());
					else if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction)
						Debug.Log ("What are you doing?");
							
				
				}

				if (Target==null)
				{
				//	Caster.CarryingThisNigga = ((GameObject)Instantiate(GameManager.instance.UserTroopPrefab, new Vector3(GameManager.instance.MousePosition.x - Mathf.Floor(GameManager.instance.mapSize/2),1.5f, -GameManager.instance.MousePosition.y + Mathf.Floor(GameManager.instance.mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserTroop>();
					Caster.CarryingThisNigga.gridPosition = GameManager.instance.MousePosition;
					Caster.CarryingThisNigga.transform.position= new Vector3(GameManager.instance.MousePosition.x - Mathf.Floor(GameManager.instance.mapSize/2),1.5f, -GameManager.instance.MousePosition.y + Mathf.Floor(GameManager.instance.mapSize/2));
					Caster.CarryingThisNigga.gameObject.SetActive(true);
					Caster.CarryingThisNigga = null;

					Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
					GameManager.instance.removeTileHighlights();
					SwitchThis = muhSkills.NoSkill;
					Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
					Caster.actionPoints--;
				}
			
			}}
	}
	public void CavalryChargeActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CavalryCharge).EnergyCost)
			SwitchThis = muhSkills.CavalryCharge;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void CavalryCharge(){
		muhSkills thisSkill = muhSkills.CavalryCharge;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}


	public void CavalryCharge2Activate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CavalryCharge2).EnergyCost)
			SwitchThis = muhSkills.CavalryCharge2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void CavalryCharge2(){
		muhSkills thisSkill = muhSkills.CavalryCharge2;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	
	
	public void ChinkChinkShurikenActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.ChinkChinkShuriken).EnergyCost)
			SwitchThis = muhSkills.ChinkChinkShuriken;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void ChinkChinkShuriken(){
		muhSkills thisSkill = muhSkills.ChinkChinkShuriken;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void CleanUpActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CleanUp).EnergyCost)
			SwitchThis = muhSkills.CleanUp;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void CleanUp(){
		muhSkills thisSkill = muhSkills.CleanUp;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						float skillDamage = NewFightScript.DamageScalingCleanUp(Caster,Target);
						mySkill.DamageScaling = skillDamage;
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void ConvertActionActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.ConvertAction).EnergyCost)
			SwitchThis = muhSkills.ConvertAction;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void ConvertAction(){
		muhSkills thisSkill = muhSkills.ConvertAction;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction) {
						Target = p;
					if (Target.GetEnergy()<Target.GetMaxEnergy())
							Target.SetEnergy(Target.GetEnergy()+1);
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}

	public void ConvertAction2Activate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.ConvertAction2).EnergyCost)
			SwitchThis = muhSkills.ConvertAction;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void ConvertAction2(){
		muhSkills thisSkill = muhSkills.ConvertAction2;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction) {
						Target = p;
						if (Target.GetEnergy()<Target.GetMaxEnergy())
							Target.SetEnergy(Target.GetEnergy()+2);
						if (Target.GetEnergy()>Target.GetMaxEnergy())
							Target.SetEnergy(Target.GetMaxEnergy());
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void CrossbowAttackActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CrossbowAttack).EnergyCost)
			SwitchThis = muhSkills.CrossbowAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void CrossbowAttack(){
		muhSkills thisSkill = muhSkills.CrossbowAttack;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void CrossbowAttackPlusActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CrossbowAttackPlus).EnergyCost)
			SwitchThis = muhSkills.CrossbowAttackPlus;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void CrossbowAttackPlus(){
		muhSkills thisSkill = muhSkills.CrossbowAttackPlus;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void DepoisonActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Depoison).EnergyCost)
			SwitchThis = muhSkills.Depoison;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Depoison(){
		muhSkills thisSkill = muhSkills.Depoison;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition) {
						Target = p;
						Target.Poisoned = 0;
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void FellowTroopRevengeActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FellowTroopsRevenge).EnergyCost)
			SwitchThis = muhSkills.FellowTroopsRevenge;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FellowsTroopRevenge(){
		muhSkills thisSkill = muhSkills.FellowTroopsRevenge;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition&& p.Faction != Caster.Faction) {
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						mySkill.DamageScaling = NewFightScript.DamageScalingRevenge(Caster);

						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void FireBlastActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FireBlast).EnergyCost)
			SwitchThis = muhSkills.FireBlast;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FireBlast(){
		muhSkills thisSkill = muhSkills.FireBlast;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void FollowThroughActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FollowThrough).EnergyCost)
			SwitchThis = muhSkills.FollowThrough;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FollowThrough(){
		muhSkills thisSkill = muhSkills.FollowThrough;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						int BattleGauge = GameManager.instance.BattleGauge;
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						if (BattleGauge>50)
							mySkill.DamageScaling = 3;
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void FootSoldierAttackActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FootSoldierAttack).EnergyCost)
			SwitchThis = muhSkills.FootSoldierAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FootSoldierAttack(){
		muhSkills thisSkill = muhSkills.FootSoldierAttack2;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void FootSoldierAttack2Activate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FootSoldierAttack2).EnergyCost)
			SwitchThis = muhSkills.FootSoldierAttack2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FootSoldierAttack2(){
		muhSkills thisSkill = muhSkills.FootSoldierAttack;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void FrostDiverActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FrostDiver).EnergyCost)
			SwitchThis = muhSkills.FrostDiver;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FrostDiver(){
		muhSkills thisSkill = muhSkills.FrostDiver;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.FrostDiver));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						if (!Target.Frozen)
							Target.Frozen = true;
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(muhSkills.FrostDiver).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void FullPowerChargeActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FullPowerCharge).EnergyCost)
			SwitchThis = muhSkills.FullPowerCharge;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FullPowerCharge(){
		muhSkills thisSkill = muhSkills.FullPowerCharge;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void FullPowerCharge2Activate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FullPowerCharge2).EnergyCost)
			SwitchThis = muhSkills.FullPowerCharge2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FullPowerCharge2(){
		muhSkills thisSkill = muhSkills.FullPowerCharge2;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void GuardBreakActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.GuardBreak).EnergyCost)
			SwitchThis = muhSkills.GuardBreak;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void GuardBreak(){
		muhSkills thisSkill = muhSkills.GuardBreak;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						if (Target.GetPhalanx()==true)
							Target.SetPhalanx(false);
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void GuardCancelActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.GuardCancel).EnergyCost)
			SwitchThis = muhSkills.GuardCancel;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void GuardCancel(){
		muhSkills thisSkill = muhSkills.GuardCancel;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						Target.GuardedBy =null;
						Target.GuardedByPercent = 0;
						for (int i=0;i<GameManager.instance.players.Count;i++){
							if (GameManager.instance.players[i].GuardedBy == Target)
								GameManager.instance.players[i].GuardedBy = null;
							GameManager.instance.players[i].GuardedByPercent = 0;
						}
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void HalveEnergyActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.HalveEnergy).EnergyCost)
			SwitchThis = muhSkills.GuardCancel;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void HalveEnergy(){
		muhSkills thisSkill = muhSkills.HalveEnergy;

		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						Target.SetEnergy(Mathf.RoundToInt(Target.GetEnergy()/2));
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(muhSkills.HalveEnergy).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}

	public void HealingMist(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		muhSkills thisSkill = muhSkills.HealingMist;



			
				foreach (TroopScript p in  GameManager.instance.players) {
					if ( p.Faction == Caster.Faction) {
						
				NewFightScript.HealingTarget(Caster,p,Skill.FromListOfSkills(muhSkills.HealingMist).HealScaling);
						//animations and shit go here
			}
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(muhSkills.HalveEnergy).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
			}}
	public void IceWallActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Icewall).EnergyCost)
			SwitchThis = muhSkills.Icewall;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	void IceWall(){
		muhSkills thisSkill = muhSkills.Icewall;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		bool horizontal = true;
		if (IceWallRotationvalue>1.2f)
			IceWallRotationvalue = 1.2f;
		else if (IceWallRotationvalue<.8f)
			IceWallRotationvalue = .8f;
		 IceWallRotationvalue+=Input.GetAxis("Mouse ScrollWheel");
		horizontal = IceWallRotationvalue> 1 ? true:false;
		List <Tile> IceWallLocations =  GameManager.instance.highLightIceWall(Caster.gridPosition,GameManager.instance.MousePosition,horizontal);
		if (Input.GetMouseButtonDown(0))
		    if (IceWallLocations.Count == 3){
			for (int i = 0;i<3;i++){
				GameManager.instance.removeTileHighlights();
				GameManager.instance.CreateIcewall(IceWallLocations[i].gridPosition,Caster);
				Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
				if (Skill.FromListOfSkills(muhSkills.Icewall).DepleteEnergy == true)
					Caster.SetEnergy(0);
				SwitchThis = muhSkills.NoSkill;
				Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
				Caster.actionPoints--;
			}
		}
		else Debug.Log("Can't summon the ice there!");



	}
	public void KnightAttackActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.KnightAttack).EnergyCost)
			SwitchThis = muhSkills.KnightAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void KnightAttack(){
		muhSkills thisSkill = muhSkills.KnightAttack;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void KnightAttack2Activate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.KnightAttack2).EnergyCost)
			SwitchThis = muhSkills.KnightAttack2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void KnightAttack2(){
		muhSkills thisSkill = muhSkills.KnightAttack2;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void KnightChargeActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.KnightCharge).EnergyCost)
			SwitchThis = muhSkills.KnightCharge;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void KnightCharge(){
		muhSkills thisSkill = muhSkills.KnightCharge;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						Skill mySkill = Skill.FromListOfSkills(muhSkills.KnightCharge);
						mySkill.DamageScaling = Caster.GetNumber()<Target.GetNumber()? 3:1.5f;
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void LightAttackActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.LightAttack).EnergyCost)
			SwitchThis = muhSkills.LightAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void LightAttack(){
		muhSkills thisSkill = muhSkills.LightAttack;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void LightningActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Lightning).EnergyCost)
			SwitchThis = muhSkills.Lightning;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Lightning(){
		muhSkills thisSkill = muhSkills.Lightning;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);

		if (Input.GetMouseButtonDown(0)){
			List<TroopScript> Targets =GameManager.instance.Lightning(Caster.gridPosition);
		
				foreach (TroopScript p in  Targets) {
					if (p.Faction != Caster.Faction) {
						
						
						NewFightScript.MeleeFightingScript(Caster,p,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						
				}}
			GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
				}}
	public void LootActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Loot).EnergyCost)
			SwitchThis = muhSkills.Loot;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Loot(){
		muhSkills thisSkill = muhSkills.Loot;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						GameManager.instance.BattleGold+=1000;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void MagicGuardActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.MagicGuard).EnergyCost)
			SwitchThis = muhSkills.MagicGuard;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void MagicGuard(){
		muhSkills thisSkill = muhSkills.MagicGuard;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction) {
						Target = p;
						Target.isMagicGuarded = true;
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void MagicGuardAroundActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.MagicGuard).EnergyCost)
			SwitchThis = muhSkills.MagicGuard;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void MagicGuardAround(){
		muhSkills thisSkill = muhSkills.MagicGuardAround;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);

		if (Input.GetMouseButtonDown(0)){	
		
				List<TroopScript> Targets =GameManager.instance.Lightning(Caster.gridPosition);
				foreach (TroopScript p in  Targets) {
					if (p.Faction == Caster.Faction) {
						
					p.isMagicGuarded = true;
						
						//animations and shit go here
						
					}}
						
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
					}}
	
	public void MaimActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Maim).EnergyCost)
			SwitchThis = muhSkills.Maim;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Maim(){
		muhSkills thisSkill = muhSkills.Maim;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						Target.Maim(NewFightScript.CalculateMaimRatio(Caster,Target));
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
						
					}}}}
	}
	public void Meditate(){
		muhSkills thisSkill = muhSkills.Meditate;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		Caster.SetEnergy(Caster.GetEnergy()+1);
		if (Caster.GetEnergy()>Caster.GetMaxEnergy())
			Caster.SetEnergy(Caster.GetMaxEnergy());
		Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
		Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
		if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
			Caster.SetEnergy(0);
		SwitchThis = muhSkills.NoSkill;
		Caster.actionPoints--;
	}
	public void Meditate2(){
		muhSkills thisSkill = muhSkills.Meditate2;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		Caster.SetEnergy(Caster.GetEnergy()+2);
		if (Caster.GetEnergy()>Caster.GetMaxEnergy())
			Caster.SetEnergy(Caster.GetMaxEnergy());
		Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
		Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
		if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
			Caster.SetEnergy(0);
		SwitchThis = muhSkills.NoSkill;
		Caster.actionPoints--;
	}
	public void MikoDanceActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.MikoDance).EnergyCost)
			SwitchThis = muhSkills.MikoDance;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void MikoDance(){
		muhSkills thisSkill = muhSkills.MikoDance;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction) {
						Target = p;
						NewFightScript.HealingTarget (Caster,Target,Skill.FromListOfSkills(thisSkill).HealScaling);
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void MikoDancePlusActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.MikoDancePlus).EnergyCost)
			SwitchThis = muhSkills.MikoDancePlus;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void MikoDancePlus(){
		muhSkills thisSkill = muhSkills.MikoDancePlus;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction) {
						Target = p;
						NewFightScript.HealingTarget (Caster,Target,Skill.FromListOfSkills(thisSkill).HealScaling);
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void MikoDanceQuickActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.MikoDanceQuick).EnergyCost)
			SwitchThis = muhSkills.MikoDanceQuick;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void MikoDanceQuick(){
		muhSkills thisSkill = muhSkills.MikoDanceQuick;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction == Caster.Faction) {
						Target = p;
						NewFightScript.HealingTarget (Caster,Target,Skill.FromListOfSkills(thisSkill).HealScaling);
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void MikoStorm (){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		Caster.SetPreparation(muhSkills.MikoStorm);
	}
	public void MikoStorm2 (){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		Caster.SetPreparation(muhSkills.MikoStorm2);
	}
	public void MikoStormEffect(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.MikoDanceQuick).EnergyCost)
		{TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
			muhSkills thisSkill = muhSkills.MikoStorm;
			NewFightScript.MikoStorm(Caster,GameManager.instance.players,Skill.FromListOfSkills(thisSkill).FullHPPercentDamage);
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");

	}
	public void MikoStorm2Effect(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.MikoDanceQuick).EnergyCost)
		{TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
			muhSkills thisSkill = muhSkills.MikoStorm2;
			NewFightScript.MikoStorm(Caster,GameManager.instance.players,Skill.FromListOfSkills(thisSkill).FullHPPercentDamage);
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
		
	}
	public void MonkChargeActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.MonkCharge).EnergyCost)
			SwitchThis = muhSkills.MonkCharge;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void MonkCharge(){
		muhSkills thisSkill = muhSkills.MonkCharge;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;

						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void MonkChargePlusActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.MonkChargePlus).EnergyCost)
			SwitchThis = muhSkills.MonkChargePlus;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void MonkChargePlus(){
		muhSkills thisSkill = muhSkills.MonkChargePlus;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;

						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void Move (){
		
		int xPos = Mathf.RoundToInt(GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].gridPosition.x);
		int yPos = Mathf.RoundToInt(GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].gridPosition.y);
		Tile _terrain = GameManager.instance.map[xPos][yPos];
		//				NewFightScript.AccurateShots(GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex],1);
		if (_terrain.Trappedby == null || _terrain.Trappedby.Faction == GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].Faction){
			if (!GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].moving) {
				GameManager.instance.removeTileHighlights();
				GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].moving = true;
				GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].attacking = false;
				GameManager.instance.highlightTilesAt(GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].gridPosition, Color.blue,GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetMovement(), false);
			} else {
				GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].moving = false;
				GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].attacking = false;
				GameManager.instance.removeTileHighlights();
			}
		} else Debug.Log ("You got trapped nigga");
		
	}
	
	public void MuhFlags(){
		muhSkills thisSkill = muhSkills.MuhFlags;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		if (Caster.GetEnergy()>= Skill.FromListOfSkills(thisSkill).EnergyCost)
		{
			
			GameManager.instance.SetAdvantage(Caster,Skill.FromListOfSkills(thisSkill).BattleEffect);
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;}
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");

	}
	public void MuhFlags2(){
		muhSkills thisSkill = muhSkills.MuhFlags2;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		if (Caster.GetEnergy()>= Skill.FromListOfSkills(thisSkill).EnergyCost)
		{
			
			GameManager.instance.SetAdvantage(Caster,Skill.FromListOfSkills(thisSkill).BattleEffect);
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
		
	}

	public void OnRushActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.OnRush).EnergyCost)
			SwitchThis = muhSkills.OnRush;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void OnRush(){
		muhSkills thisSkill = muhSkills.OnRush;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void Overtime(){
		muhSkills thisSkill = muhSkills.Overtime;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		if (Caster.GetEnergy()>= Skill.FromListOfSkills(thisSkill).EnergyCost)
		{
			
			GameManager.instance.TotalTime+=Skill.FromListOfSkills(thisSkill).BattleTurns;
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
		
	}
	
	public void Overtime2(){
		muhSkills thisSkill = muhSkills.Overtime2;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		if (Caster.GetEnergy()>= Skill.FromListOfSkills(thisSkill).EnergyCost)
		{
			
			GameManager.instance.TotalTime+=Skill.FromListOfSkills(thisSkill).BattleTurns;
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
		
	}
	public void PassTurn (){
		SwitchThis = muhSkills.NoSkill;
		GameManager.instance.removeTileHighlights();
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].SkillRecoveryTime = Skill.FromListOfSkills(muhSkills.NoSkill).SkillRecoveryTime;
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].actionPoints = 2;
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].moving = false;
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].attacking = false;			
		GameManager.instance.nextTurn();
	}
	public void PenetrationShootActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.PenetrationShoot).EnergyCost)
			SwitchThis = muhSkills.PenetrationShoot;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void PenetrationShoot(){
		muhSkills thisSkill = muhSkills.PenetrationShoot;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void PenetrationShoot2Activate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.PenetrationShoot2).EnergyCost)
			SwitchThis = muhSkills.PenetrationShoot2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void PenetrationShoot2(){
		muhSkills thisSkill = muhSkills.PenetrationShoot2;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void Phalanx(){
		muhSkills thisSkill = muhSkills.Phalanx;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		if (Caster.GetEnergy()>= Skill.FromListOfSkills(thisSkill).EnergyCost)
		{
			
			Caster.SetPhalanx(true);
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;}
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
		
	}
	public void PoisonActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Poison).EnergyCost)
			SwitchThis = muhSkills.Poison;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Poison(){
		muhSkills thisSkill = muhSkills.Poison;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void QuickAttackActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.QuickAttack).EnergyCost)
			SwitchThis = muhSkills.QuickAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void QuickAttack(){
		muhSkills thisSkill = muhSkills.QuickAttack;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void RearGuardChargeActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.RearGuardCharge).EnergyCost)
			SwitchThis = muhSkills.RearGuardCharge;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void RearGuardCharge(){
		muhSkills thisSkill = muhSkills.RearGuardCharge;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;

						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						if (Target.GetCounterMaxRange()>Caster.GetCounterMaxRange())
							mySkill.DamageScaling =3;
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void RemoveBuffsActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.RemoveBuffs).EnergyCost)
			SwitchThis = muhSkills.RemoveBuffs;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void RemoveBuffs(){
		muhSkills thisSkill = muhSkills.RemoveBuffs;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						Target.RemoveAllbuffs();
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void RemoveBuffsAroundActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.RemoveBuffsAround).EnergyCost)
			SwitchThis = muhSkills.RemoveBuffsAround;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void RemoveBuffsAround(){
		muhSkills thisSkill = muhSkills.RemoveBuffsAround;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		if (Input.GetMouseButtonDown(0)){
			List<TroopScript> Targets =GameManager.instance.Lightning(Caster.gridPosition);
			
			foreach (TroopScript p in  Targets) {
				if (p.Faction != Caster.Faction) {
					
					
					p.RemoveAllbuffs();
					//animations and shit go here
					
				}}
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}}			

	public void RemoveBuffsRangedActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.RemoveBuffsRanged).EnergyCost)
			SwitchThis = muhSkills.RemoveBuffsRanged;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void RemoveBuffsRanged(){
		muhSkills thisSkill = muhSkills.RemoveBuffsRanged;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						Target.RemoveAllbuffs();
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void SharpShootActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Sharpshoot).EnergyCost)
			SwitchThis = muhSkills.Sharpshoot;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Sharpshoot(){
		muhSkills thisSkill = muhSkills.Sharpshoot;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		List<TroopScript> Targets = null;
		GameManager.instance.removeTileHighlights();
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);


			Tile targetTile = GameManager.instance.TileUnderMouse;
		if (targetTile !=null)
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) 

			Targets =	GameManager.instance.SharpShoot(Caster,p);
				if (Targets!=null)
				if (Input.GetMouseButtonDown(0)){		                
					foreach (TroopScript k in  Targets) {
						if (k.Faction != Caster.Faction) {
							
							
							NewFightScript.MeleeFightingScript (Caster,k,Skill.FromListOfSkills(thisSkill));
							//animations and shit go here
							
						}}
					//animations and shit go here
					GameManager.instance.removeTileHighlights();
					Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
					if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
						Caster.SetEnergy(0);
					SwitchThis = muhSkills.NoSkill;
					Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
					Caster.actionPoints--;
				}}}}
	public void ShikigamiActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Shikigami).EnergyCost)
			SwitchThis = muhSkills.Shikigami;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Shikigami(){
		muhSkills thisSkill = muhSkills.Shikigami;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];

		GameManager.instance.removeTileHighlights();
		List<Tile> TargetTiles = GameManager.instance.AccurateShotsHighlights(Caster.gridPosition,GameManager.instance.MousePosition,Skill.FromListOfSkills(thisSkill).SkillArea,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(SwitchThis).SkillMaxRange);
		if (Input.GetMouseButtonDown(0)){		                
		for (int i = 0;i<TargetTiles.Count;i++){		
			foreach (TroopScript p in  GameManager.instance.players) {
				if (p.gridPosition == TargetTiles[i].gridPosition && p.Faction != Caster.Faction) 
							
				
					
					
							
							
							NewFightScript.MeleeFightingScript (Caster,p,Skill.FromListOfSkills(thisSkill));
							//animations and shit go here
							
						}}
					//animations and shit go here
					GameManager.instance.removeTileHighlights();
					Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
					if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
						Caster.SetEnergy(0);
					SwitchThis = muhSkills.NoSkill;
					Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
					Caster.actionPoints--;
				}}
	public void Shikigami2Activate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Shikigami2).EnergyCost)
			SwitchThis = muhSkills.Shikigami2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Shikigami2(){
		muhSkills thisSkill = muhSkills.Shikigami2;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		
		GameManager.instance.removeTileHighlights();
		List<Tile> TargetTiles = GameManager.instance.AccurateShotsHighlights(Caster.gridPosition,GameManager.instance.MousePosition,Skill.FromListOfSkills(thisSkill).SkillArea,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(SwitchThis).SkillMaxRange);
		if (Input.GetMouseButtonDown(0)){		                
			for (int i = 0;i<TargetTiles.Count;i++){		
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == TargetTiles[i].gridPosition && p.Faction != Caster.Faction) 
						
						
						
						
						
						
						NewFightScript.MeleeFightingScript (Caster,p,Skill.FromListOfSkills(thisSkill));
					//animations and shit go here
					
				}}
			//animations and shit go here
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}}
	public void ShootActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Shoot).EnergyCost)
			SwitchThis = muhSkills.Shoot;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Shoot(){
		muhSkills thisSkill = muhSkills.Shoot;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						Skill mySkill = Skill.FromListOfSkills(thisSkill);

						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void ShoutingChargeActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.ShoutingCharge).EnergyCost)
			SwitchThis = muhSkills.ShoutingCharge;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void ShoutingCharge(){
		muhSkills thisSkill = muhSkills.ShoutingCharge;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}	
	public void ShurikenActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Shuriken).EnergyCost)
			SwitchThis = muhSkills.Shuriken;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Shuriken(){
		muhSkills thisSkill = muhSkills.Shuriken;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}	
	public void Shuriken2Activate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Shuriken2).EnergyCost)
			SwitchThis = muhSkills.Shuriken2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Shuriken2(){
		muhSkills thisSkill = muhSkills.Shuriken2;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}	
	public void SonicShurikenActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.SonicShuriken).EnergyCost)
			SwitchThis = muhSkills.SonicShuriken;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void SonicShuriken(){
		muhSkills thisSkill = muhSkills.SonicShuriken;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void StormGustActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.StormGust).EnergyCost)
			SwitchThis = muhSkills.StormGust;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void StormGust(){
		muhSkills thisSkill = muhSkills.StormGust;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		
		GameManager.instance.removeTileHighlights();
		List<Tile> TargetTiles = GameManager.instance.AccurateShotsHighlights(Caster.gridPosition,GameManager.instance.MousePosition,Skill.FromListOfSkills(thisSkill).SkillArea,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(SwitchThis).SkillMaxRange);
		if (Input.GetMouseButtonDown(0)){		                
			for (int i = 0;i<TargetTiles.Count;i++){		
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == TargetTiles[i].gridPosition && p.Faction != Caster.Faction) 
						
						
						
						
						
						
						NewFightScript.MeleeFightingScript (Caster,p,Skill.FromListOfSkills(thisSkill));
					//animations and shit go here
					
				}}
			//animations and shit go here
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}}
	public void StrongBowAttackActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.StrongBowAttack).EnergyCost)
			SwitchThis = muhSkills.StrongBowAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void StrongBowAttack(){
		muhSkills thisSkill = muhSkills.StrongBowAttack;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void StrongFootAttackActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.StrongFootAttack).EnergyCost)
			SwitchThis = muhSkills.StrongFootAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void StrongFootAttack(){
		muhSkills thisSkill = muhSkills.StrongFootAttack;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void StrongFootAttack2Activate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.StrongFootAttack2).EnergyCost)
			SwitchThis = muhSkills.StrongFootAttack2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void StrongFootAttack2(){
		muhSkills thisSkill = muhSkills.StrongFootAttack2;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void SummonTrashActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.SummonTrash).EnergyCost)
			SwitchThis = muhSkills.SummonTrash;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void SummonTrashSet(){
		muhSkills thisSkill = muhSkills.SummonTrash;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesAt(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMaxRange,false);


		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{

				Caster.SetPreparation (thisSkill);
				Caster.SetPreparationTargetTile(targetTile);		
						
								
						//animations and shit go here
						
					}}
	}	
	public void SummonTrashEffect (TroopScript Caster,Tile TargetTile){
		muhSkills thisSkill = muhSkills.SummonTrash;
		TroopScript Target = null;
		for (int i = 0;i<GameManager.instance.players.Count;i++)
		if (GameManager.instance.players[i].gridPosition == TargetTile.gridPosition){
			Target = GameManager.instance.players[i];
			NewFightScript.SummonYogurtOntoPlayer(Target,Caster);
		}
		if (Target == null)
			GameManager.instance.SummonYogurt (TargetTile.gridPosition,Caster);
		Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
		if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
			Caster.SetEnergy(0);
		SwitchThis = muhSkills.NoSkill;
		Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
		Caster.actionPoints--;
	}
	public void SweepingFireActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.SweepingFire).EnergyCost)
			SwitchThis = muhSkills.SweepingFire;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	void SweepingFire(){

		muhSkills thisSkill = muhSkills.SummonTrash;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		List <Tile> TargetTiles = GameManager.instance.SweepingFire(Caster.gridPosition,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(SwitchThis).SkillMaxRange);
		if (Input.GetMouseButtonDown(0) && TargetTiles.Count >0){
			foreach (TroopScript p in GameManager.instance.players){
				if (p.Faction != Caster.Faction)
					NewFightScript.MeleeFightingScript(Caster,p,Skill.FromListOfSkills(thisSkill));
			}
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}
	}
	public void TenshiDivineTrash(){
		muhSkills thisSkill = muhSkills.TenshiDivineTrash;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		if (Caster.GetEnergy()>= Skill.FromListOfSkills(thisSkill).EnergyCost)
		{
			
			NewFightScript.HealingTarget(Caster,Caster,Skill.FromListOfSkills(thisSkill).HealScaling);
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;}
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
		
	}
	public void TenshiDivineTrash2(){
		muhSkills thisSkill = muhSkills.TenshiDivineTrash2;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		if (Caster.GetEnergy()>= Skill.FromListOfSkills(thisSkill).EnergyCost)
		{
			
			NewFightScript.HealingTarget(Caster,Caster,Skill.FromListOfSkills(thisSkill).HealScaling);
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;}
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
		
	}
	public void VolleyActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Volley).EnergyCost)
			SwitchThis = muhSkills.Volley;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Volley(){
		muhSkills thisSkill = muhSkills.Volley;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		
		GameManager.instance.removeTileHighlights();
		List<Tile> TargetTiles = GameManager.instance.AccurateShotsHighlights(Caster.gridPosition,GameManager.instance.MousePosition,Skill.FromListOfSkills(thisSkill).SkillArea,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(SwitchThis).SkillMaxRange);
		if (Input.GetMouseButtonDown(0)){		                
			for (int i = 0;i<TargetTiles.Count;i++){		
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == TargetTiles[i].gridPosition && p.Faction != Caster.Faction) 
						
						
						
						
						
						
						NewFightScript.MeleeFightingScript (Caster,p,Skill.FromListOfSkills(thisSkill));
					//animations and shit go here
					
				}}
			//animations and shit go here
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
			if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
			Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
			Caster.actionPoints--;
		}}
	public void WarriorAttackActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.WarriorAttack).EnergyCost)
			SwitchThis = muhSkills.WarriorAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void WarriorAttack(){
		muhSkills thisSkill = muhSkills.WarriorAttack;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void WarriorAttack2Activate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.WarriorAttack2).EnergyCost)
			SwitchThis = muhSkills.WarriorAttack2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void WarriorAttack2(){
		muhSkills thisSkill = muhSkills.WarriorAttack2;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(thisSkill).SkillMinRange,Skill.FromListOfSkills(thisSkill).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						
						Skill mySkill = Skill.FromListOfSkills(thisSkill);
						
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
						Caster.actionPoints--;
					}}}}
	}
	public void WhiteDestructionBeamActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.WhiteDestructionBeam).EnergyCost)
			SwitchThis = muhSkills.WhiteDestructionBeam;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	public void WhiteDestructionBeam(){
		muhSkills thisSkill = muhSkills.WhiteDestructionBeam;
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		List <Tile> TilesHit = GameManager.instance.WhiteDestructionBeam(Caster);
		List <TroopScript> Targets;

		if (Input.GetMouseButtonDown(0)){
			for (int i = 0;i<TilesHit.Count;i++){
			foreach (TroopScript p in  GameManager.instance.players) {
				if (p.gridPosition == TilesHit[i].gridPosition && p.Faction != Caster.Faction) {
					
					
					
					NewFightScript.MeleeFightingScript(Caster,p,Skill.FromListOfSkills(thisSkill));			
						//animations and shit go here}
					GameManager.instance.removeTileHighlights();
					Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(thisSkill).EnergyCost);
					if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
						Caster.SetEnergy(0);
					SwitchThis = muhSkills.NoSkill;
					Caster.SkillRecoveryTime = Skill.FromListOfSkills(thisSkill).SkillRecoveryTime;
					Caster.actionPoints--;
					}}}
		}
	}


}





