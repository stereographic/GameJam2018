using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public float deathTime = 30;
	private System.Timers.Timer age;
	
	// Use this for initialization
	void Start () {
		age = new System.Timers.Timer (1000);
	}
	
	// Update is called once per frame
	void Update () {
		deathTime -= Time.deltaTime;

        if (deathTime <= 0) {

            Destroy (gameObject);

        }
	}
}
