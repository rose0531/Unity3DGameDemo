using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

	Item item;
	public Image icon;
	public Button removeButton;
	public GameObject itemCount;
	int numberOfItems;

	public void AddItem (Item newItem){
		item = newItem;
		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
		itemCount.SetActive(true);
		itemCount.GetComponentInChildren<Text> ().text = item.itemStack.ToString();
	}

	public void ClearSlot(){
		item = null;
		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
		itemCount.SetActive (false);
	}

	public void OnRemoveButtonClicked(){
		Inventory.instance.Remove (item);
	}

	public void UseItem(){
		if (item != null) {
			item.Use ();
		}
	}
}
