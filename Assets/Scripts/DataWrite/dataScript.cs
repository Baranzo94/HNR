using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class dataScript : MonoBehaviour {

	string test1;
	string test2;
	public GameObject text;
	public string exploreData;
	public string accurateData;
	public string enemyData;
	public string totalEnemies;
	public string timeData;
	public string taxData;
	public string remainingData;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		exploreData	= (MapGen.Explored).ToString();
		totalEnemies = (MapGen.Accurate).ToString ();
		enemyData = (MapGen.Accurate).ToString ();
		accurateData = (GunScript.totalShotsFired).ToString ();
		timeData = (MapGen.timeSaved).ToString();
		taxData = (MapGen.explorer).ToString ();
		remainingData = (MapGen.totalEnemies).ToString ();
	}

	public void save ()
	{		
		//Add specific taxomomy, rather than 3 seperate types

		//System.IO.File.WriteAllText("C:/Users/Liam/testTextfile.txt", test1 + ", " + test2);
		System.IO.File.WriteAllText("Data.txt", "Explore Data " + "" + exploreData + "," + "Enemies Defeated " + "" + totalEnemies + "," +  "Shots Hit " + "" +  enemyData  + "," + "Enemies Remaining " + remainingData + "," +  "Shots Fired " + "" +  accurateData  +"," +  "Time Taken " +"" +  timeData + "," + "Taxonomy " + taxData);
		//System.IO.File.WriteAllText(text, test1 + ", " + test2);
		
	}

	public void save2 ()
	{		
		//System.IO.File.WriteAllText("C:/Users/Liam/testTextfile.txt", test1 + ", " + test2);
		System.IO.File.WriteAllText("Data2.txt", "Explore Data " + "" + exploreData + "," + "Enemies Defeated " + "" + totalEnemies + "," +  "Shots Hit " + "" +  enemyData  + "," + "Enemies Remaining " + remainingData + "," +  "Shots Fired " + "" +  accurateData  +"," +  "Time Taken " +"" +  timeData + "," + "Taxonomy " + taxData);
		//System.IO.File.WriteAllText(text, test1 + ", " + test2);

	}

	public void save3 ()
	{		
		//System.IO.File.WriteAllText("C:/Users/Liam/testTextfile.txt", test1 + ", " + test2);
		System.IO.File.WriteAllText("Data3.txt", "Explore Data " + "" + exploreData + "," + "Enemies Defeated " + "" + totalEnemies + "," +  "Shots Hit " + "" +  enemyData  + "," + "Enemies Remaining " + remainingData + "," + "Shots Fired " + "" +  accurateData  +"," +  "Time Taken " +"" +  timeData + "," + "Taxonomy " + taxData);
		//System.IO.File.WriteAllText(text, test1 + ", " + test2);

	}
		
}
