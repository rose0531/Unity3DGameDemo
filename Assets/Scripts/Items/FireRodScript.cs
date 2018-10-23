using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRodScript : MonoBehaviour {

	public Equipment fireRod;
	GameObject fireBall;
	float lifeTime = 0.5f;


	void Start(){
		fireBall = Resources.Load ("FireBall") as GameObject;
	}

	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Shoot ();
		}
	}

	void Shoot(){
		GameObject fireBallProjectile = Instantiate (fireBall) as GameObject;
		fireBallProjectile.transform.position = transform.position + Camera.main.transform.forward;
		Rigidbody fireBallRB = fireBallProjectile.GetComponent<Rigidbody> ();
		fireBallRB.velocity = Camera.main.transform.forward * 60;
		Destroy (fireBallProjectile, lifeTime);
	}
}
