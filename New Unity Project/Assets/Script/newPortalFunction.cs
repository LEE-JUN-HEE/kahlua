using UnityEngine;
using System.Collections;

public class newPortalFunction : MonoBehaviour {

	private Animator anim;

	public float invokeTime;
	
	void Start(){
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D coll){

		Debug.Log("Hit");

		if (coll.gameObject.tag == "Player") 
		{
			anim.SetTrigger("isClose");
			Invoke("DestroyP",invokeTime);
		}
	}

	void DestroyP(){
		Destroy(this.gameObject);
	}
}
