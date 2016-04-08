using UnityEngine;
using System.Collections;

public class endScript : MonoBehaviour {


	public int endValue = 1;

	public GameObject MapControl;
	//private GameObject MapCon;


	// Use this for initialization
	void Start () {
		MapControl = GameObject.FindGameObjectWithTag ("MapControl");
		//MapControl = MapCon;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void exploreTiles()
	{

		MapGen.endLevelValue += endValue;

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") {
			exploreTiles ();
			Destroy (other.gameObject);
			Destroy (this.gameObject);
			MapControl.GetComponent<MapGen>().regenLevel();
		}
		
	}
}

