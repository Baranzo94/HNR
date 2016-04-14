using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class dataScript : MonoBehaviour {

	//string test1;
	//string test2;
	//public GameObject text;
	public string exploreData;
	public string accurateData;
	public string enemyData;
	public string totalEnemies;
	public string timeData;
	public string taxDataE;
	public string taxDataK;
	public string taxDataA;
	public string levelData;
	public string seedData;
	public string totalTiles;

	public string remainingData;

	// Use this for initialization
	void Start () {
		/*exploreData = "";
		accurateData = "";
		enemyData ="";
		totalEnemies = "";
		timeData= "";
		taxDataE= "";
		taxDataK= "";
		taxDataA= "";
		levelData= "";
		remainingData= "";*/
		/*if (System.IO.File.Exists ("Data.txt")) 
		{
			Debug.Log ("File already exists");
		}*/

	}
	
	// Update is called once per frame
	void Update () {
		exploreData	= (MapGen.Explored).ToString();
		totalEnemies = (MapGen.Accurate).ToString ();
		enemyData = (MapGen.Accurate).ToString ();
		accurateData = (GunScript.totalShotsFired).ToString ();
		timeData = (MapGen.timeSaved).ToString();
		taxDataE = (MapGen.explorer).ToString ();
		taxDataA = (MapGen.acheiver).ToString ();
		taxDataK = (MapGen.killer).ToString ();
		remainingData = (MapGen.totalEnemies).ToString ();
		levelData = (MapGen.levelNumber).ToString ();
		seedData = (MapGen.seedRec).ToString ();
		totalTiles = (tileMap.totalExplore).ToString ();


	}

	public void save ()
	{		
		//Add specific taxomomy, rather than 3 seperate types

		//System.IO.File.WriteAllText("C:/Users/Liam/testTextfile.txt", test1 + ", " + test2);
		System.IO.File.WriteAllText("Data.txt","Level Seed "+ "" + seedData + "," + "Level "+ levelData + ", " + "Explore Data " + "" + exploreData + "," + "Total Explore " + "" + totalTiles + "," + "Enemies Defeated " + "" + totalEnemies + "," +  "Shots Hit " + "" +  enemyData  + "," + "Enemies Remaining " + remainingData + "," +  "Shots Fired " + "" +  accurateData  +"," +  "Time Taken " +"" +  timeData + "," + "Is Explorer " + taxDataE + "," + "Is Acheiver " + taxDataA  + "," + "Is Killer " + taxDataK );
		//System.IO.File.WriteAllText(text, test1 + ", " + test2);
		
	}

	public void save2 ()
	{		
		//System.IO.File.WriteAllText("C:/Users/Liam/testTextfile.txt", test1 + ", " + test2);
		System.IO.File.WriteAllText("Data2.txt","Level Seed "+ "" + seedData + "," + "Level "+ levelData + ", " + "Explore Data " + "" + exploreData + "," + "Total Explore " + "" + totalTiles + "," + "Enemies Defeated " + "" + totalEnemies + "," +  "Shots Hit " + "" +  enemyData  + "," + "Enemies Remaining " + remainingData + "," +  "Shots Fired " + "" +  accurateData  +"," +  "Time Taken " +"" +  timeData + "," + "Is Explorer " + taxDataE + "," + "Is Acheiver " + taxDataA +  "," + "Is Killer " + taxDataK );
		//System.IO.File.WriteAllText(text, test1 + ", " + test2);

	}

	public void save3 ()
	{		
		//System.IO.File.WriteAllText("C:/Users/Liam/testTextfile.txt", test1 + ", " + test2);
		System.IO.File.WriteAllText("Data3.txt","Level Seed "+ "" + seedData + "," + "Level "+ levelData + ", " + "Explore Data " + "" + exploreData + "," + "Total Explore " + "" + totalTiles + "," + "Enemies Defeated " + "" + totalEnemies + "," +  "Shots Hit " + "" +  enemyData  + "," + "Enemies Remaining " + remainingData + "," + "Shots Fired " + "" +  accurateData  +"," +  "Time Taken " +"" +  timeData + "," + "Is Explorer " + taxDataE + "," + "Is Acheiver " + taxDataA +  "," + "Is Killer " + taxDataK );
		//System.IO.File.WriteAllText(text, test1 + ", " + test2);

	}
		
}
