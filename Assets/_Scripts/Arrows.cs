using UnityEngine;
using System.Collections;
using System;
using System.IO;

public class Arrows : MonoBehaviour
{

	private float startTime, timeElapsed;
	private GameObject leftArrow, downArrow, upArrow, rightArrow;
	public GameObject leftPrefab, downPrefab, upPrefab, rightPrefab;
	private string[] beatMap = new string[200];
	private int counter, number, frameNumber, stringCounter, sizeOfString, charCounter = 0;
	//private float firstNumber = 20.5238f;
	private TextAsset textFile;
	public static int perfectCount, goodCount, badCount;
	public int SPAWN_HEIGHT;
	private float beatTime = 59.5238f;


	// Use this for initialization
	void Start ()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
		perfectCount = 0;
		goodCount = 0;
		badCount = 0;

		SPAWN_HEIGHT = 10;

		textFile = (TextAsset)Resources.Load ("Sample");
		
		StringReader reader = new StringReader (textFile.text);
		string text;
		do {
			text = reader.ReadLine ();
			beatMap [counter++] = text;
		} while (text != null);
		sizeOfString = beatMap [stringCounter].Length;

		leftArrow = transform.FindChild ("base_left").gameObject;
		downArrow = transform.FindChild ("base_down").gameObject;
		upArrow = transform.FindChild ("base_up").gameObject;
		rightArrow = transform.FindChild ("base_right").gameObject;

		Arrow_Movement.speed = 6.5f;
		startTime = Time.time + Song_Manager.delayTime - (SPAWN_HEIGHT / Arrow_Movement.speed);
		Spawn (beatMap [stringCounter] [charCounter++]);

	}
	
	// Update is called once per frame
	void Update ()
	{
		timeElapsed = (Time.time - startTime) * 1000;
		if (timeElapsed > beatTime && !beatMap [stringCounter].Equals ("%")) {
			Spawn (beatMap [stringCounter] [charCounter++]);
			if (charCounter == sizeOfString) {
				charCounter = 0;
				stringCounter++;
				sizeOfString = beatMap [stringCounter].Length;
			}
			startTime += beatTime / 1000;
		} else if (stringCounter + 3 == counter) {
			Scoreboard_Manager.perfectCount = perfectCount;
			Scoreboard_Manager.goodCount = goodCount;
			Scoreboard_Manager.badCount = badCount;
			Scoreboard_Manager.doThisBool = 1;
		}
	}

	void Spawn (char l)
	{
		GameObject g;
		switch (l) {

		case 'L':
			g = (GameObject)Instantiate (leftPrefab, new Vector3 (leftArrow.transform.localPosition.x, leftArrow.transform.localPosition.y + SPAWN_HEIGHT, leftArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print (("Left "));
			g.transform.SetParent (transform, false);
			break;

		case 'R':
			g = (GameObject)Instantiate (rightPrefab, new Vector3 (rightArrow.transform.localPosition.x, rightArrow.transform.localPosition.y + SPAWN_HEIGHT, rightArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print (("Right") );
			g.transform.SetParent (transform, false);
			break;

		case 'U':
			g = (GameObject)Instantiate (upPrefab, new Vector3 (upArrow.transform.localPosition.x, upArrow.transform.localPosition.y + SPAWN_HEIGHT, upArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print (timeElapsed);
			g.transform.SetParent (transform, false);
			break;

		case 'D':
			g = (GameObject)Instantiate (downPrefab, new Vector3 (downArrow.transform.localPosition.x, downArrow.transform.localPosition.y + SPAWN_HEIGHT, downArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print(("Down"));
			g.transform.SetParent (transform, false);
			break;

		case 'Z':
			g = (GameObject)Instantiate (downPrefab, new Vector3 (downArrow.transform.localPosition.x, downArrow.transform.localPosition.y + SPAWN_HEIGHT, downArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			g.transform.SetParent (transform, false);

			g = (GameObject)Instantiate (upPrefab, new Vector3 (upArrow.transform.localPosition.x, upArrow.transform.localPosition.y + SPAWN_HEIGHT, upArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print(("Down and Up"));
			g.transform.SetParent (transform, false);
			break;

		case 'K':
			g = (GameObject)Instantiate (upPrefab, new Vector3 (upArrow.transform.localPosition.x, upArrow.transform.localPosition.y + SPAWN_HEIGHT, upArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			g.transform.SetParent (transform, false);

			g = (GameObject)Instantiate (leftPrefab, new Vector3 (leftArrow.transform.localPosition.x, leftArrow.transform.localPosition.y + SPAWN_HEIGHT, leftArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print(("Up and Left"));
			g.transform.SetParent (transform, false);
			break;

		case 'C':
			g = (GameObject)Instantiate (upPrefab, new Vector3 (upArrow.transform.localPosition.x, upArrow.transform.localPosition.y + SPAWN_HEIGHT, upArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			g.transform.SetParent (transform, false);

			g = (GameObject)Instantiate (rightPrefab, new Vector3 (rightArrow.transform.localPosition.x, rightArrow.transform.localPosition.y + SPAWN_HEIGHT, rightArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print(("Up and Right"));
			g.transform.SetParent (transform, false);
			break;

		case 'V':
			g = (GameObject)Instantiate (downPrefab, new Vector3 (downArrow.transform.localPosition.x, downArrow.transform.localPosition.y + SPAWN_HEIGHT, downArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			g.transform.SetParent (transform, false);

			g = (GameObject)Instantiate (leftPrefab, new Vector3 (leftArrow.transform.localPosition.x, leftArrow.transform.localPosition.y + SPAWN_HEIGHT, leftArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print(("Down and Left"));
			g.transform.SetParent (transform, false);
			break;

		case 'N':
			g = (GameObject)Instantiate (downPrefab, new Vector3 (downArrow.transform.localPosition.x, downArrow.transform.localPosition.y + SPAWN_HEIGHT, downArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			g.transform.SetParent (transform, false);

			g = (GameObject)Instantiate (rightPrefab, new Vector3 (rightArrow.transform.localPosition.x, rightArrow.transform.localPosition.y + SPAWN_HEIGHT, rightArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print(("Down and Right"));
			g.transform.SetParent (transform, false);
			break;

		case 'B':
			g = (GameObject)Instantiate (leftPrefab, new Vector3 (leftArrow.transform.localPosition.x, leftArrow.transform.localPosition.y + SPAWN_HEIGHT, leftArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			g.transform.SetParent (transform, false);

			g = (GameObject)Instantiate (rightPrefab, new Vector3 (rightArrow.transform.localPosition.x, rightArrow.transform.localPosition.y + SPAWN_HEIGHT, rightArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print(("Left and Right"));
			g.transform.SetParent (transform, false);
			break;

		case 'M':
			g = (GameObject)Instantiate (upPrefab, new Vector3 (upArrow.transform.localPosition.x, upArrow.transform.localPosition.y + SPAWN_HEIGHT, upArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			g.transform.SetParent (transform, false);

			g = (GameObject)Instantiate (leftPrefab, new Vector3 (leftArrow.transform.localPosition.x, leftArrow.transform.localPosition.y + SPAWN_HEIGHT, leftArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			g.transform.SetParent (transform, false);
		
			g = (GameObject)Instantiate (rightPrefab, new Vector3 (rightArrow.transform.localPosition.x, rightArrow.transform.localPosition.y + SPAWN_HEIGHT, rightArrow.transform.localPosition.z), new Quaternion (0f, 0f, 0f, 0f));
			//print(("Up and Left and Right"));
			g.transform.SetParent (transform, false);
			break;
		}
		return;
	}
		
}
	