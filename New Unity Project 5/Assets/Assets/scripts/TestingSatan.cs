using UnityEngine;
using System.Collections;

public class TestingSatan : MonoBehaviour {
	public int numberofniggers;
	public int commanderability;
	public TileType muhtile;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("nigga",1,1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void nigga (){
		int vagoo = Random.Range(1,100);
		bool benis = Satan.SuccessCalculator(vagoo);
		Debug.Log (benis + "  " + vagoo);

	}
}
