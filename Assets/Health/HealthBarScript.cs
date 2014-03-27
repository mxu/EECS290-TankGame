using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public Texture[] healthBars;
	GameObject player;
	
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	// Update is called once per frame
	void Update () {
		this.guiTexture.texture = healthBars[player.GetComponentInChildren<TankController>().health];
	}
}
