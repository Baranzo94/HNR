using UnityEngine;
using System.Collections;

public class tileScript : MonoBehaviour {


	public int ExploreValue = 1;
	public bool explored;

	public int enemiesDefeated;
	public int timeCompleted;
	public int shotsFired;
	public int shotAccuracy;
	private MapGen MapControl;
	// Use this for initialization
	void Start () {
		//exploreTiles ();

		GameObject mapControllerObject = GameObject.FindGameObjectWithTag ("MapControl");
		/*if (mapControllerObject != null)
		{
			mapControl = mapControllerObject.GetComponent <MapGen>();
		}
		if (mapControl == null)
		{
			Debug.Log ("Cannot find 'MapGen' script");
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void exploreTiles()
	{
		
		MapGen.Explored += ExploreValue;

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			explored = true;
			exploreTiles ();
			//Collider box = this.gameObject.GetComponent<BoxCollider>();
			GetComponent<BoxCollider>().enabled = false;
			exploreTiles ();
			//Debug.Log ("Check");
		}
	}
}
