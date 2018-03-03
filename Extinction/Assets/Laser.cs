using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
	public GameObject fireBall;
	private int count;
	

	// Use this for initialization
	void Start () {
		count = 0;
		//Instantiate(fireBall, gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
		count ++;
		if(count > 20){
			Destroy(gameObject);
		}
	}
}
