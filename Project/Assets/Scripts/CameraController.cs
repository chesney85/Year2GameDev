using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private float cameraZ = -10f;
	//declare a target for camera to look at
	public GameObject target;
	//declare variable for amount the camera follows ahead of character
	public float followAhead;
	//declare variable to be used as a camera position ahead of player
	private Vector3 targetPosition;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//make the camera follow the player
		transform.position = new Vector3(target.transform.position.x, target.transform.position.y, cameraZ);

		if (target.transform.position.y < 11.7f) {
			transform.position = new Vector3 (target.transform.position.x, target.transform.position.y + 30f, cameraZ);
		}

		if (target.transform.position.x < 35f) {
			transform.position = new Vector3 (target.transform.position.x + 38f, target.transform.position.y, cameraZ);
		}

		/*
		 * this is used if you want the camera to follow but not go up and down
		 * 
		 transform.position = new Vector3(target.transform.position.x, transform.position.y, cameraZ);
		//this if is used to set the targetPosition relative to what direction the player is facing
		if (target.transform.localScale.x > 0f) {
			targetPosition = new Vector3 (targetPosition.x + followAhead, targetPosition.y, cameraZ);
		} else {
			targetPosition = new Vector3 (targetPosition.x - followAhead, targetPosition.y, cameraZ);
		}
		//once found the camera will be set relative to followAhead amount of player position
		transform.position = targetPosition;
		*/
	}
}
