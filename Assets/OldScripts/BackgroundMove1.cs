using UnityEngine; 
using System.Collections; 

public class BackgroundMove1 : MonoBehaviour { 
	
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
		moveTimeTimer -= Time.deltaTime; 
		if(moveTimeTimer<=0) 
		{ 
			moveTimeTimer = moveTime; 
			changeMoveDirection(); 
		} 
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
