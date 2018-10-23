using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	#region Singleton
	public static EnemyManager instance;

	void Awake(){
		instance = this;
	}
	#endregion

	public GameObject menuCanvas;
	int numberOfEnemies = 7;

	void Start () {
	}
	
	public void EnemyDied(){
		numberOfEnemies--;
		if (numberOfEnemies <= 0) {
			//asmenuCanvas.GetComponent<MenuSystem> ().OpenWinScreen ();
		}
		Debug.Log ("Enemy died");
	}
}
