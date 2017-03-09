using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static PlayerController player;
	public float speed = 3;

	Rigidbody2D _body;
	public Rigidbody2D body{
		get{
			if (_body == null) {
				_body = GetComponent<Rigidbody2D> ();
			}
			return _body; 
		}
	}
	void Awake(){
		if (player == null) {
			player = this;
		}
	}


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal");
		float y = Input.GetAxis ("Vertical");
		body.velocity = new Vector2 (x, y) * speed;

		if (body.velocity.sqrMagnitude > 0.1f) {
			transform.right = body.velocity;
		}

	}
}
