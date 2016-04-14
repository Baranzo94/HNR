using UnityEngine;
using System.Collections;

public class endScript : MonoBehaviour {


	public int endValue = 1;

	public GameObject MapControl;
	//private GameObject MapCon;


	// Use this for initialization
	void Awake () {
		//MapControl = MapCon;		
		MapControl = GameObject.FindGameObjectWithTag ("MapControl");

	}
	
	// Update is called once per frame
	void Update () {

	}

	void exploreTiles()
	{

		//MapGen.endLevelValue += endValue;
		MapControl.GetComponent<MapGen>().complete();

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			exploreTiles ();
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			MapControl.GetComponent<MapGen>().regenLevel();
		}

		if (other.gameObject.tag == "Walls") 
		{
			//.Log ("Test Exit");			


			MapControl.GetComponent<MapGen>().respawnExit();
			Destroy (this.gameObject);
			//Test successful, make it respawn until it doesnt have a issue
		}
		
	}
		
}

