using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public int power;
	public Text txtPower;

	// Use this for initialization
	void Start () {
		txtPower = GameObject.Find("lblPower").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		move();
		power++;
		txtPower.text = "Power: " + power.ToString();
	}

	//public methods
	public int getPower(){
		return power;
	}

	public void move(){
		// rotate
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f;
		// movement speed
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 50.0f;
		// zoom
		var y = Input.GetAxis("Mouse ScrollWheel") * -Time.deltaTime * 500.0f;
		// stop at 300 y or 20 y
		var pos = transform.position;
		transform.position = new Vector3(
			pos.x,
			Mathf.Clamp(pos.y, -20, 300),
			pos.z
		);
		// stop x
		pos = transform.position;
		transform.position = new Vector3(
			Mathf.Clamp(pos.x, -155, 84),
			pos.y,
			pos.z
		);
		// stop z
		pos = transform.position;
		transform.position = new Vector3(
			pos.x,
			pos.y,
			Mathf.Clamp(pos.z, -130, 142)
		);
		
		transform.Translate(0, y, 0);

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
	}
}
