using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour {


	public static int score, currentStreak;
	public static string perfection;
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		score = 0;
		currentStreak = 0;
		perfection = "       ";
	}
	
	// Update is called once per frame
	void Update () {
		text.text = perfection + "    " + currentStreak + "    " + score;
		if (currentStreak > Scoreboard_Manager.bestStreak)
			Scoreboard_Manager.bestStreak = currentStreak;
	}
}
