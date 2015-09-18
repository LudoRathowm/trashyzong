using UnityEngine;
using System.Collections;

public class Chief {
	public Sprite mySprite;
	 string Name;
	 string Surname;
	 Trait muhTrait;
	 Abilities AbilityOne;
	 Abilities AbilityTwo;
	 Abilities AbilityThree;
	int Attack;
	int Defense;
	int Intelligence;
	int Speed;
	int CounterAttackValue;







	// ########GETTERS##########

	public string GetName (){
		return Name;
	}

	public string GetSurname(){
		return Surname;
	}

	public Trait GetTrait (){
		return muhTrait;
	}

    public Abilities GetAbilityOne (){
		return AbilityOne;
	}

	public Abilities GetAbilityTwo (){
		return AbilityTwo;
	}

	public Abilities GetAbilityThree (){
		return AbilityThree;
	}

	public float GetMuhReturns (){

		float extraReturns = AbilityOne.muhReturns+AbilityTwo.muhReturns+AbilityThree.muhReturns;

		return extraReturns;
	}
	public int GetAttack (){
		return Attack;
	}
	public int GetDefense(){
		return Defense;
	}
	public int GetIntelligence(){
		return Intelligence;
	}
	public int GetSpeed(){
		return Speed;
	} 
	public int GetCounterAttack(){
		return CounterAttackValue;
	}





	// ########SETTERS###########
	public void SetName (string _name){
		Name = _name;
	}

	public void SetSurname (string _surname){
		Surname = _surname;
	}

	public void SetTrait (Trait _trait){
		muhTrait = _trait;
	}

	public void SetAbilityOne(Abilities _ability){
		AbilityOne = _ability;
	}        

	public void SetAbilityTwo(Abilities _ability){
		AbilityTwo = _ability;
	}        

	public void SetAbilityThree(Abilities _ability){
		AbilityThree = _ability;
	}        

	public void SetAttack(int atk){
		Attack = atk;
	}

	public void SetDefense(int def){
		Defense = def;
	}

	public void SetIntelligence(int inte){
		Intelligence = inte;
	}

	public void SetSpeed (int spd){
		Speed = spd;
	}

	public void SetCounterAttack(int cntr){
		CounterAttackValue = cntr;
	}


}
