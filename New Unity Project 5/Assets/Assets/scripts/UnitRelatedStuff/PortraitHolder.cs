using UnityEngine;
using System.Collections;

public class PortraitHolder : MonoBehaviour {

	public static PortraitHolder instance;
	
	public Sprite Creep;
	public Sprite Riccitiello;
	public Sprite Villain;
	public Sprite Fuhrer;
	public Sprite Arino;
	public Sprite Cia;
	public Sprite Bernn;
	public Sprite Prisoner;
	public Sprite None;
	void Awake() {
		instance = this;
	}
}
