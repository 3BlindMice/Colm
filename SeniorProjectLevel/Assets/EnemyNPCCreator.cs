using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyNPCCreator : MonoBehaviour {
	public enum State{
		Idle,
		Initialize,
		Setup,
		SpawnNpc
		
	}
	
	public GameObject[] npcPrefabs;  // an array to hold all of the prefabs for the npcs i want to use in an area
	public GameObject[] spawnPoints; // an array of spawn points
	
	public State state;  //variable that holds the current state
	
	void Awake(){
		state = EnemyNPCCreator.State.Initialize;
	}
	
	// Use this for initialization
	IEnumerator Start () {
		while(true){
			switch(state){
			case State.Initialize:
				Initialize();
				break;
			case State.Setup:
				Setup();
				break;
			case State.SpawnNpc:
				SpawnNPC();
				break;
			}
			yield return 0;
		}
		
	}
	
	private void Initialize(){
		Debug.LogWarning("The Initialize Function");
		if(!CheckNPC())
			return;
		if(!CheckSpawnPoints())
			return;
		state= State.Setup;
	}
	
	private void Setup(){
		Debug.LogWarning("The Setup Function");
		state=State.SpawnNpc;
	}
	
	private void SpawnNPC(){
		Debug.LogWarning("Spawn NPC");
		GameObject[] tgos = OpenSpawnPoints();
		for(int cnt=0; cnt< tgos.Length; cnt++){
			GameObject tgo = Instantiate (npcPrefabs[Random.Range(0, npcPrefabs.Length)],
			                              tgos[cnt].transform.position,
			                              Quaternion.identity) as GameObject;
			tgo.transform.parent=tgos[cnt].transform;
		}
		state=State.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// check for mobs to spawn and spawn points
	private bool CheckNPC(){
		if(npcPrefabs.Length>0){
			return true;
		}
		else 
			return false;
		
		
	}
	private bool CheckSpawnPoints(){
		if(spawnPoints.Length>0){
			return true;
		}
		else
			return false;
	}
	
	private GameObject[] OpenSpawnPoints(){
		List<GameObject> tgos = new List<GameObject>();
		
		for(int cnt=0; cnt <spawnPoints.Length; cnt++){
			if(spawnPoints[cnt].transform.childCount==0){
				Debug.LogWarning("OPEN SPAWN Points");
				tgos.Add(spawnPoints[cnt]);
			}
			
			
		}
		return tgos.ToArray();
	}
}
