using UnityEngine;
using System.Collections;

public class SentryScript : MonoBehaviour {

	//Transform myTarget;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onTriggerEnter(Collider other)
	{
		if (other.tag=="Enemy") {
			Debug.Log ("Found them");
		}
	}

	void onTriggerExit(Collider other)
	{

		//myTarget = null;
		Debug.Log ("Lost them");
	}
}
