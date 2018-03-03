using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onEasy(){
		SceneManager.LoadScene("Easy");
	}

	public void onMeduim(){
		SceneManager.LoadScene("Level1");
	}

	public void onHard(){
		SceneManager.LoadScene("Hard");
	}
}
