using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tickies : Singleton<Tickies> {

	public int tickies;
	public Text tickieLevel;

	// Use this for initialization
	void Start () {
		tickieLevel = GameObject.Find("TickieLevel").GetComponent<Text>();
		Debug.Log("!!!!!!!!!!!!!!!!!!!!!!Tickies: " + tickieLevel.text);
		tickies = 0;
	}
	
	// Update is called once per frame
	void Update () {
		tickieLevel.text = "Tickies: " + tickies;
		//Debug.Log("Tickies: " + tickies);
	}

	public void addTickies(){
		tickies ++;
		Debug.Log("Tickies: " + tickies);
		tickieLevel.text = "Tickies: ";
		//Debug.Log(tickies);
		//tickieLevel.text = "Tickies: " + tickies;	
	}
}
