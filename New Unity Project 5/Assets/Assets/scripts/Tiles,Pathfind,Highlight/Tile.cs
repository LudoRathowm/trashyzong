using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	public float rangedDefence;
	public int frontLiners;
	public int waterSpeed;
	public int softNess;
	public int turnLeft;
	public bool isFrozen;
	public bool isCompressed;
	public bool unhealthyWeather;
	public bool harmfulWeather;
	public bool canBeSeen;





	
	GameObject PREFAB;
	
	public GameObject visual;
	
	public TileType type = TileType.Street;
	
	public Vector2 gridPosition = Vector2.zero;
	
	public float movementCost = 1;
	public bool impassible = false;
	
	public List<Tile> neighbors = new List<Tile>();
	
	// Use this for initialization
	void Start () {
		if (Application.loadedLevelName == "gameScene") generateNeighbors(); //just generateneighbors for most levels anyway
	}
	
	public void generateNeighbors() {		
		neighbors = new List<Tile>();
		
		//up
		if (gridPosition.y > 0) {
			Vector2 n = new Vector2(gridPosition.x, gridPosition.y - 1);
			neighbors.Add(GameManager.instance.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}
		//down
		if (gridPosition.y < GameManager.instance.mapSize - 1) {
			Vector2 n = new Vector2(gridPosition.x, gridPosition.y + 1);
			neighbors.Add(GameManager.instance.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}		
		
		//left
		if (gridPosition.x > 0) {
			Vector2 n = new Vector2(gridPosition.x - 1, gridPosition.y);
			neighbors.Add(GameManager.instance.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}
		//right
		if (gridPosition.x < GameManager.instance.mapSize - 1) {
			Vector2 n = new Vector2(gridPosition.x + 1, gridPosition.y);
			neighbors.Add(GameManager.instance.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter() {
		if (Application.loadedLevelName == "MapCreatorScene" && Input.GetMouseButton(0)) {
			setType(MapCreatorManager.instance.palletSelection);
		}
	}
	
	void OnMouseExit() {
		
	}
	
	
	void OnMouseDown() { //i think this might be the one giving the bug but im not sure
		if (Application.loadedLevelName == "gameScene") {
			if (GameManager.instance.players[GameManager.instance.currentPlayerIndex].moving) {
				GameManager.instance.moveCurrentPlayer(this);
			} else if (GameManager.instance.players[GameManager.instance.currentPlayerIndex].attacking) {
				GameManager.instance.attackWithCurrentPlayer(this);
			} /*else {
				impassible = impassible ? false : true;
				if (impassible) {
					visual.transform.GetComponent<Renderer>().materials[0].color = new Color(.5f, .5f, 0.0f);
				} else {
					visual.transform.GetComponent<Renderer>().materials[0].color = Color.white;
				}
			}*/
		} else if (Application.loadedLevelName == "MapCreatorScene") {
			setType(MapCreatorManager.instance.palletSelection);
		}
	}
	
	public void setType(TileType t) {
		type = t;
		//definitions of TileType properties
		switch(t) {

		case TileType.BraidedStreamBed:
			movementCost = 1.7f;
			impassible = false;
			rangedDefence = 0;
			frontLiners = 15;
			waterSpeed = 0;
			softNess = 20;
			turnLeft = 0;
			isFrozen = false;
		    isCompressed = false;
			unhealthyWeather = false;
            harmfulWeather = false;
		    canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_BRAIDED_STREAM_BED;
			break;

		case TileType.Cliff:
			movementCost = 9999;
			impassible = true;
			rangedDefence = 0;
			frontLiners = 0;
			waterSpeed = 0;
			softNess = 0;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_CLIFF;
			break;

		case TileType.CompressedSnow:
			movementCost = 2;
			impassible = false;
			rangedDefence = 0;
			frontLiners = 12;
			waterSpeed = 0;
			softNess = 20;
			turnLeft = 2;
			isFrozen = false;
			isCompressed = true;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_COMPRESSED_SNOW;
			break;

		case TileType.Desert:
			movementCost = 4;
			impassible = false;
			rangedDefence = 0.8f;
			frontLiners = 10;
			waterSpeed = 0;
			softNess = 60;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_DESERT;
			break;

		case TileType.Forest:
			movementCost = 5;
			impassible = false;
			rangedDefence = 0.4f;
			frontLiners = 5;
			waterSpeed = 0;
			softNess = 20;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_FOREST;
			break;

		case TileType.Grass:
			movementCost = 1.5f;
			impassible = false;
			rangedDefence = 0;
			frontLiners = 15;
			waterSpeed = 0;
			softNess = 30;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_GRASS;
			break;

		case TileType.HeavySnow:
			movementCost = 10;
			impassible = false;
			rangedDefence = 0.3f;
			frontLiners = 6;
			waterSpeed = 0;
			softNess = 60;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = true;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_HEAVY_SNOW;
			break;

		case TileType.Ice:
			movementCost = 3;
			impassible = false;
			rangedDefence = 0;
			frontLiners = 10;
			waterSpeed = 0;
			softNess = 0;
			turnLeft = 2;
			isFrozen = true;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_ICE;
			break;

		case TileType.Lava:
			movementCost = 9999;
			impassible = true;
			rangedDefence = 0;
			frontLiners = 0;
			waterSpeed = 0;
			softNess = 0;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_LAVA;
			break;

		case TileType.RockOutcrop:
			movementCost = 5;
			impassible = false;
			rangedDefence = 0;
			frontLiners = 5;
			waterSpeed = 0;
			softNess = 0;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_ROCK_OUTCROP;
			break;

		case TileType.Snow:
			movementCost = 5;
			impassible = false;
			rangedDefence = 0;
			frontLiners = 5;
			waterSpeed = 0;
			softNess = 60;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_SNOW;
			break;

		case TileType.Street:
			movementCost = 0.5f;
			impassible = false;
			rangedDefence = 0;
			frontLiners = 20;
			waterSpeed = 0;
			softNess = 0;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_STREET;
			break;
		
		case TileType.SunDesert:
			movementCost = 4;
			impassible = false;
			rangedDefence = 0;
			frontLiners = 11;
			waterSpeed = 0;
			softNess = 40;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = true;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_SUNNY_DESERT;
			break;

		case TileType.Swamp:
			movementCost = 6;
			impassible = false;
			rangedDefence = 0.6f;
			frontLiners = 3;
			waterSpeed = 0;
			softNess = 30;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = true;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_SWAMP;
			break;

		case TileType.TallGrass:
			movementCost = 2;
			impassible = false;
			rangedDefence = 0.7f;
			frontLiners = 12;
			waterSpeed = 0;
			softNess = 40;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = false;
			PREFAB = PrefabHolder.instance.TILE_TALLGRASS;
			break;


		case TileType.ThickForest:
			movementCost = 10;
			impassible = false;
			rangedDefence = 0.1f;
			frontLiners = 2;
			waterSpeed = 0;
			softNess = 20;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = false;
			PREFAB = PrefabHolder.instance.TILE_THICK_FOREST;
			break;

		case TileType.Water:
			movementCost = 15;
			impassible = false;
			rangedDefence = 0;
			frontLiners = 1;
			waterSpeed = 50;
			softNess = 100;
			turnLeft = 0;
			isFrozen = false;
			isCompressed = false;
			unhealthyWeather = false;
			harmfulWeather = false;
			canBeSeen = true;
			PREFAB = PrefabHolder.instance.TILE_WATER;
			break;


		
		default:
			movementCost = 1;
			impassible = false;
			PREFAB = PrefabHolder.instance.TILE_GRASS; //default grass
			break;
		}
		
		generateVisuals();
	}
	
	public void generateVisuals() {
		GameObject container = transform.FindChild("Visuals").gameObject;
		//initially remove all children
		for(int i = 0; i < container.transform.childCount; i++) {
			Destroy (container.transform.GetChild(i).gameObject);
		}
		
		GameObject newVisual = (GameObject)Instantiate(PREFAB, transform.position, Quaternion.Euler(new Vector3(0,0,0)));
		newVisual.transform.parent = container.transform;
		
		visual = newVisual;
	}
}
