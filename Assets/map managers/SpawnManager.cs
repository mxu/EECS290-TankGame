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


	// Use this for initialization
	void Start () {

		//Array created for easy organizing and calling of spawn points.
		GameObject[] arrayOfSpawnPoints= {cornerSpawn, cornerSpawnLeft, cornerSpawnRight};
		GameObject[] arrayOfEnemySpawnPoints = {enemyCornerSpawn, enemyCornerSpawnRight, enemyCornerSpawnLeft};

		
	}
	
}
