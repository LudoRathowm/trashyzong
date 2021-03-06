using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TileHighlight {
	
	public TileHighlight () {
		
	}

	public static List<Tile> FindHighlight(Tile originTile, int movementPoints) {
		return FindHighlight(originTile, movementPoints, new Vector2[0], false,false);
	}
	public static List<Tile> FindHighlight(Tile originTile, int movementPoints, bool staticRange) {
		return FindHighlight(originTile, movementPoints, new Vector2[0], staticRange,false);
	}
	public static List<Tile> FindHighlight(Tile originTile, int movementPoints, Vector2[] occupied) {

		return FindHighlight(originTile, movementPoints, occupied, false,false);
	}

	public static List<Tile> AreaHighlight (Tile originTile, int distance, Vector2[] removethis){
		return FindHighlight (originTile,distance,removethis,true,true);

	}

	public static List<Tile> FindHighlight (Tile originTile, int movementPoints, bool staticRange, bool dontremoveorigin){
		return FindHighlight(originTile,movementPoints,new Vector2[0],staticRange,dontremoveorigin);
	}

	public static List<Tile> FindHighlight (Tile originTile, int movementPoints, Vector2[] occupied, bool dontremoveorigin){

		return FindHighlight(originTile,movementPoints,occupied,true,dontremoveorigin);
	}

	public static List<Tile> FindHighlight(Tile originTile, int movementPoints, Vector2[] occupied, bool staticRange, bool dontremoveorigin) {
		List<Tile> closed = new List<Tile>();
		List<TilePath> open = new List<TilePath>();

		
		TilePath originPath = new TilePath();
		if (staticRange) originPath.addStaticTile(originTile);
		else originPath.addTile(originTile);

		open.Add(originPath);
		
		while (open.Count > 0) {
			TilePath current = open[0];
			open.Remove(open[0]);
			
			if (closed.Contains(current.lastTile)) {
				continue;
			} 
			if (current.costOfPath > movementPoints + 1.5f) {
				continue;
			}


	


		closed.Add(current.lastTile);
			
			foreach (Tile t in current.lastTile.neighbors) {	

				if (t.impassible ||
				    occupied.Contains(t.gridPosition)||
				    (GameManager.instance.GetComponent<GameManager>(). playerTurns[GameManager.instance.GetComponent<GameManager>().PlayerTurnIndex].GetPhalanx()==true&&t.frontLiners<16)) continue;
				TilePath newTilePath = new TilePath(current);
				if (staticRange) newTilePath.addStaticTile(t);
				else newTilePath.addTile(t);
				open.Add(newTilePath);
			}
		}

		closed.Remove(originTile);
		closed.Distinct();

		if (dontremoveorigin && !occupied.Contains(originTile.gridPosition))
		closed.Add(originTile);
		return closed;
	}
}
