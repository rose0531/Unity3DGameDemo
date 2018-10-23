using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {

	public string itemName = "New Item";
	public string resourceItemName = "NewItem";
	public Sprite icon = null;
	public int itemStack = 0;

	public virtual void Use(){
		Debug.Log ("using " + itemName);
	}

	public void RemoveFromInventory(){
		Inventory.instance.Remove (this);
	}
}
