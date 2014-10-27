using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Return)){
			if(gameObject.activeInHierarchy == true){
				Application.LoadLevel(0);
			}
		}

	}
}
