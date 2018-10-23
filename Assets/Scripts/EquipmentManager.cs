using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	#region Singleton
	public static EquipmentManager instance;

	void Awake(){
		instance = this;
	}
	#endregion

	Equipment[] currentEquipment;

	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChanged;

	Inventory inventory;
	public GameObject menuCanvas;
	public GameObject rodOfFire;
	public GameObject swordOfPower;
	public GameObject orbOfHaste;

	void Start(){
		inventory = Inventory.instance;
		int numberOfSlots = System.Enum.GetNames (typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numberOfSlots];
	}

	public void Equip (Equipment newItem){
		int slotIndex = (int)newItem.equipmentSlot;
		menuCanvas.GetComponent<MenuSystem> ().CrosshairOn ();

		Equipment swappedEquipment = null;

		if (currentEquipment [slotIndex] != null) {
			swappedEquipment = currentEquipment [slotIndex];
			inventory.Add (swappedEquipment);
		}

		if (onEquipmentChanged != null) {
			onEquipmentChanged.Invoke (newItem, swappedEquipment);
		}

		currentEquipment [slotIndex] = newItem;
		DespawnItem (swappedEquipment); /*BAD GAME DESIGN - NEED TO FIX*/
		SpawnItem (newItem); /*BAD GAME DESIGN - NEED TO FIX*/
	}

	public void Unequip(int slotIndex){
		Equipment removedEquipment;

		if (currentEquipment [slotIndex] != null) {
			removedEquipment = currentEquipment [slotIndex];
			inventory.Add (removedEquipment);
			currentEquipment [slotIndex] = null;
			DespawnItem (removedEquipment); /*BAD GAME DESIGN - NEED TO FIX*/

			if (onEquipmentChanged != null) {
				onEquipmentChanged.Invoke (null, removedEquipment);
			}
		}

		if (currentEquipment [0] == null && currentEquipment [1] == null) {
			menuCanvas.GetComponent<MenuSystem> ().CrosshairOff ();
		}
	}

	public void UnequipAll(){
		for (int i = 0; i < currentEquipment.Length; i++) {
			Unequip (i);
		}
	}

	/*BAD GAME DESIGN - NEED TO FIX*/
	public void SpawnItem(Equipment newItem){
		
		if (newItem.itemName == "Rod of Fire") {
			rodOfFire.SetActive (true);
		} else if (newItem.itemName == "Sword of Power") {
			swordOfPower.SetActive (true);
		} else if (newItem.itemName == "Orb of Haste") {
			orbOfHaste.SetActive (true);
		}

	}

	/*BAD GAME DESIGN - NEED TO FIX*/
	public void DespawnItem(Equipment oldItem){

		if (oldItem != null) {
			if (oldItem.itemName == "Rod of Fire") {
				rodOfFire.SetActive (false);
			} else if (oldItem.itemName == "Sword of Power") {
				swordOfPower.SetActive (false);
			} else if (oldItem.itemName == "Orb of Haste") {
				orbOfHaste.SetActive (false);
			}
		}
	}


	void Update(){
		if (Input.GetKeyDown (KeyCode.U)) {
			UnequipAll ();
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Unequip (0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Unequip (1);
		}
	}
}
