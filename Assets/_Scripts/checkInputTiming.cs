using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class checkInputTiming : MonoBehaviour {
	/*
	 * uses a queue to get incoming arrows and then figure out the 
	 * distance between them and the base arrow
	 * depending on distance determine the state
	 */


	Queue<GameObject> arrowQueue;
	KeyCode arrowKey;

	// Use this for initialization
	void Start () {
		arrowQueue = new Queue<GameObject> ();

		//determine what input needs to be checked
		//depending on what arrow this object is
		switch (gameObject.tag) {
		case "spawn_arrow_left":
			arrowKey = KeyCode.A;
			break;

		case "spawn_arrow_down":
			arrowKey = KeyCode.S;
			break;

		case "spawn_arrow_up":
			arrowKey = KeyCode.W;
			break;

		case "spawn_arrow_right":
			arrowKey = KeyCode.D;
			break;
		}
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (arrowQueue.Count > 0) {
			GameObject g = arrowQueue.Peek ();
			if (Mathf.Abs (g.transform.localPosition.y) < (0.1 * Arrow_Movement.speed/4) && Input.GetKeyDown (arrowKey)) {
				Score_Manager.score += 200;
				Score_Manager.perfection = "Perfect";
				Score_Manager.currentStreak++;
				Arrows.perfectCount++;
				Player_Movement.arrowHitSuccess = true;
				arrowQueue.Dequeue ();
				Destroy (g);
			} else if (Mathf.Abs (g.transform.localPosition.y) < (0.2 * Arrow_Movement.speed/4) && Input.GetKeyDown (arrowKey)) {
				Score_Manager.score += 100;
				Score_Manager.perfection = "Good";
				Score_Manager.currentStreak++;
				Arrows.goodCount++;
				Player_Movement.arrowHitSuccess = true;
				arrowQueue.Dequeue ();
				Destroy (g);
			} else if (Mathf.Abs (g.transform.localPosition.y) < (0.3 * Arrow_Movement.speed/4) && Input.GetKeyDown (arrowKey)) {
				Score_Manager.score += 0;
				Score_Manager.perfection = "Bad";
				Score_Manager.currentStreak = 0;
				Arrows.badCount++;
				arrowQueue.Dequeue ();
				Destroy (g);
			} else if (g.transform.localPosition.y < -1) {
				Score_Manager.perfection = "Miss";
				Score_Manager.currentStreak = 0;
				Arrows.badCount++;
				arrowQueue.Dequeue ();
				Destroy (g);
			}
		}
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		arrowQueue.Enqueue (other.gameObject);
	}

}
