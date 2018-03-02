using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plagueis : MonoBehaviour {

	public bool plague = false;

	// Use this for initialization
	void Start () {
		Debug.Log(plague);
	}
	
	// Update is called once per frame
	void Update () {
		// add but support here
	}

	public bool getPlague()
	{
		return plague;
	}

	public void setPlague()
	{
		plague = true;
	}
}
