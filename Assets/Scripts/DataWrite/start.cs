using UnityEngine;
using System.Collections;

public class start : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeScene( int sceneToChangeTo )
	{
		Application.LoadLevel (sceneToChangeTo);
	}

	public void quit()
	{
		Application.Quit ();
	}
}
