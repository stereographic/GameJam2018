using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Critter : MonoBehaviour {

	private Duplicator objectItem;

	// Use this for initialization
	void Start () {
		Player.population ++;
		Player.loseCount++;
		Debug.Log(Player.population);
	}
	
	// Update is called once per frame
	void Update () {

		if (Player.population >= 200 && gameObject.GetComponent<Duplicator>() != null)
		{
			gameObject.GetComponent<Duplicator>().enabled = false;
			Destroy(gameObject.GetComponent<Duplicator>());
			
		}
		if (Player.population <= 200 && gameObject.GetComponent<Duplicator>() == null)
		{
			gameObject.AddComponent<Duplicator>();
			gameObject.GetComponent<Duplicator>().myObject = gameObject;
		}

		if(transform.position.y < -100){
			Player.population = Player.population -1;
			Debug.Log(Player.population);
			Destroy(gameObject);
			Debug.Log("Critter fell to hell");
		}
	}

	void OnMouseDown(){
		Player.population = Player.population -1;
		Debug.Log(Player.population);
		Destroy(gameObject);
	}
}
