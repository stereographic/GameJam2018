using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		// rotate
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f;
		// movement speed
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 50.0f;

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
	}
}
