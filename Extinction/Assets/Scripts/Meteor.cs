using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	private const int blastRadius = 50;

	public GameObject myObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;
        Instantiate(myObject, pos, rot);
		OnMeteorExplode();
        Destroy(gameObject);
    }

	void OnMeteorExplode() {
		GameObject[] critters = GameObject.FindGameObjectsWithTag("critter");
		foreach (var critter in critters) {
			if(blastRadius >= Vector3.Distance(transform.position, critter.transform.position)) {
				Player.population -= 1;
				Destroy(critter);
			}
		}
	}
}
