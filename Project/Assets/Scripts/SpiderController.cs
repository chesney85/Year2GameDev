﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour {

	public float moveSpeed;

	private bool canMove;

	private Rigidbody2D myRigidBody;
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) 
		{
			//to go left
			myRigidBody.velocity = new Vector3 (-moveSpeed, myRigidBody.velocity.y, 0f);
		}
	}

	void OnBecameVisible(){
		canMove = true;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "KillPlane") {
			Destroy (gameObject);
		}

	}
}
