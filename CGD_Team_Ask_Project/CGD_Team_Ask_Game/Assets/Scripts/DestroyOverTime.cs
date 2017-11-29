using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is to get rid of junk objects in the game hierarchy
public class DestroyOverTime : MonoBehaviour {

	//public variable declared in unity editor. how long a game object will stay on screen
	public float lifeTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//matches the lifetime to the framerate
		lifeTime = lifeTime - Time.deltaTime;

		//once lifetime runs out, destroy object
		if (lifeTime <= 0f) {
			Destroy (gameObject);
		}
		
	}
}
