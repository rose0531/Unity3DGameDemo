using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interact {

	public Item item;

	public override void Interactable(){
		base.Interactable ();
		if (Input.GetKeyDown (KeyCode.E)) {
			PickUp ();
		}
	}

	public void PickUp(){
		bool itemWasPickedUp = Inventory.instance.Add (item);
		if(itemWasPickedUp)
			Destroy (gameObject);
	}
}
