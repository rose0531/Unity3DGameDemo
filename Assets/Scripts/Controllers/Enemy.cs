using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interact {

	PlayerManager playerManager;
	CharacterStats myStats;
	CharacterCombat playerCombat;

	void Start(){
		playerManager = PlayerManager.instance;
		myStats = GetComponent<CharacterStats> ();
	}

	public override void Interactable(){
		base.Interactable ();
		//Attack enemy
		playerCombat = playerManager.player.GetComponent<CharacterCombat> ();
		if (Input.GetMouseButtonDown(0)) {
			if (playerCombat != null) {
				playerCombat.Attack (myStats);
			}
		}

	}
}
