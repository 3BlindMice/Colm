using UnityEngine;
using System.Collections;


// -----------------------------------------------------------------------------
// Program Description: Works with the player's movement throughout the game 
//  Example: if (PlayerJump = 1)
//              {
//               execute jump animation
//              }
// Player Name : Colm 
// Programer: Ray C. Mulligan 
// ------------------------------------------------------------------------------



// Place a required component on the type of controller we are using 

[RequireComponent (typeof(CharacterController))]
public class Movement : MonoBehaviour {

	// Holds the player Transformation 
	private Transform PlayerTransform; 

	// Holds Colm Character controller 
	private CharacterController Controller; 

	// Modifier for the rotation speed of Colm 
	public float RotateSpeed = 200; 

	// Modifier for the movement speed of Colm 
	public float MoveSpeed = 10;  

	// Hold Colm's running Modifier - higher compared to when Colm walks 
	public float RunModifier = 3; 

	// Modifier for the run speed of Colm 
	//public float StrafeSpeed = 5;  
	
	// Set Colm transform to the transform vector 
	public void Awake ()
		
	{
		PlayerTransform = transform;
		Controller = GetComponent <CharacterController> ();
	
	}


	// Use this for initialization
	void Start () 
	{
		// Sets the animation to loop 
		animation.wrapMode = WrapMode.Loop;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Place a call to the movement animation
		Turn (); 
		Walk (); 
		//Strafe ();
	}

	// Function to hold the turn animation 
	private void Turn()
	{
		// Checks if the player pressed the respected button to rotate
		if (Mathf.Abs(Input.GetAxis("Rotate Colm")) > 0)
		{
			// Test the output from the respected keys being pressed for the rotation 
			//	Debug.Log("Rotate: " + Input.GetAxis("Rotate Colm"));
			
			// Set the rotation on the y axis with reference to deltaTime 
			PlayerTransform.Rotate(0, Input.GetAxis("Rotate Colm") * Time.deltaTime * RotateSpeed, 0);
		}
	}

	// Function to hold the walk animation
	private void Walk()
	{
		// Checks if the player pressed the respected button to Colm forward 
		if (Mathf.Abs (Input.GetAxis ("MoveForward")) > 0) 
		{
						// Test the output from the respected keys being pressed for the forward motation  
						//Debug.Log("MoveForward: " + Input.GetAxis("MoveForward"));
			if (Input.GetButton ("Running")) 
			           {
								// calling the run animation 
								animation.CrossFade ("run");
				
								// Sets Colm to move run with reference to the CharacterController 
								// Using SimpleMove - Vector3
								// Determines if Colm is running - * Input.GetAxis("Run Colm");
								// Sets the movement with - * RunModifier in reference to walk so Colm can run faster than he walks 
								Controller.SimpleMove (PlayerTransform.TransformDirection (Vector3.forward) * Input.GetAxis ("MoveForward") * MoveSpeed * RunModifier); 
						}

			else 
			      {
						// Walk animation
						// Fades animation over a period of time seconds
						animation.CrossFade ("walk");
			
						// Sets Colm to move foward with reference to the CharacterController 
						// Using SimpleMove - Vector3
						// Determines if Colm is moving forward or backwards with - * Input.GetAxis("MoveForward");
						// Sets the movement with - * MoveSpeed
						Controller.SimpleMove (PlayerTransform.TransformDirection (Vector3.forward) * Input.GetAxis ("MoveForward") * MoveSpeed); 
			     }
	   } 
		           else 
						{
							// Calls for Colm idle animation if he is not walking 
							animation.CrossFade ("idle");
						}
	}
	
		//*** NOT ENOUGH TIME TO IMPLEMENT STRAFE ANIMATION**//
		//private void Strafe()
		//{
			// Checks if the player pressed the respected button to Colm forward 
		  //if (Mathf.Abs(Input.GetAxis("Strafe")) > 0)
			//{
				// Test the output from the respected keys being pressed for the forward motation  
				//Debug.Log("Strafe: " + Input.GetAxis("MoveForward"));
				
				// Run animation
				// Fades animation over a period of time seconds
				//animation.CrossFade("run");
				
				// Sets Colm to move foward with reference to the CharacterController 
				// Using SimpleMove - Vector3
	// Determines if Colm is Strafing with - * Input.GetAxis("Strafe");
				// Sets the movement with - * MoveSpeed
	//Controller.SimpleMove(PlayerTransform.TransformDirection(Vector3.right) * Input.GetAxis("Strafe") * StrafeSpeed); 
			//}
			//else 
				// Calls for Colm idle animation if he is not running
				//animation.CrossFade("idle");
	//}
}
