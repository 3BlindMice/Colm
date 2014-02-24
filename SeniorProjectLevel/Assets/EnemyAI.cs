using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public int movementSpeed;
	public int rotationSpeed;
	int maxDistance;
	public int AggroDistance;
	
	public Transform target;
	private Transform myTransform;
	
	void Awake(){
		myTransform=transform;
		
	}
	
	
	// Use this for initialization
	void Start () {
		GameObject go=GameObject.FindGameObjectWithTag("Colm ");
		target=go.transform;
		maxDistance=2;
		AggroDistance=10;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(target.position,myTransform.position)<AggroDistance){
			myTransform.rotation=Quaternion.Slerp(myTransform.rotation,Quaternion.LookRotation(target.position-myTransform.position),rotationSpeed*Time.deltaTime);
			Debug.DrawLine(target.position,myTransform.position,Color.yellow);
			if(Vector3.Distance (target.position,myTransform.position)>maxDistance)
			{
				myTransform.position+=myTransform.forward*movementSpeed*Time.deltaTime;
			}
			
		}
	}
}