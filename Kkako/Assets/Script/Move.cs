using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float speed;
	public static Move instance;

	void Awake(){
		instance = this;
	}

	void FixedUpdate(){
		gameObject.GetComponent<Transform>().Translate(Vector3.right*Time.deltaTime*speed);
	}

}
