using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : CharacterStats {

	public GameObject menuCanvas;
	public Text hpText;
	public Slider healthBar;

	void Start(){
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
		healthBar.maxValue = maxHealth;
		healthBar.value = currentHealth;
		healthBar.minValue = 0;
		hpText.text = "HP:  " + currentHealth;
	}

	void OnEquipmentChanged(Equipment newItem, Equipment oldItem){

		if (newItem != null) {
			damage.AddModifier (newItem.damageModifier);
			gameObject.GetComponent<PlayerScript> ().movementSpeed += newItem.movementSpeedModifier;
		}

		if (oldItem != null) {
			damage.RemoveModifier (oldItem.damageModifier);
			gameObject.GetComponent<PlayerScript> ().movementSpeed -= oldItem.movementSpeedModifier;
		}
	}

	public override void Die(){
		base.Die ();
		menuCanvas.GetComponent<MenuSystem> ().OpenDeathScreen ();
	}

	public override void TakeDamage (int damage)
	{
		base.TakeDamage (damage);
		UpdatePlayerHUD ();
	}

	public override void Heal(int restore){
		base.Heal (restore);
		UpdatePlayerHUD ();
	}

	public void UpdatePlayerHUD(){
		hpText.text = "HP:  " + currentHealth;
		healthBar.value = currentHealth;
	}


}
