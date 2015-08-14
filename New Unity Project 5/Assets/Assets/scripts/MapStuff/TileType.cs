using UnityEngine;
using System.Collections;

public enum TileType {
	BraidedStreamBed, //if it rains, it quickly becomes water tiles with high speed
	RockOutcrop, //gas the kikes. basically a street with less movement. lower number of units
	Cliff, //basically a wall
	Water, //if the speed is low, you can ford it.
	Lava, //impassable terrain
	Street, //movequick
	Grass, //less movement
	TallGrass, //cant be seen/reduced movement
	Desert, //harder to move, damage reduction
	SunDesert, //^ but with shitty weather that kills you
	Snow, //hard to move, damage reduction
	CompressedSnow, //after you walk over it
	HeavySnow, //shitty weather + tiles goes back to snow after a bit
	Ice, //min. movement range
	Swamp, //if hurt you get infected and die in the next few turns
	Forest, //harder to move, ranged reduction
	ThickForest, //harder to move, cavalry cant move, immune to ranged
	Impassible
}
