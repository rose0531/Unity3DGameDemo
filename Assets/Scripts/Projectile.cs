using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int damage;

	void Start(){
		damage = 10;
	}

	public int Damage(){
		Debug.Log (damage);
		return damage;
	}
}
