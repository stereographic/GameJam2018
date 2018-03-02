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
		limitMove();
	}
 

	// Repeatedly calculates a new direction to move towards.
	IEnumerator NewHeading ()
	{
		while (true) {
			NewHeadingRoutine();
			yield return new WaitForSeconds(directChange);
		}
	}
 
	// Calculates a new direction to move towards.
	void NewHeadingRoutine ()
	{
		var floor = Mathf.Clamp(heading - maxHeadChange, 0, 360);
		var ceil  = Mathf.Clamp(heading + maxHeadChange, 0, 360);
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0, heading, 0);
	}

	// stops critter if at end of map
	void limitMove ()
	{
		// stop x
		var pos = transform.position;
		transform.position = new Vector3(
			Mathf.Clamp(pos.x, -135, 95),
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
	}
}