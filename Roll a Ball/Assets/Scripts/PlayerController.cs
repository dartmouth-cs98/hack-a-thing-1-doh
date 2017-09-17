using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	/*
	 * What to do with script?
	 * We want to check every frame for player input
	 * Apply that input to the player game object every frame as movement
	 * 
	 * Use update and fixed update to apply that input
	 * 
	 */

	// Called before rendering a frame, where most of game code will go
//	void Update() {
//		
//	}

	private Rigidbody rb;
	public float speed;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	// Called just before any fixed calculations, physics code here
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
}
