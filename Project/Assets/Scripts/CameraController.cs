using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//set so camera wont move on the z axis
	private float cameraZ = -10f;

	//declare a target for camera to look at
	public GameObject target;

	//declare variable for amount the camera follows ahead of character
	public float followAhead;

	//declare variable to be used as a camera position ahead of player
	private Vector3 targetPosition;

	//this is if you need camera bounds
	public bool bounds;

	//this is min camera bounds
	public Vector3 minCamPos;

	//this is for max camera bounds
	public Vector3 maxCamPos;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
		//make the camera follow the player
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, cameraZ);

		if (bounds) {
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minCamPos.x, maxCamPos.x),
				Mathf.Clamp (transform.position.y, minCamPos.y, maxCamPos.y),
				Mathf.Clamp (transform.position.z, minCamPos.z, maxCamPos.z));
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
