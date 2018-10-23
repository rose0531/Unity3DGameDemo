using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	public float lookRadius;

	Transform target;
	NavMeshAgent agent;
	CharacterCombat combat;

	// Use this for initialization
	void Start () {
		lookRadius = 100f;
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent> ();
		combat = GetComponent<CharacterCombat> ();
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (target.position, transform.position);

		if (distance <= lookRadius) {
			//Chase player
			agent.SetDestination(target.position);

			if (distance <= agent.stoppingDistance) {
				CharacterStats targetStats = target.GetComponent<CharacterStats> ();
				if (targetStats != null) {
					combat.Attack (targetStats);
				}
			
				FaceTarget();
			}
		}
	}

	void FaceTarget(){
		Vector3 direction = (target.position - transform.position).normalized; //get direction to target
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); //smooths the rotation
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, lookRadius);
	}

}
