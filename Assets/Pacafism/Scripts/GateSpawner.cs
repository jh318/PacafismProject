using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawner : MonoBehaviour {
	public GateController gatePrefab;
	public float spawnRadius;
	public float spawnTime;

	private List<GateController> gatePool = new List<GateController>();

	void Start () {
		StartCoroutine ("SpawnGateCoroutine");
	}

	void OnDrawGizmos(){
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere (transform.position, spawnRadius);
	}

	IEnumerator SpawnGateCoroutine(){
		while (enabled) {
			Instantiate (gatePrefab, new Vector3 (0, 0, 0), Quaternion.identity);
			GateController g = SpawnGate ();
			g.transform.position = transform.position + (Vector3)Random.insideUnitCircle * spawnRadius;
			yield return new WaitForSeconds (spawnTime);
		}
	}

	GateController SpawnGate(){
		GateController gate = null;
		for (int i = 0; i < gatePool.Count; i++){
			GateController g = gatePool[i];
			if (!g.gameObject.activeSelf) {
				gate = g;
				break;
			}
		}
		if (gate == null) {
			gate = Instantiate (gatePrefab) as GateController;
			gatePool.Add (gate);
		}
		return gate;
	}
}
