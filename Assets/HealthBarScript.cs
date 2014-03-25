using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public Texture[] healthBars;
	GameObject player;
	
	void Start () {
		player = GameObject.Find("Player1");
	}
	// Update is called once per frame
	void Update () {
		this.guiTexture.texture = healthBars[player.GetComponentInChildren<TankController>().health];
	}
}
