using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	//Enemy placement and numbers 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*[System.Serializable]
	public class Round {
		public int targetCount;
	}*/

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
			Debug.Log ("Check");
			//Test successful, make it respawn until it doesnt have a issue
		}
	}
}
