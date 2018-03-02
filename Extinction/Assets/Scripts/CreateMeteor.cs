using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMeteor : MonoBehaviour {

	private Vector3 position;
	public GameObject gameObject;
	private Camera c;

	// Use this for initialization
	void Start () {
		c = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			
			position = c.ScreenToWorldPoint(new Vector3(
				Input.mousePosition.x,
				Input.mousePosition.y,
				20
			));

			Debug.Log("I CLICKED");
			Instantiate(gameObject, position, gameObject.transform.rotation);
		}

	}

}
