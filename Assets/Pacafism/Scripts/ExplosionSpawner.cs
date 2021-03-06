﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour {
	public static ExplosionSpawner instance;
	public ExplosionController explosionPrefab;

	private List<ExplosionController> explosionPool = new List<ExplosionController> ();

	void Awake(){
		if (instance == null) instance = this; 
		else Destroy (gameObject); 
	}

	public void SpawnExplosion(Vector3 pos){
		ExplosionController explosion = null;
		for (int i = 0; i < explosionPool.Count; i++) {
			ExplosionController e = explosionPool [i];
			if (!e.gameObject.activeSelf) {
				explosion = e;
				break;
			}
		}
		if (explosion == null) {
			explosionPool.Add ( explosion = Instantiate (explosionPrefab) as ExplosionController);
		}
		explosion.transform.position = pos;
		explosion.gameObject.SetActive (true);
		explosion.Explode ();
	}
}
