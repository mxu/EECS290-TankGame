using UnityEngine;
using System.Collections;

public class TankController : MonoBehaviour {
	
	
	public Vector3 torque = new Vector3(0f, 100f, 0f);
	public Rigidbody[] leftWheels;
	public Rigidbody[] rightWheels;
	public GameObject turret;
	public Transform gun;
	public Transform gunRotationPoint;
	public float gunPitchLowBound;
	public float gunPitchHighBound;
	public float gunTurnSpeed;
	public Vector3 turnTo;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.moveGunTowards(turnTo);
		
		
		
	}
	
	//ToDo: Make the gun turret lerp and shit and make the gun not turn outside of the bounds.
	private void moveGunTowards(Vector3 direction){
		Vector3 rotation = new Vector3 (0f, direction.x, 90f);
		Vector3 pitch = new Vector3(90f, direction.y, 0f);
		Vector3 startPitch = new Vector3 (0f, gun.rotation.y, 0f);
		Vector3 startRotation = new Vector3 (0f, gunRotationPoint.rotation.y, 0f);
		gun.localRotation = Quaternion.Euler(pitch);
		gunRotationPoint.rotation = Quaternion.Euler(rotation);
				
	
		/*This bit is a little weird. The way I made the gun rotate was by using 
		a spherical coordinate system and updating the position of the gun such
		that it is always on the correct spot on the outside of the tank. I am
		sure there are better ways to do this but none that worked for me. */
		
		float turretRadius = turret.transform.localScale.x / 2f;
		float gunLength = gun.localScale.y;
		float theta = ((gun.rotation.eulerAngles - this.transform.rotation.eulerAngles).y - 90f) * Mathf.Deg2Rad;
		float phi = ((gun.rotation.eulerAngles- this.transform.rotation.eulerAngles).z) * Mathf.Deg2Rad;
		gunRotationPoint.position = turret.transform.position;
		gun.position = turret.transform.position + 
			new Vector3(
				turretRadius * Mathf.Sin (phi) * Mathf.Sin(theta), 
				turretRadius * Mathf.Cos(phi),  
				turretRadius * Mathf.Sin (phi) * Mathf.Cos(theta)
				);
	}
	
	
	
	/*All these methods are just used to move and turn the tank.
	Moving forward and backwards is just done by applying the appropriate torque
	to the wheels, and turning is done by applying opposite torque to the left
	and right wheels appropriately */
	
	
	public void moveForward() {
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
