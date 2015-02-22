using UnityEngine;
using System.Collections;

public class LevelOneSpawns : MonoBehaviour
{
	//variables for spawning hazards
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public Vector3 spawnValues2;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	//main method that starts automatically
	void Start ()
	{
		//begins SpawnWaves IEnumerator
		StartCoroutine (SpawnWaves ());
	}

	//method for spawning enemies and hazards
	IEnumerator SpawnWaves ()
	{
		//time before the first wave starts
		yield return new WaitForSeconds (startWait);
		while (true) 
		{
			//spawns an emeny until hazardCount is reached
			for (int i = 0; i < hazardCount; i++) 
			{
				/*
				// original code for spawning hazards
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				*/

				//active spawn
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				

				//second spawn command
				GameObject hazard2 = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition2 = new Vector3 (Random.Range (-spawnValues2.x, spawnValues2.x), spawnValues2.y, spawnValues2.z);
				Quaternion spawnRotation2 = Quaternion.identity;
				Instantiate (hazard2, spawnPosition2, spawnRotation2);

				
				//wait time between each spawn
				yield return new WaitForSeconds (spawnWait);
			}
			//time between each wave
			yield return new WaitForSeconds (waveWait);
		}
	}
	
}
