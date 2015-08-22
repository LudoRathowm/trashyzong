using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TestTurnSpeed : MonoBehaviour {
	List<int> players = new List <int>();
	List<int> playerScaling = new List<int>();
	int guyone = 0;
	int guytwo = 0;
	int guythree = 0;
	int guyfour = 0;
	int guyfive = 0;
	int onescaling = 2;
	int twoscaling = 3;
	int threescaling = 4;
	int fourscaling = 5;
	int fivescaling = 10;
	public bool ChangeTurn = false;
	bool foundnext = false;


	// Use this for initialization
	void Start () {
		players.Add (guyone);
		players.Add (guytwo);
		players.Add (guythree);
		players.Add (guyfour);
		players.Add (guyfive);
		playerScaling.Add(onescaling);
		playerScaling.Add(twoscaling);
		playerScaling.Add(threescaling);
		playerScaling.Add(fourscaling);
		playerScaling.Add(fivescaling);
	}
	
	// Update is called once per frame
	void Update () {
		if (ChangeTurn){
			DecideNextTurn();
			ChangeTurn = false;
		}
	}



	void DecideNextTurn(){
		foundnext = false;
		while (!foundnext)
		for (int i = 0; i<players.Count;i++)
			if (players[i] < 100)
				players[i]+=playerScaling[i];
			else {players[i] = 0;
				Debug.Log ("it's "+i+"'s turn");
			foundnext = true;
		}





	}


}
