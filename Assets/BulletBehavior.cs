using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	public ParticleSystem emit;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnCollisionEnter(){
		this.Explode();
		emit.transform.parent = null;
		emit.emissionRate = 0;
		emit.GetComponent<TimedObjectDestroy>().initiated = true;
		Destroy(this.gameObject);
	}
	
	public void OnTriggerEnter(){
		this.Explode();
		emit.transform.parent = null;
		emit.emissionRate = 0;
		emit.GetComponent<TimedObjectDestroy>().initiated = true;
		Destroy(this.gameObject);
	}
	
	public void Explode(){
		GameObject boom = (GameObject) GameObject.Instantiate(explosion);
		boom.transform.position = this.transform.position;
	}
}
