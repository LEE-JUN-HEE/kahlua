using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchEvent_mod : MonoBehaviour {
	public  Vector2 mousePos; //마우스 포지션 벡터값.
	private Vector2 localPos; //마우스 포지션을 NGUI 로컬 좌표로 저장하는 포지션 벡터값. 
	private Vector2 InportalPos; //포탈이 생성되는 위치 벡터값.
	private Vector2 OutportalPos;

	public Transform targetTr; //타겟 NGUI 트랜스폼.

	public bool isPressed; //마우스가 눌러졌는지 확인.
	private bool createP; //마우스 드래그시 새로운 포탈을 그리는 순서인지 블루포탈을 그리는 순서인지 구분. 
	private bool drawingOver;

	private List<Vector2> pointList; //마우스의 NGUI로컬 좌표값을 저장하는 어레이.

	public GameObject particle; //파티클 게임오브젝트
	public GameObject portal; //생성하는 포탈
	public GameObject parent; //포탈을 생성하는 부모 게임오브젝트

//	public int pCount;
//	public int pMax;
	public int pCurrent;

	private string pName; //생상할 포탈의 이름.

	private Animator anim; //게임 케릭터 애니메이션을 불러와 isPressed = true 상태에서 느려지게 만듬.

//	public UIEventTrigger current;
	
	public GameObject blackOut;
	public Animator playerAnim;
	struct portalPosition // pointList의 첫번째 값과 마지막 값을 가져와 portalPos값 계산할 벡터값들.
	{
		public Vector2 Pos1;
		public Vector2 Pos2;
		public Vector2 Pos;
	};


	void Start(){
		isPressed = false; 
		createP = false;
//		createIsEnd = false;
		pointList = new List<Vector2>();
		pName = "";
		pCurrent = 1;
		drawingOver =false;
	}

	void Update(){

//		Debug.Log("drawingover"+drawingOver+" "+"createP"+createP);

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
	void OnDragStart () { //마우스가 눌리게 되면.
		Debug.Log("Pressed");
		blackOut.SetActive(true);
		ManagerOfGame.instance.charSpeed = ManagerOfGame.instance.charSlowSpeed; //케릭터 이동속도를 바꿈.
		playerAnim.SetFloat("slow_Motion",0.5f); //케릭터의 애니메이션 속도 바꿈.
		
		isPressed = true;

		GameObject obj = Instantiate(particle,mousePos,Quaternion.identity) as GameObject; //마우스를 따라다니는 파티클을 생성함.	

		obj.name = "mouseFollower"+pCurrent; //파티클의 이름을 정해주어 마우스 왼쪽버튼을 뗏을때 사라지게 만듬.
	}

	void OnDragEnd(){
		Debug.Log("released");
		isPressed = false;
		Destroy(GameObject.Find(("mouseFollower"+pCurrent))); //파티클을 제거.

		if(ManagerOfGame.instance.charMp>=0)
		{
			SetPortalPosition(pointList);
			
			if(createP) //포탈을 생성하는 순서라면.
			{
				if(parent.transform.childCount<=ManagerOfGame.instance.portalNum)
				{
					CreatePortal();
					CreateIsOver();
				}
			}
		}
		else{return;}
	}

	void SetPortalPosition(List<Vector2> list)
	{
		portalPosition pPos; // 저장해둔 pointList 내의 값들을 이용하여 포탈을 생성할 위치를 구함.
		pPos.Pos1 = (Vector2)list[1]; //첫번째 값.
		pPos.Pos2 = (Vector2)list[list.Count-1];//마지막 번째 값.
		pPos.Pos = (Vector2)(pPos.Pos1 + pPos.Pos2)/2; //두 벡터의 가운데값.

		if(!drawingOver)
		{
			InportalPos = new Vector2(pPos.Pos.x,pPos.Pos.y);//포탈 생성위치에 이 값들을 넣어줌.
			drawingOver = true;
		}
		else if(drawingOver)
		{
			OutportalPos = new Vector2(pPos.Pos.x,pPos.Pos.y); 
			createP = true;
		}
		list.Clear(); //리스트내의 값들을 제거.
	}

	void CreatePortal(){
		GameObject newPortal = NGUITools.AddChild(parent,portal); //부모 게임오브젝트에 포탈 오브젝트 추가
		newPortal.name = "Portal_"+pCurrent;
		pName = newPortal.name;
		Transform first =  newPortal.transform.FindChild("InPortal"); //오렌지 포탈을 저장한 portalPos의 위치에서 생성.
		Transform second = newPortal.transform.FindChild("OutPortal");
		first.localPosition = InportalPos;
		second.transform.localPosition = OutportalPos;
		pName = "";
		pCurrent ++;
	}

	void CreateIsOver(){
		blackOut.SetActive(false);
		createP = false;
		drawingOver = false;
		
		ManagerOfGame.instance.charSpeed = ManagerOfGame.instance.charOriginSpeed; //케릭터 이동속도를 바꿈.
		ManagerOfGame.instance.MpController();
		playerAnim.SetFloat("slow_Motion",1.0f); //케릭터의 애니메이션 속도 바꿈.
	}
}
