using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	float mySpeed = 30;
	float myRange = 20;

	public int damage = 10;
	private float myDist;
	PlayerScript playerHealth;
	GameObject player;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerScript> ();

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * mySpeed);
		myDist += Time.deltaTime * mySpeed;
		if (myDist >= myRange)
			Destroy (gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			Debug.Log ("Hit");
			if (playerHealth.currentHealth > 0) 
			{
				playerHealth.TakeDamage (damage);

			}
		}
	}
}
