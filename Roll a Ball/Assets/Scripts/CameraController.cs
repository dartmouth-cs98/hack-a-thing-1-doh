using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private Vector3 offset; // offset is private because you can only set it in script

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame

	// LateUpdate runs every frame, but guaranteed to run after all items have been updated
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
