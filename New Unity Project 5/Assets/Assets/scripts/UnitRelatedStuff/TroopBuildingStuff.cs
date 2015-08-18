using UnityEngine;
using System.Collections;

public class TroopBuildingStuff : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
















	static int TroopRecruitingCost (int numberofPeople, int costOfPeople, int costModifier){
		return numberofPeople*costOfPeople*costModifier;
	}












}
