using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : Singleton<GameManager> {

	public int tickies;
	public Text tickieLevel;

	private float _timeRemaining;

	public float TimeRemaining
	{
		get { return _timeRemaining; }
		set { _timeRemaining = value; }
	}

	private float maxTime = 5 * 60; // 5 min

	// Use this for initialization
	void Start () {
		TimeRemaining = maxTime;

		tickieLevel = GameObject.Find("TickieLevel").GetComponent<Text>();
		//Debug.Log("!!!!!!!!!!!!!!!!!!!!!!Tickies: " + tickieLevel.text);
	}
	
	// Update is called once per frame
	void Update () {
		TimeRemaining -= Time.deltaTime;

		if(TimeRemaining <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			TimeRemaining = maxTime;
		}

		tickieLevel.text = "Tickies: " + tickies;
	}

	public void addTickies(){
		tickieLevel = GameObject.Find("TickieLevel").GetComponent<Text>();
		tickies ++;
		Debug.Log(tickieLevel.text);
		tickieLevel.text = "Tickies: " + tickies;
		//Debug.Log(tickies);
		//tickieLevel.text = "Tickies: " + tickies;	
	}
}
