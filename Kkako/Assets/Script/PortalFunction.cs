using UnityEngine;
using System.Collections;

public class PortalFunction : MonoBehaviour {

	Transform parent;
	Transform own;
	Transform pair;

	void OnTriggerEnter2D(Collider2D coll){
		own = GetComponent<Transform>();
		parent = GameObject.Find(own.parent.name).GetComponent<Transform>();
		Debug.Log (parent);

		if(own.name=="Orange_N")
		{
			if (coll.gameObject.layer == 11) 
			{
				Debug.Log("hit");
				pair = parent.FindChild("Blue_N").GetComponent<Transform>();
				Vector2 movePosition = new Vector2(pair.position.x+0.8f,pair.position.y);
				coll.transform.position = movePosition;
			}
		}

		else{ parent.gameObject.SetActive(false);}

	}
}
