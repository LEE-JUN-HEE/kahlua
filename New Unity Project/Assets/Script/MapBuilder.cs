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
        parser.Load(Application.persistentDataPath + "/hi.xml");

        XmlNode Object_b = parser.FirstChild.ChildNodes[0];
        XmlNode Object_g = parser.FirstChild.ChildNodes[1];

        for (int i = 0; i < Object_b.ChildNodes.Count; i++)
        {
            CObj_Build temp = new CObj_Build();
            temp.SetData(Object_b.ChildNodes[i]);
            obj_b_list.Add(temp) ;//.SetData(Object_b.ChildNodes[i]));
        }
        
        for (int i = 0; i < Object_g.ChildNodes.Count; i++)
        {
            CObj_Get temp = new CObj_Get();
            temp.SetData(Object_b.ChildNodes[i]);
            obj_g_list.Add(temp);//.SetData(Object_b.ChildNodes[i]));
        }

        GameObject[] obj_b_pool = GameObject.FindGameObjectsWithTag("Obj_Build");
        GameObject[] obj_g_pool = GameObject.FindGameObjectsWithTag("Obj_Get");

        //pool보다 list가 클 경우 예외처리 해 줘야함
        for (int i = 0; i < obj_b_list.Count; i++)
        {
            obj_b_pool[i].GetComponent<IT_Obj_Build>().SetData(obj_b_list[i]);
        }

        //for (int i = 0; i < obj_g_list.Count; i++)
        //{
        //    obj_g_pool[i].GetComponent<IT_Obj_Get>().SetData(obj_g_list[i]);
        //}

    }
}
