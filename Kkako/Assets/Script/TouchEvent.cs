using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TouchEvent : MonoBehaviour {
	public  Vector2 mousePos;
	private Vector2 localPos;
	private Vector2 portalPos;

	public Transform targetTr;

	public bool isPressed;
	private bool createPortal;
	private bool createIsEnd;

	private List<Vector2> pointList;

	public GameObject particle;
	public GameObject portal;
	public GameObject parent;

	public int pCount;
	public int pMax;
	public int pCurrent;

	private string pName;

	private Animator anim;

	public float slowSpeed;
	public float backSpeed;
	
//	public UIEventTrigger current;

	public static TouchEvent tEvent;

	struct portalPosition
	{
		public Vector2 Pos1;
		public Vector2 Pos2;
		public Vector2 Pos;
	};


	void Start(){
		isPressed = false;
		createPortal = true;
		createIsEnd = false;
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
		pCount = GameObject.Find("Portal").transform.childCount;

		Debug.Log("pCount is : "+pCount);
		Debug.Log ("createisEnd :"+createIsEnd);
		Debug.Log ("pCurrent :"+pCurrent);

		if(isPressed)
		{
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			localPos = NGUIMath.WorldToLocalPoint(mousePos,Camera.main,Camera.main,targetTr);

			if(!pointList.Contains(mousePos))
			{
				pointList.Add (localPos);
			}
		}


	}

	// Use this for initialization
	public void Press () {

		Move.charMove.speed = slowSpeed;
		anim.SetFloat("slowMotion",0.5f);

		Debug.Log ("Pressed");
		isPressed = true;
//		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//		localPos = NGUIMath.WorldToLocalPoint(mousePos,Camera.main,Camera.main,targetTr);
//
//		Debug.Log(mousePos);

		GameObject obj = Instantiate(particle,mousePos,Quaternion.identity) as GameObject;

//		GameObject obj = Resources.Load("FollowParticle")as GameObject;

		obj.name = "mouseFollower"+pCurrent;
	}

	public void Realease(){

		Move.charMove.speed = backSpeed;
		anim.SetFloat("slowMotion",1.0f);

		isPressed = false;
		Destroy(GameObject.Find(("mouseFollower"+pCurrent)));

		portalPosition pPos;
		pPos.Pos1 = (Vector2)pointList[1];
		pPos.Pos2 = (Vector2)pointList[pointList.Count-1];
		pPos.Pos = (Vector2)(pPos.Pos1 + pPos.Pos2)/2;
		portalPos = new Vector2(pPos.Pos.x,pPos.Pos.y);

		pointList.Clear();

//		if(pCurrent==pMax) return;
		
//		else 
//		{
			if(createPortal)
			{
				GameObject obj = NGUITools.AddChild(parent,portal);
				obj.name = "Portal_"+pCurrent;
				pName = obj.name;
				obj.transform.FindChild("Orange_N").localPosition = portalPos;
				createPortal = false;
			}
			else 
			{
				GameObject.Find(pName).transform.FindChild("Blue_N").localPosition = portalPos;
				createPortal = true;
				pName = "";
				pCurrent ++;

//				if(pCurrent == pCount)
//				{
//					pCurrent = 0;
//				}
			}
//		}
	}

	public void Click(){

	}
}
