using UnityEngine;
using System.Collections;

public class BattleSpriteHolder : MonoBehaviour {
	public static BattleSpriteHolder instance;

	public GameObject PlayerTroop;
	public GameObject AITroop;
	public GameObject Ice;
	public GameObject Ogre;

	void Awake() {
		instance = this;
	}
}
