﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitScript : MonoBehaviour {
	
	public Vector2 gridPosition = Vector2.zero;
	
	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;
	
	public bool moving = false;
	public bool attacking = false;
	
	public string playerName = "Obama";
	public int HP = 25;
	public int actionPoints = 2; //last thing to fix
	
	public Armor headArmor;
	public Armor chestArmor;
	public Armor gauntletArmor;
	public Armor legArmor;
	public Armor shieldArmor;
	
	public List<Weapon> handWeapons = new List<Weapon>();

	//actual stuff
	public float AttackChancePerUnit = 0;
	public float EvadeChancePerUnit = 0;
	public float Movement = 5;
	public float AttackRange = 0;
	public float PiercingDefence = 0;
	public float BludgeningDefence = 0;
	public float SlashingDefence = 0;
	public float PiercingAttack = 0;
	public float BludgeningAttack = 0;
	public float SlashingAttack = 0;

		//heavy armor beats piercing, beats slashing, gets fucked by heavy piercing and bludgening
		//light armor beats bludgening and heavy pierce due to dodge, but gets fucked by slashing and piercing
		//no armor gets fucked by everything
        //maybe ill add more types of damage later on, like fire damage strong vs heavy armor




	//default values for testing garbage
	public float baseAttackChance = 0.75f;
	public float baseEvade = 0.15f;
	public int baseMovementPerActionPoint = 5;
	public int baseAttackRange = 0;
	public int baseDamageReduction = 0;
	public int baseDamageBase = 0;
	public int baseDamageRollSides = 1; 
	
	public int damageReduction {
		get {
			int ret = baseDamageReduction;
			
			if (headArmor != null) ret += headArmor.alterDamageReduction;
			if (chestArmor != null) ret += chestArmor.alterDamageReduction;
			if (gauntletArmor != null) ret += gauntletArmor.alterDamageReduction;
			if (legArmor != null) ret += legArmor.alterDamageReduction;
			
			foreach (Weapon w in handWeapons) {
				if (w != null) {
					ret += w.alterDamageReduction;
					if (w.type == WeaponSlotType.TwoHanded) break;  
				}
			}
			
			return ret;
		}
		set {}
	}
	public int damageBase {
		get {
			int ret = baseDamageBase;
			
			if (headArmor != null) ret += headArmor.alterDamageBase;
			if (chestArmor != null) ret += chestArmor.alterDamageBase;
			if (gauntletArmor != null) ret += gauntletArmor.alterDamageBase;
			if (legArmor != null) ret += legArmor.alterDamageBase;
			
			foreach (Weapon w in handWeapons) {
				if (w != null) {
					ret += w.alterDamageBase;
					if (w.type == WeaponSlotType.TwoHanded) break;  
				}
			}
			
			return ret;
		}
		set {}
	}
	public float damageRollSides {
		get {
			int ret = baseDamageRollSides;
			
			if (headArmor != null) ret += headArmor.alterDamageRollSides;
			if (chestArmor != null) ret += chestArmor.alterDamageRollSides;
			if (gauntletArmor != null) ret += gauntletArmor.alterDamageRollSides;
			if (legArmor != null) ret += legArmor.alterDamageRollSides;
			
			foreach (Weapon w in handWeapons) {
				if (w != null) {
					ret += w.alterDamageRollSides;
					if (w.type == WeaponSlotType.TwoHanded) break;  
				}
			}
			
			return ret;
		}
		set {}
	}
	public int movementPerActionPoint { 
		get {
			int ret = baseMovementPerActionPoint;
			
			if (headArmor != null) ret += headArmor.alterMovementPerActionPoint;
			if (chestArmor != null) ret += chestArmor.alterMovementPerActionPoint;
			if (gauntletArmor != null) ret += gauntletArmor.alterMovementPerActionPoint;
			if (legArmor != null) ret += legArmor.alterMovementPerActionPoint;
			
			foreach (Weapon w in handWeapons) {
				if (w != null) {
					ret += w.alterMovementPerActionPoint;
					if (w.type == WeaponSlotType.TwoHanded) break;  
				}
			}
			
			return ret;
		} 
		set {}
	}
	public int attackRange {
		get {
			int ret = baseAttackRange;
			
			if (headArmor != null) ret += headArmor.alterAttackRange;
			if (chestArmor != null) ret += chestArmor.alterAttackRange;
			if (gauntletArmor != null) ret += gauntletArmor.alterAttackRange;
			if (legArmor != null) ret += legArmor.alterAttackRange;
			
			foreach (Weapon w in handWeapons) {
				if (w != null) {
					ret += w.alterAttackRange;
					if (w.alterAttackRange > 0) break;  
				}
			}
			
			return ret;
		}
		set {}
	}
	public float attackChance { 
		get {
			float ret = baseAttackChance;
			
			if (headArmor != null) ret += headArmor.alterAttackChance;
			if (chestArmor != null) ret += chestArmor.alterAttackChance;
			if (gauntletArmor != null) ret += gauntletArmor.alterAttackChance;
			if (legArmor != null) ret += legArmor.alterAttackChance;
			
			foreach (Weapon w in handWeapons) {
				if (w != null) {
					ret += w.alterAttackChance; 
					if (w.type == WeaponSlotType.TwoHanded) break; 
				}
			}
			
			return ret;
		} 
		set {}
	}
	public float evade { 
		get {
			float ret = baseEvade;
			
			if (headArmor != null) ret += headArmor.alterEvade;
			if (chestArmor != null) ret += chestArmor.alterEvade;
			if (gauntletArmor != null) ret += gauntletArmor.alterEvade;
			if (legArmor != null) ret += legArmor.alterEvade;
			
			foreach (Weapon w in handWeapons) {
				if (w != null) {
					ret += w.alterEvade; 
					if (w.type == WeaponSlotType.TwoHanded) break; 
				}
			}
			
			return ret;
		} 
		set {}
	}
	
	//movement animation
	public List<Vector3> positionQueue = new List<Vector3>();	
	//
	
	void Awake () {
		moveDestination = transform.position;
	}
	
	
	// Update is called once per frame
	public virtual void Update () {		
		if (HP <= 0) {
			transform.rotation = Quaternion.Euler(new Vector3(90,0,0)); //yer ded nigga
			transform.GetComponent<Renderer>().material.color = Color.red; // and bleeding
		}
	}
	
	public virtual void TurnUpdate () {
		if (actionPoints <= 0) {
			actionPoints = 2; //cbf doing atk points, move point,etc.. will change l8r
			moving = false;
			attacking = false;			
			GameManager.instance.nextTurn();
		}
	}
	
	public virtual void TurnOnGUI () {
		
	}
	
	public void OnGUI() {
		//display HP just to check shit
		Vector3 location = Camera.main.WorldToScreenPoint(transform.position) + Vector3.up * 35;
		GUI.TextArea(new Rect(location.x, Screen.height - location.y, 30, 35), "hp:" + HP.ToString());
	}}