using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public enum MoveState {
        forward = 0,
        left = 1,
        right = 2
    }

	private TankController tankController;
	private GameObject player;

    private float moveTime = 0f;
    private float reloadTime = 0f;
	private float distance = 0f;
    private MoveState movement = MoveState.forward;
	private GameObject[] targets;

    public float aggroRadius = 20f;
    public float attackAngle = 4f;
    public float visionAngle = 10f;
    public float maximumRotateSpeed = 40;
    public float minimumTimeToReachTarget = 0.5f;
    public float _velocity;
    
	// Use this for initialization
	void Start() {
		tankController = this.GetComponent<TankController>();
	}
	
	// Update is called once per frame
	void Update() {
		if (this.gameObject.tag.Equals ("enemy")){
			targets = GameObject.FindGameObjectsWithTag("Player");
		}
		else{
			targets = GameObject.FindGameObjectsWithTag("enemy");
		}
		if (targets.Length > 0){
			distance = Vector3.Distance (targets[0].transform.position, this.gameObject.transform.position);
			player = targets[0];
		}
		foreach(GameObject target in targets){
			if (Vector3.Distance(target.transform.position, this.transform.position) < distance){
				player = target;
				distance = Vector3.Distance(target.transform.position, this.transform.position);
			}
		}

        //distance = (player.transform.position - this.transform.position).magnitude;
        if(distance < aggroRadius) {
            var a = Quaternion.LookRotation(player.transform.position - this.transform.position).eulerAngles;
            var b = this.transform.eulerAngles;
            var rd = (a - b).y;
            if(Mathf.Abs(rd) > attackAngle) {
                Debug.Log("Turning to face player");
                this.transform.rotation = Quaternion.Euler(b.x, Mathf.SmoothDampAngle(b.y, a.y, ref _velocity, minimumTimeToReachTarget, maximumRotateSpeed), b.z);
            }
            if(Mathf.Abs(rd) < visionAngle) {
                if(reloadTime < 0.01f) {
                    Debug.Log("Shooting");
                    tankController.shoot();
                    reloadTime = 1f;
                } else {
                    reloadTime -= Time.deltaTime;
                }
            }
        } else if(moveTime > 0f) {
            switch(movement) {
                case MoveState.forward:
                    tankController.moveForward();
                    break;
                case MoveState.left:
                    tankController.turnLeft();
                    break;
                case MoveState.right:
                    tankController.turnRight();
                    break;
                default:
                    break;
            }
            moveTime -= Time.deltaTime;
        } else {
            movement = (MoveState) Random.Range(0, 3);
            switch(movement) {
                case MoveState.forward:
                    moveTime = Random.Range(5f, 20f);
                    break;
                case MoveState.left:
                case MoveState.right:
                    moveTime = Random.Range(1f, 7f);
                    break;
                default:
                    break;
            }
        }
    }
}