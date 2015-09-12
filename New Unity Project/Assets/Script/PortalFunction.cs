using UnityEngine;
using System.Collections;

public class PortalFunction : MonoBehaviour {

	Transform another = null;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") 
		{
			another = GameObject.FindGameObjectWithTag("Blue").GetComponent<Transform>();
//			GameObject anotehr = (GameObject) 
			Vector3 movePosition = another.position;
			coll.transform.position = movePosition;
		}
	}
}
