
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Newtesttrashcan : MonoBehaviour
{   List<Individual> jews = new List<Individual>();
	List<Captain> captains = new List<Captain>();
	jews().Addpeopletomyunit(19);
	UnitClass muhTroop = new UnitClass(jews,captains);
	public bool benis = false;
	public bool walao = false;
	public bool returnWeapon = false;
	public int people = 5;
	public int lances = 3;
	int counter = 0;
	public WeaponTestData weapon1 ;
	public WeaponTestData weapon2 ;
	public WeaponTestData weapon3 ;
	void Start(){
		weapon1 = WeaponTestData.FromKey(WeaponKeyy.ActuallyNotAnHammer);
		weapon2 = WeaponTestData.FromKey(WeaponKeyy.HeavyHammer);
		weapon3 = WeaponTestData.FromKey(WeaponKeyy.ToyHammer);
	}


	void Update()
	{
		if(benis)
		{

			Debug.Log (NamingScript.GeneratePraenomina() + " " + NamingScript.GenerateNomina() + " " + NamingScript.GenerateCognomina());
			benis = false;
			jews.Addpeopletomyunit(people);
		}
		if(walao)
		{

			if (counter == 0){
				muhUnit.SetWeapon(counter,weapon1);
				counter++;
				walao = false;}
			else if (counter == 1){
				muhUnit.SetWeapon(counter,weapon2);
				counter++;
				walao = false;}
			else if (counter == 2){
				muhUnit.SetWeapon(counter,weapon3);
				counter = 0;
				walao = false;}

		}
		if (returnWeapon){
			returnWeapon = false;
			for (int i = 0;i<3;i++){
			Debug.Log ("Your soldier number " + i + " is using "+muhUnit.GetWeapon(i).EquipName);
			}}
	}
}