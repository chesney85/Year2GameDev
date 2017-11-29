using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	//number of time to wait to respawn
	public float waitToRespawn;

	//instance of the playerController Script
	public PlayerController thePlayer;

	//particle effect when player dies
	public GameObject deathSplosion;

	//keep track of coins collected
	public int coinCount;

	private Animator myAnim;

	//UI text element to count coins collected
	public Text coinText;

	//UI element for health
	public Image heart1;
	public Image heart2;
	public Image heart3;

	public Sprite heartFull;
	public Sprite heartEmpty;

	public int maxHealth;
	public int healthCount;

	private bool respawning;

	public GameObject Death;



	// Use this for initialization
	void Start () 
	{
		//find object in screen that has playerController script atttatched to it
		thePlayer = FindObjectOfType<PlayerController> ();

		coinText.text = "Coins to collect: " + coinCount;

		healthCount = maxHealth;

	}
	
	// Update is called once per frame
	void Update () 
	{

		if (healthCount <= 0 && !respawning) {
			Respawn ();
			respawning = true;
		}
	}

	public void Respawn()
	{

		//start co-routine with the name of RespawnCo within the script
		StartCoroutine ("RespawnCo");	
	}

	//Co-Routine
	public IEnumerator RespawnCo()
	{

		//player turns invisible
		thePlayer.gameObject.SetActive (false);
		//once player invisible run particle for death
		Instantiate (deathSplosion, thePlayer.transform.position, thePlayer.transform.rotation);

		//tells the game to wait before running next line of code
		yield return new WaitForSeconds (waitToRespawn);

		Time.timeScale = 0;
//		SceneManager.LoadScene ("lavaLevel");

		Death.SetActive (true);
//
//		healthCount = maxHealth;
//		respawning = false;
//		UpdateHeartMeter ();
//
//		thePlayer.transform.position = thePlayer.respawnPosition;
//		thePlayer.gameObject.SetActive (true);


	}

	public void AddCoins(int coinsToAdd)
	{
		
		coinCount -= coinsToAdd;
		coinText.text = "Coins to collect: " + coinCount;

	}

	public void HurtPlayer(int damageToTake)
	{
		healthCount -= damageToTake;
		UpdateHeartMeter ();
	}

	public void UpdateHeartMeter()
	{
		switch (healthCount)
		{

		case 3:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartFull;
			return;

		case 2:
			heart1.sprite = heartFull;
			heart2.sprite = heartFull;
			heart3.sprite = heartEmpty;
			return;

		case 1:
			heart1.sprite = heartFull;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;

		case 0:
			heart1.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;

		default:
			heart1.sprite = heartEmpty;
			heart2.sprite = heartEmpty;
			heart3.sprite = heartEmpty;
			return;
		}

	}
}
