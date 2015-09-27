using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class SkillMethods : MonoBehaviour {

	public muhSkills SwitchThis;
	float AccurateShotsArea =2;

	void Update (){
		Debug.Log("CHANGE FRAME");
		SkillsThatRequireUpdate();

	}

	void SkillsThatRequireUpdate(){

		switch (SwitchThis){
		case muhSkills.AccurateShots:
			AccurateShots();
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


		
		if (AccurateShotsArea > 0 && AccurateShotsArea < 4)
			AccurateShotsArea +=Input.GetAxis("Mouse ScrollWheel");

		int	mArea = Mathf.RoundToInt(AccurateShotsArea);
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].attacking = true;
		List<Tile>Targetcells = GameManager.instance.AccurateShotsHighlights(Origin,GameManager.instance.MousePosition,mArea);
			int cells = Targetcells.Count;
			for (int i = 0; i<cells;i++){
				for (int j = 0; j<GameManager.instance.players.Count;j++){
					//if (Targetcells[i].gridPosition == GameManager.instance.players[j].gridPosition && GameManager.instance.players[j].Faction !=GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].Faction)
					if (Targetcells[i].gridPosition == GameManager.instance.players[j].gridPosition)

						if (!Targets.Contains(GameManager.instance.players[j])){
							Targets.Add(GameManager.instance.players[j]);
					Debug.Log ("added "+GameManager.instance.players[j].GetChief().GetName()+" to the list of targets");}
				Debug.Log("count zz:"+Targets.Count);
				}
	if (Input.GetMouseButton(0))
    
				if (Targets.Count > 0){
				Debug.Log("count:"+Targets.Count);
				for (int k = 0;k<Targets.Count;k++){

					float TotalDamage = (float)5/cells;
					Skill damageados = Skill.FromListOfSkills(muhSkills.AccurateShots);
					damageados.DamageScaling = TotalDamage;
					NewFightScript.MeleeFightingScript(GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex],Targets[k],damageados);
					//Targets[i].SetNumber(Targets[i].GetNumber()-kills);
					//if (Targets[i].GetNumber()<0) Targets[i].SetNumber(0);
					Debug.Log(Targets[k].GetChief().GetName());
					Debug.Log("value of k: "+k);
					Targets[i].CancelPreparation();
					if (Targets[i].GetEnergy()>0)Targets[i].SetEnergy(Targets[i].GetEnergy()-1);
				}
				SwitchThis = muhSkills.NoSkill;
			}

			}
		}



	public void PassTurn (){
	
		GameManager.instance.removeTileHighlights();
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].actionPoints = 2;
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].moving = false;
		GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].attacking = false;			
		GameManager.instance.nextTurn();
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







	}





