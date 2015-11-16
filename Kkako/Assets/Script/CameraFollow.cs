using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Transform tr;
	public Transform target;
	public float size;

	// Use this for initialization
	void Start () {
		tr = this.GetComponent<Transform>(); //카메라의 위치값.
		target = target.GetComponent<Transform>(); //카메라가 따라갈 케릭터의 위치값
		size = GetComponent<Camera>().orthographicSize; //카메라의 사이즈


	}

	void Update () {
		tr.position = new Vector3(target.position.x,target.position.y,-0.01f); //카메라가 캐릭터를 따라간다.
	}

	public void sizeUpdate(){ //스크롤 바를 움직였을때 카메라 사이즈를 바꾼다.
		Camera.main.orthographicSize = UIProgressBar.current.value*2;
	}
}
