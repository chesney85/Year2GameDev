using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

	//public variables will be set in the unity editor as drag and drop
	public Sprite flagClosed;
	public Sprite flagOpen;

	//declare a sprite renderer
	private SpriteRenderer theSpriteRenderer;

	public bool checkpointActive;

	// Use this for initialization
	void Start () {
		//initialise the spriteRenderer as the spriteRenderer attatched to checkpoint object
		theSpriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//if player touches the flag then change the sprite
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {
			theSpriteRenderer.sprite = flagOpen;
			checkpointActive = true;
		}
	}
}
