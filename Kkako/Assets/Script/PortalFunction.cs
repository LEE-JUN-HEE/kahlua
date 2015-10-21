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

		if(own.name=="orange")
		{
			if (coll.gameObject.layer == 11) 
			{
				Debug.Log("hit");
				pair = parent.FindChild("blue").GetComponent<Transform>();
				Vector2 movePosition = pair.position;
				coll.transform.position = movePosition;
			}
		}

		else{ parent.gameObject.SetActive(false);}

	}
}
