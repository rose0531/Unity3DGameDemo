using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

	public EquipmentSlot equipmentSlot;

	public int damageModifier;
	public float movementSpeedModifier;

	public override void Use(){
		base.Use ();
		EquipmentManager.instance.Equip (this);
		RemoveFromInventory ();
	}
}

public enum EquipmentSlot{LeftHand, RightHand}