using UnityEngine;
using System.Collections;

public class TimedObjectDestroy : MonoBehaviour {
	public float time;
	private float timeCounter;
	public bool initiated;
	// Use this for initialization
	void Start () {
	
	}
	

	
	// Update is called once per frame
	void Update () {
		if (initiated){
			if (timeCounter > time)
				Destroy(gameObject);
			timeCounter += Time.deltaTime;
		}
				
	}
}
