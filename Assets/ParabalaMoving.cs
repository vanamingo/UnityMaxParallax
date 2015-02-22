using UnityEngine;
using System.Collections;

public class ParabalaMoving : MonoBehaviour {

	public float LeftX;
	public float RightX;
	public float Speed;

	private Vector3 currentDirrection;
	private bool isToRightDirection = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		CheckDirrection ();
		SetCurrentDirretion ();
		transform.position = Vector3.Lerp (transform.position, currentDirrection, Speed *  Time.deltaTime);

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
		var targetX = (currentDirrection.x + Speed) * (isToRightDirection ? 1 : -1) ;
		var targetY = targetX * targetX * 0.1f;
		
		currentDirrection = new Vector3(targetX,targetY);
	}

}
