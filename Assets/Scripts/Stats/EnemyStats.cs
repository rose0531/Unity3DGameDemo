using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats {

	public GameObject GFX;
	public float delay = 0.1f;
	float currentDelay = 0f;
	bool colorChanged = false;
	public GameObject explode;

	public override void Die(){
		base.Die ();
		explode.SetActive (true);
		Destroy(gameObject, 0.3f);
		EnemyManager.instance.EnemyDied ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Projectile") {
			int projectileDamage = other.GetComponent<Projectile> ().Damage ();
			TakeDamage (projectileDamage);
			currentDelay = Time.time + delay;
			Destroy (other.gameObject);
		}
	}

	public override void TakeDamage(int damage){
		base.TakeDamage (damage);
		colorChanged = true;
	}

	public void colorChange (){
		if (colorChanged) {
			GFX.GetComponent<Renderer> ().material.color = Color.red;
			if (Time.time > currentDelay) {
				GFX.GetComponent<Renderer> ().material.color = Color.magenta;
				colorChanged = false;
			}
		}
	}

	public override void Update(){
		base.Update ();
		colorChange ();
	}
}
