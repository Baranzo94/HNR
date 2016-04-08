using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {

	public AudioClip shoot;
	public AudioClip empty; 
	public AudioClip reload;
	//float speed = 100.0f;

	//float range = 100.0f;
	//float fireRate = 0.05f;
	//float force = 10.0f;
	 int bulletsPerClip;
	//int clips = 4;
	//float reloadTime = 0.5f;
	public bool clip_empty; 

	//private int bulletsLeft = 0;
	//private float nextFireTime = 0.0f;
	//private int m_LastFrameShot = -1;

	public int shotsFired;
	public static int totalShotsFired;
	//public GameObject spawn;
	public Transform spawn;

	public Text text;

	public GameObject projectile;
	void Start()
	{
		bulletsPerClip = 30;
		clip_empty = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		clip_check();
		totalShotsFired = shotsFired;
		text.text = "" + bulletsPerClip;
		if (clip_empty == false) 
		{
			if (Input.GetButtonDown ("Fire1")) 
			{     
				Ray ray = Camera.main.ScreenPointToRay
				(Input.mousePosition);
				bulletsPerClip = bulletsPerClip - 1;
				shotsFired = shotsFired + 1;
				//Debug.Log ("Bang");

				RaycastHit hit = new RaycastHit ();

				if (Physics.Raycast (ray, out hit)) 
				{
					if (hit.collider.gameObject.tag == "Enemies") 
					{
						Debug.Log ("Hit");
					}

				}
				Instantiate (projectile, spawn.position, spawn.rotation);

				GetComponent<AudioSource> ().PlayOneShot (shoot);


			}

		} 

		if (clip_empty == true)
		{
			Debug.Log ("Clip Empty");
			//GetComponent<AudioSource> ().PlayOneShot (empty);
		}

		if (Input.GetButtonDown ("Reload")) 
		{
			//yield return new WaitForSeconds (2);
			GetComponent<AudioSource> ().PlayOneShot (reload);
			bulletsPerClip = 30;
		}
	}
	//void OnControllerColliderHit(ControllerColliderHit hit)
	//{

	//}

	void Fire ()
	{
	


	}

	void clip_check()
	{
		
		if (bulletsPerClip == 0) 
		{
			clip_empty = true;
		} 
		else 
		{
			clip_empty = false;
		}

	}
}
