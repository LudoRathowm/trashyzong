using UnityEngine;
using System.Collections;

public class PortraitHolder : MonoBehaviour {

	public static PortraitHolder instance;
	
	public Sprite EnemyOne;
	public Sprite EnemyTwo;
	public Sprite EnemyThree;
	public Sprite PlayerOne;
	public Sprite PlayerTwo;
	public Sprite PlayerThree;
	public Sprite None;
	void Awake() {
		instance = this;
	}
}
