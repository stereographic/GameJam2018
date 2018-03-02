using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

	private Vector3 position;
	public GameObject meteor;
	public GameObject Plague;
	private Camera c;

	// Use this for initialization
	void Start () {
		c = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			Meteor();
		}
	}

	void Meteor () {
		position = c.ScreenToWorldPoint(new Vector3(
			Input.mousePosition.x,
			Input.mousePosition.y,
			20
		));

		Debug.Log("I CLICKED");
		Instantiate(meteor, position, gameObject.transform.rotation);
	}
}