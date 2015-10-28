using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawingPortal : MonoBehaviour {

	private LineRenderer line;
	private bool isMousePressed;
	private bool orange;
	private bool blue;
//	private bool isGameOver;
//	private int dragOrder;
	private List<Vector2> pointsList;
	private List<Vector2> portalPoint;
	private Vector2 mousePos;
	private Vector2 portalPosition;
	private Vector2 localPos;
	private string portalColor;
	private Transform tr;

	struct portalPos
	{
		public Vector2 Pos1;
		public Vector2 Pos2;
		public Vector2 Pos;
	};

	private enum Portal {orange, blue};
	private Portal portal;

	void Awake(){
		line = gameObject.AddComponent<LineRenderer>();
		line.material =  new Material(Shader.Find("Sprites/Default"));
		line.material.renderQueue = 3500;
		line.SetVertexCount(0);
		line.SetWidth(0.05f,0.05f);
		line.SetColors(Color.white, Color.white);
		line.useWorldSpace = true;	
		isMousePressed = false;
		orange = true;
		blue = false;
//		isGameOver = false;
		pointsList = new List<Vector2>();
		portalPoint = new List<Vector2>();
		portalPosition = new Vector2();
//		dragOrder= 0;
		portalColor = "";
		tr = GameObject.Find("DrawingArea").GetComponent<Transform>();
	}
		
	void FixedUpdate () {

//		CheckPortalOrder(orange,blue);

//		Debug.Log("pColor :" + portalColor);

		if(Input.GetMouseButtonDown(0))
		{
			isMousePressed = true;

			line.SetColors(Color.white, Color.white);
		}

		else if(Input.GetMouseButtonUp(0))
		{
			isMousePressed = false;

//			orange = !orange;
//			blue = !blue;	//포탈순서 정함.

			Debug.Log(portalPoint.Count);

			SetPortalPosition();

			line.SetVertexCount(0);

			pointsList.Clear();
			portalPoint.Clear();

			Debug.Log(portalPosition);

			CreatePortal(portalPosition);

//			CreatePortal(portalColor,portalPosition);//포탈 생성
		}

		if(isMousePressed)
		{
//			Vector2 preMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

			localPos = NGUIMath.WorldToLocalPoint(mousePos,Camera.main,Camera.main,tr);

//			Debug.Log (localPos);

//			mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
//			mousePos = NGUITools.FindCameraForLayer(11).ScreenToWorldPoint(Input.mousePosition);
			
			if (!pointsList.Contains (mousePos)) 
			{	
				pointsList.Add (mousePos);
				portalPoint.Add(localPos);
				line.SetVertexCount (pointsList.Count);
				line.SetPosition (pointsList.Count - 1, (Vector2)pointsList[pointsList.Count - 1]);
			}
		}
	}

	void CheckPortalOrder(bool Orange, bool Blue){

		if(Orange)
		{
			portalColor = "orange";
		}

		else if(Blue)
		{
			portalColor = "blue";
		}	
	}

	void SetPortalPosition(){
		
		portalPos pPos;
		pPos.Pos1 = (Vector2)portalPoint[1];
		pPos.Pos2 = (Vector2)portalPoint[portalPoint.Count-1];
		pPos.Pos = (Vector2)(pPos.Pos1 + pPos.Pos2)/2;
//		portalPosition = new Vector2(pPos.Pos.x,pPos.Pos.y,-2.0f);
		portalPosition = new Vector2(pPos.Pos.x,pPos.Pos.y);
	}

//	void SetPortalPosition(){
//
//		portalPos pPos;
//		pPos.Pos1 = (Vector2)pointsList[0];
//		pPos.Pos2 = (Vector2)pointsList[pointsList.Count-1];
//		pPos.Pos = (Vector2)(pPos.Pos1 + pPos.Pos2)/2;
////		portalPosition = new Vector2(pPos.Pos.x,pPos.Pos.y,-2.0f);
//		portalPosition = new Vector2(pPos.Pos.x,pPos.Pos.y);
//	}

//	void ConvertToLocalPos(){
//		Transform tr = GameObject.Find("DrawingArea").GetComponent<Transform>();
//		tr.localPosition = portalPosition;
//	}

	void CreatePortal(Vector2 Pos){
		GameObject portal = GameObject.Find("Portal_0");

		Debug.Log(portal.name);

		portal.GetComponent<Transform>().FindChild("Orange_N").transform.localPosition = Pos;
//		portal.GetComponent<Transform>().transform.localPosition = Pos;
	}

//	IEnumerator SetPortalPosition(){
//		while(isMousePressed)
//		{
//			switch(portal)
//			{
//			case Portal.orange:
//				portalPos orange;
//				orange.Pos1 = (Vector3)pointsList[0];
//				orange.Pos2 = (Vector3)pointsList[pointsList.Count-1];
//				orange.Pos = (Vector3)(orange.Pos1 + orange.Pos2)/2;
//				orangePos = new Vector3(orange.Pos.x,orange.Pos.y,-2.0f);
//				break;
//
//			case Portal.blue:
//				portalPos blue;
//				blue.Pos1 = (Vector3)pointsList[0];
//				blue.Pos2 = (Vector3)pointsList[pointsList.Count-1];
//				blue.Pos = (Vector3)(blue.Pos1 + blue.Pos2)/2;
//				bluePos = new Vector3(blue.Pos.x,blue.Pos.y,-2.0f);
//				break;
//			}
//
//			yield return new WaitForEndOfFrame();
//		}
//	}



//	bool DragFinish(bool check){
//		if(dragOrder == 2)
//		{
//			return true;
//		}
//		else return false;;
//	}

//	IEnumerator SetPortalPosition(){
//
//		if(dragOrder == 0)
//		{
//			portalPos orange;
//			orange.Pos1 = (Vector3)pointsList[0];
//			orange.Pos2 = (Vector3)pointsList[pointsList.Count-1];
//			orange.Pos = (Vector3)(orange.Pos1 + orange.Pos2)/2;
//			orangePos = new Vector3(orange.Pos.x,orange.Pos.y,-2.0f);
//			dragOrder = 1;
//		}
//		else if(dragOrder == 1)
//		{
//			portalPos blue;
//			blue.Pos1 = (Vector3)pointsList[0];
//			blue.Pos2 = (Vector3)pointsList[pointsList.Count-1];
//			blue.Pos = (Vector3)(blue.Pos1 + blue.Pos2)/2;
//			bluePos = new Vector3(blue.Pos.x,blue.Pos.y,-2.0f);
//			dragOrder = 2;
//		}
//		yield return new WaitForSeconds (0.5f);
//	}
//
//	void CreatePortal(Vector3 orangePos,Vector3 bluePos){
//		GameObject orangePortal = (GameObject)Instantiate(Resources.Load("orange")
//		                                                  ,orangePos
//		                                                  ,Quaternion.identity);
//
//		GameObject bluePortal = (GameObject)Instantiate(Resources.Load("blue")
//		                                                ,bluePos
//		                                                ,Quaternion.identity);
//	}
//
//	bool DragFinish(int dragOrder){
//		if(dragOrder == 2)
//		{
//			return true;
//		}
//		else return false;;
//	}

//	void CheckOrder(){
//		if(dragOrder == 0)
//		{
//			whichColor = "orange";
//			dragOrder = 1;
//		}
//		else if(dragOrder == 1)
//		{
//			whichColor = "blue";
//			dragOrder = 0;
//		}
//	}

//	void PosSave(){
//		portal.Pos = pointsList[0];
//		portal.Pos2 = pointsList[pointsList.Count-1];
//		portal.Pos = (portal.Pos1 + portal.Pos2)/2;
//	}
//
//	bool Whichcolor(string color){
//		return (color=="orange");
//	}
}
