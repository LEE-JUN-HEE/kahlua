using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalInQue : MonoBehaviour {

//	private List<GameObject> portalPool;
	private Queue<GameObject> portalPool;

	public GameObject portal;
	public GameObject parent;
//	public GameObject Ancor;
//	public static PortalInQue instance;

	public int portalMax = 1;

//	void Awake(){
//		instance = this;
//	}
	// Use this for initialization
	void Start () {

//		portalPool = new Queue<GameObject>();
		for (int i=0; i<portalMax; i++)
		{
//			GameObject obj = (GameObject) Instantiate(portal);
//			obj.SetActive(false);
//			portal.name = "Portal_" + i;
			GameObject obj = NGUITools.AddChild(parent,portal);
			obj.name = "Portal_"+i;
//			obj.transform.localPosition = new Vector2(0.0f,1600.0f);
//			obj.GetComponent<UIWidget>().SetAnchor(Ancor);

//			obj.transform.SetParent(parent);
//			portalPool.Enqueue (obj);
		}	
	}
}
