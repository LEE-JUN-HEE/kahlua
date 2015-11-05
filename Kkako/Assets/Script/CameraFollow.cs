using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Transform tr;
	public Transform target;

	// Use this for initialization
	void Start () {
		tr = this.GetComponent<Transform>();

		target = target.GetComponent<Transform>();
	}

	void Update () {
		tr.position = new Vector3(target.position.x,target.position.y,-0.01f);
	}
}
