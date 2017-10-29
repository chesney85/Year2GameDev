using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;  //a list of all the back and foregrounds to be parallaxed
	private float[] parallaxScales;	//proportion of the cameras movement to move backgrounds by
	public float smoothing = 1;	//how smooth the parallax is going to be. make sure to set this above zero.

	private Transform cam;	//ref to main cameras transform.
	private Vector3 previousCamPosition;	//store position of cam in previous frame.

	//Awak is called before start(). great for references
	void Awake()
	{
		//set up the camera reference
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		//the previous frame had the current frames camera position
		previousCamPosition = cam.position;

		//parallax scale list is same as bnackgrounds
		parallaxScales = new float[backgrounds.Length];

		//assigning corresponding parallaxScales
		for (int i = 0; i < backgrounds.Length; i++) {
			parallaxScales [i] = backgrounds [i].position.z * -1;
		}
	}
	
	// Update is called once per frame
	void Update () {

		//for each background
		for (int i = 0; i < backgrounds.Length; i++) {
			//the parallax is the opposite of the camera movement because previous frame multiplied by the scale
			float parallax = (previousCamPosition.x - cam.position.x) * parallaxScales[i];

			//set a target x position which is current position plus the parallax
			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			//create a target position which is the backgrounds current position with its target x position
			Vector3 backgroundTargetPosition = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			//fade between current position and target position using lerp
			backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPosition, smoothing * Time.deltaTime);
		}

		//set the previous cam pos to the cameras position at the end of the frame
		previousCamPosition = cam.position;
	}
}
