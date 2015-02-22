using UnityEngine;
using System.Collections;

public class LerpedParallaxLayer : MonoBehaviour {

	public float LeftX;
	public float RightX;
	public float Speed; 

	private Vector3 leftConer;
	private Vector3 rightConer;
	private Vector3 currentDirrection;
	private bool isToRightDirection = true;


	// Use this for initialization
	void Start () {
		leftConer = new Vector3(LeftX,transform.position.y - 1.5f,transform.position.z);
		rightConer = new Vector3(RightX,transform.position.y + 1.5f,transform.position.z);

		SetCurrentDirretion ();
	}
	
	private void CheckDirrection()
	{
		if (IsTouched() || IsSpacePressed()) {
			isToRightDirection = !isToRightDirection;
			SetCurrentDirretion();
		}
	}

	public bool IsTouched() {
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Ended)
				return true;
			
		}
		return false;
	}

	public bool IsSpacePressed()
	{
		return Input.GetKeyDown (KeyCode.Space);
	}
	
	private void SetCurrentDirretion()
	{
		currentDirrection = isToRightDirection ? rightConer : leftConer;
		//currentDirrection = new Vector3(currentDirrection.x,0.1f * transform.position.x * transform.position.x,transform.position.z);
		//currentDirrection = new Vector3(currentDirrection.x,0.1f * transform.position.x * transform.position.x,transform.position.z);
	}
	
	
	// Update is called once per frame
	void Update () {
		//Vector3 temp = new Vector3(2.0f,0,-5f);
		CheckDirrection ();
		transform.position = Vector3.Lerp (transform.position, currentDirrection, Speed *  Time.deltaTime);
		SetCurrentDirretion ();
		//transform.Translate (2.0f, 0, -5f);
		
		//transform.position = temp;
	}
}
