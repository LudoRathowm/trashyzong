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
		List<Tile>Targetcells = GameManager.instance.AccurateShotsHighlights(Origin,GameManager.instance.MousePosition,mArea);
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
			GameManager.instance.removeTileHighlights();
			Caster.SetEnergy(Caster.GetEnergy()-Skill.FromListOfSkills(muhSkills.AccurateShots).EnergyCost);
			if (Skill.FromListOfSkills(muhSkills.AccurateShots).DepleteEnergy == true)
				Caster.SetEnergy(0);
		}}
	public void AdvanceTime (){
		GameManager.instance.CurrentTime +=2;
		}
	public void AdvanceTime2(){
		GameManager.instance.CurrentTime +=4;
	}
	public void AimAndShootActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AimAndShoot).EnergyCost)
			SwitchThis = muhSkills.AimAndShoot;
		else Debug.Log("NO ENERGY");
	}
	void AimAndShootSet(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.removeTileHighlights();
		Caster.moving = false;
		//Caster.attacking = true;
		TroopScript target = null;
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,0,Skill.FromListOfSkills(muhSkills.AimAndShoot).SkillMaxRange);
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
				Caster.SetPreparation(muhSkills.AimAndShoot);
				Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.AimAndShoot).EnergyCost;
				SwitchThis = muhSkills.NoSkill;
				GameManager.instance.removeTileHighlights();
				if (Skill.FromListOfSkills(muhSkills.AimAndShoot).DepleteEnergy == true)
					Caster.SetEnergy(0);
			}
		
		}
		}
	public void AimAndShootEffect (TroopScript Caster, TroopScript Target){
		NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.AimAndShoot));
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].SetPreparation(muhSkills.NoSkill);
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].SetPreparationTargetPlayer(null);
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].SetPreparationTargetTile(null);

		//all the animations and shit 
	}
	public void AllGuardActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AllGuard).EnergyCost)
			SwitchThis = muhSkills.AllGuard;
		else Debug.Log("NO ENERGY");
	}
	void AllGuard (){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.removeTileHighlights();
		List <TroopScript> Targets = new List<TroopScript>();
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.gray,0,Skill.FromListOfSkills(muhSkills.AllGuard).SkillMaxRange);
		if (Input.GetMouseButtonDown(0)){
			for (int i = 0; i < GameManager.instance.mapSize; i++) {
				for (int j = 0; j < GameManager.instance.mapSize; j++) {
					for (int k = 0;k<GameManager.instance.players.Count;k++)
					if (GameManager.instance.map[i][j].visual.transform.GetComponent<Renderer>().materials[0].color == Color.gray && GameManager.instance.map[i][j].gridPosition == GameManager.instance.players[k].gridPosition && GameManager.instance.players[k].Faction == Caster.Faction && GameManager.instance.players[k] != Caster)
							Targets.Add (GameManager.instance.players[k]);
				}
			}
			for (int i = 0;i<Targets.Count;i++)
				NewFightScript.AllyGuard(Caster,Targets[i],Skill.FromListOfSkills(muhSkills.AllGuard));

			//animations and shit go here
			GameManager.instance.removeTileHighlights();
			Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.AllGuard).EnergyCost;
			if (Skill.FromListOfSkills(muhSkills.AllGuard).DepleteEnergy == true)
				Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
		}
				
				
		
	}
	public void AllyGuardActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AllyGuard).EnergyCost)
			SwitchThis = muhSkills.AllyGuard;
		else Debug.Log("NO ENERGY");
	} 
	void AllyGuard(){
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
						NewFightScript.AllyGuard(Caster,Target,Skill.FromListOfSkills(muhSkills.AllyGuard));

					
				
    		
			

			//animations and shit go here
			GameManager.instance.removeTileHighlights();
			Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.AllyGuard).EnergyCost;
						
						if (Skill.FromListOfSkills(muhSkills.AllyGuard).DepleteEnergy == true)
							Caster.SetEnergy(0);
			SwitchThis = muhSkills.NoSkill;
	}}}}}
	public void AllyGuardPlusActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AllyGuard).EnergyCost)
			SwitchThis = muhSkills.AllyGuard;
		else Debug.Log("NO ENERGY");
	} 
	void AllyGuardPlus(){
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
						NewFightScript.AllyGuard(Caster,Target,Skill.FromListOfSkills(muhSkills.AllyGuardPlus));
							
			
		

				
		
		//animations and shit go here
		GameManager.instance.removeTileHighlights();
		Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.AllyGuardPlus).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.AllyGuardPlus).DepleteEnergy == true)
							Caster.SetEnergy(0);
		SwitchThis = muhSkills.NoSkill;
					}}}}}
	public void AnkleSnareActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.AnkleSnare).EnergyCost)
			SwitchThis = muhSkills.AnkleSnare;
		else Debug.Log("NO ENERGY");

	}
	void AnkleSnare(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.removeTileHighlights();

		GameManager.instance.highlightTilesAt(Caster.gridPosition,Color.cyan,1);
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) {
				targetTile.Trappedby = Caster;
			
				
		
		
		
		//animations and shit go here
		GameManager.instance.removeTileHighlights();
		Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.AnkleSnare).EnergyCost;
				if (Skill.FromListOfSkills(muhSkills.AnkleSnare).DepleteEnergy == true)
					Caster.SetEnergy(0);
		SwitchThis = muhSkills.NoSkill;
			}}}
	public void AssassinateActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Assassinate).EnergyCost)
			SwitchThis = muhSkills.Assassinate;
		else Debug.Log("NO ENERGY");

	}
	void Assassinate(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.removeTileHighlights();
		TroopScript Target;
		GameManager.instance.highlightTilesAt(Caster.gridPosition,Color.red,1);
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.Assassinate(Caster,Target);				
						
						
						
						
						
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.Assassinate).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.Assassinate).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
					}}}}}
	public void BattleGroundPreparation (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.BattlegroundPreparation).EnergyCost){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		//Add stuff to increase the battle ratio for the faction
			Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.BattlegroundPreparation).EnergyCost;
			if (Skill.FromListOfSkills(muhSkills.BattlegroundPreparation).DepleteEnergy == true)
				Caster.SetEnergy(0);

		}
		else Debug.Log("NOT ENOUGH ENERGY");
	}
	public void BattleRatingDown (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.BattleRatingDown).EnergyCost){
			TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
			//Add stuff to lower the battle ratio of the opponent 
			Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.BattleRatingDown).EnergyCost;
			if (Skill.FromListOfSkills(muhSkills.BattleRatingDown).DepleteEnergy == true)
				Caster.SetEnergy(0);
			
		}
		else Debug.Log("NOT ENOUGH ENERGY");
	}
	public void BattleRatingDown2 (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.BattleRatingDown2).EnergyCost){
			TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
			//Add stuff to lower the battle ratio of the opponent 
			Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.BattleRatingDown2).EnergyCost;
			if (Skill.FromListOfSkills(muhSkills.BattleRatingDown2).DepleteEnergy == true)
				Caster.SetEnergy(0);
			
		}
		else Debug.Log("NOT ENOUGH ENERGY");
	}
	public void BowAttackActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.BowAttack).EnergyCost)
			SwitchThis = muhSkills.BowAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	void BowAttack(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.BowAttack).SkillMinRange,Skill.FromListOfSkills(muhSkills.BowAttack).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.BowAttack));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.BowAttack).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.BowAttack).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
					
					}}}}
	}
	//I KNOW THIS IS AWFUL CODE AND I SHOULD JUST MAKE ONE METHOD BUT DOES IT MAKE ANY DIFFERENCE 
	public void BowAttackMikoActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.BowAttackMiko).EnergyCost)
			SwitchThis = muhSkills.BowAttackMiko;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	void BowAttackMiko(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.BowAttackMiko).SkillMinRange,Skill.FromListOfSkills(muhSkills.BowAttackMiko).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.BowAttackMiko));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.BowAttackMiko).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.BowAttackMiko).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void BowAttackPlusActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.BowAttackPlus).EnergyCost)
			SwitchThis = muhSkills.BowAttackPlus;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	void BowAttackPlus(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.BowAttackPlus).SkillMinRange,Skill.FromListOfSkills(muhSkills.BowAttackPlus).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.BowAttackPlus));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.BowAttackPlus).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.BowAttackPlus).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void CannonNormalAttackActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CannonNormalAttack).EnergyCost)
			SwitchThis = muhSkills.CannonNormalAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void CannonNormalAttack(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.CannonNormalAttack).SkillMinRange,Skill.FromListOfSkills(muhSkills.CannonNormalAttack).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.CannonNormalAttack));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.CannonNormalAttack).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.CannonNormalAttack).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void CannonStrongAttackActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CannonStrongAttack).EnergyCost)
			SwitchThis = muhSkills.CannonStrongAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void CannonStrongAttack(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.CannonStrongAttack).SkillMinRange,Skill.FromListOfSkills(muhSkills.CannonStrongAttack).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.CannonStrongAttack));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.CannonStrongAttack).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.CannonStrongAttack).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void CarefulAttackActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CarefulAttack).EnergyCost)
			SwitchThis = muhSkills.CarefulAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void CarefulAttack(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.CarefulAttack).SkillMinRange,Skill.FromListOfSkills(muhSkills.CarefulAttack).SkillMaxRange);
		TroopScript Target = null;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.CarefulAttack));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.CarefulAttack).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.CarefulAttack).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void CarryActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Carry).EnergyCost)
			SwitchThis = muhSkills.Carry;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void Carry(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.magenta,Skill.FromListOfSkills(muhSkills.Carry).SkillMinRange,Skill.FromListOfSkills(muhSkills.Carry).SkillMaxRange);
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
						Caster.RemoveSkillToList(muhSkills.Carry);
						Target.gridPosition = new Vector2 (666,666); //SATAN HOLD MY CARRIED PLAYERS
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.Carry).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.Carry).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						Caster.actionPoints--;
					}}}}
	}
	public void DropActivate(){
		SwitchThis = muhSkills.Drop;

	}
	
	void Drop(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.magenta,Skill.FromListOfSkills(muhSkills.Drop).SkillMinRange,Skill.FromListOfSkills(muhSkills.Drop).SkillMaxRange);
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
						Caster.RemoveSkillToList(muhSkills.Drop);
						//animations and shit go here
						Caster.actionPoints--;
						GameManager.instance.removeTileHighlights();
						SwitchThis = muhSkills.NoSkill;
						Debug.Log ("Nig");
						
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
					Caster.actionPoints--;
					GameManager.instance.removeTileHighlights();
					SwitchThis = muhSkills.NoSkill;
				}
			
			}}
	}
	public void CavalryChargeActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CavalryCharge).EnergyCost)
			SwitchThis = muhSkills.CavalryCharge;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void CavalryCharge(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.CavalryCharge).SkillMinRange,Skill.FromListOfSkills(muhSkills.CavalryCharge).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.CavalryCharge));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.CavalryCharge).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.CavalryCharge).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}


	public void CavalryCharge2Activate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CavalryCharge2).EnergyCost)
			SwitchThis = muhSkills.CavalryCharge2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void CavalryCharge2(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.CavalryCharge2).SkillMinRange,Skill.FromListOfSkills(muhSkills.CavalryCharge2).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.CavalryCharge2));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.CavalryCharge).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.CavalryCharge2).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	
	
	public void ChinkChinkShurikenActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.ChinkChinkShuriken).EnergyCost)
			SwitchThis = muhSkills.ChinkChinkShuriken;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	
	void ChinkChinkShuriken(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.ChinkChinkShuriken).SkillMinRange,Skill.FromListOfSkills(muhSkills.ChinkChinkShuriken).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.ChinkChinkShuriken));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.ChinkChinkShuriken).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.ChinkChinkShuriken).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void CleanUpActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CleanUp).EnergyCost)
			SwitchThis = muhSkills.CleanUp;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void CleanUp(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.CleanUp).SkillMinRange,Skill.FromListOfSkills(muhSkills.CleanUp).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						Skill mySkill = Skill.FromListOfSkills(muhSkills.CleanUp);
						float skillDamage = NewFightScript.DamageScalingCleanUp(Caster,Target);
						mySkill.DamageScaling = skillDamage;
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.CleanUp).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.CleanUp).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void ConvertActionActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.ConvertAction).EnergyCost)
			SwitchThis = muhSkills.ConvertAction;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void ConvertAction(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.ConvertAction).SkillMinRange,Skill.FromListOfSkills(muhSkills.ConvertAction).SkillMaxRange);
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
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.ConvertAction).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.ConvertAction).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}

	public void ConvertAction2Activate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.ConvertAction2).EnergyCost)
			SwitchThis = muhSkills.ConvertAction;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void ConvertAction2(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.ConvertAction2).SkillMinRange,Skill.FromListOfSkills(muhSkills.ConvertAction2).SkillMaxRange);
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
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.ConvertAction).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.ConvertAction2).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void CrossbowAttackActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CrossbowAttack).EnergyCost)
			SwitchThis = muhSkills.CrossbowAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void CrossbowAttack(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.CrossbowAttack).SkillMinRange,Skill.FromListOfSkills(muhSkills.CrossbowAttack).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.CrossbowAttack));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.CrossbowAttack).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.CrossbowAttack).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void CrossbowAttackPlusActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.CrossbowAttackPlus).EnergyCost)
			SwitchThis = muhSkills.CrossbowAttackPlus;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void CrossbowAttackPlus(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.CrossbowAttackPlus).SkillMinRange,Skill.FromListOfSkills(muhSkills.CrossbowAttackPlus).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.CrossbowAttackPlus));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.CrossbowAttackPlus).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.CrossbowAttackPlus).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void DepoisonActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Depoison).EnergyCost)
			SwitchThis = muhSkills.Depoison;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void Depoison(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.Depoison).SkillMinRange,Skill.FromListOfSkills(muhSkills.Depoison).SkillMaxRange);
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
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.Depoison).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.Depoison).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void FellowTroopRevengeActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FellowTroopsRevenge).EnergyCost)
			SwitchThis = muhSkills.FellowTroopsRevenge;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FellowsTroopRevenge(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.FellowTroopsRevenge).SkillMinRange,Skill.FromListOfSkills(muhSkills.FellowTroopsRevenge).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition&& p.Faction != Caster.Faction) {
						Skill mySkill = Skill.FromListOfSkills(muhSkills.FellowTroopsRevenge);
						mySkill.DamageScaling = NewFightScript.DamageScalingRevenge(Caster);

						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.FellowTroopsRevenge).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.FellowTroopsRevenge).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void FireBlastActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FireBlast).EnergyCost)
			SwitchThis = muhSkills.FireBlast;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FireBlast(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.FireBlast).SkillMinRange,Skill.FromListOfSkills(muhSkills.FireBlast).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.FireBlast));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.FireBlast).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.FireBlast).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void FollowThroughActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FollowThrough).EnergyCost)
			SwitchThis = muhSkills.FollowThrough;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FollowThrough(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.FollowThrough).SkillMinRange,Skill.FromListOfSkills(muhSkills.FollowThrough).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						int BattleGauge = GameManager.instance.BattleGauge;
						Skill mySkill = Skill.FromListOfSkills(muhSkills.FollowThrough);
						if (BattleGauge>50)
							mySkill.DamageScaling = 3;
						NewFightScript.MeleeFightingScript(Caster,Target,mySkill);			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.FollowThrough).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.FollowThrough).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void FootSoldierAttackActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FootSoldierAttack).EnergyCost)
			SwitchThis = muhSkills.FootSoldierAttack;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FootSoldierAttack(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.FootSoldierAttack).SkillMinRange,Skill.FromListOfSkills(muhSkills.FootSoldierAttack).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.FootSoldierAttack));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.FootSoldierAttack).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.FootSoldierAttack).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void FootSoldierAttack2Activate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FootSoldierAttack2).EnergyCost)
			SwitchThis = muhSkills.FootSoldierAttack2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FootSoldierAttack2(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.FootSoldierAttack2).SkillMinRange,Skill.FromListOfSkills(muhSkills.FootSoldierAttack2).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.FootSoldierAttack2));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.FootSoldierAttack2).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.FootSoldierAttack2).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void FrostDiverActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FrostDiver).EnergyCost)
			SwitchThis = muhSkills.FrostDiver;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FrostDiver(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.FrostDiver).SkillMinRange,Skill.FromListOfSkills(muhSkills.FrostDiver).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.FrostDiver));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						if (!Target.Frozen)
							Target.Frozen = true;
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.FrostDiver).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.FrostDiver).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void FullPowerChargeActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FullPowerCharge).EnergyCost)
			SwitchThis = muhSkills.FullPowerCharge;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FullPowerCharge(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.FullPowerCharge).SkillMinRange,Skill.FromListOfSkills(muhSkills.FullPowerCharge).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.FullPowerCharge));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.FullPowerCharge).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.FullPowerCharge).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void FullPowerCharge2Activate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.FullPowerCharge2).EnergyCost)
			SwitchThis = muhSkills.FullPowerCharge2;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void FullPowerCharge2(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.FullPowerCharge2).SkillMinRange,Skill.FromListOfSkills(muhSkills.FullPowerCharge2).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.FullPowerCharge2));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.FullPowerCharge2).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.FullPowerCharge2).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void GuardBreakActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.GuardBreak).EnergyCost)
			SwitchThis = muhSkills.GuardBreak;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void GuardBreak(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.GuardBreak).SkillMinRange,Skill.FromListOfSkills(muhSkills.GuardBreak).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.GuardBreak));			
						//animations and shit go here
						if (Target.GetPhalanx()==true)
							Target.SetPhalanx(false);
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.GuardBreak).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.GuardBreak).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void GuardCancelActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.GuardCancel).EnergyCost)
			SwitchThis = muhSkills.GuardCancel;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void GuardCancel(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.GuardCancel).SkillMinRange,Skill.FromListOfSkills(muhSkills.GuardCancel).SkillMaxRange);
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
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.GuardCancel).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.GuardCancel).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}
	public void HalveEnergyActivate (){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.HalveEnergy).EnergyCost)
			SwitchThis = muhSkills.GuardCancel;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}	
	void HalveEnergy(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.HalveEnergy).SkillMinRange,Skill.FromListOfSkills(muhSkills.HalveEnergy).SkillMaxRange);
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
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.HalveEnergy).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.HalveEnergy).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}}}
	}

	public void HealingMist(){
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];



			
				foreach (TroopScript p in  GameManager.instance.players) {
					if ( p.Faction == Caster.Faction) {
						
				NewFightScript.HealingTarget(Caster,p,Skill.FromListOfSkills(muhSkills.HealingMist).HealScaling);
						//animations and shit go here
			}
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.HalveEnergy).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.HalveEnergy).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
			}}
	public void IceWallActivate(){
		if (GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].GetEnergy()>= Skill.FromListOfSkills(muhSkills.Icewall).EnergyCost)
			SwitchThis = muhSkills.Icewall;
		else Debug.Log("NOT ENOUGHTTTTTT ENERGY");
	}
	void IceWall(){
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
				Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.Icewall).EnergyCost;
				if (Skill.FromListOfSkills(muhSkills.Icewall).DepleteEnergy == true)
					Caster.SetEnergy(0);
				SwitchThis = muhSkills.NoSkill;
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
		TroopScript Caster = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex];
		GameManager.instance.highlightTilesRing(Caster.gridPosition,Color.red,Skill.FromListOfSkills(muhSkills.KnightAttack).SkillMinRange,Skill.FromListOfSkills(muhSkills.KnightAttack).SkillMaxRange);
		TroopScript Target;
		if (Input.GetMouseButtonDown(0)){
			Tile targetTile = GameManager.instance.TileUnderMouse;
			if (targetTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !targetTile.impassible) 			{
				foreach (TroopScript p in  GameManager.instance.players) {
					if (p.gridPosition == targetTile.gridPosition && p.Faction != Caster.Faction) {
						Target = p;
						NewFightScript.MeleeFightingScript(Caster,Target,Skill.FromListOfSkills(muhSkills.KnightAttack));			
						//animations and shit go here
						GameManager.instance.removeTileHighlights();
						Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.KnightAttack).EnergyCost;
						if (Skill.FromListOfSkills(muhSkills.KnightAttack).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
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
						Caster.actionPoints-=Skill.FromListOfSkills(thisSkill).EnergyCost;
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
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
						Caster.actionPoints-=Skill.FromListOfSkills(thisSkill).EnergyCost;
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
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
						Caster.actionPoints-=Skill.FromListOfSkills(thisSkill).EnergyCost;
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
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
						Caster.actionPoints-=Skill.FromListOfSkills(thisSkill).EnergyCost;
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
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
						Caster.actionPoints-=Skill.FromListOfSkills(thisSkill).EnergyCost;
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
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
						Caster.actionPoints-=Skill.FromListOfSkills(thisSkill).EnergyCost;
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
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
						Caster.actionPoints-=Skill.FromListOfSkills(thisSkill).EnergyCost;
						if (Skill.FromListOfSkills(thisSkill).DepleteEnergy == true)
							Caster.SetEnergy(0);
						SwitchThis = muhSkills.NoSkill;
						
					}}
	

	
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
	


	public void PassTurn (){
	
		GameManager.instance.removeTileHighlights();
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].actionPoints = 2;
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].moving = false;
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].attacking = false;			
		GameManager.instance.nextTurn();
		}












	}





