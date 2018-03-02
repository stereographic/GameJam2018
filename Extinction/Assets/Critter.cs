using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Critter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < -100){
			Destroy(gameObject);
			Debug.Log("Critter fell to hell");
		}
	}

	void OnMouseDown(){
		Destroy(gameObject);
	}
}
