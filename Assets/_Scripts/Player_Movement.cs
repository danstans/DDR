using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	public static bool arrowHitSuccess;
	private int playerX, playerY;
	private GameObject cam;
	private const int camDistance = -7;
	private const int camXoffset = -2;

	// Use this for initialization
	void Start() 
	{
		playerX = WorldCreation.playerX;
		playerY = WorldCreation.playerY;
		cam = GameObject.Find ("Camera");
		cam.transform.position = new Vector3(this.transform.position.x + camXoffset, this.transform.position.y, camDistance); 
		arrowHitSuccess = false;
	}

	// Update is called once per frame
	void Update () 
	{
		//check if only one bool is true
		if ((Input.GetKey (KeyCode.A) ? 1 : 0) + (Input.GetKey (KeyCode.W) ? 1 : 0) + (Input.GetKey (KeyCode.S) ? 1 : 0) + (Input.GetKey (KeyCode.D) ? 1 : 0) == 1) {
			if ((Input.GetKey (KeyCode.A) && Input.GetKeyDown (KeyCode.Space)) || (Input.GetKeyDown (KeyCode.A) && Input.GetKey (KeyCode.Space))) {	
				if (checkCanMove ("Left")) {
					transform.Translate (new Vector3 (-1, 0, 0));
					cam.transform.position = new Vector3 (this.transform.position.x + camXoffset, this.transform.position.y, camDistance); 
				}
			} else if ((Input.GetKey (KeyCode.S) && Input.GetKeyDown (KeyCode.Space)) || (Input.GetKeyDown (KeyCode.S) && Input.GetKey (KeyCode.Space))) {
				if (checkCanMove ("Down")) {
					transform.Translate (new Vector3 (0, -1, 0));
					cam.transform.position = new Vector3 (this.transform.position.x + camXoffset, this.transform.position.y, camDistance); 
				}
			} else if ((Input.GetKey (KeyCode.D) && Input.GetKeyDown (KeyCode.Space)) || (Input.GetKeyDown (KeyCode.D) && Input.GetKey (KeyCode.Space))) {
				if (checkCanMove ("Right")) {
					transform.Translate (new Vector3 (1, 0, 0));
					cam.transform.position = new Vector3 (this.transform.position.x + camXoffset, this.transform.position.y, camDistance); 
				}
			} else if ((Input.GetKey (KeyCode.W) && Input.GetKeyDown (KeyCode.Space)) || (Input.GetKeyDown (KeyCode.W) && Input.GetKey (KeyCode.Space))) {
				if (checkCanMove ("Up")) {
					transform.Translate (new Vector3 (0, 1, 0));
					cam.transform.position = new Vector3 (this.transform.position.x + camXoffset, this.transform.position.y, camDistance); 
				}
			}
		}

		arrowHitSuccess = false;
	}
	
	bool checkCanMove(string l)
	{
		if (arrowHitSuccess) {
			if (l.Equals ("Left")) {
				if (!WorldCreation.mazeMap [playerY] [playerX - 1].Equals ('B')) {
					--playerX;
					return true;
				}
			} else if (l.Equals ("Down")) {
				if (!WorldCreation.mazeMap [playerY + 1] [playerX].Equals ('B')) {
					++playerY;
					return true;
				}
			} else if (l.Equals ("Right")) {
				if (!WorldCreation.mazeMap [playerY] [playerX + 1].Equals ('B')) { 
					++playerX;
					return true;
				}
			} else if (l.Equals ("Up")) {
				if (!WorldCreation.mazeMap [playerY - 1] [playerX].Equals ('B')) {
					--playerY;
					return true;
				}
			}
		}
		return false;
	}
}
