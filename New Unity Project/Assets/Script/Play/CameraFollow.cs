//using UnityEngine;
//using System.Collections;
//
//public class CameraFollow : MonoBehaviour {
//
//	private Transform tr;
//	public Transform target;
//	public float size;
//
//	// Use this for initialization
//	void Start () {
//		tr = this.GetComponent<Transform>(); //카메라의 위치값.
//		size = GetComponent<Camera>().orthographicSize; //카메라의 사이즈
//	}
//
//	void LateUpdate () {
//		tr.position = new Vector2(target.position.x,target.position.y); //카메라가 캐릭터를 따라간다.
//	}
//
//	public void sizeUpdate(){ //스크롤 바를 움직였을때 카메라 사이즈를 바꾼다.
//		Camera.main.orthographicSize = UIProgressBar.current.value*2;
//	}
//}

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public Vector3 offset;
	Vector3 targetPos;
	// Use this for initialization
	void Start () {
		targetPos = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;
			
			Vector3 targetDirection = (target.transform.position - posNoZ);
			
			interpVelocity = targetDirection.magnitude * 5f;
			
			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.fixedDeltaTime); 
			
			transform.position = Vector3.Lerp( new Vector3( transform.position.x,0,0), targetPos + offset,0.25f);			
		}
	}
}

// Original post with image here  >  http://unity3diy.blogspot.com/2015/02/unity-2d-camera-follow-script.html