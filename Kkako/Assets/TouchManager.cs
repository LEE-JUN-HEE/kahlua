using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour {

	public float upPower;
	private Ray ray;
	private RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction*100.0f,Color.green);
		if(Input.GetMouseButtonDown(0))
		{
			if(Physics.Raycast(ray, out hit, Mathf.Infinity,1<<10))
			{
				Jump();
			}
		}
	}

	void Jump(){
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*upPower);
	}
}
