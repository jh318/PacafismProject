using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierSpawner : MonoBehaviour {
	public static MultiplierSpawner instance;
	public MultiplierController multiplierPrefab;

	private List<MultiplierController> multiplierPool = new List<MultiplierController>();

	void Awake(){
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}

	public MultiplierController MultiplierPool (Vector3 pos){
		MultiplierController multiplier = null;
		for (int i = 0; i < multiplierPool.Count; i++) {
			MultiplierController m = multiplierPool [i];
			if (!m.gameObject.activeSelf) {
				multiplier = m;
				break;
			}
		}
		if (multiplier == null) {
			multiplierPool.Add (multiplier = Instantiate (multiplierPrefab) as MultiplierController); 
		}
		multiplier.transform.position = pos;
		multiplier.gameObject.SetActive (true);
		return multiplier;
	}
}
