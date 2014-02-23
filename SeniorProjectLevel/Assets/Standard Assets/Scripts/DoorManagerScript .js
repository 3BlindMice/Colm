#pragma strict

private var doorIsOpen : boolean = false;  //switch to check if door is currently open
private var doorTimer : float = 0.0; // Time to count time before door is closed

var doorOpenTime : float = 3.0;	// Time that the door stays opne
var doorOpenSound : AudioClip; // For assigning sound clip (drag and drop in the Inspector)
var doorShutSound : AudioClip; // For assigning sound clip (drag and drop in the Inspector)



function Start () 
{
	doorTimer = 0.0;
}

function Update () 
{
	if (doorIsOpen)
	{
		doorTimer = doorTimer + Time.deltaTime;
		if (doorTimer > doorOpenTime)
		{
			Door(doorShutSound, false, "doorshut");
			doorTimer = 0.0;
		}
	}
}

function DoorCheck()
{
	if(!doorIsOpen)
	{
		Door(doorOpenSound, true, "dooropen");
	}
}

function Door(aClip:AudioClip, openCheck:boolean, animName:String)
{
	doorIsOpen = openCheck;
	audio.PlayOneShot(aClip);
	transform.parent.animation.Play(animName);
}