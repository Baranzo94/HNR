﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
	

	public Texture2D crosshairTexture;
	public float crosshairScale = 1;
	public bool isZoomed = false;


	//public int startingHealth = 100;
	//public int currentHealth;
	//public Slider healthSlider;
	//bool damaged;
	//bool isDead;


	//public int bulletsInClip;

	 //public Text text;

	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
		
	void Awake()
	{
		//currentHealth = startingHealth;	
	}
	void Update()
	{
		checkIfZoomed ();
		if (Input.GetButtonDown ("Zoom")) 
		{
				isZoomed = !isZoomed;
			if (isZoomed) {
				isZoomed = true;
			} else 
			{
				isZoomed = false;
			}
		} 

		//damaged = false;


	}

	void OnGUI()
	{

			if(crosshairTexture!=null)
				GUI.DrawTexture(new Rect((Screen.width-crosshairTexture.width*crosshairScale)/2 ,(Screen.height-crosshairTexture.height*crosshairScale)/2, crosshairTexture.width*crosshairScale, crosshairTexture.height*crosshairScale),crosshairTexture);
			else
				Debug.Log("No crosshair texture set in the Inspector");

	}

	void checkIfZoomed()
	{
		if (isZoomed == true) {
			GetComponent<Camera> ().fieldOfView = 50;
		
		} else 
		{
			GetComponent<Camera> ().fieldOfView = 80;
		}
	}

	public void TakeDamage (int amount)
	{
		//damaged = true;

		//currentHealth -= amount;

		//healthSlider.value = currentHealth;

		//if(currentHealth <= 0 && !isDead)
		//{
		//	Death();
		//}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wall") 
		{
			Debug.Log ("Check");
		}
			
	}

	void Death()
	{
	//	isDead = true;
	}
}
