using UnityEngine;
using System.Collections;

public class tileScript : MonoBehaviour {


	public int explored;
	public bool activated;
	// Use this for initialization
	void Start () {
		//exploreTiles ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void exploreTiles()
	{
		
		explored = explored + 1;

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			explored = explored + 1;
			//exploreTiles ();
			//Debug.Log ("Check");
		}
	}
}
