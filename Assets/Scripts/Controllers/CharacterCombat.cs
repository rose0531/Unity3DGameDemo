using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	public float attackSpeed = 1f;
	private float attackCooldown = 0f;

	public CharacterStats myStats;

	void Start(){
		myStats = GetComponent<CharacterStats> ();
	}

	void Update(){
		attackCooldown -= Time.deltaTime;
	}

	public void Attack(CharacterStats targetStats){

		targetStats.TakeDamage (myStats.damage.GetValue());

	}
}
