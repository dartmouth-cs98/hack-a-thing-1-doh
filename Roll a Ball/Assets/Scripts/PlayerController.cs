using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int score;
	private GameObject[] cubeArray;
	private int numCubes;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		SetCountText ();
		winText.text = "";
		cubeArray = GameObject.FindGameObjectsWithTag ("Pick Up");
		numCubes = cubeArray.Length;
	}

	// Called just before any fixed calculations, physics code here
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			score = score + 1;
			SetCountText ();
		}
	}

	void SetCountText() {
		countText.text = "Score: " + score.ToString ();
		if (score >= numCubes) {
			winText.text = "You Win!";
		}
			
	}
}
