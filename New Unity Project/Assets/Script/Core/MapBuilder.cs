using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class MapBuilder : MonoBehaviour {

    public XmlDocument parser = new XmlDocument();
    List<CObj_Build> obj_b_list = new List<CObj_Build>();
    List<CObj_Get> obj_g_list = new List<CObj_Get>(); 
    
    void Awake()
    {
        MapLoading();
    }

	void Update () {
	
	}


    void MapLoading()
    {
        #if UNITY_EDITOR
                parser.Load(Application.dataPath + "/testmap.xml");
        #endif

                //#if 안드로이드, IOS 넣어야함
                //#endif

        XmlNode Object_b = parser.FirstChild.ChildNodes[0];
        XmlNode Object_g = parser.FirstChild.ChildNodes[1];

        List<GameObject> obj_b_pool = new List<GameObject>(GameObject.FindGameObjectsWithTag("Obj_Build"));
        List<GameObject> obj_g_pool = new List<GameObject>(GameObject.FindGameObjectsWithTag("Obj_Get"));

        if (Object_b != null)
        {
            if (obj_b_pool.Count < Object_b.ChildNodes.Count)
            {
                int instiateCount = Object_b.ChildNodes.Count - obj_b_pool.Count;
                for (int i = 0; i < instiateCount; i++)
                {
                    obj_b_pool.Add((GameObject)Instantiate(obj_b_pool[0], obj_b_pool[0].transform.position, Quaternion.identity));
                }
            }

            for (int i = 0; i < Object_b.ChildNodes.Count; i++)
            {
                CObj_Build temp = new CObj_Build();
                temp.SetData(Object_b.ChildNodes[i]);
                obj_b_list.Add(temp) ;//.SetData(Object_b.ChildNodes[i]));
            }

            for (int i = 0; i < obj_b_list.Count; i++)
            {
                obj_b_pool[i].GetComponent<IT_Obj_Build>().SetData(obj_b_list[i]);
            }
        }

        if (Object_g != null)
        {
            if (obj_g_pool.Count < obj_g_list.Count)
            {
                int instiateCount = obj_g_list.Count - obj_g_pool.Count;
                for (int i = 0; i <= instiateCount; i++)
                    obj_g_pool.Add((GameObject)Instantiate(obj_g_pool[0], obj_g_pool[0].transform.position, obj_g_pool[0].transform.rotation));
            }

            for (int i = 0; i < Object_g.ChildNodes.Count; i++)
            {
                CObj_Get temp = new CObj_Get();
                temp.SetData(Object_b.ChildNodes[i]);
                obj_g_list.Add(temp);//.SetData(Object_b.ChildNodes[i]));
            }

            if (obj_g_pool.Count < obj_g_list.Count)
            {
                int instiateCount = obj_g_list.Count - obj_g_pool.Count;
                for (int i = 0; i < instiateCount; i++)
                    obj_g_pool.Add((GameObject)Instantiate(obj_g_pool[0], obj_g_pool[0].transform.position, obj_g_pool[0].transform.rotation));
            }

            for (int i = 0; i < obj_g_list.Count; i++)
            {
                obj_g_pool[i].GetComponent<IT_Obj_Get>().SetData(obj_g_list[i]);
            }
        }
        //pool보다 list가 클 경우 예외처리 해 줘야함
    }
}
