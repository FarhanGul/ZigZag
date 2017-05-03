using UnityEngine;
using System.Collections;

//TODO: Use Object Pooling to reduce load
public class ProceduralGeneration : MonoBehaviour {

	//Max distance from center allowed
	public float maxOffset;
	//First block Location
	public Transform start;
	public GameObject blockPreFab;
	public GameObject pickUpPrefab;
	[Range(0,1)]
	public float pickupSpawnProbablity;
	// Number of blocks at any instant
	public static int n; 
	// Reference to current block
	private GameObject block;
	// Current offset from center
	private int offset;

	// Use this for initialization
	void Start () {
		block = Instantiate (blockPreFab,start.position,Quaternion.identity) as GameObject;
		n = 1;
		offset = 0;
	}

	// Update is called once per frame
	void Update () {

		while (n < 50) {
			//Generate random events
			int randomDirection = Random.Range (0,2);
			bool spawnPickup = (Random.Range (0f, 1f) < pickupSpawnProbablity) ? true : false;
			// Check if blocks are going out of bounds
			if(offset == maxOffset) 
				randomDirection = 0;
			else if(offset == -maxOffset)
				randomDirection = 1;
			Vector3 newPos = block.transform.position;
			if( randomDirection == 1){		
				newPos.x++;
				offset++;
			}
			else{
				newPos = block.transform.position;
				newPos.z++;
				offset--;
			}
			block = Instantiate(blockPreFab,newPos,Quaternion.identity) as GameObject;
			n++;
			if(spawnPickup)
			{
				Vector3 pos = block.transform.position + Vector3.up * 1.5f;
				Debug.DrawRay (pos, Vector3.up * 100f, Color.red, 1000f);
				GameObject pickup = Instantiate (pickUpPrefab, pos ,Quaternion.Euler(90f,0f,0f)) as GameObject;
				pickup.transform.SetParent (block.transform);
			}
		}
	}
}
