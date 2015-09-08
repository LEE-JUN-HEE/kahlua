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
	private List<Vector3> pointsList;
	private Vector3 mousePos;
	private Vector3 portalPosition;
	private string portalColor;

	struct portalPos
	{
		public Vector3 Pos1;
		public Vector3 Pos2;
		public Vector3 Pos;
	};

	private enum Portal {orange, blue};
	private Portal portal;

	void Awake(){
		line = gameObject.AddComponent<LineRenderer>();
		line.material =  new Material(Shader.Find("Sprites/Default"));
		line.SetVertexCount(0);
		line.SetWidth(0.02f,0.02f);
		line.SetColors(Color.white, Color.white);
		line.useWorldSpace = true;	
		isMousePressed = false;
		orange = true;
		blue = false;
//		isGameOver = false;
		pointsList = new List<Vector3>();
		portalPosition = new Vector3();
//		dragOrder= 0;
		portalColor = "";
	}
		
	void FixedUpdate () {

		CheckPortalOrder(orange,blue);

		Debug.Log("pColor :" + portalColor);

		if(Input.GetMouseButtonDown(0))
		{
			isMousePressed = true;
			line.SetColors(Color.white, Color.white);

		}

		else if(Input.GetMouseButtonUp(0))
		{
			isMousePressed = false;

			orange = !orange;
			blue = !blue;	//포탈순서 정함.

			SetPortalPosition();

			line.SetVertexCount(0);
			pointsList.RemoveRange(0,pointsList.Count);

			CreatePortal(portalColor,portalPosition);//포탈 생성


		}

		if(isMousePressed)
		{
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z=0;
			
			if (!pointsList.Contains (mousePos)) 
			{
				pointsList.Add (mousePos);
				line.SetVertexCount (pointsList.Count);
				line.SetPosition (pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
			}

//			StartCoroutine(this.SetPortalPosition());
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
		pPos.Pos1 = (Vector3)pointsList[0];
		pPos.Pos2 = (Vector3)pointsList[pointsList.Count-1];
		pPos.Pos = (Vector3)(pPos.Pos1 + pPos.Pos2)/2;
		portalPosition = new Vector3(pPos.Pos.x,pPos.Pos.y,-2.0f);

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

	void CreatePortal(string pColor, Vector3 Pos){
	
		GameObject orangePortal = (GameObject)Instantiate(Resources.Load(pColor)
			                                                  ,Pos
			                                                  ,Quaternion.identity);

		portalPosition = new Vector3();
	}

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
