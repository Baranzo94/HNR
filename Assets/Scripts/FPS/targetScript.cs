using UnityEngine;
using System.Collections;

public class targetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		//if (other.gameObject.tag == "Bullet") {
		Destroy (this.gameObject);
		Destroy (other.gameObject);
			Debug.Log ("Hit");
		//}
	}
}
// Instantiate (projectile, spawn.position, spawn.rotation);