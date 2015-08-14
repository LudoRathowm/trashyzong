using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {

	private enum Passive {
		Popular, //easier to recruit for this nigga
		BornLeader // less scaling
	}
	private enum Active {
		SweepingFire, //ignores passive and active skills of the opponent when calculating damage + 1.5* dmg
		Phalanx //90% immunity to rangeados
	}

	public void Popular (){
		//do some stuff
	}
}
