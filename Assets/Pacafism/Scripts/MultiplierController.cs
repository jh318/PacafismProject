using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierController : MonoBehaviour {
	public float multiplier = 1.5f;

	void Start(){
		multiplier = Random.Range (0.1f, 3.0f);
	}

	public float getMultiplier(){
		return multiplier;
	}
}
