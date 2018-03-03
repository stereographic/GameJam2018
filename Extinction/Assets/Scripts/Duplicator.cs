using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicator : MonoBehaviour {

	public float _initial = 2f;
	public float _after = 2f;
	public float _chance = 0.5f;
	public int burstVal = 5;
	public GameObject _myObject;
	public string _type = "constant";
	private int ran = 0;
	private CritterWalk plag;
	
	void Start () {

		plag = this.gameObject.GetComponent<CritterWalk>();
		if (plag.getIsPlagueis() != true)
		{
			if (Player.population < 200)
			{
				Player.population ++;
				InvokeRepeating("doubleCritter", initial, after);
			} else {
				Player.population --;
				Destroy(gameObject);
			}
		}
	}

	// ----------------------------------------- gets/sets
	public float initial 
	{
		get { return _initial; }
		set { _initial = value; }
	}
	public float after 
	{
		get { return _after; }
		set { _after = value; }
	}

	public float chance 
	{
		get { return _chance; }
		set { _chance = value; }
	}

	public string type {
		get { return _type; }
		set { _type = value; }
	}


	public GameObject myObject
	{
		get { return _myObject; }
		set { _myObject = value; }
	}

	// Update is called once per frame
	void Update () {
		if (plag.getIsPlagueis() == true)
		{
			Debug.Log("infected");
			Start();
			
		}
		if (Player.population > 200)
		{
			Player.population --;
			Destroy(gameObject);
		}
		if(ran >= 5) {
			Debug.Log("dubed 5 times");
		}	
	}

	// ----------------------------------------- private methods
	void doubleCritter() {
		
		if(type == "burst"){
			for(int i = 0; i < burstVal; i++) {
				GameObject newObj = Instantiate(myObject, new Vector3(transform.position.x+5, transform.position.y + 10, transform.position.z + 5), transform.rotation);
			}
		} else {
			float rand = Random.Range(0f,1f);
			if (rand >= chance) {
				GameObject newObj = Instantiate(myObject, new Vector3(transform.position.x+5, transform.position.y + 10, transform.position.z + 5), transform.rotation);
				ran++;
			}
		}
		
	}


}
