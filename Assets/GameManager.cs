using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public delegate void GameEvent();

	//Keeps track of number of enemies
	private static int numberOfEnemies;
	//Keeps track of number of allies
	private static int numberOfAllies;

	public void Start() {
		numberOfEnemies = 3;
		numberOfAllies = 3;
	}

	//Called when enemy is destroyed.
	public static void DecrementEnemyCount() {
		if(numberOfEnemies>1){
			numberOfEnemies--;
		}
		else if (numberOfEnemies == 0){
			//Call gameover screen
		}

	}

	//Called when ally is destroyed
	public static void DecrementAllyCount() {
		if(numberOfAllies >1){
			numberOfAllies--;
		}
		else if (numberOfAllies == 0){
			//Call gameover screen
		}
	}
	



}
