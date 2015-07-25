using UnityEngine;
using System.Collections;

public class FightScript : MonoBehaviour {
	private int atknumber;
	private int defnumber;
	private int atkavgatk;
	private int defavgatk;
	private int atkavgspeed;
	private int defavgspeed;

	// Use this for initialization
	void Start () {
	
	}

	/*
	 how this is going to work:
1. take in the averaged speed for attacker and attacked
2. once it's decided who strikes first, you take in terrain, etc.. to decide the entity of the attack (hit chance per attacker, weapon type, atk per atker,etc..)
3. you take in terrain,etc.. to decide the entity of the defender (dodge chance per defender, etc..)
4. you make those clash, considering the weapon/armor triangle
5. repeat for the defender with adjusted numbers
*/
	bool AttackerStrikesFirst (int atkavgspeed, int defavgspeed){

		return atkavgspeed>defavgspeed;
	}


}
