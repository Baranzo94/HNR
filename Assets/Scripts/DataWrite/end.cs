using UnityEngine;
using System.Collections;

public class end : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("escape")) 
		{
			Application.Quit ();
		}
	
		}

	public void exitApp()
	{
		Application.Quit ();
	}
}
