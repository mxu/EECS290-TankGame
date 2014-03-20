using UnityEngine;
using System.Collections;

public class bullshit : MonoBehaviour {
	Quaternion start;
	public Quaternion goTo;
	public float counter = 0;

	// Use this for initialization
	void Start () {
		start = this.transform.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		this.transform.rotation = Quaternion.Lerp (start, goTo, counter);
		counter += 0.01f;
	
	}
}
