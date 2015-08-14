using UnityEngine;
using System.Collections;

public class Captain : MonoBehaviour {
	private Abilities[] muhAbilities = new Abilities[7];
	private string Praenomina;
	private string Nomina;
	private string Cognomina;
	private int Age;
	private string Profession;
	public Captain (string prae, string nomina, string cogno, int age,  string _profession, Abilities[] _abilities){
		Praenomina = prae;
		Nomina = nomina;
		Cognomina = cogno;
		Age = age;
		Profession = _profession;
		muhAbilities = _abilities;
	}


	public void SetAbility (int Slot, Abilities Ability){
		muhAbilities[Slot] = Ability;
	}
	public Abilities GetAbility (int Slot){
		Abilities _ability;
		_ability = muhAbilities[Slot];
		return _ability;
	}
	public void SetPraenomina(string prae){
		Praenomina = prae;
	}
	public void SetNomina(string nomina){
		Nomina = nomina;
	}
	public void SetCognomina(string cogno){
		Cognomina = cogno;
	}
	public string GetPraenomina(){
		return Praenomina;
	}
	public string GetNomina(){
		return Nomina;
	}
	public string GetCognomina(){
		return Cognomina;
	}
	public void SetAge(int age){
		Age =age;
	}
	public int GetAge(){
		return Age;
	}
	public void SetProfession (string profession){
		Profession = profession;
	}
	public string GetProfession (){
		return Profession;
	}
}
