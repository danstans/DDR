using UnityEngine;
using System.Collections;

public class Arrow_Movement : MonoBehaviour {

	public static float speed;
	// Use this for initialization
	void Start()
	{

	}

	void Update()
	{

		float step = speed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards (transform.position, new Vector3 (transform.position.x, 2f, transform.position.z), step);
		transform.localPosition = (new Vector3 (transform.localPosition.x, transform.localPosition.y-step, transform.localPosition.z));
	}
}
