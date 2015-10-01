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
					Targets[k].CancelPreparation();
				Targets[k].FlushPreparationTarget();
					if (Targets[k].GetEnergy()>0)Targets[k].SetEnergy(Targets[k].GetEnergy()-1);
				}
				SwitchThis = muhSkills.NoSkill;

			//animations and shit go here
			GameManager.instance.removeTileHighlights();
			Caster.actionPoints-=Skill.FromListOfSkills(muhSkills.AccurateShots).EnergyCost;;
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
	//THERE IS A REASON FOR NOW MAKING ONE METHOD I NEED TO CHANGE ANIMATIONS
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





