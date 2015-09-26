using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public class SkillMethods : MonoBehaviour {
	public muhSkills SwitchThis;
	float AccurateShotsArea =2;
	void Update (){
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







	public void ActivateAccurateShots(){
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
					if (Targetcells[i].gridPosition == GameManager.instance.players[j].gridPosition && GameManager.instance.players[j].Faction !=GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex].Faction)
						if (!Targets.Contains(GameManager.instance.players[j]))
							Targets.Add(GameManager.instance.players[j]);
				}
    if (Targets.Count>0)
				if (Input.GetMouseButtonDown(0)){
				for (int k = 0;k<Targets.Count;k++){

					float TotalDamage = (float)5/cells;
					Skill damageados = Skill.FromListOfSkills(muhSkills.AccurateShots);
					damageados.DamageScaling = TotalDamage;
					NewFightScript.MeleeFightingScript(GameManager.instance.playerTurns[GameManager.instance.PlayerTurnIndex],Targets[k],damageados);
					//Targets[i].SetNumber(Targets[i].GetNumber()-kills);
					if (Targets[i].GetNumber()<0) Targets[i].SetNumber(0);
					if (Targets[i].GetPreparation()!=null) Targets[i].CancelPreparation();
					if (Targets[i].GetEnergy()>0)Targets[i].SetEnergy(Targets[i].GetEnergy()-1);
				}
				SwitchThis = muhSkills.NoSkill;
			}

			}
		}

	}





