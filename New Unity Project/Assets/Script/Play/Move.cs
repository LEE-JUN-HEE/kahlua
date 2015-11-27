using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	public float speed;
	public float upForce;
	public static Move charMove;
	
	
	private Transform tr;
	private Ray ray;
	private RaycastHit hit;
	private Animator anim;
	
	void Awake(){
		charMove = this;
		tr = GetComponent<Transform>();
		anim = GetComponentInChildren<Animator>();
	}
	
	void Update(){
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin,ray.direction*100.0f,Color.green);
		
		//		Vector2 worldSpace = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		
		//		Debug.Log (tr.localPosition);
		
		gameObject.GetComponent<Transform>().Translate(Vector2.right*Time.deltaTime*speed);
		
		
		//		if(Input.GetMouseButton(0))
		//		{
		//			Debug.Log("mouseDown");
		//			if(UIw)//케릭터를 클릭했을때
		//			{
		//				Debug.Log("Click");
		//				if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f, 1 << 8))
		//				{
		//					Debug.Log("Jump");
		//					GetComponent<Rigidbody2D>().AddForce(Vector2.up*700.0f);
		//				}
		//			}
		//		}
		
		
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
	
	public void moveUpdate(){
		speed = UIScrollBar.current.value;
	}
	
	public void Jump(){
		Debug.Log("Jump");
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*upForce);
	}
}
