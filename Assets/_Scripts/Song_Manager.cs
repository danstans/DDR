using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Song_Manager : MonoBehaviour {

	public const float delayTime = 4.63f;

	// Use this for initialization
	void Start () {
		AudioSource audio = GetComponent<AudioSource> ();
		audio.PlayDelayed (delayTime);
	}

}
