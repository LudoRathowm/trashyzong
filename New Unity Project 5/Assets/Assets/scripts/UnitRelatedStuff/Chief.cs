using UnityEngine;
using System.Collections;

public class Chief : MonoBehaviour {

	 string Name;
	 string Surname;
	 Trait muhTrait;
	 Abilities AbilityOne;
	 Abilities AbilityTwo;
	 Abilities AbilityThree;







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





}
