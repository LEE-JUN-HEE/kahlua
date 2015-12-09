using UnityEngine;
using System.Collections;

public class BackGround : MonoBehaviour {

//	public Transform followPos;
	private Vector2 originPos;
	public float ratio ;


	// Use this for initialization
	void Start () {
		originPos = transform.position; //원래 뒷배경의 좌표값을 저장한다.
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log(ratio);
		Vector2 pos = UICamera.FindCameraForLayer(8).transform.position;
//		Vector2 pos = followPos.position;
		transform.position = new Vector2(originPos.x+pos.x*ratio,originPos.y+pos.y*ratio); //뒷배경이 원근비율에 따라 카메라가 이동하면 비율로 인해 조금씩 이동하며 따라다님.
	}
}
