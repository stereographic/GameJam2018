using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour {

	private const int POP = 0;
	private const int LASER = 1;
	private const int PLAGUE = 2;
	private const int METEOR = 3;

	private Vector3 position;
	private LayerMask layerMask;
	public GameObject meteor;
	public GameObject plague;
	public GameObject laser;
	public int _current;
	private GameObject target;
	private GameObject parent;
	private Camera c;

	// Use this for initialization
	void Start () {
		c = Camera.main;
		layerMask = LayerMask.GetMask("critter");
	}
	
	// Update is called once per frame
	void Update () {
		position = c.ScreenToWorldPoint(new Vector3(
			Input.mousePosition.x,
			Input.mousePosition.y,
			20
		));
		if(current == LASER) {
			if(Input.GetMouseButton(0)) {
				Debug.Log("LASERING");
				Laser(position);
			}
		} else {
			if(Input.GetMouseButtonDown(0)){
				switch (current) {
					case METEOR:
						Meteor(position);
						break;
					case POP:
						Pop(position);
						break;
					case PLAGUE:
						Plague(position);
						break;
				}
			}
		}
	}

	// --------------------------------- get/sets
	public int current {
		get { return _current; }
		set { _current = value; }
	}

	// --------------------------------- private methods
	void Meteor (Vector3 position) {
		Instantiate(meteor, position, gameObject.transform.rotation);
	}

	void Plague (Vector3 position) {
		Debug.Log("Plaging");
	}

	void Pop(Vector3 position) {
		target = GetClickedGameObject();
		kill(target);
	}

	void Laser(Vector3 position) {
		target = GetClickedGameObject();
		kill(target);
	}

	GameObject GetClickedGameObject() 
	{ 
		// Builds a ray from camera point of view to the mouse position 
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
		RaycastHit hit; 
		// Casts the ray and get the first game object hit 
		if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) 
		{
			return hit.transform.gameObject;
		}
		else 
			return null; 
	}

	void kill(GameObject one) {
		parent = target.transform.parent.gameObject;
		Player.population --;
		Debug.Log(target);
		Destroy(target);
		Destroy(parent);
	}


}