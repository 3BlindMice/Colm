#pragma strict

private var currentDoor : GameObject; // Reference to the current door

function Start () {

}

function Update () {

}

function OnControllerColliderHit(hit : ControllerColliderHit)  //Unity built in function to check collsision
															   // ControllerColliderHit is a Unity Class that														   // stores information about any collision
{
	if (hit.gameObject.tag == "playerDoor")
	{
		currentDoor = hit.gameObject;
		currentDoor.SendMessage("DoorCheck");
	}
	
}