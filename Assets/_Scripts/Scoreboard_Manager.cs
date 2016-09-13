using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Scoreboard_Manager : MonoBehaviour {
	
	public static int perfectCount, goodCount, badCount, doThisBool, bestStreak;
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		perfectCount = 0;
		goodCount = 0;
		badCount = 0;
		bestStreak = 0;
		doThisBool = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (doThisBool == 1) {
			text.text = "Perfect: " + perfectCount + "\nGood: " + goodCount + "\nBad: " + badCount + "\nBest Streak: " + bestStreak +
				"\nGrade: " + Average(); 
		}
	}

	char Average()
	{
		double gradePoint = (((perfectCount * 1) + (goodCount * .67) + (badCount * 0)) / (perfectCount + goodCount + badCount));
		if (gradePoint > .90)
			return 'A';
		else if (gradePoint > .80)
			return 'B';
		else if (gradePoint > .70)
			return 'C';
		else if (gradePoint > .60)
			return 'D';
		else
			return 'F';
	}
}
