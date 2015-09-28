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

		case muhSkills.NoSkill:
			break;
		default:
			break;
		
		}}







	public void ActivateAccurateShots(){ // i didn't add a !busy here because the button will go away if you do something else anyway
		SwitchThis = muhSkills.AccurateShots;
	}
	 void AccurateShots(){
	
		Vector2 Origin = GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].gridPosition;
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
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].attacking = true;
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
					NewFightScript.MeleeFightingScript(GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex],Targets[k],damageados);
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
			GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].actionPoints--;
		}}
	public void AdvanceTime (){
		GameManager.instance.CurrentTime +=2;
	}
	public void AdvanceTime2(){
		GameManager.instance.CurrentTime +=4;
	}
	public void AimAndShootActivate(){
		SwitchThis =muhSkills.AimAndShoot;	
	}
	public void AimAndShootSet(){
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
				Caster.actionPoints-=2;
				SwitchThis = muhSkills.NoSkill;
				GameManager.instance.removeTileHighlights();

			}
		
		}
		}

	public void Move (){
		
		int xPos = Mathf.RoundToInt(GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].gridPosition.x);
		int yPos = Mathf.RoundToInt(GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].gridPosition.y);
		Tile _terrain = GameManager.instance.map[xPos][yPos];
		//				NewFightScript.AccurateShots(GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex],1);
		if (!_terrain.Trapped){
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





