using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private const int POP = 0;
	private const int LASER = 1;
	private const int PLAGUE = 2;
	private const int METEOR = 3;

	private const int POP_COST = 0;
	private const int LASER_COST = 1;
	private const int PLAGUE_COST = 10;
	private const int METEOR_COST = 20;

	private const int METEOR_RADIUS = 20;

	public static float population;
	public GameObject quitScreen;
	public static float loseCount;

	private Vector3 position;
	private LayerMask layerMask;
	private LayerMask terrainLayer;
	public GameObject meteor;
	public GameObject plague;
	public GameObject laser;
	public int _current;
	private GameObject target;
	private GameObject parent;
	private Camera c;
	public int power;
	public Text txtPower;
	public bool isWin = false;
	public bool isLose = false;

	// Use this for initialization
	void Start () {
		c = Camera.main;
		layerMask = LayerMask.GetMask("critter");
		terrainLayer = LayerMask.GetMask("terrain");
		txtPower = GameObject.Find("lblPower").GetComponent<Text>();
		quitScreen = GameObject.Find("QuitScreen");
		quitScreen.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Population <= 0) 
		{
			IsWin = true;
			Debug.Log("Win!!!!!!");
		}

		if (Population > 0) 
		{
			IsWin = false;
		}

		if (LoseCount > 1000)
		{
			IsLose = true;
			Debug.Log("Lose!!!!!!");
		}

		if (Input.GetKey("escape")){
			//SceneManager.LoadScene("QuitScreen");
			quitScreen.SetActive(true);
			Time.timeScale = 0;
		}

		
		if(current == LASER) {
			if(Input.GetMouseButton(0)) {
				if(power >= LASER_COST){
					Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
					RaycastHit hit;
					GameObject terrain = GameObject.Find("Terrain_2");
					if (terrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) 
					{
						Debug.DrawLine(ray.origin, hit.point);
						position = hit.point;
					}
					Debug.Log("LASERING");
					Laser(position);
				}
			}
		} else {
			if(Input.GetMouseButtonDown(0)){
				switch (current) {
					case METEOR:
						if(power >= METEOR_COST){
							Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
							RaycastHit hit;
							GameObject terrain = GameObject.Find("Terrain_2");
							if (terrain.GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) 
							{
								Debug.DrawLine(ray.origin, hit.point);
								position = hit.point;
							}
							position = new Vector3(position.x, position.y + 100, position.z);
							Meteor(position);
							break;
						}
						break;
					case POP:
						Pop(position);
						break;
					case PLAGUE:
						if(power >= PLAGUE_COST){
							Plague(position);
							break;
						}
						break;
				}
			}
		}
		move();
		txtPower.text = "Power: " + power.ToString();
	}

	// --------------------------------- get/sets
	

	public float LoseCount
    {
        get { return loseCount;}
        set { loseCount = value;}
    }

	public bool IsWin
    {
        get { return isWin;}
        set { isWin = value;}
    }

	public bool IsLose
    {
        get { return isLose;}
        set { isLose = value;}
    }

	public float Population
    {
        get { return population;}
        set { population = value;}
    }
	
	public int current {
		get { return _current; }
		set { _current = value; }
	}

	// --------------------------------- private methods
	void Meteor (Vector3 position) {
		Vector3 meteorPosition = new Vector3(position.x + 50, position.y, position.z);
		GameObject meteorObject = Instantiate(meteor, meteorPosition, gameObject.transform.rotation);
		meteorObject.GetComponent<Rigidbody>().velocity = new Vector3(-100,-200,0);
		power -= METEOR_COST;
	}

	void Plague (Vector3 position) {
		Debug.Log("Plaging");
	}

	void Pop(Vector3 position) {
		target = GetClickedGameObject();
		if(target != null){
			kill(target);
		}
	}

	void Laser(Vector3 position) {
		Instantiate(laser, position, gameObject.transform.rotation);
		Instantiate(laser.GetComponent<Laser>().fireBall, position, gameObject.transform.rotation);
		target = GetClickedGameObject();
		power -= LASER_COST;
		if(target != null){
			kill(target);
		}
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
		power += 5;
		parent = target.transform.parent.gameObject;
		Player.population = Player.population -1;
		Debug.Log(Player.population);
		Debug.Log(target);
		Destroy(target);
		Destroy(parent);
	}

	//public methods
	public int getPower(){
		return power;
	}

	public void changeWeapon(int weapon){
		current = weapon;
	}

	public void move(){
		// rotate
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f;
		// movement speed
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 50.0f;
		// zoom
		var y = Input.GetAxis("Mouse ScrollWheel") * -Time.deltaTime * 500.0f;
		// stop at 300 y or 20 y
		var pos = transform.position;
		transform.position = new Vector3(
			pos.x,
			Mathf.Clamp(pos.y, -20, 300),
			pos.z
		);
		// stop x
		pos = transform.position;
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
			Mathf.Clamp(pos.z, -200, 135)
		);
		
		transform.Translate(0, y, 0);

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);
	}
}
