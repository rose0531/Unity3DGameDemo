using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	public float movementSpeed;
	public float rotationSpeed;
	public float mouseRotationX;
	public float mouseRotationY;
	public float mouseSensitivity;

	public GameObject playerHUD;


	void Start(){
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		movementSpeed = 0.2f;
        mouseSensitivity = 1.0f;
		playerHUD.SetActive (true);
	}

	
	// Update is called once per frame
	void Update () {
		/*First Person Camera*/
		UpdateCamera ();


		/*Movement*/
		if (Input.GetKey (KeyCode.W)) {
			transform.position += (movementSpeed * transform.forward);
			transform.position = new Vector3 (transform.position.x, 1, transform.position.z);
		}
		if (Input.GetKey (KeyCode.S)) {
			transform.position += (-movementSpeed * transform.forward);
			transform.position = new Vector3 (transform.position.x, 1, transform.position.z);
		}
		if (Input.GetKey (KeyCode.A)) {
			transform.position += (-movementSpeed * transform.right);
		}
		if (Input.GetKey (KeyCode.D)) {
			transform.position += (movementSpeed * transform.right);
		}

	}

	public void UpdateCamera(){
		mouseRotationX = transform.localEulerAngles.x - Input.GetAxis ("Mouse Y") * mouseSensitivity;
		mouseRotationY = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * mouseSensitivity;
		gameObject.transform.localEulerAngles = new Vector3 (mouseRotationX, mouseRotationY, 0);
	}
		
	public void ChangeMouseSensitivity(float newSensitivity){
		mouseSensitivity = newSensitivity;
	}
}
