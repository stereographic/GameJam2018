using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CritterWalk : MonoBehaviour {

    public float speed = 5;
	public float directChange = 1;
	public float maxHeadChange = 30;
 
	CharacterController controller;
	float heading;
	Vector3 targetRotation;
 
	void Awake ()
	{
		controller = GetComponent<CharacterController>();
 
		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);
 
		StartCoroutine(NewHeading());
	}
 
	void Update ()
	{
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directChange);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed);
		Transform playerTransform = this.transform;
		// get player position
		Vector3 position = playerTransform.position;
		// z 140 x 140 x-130 z-150
		if (position.z == 140 || position.z == -130 || position.x == 140 || position.x == -150)
		{
			endMap();
		}
	}
 

	// Repeatedly calculates a new direction to move towards.
	IEnumerator NewHeading ()
	{
		while (true) {
			NewHeadingRoutine();
			yield return new WaitForSeconds(directChange);
		}
	}

	// stops at map end and turns
	void endMap() {
		targetRotation = new Vector3(0, 100, 0);
	}
 
	// Calculates a new direction to move towards.
	void NewHeadingRoutine ()
	{
		var floor = Mathf.Clamp(heading - maxHeadChange, 0, 360);
		var ceil  = Mathf.Clamp(heading + maxHeadChange, 0, 360);
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0, heading, 0);
	}
}