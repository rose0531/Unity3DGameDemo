using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	public float radius = 3f;
	public Transform player;
	public Transform itemTransform;

	public virtual void Interactable(){
		Debug.Log ("INTERACTABLE");
	}

	void Update(){
		float distance = Vector3.Distance (player.position, transform.position); /*Gets the distance between two points*/
		if (distance <= radius) {
			/*If the player is near the interactable object*/
			Interactable ();
		}
	}

	void OnDrawGizmosSelected(){
		if (itemTransform == null)
			itemTransform = transform;
		
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
