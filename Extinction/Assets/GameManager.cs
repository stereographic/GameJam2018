using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager> {

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
	}
	
	// Update is called once per frame
	void Update () {
		TimeRemaining -= Time.deltaTime;

		if(TimeRemaining <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			TimeRemaining = maxTime;
		}
	}
}
