using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	public float speed;
	public float upPower;
	public static Move instance;

	private Transform tr;

	private Animator anim;

	void Awake(){
		instance = this;
		tr = this.gameObject.GetComponent<Transform>();

		anim = GetComponent<Animator>();
	}

	void Update(){
//		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//		Debug.DrawRay(ray.origin, ray.direction*1000.0f,Color.green);

//		Vector2 worldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//		Debug.Log (tr.localPosition);

		gameObject.GetComponent<Transform>().Translate(Vector3.right*Time.deltaTime*speed);

//		if(Input.GetMouseButtonDown(0))
//		{
//			RaycastHit2D hit = Physics2D.Raycast(worldSpace,Vector2.zero);
//			Debug.Log(worldSpace);
//
//			if(Physics2D.Raycast(worldSpace,Vector2.zero,1<<11))
//			{
//				Debug.Log("Hit");
//
//			}
//		}
	}
}
