using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	private Transform tr;
	private Animator anim;
	private bool alreadyClicked;
	private Rigidbody2D rbody;

	public float rayDistance;
	
	void Start(){
		tr = this.GetComponent<Transform>();
		anim = this.GetComponent<Animator> ();
		rbody = this.GetComponent<Rigidbody2D>();
	}

	void OnClick(){
		if(anim.GetBool("OnLand"))
		{
			anim.SetBool("OnLand",false);
			anim.SetTrigger("start_Jump");
			rbody.AddForce(Vector2.up*ManagerOfGame.instance.charUpforce);
		}
	}

	void OnAnimatorMove(){
		if(anim)
		{
			Vector3 newPosition = tr.position;
			newPosition.x +=ManagerOfGame.instance.charSpeed*Time.fixedDeltaTime;
			tr.position = newPosition;
		}
		if(anim&&!anim.GetBool("OnLand"))
		{

			StartCoroutine(DrawRayDown());
		}
	}

	IEnumerator DrawRayDown(){
		yield return new WaitForSeconds(0.5f);
		Ray2D ray = new Ray2D(anim.rootPosition,Vector2.down);
		RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction,Mathf.Infinity,1<<10);

		Debug.Log(hit.distance);
		if(hit.distance<0.477f&&hit.distance !=0.0f)
		{	
			anim.SetBool("OnLand",true);
		}
	}
}