using UnityEngine;
using System.Collections;

public class PortalFunction : MonoBehaviour {

	GameObject parent;
	Transform own;
	Transform pair;

	public float delayTime;

	void Start(){
		own = this.GetComponent<Transform>();
		parent = GameObject.Find(own.parent.name);
		Destroy(parent.gameObject,delayTime);
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.layer == 11) 
		{
			if(own.name=="Orange_N")
			{
				Debug.Log("hit");
				pair = parent.transform.FindChild("Blue_N").GetComponent<Transform>();
				Vector2 movePosition = new Vector2(pair.position.x,pair.position.y);
				coll.transform.position = movePosition;
			}

			else if(own.name =="Blue_N")
			{
				Destroy(parent);
			}
		}
	}
}
