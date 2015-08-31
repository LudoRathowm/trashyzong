using UnityEngine;
using System.Collections;

public enum TypeOfBuff {
	AttackTotal,
	AttackDirect,
	AttackCounter,
	MatkTotal,
	MatkDirect,
	MatkCounter,
	Defense,
	Mdef,
	Speed
}


public class Buffs  {

	public float AttackTotal;
	public float AttackDirect;
	public float AttackCounter;
	public float MatkTotal;
	public float MatkDirect;
	public float MatkCounter;
	public float Defense;
	public float Mdef;
	public float Speed;

	
//	public static Buffs FromTypesOfBuffs (TypeOfBuff buffeados) {
//		Buffs _buff = new Buffs();
//		switch (buffeados)
//		{
//		case TypeOfBuff.AttackCounter:
//			_buff = new Buffs() {
//				AttackCounter = 1
//				
//			};
//			break;
//		case TypeOfBuff.AttackDirect:
//			_buff = new Buffs() {
//				AttackDirect = 1
//				
//			};
//			break;
//		case TypeOfBuff.AttackTotal:
//			_buff = new Buffs() {
//				AttackTotal = 1
//				
//			};
//			break;
//		return _buff;
//	}




}
