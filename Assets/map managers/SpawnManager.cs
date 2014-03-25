using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	//Good side
	public GameObject cornerSpawn;
	public GameObject cornerSpawnRight;
	public GameObject cornerSpawnLeft;

	//Bad side
	public GameObject enemyCornerSpawn;
	public GameObject enemyCornerSpawnRight;
	public GameObject enemyCornerSpawnLeft;

	//Tank prefab
	public GameObject tank;
	public GameObject allyTank;
	public GameObject enemyTank;


	// Use this for initialization
	void Start () {
		//Create the main player
		GameObject.Instantiate(tank, new Vector3(cornerSpawn.transform.position.x, 2f, cornerSpawn.transform.position.z), Quaternion.Euler(new Vector3(0, -54, 0)));

		//Create the allies.
		GameObject[] allySpawn = new GameObject[]{cornerSpawnRight, cornerSpawnLeft};
		for(int index = 0; index < 2; index++){
			GameObject.Instantiate(allyTank, new Vector3(allySpawn[index].transform.position.x, 2f, allySpawn[index].transform.position.z), Quaternion.Euler(new Vector3(0, -50,0)));
		}

		//Spawn enemies.
		GameObject[] enemySpawn = new GameObject[]{enemyCornerSpawn, enemyCornerSpawnRight, enemyCornerSpawnLeft};
		for(int index = 0; index < 3; index++){
			GameObject.Instantiate(enemyTank, new Vector3(enemySpawn[index].transform.position.x, 2f, enemySpawn[index].transform.position.z), Quaternion.Euler(new Vector3(0,140,0)));
		}

		
	}
	
}
