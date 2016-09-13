using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class WorldCreation : MonoBehaviour {
	
	public GameObject B_Brick, P_Brick, AST_Brick, coin, Player_Object;
	public static string[] mazeMap = new string[200];
	public static int playerX, playerY;
	private int counter, number, stringCounter, sizeOfString, charCounter = 0;
	private TextAsset textFile;

	// Use this for initialization
	void Start ()
	{
		
		textFile = (TextAsset)Resources.Load ("Maze");
		StringReader reader = new StringReader (textFile.text);
		string text;
		do
		{
			text = reader.ReadLine();
			mazeMap[counter++] = text;
		} while (text != null);
		sizeOfString = mazeMap [0].Length;

		while(!mazeMap[stringCounter].Equals("%")) {
			Spawn (mazeMap [stringCounter] [charCounter], charCounter , stringCounter);
			if(mazeMap[stringCounter][charCounter].Equals('S')) {
				playerY = stringCounter;
				playerX = charCounter;
			}
			if (++charCounter == sizeOfString) {
				charCounter = 0;
				stringCounter++;
			}
		} 

	}




	void Spawn(char l, int xCord, int yCord)
	{
		GameObject g;
		if (l.Equals ('B')) {
			g = (GameObject) Instantiate (B_Brick, new Vector3 (xCord + .5f, -yCord - .5f, 0f), Quaternion.Euler (90, 0, 0));
			g.transform.SetParent (this.transform);
		} else if (l.Equals ('*')) {
			g = (GameObject) Instantiate (AST_Brick, new Vector3 (xCord + .5f, -yCord - .5f, 0f), Quaternion.Euler (90, 0, 0));
			g.transform.SetParent (this.transform);
		}
		else if (l.Equals ('C')) {
			g = (GameObject) Instantiate (AST_Brick, new Vector3 (xCord+.5f, -yCord-.5f, 0f), Quaternion.Euler(90,0,0));
			g.transform.SetParent(this.transform);
			g = (GameObject) Instantiate (coin, new Vector3 (xCord+.5f, -yCord-.5f, -0.25f), Quaternion.Euler(90,0,0));
			g.transform.SetParent(this.transform);
		}
		else if (l.Equals('S')){
			g = (GameObject) Instantiate (AST_Brick, new Vector3 (xCord+.5f, -yCord-.5f, 0f), Quaternion.Euler(90,0,0));
			g.transform.SetParent(this.transform);
			g = (GameObject) Instantiate (Player_Object, new Vector3 (xCord+.5f, -yCord-.5f, -0.3f), Player_Object.transform.rotation);
			g.transform.SetParent(this.transform);
		}
		return;
	}

	void OnTriggerEnter(Collider other)
	{
		Destroy (other.gameObject);

	}

}
