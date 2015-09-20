using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

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
