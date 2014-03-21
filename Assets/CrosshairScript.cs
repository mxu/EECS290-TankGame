// DIS SHIT CRAY
// DONT EVEN WARGARBLE ALL OVER IT
using UnityEngine;
using System.Collections;

public class CrosshairScript : MonoBehaviour {

	GameObject shootSpot;
	GameObject turret;
	Vector3 initialPos;

	// Use this for initialization
	void Start () {
		shootSpot = GameObject.Find("ShootSpot");
		turret = GameObject.Find ("PlayerTurret");
		initialPos = this.transform.position - turret.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.localPosition = (shootSpot.transform.position - turret.transform.position) * 2;
		this.transform.localRotation = shootSpot.transform.localRotation;
	}
}
