using UnityEngine;
using System.Collections;

public class PrefabHolder : MonoBehaviour {
	public static PrefabHolder instance;

	public GameObject BASE_TILE_PREFAB;

	public GameObject TILE_BRAIDED_STREAM_BED;
	public GameObject TILE_ROCK_OUTCROP;
	public GameObject TILE_CLIFF;
	public GameObject TILE_WATER;
	public GameObject TILE_LAVA;
	public GameObject TILE_STREET;
	public GameObject TILE_GRASS;
	public GameObject TILE_TALLGRASS;
	public GameObject TILE_DESERT;
	public GameObject TILE_SUNNY_DESERT;
	public GameObject TILE_SNOW;
	public GameObject TILE_COMPRESSED_SNOW;
	public GameObject TILE_HEAVY_SNOW;
	public GameObject TILE_ICE;
	public GameObject TILE_SWAMP;
	public GameObject TILE_FOREST;
	public GameObject TILE_THICK_FOREST;


	void Awake() {
		instance = this;
	}
}
