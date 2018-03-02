using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private Player instance;
	private int power;
	private Text txtPower;

	//private constructor
	private Player(){
		this.power = 0;	
	}

	//get instance
	public Player getInstance(){
		return instance;
	}

	// Use this for initialization
	void Start () {
		instance = new Player();
		instance.txtPower = GameObject.Find("lblPower").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		instance.power++;
		instance.txtPower.text = "Power: " + instance.power.ToString();
	}

	//public methods
	public int getPower(){
		return instance.power;
	}
}
