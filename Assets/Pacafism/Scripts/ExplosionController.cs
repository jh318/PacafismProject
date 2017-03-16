using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D c){
		if (c.gameObject.GetComponent<EnemyController>() == true) {
			c.gameObject.SetActive (false);
			GameManager.instance.SetScore (c.gameObject.GetComponent<EnemyController>().score);
			// spawn at c.gameObject.transform.position
			MultiplierSpawner.instance.MultiplierPool(c.transform.position);
		}
	}

	public void Explode () {
		StartCoroutine ("ExplodeCoroutine");
	}

	IEnumerator ExplodeCoroutine(){
		yield return new WaitForSeconds (3);
		gameObject.SetActive (false);
	}
}
