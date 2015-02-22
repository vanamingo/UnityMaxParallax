using UnityEngine;
using System.Collections;

public class HelloWorld : MonoBehaviour {

	private Vector3 leftConer = new Vector3(-12.0f,0,-5f);
	private Vector3 rightConer = new Vector3(12.0f,0,-5f);
	private Vector3 currentDirrection;
	private bool isToRightDirection = true;

	// Use this for initialization
	void Start () {
		SetCurrentDirretion ();
	}

	private void CheckDirrection()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			isToRightDirection = !isToRightDirection;
			SetCurrentDirretion();
		}
	}

	private void SetCurrentDirretion()
	{
		currentDirrection = isToRightDirection ? rightConer : leftConer;
	}


	// Update is called once per frame
	void Update () {
		//Vector3 temp = new Vector3(2.0f,0,-5f);
		CheckDirrection ();
		transform.position = Vector3.Lerp (transform.position, currentDirrection, /*0.5f **/ 0.2f *  Time.deltaTime);
		//transform.Translate (2.0f, 0, -5f);

		//transform.position = temp;
	}
}
