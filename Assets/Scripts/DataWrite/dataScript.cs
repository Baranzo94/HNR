using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class dataScript : MonoBehaviour {

	string test1;
	string test2;
	public GameObject text;

	// Use this for initialization
	void Start () {
		test1 = "ABC";
		test2 = "XYZ";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void save ()
	{

		//System.IO.File.WriteAllText("C:/Users/Liam/testTextfile.txt", test1 + ", " + test2);
		System.IO.File.WriteAllText("testTextfile.txt", test1 + ", " + test2);
		//System.IO.File.WriteAllText(text, test1 + ", " + test2);
		
	}

	void load ()
	{
		
	}
}
