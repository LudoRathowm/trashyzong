﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AITroop : TroopScript{

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		public override void Update () {
			if (GameManager.instance.players[GameManager.instance.currentPlayerIndex] == this) {
				transform.GetChild(1).gameObject.SetActive(true);
				//transform.GetComponent<Renderer>().material.color = Color.green; //
			} else {
				transform.GetChild(1).gameObject.SetActive(false);
				//transform.GetComponent<Renderer>().material.color = Color.white;
			}
			base.Update();
		}
		
		public override void TurnUpdate ()
		{
			if (positionQueue.Count > 0) {
				transform.position += (positionQueue[0] - transform.position).normalized * moveSpeed * Time.deltaTime;
				
				if (Vector3.Distance(positionQueue[0], transform.position) <= 0.1f) {
					transform.position = positionQueue[0];
					positionQueue.RemoveAt(0);
					if (positionQueue.Count == 0) {
						actionPoints--;
					}
				}
				
			} else {
				//priority queueue
				List<Tile> attacktilesInRange = TileHighlight.FindHighlight(GameManager.instance.map[(int)gridPosition.x][(int)gridPosition.y], GetRange(), true);
				//List<Tile> movementToAttackTilesInRange = TileHighlight.FindHighlight(GameManager.instance.map[(int)gridPosition.x][(int)gridPosition.y], movementPerActionPoint + attackRange);
				List<Tile> movementTilesInRange = TileHighlight.FindHighlight(GameManager.instance.map[(int)gridPosition.x][(int)gridPosition.y],GetMovement() + 1000);
				//blabla range, lowest hp, not ai
				if (attacktilesInRange.Where(x => GameManager.instance.players.Where (y => y.GetType() != typeof(AITroop) && y.GetNumber() > 0 && y != this && y.gridPosition == x.gridPosition).Count() > 0).Count () > 0) {
					var opponentsInRange = attacktilesInRange.Select(x => GameManager.instance.players.Where (y => y.GetType() != typeof(AITroop) && y.GetNumber() > 0 && y != this && y.gridPosition == x.gridPosition).Count () > 0 ? GameManager.instance.players.Where(y => y.gridPosition == x.gridPosition).First() : null).ToList();
					TroopScript opponent = opponentsInRange.OrderBy (x => x != null ? -x.GetNumber() : 1000).First ();
					
					GameManager.instance.removeTileHighlights();
					moving = false;
					attacking = true;
					GameManager.instance.highlightTilesAt(gridPosition, Color.red, GetRange());
					
					GameManager.instance.attackWithCurrentPlayer(GameManager.instance.map[(int)opponent.gridPosition.x][(int)opponent.gridPosition.y]);
				}
				//SHIIIIT
				//			else if (!moving && movementToAttackTilesInRange.Where(x => GameManager.instance.players.Where (y => y.GetType() != typeof(AIPlayer) && y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count() > 0).Count () > 0) {
				//				var opponentsInRange = movementToAttackTilesInRange.Select(x => GameManager.instance.players.Where (y => y.GetType() != typeof(AIPlayer) && y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count () > 0 ? GameManager.instance.players.Where(y => y.gridPosition == x.gridPosition && y.HP > 0).First() : null).ToList();
				//				Player opponent = opponentsInRange.OrderBy (x => x != null ? -x.HP : 1000).ThenBy (x => x != null ? TilePathFinder.FindPath(GameManager.instance.map[(int)gridPosition.x][(int)gridPosition.y],GameManager.instance.map[(int)x.gridPosition.x][(int)x.gridPosition.y]).Count() : 1000).First ();
				//
				//				GameManager.instance.removeTileHighlights();
				//				moving = true;
				//				attacking = false;
				//				GameManager.instance.highlightTilesAt(gridPosition, Color.blue, movementPerActionPoint, false);
				//
				//				List<Tile> path = TilePathFinder.FindPath (GameManager.instance.map[(int)gridPosition.x][(int)gridPosition.y],GameManager.instance.map[(int)opponent.gridPosition.x][(int)opponent.gridPosition.y], GameManager.instance.players.Where(x => x.gridPosition != gridPosition && x.gridPosition != opponent.gridPosition).Select(x => x.gridPosition).ToArray());
				//				if (path.Count() > 1) { 
				//					GameManager.instance.moveCurrentPlayer(path[(int)Mathf.Max(0, path.Count - 1 - attackRange)]);
				//				}
				//			}
				//move toward nearest opponent, same shit
				else if (!moving && movementTilesInRange.Where(x => GameManager.instance.players.Where (y => y.GetType() != typeof(AITroop) && y.GetNumber() > 0 && y != this && y.gridPosition == x.gridPosition).Count() > 0).Count () > 0) {
					var opponentsInRange = movementTilesInRange.Select(x => GameManager.instance.players.Where (y => y.GetType() != typeof(AITroop) && y.GetNumber() > 0 && y != this && y.gridPosition == x.gridPosition).Count () > 0 ? GameManager.instance.players.Where(y => y.gridPosition == x.gridPosition).First() : null).ToList();
					TroopScript opponent = opponentsInRange.OrderBy (x => x != null ? -x.GetNumber() : 1000).ThenBy (x => x != null ? TilePathFinder.FindPath(GameManager.instance.map[(int)gridPosition.x][(int)gridPosition.y],GameManager.instance.map[(int)x.gridPosition.x][(int)x.gridPosition.y]).Count() : 1000).First ();
					
					GameManager.instance.removeTileHighlights();
					moving = true;
					attacking = false;
					GameManager.instance.highlightTilesAt(gridPosition, Color.blue, GetMovement(), false);
					
					List<Tile> path = TilePathFinder.FindPath (GameManager.instance.map[(int)gridPosition.x][(int)gridPosition.y],GameManager.instance.map[(int)opponent.gridPosition.x][(int)opponent.gridPosition.y], GameManager.instance.players.Where(x => x.gridPosition != gridPosition && x.gridPosition != opponent.gridPosition).Select(x => x.gridPosition).ToArray());
					
					if (path.Count() > 1) {
						List<Tile> actualMovement = TileHighlight.FindHighlight(GameManager.instance.map[(int)gridPosition.x][(int)gridPosition.y], GetMovement(), GameManager.instance.players.Where(x => x.gridPosition != gridPosition).Select(x => x.gridPosition).ToArray());
						path.Reverse();
						if (path.Where(x => actualMovement.Contains(x)).Count() > 0) GameManager.instance.moveCurrentPlayer(path.Where (x => actualMovement.Contains(x)).First());
					}
				}
			}
			
			//		if (!attacking && !moving) {
			//			actionPoints = 2;		
			//			GameManager.instance.nextTurn();
			//			return;
			//		}
			
			if (actionPoints <= 1 && (attacking || moving)) {
				moving = false;
				attacking = false;			
			}
			base.TurnUpdate ();
		}
		
		public override void TurnOnGUI () {
			base.TurnOnGUI ();
		}
	}