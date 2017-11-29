using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string firstLevel;
	public string mainMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewGame(){
		Time.timeScale = 1;
		SceneManager.LoadScene (firstLevel);
	}

	public void QuitGame(){
		Application.Quit ();
	}

	public void Menu(){
		SceneManager.LoadScene (mainMenu);
	}
}
