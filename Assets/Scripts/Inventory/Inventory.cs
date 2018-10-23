using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
	#region Singleton
	public static Inventory instance;

	void Awake(){
		if (instance != null) {
			Debug.LogWarning ("More than one instance of Inventory found");
			return;
		}
		instance = this;
	}
	#endregion

	public delegate void OnItemChanged ();
	public OnItemChanged onItemChangedCallback;

	public List<Item> items = new List<Item>();

	public int space = 9;

	public bool Add(Item item){
		if (items.Count >= space) {
			Debug.Log ("Inventory is full");
			return false;
		}

		bool itemWasInInventory = items.Contains (item);
		if (itemWasInInventory) {
			item.itemStack++;
		} else {
			items.Add (item);
			item.itemStack = 1;
		}

		if(onItemChangedCallback != null)
			onItemChangedCallback.Invoke ();
		return true;
	}

	public void Remove(Item item){
		if (item.itemStack > 1) {
			item.itemStack--;
		} else {
			items.Remove (item);
		}

		if(onItemChangedCallback != null)
			onItemChangedCallback.Invoke ();
	}

}
