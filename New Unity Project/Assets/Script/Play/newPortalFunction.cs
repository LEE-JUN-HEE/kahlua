using UnityEngine;
using System.Collections;

public class newPortalFunction : MonoBehaviour {

	private Animator anim;
	private Animator[] anims;
	private Transform parent;
	private Collider2D playerColl;

	void Start(){
		parent = this.transform.parent;
		anims = parent.GetComponentsInChildren<Animator>();
		Invoke("DestroyP",ManagerOfGame.instance.destroyPtime);

	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag=="Player")
		{
			Debug.Log("coll");
			CancelInvoke("DestroyP");
			playerColl = coll;
			StartCoroutine(MoveFromTo());
			ManagerOfGame.instance.ScoreController();
		}
	}

	void DestroyP(){
		foreach(Animator am in anims)
		{
			am.SetTrigger("isClose");
			Destroy(parent.gameObject,1.0f);
		}
	}

	public IEnumerator MoveFromTo(){
		Debug.Log("coroutine");
		ManagerOfGame.instance.charSpeed = 0.0f;
		UICamera cam = UICamera.FindCameraForLayer(8);
		GameObject originTarget = cam.GetComponent<CameraFollow>().target;
		GameObject newTarget = parent.GetChild(1).gameObject;

		yield return new WaitForSeconds(.7f);
		cam.GetComponent<CameraFollow>().target = newTarget;

		yield return new WaitForSeconds(1.0f);
		playerColl.transform.position = newTarget.transform.position;

		yield return new WaitForSeconds(0.5f);
		cam.GetComponent<CameraFollow>().target = originTarget;

		ManagerOfGame.instance.charSpeed = ManagerOfGame.instance.charOriginSpeed;
		DestroyP();
	}
}
