using UnityEngine;
using System.Collections;

public class SetTarget : MonoBehaviour {

	public GameObject Enemy;
	public GameObject Target;

	private Vector3 posTarget;
	private Vector3 newPos;
	public bool targetSet;
	private GameObject targetClone;
	private float distanceToGround;

	void Start () {

		//Raycast to get Distance to Ground
		RaycastHit hit;
		if (Physics.Raycast(Enemy.transform.position, -Vector3.up, out hit, 100.0F)){
			distanceToGround = hit.distance;

		}

		targetSet = false;
		Target.SetActive(false);
		newPos = new Vector3 (Enemy.transform.position.x, Enemy.transform.position.y - distanceToGround +0.01f, Enemy.transform.position.z); 
	}

	void Update () {

		//Only Set Target if there are Enemys
		if (GameObject.Find("Enemy") != null){

			//Set Target
			if(GameObject.Find("Enemy").GetComponent<Enemy>().setTarget == true){
			//if(Enemy.GetComponent<Enemy>().setTarget == true){
				if(targetSet == false){
					GameObject targetClone = Instantiate(Target, newPos, Quaternion.identity) as GameObject;
					targetClone.SetActive(true);
					targetSet = true;
				}
			}
		} else {
			Destroy(GameObject.Find ("Target(Clone)"));
		}
	
	}

}
