using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// rotate
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f;
		// movement speed
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 50.0f;
		// zoom
		var y = Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 500.0f;
		// stop at 300 y or 20 y
		var pos = transform.position;
		transform.position = new Vector3(
			pos.x,
			Mathf.Clamp(pos.y, 20, 300),
			pos.z
		);
		// stop x
		pos = transform.position;
		transform.position = new Vector3(
			Mathf.Clamp(pos.x, -200, 95),
			pos.y,
			pos.z
		);
		// stop z
		pos = transform.position;
		transform.position = new Vector3(
			pos.x,
			pos.y,
			Mathf.Clamp(pos.z, -150, 135)
		);
		
		transform.Translate(0, y, 0);

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
	}
}
