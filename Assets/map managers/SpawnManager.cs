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


	// Use this for initialization
	void Start () {

		//Array created for easy organizing and calling of spawn points.
		GameObject[] arrayOfSpawnPoints= {cornerSpawn, cornerSpawnLeft, cornerSpawnRight};
		GameObject[] arrayOfEnemySpawnPoints = {enemyCornerSpawn, enemyCornerSpawnRight, enemyCornerSpawnLeft};

		GameObject.Instantiate(tank, new Vector3(cornerSpawn.transform.position.x, 2f, cornerSpawn.transform.position.z), Quaternion.identity);

		//Do this again, but for tanks that aren't the player, meaning we have to make sure they don't have a camera attached to them.
		
	}
	
}
