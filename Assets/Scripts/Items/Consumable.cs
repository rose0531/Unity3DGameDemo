using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumable")]
public class Consumable : Item {

	public int healAmount;		//health potions, food
	public int damageAmount;	//poison potions

	public override void Use(){
		base.Use ();
		PlayerManager.instance.player.GetComponent<PlayerStats> ().Heal (healAmount);
		RemoveFromInventory ();
	}
}
