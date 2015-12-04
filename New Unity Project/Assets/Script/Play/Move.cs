using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {	
	
	private Transform tr;
	private Ray ray;
	private RaycastHit hit;
	private Animator anim;
	
	void Start(){
		tr = GetComponent<Transform>();
		anim = GetComponentInChildren<Animator>();
	}

	void Update(){
		tr.Translate(Vector2.right*Time.fixedDeltaTime*0.4f);
	}

	void OnClick(){
		Debug.Log("Jump");
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*ManagerOfGame.instance.charUpforce);
	}
}
