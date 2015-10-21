using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PortalInQue : MonoBehaviour {

//	private List<GameObject> portalPool;
	private Queue<GameObject> portalPool;

	public GameObject portal;
	public Transform parent;
	public static PortalInQue instance;

	public int portalMax = 1;

	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {

		portalPool = new Queue<GameObject>();
		for (int i=0; i<portalMax; i++)
		{
			GameObject obj = (GameObject) Instantiate(portal);
			obj.name = "Portal_" + i;
			obj.SetActive(false);
			obj.transform.SetParent(parent);
			portalPool.Enqueue (obj);
		}	
	}
}
