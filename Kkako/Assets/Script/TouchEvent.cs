using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchEvent : MonoBehaviour {
	public  Vector2 mousePos; //마우스 포지션 벡터값.
	private Vector2 localPos; //마우스 포지션을 NGUI 로컬 좌표로 저장하는 포지션 벡터값. 
	private Vector2 portalPos; //포탈이 생성되는 위치 벡터값.

	public Transform targetTr; //타겟 NGUI 트랜스폼.

	public bool isPressed; //마우스가 눌러졌는지 호가인
	private bool createPortal; //마우스 드래그시 새로운 포탈을 그리는 순서인지 블루포탈을 그리는 순서인지 구분. 

	private List<Vector2> pointList; //마우스의 NGUI로컬 좌표값을 저장하는 어레이.

	public GameObject particle; //파티클 게임오브젝트
	public GameObject portal; //생성하는 포탈
	public GameObject parent; //포탈을 생성하는 부모 게임오브젝트

//	public int pCount;
//	public int pMax;
	public int pCurrent;

	private string pName; //생상할 포탈의 이름.

	private Animator anim; //게임 케릭터 애니메이션을 불러와 isPressed = true 상태에서 느려지게 만듬.

	public float slowSpeed; //케릭터 이동속도를 얼마로 바꿀껀지.
	public float backSpeed; //케릭터 이동속도가 다시 얼마로 바뀌는지.
	
//	public UIEventTrigger current;

	public static TouchEvent tEvent; //다른 스크립트에서 이 스크립트 접근.

	struct portalPosition // pointList의 첫번째 값과 마지막 값을 가져와 portalPos값 계산할 벡터값들.
	{
		public Vector2 Pos1;
		public Vector2 Pos2;
		public Vector2 Pos;
	};


	void Start(){
		isPressed = false; 
		createPortal = true;
//		createIsEnd = false;
		pointList = new List<Vector2>();
		pName = "";
		tEvent = this;
		pCurrent = 1;
		anim = GameObject.Find("Player").GetComponent<Animator>();
	}

	void Update(){
//		if(Input.GetMouseButtonDown(0))
//		{
//			isPressed = true;
//		}
//		pCount = GameObject.Find("Portal").transform.childCount;
//
//		Debug.Log("pCount is : "+pCount);
//		Debug.Log ("createisEnd :"+createIsEnd);
//		Debug.Log ("pCurrent :"+pCurrent);

		if(isPressed) //마우스가 눌러진 상태에서.
		{
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //마우스 위치값을 카메라에서 가져옴.
			localPos = NGUIMath.WorldToLocalPoint(mousePos,Camera.main,Camera.main,targetTr);//마우스 위치값을 Ngui 로컬좌료로 변환.

			if(!pointList.Contains(mousePos))//로컬 좌표값을 어레이에 담음.
			{
				pointList.Add (localPos);
			}
		}


	}

	// Use this for initialization
	public void Press () { //마우스가 눌리게 되면.

		Move.charMove.speed = slowSpeed; //케릭터 이동속도를 바꿈.
		anim.SetFloat("slowMotion",0.5f); //케릭터의 애니메이션 속도 바꿈.

//		Debug.Log ("Pressed");
		isPressed = true;

		GameObject obj = Instantiate(particle,mousePos,Quaternion.identity) as GameObject; //마우스를 따라다니는 파티클을 생성함.

//		GameObject obj = Resources.Load("FollowParticle")as GameObject;

		obj.name = "mouseFollower"+pCurrent; //파티클의 이름을 정해주어 마우스 왼쪽버튼을 뗏을때 사라지게 만듬.
	}

	public void Realease(){

		Move.charMove.speed = backSpeed; //케릭터 속도를 원상복구.
		anim.SetFloat("slowMotion",1.0f); //케릭터의 에니메이션 속도를 복구.

		isPressed = false;
		Destroy(GameObject.Find(("mouseFollower"+pCurrent))); //파티클을 제거.

		portalPosition pPos; // 저장해둔 pointList 내의 값들을 이용하여 포탈을 생성할 위치를 구함.
		pPos.Pos1 = (Vector2)pointList[1]; //첫번째 값.
		pPos.Pos2 = (Vector2)pointList[pointList.Count-1];//마지막 번째 값.
		pPos.Pos = (Vector2)(pPos.Pos1 + pPos.Pos2)/2; //두 벡터의 가운데값.
		portalPos = new Vector2(pPos.Pos.x,pPos.Pos.y); //포탈 생성위치에 이 값들을 넣어줌.

		pointList.Clear(); //리스트내의 값들을 제거.

//		if(pCurrent==pMax) return;
		
//		else 
//		{
			if(createPortal) //포탈을 생성하는 순서라면.
			{
				GameObject obj = NGUITools.AddChild(parent,portal); //부모 게임오브젝트에 포탈 오브젝트 추가
				obj.name = "Portal_"+pCurrent;
				pName = obj.name;
				obj.transform.FindChild("Orange_N").localPosition = portalPos; //오렌지 포탈을 저장한 portalPos의 위치에서 생성.
				createPortal = false; //포탈을 생성하는 순서가 아님을 알림.
			}
			else //블루포탈을 생성하는 순서라면.
			{
				GameObject.Find(pName).transform.FindChild("Blue_N").localPosition = portalPos; //블루 포탈을 저장한 portalPos 위치에 생성.
				createPortal = true; //포탈을 생성하는 순서임을 알림.
				pName = "";
				pCurrent ++; //현재 포탈 생성 개수를 올림.

//				if(pCurrent == pCount)
//				{
//					pCurrent = 0;
//				}
			}
//		}
	}
}
