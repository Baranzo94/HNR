using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	//Enemy placement and numbers 
	public GameObject MapControl;


	// Use this for initialization
	void Awake () {
		MapControl = GameObject.FindGameObjectWithTag ("MapControl");

	}
	
	// Update is called once per frame
	void Update () {

	}

	/*void OnCollisionEnter(Collision collision)
	{
		
		if (collision.gameObject.tag == "Wall") 
		{
			Debug.Log ("Check");
		}
	}*/

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Walls") 
		{
			//Debug.Log ("Check");
			MapControl.GetComponent<MapGen> ().respawnSpawn ();
			Destroy (this.gameObject);
			//Test successful, make it respawn until it doesnt have a issue
		}
	}
}
