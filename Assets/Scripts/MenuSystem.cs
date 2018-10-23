using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour {
    public static bool InstructionIsOpen;
    public GameObject instructionMenuUI;

	public static bool EscapeIsOpen;
	public GameObject escapeMenuUI;

	public GameObject inventoryMenuUI;
	public static bool InventoryIsOpen;

	public GameObject deathScreenUI;
	public static bool deathScreenIsOpen;

	public GameObject winScreenUI;
	public static bool winScreenIsOpen;

	public GameObject statsMenuUI;
	public static bool statsMenuIsOpen;

	public GameObject optionsMenuUI;
	public static bool optionsMenuIsOpen;

	public GameObject crosshair;

    public GameObject playerHUD;

	public Transform playerTransform;

	public Transform itemsGrid;

	InventorySlot[] slots;

	Inventory inventory;

	public InputField mouseSensitivityInputField;
	public float mouseSensitivity;
	public Slider mouseSensitivitySlider;

	void Start(){
		CloseEscape ();
		CloseInventory ();
		CloseDeathScreen ();
		CloseStatsMenu ();
		CloseWinScreen ();
		CloseOptionsMenu ();
		EscapeIsOpen = false;
		InventoryIsOpen = false;
		deathScreenIsOpen = false;
		statsMenuIsOpen = false;
		winScreenIsOpen = false;
		optionsMenuIsOpen = false;
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateInventory;
		slots = itemsGrid.GetComponentsInChildren<InventorySlot> ();
        playerTransform.GetComponent<PlayerScript>().ChangeMouseSensitivity(1);
		mouseSensitivity = playerTransform.GetComponent<PlayerScript>().mouseSensitivity;
		UpdateMouseSensitivityInputField ();
		UpdateMouseSensitivitySlider ();
        OpenInstructionMenu();
    }


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
            if (EscapeIsOpen)
            {
                CloseEscape();
            }
            else if (InventoryIsOpen)
            {
                CloseInventory();
                OpenEscape();
            }
            else if (statsMenuIsOpen)
            {
                CloseStatsMenu();
                OpenEscape();
            }else if (InstructionIsOpen) {
                CloseInstructionMenu();
			} else {
				OpenEscape ();
			}
		}

		if (Input.GetKeyDown (KeyCode.I)) {
			if (InventoryIsOpen) {
				CloseInventory ();
			} else if (EscapeIsOpen) {
				CloseEscape ();
				OpenInventory ();
			}else if(statsMenuIsOpen){
				CloseStatsMenu ();
				OpenInventory ();
			} else {
				OpenInventory ();
			}
		}

		if (Input.GetKeyDown (KeyCode.Y)) {
			if (statsMenuIsOpen) {
				CloseStatsMenu ();
			} else if (EscapeIsOpen) {
				CloseEscape ();
				OpenStatsMenu ();
			} else if (InventoryIsOpen) {
				CloseInventory ();
				OpenStatsMenu ();
			} else {
				OpenStatsMenu ();
			}
		}
	}

    /************ Instruction Menu ***********/
    public void CloseInstructionMenu()
    {
        InstructionIsOpen = false;
        instructionMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        playerTransform.GetComponent<PlayerScript>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        playerHUD.SetActive(true);
    }

    public void OpenInstructionMenu()
    {
        InstructionIsOpen = true;
        instructionMenuUI.SetActive(true);
        Time.timeScale = 0f;
        playerTransform.GetComponent<PlayerScript>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerHUD.SetActive(false);
    }


    /*****************************************/


	/************ Pause Menu ************/
	public void CloseEscape(){ 
		escapeMenuUI.SetActive (false);
		Time.timeScale = 1f;
		EscapeIsOpen = false;
		Cursor.visible = false;
		playerTransform.GetComponent<PlayerScript> ().enabled = true;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void OpenEscape(){ 
		escapeMenuUI.SetActive (true);
		Time.timeScale = 0f;
		EscapeIsOpen = true;
		playerTransform.GetComponent<PlayerScript> ().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void LoadMenu(){
		Debug.Log ("Loading menu...");
	}

	public void QuitGame(){
		Debug.Log ("Quitting game...");
	}
	/**************************************/


	/*********** Inventory Menu ***********/
	public void CloseInventory(){ //resume game
		inventoryMenuUI.SetActive (false);
		Time.timeScale = 1f;
		InventoryIsOpen = false;
		playerTransform.GetComponent<PlayerScript> ().enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void OpenInventory(){ //open inventory
		inventoryMenuUI.SetActive (true);
		Time.timeScale = 0f;
		InventoryIsOpen = true;
		playerTransform.GetComponent<PlayerScript> ().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		UpdateInventory ();
	}

	public void UpdateInventory(){
		for (int i = 0; i < slots.Length; i++) {
			if (i < inventory.items.Count) {
				slots [i].AddItem (inventory.items [i]);
			} else {
				slots [i].ClearSlot ();
			}
		}
	}
	/**************************************/


	/************* Stats Menu ************/
	public void OpenStatsMenu(){
		statsMenuUI.SetActive (true);
		Time.timeScale = 0f;
		statsMenuIsOpen = true;
		playerTransform.GetComponent<PlayerScript> ().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void CloseStatsMenu(){
		statsMenuUI.SetActive (false);
		Time.timeScale = 1f;
		statsMenuIsOpen = false;
		playerTransform.GetComponent<PlayerScript> ().enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void OnStatsCloseButtonClicked(){
		CloseStatsMenu ();
	}
	/**************************************/



	/************* Options Menu *************/
	public void OpenOptionsMenu(){
		CloseEscape ();
		optionsMenuUI.SetActive (true);
		Time.timeScale = 0f;
		optionsMenuIsOpen = true;
		playerTransform.GetComponent<PlayerScript> ().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void CloseOptionsMenu(){
		optionsMenuUI.SetActive (false);
		Time.timeScale = 1f;
		optionsMenuIsOpen = false;
		playerTransform.GetComponent<PlayerScript> ().enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		/*Update any changed option settings*/
		playerTransform.GetComponent<PlayerScript> ().ChangeMouseSensitivity (mouseSensitivity);
	}

	public void OnOptionsBackButtonClicked(){
		CloseOptionsMenu ();
		OpenEscape ();
	}

	/*when the slider moves, adjust the input*/
	public void OnInputFieldMouseSensitivityChanged(){
		mouseSensitivity = float.Parse (mouseSensitivityInputField.text);
		UpdateMouseSensitivitySlider ();
	}

	public void UpdateMouseSensitivitySlider(){
		mouseSensitivitySlider.value = mouseSensitivity;
	}

	public void OnSliderMouseSensitivityChanged(){
		mouseSensitivity = mouseSensitivitySlider.value;
		UpdateMouseSensitivityInputField ();
	}

	public void UpdateMouseSensitivityInputField(){
		mouseSensitivityInputField.text = mouseSensitivity.ToString ();
	}

	/****************************************/



	/*********** Death Screen ***********/
	public void OpenDeathScreen(){
		deathScreenUI.SetActive (true);
		Time.timeScale = 0f;
		deathScreenIsOpen = true;
		playerTransform.GetComponent<PlayerScript> ().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void CloseDeathScreen(){
		deathScreenUI.SetActive (false);
		Time.timeScale = 1f;
		deathScreenIsOpen = false;
		playerTransform.GetComponent<PlayerScript> ().enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void RestartScene(){
		SceneManager.LoadScene ("map", LoadSceneMode.Single);
	}
	/**************************************/



	/*********** Win Screen ***********/
	public void OpenWinScreen(){
		winScreenUI.SetActive (true);
		Time.timeScale = 0f;
		winScreenIsOpen = true;
		playerTransform.GetComponent<PlayerScript> ().enabled = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void CloseWinScreen(){
		winScreenUI.SetActive (false);
		Time.timeScale = 1f;
		winScreenIsOpen = false;
		playerTransform.GetComponent<PlayerScript> ().enabled = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	/**************************************/




	/************** Crosshair *************/
	public void CrosshairOn(){
		crosshair.SetActive(true);
	}

	public void CrosshairOff(){
		crosshair.SetActive(false);
	}
	/**************************************/
}
