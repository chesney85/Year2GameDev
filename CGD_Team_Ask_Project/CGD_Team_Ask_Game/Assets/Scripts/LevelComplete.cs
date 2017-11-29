using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour {
	
	//public variables will be set in the unity editor as drag and drop
	public Sprite flagClosed;
	public Sprite flagOpen;
	public LevelManager theLevelManager;
	public GameObject WinUI;
	public GameObject CoinText;

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
			if (theLevelManager.coinCount < 1) {
				theSpriteRenderer.sprite = flagOpen;
				checkpointActive = true;
				Time.timeScale = 0;
				WinUI.SetActive (true);
			} else if (theLevelManager.coinCount > 0){
				CoinText.SetActive (true);
				StartCoroutine(Wait(2.0f));
				CoinText.SetActive (false);
			}

		}
	}


	public IEnumerator Wait(float delaySec)
	{
		yield return new WaitForSeconds (delaySec);
	}
}
