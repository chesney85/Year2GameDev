﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//declare variable for speed of character
	public float moveSpeed;
	//declare RigidBody to use for movement
	private Rigidbody2D myRigidBody;
	//declare variable to control jump movement
	public float jumpSpeed;

	//declaring a transform to check if player touching ground
	public Transform groundCheck;
	//this is for the radius of the ground check
	public float groundCheckRadius;
	//needed to check the layer the player is touching
	public LayerMask whatIsGround;
	//bool to say wether player is on ground or not
	public bool isGrounded;

	//declare an animator for sprites
	private Animator myAnim;

	// Use this for initialization
	void Start () {
		//tells unity that myRigidBody is equal to the rigidbody on player
		myRigidBody = GetComponent<Rigidbody2D> ();
		//tells unity myAnim is equal to the animator on player
		myAnim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		//determine if grounded or not by using our variables declared above
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		//determine if button is pressed then move character using corresponding keys
		//getaxisRaw for 2d as theres theres no lag
		if (Input.GetAxisRaw ("Horizontal") > 0f) {
			//if greater than zero**which means moving right** add velocity to rigidbody
			//Vector3 is a position with 3 values x,y,z 
			//velocity of character  x value is equal to moveSpeed.
			//y value is equal to current y value of player. no z value 
			myRigidBody.velocity = new Vector3 (moveSpeed, myRigidBody.velocity.y, 0f);
			//set sprite to face right if moving right
			transform.localScale = new Vector3(1f, 1f, 1f);

			//less than zero is left
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {
			myRigidBody.velocity = new Vector3 (-moveSpeed, myRigidBody.velocity.y, 0f);

			//set sprite to face left if moving left
			transform.localScale = new Vector3(-1f, 1f, 1f);
		} else {
			//to stop character sliding slightly after buttone depressed this is added
			myRigidBody.velocity = new Vector3 (0f, myRigidBody.velocity.y, 0f);
		}
		
		//if statement for jumping. if button is pressed and standing on ground then jump
		if (Input.GetButtonDown("Jump") && isGrounded) {
			//x axis stays same, y axis is jump speed, x axis stays same at 0
			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, jumpSpeed, 0f);
		}

		//Mathf math function says absolute value i.e. if negative turn positive number
		//this ensure float speed is always positive for the animation
		myAnim.SetFloat ("Speed",Mathf.Abs(myRigidBody.velocity.x) );
		//set the animation bool equal to character position if on ground or not
		myAnim.SetBool ("Grounded", isGrounded);
	}
}