using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Vector3 torque = new Vector3(0f, 100f, 0f);
	public Rigidbody[] leftWheels;
	public Rigidbody[] rightWheels;
	public Rigidbody turret;
	
	void Start() {
	}
	
	
	void Update () {
	
		if (Input.GetKey (KeyCode.W)) {
			this.moveForward();
		}
		if (Input.GetKey (KeyCode.S)) {
			this.moveBackward();
		}
		if (Input.GetKey (KeyCode.A)) {
			this.turnLeft();
		}
		if (Input.GetKey (KeyCode.D)) {
			this.turnRight();
		}
		
		
	}
	
	private void moveForward() {
		foreach (Rigidbody rb in leftWheels){
			rb.AddRelativeTorque(-torque);
		}
		foreach (Rigidbody rb in rightWheels){
			rb.AddRelativeTorque(-torque);
		}
	}
	
	public void moveBackward(){
		foreach (Rigidbody rb in leftWheels){
			rb.AddRelativeTorque(torque);
		}
		foreach (Rigidbody rb in rightWheels){
			rb.AddRelativeTorque(torque);
		}
	}
	
	public void turnRight(){
		foreach (Rigidbody rb in leftWheels){
			rb.AddRelativeTorque(-torque);
		}
		foreach (Rigidbody rb in rightWheels){
			rb.AddRelativeTorque(torque);
		}
	}
	
	public void turnLeft(){
		foreach (Rigidbody rb in leftWheels){
			rb.AddRelativeTorque(torque);
		}
		foreach (Rigidbody rb in rightWheels){
			rb.AddRelativeTorque(-torque);
		}
	}
	
}
