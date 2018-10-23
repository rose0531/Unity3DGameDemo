using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public int maxHealth;
	public int currentHealth { get; private set;}

	public Stats damage;
	public Stats armor;

	void Awake(){
		maxHealth = 100;
		currentHealth = maxHealth;
	}

	public virtual void Update(){
		if (Input.GetKeyDown (KeyCode.X)) {
			TakeDamage (10);
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			Heal (10);
		}
	}

	public virtual void Heal(int restore){
		currentHealth += restore;
		Debug.Log ("Healed for " + restore);
		if (currentHealth > maxHealth) {
			maxHealth = currentHealth;
		}
	}

	public virtual void TakeDamage (int damage){

		currentHealth -= damage;
		Debug.Log (transform.name + " takes " + damage + " damage");
		if (currentHealth <= 0) {
			Die ();
		}
	}
		

	public virtual void Die(){
		Debug.Log ("You Died");
	}

}
