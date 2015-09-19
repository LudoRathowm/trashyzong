using UnityEngine;
using System.Collections;

public class PortraitHolder : MonoBehaviour {

	public static PortraitHolder instance;
	
	public Sprite EnemyOne;
	public Sprite EnemyTwo;
	public Sprite EnemyThree;
	public Sprite EnemyFour;
	public Sprite PlayerOne;
	public Sprite PlayerTwo;
	public Sprite PlayerThree;
	public Sprite PlayerFour;
	public Sprite None;
	void Awake() {
		instance = this;
	}
}
