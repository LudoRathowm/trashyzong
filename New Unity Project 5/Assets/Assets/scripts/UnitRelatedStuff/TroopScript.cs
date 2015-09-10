using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum NumberOfHands {
	OneHanded,
	TwoHanded,
	Bow, //means ranged not bow
	NotAWeapon
}

public enum WeaponType {
	Spear,
	Sword,
	Mace,
	Axe,
	Bow,
	Crossbow,
	NotAWeapon
}

public enum ArmorType {
	Light,
	Heavy,
	NoArmor,
	NotAnArmor
}



public class TroopScript : MonoBehaviour {

	Chief Leader;
	Buffs myBuffs;
	List<Skill> SkillsPossessed = new List<Skill>();
	int baseAttack;
	int baseDefence;
	int baseHitPoints;
	int baseSpeed;
	int People = 1;
	int maxPeople = 999;
	int baseMovement = 10;
	int baseCounterAttackRange = 0;
	int baseTurnSpeed = 1;
	int Energy;
	int MaxEnergy;

	Weaponry WeaponAdopted;
	Armory ArmorAdopted;
	Classes myClass;
	//just for the debug
	string WeaponName;
	string ArmorName;
	string LeaderName; 
	
	//stuff to make it work, not related to rpg parts
	public int TurnRecoveryTime = 0;
	bool isPreparating = false;
	bool chargedWeapon = false; //for crossbows
	bool isPhalanxing = false; //for AI and pathfinding
	public int actionPoints = 2;
	public bool boss = false;
	public Vector2 previousGridPosition = Vector2.zero;
	public Vector2 gridPosition = Vector2.zero;
	public Vector3 previousWorldPosition;
	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;
	public int Faction; //0 player 1 opponent 2 third faction
	public bool moving = false;
	public bool attacking = false;
	public bool Trapped = false; //ankle snare
	public TroopScript CarryingThisNigga = null;
	public int Poisoned = 0;
	public TroopScript GuardedBy = null;
	public int GuardedByPercent =0;
	public bool Frozen = false;
	public bool isMagicGuarded = false;




	//the constructor

/*	public TroopScript (string CptName, string CptSurname, int Atk, int Def, int HP, int spd, int Soldiers, int Wounded, NumberOfHands hands, WeaponType weap, ArmorType armor){
		CaptainName = CptName;
		CaptainSurname = CptSurname;
		Attack = Atk;
		Defence = Def;
		HitPoints = HP;
		Speed = spd;
		NumberOfSoldiers = Soldiers;
		NumberOfWounded = Wounded;
		HandsUsedByTheWeapon = hands;
		TypeOfWeapon = weap;
		TypeOfArmor = armor;
	}
*/







			//======================================
			//              GETTERS
			//======================================



	public NumberOfHands GetHands (){

				return WeaponAdopted.handsUsed;
			}

	public Weaponry GetWeapon (){
				return WeaponAdopted;
			}

	public Armory GetArmor(){
				return ArmorAdopted;
			}

	public int GetSpeed(){
				return Mathf.RoundToInt(baseSpeed*WeaponAdopted.speedModifier*ArmorAdopted.speedModifier);
			}

	public int GetAttack(){
		int attack = 0;
		if (WeaponAdopted.weapType != WeaponType.Crossbow)
		attack = baseAttack+WeaponAdopted.Attack+ArmorAdopted.Attack;
		else if (WeaponAdopted.weapType == WeaponType.Crossbow)
		attack = WeaponAdopted.Attack+ArmorAdopted.Attack;
		return attack;
	}

	public int GetDefence(){
		return baseDefence+WeaponAdopted.Defence+ArmorAdopted.Defence;
	}

	public int GetHitpoints(){
		return baseHitPoints+ArmorAdopted.HPModifier;
	}

	public int GetNumber(){
		return People;
	}

	public int GetmaxNumber(){
		return maxPeople;
	}

	public Chief GetChief(){
		return Leader;
	}

	public string GetName(){
		return Leader.GetName();
	}

	public string GetSurname(){
		return Leader.GetSurname();
	}
	public int GetBaseMovement (){
		bool phalanx = isPhalanxing;
		int value = 0;
		if (phalanx) value = -1;
		return baseMovement + value;
	}
	public int GetMovement(){
		return Mathf.RoundToInt(baseMovement*WeaponAdopted.movModifier*ArmorAdopted.movModifier);
	}
	public int GetCounterMaxRange(){
		return baseCounterAttackRange+WeaponAdopted.maxRange;
	}
	public int GetCounterMinRange(){
		return baseCounterAttackRange+WeaponAdopted.minRange;
	}

	public bool GetCharge(){
		return chargedWeapon;
	}
	public bool GetPreparation(){
		return isPreparating;
	}

	public bool GetPhalanx(){
		return isPhalanxing;
	}

	public int GetTurnSpeed(){
		return baseTurnSpeed;
	}

	public Classes GetClass(){
		return myClass;
	}

	public int GetEnergy(){
		return Energy;
	}

	public int GetMaxEnergy(){
		return MaxEnergy;
	}

	public float GetDirectAttackBuff (){
		if (myBuffs != null)
			return myBuffs.AttackDirect+myBuffs.AttackTotal;
		else return 0;
	}

	public float GetCounterAttackBuff (){
		if (myBuffs != null)
		return myBuffs.AttackCounter + myBuffs.AttackTotal;
		else return 0;

	}

	public float GetDirectMatkBuff(){
		if (myBuffs != null)
		return myBuffs.MatkTotal + myBuffs.MatkDirect;
		else return 0;

	}

	public float GetCounterMatkBuff(){
		if (myBuffs != null)
		return myBuffs.MatkTotal + myBuffs.MatkCounter;
		else return 0;

	}

	public float GetDefenseBuff (){
		if (myBuffs != null)
		return myBuffs.Defense;
		else return 0;

	}

	public float GetMdefBuff (){
		if (myBuffs != null)
		return myBuffs.Mdef;
		else return 0;

	}

	public float GetSpeedBuff(){
		if (myBuffs != null)
		return myBuffs.Speed;
		else return 0;

	}



		    //======================================
		    //             SETTERS
		    //======================================

	public void SetWeapon (Weaponry weapon){
		WeaponAdopted = weapon;
		}

	public void SetArmor (Armory armor){
			ArmorAdopted = armor;
		}

	public void SetBaseSpeed(int spd){
			baseSpeed = spd;
		}

	public void SetBaseAttack (int atk)	{
		baseAttack = atk;
	}

	public void SetBaseDefence (int def){
		baseDefence = def;
	}

	public void SetBaseHitpoints (int hp){
		baseHitPoints = hp;
	}

	public void SetNumber (int people){
		if (people<People)
			if (!isMagicGuarded)
		People = people;
		else isMagicGuarded = false;
	}

	public void SetmaxNumber (int wounded){
		maxPeople = wounded;
	}

	public void SetChief (Chief leader){
		Leader = leader;
	}

	public void SetName (string name){
		Leader.SetName(name);
	}

	public void SetSurname(string srname){
		Leader.SetSurname(srname);
	}

	public void SetBaseMovement(int Mov){
		baseMovement = Mov;
	}

	public void SetBaseRange (int range){
		baseCounterAttackRange = range;
	}

	public void SetCharge (bool charge){
		chargedWeapon = charge;
	}

	public void SetPreparation (bool prep){
		isPreparating = prep;
	}


	public void SetPhalanx (bool phalanx){
		isPhalanxing = phalanx;
	}

	public void SetBaseTurnSpeed (int turnspeed){
		baseTurnSpeed = turnspeed;
	}

	public void SetClassDONTUSETHISAREYOUSUREYOUWANTTOUSETHISYOUREALLYSHOULDNT (Classes classy){
		myClass = classy;
	}

	public void SetEnergy(int energy){
		Energy = energy;
	}

	public void SetMaxEnergy(int menergy){
		MaxEnergy = menergy;
	}

	public void SetDirectAttackBuff (float value){
		myBuffs.AttackDirect = value;
	}
	public void SetTotalAttackBuff (float value){
		myBuffs.AttackTotal = value;
	}
	public void SetCounterAttackBuff (float value){
		myBuffs.AttackCounter = value;
	}

	public void SetDirectMatkBuff (float value){
		myBuffs.MatkDirect = value;
	}
	public void SetTotalMatkBuff (float value){
		myBuffs.MatkTotal = value;
	}
	public void SetCounterMatkBuff (float value){
		myBuffs.MatkCounter = value;
	}
	public void SetDefenseBuff (float value){
		myBuffs.Defense = value;
	}

	public void SetMdefBuff ( float value){
		myBuffs.Mdef = value;
	}

	public void SetSpeedBuff (float value){
		myBuffs.Speed = value;
	}
	public void RemoveAllbuffs (){
		myBuffs.AttackCounter =0;
		myBuffs.AttackDirect =0;
		myBuffs.AttackTotal = 0;
		myBuffs.Defense=0;
		myBuffs.Mdef =0;
		myBuffs.MatkCounter=0;
		myBuffs.MatkDirect = 0;
		myBuffs.MatkTotal = 0;
		myBuffs.Speed = 0;
	}


	public void AddSkillToList (Skill _skill){
		SkillsPossessed.Add(_skill);
	}


	//movement animation
	public List<Vector3> positionQueue = new List<Vector3>();	
	//
	
	void Awake () {
		moveDestination = transform.position;
		previousWorldPosition = transform.position;

	}

	void Start (){
		Debug.Log(myClass);
		for (int i=0;i<myClass.GetCountBaseClassSkills();i++)
			SkillsPossessed.Add(myClass.GetBaseClassSkills(i));
	}
	
	
	// Update is called once per frame
	public virtual void Update () {		
		WeaponName = WeaponAdopted.NameOfTheEquip;
		ArmorName = ArmorAdopted.NameOfTheEquip;
		LeaderName = Leader.GetName();
		if (GetNumber() <= 0) {
			transform.rotation = Quaternion.Euler(new Vector3(90,0,0)); //yer ded nigga
			transform.GetComponent<Renderer>().material.color = Color.red; // and bleeding
		}
	}
	
	public virtual void TurnUpdate () {
		if (Poisoned>0)
			Poisoned++;
		if (Poisoned >9) //10 ticks to kill? maybe gonna drop to like 5
			People = 0;
		if (actionPoints <= 0) {
			actionPoints = 2; //cbf doing atk points, move point,etc.. will change l8r
			moving = false;
			attacking = false;			
			GameManager.instance.nextTurn();
		}
	}

	void UpgradeSkill (Skill SkillYouWant){
		bool FoundIt = false;
		if (SkillYouWant.PrerequisiteSkill != muhSkills.NoSkill){
		Skill Prerequisite = Skill.FromListOfSkills(SkillYouWant.PrerequisiteSkill);

		for (int i = 0;i<SkillsPossessed.Count;i++){
			if (SkillsPossessed[i]==Prerequisite){
				SkillsPossessed.Remove(SkillsPossessed[i]);
				SkillsPossessed.Add(SkillYouWant);
				FoundIt = true;
				break;
			}
		}
		 if (!FoundIt)
		Debug.Log("YOU ARE MISSING THE PRE-REQUISITE SKILL: "+Prerequisite);
			
		}
	else if (SkillYouWant.PrerequisiteSkill == muhSkills.NoSkill)
			SkillsPossessed.Add(SkillYouWant);
	}

//	public virtual void TurnOnGUI () {
//	}
//
//
//	public void OnGUI() {
//		if (TurnOnGUI)
//		//display HP just to check shit
//		Vector3 location = Camera.main.WorldToScreenPoint(transform.position) + Vector3.up * 35;
//		GUI.TextArea(new Rect(location.x, Screen.height - location.y, 100, 40), "hp:" + People.ToString());
//	}


}