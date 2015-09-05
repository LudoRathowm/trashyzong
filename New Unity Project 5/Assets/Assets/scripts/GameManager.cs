using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class GameManager : MonoBehaviour {
	public int TotalTime = 30;
	public int CurrentTime = 0;

	public bool calc;
	public Tile TileUnderMouse;
	public Vector2 MousePosition;
	public static GameManager instance;
	//public LayerMask Units;
	public GameObject TilePrefab;
	public GameObject UserTroopPrefab;
	public GameObject AITroopPrefab;
	
	public int mapSize = 2233;
	Transform mapTransform;
	
	public List <List<Tile>> map = new List<List<Tile>>();
	public List <TroopScript> players = new List<TroopScript>();
	public List <TroopScript> playerTurns = new List<TroopScript>();
public	int PlayerTurnIndex = 0;
	public List<string> playerTurnNamesForShow = new List<string>();
//	public int currentPlayerIndex = 0;

	bool CalculatedNextPlayerTurn = false;


	void Awake() {

		AdjustCamera();

		instance = this;

		mapTransform = transform.FindChild("Map"); //so you center shit around it
	}
	
	// Use this for initialization
	void Start () {		

		generateMap();
		generatePlayers();
	
		while (playerTurns.Count<10)
		DecideNextTurn();
	}
	
	// Update is called once per frame
	void Update () {


		//	GiveInformationOnPlayer();
//		float value = Mathf.Abs(players[0].gridPosition.x-players[1].gridPosition.x)+Mathf.Abs(players[0].gridPosition.y-players[1].gridPosition.y);
//		if (value > 1 && value < 5)
//
//		Debug.Log("the distance between "+ players[0].GetName()+" and "+players[1].GetName()+" is "+value+ " ");

		if (playerTurns[PlayerTurnIndex].GetNumber() > 0) playerTurns[PlayerTurnIndex].TurnUpdate();
		else nextTurn();
	}
	
//	void OnGUI () {
//		if (players[currentPlayerIndex].GetNumber()+players[currentPlayerIndex].GetWounded() > 0) players[currentPlayerIndex].TurnOnGUI();
//	}
	
	public void nextTurn() {	
		CurrentTime++;
		DecideNextTurn();
		PlayerTurnIndex++;
	}

	public void highlightTilesAt(Vector2 originLocation, Color highlightColor, int distance) {
		highlightTilesAt(originLocation, highlightColor, distance, true);
	}

	public void highlightTilesAt(Vector2 originLocation, Color highlightColor, int distance, bool ignorePlayers) {
		//you dont want to highlight a tile where there's someone usually (movement)
		List <Tile> highlightedTiles = new List<Tile>();

		if (ignorePlayers) highlightedTiles = TileHighlight.FindHighlight(map[(int)originLocation.x][(int)originLocation.y], distance, highlightColor == Color.red,false);
		else highlightedTiles = TileHighlight.FindHighlight(map[(int)originLocation.x][(int)originLocation.y], distance,  playerTurns.Where(x => x.gridPosition != originLocation).Select(x => x.gridPosition).ToArray(), highlightColor == Color.red,false);

		foreach (Tile t in highlightedTiles) {
			t.visual.transform.GetComponent<Renderer>().materials[0].color = highlightColor;
		}
	}

	public void highlightTilesRing (Vector2 originLocation, Color highLightColor, int internDistance, int outerDistance){
		List <Tile> Intern = new List<Tile>();
		List <Tile> Extern = new List<Tile>();
		Intern = TileHighlight.FindHighlight(map[(int)originLocation.x][(int)originLocation.y],internDistance,true,false);
		Extern = TileHighlight.FindHighlight(map[(int)originLocation.x][(int)originLocation.y],outerDistance,true,false);
		var _ring = Extern.Except(Intern);
		List <Tile> FinalRing = _ring.ToList();
		foreach (Tile t in FinalRing) {
			t.visual.transform.GetComponent<Renderer>().materials[0].color = highLightColor;
		}

	}

	public List<Tile> AccurateShotsHighlights (Vector2 originLocation, Vector2 mousePosition, int distance, int mouseArea){
		Color targetColor = new Color(ColorAdapter(0),ColorAdapter(255),ColorAdapter(0),1);
		Color AreaColor = new Color(ColorAdapter(153),ColorAdapter(153),ColorAdapter(0),1);

		List<Tile> MouseHighlightedTiles = new List<Tile>();
		List<Tile> TotalArea = new List<Tile>();
		List<Tile> IgnoreCloserTiles = new List<Tile>();
		IgnoreCloserTiles = TileHighlight.FindHighlight(map[(int)originLocation.x][(int)originLocation.y], 2, true,true);
		//Vector2[]_ignoreCloserTiles = IgnoreCloserTiles.Select(x=>x.gridPosition).ToArray();
		TotalArea = TileHighlight.FindHighlight(map[(int)originLocation.x][(int)originLocation.y],distance,true,true);
        var	_AreaHighlightedTiles = TotalArea.Except(IgnoreCloserTiles);
		List <Tile> AreaHighlighted = _AreaHighlightedTiles.ToList();

		MouseHighlightedTiles = TileHighlight.FindHighlight(map[(int)mousePosition.x][(int)mousePosition.y], mouseArea, true,true);

		var _ActuallyMouse = AreaHighlighted.Intersect(MouseHighlightedTiles);
		List<Tile> IntesectionArea = _ActuallyMouse.ToList();

		
		foreach (Tile t in AreaHighlighted) {
			t.visual.transform.GetComponent<Renderer>().materials[0].color = Color.blue;
		}
		foreach (Tile t in IntesectionArea) {
			t.visual.transform.GetComponent<Renderer>().materials[0].color = Color.red;
		}
		return IntesectionArea;
	}



	public static float ColorAdapter(float color){
		return color/255;
	}
	public void removeTileHighlights() {
		for (int i = 0; i < mapSize; i++) {
			for (int j = 0; j < mapSize; j++) {
				if (!map[i][j].impassible) map[i][j].visual.transform.GetComponent<Renderer>().materials[0].color = Color.white;
			}
		}
	}
 	
	public void moveCurrentPlayer(Tile destTile) {
		playerTurns[PlayerTurnIndex].previousWorldPosition = playerTurns[PlayerTurnIndex].transform.position;
		if (destTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !destTile.impassible && playerTurns[PlayerTurnIndex].positionQueue.Count == 0) {
			removeTileHighlights();
			playerTurns[PlayerTurnIndex].moving = false;
			foreach(Tile t in TilePathFinder.FindPath(map[(int)playerTurns[PlayerTurnIndex].gridPosition.x][(int)playerTurns[PlayerTurnIndex].gridPosition.y],destTile, playerTurns.Where(x => x.gridPosition != destTile.gridPosition && x.gridPosition != playerTurns[PlayerTurnIndex].gridPosition).Select(x => x.gridPosition).ToArray())) {
				playerTurns[PlayerTurnIndex].positionQueue.Add(map[(int)t.gridPosition.x][(int)t.gridPosition.y].transform.position + 1.5f * Vector3.up);
			//	Debug.Log("(" + players[currentPlayerIndex].positionQueue[players[currentPlayerIndex].positionQueue.Count - 1].x + "," + players[currentPlayerIndex].positionQueue[players[currentPlayerIndex].positionQueue.Count - 1].y + ")"); //debug shit
			}			
			playerTurns[PlayerTurnIndex].previousGridPosition = playerTurns[PlayerTurnIndex].gridPosition;
			playerTurns[PlayerTurnIndex].gridPosition = destTile.gridPosition;

		} else {
			Debug.Log ("destination invalid");
		//	destTile.visual.transform.GetComponent<Renderer>().materials[0].color = Color.cyan; 
			//if you dont comment this out you can move onto the cell oop
		}
	}
	
	public void attackWithCurrentPlayer(Tile destTile) {
		if (destTile.visual.transform.GetComponent<Renderer>().materials[0].color != Color.white && !destTile.impassible) {
			
			TroopScript target = null;
			foreach (TroopScript p in  players) {
				if (p.gridPosition == destTile.gridPosition) {
					target = p;
				}
			}

			if (target != null) {
				if (playerTurns[PlayerTurnIndex].GetWeapon().weapType == WeaponType.Crossbow){
					playerTurns[PlayerTurnIndex].SetCharge(false);
					Debug.Log( playerTurns[PlayerTurnIndex].GetName()+" has shot his crossbow.");
				}
				//Debug.Log ("p.x: " + players[currentPlayerIndex].gridPosition.x + ", p.y: " + players[currentPlayerIndex].gridPosition.y + " t.x: " + target.gridPosition.x + ", t.y: " + target.gridPosition.y);
//				if (players[currentPlayerIndex].gridPosition.x >= target.gridPosition.x - 1 && players[currentPlayerIndex].gridPosition.x <= target.gridPosition.x + 1 &&
//					players[currentPlayerIndex].gridPosition.y >= target.gridPosition.y - 1 && players[currentPlayerIndex].gridPosition.y <= target.gridPosition.y + 1) {

				playerTurns[PlayerTurnIndex].actionPoints--;
//				if (players[currentPlayerIndex].GetMaxRange() > 1) //rangeds get only one action per turn
//					players[currentPlayerIndex].actionPoints--;
				removeTileHighlights();
				playerTurns[PlayerTurnIndex].attacking = false;			

		
				//to edit

			//	TroopScript TroopOne = players[currentPlayerIndex].thisTroop;
			//	TroopScript TroopTwo = target.thisTroop;
				//melee
		//		NewFightScript.MeleeFightingScript(playerTurns[PlayerTurnIndex],target,1);
			//	UnitInteraction.InteractionMain(playerTurns[PlayerTurnIndex],target,_terrain);

				//attack logic
				//rng is fun
				/*bool hit = Random.Range(0.0f, 1.0f) <= players[currentPlayerIndex].attackChance - target.evade;
				
				if (hit) {
					//damage logic
					int amountOfDamage = Mathf.Max(0, (int)Mathf.Floor(players[currentPlayerIndex].damageBase + Random.Range(0, players[currentPlayerIndex].damageRollSides)) - target.damageReduction);
					
					target.HP -= amountOfDamage;
					
					Debug.Log(players[currentPlayerIndex].playerName + " hit " + target.playerName + " for " + amountOfDamage + " damage!");
				} else {
					Debug.Log(players[currentPlayerIndex].playerName + " missed " + target.playerName + "!");
				}*/
			//  }
			}
		} else {
			Debug.Log ("you cant go there man");
		}
	}
	
	void generateMap() {
		loadMapFromXml();

//		map = new List<List<Tile>>();
//		for (int i = 0; i < mapSize; i++) {
//			List <Tile> row = new List<Tile>();
//			for (int j = 0; j < mapSize; j++) {
//				Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(mapSize/2),0, -j + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
//				tile.gridPosition = new Vector2(i, j);
//				row.Add (tile);
//			}
//			map.Add(row);
//		}
	}


	//CHECK THE PATHFINDER

	void AddStuffToPlayer (TroopScript player,int faction,muhClasses muhclass,Chief leader, int Attack,int Defence,int HitPoints,int Speed,int NumberOfSoldiers,  Weaponry _weapon, Armory _armor){
		Classes ClassToSet = Classes.fromList(muhclass);
		player.Faction = faction;
		player.SetClassDONTUSETHISAREYOUSUREYOUWANTTOUSETHISYOUREALLYSHOULDNT(ClassToSet);
		player.SetChief(leader);
		player.SetBaseAttack(Attack);
		player.SetBaseDefence(Defence);
		player.SetBaseHitpoints(HitPoints);
		player.SetBaseSpeed(Speed);
		player.SetNumber(NumberOfSoldiers);
		player.SetWeapon(_weapon);
		player.SetArmor(_armor);
	}

	void AddStuffToChief (Chief leader, string Name, string Surname, Trait trait, Abilities one, Abilities two, Abilities three,int atk, int def,int inte,int spd){
		leader.SetName(Name);
		leader.SetSurname(Surname);
		leader.SetTrait(trait);
		leader.SetAbilityOne(one);
		leader.SetAbilityTwo(two);
		leader.SetAbilityThree(three);
		leader.SetAttack(atk);
		leader.SetDefense(def);
		leader.SetIntelligence(inte);
		leader.SetSpeed(spd);
	}
	                      
	                      


	void loadMapFromXml() {
		MapXmlContainer container = MapSaveLoad.Load("map.xml");
		
		mapSize = container.size;
		
		//initially remove all children
		for(int i = 0; i < mapTransform.childCount; i++) {
			Destroy (mapTransform.GetChild(i).gameObject);
		}
		
		map = new List<List<Tile>>();
		for (int i = 0; i < mapSize; i++) {
			List <Tile> row = new List<Tile>();
			for (int j = 0; j < mapSize; j++) {
				Tile tile = ((GameObject)Instantiate(PrefabHolder.instance.BASE_TILE_PREFAB, new Vector3(i - Mathf.Floor(mapSize/2),0, -j + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.transform.parent = mapTransform;
				tile.gridPosition = new Vector2(i, j);
				tile.setType((TileType)container.tiles.Where(x => x.locX == i && x.locY == j).First().id);
				row.Add (tile);
			}
			map.Add(row);
		}
	}
	
	void generatePlayers() {
		UserTroop player;
		player = ((GameObject)Instantiate(UserTroopPrefab, new Vector3(3 - Mathf.Floor(mapSize/2),1.5f, -20 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserTroop>();
	//	public TroopScript (string CptName, string CptSurname, int Atk, int Def, int HP, int spd, int Soldiers, int Wounded, NumberOfHands hands, WeaponType weap, ArmorType armor){



		Chief leader = new Chief();
		AddStuffToChief(leader,"Barack","Obama", Trait.FromTraitList(ListOfTraits.Fearless),Abilities.fromList(ListOfAbilities.StrongLeadership),Abilities.fromList(ListOfAbilities.Popular),Abilities.fromList(ListOfAbilities.Phalanx),7,3,2,4);


        AddStuffToPlayer(player, 0,muhClasses.Animal, leader, 10,10,100,10,100, Weaponry.FromName(WeaponryName.TestCrossbow),Armory.FromName(ArmoryName.TestGambeson));

		player.gridPosition = new Vector2(3,20);

	//player.thisTroop = new TroopScript("Obama", "Barack", 10,4,100,10,100,0,NumberOfHands.TwoHanded,WeaponType.Axe,ArmorType.Heavy);
	    
//		player.SetName("nig");
//		player.SetSurname("nog");
//		player.SetAttack(10);
//		player.SetDefence(4);
//		player.SetHitpoints(100);
//		player.SetSpeed(10);
//		player.SetNumber(100);
//		player.SetWounded(0);
//		player.SetHands(NumberOfHands.TwoHanded);
//		player.SetWeapon(WeaponType.Axe);
//		player.SetArmor(ArmorType.Heavy);

			//("fag","nog", 10,10,100,10,100,0, hand,wpn,arm);

/*		player.playerName = "Obama";
		player.headArmor = Armor.FromKey(ArmorKey.LeatherCap);
		player.chestArmor = Armor.FromKey(ArmorKey.MagicianCloak);
		player.handWeapons.Add(Weapon.FromKey(WeaponKey.LongSword));
*/		
		players.Add(player);


		player = ((GameObject)Instantiate(UserTroopPrefab, new Vector3(5- Mathf.Floor(mapSize/2),1.5f, -20 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserTroop>();
		player.gridPosition = new Vector2(5,20);
		leader = new Chief();
		AddStuffToChief(leader,"nigga","this", Trait.FromTraitList(ListOfTraits.Fearless),Abilities.fromList(ListOfAbilities.StrongLeadership),Abilities.fromList(ListOfAbilities.Popular),Abilities.fromList(ListOfAbilities.Phalanx),5,4,2,5);


		AddStuffToPlayer(player,0,muhClasses.Animal,leader, 20,5,200,5,100,Weaponry.FromName(WeaponryName.TestAxe),Armory.FromName(ArmoryName.TestChainMail));
		players.Add(player);



		player = ((GameObject)Instantiate(UserTroopPrefab, new Vector3(4 - Mathf.Floor(mapSize/2),1.5f, -20 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserTroop>();
		player.gridPosition = new Vector2(4,20);
		leader = new Chief();
		AddStuffToChief(leader,"man","Obama", Trait.FromTraitList(ListOfTraits.Fearless),Abilities.fromList(ListOfAbilities.StrongLeadership),Abilities.fromList(ListOfAbilities.Popular),Abilities.fromList(ListOfAbilities.Phalanx),6,6,2,1);
		player.SetBaseTurnSpeed (2);
		AddStuffToPlayer(player,0,muhClasses.Warrior,leader, 14,7,70,12,100,Weaponry.FromName(WeaponryName.TestPike),Armory.FromName(ArmoryName.TestBrigandine));
		players.Add(player);

		player = ((GameObject)Instantiate(UserTroopPrefab, new Vector3(2 - Mathf.Floor(mapSize/2),1.5f, -20 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserTroop>();
		player.gridPosition = new Vector2(2,20);
		leader = new Chief();
		AddStuffToChief(leader,"asshole","Obama", Trait.FromTraitList(ListOfTraits.Fearless),Abilities.fromList(ListOfAbilities.StrongLeadership),Abilities.fromList(ListOfAbilities.Popular),Abilities.fromList(ListOfAbilities.Phalanx),7,0,2,1);

		AddStuffToPlayer(player,0,muhClasses.Animal, leader, 12,10,100,12,100,Weaponry.FromName(WeaponryName.TestBow),Armory.FromName(ArmoryName.TestGambeson));
		
		players.Add(player);
		
		AITroop aiplayer = ((GameObject)Instantiate(AITroopPrefab, new Vector3(6 - Mathf.Floor(mapSize/2),1.5f, -4 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<AITroop>();
		aiplayer.gridPosition = new Vector2(6,4);
		leader = new Chief();
		AddStuffToChief(leader,"another asshole","Obama", Trait.FromTraitList(ListOfTraits.Fearless),Abilities.fromList(ListOfAbilities.StrongLeadership),Abilities.fromList(ListOfAbilities.Popular),Abilities.fromList(ListOfAbilities.Phalanx),2,3,1,3);

		AddStuffToPlayer(aiplayer,1,muhClasses.Animal,leader, 12,2,100,12,100,Weaponry.FromName(WeaponryName.TestHammer),Armory.FromName(ArmoryName.TestConfortableClothes));
	
		players.Add(aiplayer);

		aiplayer = ((GameObject)Instantiate(AITroopPrefab, new Vector3(8 - Mathf.Floor(mapSize/2),1.5f, -4 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<AITroop>();
		aiplayer.gridPosition = new Vector2(8,4);
		leader = new Chief();
		AddStuffToChief(leader,"yet another nigga","Obama", Trait.FromTraitList(ListOfTraits.Fearless),Abilities.fromList(ListOfAbilities.StrongLeadership),Abilities.fromList(ListOfAbilities.Popular),Abilities.fromList(ListOfAbilities.Phalanx),8,8,8,8);

		AddStuffToPlayer(aiplayer,1,muhClasses.Animal,leader, 22,1,100,13,100,Weaponry.FromName(WeaponryName.TestCrossbow),Armory.FromName(ArmoryName.TestGambeson));

		
		players.Add(aiplayer);

		aiplayer = ((GameObject)Instantiate(AITroopPrefab, new Vector3(12 - Mathf.Floor(mapSize/2),1.5f, -1 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<AITroop>();
		aiplayer.gridPosition = new Vector2(12,1);
		leader = new Chief();
		AddStuffToChief(leader,"zzz","Obama", Trait.FromTraitList(ListOfTraits.Fearless),Abilities.fromList(ListOfAbilities.StrongLeadership),Abilities.fromList(ListOfAbilities.Popular),Abilities.fromList(ListOfAbilities.Phalanx),2,3,3,1);

		AddStuffToPlayer(aiplayer,1, muhClasses.Animal,leader, 22,3,100,12,100,Weaponry.FromName(WeaponryName.TestBow),Armory.FromName(ArmoryName.TestConfortableClothes));

		
		players.Add(aiplayer);

		aiplayer = ((GameObject)Instantiate(AITroopPrefab, new Vector3(18 - Mathf.Floor(mapSize/2),1.5f, -8 + Mathf.Floor(mapSize/2)), Quaternion.Euler(new Vector3()))).GetComponent<AITroop>();
		aiplayer.gridPosition = new Vector2(18,8);
		leader = new Chief();
		AddStuffToChief(leader,"glorious leader","Obama", Trait.FromTraitList(ListOfTraits.Fearless),Abilities.fromList(ListOfAbilities.StrongLeadership),Abilities.fromList(ListOfAbilities.Popular),Abilities.fromList(ListOfAbilities.Phalanx),5,2,3,1);

		AddStuffToPlayer(aiplayer,1,muhClasses.Animal, leader, 12,4,100,22,100,Weaponry.FromName(WeaponryName.TestSword),Armory.FromName(ArmoryName.TestPlateArmor));

		aiplayer.SetBaseTurnSpeed(3);
		players.Add(aiplayer);
	}

	void AdjustCamera(){
		GameObject muhCamera = GameObject.Find("Main Camera");
		muhCamera.transform.position = new Vector3(0,12	, 0.5f);
		int size = mapSize/2;
		GetComponentInChildren<Camera>().orthographicSize= size;
//		Debug.Log("The Screen Resolution is: "+Screen.currentResolution.width+ "x"+Screen.currentResolution.height+ " and refresh: "+Screen.currentResolution.refreshRate);

	}

	void GiveInformationOnPlayer(){
		if (TileUnderMouse)
		Debug.Log(TileUnderMouse.TileName);
		for (int i = 0; i<players.Count;i++)
		if (players[i].gridPosition == MousePosition){
			Debug.Log(players[i].GetName()+" has "+players[i].GetNumber()+" healthy soldiers. Those soldiers are using " + players[i].GetWeapon().NameOfTheEquip+"s as weapon and "+players[i].GetArmor().NameOfTheEquip+"s as armor.");
		}				
	}

	void DecideNextTurn(){
		CalculatedNextPlayerTurn = false;
		while (!CalculatedNextPlayerTurn)
			for (int i = 0; i<players.Count;i++)
				if (players[i].TurnRecoveryTime < 100)
					players[i].TurnRecoveryTime+=players[i].GetTurnSpeed();
		else if (players[i].TurnRecoveryTime>=100)
		{   players[i].TurnRecoveryTime= 0;
			playerTurns.Add(players[i]);
			playerTurnNamesForShow.Add(players[i].GetName());
			CalculatedNextPlayerTurn = true;
		}
		else if (players[i].TurnRecoveryTime ==0)
			playerTurns.Remove(players[i]);


	}



}
