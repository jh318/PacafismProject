using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour {
	public static ExplosionSpawner instance;
	public ExplosionController explosion;

	void Awake(){
		if (instance == null) instance = this; 
		else Destroy (gameObject); 
	}

	void Start(){
		gameObject.SetActive (false);
	}

	//Disable by default and enable with player/gate collision
	void OnEnable(){
		Instantiate (explosion, PlayerController.player.transform.position, Quaternion.identity);
		gameObject.SetActive (false);
	}
}
