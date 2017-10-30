using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	//number of time to wait to respawn
	public float waitToRespawn;

	//instance of the playerController Script
	public PlayerController thePlayer;



	// Use this for initialization
	void Start () {
		//find object in screen that has playerController script atttatched to it
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Respawn(){

		//start co-routine with the name of RespawnCo within the script
		StartCoroutine ("RespawnCo");	
	}

	//Co-Routine
	public IEnumerator RespawnCo(){

		thePlayer.gameObject.SetActive (false);

		//tells the game to wait before running next line of code
		yield return new WaitForSeconds (waitToRespawn);

		thePlayer.transform.position = thePlayer.respawnPosition;
		thePlayer.gameObject.SetActive (true);
	}
}
