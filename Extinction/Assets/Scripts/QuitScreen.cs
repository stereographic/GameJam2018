using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScreen : MonoBehaviour {

	public GameObject quitScreen;

	// Use this for initialization
	void Start () {
		quitScreen = GameObject.Find("QuitScreen");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onQuit(){
		Application.Quit();
	}

	public void onResume(){
		quitScreen.SetActive(false);
		Time.timeScale = 1;
	}

	public void onRestart(){
		SceneManager.LoadScene("Level1");
		Time.timeScale = 1;
	}

	public void onClick(){
		if (Input.GetKey("escape")){
            SceneManager.LoadScene("QuitScreen");
		}
	}
}
