using UnityEngine;
using System.Collections;

public class SpriteHolder : MonoBehaviour {

	public static SpriteHolder instance;
	
	public Sprite BASE_TILE_PREFAB;
	
	public Sprite TILE_BRAIDED_STREAM_BED;
	public Sprite TILE_ROCK_OUTCROP;
	public Sprite TILE_CLIFF;
	public Sprite TILE_WATER;
	public Sprite TILE_LAVA;
	public Sprite TILE_STREET;
	public Sprite TILE_GRASS;
	public Sprite TILE_TALLGRASS;
	public Sprite TILE_DESERT;
	public Sprite TILE_SUNNY_DESERT;
	public Sprite TILE_SNOW;
	public Sprite TILE_COMPRESSED_SNOW;
	public Sprite TILE_HEAVY_SNOW;
	public Sprite TILE_ICE;
	public Sprite TILE_SWAMP;
	public Sprite TILE_FOREST;
	public Sprite TILE_THICK_FOREST;
	public Sprite Jesus;
	
	void Awake() {
		instance = this;
	}
}
