﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public float deathTime = 30;
	private System.Timers.Timer age;
	
	// Use this for initialization
	void Start () {
		StartCoroutine ("Countdown", deathTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// timer till death
	private IEnumerator Countdown(int time){
    while(time>0){
        Debug.Log(time--);
        yield return new WaitForSeconds(1);
    }
	Player.population --;
	Destroy (gameObject);
    Debug.Log("Countdown Complete!");
	}
}