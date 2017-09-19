using System;
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
	public float jump;
	public Text countText;
	public Text winText;
	public Text timeText;
	private float timeLeft;

	private Rigidbody rb;
	private int score;
	private GameObject[] cubeArray;
	private int numCubes;
	private bool lost;
	private bool gameDone;
	private float moveHorizontal = 0.0f;
	private float moveVertical = 0.0f;

	void Start() {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		timeLeft = 90.0f;
		SetCountText ();
		SetTimeText ();
		lost = false;
		gameDone = false;
		winText.text = "";
		cubeArray = GameObject.FindGameObjectsWithTag ("Pick Up");
		numCubes = cubeArray.Length;
	}

	void Update() {
		if (!lost && !gameDone) {
			timeLeft -= Time.deltaTime;
		}
		SetTimeText ();
	}

	// Called just before any fixed calculations, physics code here
	void FixedUpdate() {
		if (!lost) {
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		}

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		if (Input.GetKeyDown ("space") & rb.velocity.y == 0.0f) {
			Vector3 jump_force = new Vector3 (0.0f, jump, 0.0f);

			rb.AddForce (jump_force);
		}
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
			gameDone = true;
		}
			
	}

	void SetTimeText() {
		int secondsLeft = (int)timeLeft;
		timeText.text = "Time: " + secondsLeft.ToString ();
		if (timeLeft <= 0) {
			winText.text = "Sorry, you lose!";
			lost = true;
			gameDone = true;
		}
	}
}
