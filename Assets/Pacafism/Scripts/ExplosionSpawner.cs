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

	public void SpawnExplosion(){
		Instantiate(explosion, PlayerController.player.transform.position, Quaternion.identity);
	}

}
