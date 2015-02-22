using UnityEngine; 
using System.Collections; 

public class BackgroundMove : MonoBehaviour { 
	
	public float speed; 
	public float moveTime; 
	float moveTimeTimer; 
	bool isFirstTime;
	
	bool moveDirection; //true - right move, false - left move 
	
	// Use this for initialization 
	void Start () { 
		moveDirection = true; 
		moveTimeTimer = moveTime; 
		isFirstTime = true;
	} 
	
	// Update is called once per frame 
	void Update () { 
		checkDirection(); 
		moveBg(); 
	} 
	
	public void checkDirection() 
	{ 
		if (Input.GetKeyDown (KeyCode.Space))
			changeMoveDirection(); 

		if(IsTouched())
			changeMoveDirection(); 

	} 

	public bool IsTouched() {
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
			
		}
		if (fingerCount > 0)
						return true;
				else 
						return false;
	}


	public void changeMoveDirection() 
	{ 
		if (isFirstTime) {
			isFirstTime = false;
			moveTime = moveTime*2;
				}

		moveDirection = !moveDirection; 
	} 
	
	public void moveBg() 
	{ 
		if(moveDirection) 
		{  
			transform.Translate(Vector3.left*Time.deltaTime*speed, Space.World); 
		} 
		else 
		{  
			transform.Translate(Vector3.right*Time.deltaTime*speed, Space.World); 
		} 
	} 
} 
