using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class UnitClass {
private	List<Individual> muhUnit = new List<Individual>();
	private List<Captain> muhCaptains = new List<Captain>();

//	public List<Individual> muhUnit(){}
//	public muhCaptains(){}

 public UnitClass(List <Individual> _unit, List <Captain> _captains){
		
	

		for(int i = 0; i < _unit.Count ; i++)
			{
				muhUnit.Add(_unit[i]);
			}
		for(int i = 0; i < _captains.Count ; i++)
			{
				muhCaptains.Add(_captains[i]);
			}

	}
	// Use this for initialization


	public void Addpeopletomyunit(int numberofNiggasinmyunit){
		for (int i = 0;i<numberofNiggasinmyunit;i++){
		muhUnit.Add(new Individual(NamingScript.GeneratePraenomina(),NamingScript.GenerateNomina(),NamingScript.GenerateCognomina(),0,"",0,0)); //create an empty person
			}
	}
	

		


	public void SortByAttack(List<Individual> original)
	{
		original.Sort((x,y) => x.GetWeapon().attack.CompareTo(y.GetWeapon().attack)); 
	}

	public WeaponTestData GetWeapon (int UnitNumberInTheList){
		return muhUnit[UnitNumberInTheList].GetWeapon();

	}

	public void SetWeapon ( int UnitNumberInTheList, WeaponTestData weaponAssinged){
		muhUnit[UnitNumberInTheList].SetWeapon(weaponAssinged);
	}
		

}

