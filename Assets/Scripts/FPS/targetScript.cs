using UnityEngine;
using System.Collections;

public class targetScript : MonoBehaviour {
	public int shotsHit;
	private MapGen MapControl;
	public int shotValue = 1;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Accuracy()
	{
		MapGen.Accurate += shotValue;

	}

	void OnTriggerEnter(Collider other)
	{
		//if (other.gameObject.tag == "Bullet") {
		Destroy (this.gameObject);
		Destroy (other.gameObject);
			//Debug.Log ("Hit");
		Accuracy ();

		//shotsHit = shotsHit + 1;
		//}
	}
}
