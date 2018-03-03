using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstMed : MonoBehaviour {

	public GameObject critterOne;
	public GameObject critterTwo;
	public GameObject critterThree;

	public int density = 5;

	// Use this for initialization
	void Start () {

		Time.timeScale = 1;

		System.Random rnd = new System.Random();

		for(int i = 0; i < density; i ++){
			int x = rnd.Next(-184, 55);
			int z = rnd.Next(-117, 94);
			GameObject newCritterOne = Instantiate(critterOne, new Vector3(x, 16, z), transform.rotation);

			x = rnd.Next(-184, 55);
			z = rnd.Next(-117, 94);
			GameObject newCritterTwo = Instantiate(critterTwo, new Vector3(x, 16, z), transform.rotation);

			x = rnd.Next(-184, 55);
			z = rnd.Next(-117, 94);
			GameObject newCritterThree = Instantiate(critterThree, new Vector3(x, 16, z), transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
